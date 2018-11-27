﻿using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using Agerfor.Views.Projet;

namespace Agerfor.Views.Projet
{
    /// <summary>
    /// Interaction logic for Projet.xaml
    /// </summary>
    public partial class Projet : Page
    {
        MySqlHelper msh = new MySqlHelper();
        string tempRefProjet = "";
        string Query = "";
        public Projet(string Query)
        {
            InitializeComponent();
            this.Query = Query;

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Query == "")
            {
                msh.LoadData("select * from projet", dataGridView2);
            }
            else
            {
                msh.LoadData(Query, dataGridView2);
            }
        }


        private void BtnAfficherProjet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                MessageBox.Show(tempRefProjet);
                AddProjet AP = new AddProjet(tempRefProjet);
                AP.inputRefProjet.IsEnabled = AP.inputNomProjet.IsEnabled = AP.inputVolProjet.IsEnabled = AP.inputConservProjet.IsEnabled = AP.inputVendeurProjet.IsEnabled = AP.inputWilayaProjet.IsEnabled = AP.inputDairaProjet.IsEnabled = AP.inputCommuneProjet.IsEnabled = AP.inputSuperficieProjet.IsEnabled = AP.inputNomGeo.IsEnabled = AP.inputAddressGeo.IsEnabled = AP.inputTelGeo.IsEnabled = AP.inputLimitEst.IsEnabled = AP.inputLimitNord.IsEnabled = AP.inputLimitOuest.IsEnabled = AP.inputLimitSud.IsEnabled = AP.inputPrix.IsEnabled = AP.inputNumReçu.IsEnabled = AP.inputDateRecu.IsEnabled =AP.BtnAjouterProjet.IsEnabled =AP.BtnModifierProjet.IsEnabled= AP.BtnUploadFiles.IsEnabled=AP.inputNumAct.IsEnabled=AP.inputDateActe.IsEnabled=AP.inputEnrgActe.IsEnabled=AP.inputDatepubliActe.IsEnabled=AP.BtnAjouterActe.IsEnabled=AP.BtnModifierActe.IsEnabled=AP.BtnSupprimerActe.IsEnabled=AP.BtnJoindre.IsEnabled=AP.BtnOuvrirActe.IsEnabled= false;
                this.NavigationService.Navigate(AP);
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez sélectionner une référence");
            }

        }

        private void dataGridView2_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridCellInfo cell0 = dataGridView2.SelectedCells[0];
                tempRefProjet = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
            }
            catch (Exception)
            {

            }

        }

        private void BtnSuppProjet_Click(object sender, RoutedEventArgs e)
        {
            if (tempRefProjet != "")
            {
                if (MessageBox.Show("Voulez-vous supprimer ce projet?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                    Projet P = new Projet("");
                    NavigationService.Navigate(P);
                }
                else
                {
                    ProjetController PC = new ProjetController();
                    ActeController AC = new ActeController();
                    AC.SupprimerActe2(tempRefProjet);
                    PC.DeleteProjet(tempRefProjet);
                    
                   
                    MessageBox.Show("Le projet " + tempRefProjet + " à était bien supprimer");
                    Projet P = new Projet("");
                    NavigationService.Navigate(P);
                }

            }


            else
            {
                MessageBox.Show("Veuillez selectioner un projet", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }


        }

        private void BtnAjouterProjet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddProjet AP = new AddProjet("");
                NavigationService.Navigate(AP);
            }
            catch (Exception)
            {

            }
        }

        private void BtnModifierProjet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddProjet AP = new AddProjet(tempRefProjet);
                AP.BtnAjouterProjet.IsEnabled = false;
                this.NavigationService.Navigate(AP);
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez sélectionner une référence");
            }

        }
    }
}