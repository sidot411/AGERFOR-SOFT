﻿using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Windows.Navigation;
using System;
using MaterialDesignThemes.Wpf;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace Agerfor.Views.Payement
{
    /// <summary>
    /// Interaction logic for ListeVers.xaml
    /// </summary>
    public partial class ListeVers : Window
    {
        OrdreVerssementController OVC = new OrdreVerssementController();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        int tempNumOV = 0;
        int NumAttribution;
        int NumPayement;
        int tempNumVerssement;
        decimal Reste;
        AddPayement AddPayement;
        
        public ListeVers(int NumPayement, decimal Reste,int NumAttribution, AddPayement AddPayement)
        {

            InitializeComponent();
            msh.LoadData("select * from ov where NumPayement='" + NumPayement + "'", dataViewOV);
            this.NumPayement = NumPayement;
            this.Reste = Reste;
            this.AddPayement = AddPayement;
            this.NumAttribution = NumAttribution;
            inputNumPayement.Text = NumPayement.ToString();
            inputEtat.IsEnabled = false;
           

        }

        private void BtnOV_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.Parse(inputMontant.Text) <= Reste)
            {
                OVC.AjouterOV(NumPayement, inputNumOV.Text, inputDateVersement.Text, inputDateEcheance.Text, decimal.Parse(inputMontant.Text), inputEtat.Text, inputDateRecu.Text, inputNumRecu.Text);
                msh.LoadData("select * from ov where NumPayement='" + NumPayement + "'", dataViewOV);
            }
            else
            
                {
                System.Windows.MessageBox.Show("Le montant CNL est supérieux au montant reste à payé du bien veuillez introduire une valeur inferieur");
                }
        }

        private void dataViewOV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewOV.SelectedCells[0];
            tempNumOV = int.Parse(((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text);

            string query = "select * from ov where NumPayement='" + NumPayement + "' and NumOV='" + tempNumOV + "'";
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
                tempNumVerssement = int.Parse(rdr["NumVerssement"].ToString());
                inputNumOV.Text = rdr["NumOV"].ToString();
                inputDateVersement.Text = rdr["DateOV"].ToString();
                inputDateEcheance.Text = rdr["DateEcheance"].ToString();
                inputMontant.Text = rdr["MontantAV"].ToString();
                inputEtat.Text = rdr["Etat"].ToString();
                inputDateRecu.Text = rdr["DateRecu"].ToString();
                inputNumRecu.Text = rdr["NumRecu"].ToString();
                inputNumPayement.IsEnabled = inputNumOV.IsEnabled = inputDateVersement.IsEnabled = inputDateEcheance.IsEnabled = inputMontant.IsEnabled = false;
                BtnOV.IsEnabled = false;
            }
        }


        private void BtnNewOv_Click(object sender, RoutedEventArgs e)
        {

            inputNumOV.Text = inputDateVersement.Text = inputDateEcheance.Text = inputMontant.Text = inputDateRecu.Text = inputNumRecu.Text = string.Empty;
            inputNumPayement.IsEnabled = inputNumOV.IsEnabled = inputDateVersement.IsEnabled = inputDateEcheance.IsEnabled = inputMontant.IsEnabled = true;
            msh.LoadData("select * from ov where NumPayement='" + NumPayement + "'", dataViewOV);
            BtnOV.IsEnabled = true;



        }

        private void BtnValiderverssement_Click(object sender, RoutedEventArgs e)
        {

            if (inputNumRecu.Text != "" && inputDateRecu.Text != "")
            {
                if (inputNumOV.Text != "")
                {
                    OrdreVerssementController OVC = new OrdreVerssementController();
                    OVC.UpdateOV("Terminé", inputDateRecu.Text, inputNumRecu.Text, tempNumVerssement);
                    msh.ExecuteQuery("update payement set MontantVerse=MontantVerse+" + decimal.Parse(inputMontant.Text) + ",Reste=MontantTotal-MontantVerse where NumPayement='" + NumPayement + "'");
                    msh.LoadData("select * from ov where NumPayement='" + NumPayement + "'", dataViewOV);
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
                    AddPayement.BtnCNL.IsEnabled = AddPayement.BtnFNPOS.IsEnabled = AddPayement.BtnCB.IsEnabled = true;
                }
                else
                {
                    System.Windows.MessageBox.Show("Veuillez selectionner un OV");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez remplir le Num et la date du recu de verssement !");
            }
            
            MainWindow mainWindows = (MainWindow)System.Windows.Application.Current.Windows[0];
            mainWindows.Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            mainWindows.Frame.Navigate(AddPayement);
            mainWindows.currentWindow.Text = "Payement";
            mainWindows.Activate();
            this.Close();
        }

        private void BtnUploadFiles_Click(object sender, RoutedEventArgs e)
        {
            SelectFile("Payements");
        }
        public void SelectFile(string theDirectory)
        {
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Attribution\" + NumAttribution.ToString() + @"\" + theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolder))
                {
                    File.Delete(destinationFolder);
                }
                File.Copy(fileName, Path.Combine(Path.GetDirectoryName(fileName), destinationFolder));
                System.Windows.MessageBox.Show(destinationFolder.ToString());
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionner");
            }
        }

        private void BtnOpenFolder_Click(object sender, RoutedEventArgs e)
        {

            string folderPath = AppDomain.CurrentDomain.BaseDirectory+ @"Attribution\" + NumAttribution.ToString() + @"\Payements\";
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
                dcr.CreateDirectory3(NumAttribution.ToString() + "/");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        }
    }
}
