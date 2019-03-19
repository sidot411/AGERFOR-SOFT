using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Windows.Navigation;

namespace Agerfor.Views.Payement
{
    /// <summary>
    /// Interaction logic for CNLPayement.xaml
    /// </summary>
    public partial class CNLPayement : Window
    {
        int NumPayement;
        AddPayement AddPayement;
        decimal Reste;
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public CNLPayement(int NumPayement, decimal Reste, AddPayement AddPayement)
        {
            InitializeComponent();
            this.NumPayement = NumPayement;
            this.AddPayement = AddPayement;
            this.Reste = Reste;
            string query = "select * from cnl where NumCNL=(select MAX(NumCNL)) and NumPayement='"+NumPayement+"'";
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
                inputNumDeci.Text = rdr["NumDeci"].ToString();
                inputDateDeci.Text = rdr["DateDeci"].ToString();
                inputMontantCNL.Text = rdr["MontantCNL"].ToString();
                inputDateRecu.Text = rdr["DateRecu"].ToString();
                inputNumRecu.Text = rdr["NumRecu"].ToString();
            }

            if(inputNumDeci.Text!="")
            {
               BtnValiderverssement.IsEnabled = false;
            }
        }

        private void BtnValiderverssement_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.Parse(inputMontantCNL.Text) <= Reste)
            {
                CNLController CNLC = new CNLController();
                CNLC.AjouterCNL(NumPayement, inputNumDeci.Text, inputDateDeci.Text, decimal.Parse(inputMontantCNL.Text), inputDateRecu.Text, inputNumRecu.Text);
                msh.ExecuteQuery("update payement set MontantVerse=MontantVerse+" + decimal.Parse(inputMontantCNL.Text) + ",Reste=MontantTotal-MontantVerse where NumPayement='" + NumPayement + "'");
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
                MessageBox.Show("Le montant CNL est supérieux au montant reste à payé du bien veuillez introduire une valeur inferieur");
            }
        }

        private void BtnAnnuleCNL_Click(object sender, RoutedEventArgs e)
        {
            CNLController CNLC = new CNLController();
            CNLC.AnnulerCNL(NumPayement);
        }
    }
}
