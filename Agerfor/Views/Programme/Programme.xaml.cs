using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using Agerfor.Views.Projet;
using Agerfor.Views.Programme;

namespace Agerfor.Views.Programme
{
    /// <summary>
    /// Interaction logic for Programme.xaml
    /// </summary>
    public partial class Programme : Page
    {
        MySqlHelper msh = new MySqlHelper();
        string temprefprogramme = "";
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
                if (MessageBox.Show("Voulez-vous supprimer ce projet?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                    Programme P = new Programme("");
                    NavigationService.Navigate(P);
                }
                else
                {

                    ProgrammeController PC = new ProgrammeController();
                    PC.DeleteProgramme(temprefprogramme);
                    Programme P = new Programme("");
                    NavigationService.Navigate(P);
                }

            }


            else
            {
                MessageBox.Show("Veuillez selectioner un projet", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
