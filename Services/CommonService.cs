using school_management_app.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace school_management_app.Services
{
    public class CommonService : ICommonRepository
    {
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
    }
}
