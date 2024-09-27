using school_management_app.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Services.Interfaces
{
    public interface ICommonRepository
    {
        DataTable ConvertListToDataTable<T>(List<T> list);
        String Encrypt(String plainText);
        String Decrypt(String cipherText);
        String HashPassword(string password);
        bool VerifyHashedPassword(String hashedPassword, String providedPassword);
        void WriteNetworkByteOrder(byte[] buffer, int offset, uint value);
        uint ReadNetworkByteOrder(byte[] buffer, int offset);
    }
}
