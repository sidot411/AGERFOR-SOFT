using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Globalization;
using Agerfor.Views.Demande;


namespace Agerfor.Views.Clients
{
    /// <summary>
    /// Interaction logic for AddClient.xaml
    /// </summary>
    public partial class AddClient : Page
    {
        string NumClient = "";
        string Situation = "";
        string tempNumDemande = "";
        Agerfor.Controlers.MySqlHelper msh = new Agerfor.Controlers.MySqlHelper();
        ClientController cc = new ClientController();


        public AddClient(string NumClient, string Situation)
        {

            InitializeComponent();
            this.NumClient = NumClient;
            this.Situation = Situation;
            inputNomconjoint.IsEnabled = inputPrenomConjoint.IsEnabled = inputNomConjArab.IsEnabled = inputPrenomCongAr.IsEnabled = inputDateNaissanceConj.IsEnabled = inputLieuNaissanceConj.IsEnabled = inputProffessionConj.IsEnabled = false;

            msh.FillDropDownList("select NomWilaya from wilaya", inputLieucni, "NomWilaya");
            msh.FillDropDownList("select NomWilaya from wilaya", inputLieuNaissance, "NomWilaya");
            msh.FillDropDownList("select NomWilaya from wilaya", inputLieuNaissanceConj, "NomWilaya");
            msh.FillDropDownList("select NomWilaya from wilaya", inputVille, "NomWilaya");

            if (NumClient != "" && Situation == "Marié(e)")
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
                        inputLieuNaissance.Text = rdr["LieuNaissance"].ToString();
                        inputPrenomPere.Text = rdr["PrenomPere"].ToString();
                        inputNomMere.Text = rdr["NomMere"].ToString();
                        inputPrenomMere.Text = rdr["PrenomMere"].ToString();
                        inputnomMereAR.Text = rdr["NomMereAr"].ToString();
                        inputPrenomMereAr.Text = rdr["PrenomMereAr"].ToString();
                        inputNumcni.Text = rdr["Cni"].ToString();
                        inputLieucni.Text = rdr["LieuCni"].ToString();
                        inputTelphone.Text = rdr["Tel"].ToString();
                        inputSituationFamiliale.Text = rdr["Situation"].ToString();
                        inputNomconjoint.Text = rdr["Nomconj"].ToString();
                        inputPrenomConjoint.Text = rdr["PrénomConj"].ToString();
                        inputProffessionConj.Text = rdr["ProfessionConj"].ToString();
                        inputPrenomPereAR.Text = rdr["PrenomPereAR"].ToString();
                        inputVille.Text = rdr["Ville"].ToString();
                        inputAdress.Text = rdr["Adress"].ToString();
                        inputProffession.Text = rdr["Proffession"].ToString();
                        inputNomAutreCntacte.Text = rdr["NomContact"].ToString();
                        inputTelphoneContact.Text = rdr["TelContact"].ToString();
                        inputNomConjArab.Text = rdr["NomConjAR"].ToString();
                        inputPrenomCongAr.Text = rdr["PrenomConjAR"].ToString();
                        inputLieuNaissanceConj.Text = rdr["LieuNaissanceConj"].ToString();
                        inputProffessionConj.Text = rdr["ProfessionConj"].ToString();
                        inputDateNaissanceConj.SelectedDate = DateTime.ParseExact(rdr["DateNaissanceConj"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        inputDateCration.SelectedDate = DateTime.ParseExact(rdr["DateCreation"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        inputDateNaissance.SelectedDate = DateTime.ParseExact(rdr["DateNaissance"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                        inputDateCni.SelectedDate = DateTime.ParseExact(rdr["DateCni"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

                        oneTime = false;
                    }
                }


                con.Close();
            }
            else
            {
                if (NumClient != "")
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
                            inputLieuNaissance.Text = rdr["LieuNaissance"].ToString();
                            inputPrenomPere.Text = rdr["PrenomPere"].ToString();
                            inputNomMere.Text = rdr["NomMere"].ToString();
                            inputPrenomMere.Text = rdr["PrenomMere"].ToString();
                            inputnomMereAR.Text = rdr["NomMereAr"].ToString();
                            inputPrenomMereAr.Text = rdr["PrenomMereAr"].ToString();
                            inputNumcni.Text = rdr["Cni"].ToString();
                            inputLieucni.Text = rdr["LieuCni"].ToString();
                            inputTelphone.Text = rdr["Tel"].ToString();
                            inputSituationFamiliale.Text = rdr["Situation"].ToString();
                            inputPrenomPereAR.Text = rdr["PrenomPereAR"].ToString();
                            inputVille.Text = rdr["Ville"].ToString();
                            inputAdress.Text = rdr["Adress"].ToString();
                            inputProffession.Text = rdr["Proffession"].ToString();
                            inputNomAutreCntacte.Text = rdr["NomContact"].ToString();
                            inputTelphoneContact.Text = rdr["TelContact"].ToString();
                            inputDateCration.SelectedDate = DateTime.ParseExact(rdr["DateCreation"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            inputDateNaissance.SelectedDate = DateTime.ParseExact(rdr["DateNaissance"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);
                            inputDateCni.SelectedDate = DateTime.ParseExact(rdr["DateCni"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);

                            oneTime = false;
                        }
                    }


                    con.Close();
                }
            }
        }


        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            
            if (inputSituationFamiliale.SelectedIndex == 1)
            {
                if (Clientissecure1() == true)
                { 
                    cc.ajouterclient(inputNumClient.Text, inputDateCration.Text, inputName.Text, inputPrenom.Text, inputNomAR.Text, inputPrenomAR.Text, inputSexe.Text, inputDateNaissance.Text, inputLieuNaissance.Text, inputPrenomPere.Text, inputPrenomPereAR.Text, inputNomMere.Text, inputPrenomMere.Text, inputnomMereAR.Text, inputPrenomMereAr.Text, inputNumcni.Text, inputDateCni.Text, inputLieucni.Text, inputVille.Text, inputAdress.Text, inputProffession.Text, inputTelphone.Text, inputNomAutreCntacte.Text, inputTelphoneContact.Text, inputSituationFamiliale.Text, inputNomconjoint.Text, inputPrenomConjoint.Text, inputNomConjArab.Text, inputPrenomConjoint.Text, inputDateNaissanceConj.Text, inputLieuNaissanceConj.Text, inputProffessionConj.Text);
                    AddClient AddClient2 = new AddClient("","");
                    this.NavigationService.Navigate(AddClient2);
                }
                else
                {
                    MessageBox.Show("Veuillez entrer les informations nécessaire");
                }
            }
            else
            {
                if (Clientissecure2() == true)
                {
                    cc.ajouterclient(inputNumClient.Text, inputDateCration.Text, inputName.Text, inputPrenom.Text, inputNomAR.Text, inputPrenomAR.Text, inputSexe.Text, inputDateNaissance.Text, inputLieuNaissance.Text, inputPrenomPere.Text, inputPrenomPereAR.Text, inputNomMere.Text, inputPrenomMere.Text, inputnomMereAR.Text, inputPrenomMereAr.Text, inputNumcni.Text, inputDateCni.Text, inputLieucni.Text, inputVille.Text, inputAdress.Text, inputProffession.Text, inputTelphone.Text, inputNomAutreCntacte.Text, inputTelphoneContact.Text, inputSituationFamiliale.Text, inputNomconjoint.Text, inputPrenomConjoint.Text, inputNomConjArab.Text, inputPrenomConjoint.Text, inputDateNaissanceConj.Text, inputLieuNaissanceConj.Text, inputProffessionConj.Text);
                    AddClient AddClient2 = new AddClient("","");
                    this.NavigationService.Navigate(AddClient2);
                }
                else
                {
                    MessageBox.Show("Veuillez entrer les informations nécessaire");
                }
            }
        }


        private Boolean Clientissecure1()
        {
            if (inputNumClient.Text != "" && inputName.Text != "" && inputPrenom.Text != "" && inputNomAR.Text != "" && inputPrenomAR.Text != "" && inputDateNaissance.Text !="" && inputLieuNaissance.Text !="" && inputPrenomPere.Text !="" && inputPrenomPereAR.Text !="" && inputNomMere.Text !="" && inputPrenomMere.Text !="" && inputnomMereAR.Text !="" && inputPrenomMereAr.Text !="" && inputNumcni.Text !="" && inputDateCni.Text !="" && inputLieucni.Text !="" && inputVille.Text !="" && inputAdress.Text !="" && inputProffession.Text !="" && inputTelphone.Text !="" && inputNomAutreCntacte.Text !="" && inputTelphoneContact.Text !="" && inputNomconjoint.Text !="" && inputPrenomConjoint.Text !="" && inputNomConjArab.Text !="" && inputPrenomCongAr.Text !="" && inputDateNaissanceConj.Text !="" && inputLieuNaissanceConj.Text !="" && inputProffessionConj.Text !="" )

            {
                return true;
            }
            else
            {
                return false;
            }

        }

        
        private Boolean Clientissecure2()
        {
            if (inputNumClient.Text != "" && inputName.Text != "" && inputPrenom.Text != "" && inputNomAR.Text != "" && inputPrenomAR.Text != "" && inputDateNaissance.Text != "" && inputLieuNaissance.Text != "" && inputPrenomPere.Text != "" && inputPrenomPereAR.Text != "" && inputNomMere.Text != "" && inputPrenomMere.Text != "" && inputnomMereAR.Text != "" && inputPrenomMereAr.Text != "" && inputNumcni.Text != "" && inputDateCni.Text != "" && inputLieucni.Text != "" && inputVille.Text != "" && inputAdress.Text != "" && inputProffession.Text != "" && inputTelphone.Text != "" && inputNomAutreCntacte.Text != "" && inputTelphoneContact.Text != "")

            {
                return true;
            }
            else
            {
                return false;
            }

        }

        private void inputSituationFamiliale_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (inputSituationFamiliale.SelectedIndex == 1)
            {

                inputNomconjoint.IsEnabled = inputPrenomConjoint.IsEnabled = inputNomConjArab.IsEnabled = inputPrenomCongAr.IsEnabled = inputDateNaissanceConj.IsEnabled = inputLieuNaissanceConj.IsEnabled = inputProffessionConj.IsEnabled = true;

            }


            else
            {
                inputNomconjoint.IsEnabled = inputPrenomConjoint.IsEnabled = inputNomConjArab.IsEnabled = inputPrenomCongAr.IsEnabled = inputDateNaissanceConj.IsEnabled = inputLieuNaissanceConj.IsEnabled = inputProffessionConj.IsEnabled = false;
                inputNomconjoint.Text = inputPrenomConjoint.Text = inputNomConjArab.Text = inputPrenomCongAr.Text = inputDateNaissanceConj.Text = inputLieuNaissanceConj.Text = inputProffessionConj.Text = "";

            }

        }

        private void BtnAnnuler_Click(object sender, RoutedEventArgs e)
        {
            Client c = new Client("");
            this.NavigationService.Navigate(c);
        }

        private void BtnModifier_Click(object sender, RoutedEventArgs e)
        {

            if (inputSituationFamiliale.SelectedIndex == 1)
            {
                if (Clientissecure1() == true)
                {
                    cc.Editclient(inputNumClient.Text, inputDateCration.Text, inputName.Text, inputPrenom.Text, inputNomAR.Text, inputPrenomAR.Text, inputSexe.Text, inputDateNaissance.Text, inputLieuNaissance.Text, inputPrenomPere.Text, inputPrenomPereAR.Text, inputNomMere.Text, inputPrenomMere.Text, inputnomMereAR.Text, inputPrenomMereAr.Text, inputNumcni.Text, inputDateCni.Text, inputLieucni.Text, inputVille.Text, inputAdress.Text, inputProffession.Text, inputTelphone.Text, inputNomAutreCntacte.Text, inputTelphoneContact.Text, inputSituationFamiliale.Text, inputNomconjoint.Text, inputPrenomConjoint.Text, inputNomConjArab.Text, inputPrenomConjoint.Text, inputDateNaissanceConj.Text, inputLieuNaissanceConj.Text, inputProffessionConj.Text);
                    Client c = new Client("");
                    this.NavigationService.Navigate(c);
                }
                else
                {
                    MessageBox.Show("Veuillez entrer les informations nécessaire");
                }
            }
            else
            {
                if (Clientissecure2() == true)
                {
                    
                    cc.Editclient(inputNumClient.Text, inputDateCration.Text, inputName.Text, inputPrenom.Text, inputNomAR.Text, inputPrenomAR.Text, inputSexe.Text, inputDateNaissance.Text, inputLieuNaissance.Text, inputPrenomPere.Text, inputPrenomPereAR.Text, inputNomMere.Text, inputPrenomMere.Text, inputnomMereAR.Text, inputPrenomMereAr.Text, inputNumcni.Text, inputDateCni.Text, inputLieucni.Text, inputVille.Text, inputAdress.Text, inputProffession.Text, inputTelphone.Text, inputNomAutreCntacte.Text, inputTelphoneContact.Text, inputSituationFamiliale.Text, inputNomconjoint.Text, inputPrenomConjoint.Text, inputNomConjArab.Text, inputPrenomConjoint.Text, inputDateNaissanceConj.Text, inputLieuNaissanceConj.Text, inputProffessionConj.Text);
                    Client c = new Client("");
                    this.NavigationService.Navigate(c);
                }
                else
                {
                    MessageBox.Show("Veuillez entrer les informations nécessaire");
                }
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            msh.LoadData("select NumDemande,DateDemande,RefClient,Motif,TypeDemande,StatutDemande,Nom,Prenom,DateNaissance,LieuNaissance,Cni,DateCni,LieuCni from demande,client where demande.RefClient=client.NumClient and NumClient='"+inputNumClient.Text+"'",dataViewDemande);

        }
        private void dataViewDemande_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridCellInfo cell0 = dataViewDemande.SelectedCells[0];
                tempNumDemande = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
            }
            catch (Exception)
            {
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddDemande AD = new AddDemande(tempNumDemande);
                AD.BtnModifier.Visibility = Visibility.Collapsed;
                this.NavigationService.Navigate(AD);


            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez sélectioner une demande");
            }

        }

        private void BtnAjouterDemande_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
            DemandeController DC = new DemandeController();
            DC.ajouterDemande(inputDateDemande.Text,inputNumClient.Text,inputMotifDemande.Text,inputStatutDemande.Text,inputTypeDemande.Text); msh.LoadData("select NumDemande,DateDemande,RefClient,Motif,TypeDemande,StatutDemande,Nom,Prenom,DateNaissance,LieuNaissance,Cni,DateCni,LieuCni from demande,client where demande.RefClient=client.NumClient and NumClient='" + inputNumClient.Text + "'", dataViewDemande);
            }
            catch (Exception)
            {

            }
        }

        private void BtnSupprimerDemande_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                DemandeController DC = new DemandeController();
                DC.supprimerDemande(tempNumDemande);
                msh.LoadData("select NumDemande,DateDemande,RefClient,Motif,TypeDemande,StatutDemande,Nom,Prenom,DateNaissance,LieuNaissance,Cni,DateCni,LieuCni from demande,client where demande.RefClient=client.NumClient and NumClient='" + inputNumClient.Text + "'", dataViewDemande);
            }
            catch (Exception)
            {

            }
        }

      
    }
}
    

