using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Windows.Navigation;
using System;
using MaterialDesignThemes.Wpf;
using System.IO;
using System.Diagnostics;
using Agerfor.OVReporting;
using Agerfor.Controlers;


namespace Agerfor.Views.Clients
{
    /// <summary>
    /// Interaction logic for SoldeOV.xaml
    /// </summary>
    public partial class SoldeOV : UserControl
    {
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        OvSoldeController OVS = new OvSoldeController();
        int CodeClient;
        string tempNumOV;
        public SoldeOV(int CodeClient)
        {
            InitializeComponent();
            inputCodeClient.IsEnabled = inputNumOV.IsEnabled = inputDateRecu.IsEnabled = inputDateRecu.IsEnabled = inputNumRecu.IsEnabled = inputEtat.IsEnabled = false;
            this.CodeClient = CodeClient;
            inputCodeClient.Text = CodeClient.ToString();
            msh.LoadData("select * from ovsolde where CodeClient='" + inputCodeClient.Text + "'", dataViewOVSolde);
            msh.FillDropDownList("select NomProgramme from programme",inputNomProgramme,"NomProgramme");

            string query = "select SUM(Montant) AS SOLDE from ovsolde where CodeClient='" + inputCodeClient.Text + "' and EtatOvSolde='Terminé'";
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
                inputSolde.Text = rdr["SOLDE"].ToString();
            }
        }

        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
          
            OVS.AjouterOvSolde(inputDateVersement.Text, int.Parse(inputCodeClient.Text), inputDateEcheance.Text, inputNomProgramme.Text, decimal.Parse(inputMontant.Text), inputEtat.Text, inputDateRecu.Text, inputNumRecu.Text);
            inputDateVersement.Text = System.DateTime.Now.ToString();
            inputNumOV.Text = inputDateEcheance.Text = inputNomProgramme.Text = inputMontant.Text = inputDateRecu.Text = inputNumRecu.Text = string.Empty;
            msh.LoadData("select * from ovsolde where CodeClient='" + inputCodeClient.Text + "'", dataViewOVSolde);
        }
        private void dataViewOVSolde_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewOVSolde.SelectedCells[0];
            tempNumOV = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;

            string query = "select * from ovsolde where IdOvSolde='" + tempNumOV + "'";
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
                inputCodeClient.Text = rdr["CodeClient"].ToString();
                inputNumOV.Text = rdr["IdOvSolde"].ToString();
                inputDateVersement.Text = rdr["DateOvSolde"].ToString();
                inputDateEcheance.Text = rdr["DateEchOvSolde"].ToString();
                inputNomProgramme.Text = rdr["NomProgramme"].ToString();
                inputMontant.Text = rdr["Montant"].ToString();
                inputEtat.Text = rdr["EtatOvSolde"].ToString();
                inputDateRecu.Text = rdr["DateRecu"].ToString();
                inputNumRecu.Text = rdr["NumRecu"].ToString();
            }

            if(inputEtat.Text=="En Cours")
            {
                inputCodeClient.IsEnabled = inputNumOV.IsEnabled = inputDateRecu.IsEnabled = inputDateRecu.IsEnabled = inputNumRecu.IsEnabled = inputEtat.IsEnabled = true;
            }
            else
            {
                inputCodeClient.IsEnabled = inputNumOV.IsEnabled = inputDateRecu.IsEnabled = inputDateRecu.IsEnabled = inputNumRecu.IsEnabled = inputEtat.IsEnabled = false;
                BtnAjouter.IsEnabled = BtnModifier.IsEnabled = BtnAnnuler.IsEnabled = false;
            }

        }
        private void BtnModifier_Click(object sender, RoutedEventArgs e)
        {
            if (inputDateRecu.Text != "" && inputNumRecu.Text != "")
            {
                OVS.validerOvSolde(inputDateRecu.Text, inputNumRecu.Text, "Terminé");
                inputDateVersement.Text = System.DateTime.Now.ToString();
                inputNumOV.Text = inputDateEcheance.Text = inputNomProgramme.Text = inputMontant.Text = inputDateRecu.Text = inputNumRecu.Text = string.Empty;
                msh.LoadData("select * from ovsolde where CodeClient='" + inputCodeClient.Text + "'", dataViewOVSolde);
                string query = "select SUM(Montant) AS SOLDE from ovsolde where CodeClient='" + inputCodeClient.Text + "' and EtatOvSolde='Terminé'";
                MessageBox.Show(inputCodeClient.Text);
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
                    inputSolde.Text = rdr["SOLDE"].ToString();
                }
            }
            else
            {
                MessageBox.Show("Veuillez remplire la date et le num de reçu de payement");
            }
        }

        private void Btnvider_Click(object sender, RoutedEventArgs e)
        {
            inputDateVersement.Text = System.DateTime.Now.ToString();
            inputNumOV.Text = inputDateEcheance.Text = inputNomProgramme.Text = inputMontant.Text = inputDateRecu.Text = inputNumRecu.Text = string.Empty;
            inputCodeClient.IsEnabled = inputNumOV.IsEnabled = inputDateRecu.IsEnabled = inputDateRecu.IsEnabled = inputNumRecu.IsEnabled = inputEtat.IsEnabled = false;
            inputEtat.Text = "En cours";
            BtnAjouter.IsEnabled = BtnModifier.IsEnabled = BtnAnnuler.IsEnabled = false;
            msh.LoadData("select * from ovsolde where CodeClient='" + inputCodeClient.Text + "'", dataViewOVSolde);
            
            
        }
    }
}
