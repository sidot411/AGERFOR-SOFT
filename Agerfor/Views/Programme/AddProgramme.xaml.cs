﻿using System;
using System.Windows.Controls;
using Agerfor.Controlers;
using System.Windows;
using Notifications.Wpf;
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Agerfor.Views.Programme
{
    /// <summary>
    /// Interaction logic for AddProgramme.xaml
    /// </summary>
    public partial class AddProgramme : Page
    {
        ProgrammeController PC = new ProgrammeController();
        ActeProgrammeController APC = new ActeProgrammeController();
        string RefProgramme = "";
        string Query = "";
        string tempNumActeProgramme = "";
        string tempnumprojet = "";
        /*string tempDateActeProgramme = "";
        string tempDateEnregActe = "";
        string tempDatePubliActe = "";
        string tempConservation = "";
        decimal tempFraisEnregi = 0;*/

        private readonly NotificationManager _notificationManager = new NotificationManager();
        private readonly Random _random = new Random();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public AddProgramme(string refprogramme)
        {
            this.RefProgramme = refprogramme;
            InitializeComponent();
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            msh.FillDropDownList("select NatureProgramme from natureprogramme", inputNatureProgramme, "NatureProgramme");
            msh.FillDropDownList("select NomDaira from daira", inputDairaProgramme, "NomDaira");
            msh.FillDropDownList("select NomProjet from projet", inputNomProjet, "NomProjet");



            var timer = new System.Timers.Timer { Interval = 3000 };
            timer.Start();
            if (refprogramme != "")
            {
                string query = "select * from programme where RefProgramme =" + refprogramme;

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
                        inputNomProjet.Text = rdr["NomProjet"].ToString();
                        inputRefProgramme.Text = rdr["RefProgramme"].ToString();
                        inputNomProgramme.Text = rdr["NomProgramme"].ToString();
                        inputSiteProgramme.Text = rdr["Site"].ToString();
                        inputDairaProgramme.Text = rdr["Daira"].ToString();
                        inputCommuneProgramme.Text = rdr["Commune"].ToString();
                        inputNatureProgramme.Text = rdr["NatureProgramme"].ToString();
                        inputTypeProgramme.Text = rdr["TypeProgramme"].ToString();
                        inputNombredebien.Text = rdr["NombreBiens"].ToString();
                        inputSuperficie.Text = rdr["Superficie"].ToString();




                        oneTime = false;
                    }
                }
            }
        }


        private void inputNatureProgramme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            try
            {
                inputTypeProgramme.Items.Clear();
                msh.FillDropDownList("select TypeProgramme from typeprogramme where typeprogramme.NatureProgramme='" + inputNatureProgramme.SelectedValue.ToString() + "'", inputTypeProgramme, "TypeProgramme");
                if (inputNatureProgramme.SelectedValue.ToString() == "Lotissement" || inputNatureProgramme.SelectedValue.ToString() == "Terrain Industriel" || inputNatureProgramme.SelectedValue.ToString() == "RHP")
                {
                    PermiLotir.IsEnabled = true;
                    Permisconstruire.IsEnabled = false;

                }
                else
                {
                    PermiLotir.IsEnabled = true;
                    Permisconstruire.IsEnabled = true;
                }
                if (inputNatureProgramme.SelectedValue.ToString() == "Lotissement" || inputNatureProgramme.SelectedValue.ToString() == "RHP")
                {
                    BtnCahiercharge.IsEnabled = true;
                    BtnEDD.IsEnabled = BtnConvention.IsEnabled = false;
                }
                if (inputNatureProgramme.SelectedValue.ToString() == "Terrain Industriel")
                {
                    BtnCahiercharge.IsEnabled = BtnConvention.IsEnabled = true;
                    BtnEDD.IsEnabled = false;
                }

                if (inputNatureProgramme.SelectedValue.ToString() == "Local" || inputNatureProgramme.SelectedValue.ToString() == "Logement")
                {
                    BtnCahiercharge.IsEnabled = BtnConvention.IsEnabled = false;
                    BtnEDD.IsEnabled = true;
                }



            }
            catch (Exception)
            { }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {/*
            string tempnumlotir = inputNumLotir.Text;
            if (tempnumlotir == "")
            {
                var content = new NotificationContent { Title = "Permis de lotir n'existe pas", Message = "veuillez ajouter un permis de lotir!", Type=NotificationType.Warning };
                var clickContent = new NotificationContent
                {
                    Title = "",
                    Message = "",
                    Type = NotificationType.Warning
                };
                _notificationManager.Show(content, "WindowArea", onClick: () => _notificationManager.Show(clickContent));

                var content2 = new NotificationContent { Title = "Permis de lotir existe", Message = "veuillez ajouter un permis de lotir!", Type = NotificationType.Error };
                var clickContent2 = new NotificationContent
                {
                    Title = "",
                    Message = "",
                    Type = NotificationType.Warning
                };
                _notificationManager.Show(content2, "WindowArea2", onClick: () => _notificationManager.Show(clickContent2));
            }
            */
            if (Query == "")
            {
                msh.LoadData("select * from acteprogramme where RefProgramme='" + RefProgramme + "'", datagridActeProgramme);
            }
            else
            {
                msh.LoadData(Query, datagridActeProgramme);
            }

            if (RefProgramme != "" && inputNatureProgramme.Text != "" && inputTypeProgramme.Text != "")
            {
                if (inputNatureProgramme.SelectedValue.ToString() == "Lotissement" || inputNatureProgramme.SelectedValue.ToString() == "Terrain Industriel" || inputNatureProgramme.SelectedValue.ToString() == "RHP")
                {
                    PermiLotir.IsEnabled = true;
                    Permisconstruire.IsEnabled = false;

                }
                else
                {
                    PermiLotir.IsEnabled = true;
                    Permisconstruire.IsEnabled = true;
                }
                if (inputNatureProgramme.SelectedValue.ToString() == "Lotissement" || inputNatureProgramme.SelectedValue.ToString() == "RHP")
                {
                    BtnCahiercharge.IsEnabled = true;
                    BtnEDD.IsEnabled = BtnConvention.IsEnabled = false;
                }
                if (inputNatureProgramme.SelectedValue.ToString() == "Terrain Industriel")
                {
                    BtnCahiercharge.IsEnabled = BtnConvention.IsEnabled = true;
                    BtnEDD.IsEnabled = false;
                }

                if (inputNatureProgramme.SelectedValue.ToString() == "Local" || inputNatureProgramme.SelectedValue.ToString() == "Logement")
                {
                    BtnCahiercharge.IsEnabled = BtnConvention.IsEnabled = false;
                    BtnEDD.IsEnabled = true;
                }
            }
            else
            {
                PermiLotir.IsEnabled = Permisconstruire.IsEnabled = false;
                BtnCahiercharge.IsEnabled = BtnEDD.IsEnabled = BtnConvention.IsEnabled = false;

            }
        }



        private void BtnCahiercharge_Click(object sender, RoutedEventArgs e)
        {
            CahierCharge cahiercharge = new CahierCharge();
            DialogHost.Show(cahiercharge);
        }

        private void BtnEDD_Click(object sender, RoutedEventArgs e)
        {
            EDD EDD = new EDD();
            DialogHost.Show(EDD);
        }

        private void BtnConvention_Click(object sender, RoutedEventArgs e)
        {
            Convention convention = new Convention();
            DialogHost.Show(convention);
        }

        private void inputDairaProgramme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            inputCommuneProgramme.Items.Clear();
            msh.FillDropDownList("select NomCommune from commune,daira where NomDaira='" + inputDairaProgramme.SelectedItem.ToString() + "'and daira.IdDaira=commune.IdDaira", inputCommuneProgramme, "NomCommune");
        }
        //Ajouter Programme//
        private void BtnAjouterProgramme_Click(object sender, RoutedEventArgs e)
        {
            getrefprojet();
            DirectoryCreator DC = new DirectoryCreator();
            DC.CreateDirectoryProgramme(tempnumprojet, inputRefProgramme.Text);
            PC.AjouterProgramme(inputNomProjet.Text, inputRefProgramme.Text, inputNomProgramme.Text, inputSiteProgramme.Text, inputDairaProgramme.Text, inputCommuneProgramme.Text, inputNatureProgramme.Text, inputTypeProgramme.Text, inputNombredebien.Text, decimal.Parse(inputSuperficie.Text));
            AddProgramme AP = new AddProgramme("");
            NavigationService.Navigate(AP);
            System.Windows.MessageBox.Show(tempnumprojet);
        }
        //Modifier Programme//
        private void BtnModifierProgramme_Click(object sender, RoutedEventArgs e)
        {
            PC.Editprogramme(inputNomProjet.Text, inputRefProgramme.Text, inputNomProgramme.Text, inputSiteProgramme.Text, inputDairaProgramme.Text, inputCommuneProgramme.Text, inputNatureProgramme.Text, inputTypeProgramme.Text, inputNombredebien.Text, decimal.Parse(inputSuperficie.Text));
            AddProgramme AP = new AddProgramme("");
            NavigationService.Navigate(AP);
        }
        //Annuler Programme//
        private void BtnAnnulerProgramme_Click(object sender, RoutedEventArgs e)
        {
            Programme P = new Programme("");
            NavigationService.Navigate(P);
        }
        //Ouvrir Programme//
        private void BtnOuvrirprogramme_Click(object sender, RoutedEventArgs e)
        {
            getrefprojet();
            string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text;

            OpenFolder(folderPath);
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
                dcr.CreateDirectoryProgramme(tempnumprojet, inputRefProgramme.Text + "/");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        }

        //Joindre Programme//
        private void BtnJoindreprogramme_Click(object sender, RoutedEventArgs e)
        {

            SelectFile("Document-Programme");
        }
        public void SelectFile(string theDirectory)
        {
            getrefprojet();
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\" + theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectoryProgramme(tempnumprojet, inputRefProgramme.Text + "/" + theDirectory + "/");
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

        private void BtnAjouterActeProgramme_Click(object sender, RoutedEventArgs e)

        {
            string Acte = "Acte";
            getrefprojet();
            DirectoryCreator DC = new DirectoryCreator();
            DC.CreateDirectoryProgramme(tempnumprojet, inputRefProgramme.Text + "/" + Acte + "/" + NumActeProgramme.Text);
            APC.AjouterActeProgramme(NumActeProgramme.Text, inputDateActeProgramme.Text, DateEnrgActeP.Text, DatePubliActeP.Text, inputConservation.Text, decimal.Parse(inputFrais.Text), inputRefProgramme.Text,inputNomProjet.Text);
            AddProgramme AP = new AddProgramme(inputRefProgramme.Text);
            NavigationService.Navigate(AP);
        }

        private void BtnModifierActeProgramme_Click(object sender, RoutedEventArgs e)
        {

            APC.EditerActe(NumActeProgramme.Text, inputDateActeProgramme.Text, DateEnrgActeP.Text, DatePubliActeP.Text, inputConservation.Text, decimal.Parse(inputFrais.Text), inputRefProgramme.Text,inputNomProjet.Text, tempNumActeProgramme);
            AddProgramme AP = new AddProgramme(inputRefProgramme.Text);
            NavigationService.Navigate(AP);
        }

        private void dataViewActeProgramme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            DataGridCellInfo cell0 = datagridActeProgramme.SelectedCells[0];
            tempNumActeProgramme = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;

            string query = "select * from acteprogramme where NumActe =" + tempNumActeProgramme;
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
                    NumActeProgramme.Text = rdr["NumActe"].ToString();
                    inputDateActeProgramme.Text = rdr["DateActe"].ToString();
                    DateEnrgActeP.Text = rdr["DateEnrgActe"].ToString();
                    DatePubliActeP.Text = rdr["DatePubliActe"].ToString();
                    inputConservation.Text = rdr["Conservation"].ToString();
                    inputFrais.Text = rdr["FraisEnrg"].ToString();
                    oneTime = false;
                }
            }
        }

        private void BtnSupprimerActeProgramme_Click(object sender, RoutedEventArgs e)
        {
            APC.SupprimerActe(tempNumActeProgramme);
            AddProgramme AP = new AddProgramme(inputRefProgramme.Text);
            NavigationService.Navigate(AP);
        }


        //Référence Projet//
        private void getrefprojet()
        {
            string query2 = "select RefProjet from projet where NomProjet ='" + inputNomProjet.Text + "'";
            MySqlDataReader rdr2 = null;
            MySqlConnection con2 = null;
            MySqlCommand cmd2 = null;

            con2 = new MySqlConnection(Database.ConnectionString);
            con2.Open();
            cmd2 = new MySqlCommand(query2);
            cmd2.Connection = con2;
            rdr2 = cmd2.ExecuteReader();
            bool oneTime = true;
            while (rdr2.Read())
            {

                if (oneTime)
                {
                    tempnumprojet = rdr2["RefProjet"].ToString();
                    oneTime = false;
                }
            }
        }

        private void BtnOuvrirActeProgramme_Click(object sender, RoutedEventArgs e)
        {
            getrefprojet();
            string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\Acte\" + NumActeProgramme.Text;
            System.Windows.MessageBox.Show(folderPath);
            OpenFolder(folderPath);
        }

        private void BtnJoindreActeProgramme_Click(object sender, RoutedEventArgs e)
        {
            SelectFile2("Document-Acte");
        }
        public void SelectFile2(string theDirectory)
        {
            getrefprojet();
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\Acte\" + NumActeProgramme.Text + @"\" + theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectoryActe(tempnumprojet,inputRefProgramme.Text,NumActeProgramme.Text+ "/"+theDirectory);
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
        }
    }

    


