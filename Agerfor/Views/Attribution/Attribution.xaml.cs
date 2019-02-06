using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;

namespace Agerfor.Views.Attribution
{
    /// <summary>
    /// Interaction logic for Attribution.xaml
    /// </summary>
    public partial class Attribution : Page
    {
        MySqlHelper msh = new MySqlHelper();
        string query = "";
        string tempNumAttribution = "";
        public Attribution(string query)
        {
            InitializeComponent();
            this.query = query;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

            msh.LoadData("Select DISTINCT * from client, projet, programme, biens, attribution where attribution.NumClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumIlot = biens.NumIlot AND attribution.Numlot = biens.Numlot AND attribution.TypeBien = biens.TypeBien AND attribution.NumBloc = biens.NumBloc AND attribution.NumBien = biens.NumBien AND biens.NumEdd = (SELECT MAX(NumEdd) FROM biens where projet.NomProjet=biens.NomPRojet and programme.RefProgramme)", dataGridView2);


        }

        private void IdClient_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("Select * from client,projet,programme,biens,attribution where CodeClient like '" + IdClient.Text + "%' and attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);
        }



        private void Nom_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("Select * from client,projet,programme,biens,attribution where Nom like '" + inputNom.Text + "%'  and attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }



        private void CNI_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("Select * from client,projet,programme,biens,attribution where Cni like '" + inputCNI.Text + "%'  and attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void inputDateNaissance_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

            msh.LoadData("Select * from client,projet,programme,biens,attribution where DateNaissance like '" + inputDateNaissance.Text + "%'  and attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void inputDateNaissance_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("Select * from client,projet,programme,biens,attribution where DateNaissance like '" + inputDateNaissance.Text + "%'  and attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);


        }

        private void inputNomProjet_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

            msh.LoadData("Select * from client,projet,programme,biens,attribution where projet.NomProjet like '" + inputNomProjet.Text + "%'  and attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void inputNumProgramme_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("Select * from client,projet,programme,biens,attribution where programme.RefProgramme like '" + inputNumProgramme.Text + "%'  and attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void inputnumbien_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("Select * from client,projet,programme,biens,attribution where Biens.NumBien like '" + inputnumbien.Text + "%'  and attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }


        private void inputDateAttri_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            msh.LoadData("Select * from client,projet,programme,biens,attribution where DateAttribution like '" + inputDateAttri.Text + "%'  and attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void inputDateAttri_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            msh.LoadData("Select * from client,projet,programme,biens,attribution where DateAttribution like '" + inputDateAttri.Text + "%'  and attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void IdClient_GotFocus(object sender, RoutedEventArgs e)
        {
            IdClient.Text = inputNom.Text = inputCNI.Text = inputDateNaissance.Text = inputNomProjet.Text = inputNumProgramme.Text = inputnumbien.Text = inputDateAttri.Text = string.Empty;
            msh.LoadData("Select * from client,projet,programme,biens,attribution where attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void inputNom_GotFocus(object sender, RoutedEventArgs e)
        {
            IdClient.Text = inputNom.Text = inputCNI.Text = inputDateNaissance.Text = inputNomProjet.Text = inputNumProgramme.Text = inputnumbien.Text = inputDateAttri.Text = string.Empty;
            msh.LoadData("Select * from client,projet,programme,biens,attribution where attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void inputCNI_GotFocus(object sender, RoutedEventArgs e)
        {
            IdClient.Text = inputNom.Text = inputCNI.Text = inputDateNaissance.Text = inputNomProjet.Text = inputNumProgramme.Text = inputnumbien.Text = inputDateAttri.Text = string.Empty;
            msh.LoadData("Select * from client,projet,programme,biens,attribution where attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void inputDateNaissance_GotFocus(object sender, RoutedEventArgs e)
        {
            IdClient.Text = inputNom.Text = inputCNI.Text = inputDateNaissance.Text = inputNomProjet.Text = inputNumProgramme.Text = inputnumbien.Text = inputDateAttri.Text = string.Empty;
            msh.LoadData("Select * from client,projet,programme,biens,attribution where attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void inputNomProjet_GotFocus(object sender, RoutedEventArgs e)
        {
            IdClient.Text = inputNom.Text = inputCNI.Text = inputDateNaissance.Text = inputNomProjet.Text = inputNumProgramme.Text = inputnumbien.Text = inputDateAttri.Text = string.Empty;
            msh.LoadData("Select * from client,projet,programme,biens,attribution where attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void inputNumProgramme_GotFocus(object sender, RoutedEventArgs e)
        {
            IdClient.Text = inputNom.Text = inputCNI.Text = inputDateNaissance.Text = inputNomProjet.Text = inputNumProgramme.Text = inputnumbien.Text = inputDateAttri.Text = string.Empty;
            msh.LoadData("Select * from client,projet,programme,biens,attribution where attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void inputnumbien_GotFocus(object sender, RoutedEventArgs e)
        {
            IdClient.Text = inputNom.Text = inputCNI.Text = inputDateNaissance.Text = inputNomProjet.Text = inputNumProgramme.Text = inputnumbien.Text = inputDateAttri.Text = string.Empty;
            msh.LoadData("Select * from client,projet,programme,biens,attribution where attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void inputDateAttri_GotFocus(object sender, RoutedEventArgs e)
        {
            IdClient.Text = inputNom.Text = inputCNI.Text = inputDateNaissance.Text = inputNomProjet.Text = inputNumProgramme.Text = inputnumbien.Text = inputDateAttri.Text = string.Empty;
            msh.LoadData("Select * from client,projet,programme,biens,attribution where attribution.CodeClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumBien = biens.NumBien", dataGridView2);

        }

        private void BtnAfficherAttribution_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddAttribution addat = new AddAttribution(tempNumAttribution);
                this.NavigationService.Navigate(addat);
            }
            catch (Exception)
            {

            }
        }

        private void BtnAjouterAttribution_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddAttribution addat = new AddAttribution(tempNumAttribution);
                this.NavigationService.Navigate(addat);
            }
            catch (Exception)
            {

            }
        }

        private void dataGridView2_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                DataGridCellInfo cell0 = dataGridView2.SelectedCells[0];
                tempNumAttribution = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
            }
            catch(Exception)
            {

            }
        }
    }
}
