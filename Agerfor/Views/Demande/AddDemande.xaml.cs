using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Globalization;

namespace Agerfor.Views.Demande
{
    /// <summary>
    /// Interaction logic for AddDemande.xaml
    /// </summary>
    public partial class AddDemande : Page
    {
        string NumDemande2 ="";
        Agerfor.Controlers.MySqlHelper msh = new Agerfor.Controlers.MySqlHelper();
        DemandeController DC = new DemandeController();
        
        public AddDemande(string NumDemande)
        {
            InitializeComponent();
            msh.FillDropDownList("select NomWilaya from wilaya", inputLieuCni, "NomWilaya");
            msh.FillDropDownList("select NomWilaya from wilaya", inputLieuNaissance, "NomWilaya");
            this.NumDemande2 = NumDemande;
            inputNumDemande.IsEnabled = inputNum.IsEnabled = inputNom.IsEnabled = inputPrenom.IsEnabled = inputDateNaissance.IsEnabled = inputNumcni.IsEnabled = inputDateCni.IsEnabled = inputLieuCni.IsEnabled = inputLieuNaissance.IsEnabled = inputDateDemande.IsEnabled= inputTypeDemande.IsEnabled=inputMotifDemande.IsEnabled=inputStatutDemande.IsEnabled= false;

            

            if (NumDemande !="")

            {
                
                string query = "select NumDemande,DateDemande,RefClient,Motif,TypeDemande,StatutDemande,Nom,Prenom,DateNaissance,LieuNaissance,Cni,DateCni,LieuCni from demande,client where demande.RefClient=client.NumClient and demande.NumDemande ="+NumDemande;
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
                        inputNumDemande.Text = rdr["NumDemande"].ToString();
                        inputDateDemande.SelectedDate = DateTime.ParseExact(rdr["DateDemande"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        inputTypeDemande.Text = rdr["TypeDemande"].ToString();
                        inputMotifDemande.Text = rdr["Motif"].ToString();
                        inputNum.Text = rdr["RefClient"].ToString();
                        inputNom.Text = rdr["Nom"].ToString();
                        inputPrenom.Text = rdr["Prenom"].ToString();
                        inputDateNaissance.SelectedDate= DateTime.ParseExact(rdr["DateNaissance"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        inputLieuNaissance.Text = rdr["LieuNaissance"].ToString();
                        inputNumcni.Text = rdr["Cni"].ToString();
                        inputDateCni.SelectedDate = DateTime.ParseExact(rdr["DateCni"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        inputLieuCni.Text = rdr["LieuCni"].ToString();
                        inputStatutDemande.Text = rdr["StatutDemande"].ToString();

                        oneTime = false;
                    }
                }


                con.Close();
            }
        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Demande d = new Demande("");
            this.NavigationService.Navigate(d);
        }
    }
    }

