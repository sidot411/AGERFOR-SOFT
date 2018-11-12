using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;


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

        public Client()
        {
            InitializeComponent();
            msh.LoadData("select * from client", dataGridView2);
            
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
            catch(Exception)
            {
                MessageBox.Show("Veuillez sélectionner un client!","Information", MessageBoxButton.OK, MessageBoxImage.Information );
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


    }
}
