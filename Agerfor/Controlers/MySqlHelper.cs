using System;
using System.Data;
using System.Windows.Controls;
using MySql.Data.MySqlClient;


using System.Windows;
using DbConnection.Models;
using System.Data.SqlClient;

namespace Agerfor.Controlers
{
    class MySqlHelper
    {
        private MySqlCommand cmd;
        private DataTable dt = new DataTable();

        public void ExecuteQuery(string query)
        {
           
                MySqlConnection conn = new MySqlConnection(Database.ConnectionString);
                conn.Open();
                MySqlCommand cmd = conn.CreateCommand();
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                conn.Close();
           

        } 

        public void LoadData(string cmdTxt, DataGrid gridView)
        {
            try
            {
                string MyConString = "server=localhost;user id=root;database=agerforsoft";
                using (MySqlConnection connection = new MySqlConnection(MyConString))
                {
                    connection.Open();
                    using (MySqlCommand cmdSel = new MySqlCommand(cmdTxt, connection))
                    {
                        DataTable dt = new DataTable();
                        MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                        da.Fill(dt);
                        gridView.DataContext = dt;
                    }

                    connection.Close();
                }
            }
            catch (Exception)
            {
            }
        }

        public void LoadData2(string cmdTxt, DataGrid gridView)
        {
            string MyConString = "server=localhost;user id=root;database=agerforsoft";

            string sql = "SELECT * from client";

            using (MySqlConnection connection = new MySqlConnection(MyConString))
            {
                connection.Open();
                using (MySqlCommand cmdSel = new MySqlCommand(sql, connection))
                {
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(cmdSel);
                    da.Fill(dt);
                    gridView.DataContext = dt;
                }

                connection.Close();
            }
        }

        public void FillDropDownList(string Query, ComboBox DropDownName, string FillWith)
        {
            try
            {
                MySqlDataReader rdr = null;
                MySqlConnection con = null;
                MySqlCommand cmd = null;

                con = new MySqlConnection(Database.ConnectionString);
                con.Open();
                cmd = new MySqlCommand(Query);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                while (rdr.Read())
                {
                    DropDownName.Items.Add(rdr[FillWith].ToString());
                }

                DropDownName.SelectedItem = null;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("No connection to Database");
               
            }
        }
    }
}    
