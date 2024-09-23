﻿using school_management_app.Services.Interfaces;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.IO;

namespace school_management_app.Services
{
    public class CommonService : ICommonRepository
    {
        private static readonly byte[] _salt = new byte[] { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        private static readonly int _iterations = 10000;

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

        public String Encrypt(string plainText)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(plainText, _salt, _iterations))
            {
                byte[] key = pbkdf2.GetBytes(32);
                byte[] iv = pbkdf2.GetBytes(16);

                using (Aes aes = Aes.Create())
                {
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

        public String Decrypt(string cipherText)

        {
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(cipherText, _salt, _iterations))
            {
                byte[] key = pbkdf2.GetBytes(32);
                byte[] iv = pbkdf2.GetBytes(16);

                using (Aes aes = Aes.Create())
                {
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
    }
}
