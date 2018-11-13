using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MaterialDesignThemes.Wpf;


namespace Agerfor.Views.Clients
{
    /// <summary>
    /// Interaction logic for Client.xaml
    /// </summary>
    public partial class Client : Page

    {
        MySqlHelper msh = new MySqlHelper();
        string tempNumClient = "";
        string tempSituation = "";
        string Query = "";

        public Client(string Query)
        {
            InitializeComponent();
            this.Query = Query;
            

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Query == "")
            {
                msh.LoadData("select * from client", dataGridView2);
            }
            else
            {
                msh.LoadData(Query, dataGridView2);
            }
        }

        private void BtnAfficherClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddClient AC = new AddClient(tempNumClient, tempSituation);
                AC.BtnAjouter.Visibility = Visibility.Collapsed;
                AC.BtnModifier.Visibility = Visibility.Collapsed;
                this.NavigationService.Navigate(AC);
            }
            catch (Exception)
            {
                MessageBox.Show("Veuillez sélectionner un client!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridCellInfo cell0 = dataGridView2.SelectedCells[0];
                tempNumClient = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
                DataGridCellInfo cell7 = dataGridView2.SelectedCells[7];
                tempSituation = ((TextBlock)cell7.Column.GetCellContent(cell7.Item)).Text;
            }
            catch (Exception)
            {
            }
        }

        private void BtnModifierClient_Click(object sender, RoutedEventArgs e)

        {
           if (tempNumClient !="")
            { 
                AddClient AC = new AddClient(tempNumClient, tempSituation);
                AC.BtnAjouter.Visibility = Visibility.Collapsed;
                this.NavigationService.Navigate(AC);
            }
            else
            {
                MessageBox.Show("Veuillez sélectionner un client!", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void BtnAjouterClient_Click(object sender, RoutedEventArgs e)
        {

            AddClient ac = new AddClient("", "");
            NavigationService.Navigate(ac);


        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumClient != "")
            { 
                if (MessageBox.Show("Voulez-vous supprimer ce client?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                    Client C = new Client("");
                    NavigationService.Navigate(C);
                }
                else
                {
                    ClientController CC = new ClientController();
                    CC.DeleteClient(tempNumClient);
                    MessageBox.Show("Le client " + tempNumClient + " a était bien supprimer");
                    Client C = new Client("");
                    NavigationService.Navigate(C);
                }
                    
                }
  
            
        else
        {
                MessageBox.Show("Veuillez selectioner un client", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

            
        }

        private void BtnRecherche_Click(object sender, RoutedEventArgs e)
        {
            {
                if (inputrecherche.Text !="" && inputrecherche.Text != "" && SelectTypeRecherche.Text !="")
                {
                    Client C = new Client("select * from client where " + SelectTypeRecherche.Text + " like'%" + inputrecherche.Text + "%'");
                    C.inputrecherche.Text = inputrecherche.Text;
                    this.NavigationService.Navigate(C);
                }
                else if (inputrecherche.Text == "*")
                {
                    Client C = new Client("");
                    C.inputrecherche.Text = "*";
                    this.NavigationService.Navigate(C);
                }
                else
                {
                    MessageBox.Show("La recherche ne peut pas etre effectuer");
                }
            }
        }
    }
}
