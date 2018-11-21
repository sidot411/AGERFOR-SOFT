using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;

namespace Agerfor.Views.Demande
{
    /// <summary>
    /// Interaction logic for Demande.xaml
    /// </summary>
    public partial class Demande : Page
    {

        MySqlHelper msh = new MySqlHelper();
        string tempNumDemande = "";
        string Query = "";
        public Demande(string Query)
        {
            InitializeComponent();
            this.Query = Query;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Query =="")
            {
                msh.LoadData("select NumDemande,DateDemande,RefClient,Motif,TypeDemande,StatutDemande,Nom,Prenom,DateNaissance,LieuNaissance,Cni,DateCni,LieuCni from demande,client where demande.RefClient=client.NumClient", dataGridView2);
            }
            else
            {
                msh.LoadData(Query, dataGridView2);
            }
        }

        private void BtnAfficherDemande_Click(object sender, RoutedEventArgs e)
        {
            try
            { 
                AddDemande AD = new AddDemande(tempNumDemande);
                AD.BtnModifier.Visibility = Visibility.Collapsed;
                this.NavigationService.Navigate(AD);
                
                
            }
            catch(Exception)
            {
                MessageBox.Show("Veuillez sélectioner une demande");
            }


        }

        private void dataGridView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridCellInfo cell0 = dataGridView2.SelectedCells[0];
                tempNumDemande = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
            }
            catch (Exception)
            {
            }
        }

        private void BtnModifierDemande_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddDemande AD = new AddDemande(tempNumDemande);
                AD.inputTypeDemande.IsEnabled = AD.inputMotifDemande.IsEnabled = AD.inputStatutDemande.IsEnabled = true;
                this.NavigationService.Navigate(AD);


            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez sélectioner une demande");
            }
        }
    }
}
