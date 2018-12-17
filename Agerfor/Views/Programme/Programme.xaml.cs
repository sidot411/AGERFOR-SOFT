﻿using System;
using System.Windows;
using System.Windows.Controls;

using Agerfor.Controlers;

using MySql.Data.MySqlClient;
using DbConnection.Models;

using System.Windows.Forms;


namespace Agerfor.Views.Programme
{
    /// <summary>
    /// Interaction logic for Programme.xaml
    /// </summary>
    public partial class Programme : Page
    {
        
        PermiLotirController PLC = new PermiLotirController();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        string temprefprogramme = "";
        string tempNomProjet = "";
        string tempnumprojet = "";
        string query = "";
        
        public Programme(string query)
        {
            InitializeComponent();
            this.query = query;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (query == "")
            {
                msh.LoadData("select * from programme", dataGridView2);
            }
            else
            {
                msh.LoadData(query, dataGridView2);
            }
        }

      

        private void dataGridView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataGridView2.SelectedCells[0];
            temprefprogramme = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
            DataGridCellInfo cell1 = dataGridView2.SelectedCells[1];
            tempNomProjet = ((TextBlock)cell1.Column.GetCellContent(cell1.Item)).Text;
        }
        private void BtnAfficherProgramme_Click(object sender, RoutedEventArgs e)
        {

            AddProgramme AP = new AddProgramme(temprefprogramme);
            AP.GridProgramme.IsEnabled = false;
            NavigationService.Navigate(AP);

        }
        private void BtnAjouterProgramme_Click(object sender, RoutedEventArgs e)
        {
            AddProgramme AP = new AddProgramme(""); 
            NavigationService.Navigate(AP);
        }

        private void BtnModifierProgramme_Click(object sender, RoutedEventArgs e)
        {
            AddProgramme AP = new AddProgramme(temprefprogramme);
            AP.BtnAjouterProgramme.IsEnabled = false;
            NavigationService.Navigate(AP);
        }

        private void BtnSuppProgramme_Click(object sender, RoutedEventArgs e)
        {
            if (temprefprogramme != "")
            {
                if (System.Windows.MessageBox.Show("Voulez-vous supprimer ce projet?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                    Programme P = new Programme("");
                    NavigationService.Navigate(P);
                }
                else
                {
                    ActeProgrammeController APC = new ActeProgrammeController();
                    ProgrammeController PC = new ProgrammeController();
                    DirectoryCreator DC = new DirectoryCreator();
                    PermiLotirController PLC = new PermiLotirController();
                    PermisDeConstruireController PDCC = new PermisDeConstruireController();
                    
                    DC.DeleteDirectory(@"Projet\" + tempnumprojet + @"\Programme\"+ temprefprogramme);
                    
                    APC.SupprimerActeFromProgramme(temprefprogramme);
                    PLC.SupprimerPLFromProgramme(temprefprogramme);
                    PDCC.SupprimerPermisConstruireFromProgramme(temprefprogramme);
                    PC.DeleteProgramme(temprefprogramme);
                    Programme P = new Programme("");
                    NavigationService.Navigate(P);
                }

            }


            else
            {
                System.Windows.MessageBox.Show("Veuillez selectioner un projet", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void getrefprojet()
        {
            string query2 = "select RefProjet from projet where NomProjet ='" + tempNomProjet + "'";
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

        private void inputrecherche2_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {

        }
    }
}