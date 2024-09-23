using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Windows;
using System.Configuration;
using school_management_app.Services.Interfaces;

namespace school_management_app.Services
{
    public class DataSource
    {
        private static MySqlConnection _connection;
        private static MySqlCommand _command;
        private static DataTable dt;
        private static MySqlDataReader _reader;

        public static void EstablishConnection()
        {
            DotNetEnv.Env.Load();

            try
            {
                MySqlConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = ConfigurationManager.AppSettings["SERVER"];
                builder.UserID = ConfigurationManager.AppSettings["USERID"];
                builder.Password = ConfigurationManager.AppSettings["PASSWORD"];
                builder.Database = "SCHOOLMANAGEMENT";
                builder.SslMode = MySqlSslMode.Disabled;

                _connection = new MySqlConnection(builder.ToString());
                MessageBox.Show("Database connected successfully", "Connection", MessageBoxButton.OK);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Connection Failed");
            }
        }

        public static MySqlCommand RunQuery(string query)
        {
            try
            {
                if (_connection != null)
                {
                    _connection.Open();
                    _command = _connection.CreateCommand();
                    _command.CommandType = CommandType.Text;
                    _command.CommandText = query;

                    _command.ExecuteNonQuery();
                    _connection.Close();
                }
            }
            catch (Exception ex)
            {
                _connection.Close();
            }

            return _command;
        }

        public List<T> ExecuteQuery<T>(string query) where T : class
        {
            List<T> result = new List<T>();

            try
            {
                using (MySqlCommand command = new MySqlCommand(query, _connection))
                {
                    _connection.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())

                    {
                        while (reader.Read())
                        {
                            T entity = Activator.CreateInstance<T>();
                            for (int i = 0; i < reader.FieldCount; i++)
                            {
                                var propertyName = reader.GetName(i);
                                var propertyInfo = entity.GetType().GetProperty(propertyName);
                                if (propertyInfo != null && propertyInfo.CanWrite)
                                {
                                    propertyInfo.SetValue(entity, reader.GetValue(i));
                                }
                            }
                            result.Add(entity);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                _connection.Close();
            }

            return result;
        }

        public List<T> ExecuteQueryAndConvertToList<T>(string query, Func<IDataRecord, T> rowMapper = null) where T : class
        {
            List<T> result = new List<T>();

            if (_connection.State !=  ConnectionState.Open)
            {
                _connection.Open();

            }

            using (MySqlCommand command = new MySqlCommand(query, _connection))
            {
                using (MySqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.HasRows)
                    {
                        if (rowMapper == null)
                        {
                            // Dynamic Mapping
                            string[] columnNames = Enumerable.Range(0, reader.FieldCount)
                                                            .Select(i => reader.GetName(i))
                                                            .ToArray();

                            while (reader.Read())
                            {
                                var row = new Dictionary<string, object>();
                                for (int i = 0; i < reader.FieldCount; i++)
                                {
                                    row.Add(columnNames[i], reader[i]);
                                }

                                // Use reflection to map the dictionary to the entity type
                                T entity = Activator.CreateInstance<T>();
                                foreach (var propertyInfo in entity.GetType().GetProperties())
                                {
                                    if (row.ContainsKey(propertyInfo.Name))
                                    {
                                        propertyInfo.SetValue(entity, row[propertyInfo.Name]);
                                    }
                                }

                                result.Add(entity);
                            }
                        }
                        else
                        {
                            // Custom Row Mapping
                            while (reader.Read())
                            {
                                result.Add(rowMapper(reader));
                            }
                        }
                    }
                }
            }

            return result;
        }


    }
}
