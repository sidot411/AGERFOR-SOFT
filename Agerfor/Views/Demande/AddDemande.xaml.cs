using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using Agerfor.Views.Clients;
using System.Globalization;
using System.Windows.Navigation;
using Agerfor.DemandeReporting;
using Agerfor.Views.Demande;

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
            msh.FillDropDownList("select Nature from naturedemande", inputNatureDemande, "Nature");
            this.NumDemande2 = NumDemande;
            inputNumDemande.IsEnabled = inputNum.IsEnabled = inputNom.IsEnabled = inputPrenom.IsEnabled = inputDateReponse.IsEnabled = inputDemande.IsEnabled = inputDateNaissance.IsEnabled = inputNumcni.IsEnabled = inputDateCni.IsEnabled = inputLieuCni.IsEnabled = inputLieuNaissance.IsEnabled = inputDateDemande.IsEnabled= inputNatureDemande.IsEnabled=inputMotifDemande.IsEnabled=inputStatutDemande.IsEnabled= false;

            if (NumDemande !="")

            {
                
                string query = "select NumDemande,DATE_FORMAT(DateDemande,'%d/%m/%Y') AS DateD,RefClient,Motif,NatureDemande,TypeDemande,StatutDemande,DateReponse,Nom,Prenom,DateNaissance,LieuNaissance,Cni,DateCni,LieuCni from demande,client where demande.RefClient=client.NumClient and demande.NumDemande =" + NumDemande;
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
                        inputDateDemande.Text = rdr["DateD"].ToString();
                        inputDateReponse.Text = rdr["DateReponse"].ToString();
                        inputNatureDemande.Text = rdr["NatureDemande"].ToString();
                        inputDemande.Text = rdr["TypeDemande"].ToString();
                        inputMotifDemande.Text = rdr["Motif"].ToString();
                        inputNum.Text = rdr["RefClient"].ToString();
                        inputNom.Text = rdr["Nom"].ToString();
                        inputPrenom.Text = rdr["Prenom"].ToString();
                        inputDateNaissance.Text= rdr["DateNaissance"].ToString();
                        inputLieuNaissance.Text = rdr["LieuNaissance"].ToString();
                        inputNumcni.Text = rdr["Cni"].ToString();
                        inputDateCni.Text = rdr["DateCni"].ToString();
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

        private void BtnAfficherClient_Click(object sender, RoutedEventArgs e)
        {
            AddClient AC = new AddClient(inputNum.Text, "");
            this.NavigationService.Navigate(AC);
        }

        private void Btnimprimer_Click(object sender, RoutedEventArgs e)
        {
            DemandeR DR = new DemandeR(int.Parse(inputNum.Text), int.Parse(inputNumDemande.Text));
            DR.Show();
        }
    }
    }

