using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data.SQLite;
using MySql.Data.MySqlClient;

namespace DbConnection.Models
{
    /// <summary>
    /// Interaction logic for BDD.xaml
    /// </summary>
    public partial class BDD : Page
    {
        
        public BDD()
        {
            InitializeComponent();
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
                            inputServeur.Text = reader["SERVER"].ToString();
                            inputNomBDD.Text = reader["NAME"].ToString();
                            inputPort.Text = reader["PORT"].ToString();
                            inputNomUtilisatur.Text = reader["USER"].ToString();
                            inputMotdePass.Text = reader["PASSWORD"].ToString();


                        }
                        conn.Close();
                    }
                }

            }
        }

        private void BtnBddInfo_Click(object sender, RoutedEventArgs e)
        {
            string sqlLiteFileName = "dbaccess.sqlite";

  
            using (SQLiteConnection conn = new SQLiteConnection("data source =" + sqlLiteFileName))
            {
                conn.Open();
                using (var sqlCommand = new SQLiteCommand("UPDATE DbInfo set SERVER=@Server, NAME=@NameDb, PORT=@Port, USER=@User, PASSWORD=@Password where Id=1", conn)) 
                {
                    sqlCommand.Parameters.AddWithValue("@Server", inputServeur.Text);
                    sqlCommand.Parameters.AddWithValue("@Namedb", inputNomBDD.Text);
                    sqlCommand.Parameters.AddWithValue("@Port", inputPort.Text);
                    sqlCommand.Parameters.AddWithValue("@User", inputNomUtilisatur.Text);
                    sqlCommand.Parameters.AddWithValue("@Password", inputMotdePass.Text); 
                    sqlCommand.ExecuteNonQuery();
                    conn.Close();
                }

            }

            }

        private void BtnTestCon_Click(object sender, RoutedEventArgs e)
        {
            try { 
            MySqlConnection conn = new MySqlConnection("server='"+inputServeur.Text+"';user id='"+inputNomUtilisatur.Text+"';database='"+inputNomBDD.Text+"'; CHARSET=utf8");
            conn.Open();
                MessageBox.Show("Connected", "Base de donnée", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch(Exception)
            {
                MessageBox.Show("Not Connected","Base de donnée", MessageBoxButton.OK, MessageBoxImage.Error);
            }

       
        }
    }

}

       

    