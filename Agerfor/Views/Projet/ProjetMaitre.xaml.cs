using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using Agerfor.Views.Projet;
using System.Windows.Navigation;
using Agerfor.Views.Projet;
using MaterialDesignThemes.Wpf;

namespace Agerfor.Views.Projet
{
    /// <summary>
    /// Interaction logic for ProjetMaitre.xaml
    /// </summary>
    public partial class ProjetMaitre : UserControl
    {
        AddProjet addprojet;
        string tempNomProjetMaitre;
        MySqlHelper msh = new MySqlHelper();
        public ProjetMaitre(AddProjet addprojet)
        {
           
            
            this.addprojet = addprojet;
            InitializeComponent();
            msh.LoadData("select NomProjetM from projetmaitre", dataViewProjet);

        }

        private void BtnAjouterProjetM_Click(object sender, RoutedEventArgs e)
        {
            
            ProjetMaitreController PMC = new ProjetMaitreController();
            PMC.AjouterProjetMaitre(inputNomProjet.Text);
            MainWindow mainWindows = (MainWindow)Application.Current.Windows[0];
            mainWindows.Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
            addprojet = new AddProjet(0);
            mainWindows.Frame.Navigate(addprojet);
            mainWindows.currentWindow.Text = "Projet";
            mainWindows.Activate();

        }

        private void BtnModifierProjetM_Click(object sender, RoutedEventArgs e)
        {
            ProjetMaitreController PMC = new ProjetMaitreController();
            PMC.ModifierProjetMaitre(inputNomProjet.Text,tempNomProjetMaitre);
            msh.LoadData("select NomProjetM from projetmaitre", dataViewProjet);
            inputNomProjet.Text = "";
        }

        private void BtnSupprimerProjetM_Click(object sender, RoutedEventArgs e)
        {

            ProjetMaitreController PMC = new ProjetMaitreController();
            PMC.SupprimeProjetMaitre(inputNomProjet.Text);
            msh.LoadData("select NomProjetM from projetmaitre", dataViewProjet);
            inputNomProjet.Text = "";
        }

        private void dataViewProjet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridCellInfo cell0 = dataViewProjet.SelectedCells[0];
                tempNomProjetMaitre = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
                inputNomProjet.Text = tempNomProjetMaitre;
            }
            catch (Exception)
            {

            }
        }
    }
}
