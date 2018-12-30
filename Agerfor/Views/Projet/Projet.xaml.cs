using System;
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
        string tempnomprojet = "";
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
                if (tempnomprojet != "") { 
                AddProjet AP = new AddProjet(tempRefProjet);
                AP.inputRefProjet.IsEnabled = AP.inputNomProjet.IsEnabled = AP.inputVolProjet.IsEnabled = AP.inputConservProjet.IsEnabled = AP.inputVendeurProjet.IsEnabled = AP.inputWilayaProjet.IsEnabled = AP.inputDairaProjet.IsEnabled = AP.inputCommuneProjet.IsEnabled = AP.inputSuperficieProjet.IsEnabled = AP.inputNomGeo.IsEnabled = AP.inputAddressGeo.IsEnabled = AP.inputTelGeo.IsEnabled = AP.inputLimitEst.IsEnabled = AP.inputLimitNord.IsEnabled = AP.inputLimitOuest.IsEnabled = AP.inputLimitSud.IsEnabled = AP.inputPrix.IsEnabled = AP.inputNumReçu.IsEnabled = AP.inputDateRecu.IsEnabled =AP.BtnAjouterProjet.IsEnabled =AP.BtnModifierProjet.IsEnabled= AP.BtnUploadFiles.IsEnabled=AP.inputNumAct.IsEnabled=AP.inputDateActe.IsEnabled=AP.inputEnrgActe.IsEnabled=AP.inputDatepubliActe.IsEnabled=AP.BtnAjouterActe.IsEnabled=AP.BtnModifierActe.IsEnabled=AP.BtnSupprimerActe.IsEnabled=AP.BtnJoindre.IsEnabled=AP.BtnOuvrirActe.IsEnabled= false;
                this.NavigationService.Navigate(AP);
                }
                else
                {
                    MessageBox.Show("Veuillez sélectionner un projet!", "Projet", MessageBoxButton.OK, MessageBoxImage.Information);
                }
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
                DataGridCellInfo cell1 = dataGridView2.SelectedCells[1];
                tempnomprojet = ((TextBlock)cell1.Column.GetCellContent(cell1.Item)).Text;

            }
            catch (Exception)
            {

            }

        }

        private void BtnSuppProjet_Click(object sender, RoutedEventArgs e)
        {
            if (tempRefProjet != "")
            {

                System.Windows.MessageBox.Show("Note: Lors de la supression d'un projet tous les élements qui appartienent au projet et au programmes du projet à savoir(Acte,Permis de lotir, permis de construire, Cahier des charges, Edd,Convention, et documents) seront automatiquement supprimé !", "Information", MessageBoxButton.OK, MessageBoxImage.Warning);

                if (MessageBox.Show("Voulez-vous supprimer ce projet?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                    Projet P = new Projet("");
                    NavigationService.Navigate(P);
                }
                else
                {
                    BiensController BC = new BiensController();
                    BC.SupprimerLogFromProjet(tempnomprojet);  
                    ProjetController PC = new ProjetController();
                    DirectoryCreator DC = new DirectoryCreator();   
                    ActeController AC = new ActeController();
                    ProgrammeController PRC = new ProgrammeController();
                    ActeProgrammeController APC = new ActeProgrammeController();
                    PermiLotirController PLC = new PermiLotirController();
                    PermisDeConstruireController PDCC = new PermisDeConstruireController();
                    CahierChargeProgrammeController CCPC = new CahierChargeProgrammeController();
                    EddController EC = new EddController();
                    ConventionController CC = new ConventionController();
                    DC.DeleteDirectory(@"Projet\" + tempRefProjet);
                    CC.SupprimerConventionFromProjet(tempnomprojet);
                    EC.SupprimerEddFromProjet(tempnomprojet);
                    CCPC.SupprimerCahierChargeFromProjet(tempnomprojet);
                    APC.SupprimerActeFromProjet(tempnomprojet);
                    PDCC.SupprimerPermisConstruireFromProjet(tempnomprojet);
                    PLC.SupprimerPLFromProjet(tempnomprojet);
                    PRC.DeleteProgrammeFromProjet(tempnomprojet);
                    AC.SupprimerActe2(tempRefProjet);
                    PC.DeleteProjet(tempRefProjet);  
                    MessageBox.Show("Le projet " + tempRefProjet + " à était bien supprimer");
                    Projet P = new Projet("");
                    NavigationService.Navigate(P);
                }

            }


            else
            {
                MessageBox.Show("Veuillez selectioner un projet", "Projet", MessageBoxButton.OK, MessageBoxImage.Information);
            }


        }

        private void BtnAjouterProjet_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddProjet AP = new AddProjet("");
                AP.BtnModifierProjet.IsEnabled = AP.BtnUploadFiles.IsEnabled=AP.BtnOpenFolder.IsEnabled= false;
                NavigationService.Navigate(AP);
            }
            catch (Exception)
            {

            }
        }

        private void BtnModifierProjet_Click(object sender, RoutedEventArgs e)
        {
            if (tempnomprojet != "")
            {
                    AddProjet AP = new AddProjet(tempRefProjet);
                    AP.BtnAjouterProjet.IsEnabled = false;
                    this.NavigationService.Navigate(AP);
        
            }
            else
            {
                MessageBox.Show("Veuillez selectioner un projet", "Projet", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }
    }
}