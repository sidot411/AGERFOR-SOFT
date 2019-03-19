using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;

namespace Agerfor.Views.Attribution
{
    /// <summary>
    /// Interaction logic for Attribution.xaml
    /// </summary>
    public partial class Attribution : Page
    {
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        string query = "";
        string tempNumAttribution = "";
        string tempDateAttribution = "";
        string tempCodeClient = "";
        string tempNumProjet = "";
        string tempNumProgramme = "";
        string tempNumIlot = "";
        string tempNumlot = "";
        string tempTypeBien = "";
        string tempNumBloc = "";
        string tempNumBien = "";
        string tempNatureProgramme = "";
       
        public Attribution(string query)
        {

            InitializeComponent();
            this.query = query;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
             
            msh.LoadData("Select DISTINCT * from client, projet, programme, attribution where attribution.NumClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme", dataGridView2);
         


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
                AddAttribution addat = new AddAttribution(tempNumAttribution,tempDateAttribution,tempCodeClient,tempNumProjet,tempNumProgramme,tempNumIlot,tempNumlot,tempTypeBien,tempNumBloc,tempNumBien,tempNatureProgramme);
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
                AddAttribution addat = new AddAttribution("","","","","","","","","","","");
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

                string querytest = "select * from attribution where NumA='"+tempNumAttribution+"'";
                MySqlDataReader rdrt = null;
                MySqlConnection cont = null;
                MySqlCommand cmdt = null;
                cont = new MySqlConnection(Database.ConnectionString());
                cont.Open();
                cmdt = new MySqlCommand(querytest);
                cmdt.Connection = cont;
                rdrt = cmdt.ExecuteReader();

                while (rdrt.Read())
                {
                    tempNatureProgramme = rdrt["NatureProgramme"].ToString();
                }

                if (tempNatureProgramme == "Logement" || tempNatureProgramme == "Local")
                {

                    string query = "Select DISTINCT * from client, projet, programme, biens, attribution where attribution.NumClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumIlot = biens.NumIlot AND attribution.Numlot = biens.Numlot AND attribution.TypeBien = biens.TypeBien AND attribution.NumBloc = biens.NumBloc AND attribution.NumBien = biens.NumBien AND biens.NumEdd = (SELECT MAX(NumEdd) FROM biens where projet.NomProjet=biens.NomPRojet and programme.RefProgramme) AND NumA='" + tempNumAttribution + "'";

                    MySqlDataReader rdr = null;
                    MySqlConnection con = null;
                    MySqlCommand cmd = null;
                    con = new MySqlConnection(Database.ConnectionString());
                    con.Open();
                    cmd = new MySqlCommand(query);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    bool oneTime = true;
                    while (rdr.Read())
                    {
                        tempDateAttribution = rdr["DateAttribution"].ToString();
                        tempCodeClient = rdr["NumClient"].ToString();
                        tempNumProjet = rdr["NumProjet"].ToString();
                        tempNumProgramme = rdr["NumProgramme"].ToString();
                        tempNumIlot = rdr["NumIlot"].ToString();
                        tempNumlot = rdr["Numlot"].ToString();
                        tempTypeBien = rdr["TypeBien"].ToString();
                        tempNumBloc = rdr["NumBloc"].ToString();
                        tempNumBien = rdr["NumBien"].ToString();
                        tempNatureProgramme = rdr["NatureProgramme"].ToString();
                     

                    }

                }

                else
                {
                    string query = "Select DISTINCT * from client, projet, programme,lot, attribution where attribution.NumClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumIlot = lot.NumIlot AND attribution.Numlot = lot.Numlot  AND lot.NumCC = (SELECT MAX(NumCC) FROM biens where projet.NomProjet=lot.NomPRojet and programme.RefProgramme=lot.RefProgramme) AND NumA='" + tempNumAttribution + "'";

                    MySqlDataReader rdr = null;
                    MySqlConnection con = null;
                    MySqlCommand cmd = null;
                    con = new MySqlConnection(Database.ConnectionString());
                    con.Open();
                    cmd = new MySqlCommand(query);
                    cmd.Connection = con;
                    rdr = cmd.ExecuteReader();
                    bool oneTime = true;
                    while (rdr.Read())
                    {
                        tempDateAttribution = rdr["DateAttribution"].ToString();
                        tempCodeClient = rdr["NumClient"].ToString();
                        tempNumProjet = rdr["NumProjet"].ToString();
                        tempNumProgramme = rdr["NumProgramme"].ToString();
                        tempNumIlot = rdr["NumIlot"].ToString();
                        tempNumlot = rdr["Numlot"].ToString();
                        tempNatureProgramme = rdr["NatureProgramme"].ToString();



                    }
                }
            }
            catch (Exception)
            {

            }
        }

        private void BtnSuppProgramme_Click(object sender, RoutedEventArgs e)
        {
            AttributionController AC = new AttributionController();
            AC.SupprimerAttribution(tempNumAttribution);
            Attribution A = new Attribution("");
            this.NavigationService.Navigate(A);
        }
    }
}
