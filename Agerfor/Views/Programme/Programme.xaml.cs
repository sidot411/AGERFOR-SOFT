using System;
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
        string tempNomProgramme = "";
        string tempNomProjet = "";
        string tempRefProjet = "";
        string tempnumprojet = "";
        string query = "";
        
        public Programme(string query)
        {
            InitializeComponent();
            msh.FillDropDownList("select NomDaira from daira", Daira, "NomDaira");
            msh.FillDropDownList("select * from natureprogramme", Natureprogramme, "NatureProgramme");
            this.query = query;
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (query == "")
            {
                msh.LoadData("select * from programme,projet where programme.RefProjet=projet.RefProjet", dataGridView2);
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
            tempNomProgramme = ((TextBlock)cell1.Column.GetCellContent(cell1.Item)).Text;
            DataGridCellInfo cell2 = dataGridView2.SelectedCells[2];
            tempRefProjet  = ((TextBlock)cell2.Column.GetCellContent(cell2.Item)).Text;
             
        

    }
    private void BtnAfficherProgramme_Click(object sender, RoutedEventArgs e)
        {
            if (temprefprogramme != "")
            {
                AddProgramme AP = new AddProgramme(int.Parse(temprefprogramme));
                AP.GridProgramme.IsEnabled = false;
                NavigationService.Navigate(AP);
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez selectioner un programme");
            }

        }
        private void BtnAjouterProgramme_Click(object sender, RoutedEventArgs e)
        {
            AddProgramme AP = new AddProgramme(0); 
            NavigationService.Navigate(AP);
        }

        private void BtnModifierProgramme_Click(object sender, RoutedEventArgs e)
        {
            AddProgramme AP = new AddProgramme(int.Parse(temprefprogramme));
            AP.BtnAjouterProgramme.IsEnabled = false;
            NavigationService.Navigate(AP);
        }

        private void BtnSuppProgramme_Click(object sender, RoutedEventArgs e)
        {
            if (temprefprogramme !="")
            {
                System.Windows.MessageBox.Show("Note: Lors de la supression d'un programme tous les élements qui appartienent au programme à savoir(Acte,Permis de lotir, permis de construire, Cahier des charges, Edd,Convention, et documents) seront automatiquement supprimé !", "Information", MessageBoxButton.OK, MessageBoxImage.Warning);
                if (System.Windows.MessageBox.Show("Voulez-vous supprimer ce projet?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {

                    Programme P = new Programme("");
                    NavigationService.Navigate(P);
                }
                else
                {
                 
                    
                    ProgrammeController PC = new ProgrammeController();
                    DirectoryCreator DC = new DirectoryCreator();
                    PermisDeConstruireController PDCC = new PermisDeConstruireController();
                    CahierChargeProgrammeController CCPC = new CahierChargeProgrammeController();
                    EddController EC = new EddController();
                    ConventionController CC = new ConventionController();
                    BiensController BC = new BiensController();
                    DC.DeleteDirectory(@"Projet\" + tempRefProjet + @"\Programme\" + temprefprogramme);
                    BC.SupprimerLogFromProgramme(int.Parse(temprefprogramme),int.Parse(tempRefProjet));  
                    PDCC.SupprimerPermisConstruireFromProgramme(temprefprogramme);
                    CCPC.SupprimerCahierChargefromProgramme(temprefprogramme);
                    EC.SupprimerEddFromProgramme(temprefprogramme);
                    CC.SupprimerConventionFromProgramme(temprefprogramme);
                    PC.DeleteProgramme(int.Parse(temprefprogramme));
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

            con2 = new MySqlConnection(Database.ConnectionString());
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




        private void Daira_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Commune.Items.Clear();
            msh.FillDropDownList("select NomCommune from commune,daira where NomDaira='" + Daira.SelectedItem.ToString() + "'and daira.IdDaira=commune.IdDaira", Commune, "NomCommune");
            SearchProgramme SP = new SearchProgramme();
            msh.LoadData(SP.AdvencedSearchGetQuery(inputRefProjet, inputNomProjet, inputRefProgramme, inputNomProgramme, Daira, Commune, Natureprogramme, Typeprogramme), dataGridView2);

        }

        private void Natureprogramme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Typeprogramme.Items.Clear();
            msh.FillDropDownList("select TypeProgramme from typeprogramme where typeprogramme.NatureProgramme='" + Natureprogramme.SelectedValue.ToString() + "'", Typeprogramme, "TypeProgramme");
            SearchProgramme SP = new SearchProgramme();
            msh.LoadData(SP.AdvencedSearchGetQuery(inputRefProjet, inputNomProjet, inputRefProgramme, inputNomProgramme, Daira, Commune, Natureprogramme, Typeprogramme), dataGridView2);

        }

        private void inputRefProjet_TextChanged(object sender, TextChangedEventArgs e)
        {
            SearchProgramme SP = new SearchProgramme();
            msh.LoadData(SP.AdvencedSearchGetQuery(inputRefProjet, inputNomProjet, inputRefProgramme, inputNomProgramme, Daira, Commune, Natureprogramme, Typeprogramme), dataGridView2);

        }

        private void Commune_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            SearchProgramme SP = new SearchProgramme();
            msh.LoadData(SP.AdvencedSearchGetQuery(inputRefProjet, inputNomProjet, inputRefProgramme, inputNomProgramme, Daira, Commune, Natureprogramme, Typeprogramme), dataGridView2);
        }
    }
}
