using school_management_app.Services.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;
using school_management_app.Models;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace school_management_app.Services
{
    public class CommonService : ICommonRepository
    {
        private static readonly byte[] _salt = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static readonly int _iterations = 10000;

        // Form Colors DNU
        private String EbonyClay = "#25283B";
        private String Pizazz = "#FF8F00";

        public DataTable ConvertListToDataTable<T>(List<T> list)
        {
            DataTable dataTable = new DataTable();

            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                dataTable.Columns.Add(property.Name, property.PropertyType);
            }

            foreach (T item in list)
            {
                DataRow dataRow = dataTable.NewRow();

                foreach (PropertyInfo property in properties)
                {
                    dataRow[property.Name] = property.GetValue(item);

                }

                dataTable.Rows.Add(dataRow);
            }

            return dataTable;
        }

        public String Encrypt(String plainText)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(plainText, _salt, _iterations))
            {
                byte[] key = pbkdf2.GetBytes(32);
                byte[] iv = pbkdf2.GetBytes(16);

                using (Aes aes = Aes.Create())
                {
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key = key;
                    aes.IV = iv;

                    using (ICryptoTransform encryptor = aes.CreateEncryptor())
                    {
                        using (MemoryStream ms = new MemoryStream())
                        {
                            using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))

                            {
                                using (StreamWriter sw = new StreamWriter(cs))
                                {
                                    sw.Write(plainText);

                                }
                            }

                            return Convert.ToBase64String(ms.ToArray());
                        }
                    }
                }
            }
        }

        public String Decrypt(String cipherText)
        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(cipherText, _salt, _iterations))
            {
                byte[] key = pbkdf2.GetBytes(32);
                byte[] iv = pbkdf2.GetBytes(16);

                using (Aes aes = Aes.Create())
                {
                    aes.Padding = PaddingMode.PKCS7;
                    aes.Key = key;
                    aes.IV = iv;

                    using (ICryptoTransform decryptor = aes.CreateDecryptor())
                    {
                        using (MemoryStream ms = new MemoryStream(cipherBytes))
                        {
                            using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                            {
                                using (StreamReader sr = new StreamReader(cs))
                                {
                                    return sr.ReadToEnd();

                                }
                            }
                        }
                    }
                }
            }
        }

        public String HashPassword(string password)
        {
            var prf = KeyDerivationPrf.HMACSHA256;
            var rng = RandomNumberGenerator.Create();
            const int iterCount = 10000;
            const int saltSize = 128 / 8;
            const int numBytesRequested = 256 / 8;

            // Produce a version 3 (see comment above) text hash.
            var salt = new byte[saltSize];
            rng.GetBytes(salt);
            var subkey = KeyDerivation.Pbkdf2(password, salt, prf, iterCount, numBytesRequested);

            var outputBytes = new byte[13 + salt.Length + subkey.Length];
            outputBytes[0] = 0x01; // format marker
            WriteNetworkByteOrder(outputBytes, 1, (uint)prf);
            WriteNetworkByteOrder(outputBytes, 5, iterCount);
            WriteNetworkByteOrder(outputBytes, 9, saltSize);
            Buffer.BlockCopy(salt, 0, outputBytes, 13, salt.Length);
            Buffer.BlockCopy(subkey, 0, outputBytes, 13 + saltSize, subkey.Length);
            return Convert.ToBase64String(outputBytes);
        }

        public bool VerifyHashedPassword(String hashedPassword, String providedPassword)
        {
            var decodedHashedPassword = Convert.FromBase64String(hashedPassword);

            // Wrong version
            if (decodedHashedPassword[0] != 0x01)
                return false;

            // Read header information
            var prf = (KeyDerivationPrf)ReadNetworkByteOrder(decodedHashedPassword, 1);
            var iterCount = (int)ReadNetworkByteOrder(decodedHashedPassword, 5);
            var saltLength = (int)ReadNetworkByteOrder(decodedHashedPassword, 9);

            // Read the salt: must be >= 128 bits
            if (saltLength < 128 / 8)
            {
                return false;
            }
            var salt = new byte[saltLength];
            Buffer.BlockCopy(decodedHashedPassword, 13, salt, 0, salt.Length);

            // Read the subkey (the rest of the payload): must be >= 128 bits
            var subkeyLength = decodedHashedPassword.Length - 13 - salt.Length;
            if (subkeyLength < 128 / 8)
            {
                return false;
            }
            var expectedSubkey = new byte[subkeyLength];
            Buffer.BlockCopy(decodedHashedPassword, 13 + salt.Length, expectedSubkey, 0, expectedSubkey.Length);

            // Hash the incoming password and verify it
            var actualSubkey = KeyDerivation.Pbkdf2(providedPassword, salt, prf, iterCount, subkeyLength);
            return actualSubkey.SequenceEqual(expectedSubkey);
        }

        public void WriteNetworkByteOrder(byte[] buffer, int offset, uint value)
        {
            buffer[offset + 0] = (byte)(value >> 24);
            buffer[offset + 1] = (byte)(value >> 16);
            buffer[offset + 2] = (byte)(value >> 8);
            buffer[offset + 3] = (byte)(value >> 0);
        }

        public uint ReadNetworkByteOrder(byte[] buffer, int offset)
        {
            return ((uint)(buffer[offset + 0]) << 24)
                | ((uint)(buffer[offset + 1]) << 16)
                | ((uint)(buffer[offset + 2]) << 8)
                | ((uint)(buffer[offset + 3]));
        }
    }
}
