using DbConnection.Models;
using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;

namespace Agerfor
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        string tempPassword;
        string tempID;
        string tempUserName;
        string tempSprojet;
        string tempSprogramme;
        string tempSclient;
        string tempSdemande;
        string tempSattribution;
        string tempSpayement;
        string tempSremboursement;
        string tempSparametre;
        string tempuserrole;
        string tempdivision;
        public Login()
        {
            InitializeComponent();
            PasswordShow.Visibility = Visibility.Collapsed;
            errorpassword.Visibility = Visibility.Collapsed;
            erroruser.Visibility = Visibility.Collapsed; 

        }
      


        private void PackIcon_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Password.Visibility = Visibility.Collapsed;
            passshow.Text = inputpass.Password.ToString();
            PasswordShow.Visibility = Visibility.Visible;

        }

        private void PackIcon_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Password.Visibility = Visibility.Visible;
            PasswordShow.Visibility = Visibility.Collapsed;
        }

        private void BtnLogin_Click(object sender, RoutedEventArgs e)
        {


            int count = 0;
            DataTable DT = new DataTable();
            string query2 = "select UserName from users";
            MySqlConnection con2 = null;
            MySqlCommand cmd2 = null;
            con2 = new MySqlConnection(Database.ConnectionString());
            cmd2 = new MySqlCommand(query2);
            cmd2.Connection = con2;
            con2.Open();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd2);
            da.Fill(DT);
            con2.Close();
            da.Dispose();
            for (int i = 0; i < DT.Rows.Count; i++) 
            {
                if(inputUserName.Text==DT.Rows[i]["UserName"].ToString())
                {
                    count = 1;
                }
                
            }

            
            string query = "select *,CAST(AES_DECRYPT(UserPassword,'BCGE2380A579C') AS CHAR(50)) AS pass FROM users where UserName='" + inputUserName.Text + "'";
            MySqlDataReader rdr = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            con = new MySqlConnection(Database.ConnectionString());
            con.Open();
            cmd = new MySqlCommand(query);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            bool oneTime = true;
            while (rdr.Read())
            {

                if (oneTime)
                {
                    tempID = rdr["IdUser"].ToString();
                    tempPassword = rdr["pass"].ToString();
                    tempSprojet = rdr["Sprojet"].ToString();
                    tempSprogramme = rdr["Sprogramme"].ToString();
                    tempSclient = rdr["Sclient"].ToString();
                    tempSdemande = rdr["Sdemande"].ToString();
                    tempSattribution = rdr["Sattribution"].ToString();
                    tempSpayement = rdr["Spayement"].ToString();
                    tempSremboursement = rdr["Sremboursement"].ToString();
                    tempSparametre = rdr["Sparametre"].ToString();
                    tempdivision = rdr["Divison"].ToString();
                    tempuserrole = rdr["Role"].ToString();

                }

            }
        

            if (count == 0 && inputpass.Password.ToString() != "")
            {
                erroruser.Visibility = Visibility.Visible;
                inputpass.Clear();
            }

            else if (count == 1 && inputpass.Password.ToString() == tempPassword )
                {
               
                    MainWindow mw = new MainWindow(tempSprojet,tempSprogramme,tempSclient,tempSdemande,tempSattribution,tempSpayement,tempSremboursement,tempSparametre,tempuserrole,tempdivision);
                    mw.Show();
                    mw.User.Text = inputUserName.Text;
                    mw.ID.Text = tempID;
                    this.Close();
                }

                else if (tempUserName == inputUserName.Text && tempPassword != inputpass.Password.ToString())
                {
                    erroruser.Visibility = Visibility.Collapsed;
                    errorpassword.Visibility = Visibility.Visible;
                }

            else if (count==1 && inputpass.Password.ToString()=="")
            {
                erroruser.Visibility = Visibility.Collapsed;
                errorpassword.Visibility = Visibility.Visible;
            }

            else if (count == 0 && inputpass.Password.ToString() == "")
            {
                erroruser.Visibility = Visibility.Visible;
                errorpassword.Visibility = Visibility.Visible;
            }

            
        }

        private void BtnFermer_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

      
    }
}
