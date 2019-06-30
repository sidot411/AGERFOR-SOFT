using Agerfor.Controlers;
using DbConnection.Models;
using MySql.Data.MySqlClient;
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


namespace Agerfor.Views.Payement
{
    /// <summary>
    /// Interaction logic for FNPOSPayement.xaml
    /// </summary>
    public partial class FNPOSPayement : Window
    {
        int NumPayement;
        AddPayement AddPayement;
        decimal Reste;
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public FNPOSPayement(int NumPayement, decimal Reste, AddPayement AddPayement)
        {
            InitializeComponent();
            this.NumPayement = NumPayement;
            this.Reste = Reste;
            this.AddPayement = AddPayement;
            string query = "select * FROM fnpos where NumFNPOS=(select MAX(NumFNPOS)) and NumPayement='" + NumPayement + "'";
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
                inputDeciF.Text = rdr["NumDeciF"].ToString();
                inputDateDeciF.Text = rdr["DateDeciF"].ToString();
                inputMontantFNPOS.Text = rdr["MontantFNPOS"].ToString();
                
            }

            if (inputDeciF.Text != "")
            {
                BtnValiderFNPOS.IsEnabled = false;
            }
        }

        private void BtnValiderFNPOS_Click(object sender, RoutedEventArgs e)
        {

            if (decimal.Parse(inputMontantFNPOS.Text) <= Reste)
            {
                FNPOSController FNPOSC = new FNPOSController();
                FNPOSC.AjouterFNPOS(NumPayement, inputDeciF.Text, inputDateDeciF.Text, decimal.Parse(inputMontantFNPOS.Text));
                msh.ExecuteQuery("update payement set MontantVerse=MontantVerse+" + decimal.Parse(inputMontantFNPOS.Text) + ",Reste=MontantTotal-MontantVerse where NumPayement='" + NumPayement + "'");
                string query = "select * from payement where NumPayement='" + NumPayement + "'";
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
                    AddPayement.inputprixtotal.Text = rdr["MontantTotal"].ToString();
                    AddPayement.inputprixpayer.Text = rdr["MontantVerse"].ToString();
                    AddPayement.inputReste.Text = rdr["Reste"].ToString();
                }
                MainWindow mainWindows = (MainWindow)Application.Current.Windows[0];
                mainWindows.Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
                mainWindows.Frame.Navigate(AddPayement);
                mainWindows.currentWindow.Text = "Payement";
                mainWindows.Activate();
                this.Close();
            }
            else
            {
                MessageBox.Show("Le montant FNPOS est supérieux au montant reste à payé du bien veuillez introduire une valeur inferieur");
            }
        }
        
    }
}
