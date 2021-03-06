﻿using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Data;
using System.Collections.Generic;
using System.Windows.Media;
using Agerfor.Views.Programme;
using Agerfor.BiensReporting;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace Agerfor.Views.Programme

{
    /// <summary>
    /// Interaction logic for CreationListeLog.xaml
    /// </summary>
    public partial class CreationListeLog : System.Windows.Controls.UserControl
    {
        
        BiensController BC = new BiensController();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        int RefProgramme = 0;
        int RefProjet = 0;
        int NumEdd = 0;
        string tempnumprojet = "";
        string tempId = "";
        string TypeBien;
        string tempTypeBien = "";
        string tempNumLot = "";
        string tempNumIlot = "";
        string typevente;
        decimal CoutFoncierTTC;
        decimal prixm2;


        public CreationListeLog(int RefProjet, int refprogramme, int NumEdd, string TypeBien,string typevente, decimal CoutFoncierTTC, decimal prixm2)
        {
            InitializeComponent();

            inputPrixHT.IsEnabled =  false;
            msh.FillDropDownList("select ValeurTva from tva", inputTva, "ValeurTva");
            msh.FillDropDownList("select Type from typevente", inputTypeVente, "Type");
            this.RefProgramme = refprogramme;
            this.RefProjet = RefProjet;
            this.NumEdd = NumEdd;
            this.TypeBien = TypeBien;
            this.typevente = typevente;
            this.CoutFoncierTTC = CoutFoncierTTC;
            this.prixm2 = prixm2;
            BtnSearch.IsEnabled = inputSurMax.IsEnabled = inputSurUMax.IsEnabled= false;

            msh.FillDropDownList("select NumIlot from listeilot where RefProjet='" + RefProjet + "'",inputNumIlot,"NumIlot");
            if(TypeBien=="CNL" || TypeBien == "LPA" || TypeBien == "LSP" || TypeBien == "Promotionnel Semi Collectif" || TypeBien == "Promotionnel Individuel" || TypeBien == "Promotionnel Collectif")
            {
                inputTypeBien.Text = "Logement";
                inputTypeBien.IsEnabled = false;
            }
            
            if (inputTypeBien.Text == "Terrain")

            {
                inputNumBloc.IsEnabled = inputNiveau.IsEnabled = inputNbrPiece.IsEnabled = false;
                inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = true;
            }

            else

            {
                inputNumBloc.IsEnabled = inputNiveau.IsEnabled = inputNbrPiece.IsEnabled = true;
                inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = false;
            }
            if(typevente== "Vente par unité")
            {
                inputPrixHT.IsEnabled = inputTva.IsEnabled = false;
            }
            else
            {
                inputTva.IsEnabled = true;
                inputPrixHT.Text = prixm2.ToString();

            }

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)

        {
            msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "' and NumEdd='" + NumEdd + "'", dataViewListeBien);
        }

        private void BtnAjouterBien_Click(object sender, RoutedEventArgs e)
        {
            try {

                if (inputNumLot.Text != "")
                {
                    string Edd = "Edd";
                    DirectoryCreator DC = new DirectoryCreator();
                    DC.CreateDirectoryProgramme(RefProjet.ToString(), RefProgramme + "/" + Edd + "/" + NumEdd.ToString()+"/"+inputNumBloc.Text);
                    BC.AjouterBiens(RefProgramme, RefProjet, NumEdd, inputNumIlot.Text, inputTypeBien.Text, inputNumLot.Text, inputNumBloc.Text, inputNiveau.Text, inputNbrPiece.Text, decimal.Parse(inputSurH.Text), decimal.Parse(inputSurU.Text), decimal.Parse(inputPrixHT.Text), int.Parse(inputTva.Text), decimal.Parse(inputPrixTTC.Text), inputLimiteNord.Text, inputLimiteSud.Text, inputLimiteEst.Text, inputLimiteOuest.Text, inputEtat.Text,inputTypeVente.Text);
                    inputNumLot.Background = Brushes.White;
                    inputNumIlot.Text = inputNumLot.Text = inputNumBloc.Text = inputNiveau.Text = inputNbrPiece.Text = inputSurH.Text = inputSurU.Text = inputLimiteEst.Text = inputLimiteNord.Text = inputLimiteOuest.Text = inputLimiteSud.Text = "";
                    inputPrixHT.Text = "0.00";
                    inputTva.Text = "0";
                    inputPrixTTC.Text = "0.00";

                    msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "' and NumEdd='" + NumEdd + "'", dataViewListeBien); 
                }

            }

            catch (Exception)
            {
               
                
            }
        }           
            
            

        private void dataViewListeBien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewListeBien.SelectedCells[0];
            tempId = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;

            string query = "select * from biens where Id='"+tempId+"'";
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
                    inputNumIlot.Text = rdr["NumIlot"].ToString();
                    inputTypeBien.Text = rdr["TypeBien"].ToString();
                    inputNumLot.Text = rdr["Numlot"].ToString();
                    inputNumBloc.Text = rdr["NumBloc"].ToString();
                    inputNiveau.Text = rdr["Niveau"].ToString();
                    inputNbrPiece.Text = rdr["NbrPiece"].ToString();
                    inputSurH.Text = rdr["SurH"].ToString();
                    inputSurU.Text = rdr["SurU"].ToString();
                    inputPrixHT.Text = rdr["PrixHT"].ToString();
                    inputTva.Text = rdr["Tva"].ToString();
                    inputPrixTTC.Text = rdr["PrixTTC"].ToString();
                    inputLimiteNord.Text = rdr["LimiteNord"].ToString();
                    inputLimiteSud.Text = rdr["LimiteSud"].ToString();
                    inputLimiteEst.Text = rdr["LimiteEst"].ToString();
                    inputLimiteOuest.Text = rdr["LimiteOuest"].ToString();
                    inputTypeVente.Text = rdr["TypeVente"].ToString();
                    

                    oneTime = false;
                }
            }
        }

        private void BtnModifierBien_Click(object sender, RoutedEventArgs e)
        {
            BC.ModifierBien(RefProgramme, RefProjet, NumEdd, inputNumIlot.Text, inputTypeBien.Text, inputNumLot.Text, inputNumBloc.Text, inputNiveau.Text, inputNbrPiece.Text, decimal.Parse(inputSurH.Text), decimal.Parse(inputSurU.Text), decimal.Parse(inputPrixHT.Text), int.Parse(inputTva.Text), decimal.Parse(inputPrixTTC.Text), inputLimiteNord.Text, inputLimiteSud.Text, inputLimiteEst.Text, inputLimiteOuest.Text,tempId,inputTypeVente.Text);
            msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "' and NumEdd='" + NumEdd + "'", dataViewListeBien);
          

        }
        private void inputPrixHT_TextChanged(object sender, TextChangedEventArgs e)
        {
/*
            try
            {
                inputPrixTTC.Text = ((decimal.Parse(inputPrixHT.Text) * ((decimal.Parse(inputSurH.Text) + decimal.Parse(inputSurU.Text)))) + ((decimal.Parse(inputPrixHT.Text) * (decimal.Parse(inputSurH.Text) + decimal.Parse(inputSurU.Text))) * (decimal.Parse(inputTva.Text)) / 100) + CoutFoncierTTC).ToString();

            }
            catch (Exception)
            {

            }*/
        }
/*
        private void inputTva_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                inputPrixTTC.Text = (decimal.Parse(inputPrixHT.Text) + (decimal.Parse(inputPrixHT.Text) * (decimal.Parse(inputTva.Text)) / 100)).ToString();
            }
            catch (Exception)
            {

            }
        }*/

        private void BtnSupprimmerBien_Click(object sender, RoutedEventArgs e)
        {
            BC.SupprimerBien(tempId);
            inputNumIlot.Text = inputNumLot.Text = inputNumBloc.Text = inputNiveau.Text = inputNbrPiece.Text = inputSurH.Text = inputSurU.Text =  inputLimiteEst.Text = inputLimiteNord.Text = inputLimiteOuest.Text = inputLimiteSud.Text = "";
            inputPrixHT.Text = "0.00";
            inputTva.Text = "0";
            inputPrixTTC.Text = "0.00";
            msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and NomProjet='" + RefProjet + "' and NumEdd='" + NumEdd + "'", dataViewListeBien);
           



        }

        private void SearchSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (SearchSwitch.IsChecked == true)
            {
                inputPrixHT.IsEnabled = inputPrixTTC.IsEnabled = inputTva.IsEnabled = inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = false;
            }
            else
            {
                inputPrixHT.IsEnabled = inputPrixTTC.IsEnabled = inputTva.IsEnabled = inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = true;
            }
        }

     


        private void inputTva_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                inputPrixTTC.Text = ((((decimal.Parse(inputSurH.Text)) * decimal.Parse(inputPrixHT.Text)) + (((decimal.Parse(inputSurH.Text)) * decimal.Parse(inputPrixHT.Text))*(decimal.Parse(inputTva.SelectedValue.ToString())/100)))+(CoutFoncierTTC*(decimal.Parse(inputSurH.Text)))).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void inputSurH_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

            try
            {
                inputPrixTTC.Text = ((((decimal.Parse(inputSurH.Text)) * decimal.Parse(inputPrixHT.Text)) + (((decimal.Parse(inputSurH.Text)) * decimal.Parse(inputPrixHT.Text)) * (decimal.Parse(inputTva.SelectedValue.ToString()) / 100))) + (CoutFoncierTTC*(decimal.Parse(inputSurH.Text)))).ToString();
            }
            catch (Exception)
            {

            }

        }

      

        private void SearchSwitch_Checked(object sender, RoutedEventArgs e)
        {
            inputPrixHT.IsEnabled = inputPrixTTC.IsEnabled = inputTva.IsEnabled = inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = BtnAjouterBien.IsEnabled = BtnModifierBien.IsEnabled= BtnSupprimmerBien.IsEnabled = false;
            inputSurMax.IsEnabled = inputSurUMax.IsEnabled = BtnSearch.IsEnabled = true;
        }

        private void SearchSwitch_Unchecked(object sender, RoutedEventArgs e)
        {
            inputPrixHT.IsEnabled = inputPrixTTC.IsEnabled = inputTva.IsEnabled = inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = BtnAjouterBien.IsEnabled = BtnModifierBien.IsEnabled = BtnSupprimmerBien.IsEnabled = true;
            inputSurMax.IsEnabled = inputSurUMax.IsEnabled = BtnSearch.IsEnabled = false;
        }

        private void BtnSearch_Click(object sender, RoutedEventArgs e)
        {
           SearchLog SL = new SearchLog();
           string Query;
           Query = SL.AdvencedSearchGetQuery(inputNumLot, inputNumBloc, inputNiveau, inputNbrPiece, inputNumIlot, inputEtat,inputSurH,inputSurMax,inputSurU,inputSurUMax, RefProjet, RefProgramme, NumEdd, inputTypeBien.Text);

           BienViwer BV = new BienViwer(RefProjet,RefProgramme,NumEdd,Query);
           BV.Show();

                
    }

        private void BtnOuvrirPlan_Click(object sender, RoutedEventArgs e)
        {
            if (inputNumBloc.Text == "")
            {
                System.Windows.MessageBox.Show("Veuillez introduire un numéro de bloc pour ouvrir le dossier des  plans", "information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {

                string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + RefProjet + @"\Programme\" + RefProgramme + @"\Edd\" + NumEdd.ToString()+@"\"+inputNumBloc.Text;
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
                string Edd = "Edd";
                DirectoryCreator dcr = new DirectoryCreator();
                dcr.CreateDirectoryProgramme(RefProjet.ToString(), RefProgramme + "/" + Edd + "/" + NumEdd.ToString() + "/" + inputNumBloc.Text);
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        }

        private void BtnJoindrePlan_Click(object sender, RoutedEventArgs e)
        {
            {
                if (inputNumBloc.Text == "")
                {
                    System.Windows.MessageBox.Show("Veuillez selectionner un Bloc pour joindre des plan", "information", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    SelectFile();
                }
            }
        }

        public void SelectFile()
        {

            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + RefProjet.ToString()  + @"\Programme\" + RefProgramme + @"\Edd\" + NumEdd + @"\" + inputNumBloc.Text + @"\" + System.IO.Path.GetFileName(openFileDialog1.FileName);
                string Edd = "Edd";
                dcr.CreateDirectoryProgramme(RefProjet.ToString(), RefProgramme + "/" + Edd + "/" + NumEdd.ToString() + "/" + inputNumBloc.Text);
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


