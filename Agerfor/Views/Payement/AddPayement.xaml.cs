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
        int refprogramme;
        string tempetat;
        string TypeProgramme;
        string tempNumDeci;
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
                refprogramme = int.Parse(rdr["RefProgramme"].ToString());

                oneTime = false; 
            }
            con.Close();


            string Query3 = "select TypeProgramme from programme where RefProgramme='" + refprogramme + "'";
            MySqlDataReader rdr3 = null;
            MySqlConnection con3 = null;
            MySqlCommand cmd3 = null;
            con3 = new MySqlConnection(Database.ConnectionString());
            con3.Open();
            cmd3 = new MySqlCommand(Query3);
            cmd3.Connection = con3;
            rdr3 = cmd3.ExecuteReader();
            bool oneTime3 = true;
            while (rdr3.Read())
            {
                TypeProgramme = rdr3["TypeProgramme"].ToString();
            }
            con3.Close();

            string Query2 = "SELECT COUNT(NumVerssement) as count, Etat FROM ov WHERE NumPayement = '" + NumPayement + "' ORDER BY NumVerssement LIMIT 1 ";
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
                tempetat = rdr2["Etat"].ToString();
            }
          
            if (tempnbrov <= 0 || tempetat=="En cours" ||  TypeProgramme!="LPA")
            {
           
                BtnCNL.IsEnabled = BtnCB.IsEnabled = BtnFNPOS.IsEnabled = false;
            }
            else
            {
                
                BtnCNL.IsEnabled = BtnCB.IsEnabled = BtnFNPOS.IsEnabled = true;
            }
            if (inputReste.Text !="0.00")
            {
                BtnAttestation.IsEnabled  = BtnMainlever.IsEnabled= false;
                
            }
            else
            {
                BtnAttestation.IsEnabled = BtnMainlever.IsEnabled = true;
            }
            con2.Close();


            string Query4 = "SELECT NumDeci FROM cnl WHERE NumPayement = '" + NumPayement + "'";
            MySqlDataReader rdr4 = null;
            MySqlConnection con4 = null;
            MySqlCommand cmd4 = null;
            con4 = new MySqlConnection(Database.ConnectionString());
            con4.Open();
            cmd4 = new MySqlCommand(Query4);
            cmd4.Connection = con4;
            rdr4 = cmd4.ExecuteReader();
            bool oneTime4 = true;
            while (rdr4.Read())
            {
                tempNumDeci = rdr4["NumDeci"].ToString();
            }

            if(tempNumDeci =="")
            {
                BtnDec.IsEnabled = false;

            }

            else
            {
                BtnDec.IsEnabled = true;
            }


        }

        private void BtnOV_Click(object sender, RoutedEventArgs e)
        {
          //  ListeVers LV = new ListeVers(0, 0, 0, this);

            ListeVers LV = new ListeVers(int.Parse(inputPayement.Text), decimal.Parse(inputReste.Text),tempNumAttribution, this,inputNumClient.Text,inputNomProgramme.Text);
            LV.ShowInTaskbar = false;
            LV.Owner = Application.Current.Windows[0];
            LV.Show();
             /*
            ListeVersement LV = new ListeVersement(int.Parse(inputPayement.Text),decimal.Parse(inputReste.Text));
            DialogHost.Show(LV);*/
        }

        private void BtnCNL_Click(object sender, RoutedEventArgs e)
        {
            CNLPayement CNLP = new CNLPayement(int.Parse(inputPayement.Text), decimal.Parse(inputReste.Text),this,tempNumAttribution);
            CNLP.ShowInTaskbar = false;
            CNLP.Owner = Application.Current.Windows[0];
            CNLP.Show();

            /*CNL cnl = new CNL(int.Parse(inputPayement.Text));
            DialogHost.Show(cnl);*/
        }

        private void BtnFNPOS_Click(object sender, RoutedEventArgs e)
        {
            FNPOSPayement FNPOS = new FNPOSPayement(int.Parse(inputPayement.Text), decimal.Parse(inputReste.Text), this,tempNumAttribution);
            FNPOS.ShowInTaskbar = false;
            FNPOS.Owner = Application.Current.Windows[0];
            FNPOS.Show();

        }

        private void BtnCB_Click(object sender, RoutedEventArgs e)
        {
            CBPayement CBP = new CBPayement(int.Parse(inputPayement.Text), decimal.Parse(inputReste.Text), this,tempNumAttribution);
            CBP.ShowInTaskbar = false;
            CBP.Owner = Application.Current.Windows[0];
            CBP.Show();
        }

        private void BtnDec_Click(object sender, RoutedEventArgs e)
        {
            DecisionReservation DR = new DecisionReservation(int.Parse(inputPayement.Text),tempNumAttribution);
           
            DR.ShowInTaskbar = false;
            DR.Owner = Application.Current.Windows[0];
            DR.Show();
        }

        private void BtnMainlever_Click(object sender, RoutedEventArgs e)
        {
            MainLeve ML = new MainLeve(int.Parse(inputPayement.Text),tempNumAttribution);
            ML.ShowInTaskbar = false;
            ML.Owner = Application.Current.Windows[0];
            ML.Show();
        }

        private void BtnVSP_Click(object sender, RoutedEventArgs e)
        {
            VSP VSP = new VSP(int.Parse(inputPayement.Text),tempNumAttribution);
            VSP.ShowInTaskbar = false;
            VSP.Owner = Application.Current.Windows[0];
            VSP.Show();
        }
    }
}
