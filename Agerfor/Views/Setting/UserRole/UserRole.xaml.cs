using System;
using System.Collections.Generic;
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
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using MaterialDesignThemes.Wpf;

namespace Agerfor.Views.Setting.UserRole
{
    /// <summary>
    /// Interaction logic for UserRole.xaml
    /// </summary>
    public partial class UserRole : Page
    {
        string tempUserName;
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public UserRole(string tempUserName)
        {
            InitializeComponent();
            this.tempUserName = tempUserName;
            msh.LoadData("select * from users", dataViewUser);
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            if (inputPasseword.Password.ToString() == inputConfirmPassword.Password.ToString())
            {
                UsersControlle UC = new UsersControlle();
                UC.AddUser(inputUserName.Text, inputPasseword.Password.ToString(), inputDivision.Text, inputRole.Text, SP.IsChecked.ToString(), SPROG.IsChecked.ToString(), SC.IsChecked.ToString(), SD.IsChecked.ToString(), SA.IsChecked.ToString(), SPAY.IsChecked.ToString(), SR.IsChecked.ToString(), SPAR.IsChecked.ToString());
                inputUserName.Text = inputDivision.Text = inputRole.Text = string.Empty;
                inputPasseword.Clear();
                inputConfirmPassword.Clear();
                SP.IsChecked = SPROG.IsChecked = SC.IsChecked = SD.IsChecked = SA.IsChecked = SP.IsChecked = SR.IsChecked = SPAR.IsChecked = false;
                msh.LoadData("select * from users", dataViewUser);

            }
            else
            {
                MessageBox.Show("Le mot de passe de confirmation est différent du mot de passe introduit !");
            }
        }

        private void BtnModifier_Click(object sender, RoutedEventArgs e)
        {
           
            if (inputPasseword.Password.ToString() == inputConfirmPassword.Password.ToString())
            {
            
                UsersControlle UC = new UsersControlle();
                UC.EditUser(inputUserName.Text, inputPasseword.Password.ToString(), inputDivision.Text, inputRole.Text, SP.IsChecked.ToString(), SPROG.IsChecked.ToString(), SC.IsChecked.ToString(), SD.IsChecked.ToString(), SA.IsChecked.ToString(), SPAY.IsChecked.ToString(), SR.IsChecked.ToString(), SPAR.IsChecked.ToString(), tempUserName);
                inputUserName.Text = inputDivision.Text = inputRole.Text = string.Empty;
                inputPasseword.Clear();
                inputConfirmPassword.Clear();
                SP.IsChecked = SPROG.IsChecked = SC.IsChecked = SD.IsChecked = SA.IsChecked = SP.IsChecked = SPAY.IsChecked = SR.IsChecked = SPAR.IsChecked = false;
                msh.LoadData("select * from users", dataViewUser);
                MessageBox.Show("Veuillez redémarrer l'application dans le poste de l'utilisateurs pour enregistrer les chagements");

            }

            else
            {
                MessageBox.Show("Le mot de passe de confirmation est différent du mot de passe introduit !");
            }
         
        }

        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            UsersControlle UC = new UsersControlle();
            UC.deleteUser(tempUserName);
            inputUserName.Text = inputDivision.Text = inputRole.Text = string.Empty;
            inputPasseword.Clear();
            inputConfirmPassword.Clear();
            SP.IsChecked = SPROG.IsChecked = SC.IsChecked = SD.IsChecked = SA.IsChecked = SP.IsChecked = SPAY.IsChecked = SR.IsChecked = SPAR.IsChecked = false;
            msh.LoadData("select * from users", dataViewUser);
        }

        private void dataViewUser_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewUser.SelectedCells[0];
            tempUserName = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
     

            string query = "select *,CAST(AES_DECRYPT(UserPassword,'BCGE2380A579C') AS CHAR(50)) AS pass from users where UserName='" + tempUserName+"'";
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
                    
                    inputUserName.Text = rdr["UserName"].ToString();
                    inputDivision.Text = rdr["Divison"].ToString();
                    inputRole.Text = rdr["Role"].ToString();
                    inputPasseword.Password = rdr["pass"].ToString();
                    inputConfirmPassword.Password = rdr["pass"].ToString();
                    SP.IsChecked = bool.Parse(rdr["Sprojet"].ToString());
                    SPROG.IsChecked = bool.Parse(rdr["Sprogramme"].ToString());
                    SC.IsChecked = bool.Parse(rdr["Sclient"].ToString());
                    SD.IsChecked = bool.Parse(rdr["Sdemande"].ToString());
                    SA.IsChecked = bool.Parse(rdr["Sattribution"].ToString());
                    SPAY.IsChecked = bool.Parse(rdr["Spayement"].ToString());
                    SR.IsChecked = bool.Parse(rdr["Sremboursement"].ToString());
                    SPAR.IsChecked = bool.Parse(rdr["Sparametre"].ToString());

                }
            }
        }
    }
}
