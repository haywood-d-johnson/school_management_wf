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
        String Encrypt(string plainText);
        String Decrypt(string cipherText);

    }
}
