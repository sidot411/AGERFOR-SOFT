using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using Agerfor.Views.Projet;
using MaterialDesignThemes.Wpf;
using Agerfor.ListeProjetReporting;

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
        string UserRole;
        public Projet(string Query, string UserRole)
        {
            InitializeComponent();
            this.Query = Query;
            this.UserRole = UserRole;
            if (UserRole =="Lecteur")
            {
                BtnSuppProjet.IsEnabled = BtnAjouterProjet.IsEnabled = BtnModifierProjet.IsEnabled = false;
            }

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
                if (tempnomprojet !="") { 
                AddProjet AP = new AddProjet(int.Parse(tempRefProjet),UserRole);
                AP.inputRefProjet.IsEnabled = AP.inputNomProjet.IsEnabled = AP.inputConserv.IsEnabled = AP.inputVendeurProjet.IsEnabled =
                AP.inputWilayaProjet.IsEnabled = AP.inputDairaProjet.IsEnabled = AP.inputCommuneProjet.IsEnabled = AP.inputSuperficieProjet.IsEnabled = 
                AP.inputLimitEst.IsEnabled = AP.inputLimitNord.IsEnabled = AP.inputLimitOuest.IsEnabled = AP.inputLimitSud.IsEnabled = AP.inputNumReçu.IsEnabled =
                AP.inputDateRecu.IsEnabled =AP.BtnAjouterProjet.IsEnabled =AP.BtnModifierProjet.IsEnabled= AP.BtnUploadFiles.IsEnabled=AP.inputNumAct.IsEnabled=
                AP.inputDatepubliActe.IsEnabled=AP.BtnAjouterActe.IsEnabled=AP.BtnModifierActe.IsEnabled=AP.BtnSupprimerActe.IsEnabled=AP.BtnJoindre.IsEnabled=
                AP.BtnOuvrirActe.IsEnabled = AP.inputProjetMaitre.IsEnabled=AP.inputPayement.IsEnabled=AP.inputMontantC.IsEnabled=AP.inputMontantCB.IsEnabled=
                AP.inputVolume.IsEnabled=AP.inputRefPub.IsEnabled=AP.inputFraisActe.IsEnabled=AP.inputPOS.IsEnabled= AP.BtnAjouterIlot.IsEnabled = AP.BtnModifierIlot.IsEnabled = AP.BtnSupprimerIlot.IsEnabled =  AP.dataViewActeProjet.IsEnabled = AP.dataViewIlot.IsEnabled = false;
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

                    Projet P = new Projet("",UserRole);
                    NavigationService.Navigate(P);
                }
                else
                {
                    BiensController BC = new BiensController();
                    BC.SupprimerLogFromProjet(int.Parse(tempRefProjet));  
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
                    EC.SupprimerEddFromProjet(int.Parse(tempRefProjet));
                    CCPC.SupprimerCahierChargeFromProjet(tempnomprojet);
                    PDCC.SupprimerPermisConstruireFromProjet(int.Parse(tempRefProjet));
                    PLC.SupprimerPLFromProjet(int.Parse(tempRefProjet));
                    PRC.DeleteProgrammeFromProjet(int.Parse(tempRefProjet));
                    AC.SupprimerActe2(tempRefProjet);
                    PC.DeleteProjet(tempRefProjet);  
                    MessageBox.Show("Le projet " + tempRefProjet + " à était bien supprimer");
                    Projet P = new Projet("",UserRole);
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
                if (System.Windows.MessageBox.Show("Voulez-vous ajouter un projet maitre ?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.No)
                {
                    AddProjet AP = new AddProjet(0,UserRole);
                    AP.BtnModifierProjet.IsEnabled = AP.BtnUploadFiles.IsEnabled = AP.BtnOpenFolder.IsEnabled = false;
                    NavigationService.Navigate(AP);
                }
                else
                {
                    AddProjet AP = new AddProjet(0,UserRole);
                    ProjetMaitre PM = new ProjetMaitre(AP,UserRole);
                    DialogHost.Show(PM);
                }

               
            }
            catch (Exception)
            {

            }
        }

        private void BtnModifierProjet_Click(object sender, RoutedEventArgs e)
        {
            if (tempnomprojet != "")
            {
                    AddProjet AP = new AddProjet(int.Parse(tempRefProjet),UserRole);
                    AP.BtnAjouterProjet.IsEnabled = false;
                    this.NavigationService.Navigate(AP);
        
            }
            else
            {
                MessageBox.Show("Veuillez selectioner un projet", "Projet", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void BtnImprimeliste_Click(object sender, RoutedEventArgs e)
        {
            ListeProjetViwer LPV = new ListeProjetViwer(@"select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS DatePubli,DATE_FORMAT(DateRecu,'%d/%m/%y') AS DateR from projet,acteprojet where projet.RefProjet=acteprojet.RefProjet");
            LPV.Show();
        }

        private void inputCodeProjet_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("select * from projet where RefProjet = '"+inputCodeProjet.Text+ "'", dataGridView2);
        }

        private void inputNomProjetMaitre_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("select * from projet where ProjetMaitre = '" + inputNomProjetMaitre.Text + "'", dataGridView2);
        }


        private void inputNomProjet_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("select * from projet where NomProjet = '" + inputNomProjet.Text +"'", dataGridView2);
        }

        private void inputDatePublication_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("SELECT * FROM projet, acteprojet WHERE year(acteprojet.DatePubliActe) like '"+inputDatePublication.Text+"%' and acteprojet.RefProjet = projet.RefProjet", dataGridView2);
        }

        private void wilaya_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("select * from projet where Wilaya like '" + wilaya.Text + "%'", dataGridView2);
        }

        private void Daira_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("select * from projet where Daira like '" + Daira.Text + "%'", dataGridView2);
        }

        private void Commune_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("select * from projet where Commune like '" + Commune.Text + "%'", dataGridView2);
        }

        private void Conservation_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("SELECT * FROM projet, acteprojet WHERE acteprojet.Conservation like '" +Conservation.Text + "%' and acteprojet.RefProjet = projet.RefProjet", dataGridView2);
        }

        private void btnimprim1_Click(object sender, RoutedEventArgs e)
        {
            ListeProjetViwer LPV = new ListeProjetViwer(@"select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS DatePubli,DATE_FORMAT(DateRecu,'%d/%m/%y') AS DateR from projet,acteprojet where projet.RefProjet = '" + inputCodeProjet.Text + "' and projet.RefProjet=acteprojet.RefProjet");
            LPV.Show();
        }

        private void Btnimprim2_Click(object sender, RoutedEventArgs e)
        {
            ListeProjetViwer LPV = new ListeProjetViwer(@"select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS DatePubli,DATE_FORMAT(DateRecu,'%d/%m/%y') AS DateR from projet,acteprojet where projet.ProjetMaitre = '" + inputNomProjetMaitre.Text + "' and projet.RefProjet=acteprojet.RefProjet");
            LPV.Show();
        }

        private void Btnimprim3_Click(object sender, RoutedEventArgs e)
        {
            ListeProjetViwer LPV = new ListeProjetViwer(@"select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS DatePubli,DATE_FORMAT(DateRecu,'%d/%m/%y') AS DateR from projet,acteprojet where projet.NomProjet = '" + inputNomProjet.Text + "' and projet.RefProjet=acteprojet.RefProjet");
            LPV.Show();
        }

        private void Btnimprim4_Click(object sender, RoutedEventArgs e)
        {
            ListeProjetViwer LPV = new ListeProjetViwer(@"select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS DatePubli,DATE_FORMAT(DateRecu,'%d/%m/%y') AS DateR from projet,acteprojet where year(acteprojet.DatePubliActe) like '" + inputDatePublication.Text + "%' and projet.RefProjet=acteprojet.RefProjet");
            LPV.Show();
        }

        private void Btnimprim5_Click(object sender, RoutedEventArgs e)
        {
            ListeProjetViwer LPV = new ListeProjetViwer(@"select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS DatePubli,DATE_FORMAT(DateRecu,'%d/%m/%y') AS DateR from projet,acteprojet where projet.Wilaya like '" + wilaya.Text + "%' and projet.RefProjet=acteprojet.RefProjet");
            LPV.Show();
        }

        private void Btnimprim6_Click(object sender, RoutedEventArgs e)
        {
            ListeProjetViwer LPV = new ListeProjetViwer(@"select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS DatePubli,DATE_FORMAT(DateRecu,'%d/%m/%y') AS DateR from projet,acteprojet where projet.Daira like '" + Daira.Text + "%' and projet.RefProjet=acteprojet.RefProjet");
            LPV.Show();
        }

        private void Btnimprim7_Click(object sender, RoutedEventArgs e)
        {
            ListeProjetViwer LPV = new ListeProjetViwer(@"select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS DatePubli,DATE_FORMAT(DateRecu,'%d/%m/%y') AS DateR from projet,acteprojet where projet.Commune like '" + Commune.Text + "%' and projet.RefProjet=acteprojet.RefProjet");
            LPV.Show();
        }

        private void Btnimprim8_Click(object sender, RoutedEventArgs e)
        {
            ListeProjetViwer LPV = new ListeProjetViwer(@"select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS DatePubli,DATE_FORMAT(DateRecu,'%d/%m/%y') AS DateR from projet,acteprojet where acteprojet.Conservation like '" + Conservation.Text + "%' and projet.RefProjet=acteprojet.RefProjet");
            LPV.Show();
        }

        private void inputCodeProjet_GotFocus(object sender, RoutedEventArgs e)
        {
            inputNomProjet.Text = inputNomProjetMaitre.Text = inputCodeProjet.Text = inputDatePublication.Text = wilaya.Text = Daira.Text = Commune.Text = Conservation.Text = string.Empty;
            msh.LoadData("select * from projet", dataGridView2);
        }

        private void Conservation_GotFocus(object sender, RoutedEventArgs e)
        {

        }
    }
}