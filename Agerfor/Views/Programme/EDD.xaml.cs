using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using MaterialDesignThemes.Wpf;
using System.Windows.Media.Imaging;
using System.Data;

namespace Agerfor.Views.Programme
{
    /// <summary>
    /// Interaction logic for EDD.xaml
    /// </summary>
    public partial class EDD : System.Windows.Controls.UserControl
    {
        EddController EC = new EddController();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        string RefProgramme = "";
        int RefProjet = 0;
        string tempnumprojet = "";
        string tempNumEdd = "";
        string tempPrevNumEDD = "";
        string TypeProgramme;
        string typevente;
        decimal coutFoncier;
        decimal Prixm2;
        
        public EDD(int RefProjet, string refprogramme,string TypeProgramme,string typevente, decimal Coufoncier,decimal Prixm2)
        {
            InitializeComponent();
            title.Text = "EDD";
            this.Prixm2 = Prixm2;
            this.coutFoncier = Coufoncier;
            this.typevente = typevente;
            this.TypeProgramme = TypeProgramme;
            this.RefProgramme = refprogramme;
            this.RefProjet = RefProjet;
           
            msh.FillDropDownList("select NomConservation from conservation", inputConservation, "NomConservation");
            string query3 = "select MAX(NumEdd)+1 AS Num from edd;";
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
                if (rdr3["Num"].ToString() == "")
                {
                    inputNumEDD.Text = "1";
                }
                else
                {
                    inputNumEDD.Text = rdr3["Num"].ToString();
                }
                inputNumEDD.IsEnabled = false;
            }

        }
       

     




        private void Page_Loaded(object sender, RoutedEventArgs e)

        {
            msh.LoadData("select *,DATE_FORMAT(DatePubli,'%d/%m/%y') AS Date from edd where RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "'", dataViewListeEdd);
        }



        private void dataViewListeEdd_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewListeEdd.SelectedCells[0];
            tempNumEdd = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
            
              /*
            DataRowView row = dataViewListeEdd.SelectedItem as DataRowView;
            System.Windows.MessageBox.Show(row.Row.ItemArray[2].ToString());
            string tempNumEdd2 = "";
            
            int idx =  dataViewListeEdd.SelectedIndex -1;
            dataViewListeEdd.*/
            


            string query = "select *,DATE_FORMAT(DatePubli,'%d/%m/%y') AS Date from edd where NumEdd =" + tempNumEdd;
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
                    //inputNumEDD.Text = rdr["NumEdd"].ToString();
                  /*inputDateEdd.Text = rdr["DateEdd"].ToString();
                    inputNumEnreg.Text = rdr["NumEnrg"].ToString();*/
                    inputDateEnreg.Text = rdr["Date"].ToString();
                    inputVolume.Text = rdr["Volume"].ToString();
                    inputRefPub.Text = rdr["RefPubli"].ToString();
                    inputConservation.Text = rdr["Conservation"].ToString();
                    inputNotaire.Text = rdr["Notaire"].ToString();
                    inputTelNotaire.Text = rdr["TelNotaire"].ToString();
                    inputAdresseNotaire.Text = rdr["AdresseNotaire"].ToString();
                    inputNomGeo.Text = rdr["NomPrenomGeo"].ToString();
                    inputAddresseGeo.Text = rdr["AdresseGeo"].ToString();
                    inputTelGeo.Text = rdr["TelGeo"].ToString();
                    inputNbrLog.Text = rdr["NbrLog"].ToString();
                    inputSupLog.Text = rdr["SuperficieLog"].ToString();
                    inputNbrLoc.Text = rdr["NbrLoc"].ToString();
                    inputSupLoc.Text = rdr["SuperficeiLoc"].ToString();
                    inputNbrBur.Text = rdr["NbrBur"].ToString();
                    inputSupBur.Text = rdr["SuperficieBur"].ToString();
                    inputNbrCave.Text = rdr["NbrCave"].ToString();
                    inputSupCave.Text = rdr["SuperficieCave"].ToString();
                    inputNbrEQ.Text = rdr["NbrEQ"].ToString();
                    inputSupEQ.Text = rdr["SuperficieEQ"].ToString();
                    inputNbrPS.Text = rdr["NbrPS"].ToString();
                    inputSupPS.Text = rdr["SuperficiePS"].ToString();
                    inputDateGeo.Text = rdr["DateEtablis"].ToString();
                    inputRedicte.Text=rdr["Redicte"].ToString();



                    oneTime = false;
                }
            }
        }


    

    private void BtnAjouterEdd_Click(object sender, RoutedEventArgs e)
        {
           if (dataViewListeEdd.Items.Count==0)
            { 
            string Edd = "Edd";
            DirectoryCreator DC = new DirectoryCreator();
            DC.CreateDirectoryProgramme(RefProjet.ToString(), RefProgramme + "/" + Edd + "/" + inputNumEDD.Text);
            EC.AjouterEdd(RefProjet, RefProgramme, inputDateEnreg.Text, inputVolume.Text,inputRefPub.Text, inputConservation.Text, inputNotaire.Text, inputTelNotaire.Text, inputAdresseNotaire.Text, inputNomGeo.Text, inputAddresseGeo.Text, inputTelGeo.Text,inputDateGeo.Text,inputRedicte.Text, inputNbrLog.Text, decimal.Parse(inputSupLog.Text), inputNbrLoc.Text, decimal.Parse(inputSupLoc.Text), inputNbrBur.Text, decimal.Parse(inputSupBur.Text), inputNbrCave.Text, decimal.Parse(inputSupCave.Text), inputNbrEQ.Text, decimal.Parse(inputSupEQ.Text), inputNbrPS.Text, decimal.Parse(inputSupPS.Text));
            msh.LoadData("select *,DATE_FORMAT(DatePubli,'%d/%m/%y') AS Date from edd where RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "'", dataViewListeEdd);
            inputDateEnreg.Text = inputVolume.Text = inputConservation.Text = inputNotaire.Text = inputTelNotaire.Text = inputAdresseNotaire.Text = inputNomGeo.Text = inputTelGeo.Text = inputAddresseGeo.Text= inputNbrLog.Text=inputNbrLoc.Text=inputNbrCave.Text=inputNbrEQ.Text=inputNbrPS.Text=inputNbrBur.Text= "";
            inputSupLog.Text = inputSupLoc.Text = inputSupBur.Text = inputSupCave.Text = inputSupEQ.Text = inputSupPS.Text = "0";
            }
            else
            {
                System.Windows.MessageBox.Show("Vous ne pouvez pas ajouter un nouveau EDD car il existe déja un !", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }

        private void BtnModifierEdd_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumEdd == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionner un EDD pour le modifié", "information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { 
                EC.ModifierEdd(RefProjet, RefProgramme, inputDateEnreg.Text, inputVolume.Text,inputRefPub.Text, inputConservation.Text, inputNotaire.Text, inputTelNotaire.Text, inputAdresseNotaire.Text, inputNomGeo.Text, inputAddresseGeo.Text, inputTelGeo.Text, inputDateGeo.Text, inputRedicte.Text, inputNbrLog.Text, decimal.Parse(inputSupLog.Text), inputNbrLoc.Text, decimal.Parse(inputSupLoc.Text), inputNbrBur.Text, decimal.Parse(inputSupBur.Text), inputNbrCave.Text, decimal.Parse(inputSupCave.Text), inputNbrEQ.Text, decimal.Parse(inputSupEQ.Text), inputNbrPS.Text, decimal.Parse(inputSupPS.Text),tempNumEdd);
                msh.LoadData("select *,DATE_FORMAT(DatePubli,'%d/%m/%y') AS Date from edd where RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "'", dataViewListeEdd);
                inputDateEnreg.Text = inputVolume.Text = inputConservation.Text = inputNotaire.Text = inputTelNotaire.Text = inputAdresseNotaire.Text = inputNomGeo.Text = inputTelGeo.Text = inputAddresseGeo.Text = inputNbrLog.Text = inputNbrLoc.Text = inputNbrCave.Text = inputNbrEQ.Text = inputNbrPS.Text = inputNbrBur.Text = "";
                inputSupLog.Text = inputSupLoc.Text = inputSupBur.Text = inputSupCave.Text = inputSupEQ.Text = inputSupPS.Text = "0";
            }

        }

        private void BtnSupprimmerEdd_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumEdd == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionner un EDD pour le supprimé", "information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                BiensController BC = new BiensController();
                DirectoryCreator DC = new DirectoryCreator();
                
                DC.DeleteDirectory(@"Projet\" + RefProjet + @"\Programme\" + RefProgramme + @"\Edd \" + tempNumEdd);
                BC.SupprimerLogFromEDD(int.Parse(tempNumEdd), int.Parse(RefProgramme), RefProjet);
                EC.SupprimerEdd(tempNumEdd);
                msh.LoadData("select *,DATE_FORMAT(DatePubli,'%d/%m/%y') AS Date from edd where RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "'", dataViewListeEdd);
                inputDateEnreg.Text = inputVolume.Text = inputConservation.Text = inputNotaire.Text = inputTelNotaire.Text = inputAdresseNotaire.Text = inputNomGeo.Text = inputTelGeo.Text = inputAddresseGeo.Text = inputNbrLog.Text = inputNbrLoc.Text = inputNbrCave.Text = inputNbrEQ.Text = inputNbrPS.Text = inputNbrBur.Text = "";
                inputSupLog.Text = inputSupLoc.Text = inputSupBur.Text = inputSupCave.Text = inputSupEQ.Text = inputSupPS.Text = "0";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnOuvrirEdd_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumEdd == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionner un EDD pour ouvrir dossier", "information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
            
               string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + RefProjet + @"\Programme\" + RefProgramme + @"\Edd\" + inputNumEDD.Text;
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
                dcr.CreateDirectoryProgramme(tempnumprojet, RefProgramme + "/");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        }

        private void BtnJoindreEdd_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumEdd == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionner un EDD pour joindre des fichier", "information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                SelectFile("Document Edd");
            }
        }
        public void SelectFile(string theDirectory)
        {
           
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + RefProgramme + @"\Edd\" + inputNumEDD.Text + @"\" + theDirectory + @"\" + System.IO.Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectoryEdd(tempnumprojet, RefProgramme, inputNumEDD.Text + "/" + theDirectory);
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

        private void BtnCreationListeBiens_Click(object sender, RoutedEventArgs e)
        {
            /*
            Window win = new Window();
            CreationListeLog bien = new 
            win.Content = bien;
            win.Title = "Biens";
            win.Show();*/


            if (tempNumEdd !="")
            {
                Window window = new Window

                {
                    Title = "Ajouter/Liste biens",
                    Content = new CreationListeLog(RefProjet, int.Parse(RefProgramme), int.Parse(tempNumEdd),TypeProgramme,typevente,coutFoncier,Prixm2),
                    SizeToContent = SizeToContent.WidthAndHeight,
                    ResizeMode = ResizeMode.NoResize,
                    WindowStartupLocation = WindowStartupLocation.CenterScreen,
                      
                };

                window.ShowDialog();
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez selectionner un EDD pour créer des biens", "information", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void BtnEddmodificatif_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumEdd == "" && inputNumEDD.Text==tempNumEdd && inputNumEDD.Text=="")
            {
                System.Windows.MessageBox.Show("Veuillez selectionner un EDD pour créer un EDD modificatif","information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                string NumEddModif = "";
                 BiensController BS = new BiensController();
                 
                
               
                 EC.AjouterEdd(RefProjet, RefProgramme, inputDateEnreg.Text, inputVolume.Text,inputRefPub.Text, inputConservation.Text, inputNotaire.Text, inputTelNotaire.Text, inputAdresseNotaire.Text, inputNomGeo.Text, inputAddresseGeo.Text, inputTelGeo.Text, inputDateGeo.Text, inputRedicte.Text, inputNbrLog.Text, decimal.Parse(inputSupLog.Text), inputNbrLoc.Text, decimal.Parse(inputSupLoc.Text), inputNbrBur.Text, decimal.Parse(inputSupBur.Text), inputNbrCave.Text, decimal.Parse(inputSupCave.Text), inputNbrEQ.Text, decimal.Parse(inputSupEQ.Text), inputNbrPS.Text, decimal.Parse(inputSupPS.Text));
                string query3 = "select MAX(NumEdd) AS Num from edd where RefProjet='" + RefProjet + "' and RefProgramme='" + RefProgramme + "';";
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
                    NumEddModif = rdr3["Num"].ToString();
                }
                System.Windows.MessageBox.Show(NumEddModif);
                string Edd = "Edd";
                DirectoryCreator DC = new DirectoryCreator();
                DC.CreateDirectoryProgramme(RefProjet.ToString(), RefProgramme + "/" + Edd + "/" + NumEddModif);
                BS.BiensEddModificatif(int.Parse(tempNumEdd),int.Parse(NumEddModif),int.Parse(RefProgramme),RefProjet);
                msh.LoadData("select *,DATE_FORMAT(DatePubli,'%d/%m/%y') AS Date from edd where RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "'", dataViewListeEdd);
                inputDateEnreg.Text = inputVolume.Text = inputConservation.Text = inputNotaire.Text = inputTelNotaire.Text = inputAdresseNotaire.Text = inputNomGeo.Text = inputTelGeo.Text = inputAddresseGeo.Text = inputNbrLog.Text = inputNbrLoc.Text = inputNbrCave.Text = inputNbrEQ.Text = inputNbrPS.Text = inputNbrBur.Text = "";
                inputSupLog.Text = inputSupLoc.Text = inputSupBur.Text = inputSupCave.Text = inputSupEQ.Text = inputSupPS.Text = "0";

            }
        }
    }
}
