using Agerfor.Controlers;
using DbConnection.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Agerfor.Views.Projet
{
    /// <summary>
    /// Interaction logic for PermisLotir.xaml
    /// </summary>
    public partial class PermisLotir : System.Windows.Controls.UserControl
    {
        string tempNumPL = "";
        PermiLotirController PLC = new PermiLotirController();
        int RefProjet;
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public PermisLotir(int RefProjet)
        {
            InitializeComponent();
            this.RefProjet = RefProjet;
            msh.LoadData("select * from permilotir where 	RefProjet='" + RefProjet + "'", DataGridPLotir);
            inputSuperficieGlobal.Text = inputSuperficieVoiries.Text = inputSuperficieEspaceVert.Text = inputSuperficieEquipements.Text = inputSuperficieAmenagement.Text = inputAutresSuperficie.Text = "0";
            string query3 = "select MAX(NumPL)+1 AS Num2 from permilotir;";
            MySqlDataReader rdr3 = null;
            MySqlConnection con3 = null;
            MySqlCommand cmd3 = null;
            con3 = new MySqlConnection(Database.ConnectionString());
            con3.Open();
            cmd3 = new MySqlCommand(query3);
            cmd3.Connection = con3;
            rdr3 = cmd3.ExecuteReader();
            bool oneTime3 = true;
            while (rdr3.Read())
            {
                if (rdr3["Num2"].ToString() == "")
                {
                    inputNumLotir.Text = "1";
                }
                else
                {
                    inputNumLotir.Text = rdr3["Num2"].ToString();
                }

            }
            inputNumLotir.IsEnabled = false;
        }

        private void BtnAjouterPLotir_Click(object sender, RoutedEventArgs e)
        {
            if (inputNumLotir.Text != "")
            {
                string PermisLotir = "PermisLotir";
                DirectoryCreator DC = new DirectoryCreator();
                DC.CreateDirectory(RefProjet.ToString() + "/" + PermisLotir + "/" + inputNumLotir.Text);
                PLC.AjouterPL(inputDatePLotir.Text, inputNbrIlot.Text, inputNbrLots.Text,decimal.Parse(inputSurfaceBrut.Text),  decimal.Parse(inputSuperficieGlobal.Text), decimal.Parse(inputSuperficieVoiries.Text), decimal.Parse(inputSuperficieEspaceVert.Text), decimal.Parse(inputSuperficieEquipements.Text), decimal.Parse(inputSuperficieAmenagement.Text), decimal.Parse(inputAutresSuperficie.Text),RefProjet);
                msh.LoadData("select * from permilotir where 	RefProjet='" + RefProjet + "'", DataGridPLotir);
                inputNumLotir.Text = inputDatePLotir.Text = inputNbrLots.Text = inputNbrIlot.Text = "";
          
                inputSuperficieGlobal.Text = inputSuperficieVoiries.Text = inputSuperficieEspaceVert.Text = inputSuperficieEquipements.Text = inputSuperficieAmenagement.Text = inputAutresSuperficie.Text = "0";
                string query3 = "select MAX(NumPL)+1 AS Num2 from permilotir;";
                MySqlDataReader rdr3 = null;
                MySqlConnection con3 = null;
                MySqlCommand cmd3 = null;
                con3 = new MySqlConnection(Database.ConnectionString());
                con3.Open();
                cmd3 = new MySqlCommand(query3);
                cmd3.Connection = con3;
                rdr3 = cmd3.ExecuteReader();
                bool oneTime3 = true;
                while (rdr3.Read())
                {
                    if (rdr3["Num2"].ToString() == "")
                    {
                        inputNumLotir.Text = "1";
                    }
                    else
                    {
                        inputNumLotir.Text = rdr3["Num2"].ToString();
                    }

                }
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez remplir tous les champs pour ajouter un permi de lotir", "Permi lotir programme", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnModifierPLotir_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumPL == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Permis de lotir pour le modifié", "Permis lotir", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                PLC.EditerPL(inputDatePLotir.Text, inputNbrIlot.Text, inputNbrLots.Text, decimal.Parse(inputSurfaceBrut.Text), decimal.Parse(inputSuperficieGlobal.Text), decimal.Parse(inputSuperficieVoiries.Text), decimal.Parse(inputSuperficieEspaceVert.Text), decimal.Parse(inputSuperficieEquipements.Text), decimal.Parse(inputSuperficieAmenagement.Text), decimal.Parse(inputAutresSuperficie.Text),RefProjet, tempNumPL);
                msh.LoadData("select * from permilotir where 	RefProjet='" + RefProjet + "'", DataGridPLotir);
                inputNumLotir.Text = inputDatePLotir.Text = inputNbrLots.Text = inputNbrIlot.Text = "";
         
                inputSuperficieGlobal.Text = inputSuperficieVoiries.Text = inputSuperficieEspaceVert.Text = inputSuperficieEquipements.Text = inputSuperficieAmenagement.Text = inputAutresSuperficie.Text = "0";
                string query3 = "select MAX(NumPL)+1 AS Num2 from permilotir;";
                MySqlDataReader rdr3 = null;
                MySqlConnection con3 = null;
                MySqlCommand cmd3 = null;
                con3 = new MySqlConnection(Database.ConnectionString());
                con3.Open();
                cmd3 = new MySqlCommand(query3);
                cmd3.Connection = con3;
                rdr3 = cmd3.ExecuteReader();
                bool oneTime3 = true;
                while (rdr3.Read())
                {
                    if (rdr3["Num2"].ToString() == "")
                    {
                        inputNumLotir.Text = "1";
                    }
                    else
                    {
                        inputNumLotir.Text = rdr3["Num2"].ToString();
                    }

                }
            }
        }

        private void DataGridPLotir_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = DataGridPLotir.SelectedCells[0];
            tempNumPL = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;

            string query = "select * from permilotir where NumPL =" + tempNumPL;
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

                if (oneTime)
                {
                    inputNumLotir.Text = rdr["NumPL"].ToString();
                    inputDatePLotir.Text = rdr["DatePL"].ToString();
             
                    inputNbrIlot.Text = rdr["NbrIlot"].ToString();
                    inputNbrLots.Text = rdr["NbrLots"].ToString();
                    inputSuperficieGlobal.Text = rdr["SuperficieCG"].ToString();
                    inputSuperficieVoiries.Text = rdr["SuperficieVoiries"].ToString();
                    inputSuperficieEspaceVert.Text = rdr["SuperficieEV"].ToString();
                    inputSuperficieEquipements.Text = rdr["SuperficieEquip"].ToString();
                    inputSuperficieAmenagement.Text = rdr["SuperficieAmenag"].ToString();
                    inputAutresSuperficie.Text = rdr["AutreSupercie"].ToString();
                    oneTime = false;
                }
            }
        }

        private void BtnRestor_Click(object sender, RoutedEventArgs e)
        {
            msh.LoadData("select * from permilotir where 	RefProjet='" + RefProjet + "'", DataGridPLotir);
            inputNumLotir.Text = inputDatePLotir.Text = inputNbrLots.Text = inputNbrIlot.Text = "";

            inputSuperficieGlobal.Text = inputSuperficieVoiries.Text = inputSuperficieEspaceVert.Text = inputSuperficieEquipements.Text = inputSuperficieAmenagement.Text = inputAutresSuperficie.Text = "0";
            string query3 = "select MAX(NumPL)+1 AS Num2 from permilotir;";
            MySqlDataReader rdr3 = null;
            MySqlConnection con3 = null;
            MySqlCommand cmd3 = null;
            con3 = new MySqlConnection(Database.ConnectionString());
            con3.Open();
            cmd3 = new MySqlCommand(query3);
            cmd3.Connection = con3;
            rdr3 = cmd3.ExecuteReader();
            bool oneTime3 = true;
            while (rdr3.Read())
            {
                if (rdr3["Num2"].ToString() == "")
                {
                    inputNumLotir.Text = "1";
                }
                else
                {
                    inputNumLotir.Text = rdr3["Num2"].ToString();
                }

            }
        }

        private void BtnSupprimerPLotir_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumPL == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Permis de lotir pour le supprimé", "Permis lotir", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                DirectoryCreator DC = new DirectoryCreator();
                DC.DeleteDirectory(@"Projet\" + RefProjet.ToString() + @"\PermisLotir\" + inputNumLotir.Text);
                PLC.SupprimerPL(tempNumPL);
                msh.LoadData("select * from permilotir where 	RefProjet='" + RefProjet + "'", DataGridPLotir);
                inputNumLotir.Text = inputDatePLotir.Text = inputNbrIlot.Text = inputNbrLots.Text = "";
                inputSuperficieGlobal.Text = inputSuperficieVoiries.Text = inputSuperficieEspaceVert.Text = inputSuperficieEquipements.Text = inputSuperficieAmenagement.Text = inputAutresSuperficie.Text = "0";
         
            }
        }

        private void BtnOuvrirPLotir_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumPL == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Permis de lotir pour ouvrir le dossier", "Permis lotir", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                
                string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + RefProjet.ToString() + @"\PermisLotir\" + inputNumLotir.Text;

                OpenFolder(folderPath);
            }
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
                dcr.CreateDirectory(RefProjet.ToString() + "/");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        }

        private void BtnJoindrePLotir_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumPL == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Permis de lotir pour joindre des fichies", "Permis lotir", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                SelectFile3("Document Permis lotir");
            }
        }

        public void SelectFile3(string theDirectory)
        {
            
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + RefProjet.ToString() + @"\PermisLotir\" + inputNumLotir.Text + @"\" + theDirectory + @"\" + System.IO.Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectoryPermisLotir(RefProjet.ToString(), inputNumLotir.Text + "/" + theDirectory);
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolder))
                {
                    File.Delete(destinationFolder);
                }

                File.Copy(fileName, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(fileName), destinationFolder));
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionné");
            }
        }
    }
    }

