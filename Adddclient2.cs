using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;

namespace Agerfor.Views.Clients
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Page
    {
        Agerfor.Controlers.MySqlHelper msh = new Agerfor.Controlers.MySqlHelper();
        ClientController cc = new ClientController();
        string NumClient = "";
        public AddClient(string NumClient)
        {
            InitializeComponent();
            this.NumClient = NumClient;
            if(NumClient !="")
            {
                string query = "select * from client where NumClient =" + NumClient;
                MySqlDataReader rdr = null;
                MySqlConnection con = null;
                MySqlCommand cmd = null;

                con = new MySqlConnection(Database.ConnectionString);
                con.Open();
                cmd = new MySqlCommand(query);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                bool oneTime = true;
                while (rdr.Read())
                {
                    if (oneTime)
                    {
                        inputNumClient.Text = rdr["NumClient"].ToString();
                        inputName.Text = rdr["Nom"].ToString();
                        inputPrenom.Text = rdr["Prenom"].ToString();
                        inputNomAR.Text = rdr["NomAR"].ToString();
                        inputPrenomAR.Text = rdr["PrenomAr"].ToString();
                        inputSexe.Text = rdr["Sexe"].ToString();
                        inputDateNaissance.Text = rdr["DateNaissance"].ToString();
                        inputLieuNaissance.Text = rdr["LieuNaissance"].ToString();
                        inputPrenomPere.Text = rdr["PrenomPere"].ToString();
                        inputNomMere.Text = rdr["NomMere"].ToString();
                        inputPrenomMere.Text = rdr["PrenomMere"].ToString();
                        inputnomMereAR.Text = rdr["NomMereAr"].ToString();
                        inputPrenomMereAr.Text = rdr["PrenomMereAr"].ToString();
                        inputNumcni.Text = rdr["Cni"].ToString();
                        inputDateCni.Text = rdr["DaeCni"].ToString();
                        inputLieucni.Text = rdr["LieuCni"].ToString();
						inputTelphone.Text = rdr["Telphone"].ToString();
						inputMobile.Text = rdr["Mobile"].ToString();
						inputSituationFamiliale.Text = rdr["SituationFamiliale"].ToString();
						Nomconjoint.Text = rdr["Nomconjoint"].ToString();
						inputPrenomConjoint.Text = rdr["PrenomConjoint"].ToString();
						inputProffessionConj.Text = rdr["ProffessionConj"].ToString();
						inputDatecreation.Text = rdr["Datecreation"].ToString();
                        inputPrenomPereAR.Text = rdr["PrenomPereAR"].ToString();
						inputVille.Text = rdr["Ville"].ToString();
						inputAdress.Text = rdr["Adress"].ToString();
						inputProffession.Text = rdr["Proffession"].ToString();
						inputNomAutreCntacte.Text = rdr["NomAutreCntacte"].ToString();
						inputTelphoneContact.Text = rdr["TelphoneContact"].ToString();
						inputNomConjArab.Text = rdr["NomConjArab"].ToString();
						inputPrenomCongAr.Text = rdr["PrenomCongAr"].ToString();
					



                        oneTime = false;
                    }
                }

                con.Close();
            }
        }
    

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private Boolean Clientissecure()
        {
            if (inputNumClient.Text != "" && inputName.Text != "" && inputPrenom.Text != "" && inputNomAR.Text != "" && inputPrenomAR.Text != "" && inputDateNaissance.Text != "" && inputLieuNaissance.Text != "" &&
                inputNumcni.Text != "" && inputDateCni.Text != "") 
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }
    }
}
