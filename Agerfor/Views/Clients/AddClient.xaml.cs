﻿using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Globalization;
using Agerfor.Views.Demande;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Timers;
using MaterialDesignThemes.Wpf;

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
        MainWindow mw = new MainWindow("","","","","","","","","","");
        
        


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
            msh.FillDropDownList("select Nature from naturedemande", inputNatureDemande, "Nature");
            msh.FillDropDownList("select Type from typedemande", inputDemande, "Type");
            msh.FillDropDownList("select Statut from demandestatut", inputStatutDemande, "Statut");

            string query2 = "select MAX(Numclient)+1 AS Num from client  ;";
            MySqlDataReader rdr2 = null;
            MySqlConnection con2 = null;
            MySqlCommand cmd2 = null;
            con2 = new MySqlConnection(Database.ConnectionString());
            con2.Open();
            cmd2 = new MySqlCommand(query2);
            cmd2.Connection = con2;
            rdr2 = cmd2.ExecuteReader();
            bool oneTime2 = true;
            while (rdr2.Read())
            {
                if (rdr2["Num"].ToString() == "")
                {
                    inputNumClient.Text="1";
                }
                else
                {
                    inputNumClient.Text = rdr2["Num"].ToString();
                }
            }
            inputNumClient.IsEnabled = false;

                if (NumClient != "" && Situation == "Marié(e)")
            {
                string query = "select * from client where NumClient =" + NumClient;
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
                        inputNumClient.Text = rdr["NumClient"].ToString();
                        Statutclient.Text = rdr["StatutClient"].ToString();
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
                        inputDateNaissanceConj.Text = rdr["DateNaissanceConj"].ToString();
                        inputDateCration.Text = rdr["DateCreation"].ToString();
                        inputDateNaissance.Text = rdr["DateNaissance"].ToString();
                        inputDateCni.Text = rdr["DateCni"].ToString();

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
                            inputDateCration.Text = rdr["DateCreation"].ToString();
                            inputDateNaissance.Text = rdr["DateNaissance"].ToString();
                            inputDateCni.Text = rdr["DateCni"].ToString();

                            oneTime = false;
                        }
                    }


                    con.Close();
                }
            }
        
            if (Statutclient.Text != "Contentieux")
            {
                alerte.Visibility = Visibility.Collapsed;
            }
            else
            {
                alerte.Visibility = Visibility.Visible;
            }

        }


        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            
            if (inputSituationFamiliale.SelectedIndex == 1)
            {
                if (Clientissecure1() == true)
                {
                    DirectoryCreator dcr = new DirectoryCreator();
                    dcr.CreateDirectory2(inputNumClient.Text);
                    cc.ajouterclient(inputNumClient.Text, inputDateCration.Text, inputName.Text, inputPrenom.Text, inputNomAR.Text, inputPrenomAR.Text, inputSexe.Text, inputDateNaissance.Text, inputLieuNaissance.Text, inputPrenomPere.Text, inputPrenomPereAR.Text, inputNomMere.Text, inputPrenomMere.Text, inputnomMereAR.Text, inputPrenomMereAr.Text, inputNumcni.Text, inputDateCni.Text, inputLieucni.Text, inputVille.Text, inputAdress.Text, inputProffession.Text, inputTelphone.Text, inputNomAutreCntacte.Text, inputTelphoneContact.Text, inputSituationFamiliale.Text, inputNomconjoint.Text, inputPrenomConjoint.Text, inputNomConjArab.Text, inputPrenomConjoint.Text, inputDateNaissanceConj.Text, inputLieuNaissanceConj.Text, inputProffessionConj.Text,inputNumDeliberation.Text,inputDateDeliberation.Text);
                    AddClient AddClient2 = new AddClient("","");
                    this.NavigationService.Navigate(AddClient2);
                }
                else
                {
                    System.Windows.MessageBox.Show("Veuillez entrer les informations nécessaire");
                }
            }
            else
            {
                if (Clientissecure2() == true)
                {
                    DirectoryCreator dcr = new DirectoryCreator();
                    dcr.CreateDirectory2(inputNumClient.Text);
                    cc.ajouterclient(inputNumClient.Text, inputDateCration.Text, inputName.Text, inputPrenom.Text, inputNomAR.Text, inputPrenomAR.Text, inputSexe.Text, inputDateNaissance.Text, inputLieuNaissance.Text, inputPrenomPere.Text, inputPrenomPereAR.Text, inputNomMere.Text, inputPrenomMere.Text, inputnomMereAR.Text, inputPrenomMereAr.Text, inputNumcni.Text, inputDateCni.Text, inputLieucni.Text, inputVille.Text, inputAdress.Text, inputProffession.Text, inputTelphone.Text, inputNomAutreCntacte.Text, inputTelphoneContact.Text, inputSituationFamiliale.Text, inputNomconjoint.Text, inputPrenomConjoint.Text, inputNomConjArab.Text, inputPrenomConjoint.Text, inputDateNaissanceConj.Text, inputLieuNaissanceConj.Text, inputProffessionConj.Text,inputNumDeliberation.Text, inputDateDeliberation.Text);
                    AddClient AddClient2 = new AddClient("","");
                    this.NavigationService.Navigate(AddClient2);
                }
                else
                {
                    System.Windows.MessageBox.Show("Veuillez entrer les informations nécessaire");
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
                    cc.Editclient(inputDateCration.Text, inputName.Text, inputPrenom.Text, inputNomAR.Text, inputPrenomAR.Text, inputSexe.Text, inputDateNaissance.Text, inputLieuNaissance.Text, inputPrenomPere.Text, inputPrenomPereAR.Text, inputNomMere.Text, inputPrenomMere.Text, inputnomMereAR.Text, inputPrenomMereAr.Text, inputNumcni.Text, inputDateCni.Text, inputLieucni.Text, inputVille.Text, inputAdress.Text, inputProffession.Text, inputTelphone.Text, inputNomAutreCntacte.Text, inputTelphoneContact.Text, inputSituationFamiliale.Text, inputNomconjoint.Text, inputPrenomConjoint.Text, inputNomConjArab.Text, inputPrenomConjoint.Text, inputDateNaissanceConj.Text, inputLieuNaissanceConj.Text, inputProffessionConj.Text,int.Parse(inputNumClient.Text), inputNumDeliberation.Text, inputDateDeliberation.Text);
                    Client c = new Client("");
                    this.NavigationService.Navigate(c);
                }
                else
                {
                    System.Windows.MessageBox.Show("Veuillez entrer les informations nécessaire ");
                }
            }
            else
            {
                if (Clientissecure2() == true)
                {
                    
                    cc.Editclient(inputDateCration.Text, inputName.Text, inputPrenom.Text, inputNomAR.Text, inputPrenomAR.Text, inputSexe.Text, inputDateNaissance.Text, inputLieuNaissance.Text, inputPrenomPere.Text, inputPrenomPereAR.Text, inputNomMere.Text, inputPrenomMere.Text, inputnomMereAR.Text, inputPrenomMereAr.Text, inputNumcni.Text, inputDateCni.Text, inputLieucni.Text, inputVille.Text, inputAdress.Text, inputProffession.Text, inputTelphone.Text, inputNomAutreCntacte.Text, inputTelphoneContact.Text, inputSituationFamiliale.Text, inputNomconjoint.Text, inputPrenomConjoint.Text, inputNomConjArab.Text, inputPrenomConjoint.Text, inputDateNaissanceConj.Text, inputLieuNaissanceConj.Text, inputProffessionConj.Text,int.Parse(inputNumClient.Text), inputNumDeliberation.Text, inputDateDeliberation.Text);
                    Client c = new Client("");
                    this.NavigationService.Navigate(c);
                }
                else
                {
                    System.Windows.MessageBox.Show("Veuillez entrer les informations nécessaire");
                }
            }
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            msh.LoadData("select *,DATE_FORMAT(DateDemande,'%d/%m/%Y') AS DATE,DATE_FORMAT(DateReponse,'%d/%m/%Y') AS DATER from demande where RefClient='" + inputNumClient.Text + "'", dataViewDemande);

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
                this.NavigationService.Navigate(AD);


            }
            catch (Exception)
            {
                System.Windows.MessageBox.Show("Veuillez sélectioner une demande");
            }

        }

        private void BtnAjouterDemande_Click(object sender, RoutedEventArgs e)
        {
            try
            {
            string Demandes = "Demandes";
            DirectoryCreator DCR = new DirectoryCreator();
            DCR.CreateDirectory2(inputNumClient.Text + "/"+Demandes+"/");
            DemandeController DC = new DemandeController();
            DC.ajouterDemande(inputDateDemande.Text,inputNumClient.Text,inputMotifDemande.Text,inputStatutDemande.Text,inputDemande.Text,inputNatureDemande.Text);
            msh.LoadData("select *,DATE_FORMAT(DateDemande,'%d/%m/%Y') AS DATE,DATE_FORMAT(DateReponse,'%d/%m/%Y') AS DATER from demande where RefClient='" + inputNumClient.Text + "'", dataViewDemande);
                inputStatutDemande.Text = inputNatureDemande.Text = inputDemande.Text = inputMotifDemande.Text = string.Empty;
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
                msh.LoadData("select *,DATE_FORMAT(DateDemande,'%d/%m/%Y') AS DATE,DATE_FORMAT(DateReponse,'%d/%m/%Y') AS DATER from demande where RefClient='" + inputNumClient.Text + "'", dataViewDemande);
            }
            catch (Exception)
            {

            }
        }

        private void BtnOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            {
                string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Client\" + inputNumClient.Text;
                OpenFolder(folderPath);
            }
        }
        private void OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
            else
            {
                DirectoryCreator dcr = new DirectoryCreator();
                dcr.CreateDirectory(inputNumClient.Text + "/");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        }

        private void BtnUploadFiles_Click(object sender, RoutedEventArgs e)
        {
            SelectFile("Document");
        }
        public void SelectFile(string theDirectory)
        {
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Client\" + inputNumClient.Text + @"\" + theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectory2(inputNumClient.Text + "/" + theDirectory + "/");
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolder))
                {
                    File.Delete(destinationFolder);
                }

                File.Copy(fileName, Path.Combine(Path.GetDirectoryName(fileName), destinationFolder));
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionner");
            }
        }

        private void BtnJoindreD_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumDemande != "")
            {
                SelectFile2(tempNumDemande);
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez sélectionner une demande");
            }
        }

        public void SelectFile2(string theDirectory)
        {
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Client\" + inputNumClient.Text + @"\Demandes\"+ @"\" + theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectory2(inputNumClient.Text + "/"+"Demandes"+"/"+ theDirectory +"/");
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolder))
                {
                    File.Delete(destinationFolder);
                }

                File.Copy(fileName, Path.Combine(Path.GetDirectoryName(fileName), destinationFolder));
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionner");
            }
        }

        private void BtnSupprimerD_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumDemande != "")
            {
                string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Client\" + inputNumClient.Text + @"\Demandes\" + tempNumDemande;
                OpenFolder(folderPath);
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez sélectionner une demande");
            }
        }

        private void BtnOVSolde_Click(object sender, RoutedEventArgs e)
        {
            SoldeOV SOV = new SoldeOV(int.Parse(inputNumClient.Text));
            DialogHost.Show(SOV);
        }
    }

}
    

