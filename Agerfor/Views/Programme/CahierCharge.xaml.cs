using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Agerfor.Views.Programme
{
    /// <summary>
    /// Interaction logic for CahierCharge.xaml
    /// </summary>
    public partial class CahierCharge : System.Windows.Controls.UserControl
    {
        CahierChargeProgrammeController CCPC = new CahierChargeProgrammeController();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        string RefProgramme = "";
        string NomProjet = "";
        string tempnumprojet = "";
        string tempNumCahierDeCharge = "";
        public CahierCharge(string NomProjet, string refprogramme)
        {
            InitializeComponent();
            title.Text = "Cahier de charge";
            this.RefProgramme = refprogramme;
            this.NomProjet = NomProjet;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)

        {
           
            msh.LoadData("select * from cahierchargeprogramme where RefProgramme='"+RefProgramme+"' and NomProjet='"+NomProjet+"'", dataViewCahierCharge);
        }

        private void BtnAjouterCC_Click(object sender, RoutedEventArgs e)
        {
            string CC = "Cahier des charges";
            getrefprojet();
            DirectoryCreator DC = new DirectoryCreator();
            DC.CreateDirectoryProgramme(tempnumprojet, RefProgramme + "/" + CC + "/" + inputNumCahierCharge.Text);
            CCPC.AjouterCahierCharge(NomProjet,RefProgramme,inputNumCahierCharge.Text,inputDateEnreg.Text,inputVolume.Text,inputNumPubli.Text,inputDatePubli.Text,inputConservation.Text,inputNotaire.Text,inputTelNotaire.Text,inputAdresseNotaire.Text,decimal.Parse(inputSuperficieCessible.Text),decimal.Parse(inputSuperficieVoirie.Text),decimal.Parse(inputSuperficieEv.Text),decimal.Parse(inputSuperficieEq.Text),decimal.Parse(inputAutreSuperficie.Text),inputNomGeo.Text,inputAddressGeo.Text,inputTelGeo.Text);
            msh.LoadData("select * from cahierchargeprogramme where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'", dataViewCahierCharge);
        }

        private void dataViewCahierCharge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewCahierCharge.SelectedCells[0];
            tempNumCahierDeCharge = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;

            string query = "select * from cahierchargeprogramme where NumCahierCharge =" + tempNumCahierDeCharge;
            MySqlDataReader rdr = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;

            con = new MySqlConnection(Database.ConnectionString);
            con.Open();
            cmd = new MySqlCommand(query);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            bool oneTime = true;
            while (rdr.Read())
            {

                if (oneTime)
                {
                    inputNumCahierCharge.Text = rdr["NumCahierCharge"].ToString();
                    inputDateEnreg.Text = rdr["DateEnre"].ToString();
                    inputVolume.Text = rdr["Volume"].ToString();
                    inputNumPubli.Text = rdr["NumPubli"].ToString();
                    inputDatePubli.Text = rdr["DatePubli"].ToString();
                    inputConservation.Text = rdr["Conservation"].ToString();
                    inputNotaire.Text = rdr["Notaire"].ToString();
                    inputTelNotaire.Text = rdr["TelNotaire"].ToString();
                    inputAdresseNotaire.Text = rdr["AdresseNotaire"].ToString();
                    inputSuperficieCessible.Text = rdr["SuperficieCessible"].ToString();
                    inputSuperficieVoirie.Text = rdr["SuperficieVoirie"].ToString();
                    inputSuperficieEv.Text = rdr["SuperficieEv"].ToString();
                    inputSuperficieEq.Text = rdr["SuperficieEq"].ToString();
                    inputAutreSuperficie.Text = rdr["AutreSuperficie"].ToString();
                    inputNomGeo.Text = rdr["NomPreomGeo"].ToString();
                    inputAddressGeo.Text = rdr["AdresseGeo"].ToString();
                    inputTelGeo.Text = rdr["TelGeo"].ToString();


                    oneTime = false;
                }
            }
        }

        private void BtnModifierCC_Click(object sender, RoutedEventArgs e)
        {
            CCPC.ModifierCahierCharge(NomProjet, RefProgramme, inputNumCahierCharge.Text, inputDateEnreg.Text,inputVolume.Text, inputNumPubli.Text, inputDatePubli.Text, inputConservation.Text, inputNotaire.Text, inputTelNotaire.Text, inputAdresseNotaire.Text, decimal.Parse(inputSuperficieCessible.Text), decimal.Parse(inputSuperficieVoirie.Text), decimal.Parse(inputSuperficieEv.Text), decimal.Parse(inputSuperficieEq.Text), decimal.Parse(inputAutreSuperficie.Text), inputNomGeo.Text, inputAddressGeo.Text, inputTelGeo.Text, tempNumCahierDeCharge);
            msh.LoadData("select * from cahierchargeprogramme where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'", dataViewCahierCharge);
        }

        private void BtnSupprimerCC_Click(object sender, RoutedEventArgs e)
        {
            DirectoryCreator DC = new DirectoryCreator();
            DC.DeleteDirectory(@"Projet\" + tempnumprojet + @"\Programme\" + RefProgramme + @"\Cahier des charges\" + tempNumCahierDeCharge);
            CCPC.SupprimerCahierCharge(tempNumCahierDeCharge);
            msh.LoadData("select * from cahierchargeprogramme where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'", dataViewCahierCharge);
        }
        //Référence Projet//
        private void getrefprojet()
        {
            string query2 = "select RefProjet from projet where NomProjet ='" +NomProjet + "'";
            MySqlDataReader rdr2 = null;
            MySqlConnection con2 = null;
            MySqlCommand cmd2 = null;

            con2 = new MySqlConnection(Database.ConnectionString);
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

        private void BtnOuvrirCC_Click(object sender, RoutedEventArgs e)
        {
            getrefprojet();
            string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + RefProgramme + @"\Cahier des charges\" + inputNumCahierCharge.Text;

            OpenFolder(folderPath);
        }

        private void OpenFolder(string folderPath)
        {
            if (Directory.Exists(folderPath))
            {
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
            else
            {
                DirectoryCreator dcr = new DirectoryCreator();
                dcr.CreateDirectoryProgramme(tempnumprojet, RefProgramme + "/");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        }

        private void BtnJoindreCC_Click(object sender, RoutedEventArgs e)
        {
            SelectFile("Document Cahier des charges");
        }

        public void SelectFile(string theDirectory)
        {
            getrefprojet();
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + RefProgramme + @"\Cahier des charges\" + inputNumCahierCharge.Text + @"\" + theDirectory + @"\" + System.IO.Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectoryPermisDeConstruire(tempnumprojet, RefProgramme, inputNumCahierCharge.Text+ "/" + theDirectory);
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolder))
                {
                    File.Delete(destinationFolder);
                }

                File.Copy(fileName, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(fileName), destinationFolder));
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionner");
            }
        }
    }

}
