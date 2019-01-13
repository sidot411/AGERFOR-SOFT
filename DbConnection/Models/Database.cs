using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DbConnection.Models
{

    public class Database 
    {
       

        public static string ConnectionString()
        {
            string ConnectionString;
            string Id = "server=";
            string User = "user id=";
            string database = "database=";
            string CHARSET = "CHARSET=utf8";
            string sqlLiteFileName = "dbaccess.sqlite";

            using (SQLiteConnection conn = new SQLiteConnection("data source =" + sqlLiteFileName))
            {
                conn.Open();
                using (var sqlCommand = new SQLiteCommand("select * from DbInfo", conn))
                {
                    using (SQLiteDataReader reader = sqlCommand.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Id = Id+reader["SERVER"].ToString();
                            User = User + reader["USER"].ToString();
                            database = database + reader["NAME"].ToString();


                        }
                        conn.Close();
                    }
                }
               
            }
            ConnectionString = Id + ";" + User + ";" + database + ";" + CHARSET;
            return ConnectionString;
        }

    }

}
