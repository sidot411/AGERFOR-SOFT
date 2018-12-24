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
    /// Interaction logic for Conservation.xaml
    /// </summary>
    public partial class Convention : System.Windows.Controls.UserControl
    {
        ConventionController CC = new ConventionController();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        string RefProgramme = "";
        string NomProjet = "";
        string tempnumprojet = "";
        string tempNumDec = "";
        public Convention(string NomProjet, string refprogramme)
        {
            InitializeComponent();
            title.Text = "Convention";
            this.RefProgramme = refprogramme;
            this.NomProjet = NomProjet;

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)

        {
            msh.LoadData("select * from Convention where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'", dataViewConvention);

        }

        private void dataViewConvention_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewConvention.SelectedCells[0];
            tempNumDec = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
            string query = "select * from Convention where NumDec =" + tempNumDec;
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
                    inputNumDC.Text = rdr["NumDec"].ToString();
                    inputDateDC.Text = rdr["DateDec"].ToString();
                    inputNumAW.Text = rdr["NumAW"].ToString();
                    inputDateAW.Text = rdr["DateAW"].ToString();
                    inputDateConv.Text = rdr["DateConv"].ToString();
                    inputNatureA.Text = rdr["NatureA"].ToString();
                    inputSupT.Text = rdr["SupT"].ToString();
                    inputPrix.Text = rdr["PrixU"].ToString();
                    inputMajoration.Text = rdr["Majoration"].ToString();


                    oneTime = false;
                }
            }
        }
        private void getrefprojet()
        {
            string query2 = "select RefProjet from projet where NomProjet ='" + NomProjet + "'";
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
        private void BtnAjouter_Click(object sender, RoutedEventArgs e)
        {
            string Conv = "Convention";
            getrefprojet();
            DirectoryCreator DC = new DirectoryCreator();
            DC.CreateDirectoryProgramme(tempnumprojet, RefProgramme + "/" + Conv + "/" +inputNumDC.Text);
            CC.AjouterConvention(NomProjet,RefProgramme,inputNumDC.Text, inputDateDC.Text, inputNumAW.Text, inputDateAW.Text, inputDateConv.Text, inputNatureA.Text, decimal.Parse(inputSupT.Text), decimal.Parse(inputPrix.Text), inputMajoration.Text);
            inputNumDC.Text = inputDateDC.Text = inputNumAW.Text = inputDateAW.Text = inputDateConv.Text = inputNatureA.Text = inputMajoration.Text = "";
            inputSupT.Text = inputPrix.Text ="0";
            msh.LoadData("select * from Convention where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'", dataViewConvention);

        }

        private void BtnModifier_Click(object sender, RoutedEventArgs e)
        {
            CC.ModifierConvention(NomProjet, RefProgramme, inputNumDC.Text, inputDateDC.Text, inputNumAW.Text, inputDateAW.Text, inputDateConv.Text, inputNatureA.Text, decimal.Parse(inputSupT.Text), decimal.Parse(inputPrix.Text), inputMajoration.Text,tempNumDec);
            msh.LoadData("select * from Convention where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'", dataViewConvention);
            inputNumDC.Text = inputDateDC.Text = inputNumAW.Text = inputDateAW.Text = inputDateConv.Text = inputNatureA.Text = inputMajoration.Text = "";
            inputSupT.Text = inputPrix.Text = "0";
            
        }

        private void BtnSupprimer_Click(object sender, RoutedEventArgs e)
        {
            DirectoryCreator DC = new DirectoryCreator();
            DC.DeleteDirectory(@"Projet\" + tempnumprojet + @"\Programme\" + RefProgramme + @"\Convention\" + tempNumDec);
            CC.SupprimerConvention(inputNumDC.Text);
            msh.LoadData("select * from Convention where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'", dataViewConvention);
            inputNumDC.Text = inputDateDC.Text = inputNumAW.Text = inputDateAW.Text = inputDateConv.Text = inputNatureA.Text = inputMajoration.Text = "";
            inputSupT.Text = inputPrix.Text = "0";
        }

        private void Ouvrir_Click(object sender, RoutedEventArgs e)
        {
            getrefprojet();
            string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + RefProgramme + @"\Convention\" + inputNumDC.Text;
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

        private void Joindre_Click(object sender, RoutedEventArgs e)
        {
            SelectFile("Document Convention");
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
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + RefProgramme + @"\Convention\" + inputNumDC.Text + @"\" + theDirectory + @"\" + System.IO.Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectoryConvention(tempnumprojet, RefProgramme, inputNumDC.Text + "/" + theDirectory);
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
