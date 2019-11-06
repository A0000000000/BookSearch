using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web;
using BookManager.Domain;


namespace BookManager.Utils
{
    public static class ORMUtils
    {
        private static SqlConnection sqlConnection = null;
        private static string connStr = "server=localhost;database=BookManager;uid=sa;pwd=1998";
        static ORMUtils()
        {
            sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
        }

        public static List<T> GetBeans<T>(T obj = null, bool like = false)
            where T : class, new()
        {
            SqlCommand sqlCommand = sqlConnection.CreateCommand();
            StringBuilder sql = new StringBuilder();            
            sql.Append("select * from t_" + char.ToLower(typeof(T).Name[0]) + typeof(T).Name.Substring(1) + " where 1=1");
            if (obj != null)
            {
                PropertyInfo[] properties = typeof(T).GetProperties(BindingFlags.Instance | BindingFlags.Public);
                foreach (PropertyInfo info in properties)
                {
                    string name = info.Name;
                    string value = info.GetValue(obj)?.ToString();
                    if (!string.IsNullOrEmpty(value))
                    {
                        sql.Append(" and " + char.ToLower(name[0]) + name.Substring(1) + (like ? " like " : " = ") + "'" + value + "'");
                    }
                }
            }
            List<T> res = new List<T>();
            sqlCommand.CommandText = sql.ToString();
            SqlDataReader reader = sqlCommand.ExecuteReader();
            while (reader.Read())
            {
                T tmp = Activator.CreateInstance<T>();
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string name = char.ToUpper(reader.GetName(i)[0]) + reader.GetName(i).Substring(1);
                    string value = reader.GetString(i);
                    typeof(T).GetProperty(name)?.SetValue(tmp, value);
                }
                res.Add(tmp);
            }
            if (!reader.IsClosed)
            {
                reader.Close();
            }
            sqlCommand.Dispose();
            return res;
        }
    }
}