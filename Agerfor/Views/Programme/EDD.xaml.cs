﻿using System;
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
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Agerfor.Views.Programme
{
    /// <summary>
    /// Interaction logic for EDD.xaml
    /// </summary>
    public partial class EDD : System.Windows.Controls.UserControl
    {
        EddController EC = new EddController();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        string RefProgramme = "";
        string NomProjet = "";
        string tempnumprojet = "";
        string tempNumEdd = "";
        public EDD(string NomProjet, string refprogramme)
        {
            InitializeComponent();
            title.Text = "EDD";
            this.RefProgramme = refprogramme;
            this.NomProjet = NomProjet;
        }

        private void getrefprojet()
        {
            string query2 = "select RefProjet from projet where NomProjet ='" + NomProjet + "'";
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


        private void Page_Loaded(object sender, RoutedEventArgs e)

        {

            msh.LoadData("select * from edd where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'", dataViewListeEdd);
        }

        private void dataViewListeEdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewListeEdd.SelectedCells[0];
            tempNumEdd = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;

            string query = "select * from edd where NumEdd =" + tempNumEdd;
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
                    inputNumEdd.Text = rdr["NumEdd"].ToString();
                    inputDateEdd.Text = rdr["DateEdd"].ToString();
                    inputNumEnreg.Text = rdr["NumEnrg"].ToString();
                    inputDateEnreg.Text = rdr["DateEnrg"].ToString();
                    inputVolume.Text = rdr["Volume"].ToString();
                    inputConservation.Text = rdr["Conservation"].ToString();
                    inputNotaire.Text = rdr["Notaire"].ToString();
                    inputTelNotaire.Text = rdr["TelNotaire"].ToString();
                    inputAdresseNotaire.Text = rdr["AdresseNotaire"].ToString();
                    inputNomGeo.Text = rdr["NomPrenomGeo"].ToString();
                    inputAddresseGeo.Text = rdr["AdresseGeo"].ToString();
                    inputTelGeo.Text = rdr["TelGeo"].ToString();
                    inputNbrLog.Text = rdr["NbrLog"].ToString();
                    inputSupLog.Text = rdr["SuperficieLog"].ToString();
                    inputNbrLoc.Text = rdr["NbrLoc"].ToString();
                    inputSupLoc.Text = rdr["SuperficeiLoc"].ToString();
                    inputNbrBur.Text = rdr["NbrBur"].ToString();
                    inputSupBur.Text = rdr["SuperficieBur"].ToString();
                    inputNbrCave.Text = rdr["NbrCave"].ToString();
                    inputSupCave.Text = rdr["SuperficieCave"].ToString();
                    inputNbrCC.Text = rdr["NbrCC"].ToString();
                    inputSupCC.Text = rdr["SuperficieCC"].ToString();
                    inputNbrPS.Text = rdr["NbrPS"].ToString();
                    inputSupPS.Text = rdr["SuperficiePS"].ToString();



                    oneTime = false;
                }
            }
        }


    

    private void BtnAjouterEdd_Click(object sender, RoutedEventArgs e)
        {
            string Edd = "Edd";
            getrefprojet();
            DirectoryCreator DC = new DirectoryCreator();
            DC.CreateDirectoryProgramme(tempnumprojet, RefProgramme + "/" + Edd + "/" + inputNumEdd.Text);
            EC.AjouterEdd(NomProjet,RefProgramme,inputNumEdd.Text,inputDateEdd.Text,inputNumEnreg.Text,inputDateEnreg.Text,inputVolume.Text,inputConservation.Text,inputNotaire.Text,inputTelNotaire.Text,inputAdresseNotaire.Text,inputNomGeo.Text,inputAddresseGeo.Text,inputTelGeo.Text,inputNbrLog.Text,decimal.Parse(inputSupLog.Text),inputNbrLoc.Text,decimal.Parse(inputSupLoc.Text),inputNbrBur.Text,decimal.Parse(inputSupBur.Text),inputNbrCave.Text,decimal.Parse(inputSupCave.Text),inputNbrCC.Text,decimal.Parse(inputSupCC.Text),inputNbrPS.Text,decimal.Parse(inputSupPS.Text));
            msh.LoadData("select * from edd where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'", dataViewListeEdd);
            inputNumEdd.Text = inputDateEdd.Text = inputNumEnreg.Text = inputDateEnreg.Text = inputVolume.Text = inputConservation.Text = inputNotaire.Text = inputTelNotaire.Text = inputAdresseNotaire.Text = inputNomGeo.Text = inputTelGeo.Text = inputAddresseGeo.Text= inputNbrLog.Text=inputNbrLoc.Text=inputNbrCave.Text=inputNbrCC.Text=inputNbrPS.Text=inputNbrBur.Text= "";
            inputSupLog.Text = inputSupLoc.Text = inputSupBur.Text = inputSupCave.Text = inputSupCC.Text = inputSupPS.Text = "0";

        }

        private void BtnModifierEdd_Click(object sender, RoutedEventArgs e)
        {

             EC.ModifierEdd(NomProjet, RefProgramme, inputNumEdd.Text, inputDateEdd.Text, inputNumEnreg.Text, inputDateEnreg.Text, inputVolume.Text, inputConservation.Text, inputNotaire.Text, inputTelNotaire.Text, inputAdresseNotaire.Text, inputNomGeo.Text, inputAddresseGeo.Text, inputTelGeo.Text, inputNbrLog.Text, decimal.Parse(inputSupLog.Text), inputNbrLoc.Text, decimal.Parse(inputSupLoc.Text), inputNbrBur.Text, decimal.Parse(inputSupBur.Text), inputNbrCave.Text, decimal.Parse(inputSupCave.Text), inputNbrCC.Text, decimal.Parse(inputSupCC.Text), inputNbrPS.Text, decimal.Parse(inputSupPS.Text),tempNumEdd);
             msh.LoadData("select * from edd where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'", dataViewListeEdd);
             inputNumEdd.Text = inputDateEdd.Text = inputNumEnreg.Text = inputDateEnreg.Text = inputVolume.Text = inputConservation.Text = inputNotaire.Text = inputTelNotaire.Text = inputAdresseNotaire.Text = inputNomGeo.Text = inputTelGeo.Text = inputAddresseGeo.Text = inputNbrLog.Text = inputNbrLoc.Text = inputNbrCave.Text = inputNbrCC.Text = inputNbrPS.Text = inputNbrBur.Text = "";
             inputSupLog.Text = inputSupLoc.Text = inputSupBur.Text = inputSupCave.Text = inputSupCC.Text = inputSupPS.Text = "0";

        }

        private void BtnSupprimmerEdd_Click(object sender, RoutedEventArgs e)
        {
            DirectoryCreator DC = new DirectoryCreator();
            DC.DeleteDirectory(@"Projet\" + tempnumprojet + @"\Programme\" + RefProgramme + @"\Edd \" + tempNumEdd);
            EC.SupprimerEdd(tempNumEdd);
            msh.LoadData("select * from edd where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'", dataViewListeEdd);
            inputNumEdd.Text = inputDateEdd.Text = inputNumEnreg.Text = inputDateEnreg.Text = inputVolume.Text = inputConservation.Text = inputNotaire.Text = inputTelNotaire.Text = inputAdresseNotaire.Text = inputNomGeo.Text = inputTelGeo.Text = inputAddresseGeo.Text = inputNbrLog.Text = inputNbrLoc.Text = inputNbrCave.Text = inputNbrCC.Text = inputNbrPS.Text = inputNbrBur.Text = "";
            inputSupLog.Text = inputSupLoc.Text = inputSupBur.Text = inputSupCave.Text = inputSupCC.Text = inputSupPS.Text = "0";

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOuvrirEdd_Click(object sender, RoutedEventArgs e)
        {
            getrefprojet();
            string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + RefProgramme + @"\Edd\" + inputNumEdd.Text;
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
                dcr.CreateDirectoryProgramme(tempnumprojet, RefProgramme + "/");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        }

        private void BtnJoindreEdd_Click(object sender, RoutedEventArgs e)
        {
            SelectFile("Document Edd");
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
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + RefProgramme + @"\Edd\" + inputNumEdd.Text + @"\" + theDirectory + @"\" + System.IO.Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectoryEdd(tempnumprojet, RefProgramme, inputNumEdd.Text + "/" + theDirectory);
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolder))
                {
                    File.Delete(destinationFolder);
                }

                File.Copy(fileName, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(fileName), destinationFolder));
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionner");
            }
        }
    }
}
