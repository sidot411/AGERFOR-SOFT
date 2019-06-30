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
    /// Interaction logic for CBPayement.xaml
    /// </summary>
    public partial class CBPayement : Window
    {
        int NumPayement;
        AddPayement AddPayement;
        decimal Reste;
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public CBPayement(int NumPayement, decimal Reste, AddPayement AddPayement)
        {
            InitializeComponent();
            this.NumPayement = NumPayement;
            this.AddPayement = AddPayement;
            this.Reste = Reste;
            string query = "select * FROM creditb  where NumCB=(select MAX(NumCB)) and NumPayement='" + NumPayement + "'";
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
                inputNumConv.Text = rdr["NumConvBan"].ToString();
                inputDateConv.Text = rdr["DateConv"].ToString();
                inputNomBanque.Text = rdr["NomBanque"].ToString();
                inputBIC.Text = rdr["BIC"].ToString();
                inputMontant.Text = rdr["MontantCb"].ToString();
            }

            if (inputNumConv.Text != "")
            {
                BtnValiderCB.IsEnabled = false;
            }
        }

        private void BtnValiderCB_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.Parse(inputMontant.Text) <= Reste)
            {
                CreditBancaireController CBC = new CreditBancaireController();
                CBC.ValiderCreditBancaire(NumPayement,inputNumConv.Text, inputDateConv.Text, inputNomBanque.Text, inputBIC.Text, decimal.Parse(inputMontant.Text));
                msh.ExecuteQuery("update payement set MontantVerse=MontantVerse+" + decimal.Parse(inputMontant.Text) + ",Reste=MontantTotal-MontantVerse where NumPayement='" + NumPayement + "'");
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
    }
}
