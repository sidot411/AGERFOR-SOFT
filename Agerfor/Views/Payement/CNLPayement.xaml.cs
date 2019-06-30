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
        int NumCNL;
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
                NumCNL = int.Parse(rdr["NumCNL"].ToString());
                inputNumDeci.Text = rdr["NumDeci"].ToString();
                inputDateDeci.Text = rdr["DateDeci"].ToString();
                inputMontantCNL.Text = rdr["MontantCNL"].ToString();
                inputEtat.Text = rdr["Etat"].ToString();
                inputDateConserv.Text = rdr["DateConservation"].ToString();
                inputDatecontrole.Text = rdr["DateControle"].ToString();
                inputDatereserve.Text = rdr["DateReserve"].ToString();
      
            }
            if(NumCNL.ToString()!="")
            {
                BtnAddCNL.IsEnabled = false;
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
                if (inputNumDeci.Text != "" && inputDateDeci.Text != "" && inputMontantCNL.Text != "" && inputDateConserv.Text != "")
                {
                    CNLController CNLC = new CNLController();
                    CNLC.ValidationCNL(NumPayement, inputNumDeci.Text, inputDateDeci.Text, decimal.Parse(inputMontantCNL.Text),inputDateConserv.Text);
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
                    MessageBox.Show("Veuillez remplir les champs suivants: Num Décision, Date Décision, Montant CNL , Date Conservation");
                }
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

        private void BtnAddCNL_Click(object sender, RoutedEventArgs e)
        {
            CNLController CNLC = new CNLController();
            CNLC.AjouterCNL(NumPayement, inputEtat.Text);
        }

        private void BtnsaveDateC_Click(object sender, RoutedEventArgs e)
        {
            CNLController CNLC = new CNLController();
            CNLC.updateDateConservation(inputDateConserv.Text, inputEtat.Text, NumPayement);
        }

        private void BtnsaveDateCont_Click(object sender, RoutedEventArgs e)
        {
            CNLController CNLC = new CNLController();
            CNLC.updateDateControle(inputDatecontrole.Text, inputEtat.Text, NumPayement);
        }

        private void BtnsaveDateR_Click(object sender, RoutedEventArgs e)
        {
            CNLController CNLC = new CNLController();
            CNLC.updateDateReserve(inputDatereserve.Text, inputEtat.Text, NumPayement);

        }

        private void BtnsaveEtat_Click(object sender, RoutedEventArgs e)
        {
            CNLController CNLC = new CNLController();
            CNLC.UpdateEtat(inputEtat.Text, NumPayement);
        }

        private void BtndeleteDateC_Click(object sender, RoutedEventArgs e)
        {
            CNLController CNLC = new CNLController();
            CNLC.deleteDateConservation(inputDateConserv.Text, inputEtat.Text, NumPayement);
            inputDateConserv.Text = string.Empty;
        }

        private void BtndeleteDateCont_Click(object sender, RoutedEventArgs e)
        {
            CNLController CNLC = new CNLController();
            CNLC.DeleteDateControle(inputDatecontrole.Text, inputEtat.Text, NumPayement);
            inputDatecontrole.Text = string.Empty;
        }

        private void BtndeleteDateR_Click(object sender, RoutedEventArgs e)
        {
            CNLController CNLC = new CNLController();
            CNLC.DeleteDateReserve(inputDatereserve.Text, inputEtat.Text, NumPayement);
            inputDatereserve.Text = string.Empty;
        }
    }
}
