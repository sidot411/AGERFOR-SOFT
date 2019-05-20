using Agerfor.Controlers;
using DbConnection.Models;
using MaterialDesignThemes.Wpf;
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
    /// Interaction logic for AddPayement.xaml
    /// </summary>
    public partial class AddPayement : Page
    {
        int NumPayement;
        int tempnbrov;
        int tempNumAttribution;
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public AddPayement(int NumPayement)
        {
            InitializeComponent();
            this.NumPayement = NumPayement;
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
                tempNumAttribution = int.Parse(rdr["NumAttribution"].ToString());
                inputPayement.Text = rdr["NumPayement"].ToString();
                inputDatePayement.Text = rdr["DatePayement"].ToString();
                inputNumClient.Text = rdr["NumClient"].ToString();
                inputNomClient.Text = rdr["NomClient"].ToString();
                inputPrenomClient.Text = rdr["PrenomClient"].ToString();
                inputDateNaissance.Text = rdr["DateNaissance"].ToString();
                inputNumCNI.Text = rdr["NumCni"].ToString();
                inputNomProjet.Text = rdr["NomProjet"].ToString();
                inputNomProgramme.Text = rdr["NomProgramme"].ToString();
                inputNumIlot.Text = rdr["NumIlot"].ToString();
                inputNumLot.Text = rdr["NumLot"].ToString();
                inputTypeBien.Text = rdr["TypeBien"].ToString();
                inputNumBloc.Text = rdr["NumBloc"].ToString();
                inputNiveau.Text = rdr["Niveau"].ToString();
                inputNbrPiece.Text = rdr["NbrP"].ToString();
                inputprixtotal.Text = rdr["MontantTotal"].ToString();
                inputprixpayer.Text = rdr["MontantVerse"].ToString();
                inputReste.Text = rdr["Reste"].ToString();
                inputSup.Text = rdr["SurH"].ToString();
                oneTime = false; 
            }
            con.Close();

            string Query2 = "SELECT COUNT(NumVerssement) as count FROM ov WHERE NumPayement='"+NumPayement+"'";
            MySqlDataReader rdr2 = null;
            MySqlConnection con2 = null;
            MySqlCommand cmd2 = null;
            con2 = new MySqlConnection(Database.ConnectionString());
            con2.Open();
            cmd2 = new MySqlCommand(Query2);
            cmd2.Connection = con2;
            rdr2 = cmd2.ExecuteReader();
            bool oneTime2 = true;
            while (rdr2.Read())
            {
                tempnbrov = int.Parse(rdr2["count"].ToString());
            }
            if (tempnbrov <= 0)
            {
                BtnCNL.IsEnabled = BtnCB.IsEnabled = BtnFNPOS.IsEnabled = false;
            }
            else
            {
                BtnCNL.IsEnabled = BtnCB.IsEnabled = BtnFNPOS.IsEnabled = true;
            }
            if (inputReste.Text !="0.00")
            {
                BtnAttestation.IsEnabled = false;
            }
            else
            {
                BtnAttestation.IsEnabled = true;
            }


        }

        private void BtnOV_Click(object sender, RoutedEventArgs e)
        {
          //  ListeVers LV = new ListeVers(0, 0, 0, this);

            ListeVers LV = new ListeVers(int.Parse(inputPayement.Text), decimal.Parse(inputReste.Text),tempNumAttribution, this);
            LV.ShowInTaskbar = false;
            LV.Owner = Application.Current.Windows[0];
            LV.Show();
             /*
            ListeVersement LV = new ListeVersement(int.Parse(inputPayement.Text),decimal.Parse(inputReste.Text));
            DialogHost.Show(LV);*/
        }

        private void BtnCNL_Click(object sender, RoutedEventArgs e)
        {
            CNLPayement CNLP = new CNLPayement(int.Parse(inputPayement.Text), decimal.Parse(inputReste.Text),this);
            CNLP.ShowInTaskbar = false;
            CNLP.Owner = Application.Current.Windows[0];
            CNLP.Show();

            /*CNL cnl = new CNL(int.Parse(inputPayement.Text));
            DialogHost.Show(cnl);*/
        }

        private void BtnFNPOS_Click(object sender, RoutedEventArgs e)
        {
            FNPOSPayement FNPOS = new FNPOSPayement(int.Parse(inputPayement.Text), decimal.Parse(inputReste.Text), this);
            FNPOS.ShowInTaskbar = false;
            FNPOS.Owner = Application.Current.Windows[0];
            FNPOS.Show();

        }

        private void BtnCB_Click(object sender, RoutedEventArgs e)
        {
            CBPayement CBP = new CBPayement(int.Parse(inputPayement.Text), decimal.Parse(inputReste.Text), this);
            CBP.ShowInTaskbar = false;
            CBP.Owner = Application.Current.Windows[0];
            CBP.Show();
        }
    }
}
