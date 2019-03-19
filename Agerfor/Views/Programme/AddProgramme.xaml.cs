using System;
using System.Windows.Controls;
using Agerfor.Controlers;
using System.Windows;
using Notifications.Wpf;
using MaterialDesignThemes.Wpf;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Globalization;
using System.Threading;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Data;
using System.ComponentModel;
using System.Text;

namespace Agerfor.Views.Programme
{
    /// <summary>
    /// Interaction logic for AddProgramme.xaml
    /// </summary>
    public partial class AddProgramme : Page
    {

      
        ProgrammeController PC = new ProgrammeController();
        ActeProgrammeController APC = new ActeProgrammeController();
        PermiLotirController PLC = new PermiLotirController();
     

        string RefProgramme = "";
        string Query = "";
        string tempNumActeProgramme = "";
        string tempnumprojet = "";
        string tempNumPL = "";
        string tempNumPC = "";
        /*string tempDateActeProgramme = "";
        string tempDateEnregActe = "";
        string tempDatePubliActe = "";
        string tempConservation = "";
        decimal tempFraisEnregi = 0;*/

        private readonly NotificationManager _notificationManager = new NotificationManager();
        private readonly Random _random = new Random();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public AddProgramme(string refprogramme, string NomProgramme)
        {
            this.RefProgramme = refprogramme;
            InitializeComponent();
          /*  
            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");*/
            msh.FillDropDownList("select NatureProgramme from natureprogramme", inputNatureProgramme, "NatureProgramme");
            msh.FillDropDownList("select NomDaira from daira", inputDairaProgramme, "NomDaira");
            msh.FillDropDownList("select NomProjet from projet", inputNomProjet, "NomProjet");
            msh.FillDropDownList("select NomConservation from conservation", inputConservation, "NomConservation");
            inputSuperficieGlobal.Text = inputSuperficieVoiries.Text = inputSuperficieEspaceVert.Text = inputSuperficieEquipements.Text = inputSuperficieAmenagement.Text = inputAutresSuperficie.Text = "0";
            inputSupLog.Text = inputSupLoc.Text = inputSupBur.Text = inputSuperficieCave.Text = inputSuperficieCC.Text = inputSuperficiePlcS.Text = "0";


            var timer = new System.Timers.Timer { Interval = 3000 };
            timer.Start();
            if (refprogramme != "")
            {
                string query = "select * from programme where RefProgramme =" + refprogramme;

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
                        inputNomProjet.Text = rdr["NomProjet"].ToString();
                        inputRefProgramme.Text = rdr["RefProgramme"].ToString();
                        inputNomProgramme.Text = rdr["NomProgramme"].ToString();
                        inputSiteProgramme.Text = rdr["Site"].ToString();
                        inputDairaProgramme.Text = rdr["Daira"].ToString();
                        inputCommuneProgramme.Text = rdr["Commune"].ToString();
                        inputNatureProgramme.Text = rdr["NatureProgramme"].ToString();
                        inputTypeProgramme.Text = rdr["TypeProgramme"].ToString();
                        inputNombredebien.Text = rdr["NombreBiens"].ToString();
                        inputSuperficie.Text = rdr["Superficie"].ToString();




                        oneTime = false;
                    }
                }
            }
        }


        private void inputNatureProgramme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
            try
            {
                inputTypeProgramme.Items.Clear();
                msh.FillDropDownList("select TypeProgramme from typeprogramme where typeprogramme.NatureProgramme='" + inputNatureProgramme.SelectedValue.ToString() + "'", inputTypeProgramme, "TypeProgramme");
                if (inputNatureProgramme.SelectedValue.ToString() == "Lotissement" || inputNatureProgramme.SelectedValue.ToString() == "Terrain Industriel" || inputNatureProgramme.SelectedValue.ToString() == "RHP")
                {
                    PermiLotir.IsEnabled = true;
                    Permisconstruire.IsEnabled = false;

                }
                else
                {
                    PermiLotir.IsEnabled = true;
                    Permisconstruire.IsEnabled = true;
                }
                if (inputNatureProgramme.SelectedValue.ToString() == "Lotissement" || inputNatureProgramme.SelectedValue.ToString() == "RHP")
                {
                    BtnCahiercharge.IsEnabled = true;
                    BtnEDD.IsEnabled = BtnConvention.IsEnabled = false;
                }
                if (inputNatureProgramme.SelectedValue.ToString() == "Terrain Industriel")
                {
                    BtnCahiercharge.IsEnabled = BtnConvention.IsEnabled = true;
                    BtnEDD.IsEnabled = false;
                }

                if (inputNatureProgramme.SelectedValue.ToString() == "Local" || inputNatureProgramme.SelectedValue.ToString() == "Logement")
                {
                    BtnCahiercharge.IsEnabled = BtnConvention.IsEnabled = false;
                    BtnEDD.IsEnabled = true;
                }



            }
            catch (Exception)
            { }

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {/*
            string tempnumlotir = inputNumLotir.Text;
            if (tempnumlotir == "")
            {
                var content = new NotificationContent { Title = "Permis de lotir n'existe pas", Message = "veuillez ajouter un permis de lotir!", Type=NotificationType.Warning };
                var clickContent = new NotificationContent
                {
                    Title = "",
                    Message = "",
                    Type = NotificationType.Warning
                };
                _notificationManager.Show(content, "WindowArea", onClick: () => _notificationManager.Show(clickContent));

                var content2 = new NotificationContent { Title = "Permis de lotir existe", Message = "veuillez ajouter un permis de lotir!", Type = NotificationType.Error };
                var clickContent2 = new NotificationContent
                {
                    Title = "",
                    Message = "",
                    Type = NotificationType.Warning
                };
                _notificationManager.Show(content2, "WindowArea2", onClick: () => _notificationManager.Show(clickContent2));
            }
            */
            

            if (Query == "")
            {
                msh.LoadData("select * from acteprogramme where RefProgramme='" + RefProgramme + "' and NomProjet='"+inputNomProjet.Text+"'", datagridActeProgramme);
            }
            else
            {
                msh.LoadData(Query, datagridActeProgramme);
            }
            msh.LoadData("select * from permilotir where RefProgramme='" + RefProgramme + "' and NomProjet='" + inputNomProjet.Text + "'", DataGridPLotir);
            msh.LoadData("select * from permisdeconstruire where RefProgramme='" + RefProgramme + "' and NomProjet='" + inputNomProjet.Text + "'", DataGridPConstruire);


            if (RefProgramme != "" && inputNatureProgramme.Text != "" && inputTypeProgramme.Text != "")
            {
                if (inputNatureProgramme.SelectedValue.ToString() == "Lotissement" || inputNatureProgramme.SelectedValue.ToString() == "Terrain Industriel" || inputNatureProgramme.SelectedValue.ToString() == "RHP")
                {
                    PermiLotir.IsEnabled = true;
                    Permisconstruire.IsEnabled = false;

                }
                else
                {
                    PermiLotir.IsEnabled = true;
                    Permisconstruire.IsEnabled = true;
                }
                if (inputNatureProgramme.SelectedValue.ToString() == "Lotissement" || inputNatureProgramme.SelectedValue.ToString() == "RHP")
                {
                    BtnCahiercharge.IsEnabled = true;
                    BtnEDD.IsEnabled = BtnConvention.IsEnabled = false;
                }
                if (inputNatureProgramme.SelectedValue.ToString() == "Terrain Industriel")
                {
                    BtnCahiercharge.IsEnabled = BtnConvention.IsEnabled = true;
                    BtnEDD.IsEnabled = false;
                }

                if (inputNatureProgramme.SelectedValue.ToString() == "Local" || inputNatureProgramme.SelectedValue.ToString() == "Logement")
                {
                    BtnCahiercharge.IsEnabled = BtnConvention.IsEnabled = false;
                    BtnEDD.IsEnabled = true;
                }
            }
            else
            {
                PermiLotir.IsEnabled = Permisconstruire.IsEnabled = false;
                BtnCahiercharge.IsEnabled = BtnEDD.IsEnabled = BtnConvention.IsEnabled = false;

            }
        }



        private void BtnCahiercharge_Click(object sender, RoutedEventArgs e)
        {
            CahierCharge cahiercharge = new CahierCharge(inputNomProjet.Text,inputRefProgramme.Text);
            DialogHost.Show(cahiercharge);
        }

        private void BtnEDD_Click(object sender, RoutedEventArgs e)
        {
            EDD EDD = new EDD(inputNomProjet.Text, inputRefProgramme.Text);
            DialogHost.Show(EDD);
            
        }

        private void BtnConvention_Click(object sender, RoutedEventArgs e)
        {
            Convention convention = new Convention(inputNomProjet.Text, inputRefProgramme.Text);
            DialogHost.Show(convention);
        }

  
        private void inputDairaProgramme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            inputCommuneProgramme.Items.Clear();
            msh.FillDropDownList("select NomCommune from commune,daira where NomDaira='" + inputDairaProgramme.SelectedItem.ToString() + "'and daira.IdDaira=commune.IdDaira", inputCommuneProgramme, "NomCommune");
        }
        //Ajouter Programme//
        private void BtnAjouterProgramme_Click(object sender, RoutedEventArgs e)
        {
            getrefprojet();
            DirectoryCreator DC = new DirectoryCreator();
            DC.CreateDirectoryProgramme(tempnumprojet, inputRefProgramme.Text);
            PC.AjouterProgramme(inputNomProjet.Text, inputRefProgramme.Text, inputNomProgramme.Text, inputSiteProgramme.Text, inputDairaProgramme.Text, inputCommuneProgramme.Text, inputNatureProgramme.Text, inputTypeProgramme.Text, inputNombredebien.Text, decimal.Parse(inputSuperficie.Text));
            AddProgramme AP = new AddProgramme("","");
            NavigationService.Navigate(AP);
           
        }
        //Modifier Programme//
        private void BtnModifierProgramme_Click(object sender, RoutedEventArgs e)
        {
            PC.Editprogramme(inputNomProjet.Text, inputRefProgramme.Text, inputNomProgramme.Text, inputSiteProgramme.Text, inputDairaProgramme.Text, inputCommuneProgramme.Text, inputNatureProgramme.Text, inputTypeProgramme.Text, inputNombredebien.Text, decimal.Parse(inputSuperficie.Text));
            AddProgramme AP = new AddProgramme("","");
            NavigationService.Navigate(AP);
        }
        //Annuler Programme//
        private void BtnAnnulerProgramme_Click(object sender, RoutedEventArgs e)
        {
            Programme P = new Programme("");
            NavigationService.Navigate(P);
        }
        //Ouvrir Programme//
        private void BtnOuvrirprogramme_Click(object sender, RoutedEventArgs e)
        {
            getrefprojet();
            string ip = "localhost";
            string folderPath = @"\\"+ip+@"\"+ AppDomain.CurrentDomain.BaseDirectory+""+ @"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text;
            OpenFolder(ipPatchController.getpath(folderPath, ip));
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
                dcr.CreateDirectoryProgramme(tempnumprojet, inputRefProgramme.Text + "/");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        }

        //Joindre Programme//
        private void BtnJoindreprogramme_Click(object sender, RoutedEventArgs e)
        {

            SelectFile("Document-Programme");
        }
        public void SelectFile(string theDirectory)
        {
            string ip = "localhost";
            getrefprojet();
            string destinationFolder;
            string destinationFolderf;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = @"\\" + ip + @"\" + AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\" + theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
                destinationFolderf = ipPatchController.getpath(destinationFolder, ip);

                dcr.CreateDirectoryProgramme(tempnumprojet, inputRefProgramme.Text + "/" + theDirectory + "/");
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolderf))
                {
                    File.Delete(destinationFolderf);
                }

                File.Copy(fileName, Path.Combine(Path.GetDirectoryName(fileName), destinationFolderf));
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionner");
            }
        }

        private void BtnAjouterActeProgramme_Click(object sender, RoutedEventArgs e)

        {
            if (NumActeProgramme.Text != "")
            {
                string Acte = "Acte";
                getrefprojet();
                DirectoryCreator DC = new DirectoryCreator();
                DC.CreateDirectoryProgramme(tempnumprojet, inputRefProgramme.Text + "/" + Acte + "/" + NumActeProgramme.Text);
                APC.AjouterActeProgramme(NumActeProgramme.Text, inputDateActeProgramme.Text, DateEnrgActeP.Text, DatePubliActeP.Text, inputConservation.Text, decimal.Parse(inputFrais.Text), inputRefProgramme.Text, inputNomProjet.Text);
                msh.LoadData("select * from acteprogramme where RefProgramme='" + RefProgramme + "' and NomProjet='" + inputNomProjet.Text + "'", datagridActeProgramme);
                NumActeProgramme.Text = inputDateActeProgramme.Text = DateEnrgActeP.Text = DatePubliActeP.Text = inputConservation.Text = "";
                inputFrais.Text = "0.00";
                inputFraisDivers.Text = "0.00";
                inputFraisPLotir.Text = "0.00";
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez remplir tous les champs pour ajouter un acte", "Acte programme", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void BtnModifierActeProgramme_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumActeProgramme == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Acte pour le modifier", "Acte programme", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                APC.EditerActe(NumActeProgramme.Text, inputDateActeProgramme.Text, DateEnrgActeP.Text, DatePubliActeP.Text, inputConservation.Text, decimal.Parse(inputFrais.Text), inputRefProgramme.Text, inputNomProjet.Text, tempNumActeProgramme);
                msh.LoadData("select * from acteprogramme where RefProgramme='" + RefProgramme + "' and NomProjet='" + inputNomProjet.Text + "'", datagridActeProgramme);
            }
        }
        private void dataViewActeProgramme_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            DataGridCellInfo cell0 = datagridActeProgramme.SelectedCells[0];
            tempNumActeProgramme = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;

            string query = "select * from acteprogramme where NumActe =" + tempNumActeProgramme;
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
                    NumActeProgramme.Text = rdr["NumActe"].ToString();
                    inputDateActeProgramme.Text = rdr["DateActe"].ToString();
                    DateEnrgActeP.Text = rdr["DateEnrgActe"].ToString();
                    DatePubliActeP.Text = rdr["DatePubliActe"].ToString();
                    inputConservation.Text = rdr["Conservation"].ToString();
                    inputFrais.Text = rdr["FraisEnrg"].ToString();
                    oneTime = false;
                }
            }
        }

        private void BtnSupprimerActeProgramme_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumActeProgramme == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Acte pour le supprimé", "Acte programme", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                DirectoryCreator DC = new DirectoryCreator();
                DC.DeleteDirectory(@"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\Acte\" + tempNumActeProgramme);
                APC.SupprimerActe(tempNumActeProgramme);
                msh.LoadData("select * from acteprogramme where RefProgramme='" + RefProgramme + "' and NomProjet='" + inputNomProjet.Text + "'", datagridActeProgramme);
                NumActeProgramme.Text = inputDateActeProgramme.Text = DateEnrgActeP.Text = DatePubliActeP.Text = inputConservation.Text = "";
                inputFrais.Text = "0.00";
            }
        }


        //Référence Projet//
        private void getrefprojet()
        {
            string query2 = "select RefProjet from projet where NomProjet ='" + inputNomProjet.Text + "'";
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

        private void BtnOuvrirActeProgramme_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumActeProgramme == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Acte pour ouvrir le dossier", "Acte programme", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { 
            getrefprojet();
            string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\Acte\" + NumActeProgramme.Text;
      
            OpenFolder(folderPath);
            }
        }

        private void BtnJoindreActeProgramme_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumActeProgramme == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Acte pour joindre des fichiers", "Acte programme", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else { 
            SelectFile2("Document-Acte");
            }
        }
        public void SelectFile2(string theDirectory)
        {
            getrefprojet();
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\Acte\" + NumActeProgramme.Text + @"\" + theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectoryActe(tempnumprojet,inputRefProgramme.Text,NumActeProgramme.Text+ "/"+theDirectory);
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolder))
                {
                    File.Delete(destinationFolder);
                }

                File.Copy(fileName, Path.Combine(Path.GetDirectoryName(fileName), destinationFolder));
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionner");
            }
            }

        private void BtnAjouterPLotir_Click(object sender, RoutedEventArgs e)
        {
            if (inputNumLotir.Text!="")
            {
                getrefprojet();
                DirectoryCreator DC = new DirectoryCreator();
                DC.CreateDirectoryPermisLotir(tempnumprojet, inputRefProgramme.Text, inputNumLotir.Text);
                PLC.AjouterPL(inputNumLotir.Text, inputDatePLotir.Text, decimal.Parse(inputFraisPLotir.Text), inputNbrIlot.Text, inputNbrLots.Text, decimal.Parse(inputSuperficieGlobal.Text), decimal.Parse(inputSuperficieVoiries.Text), decimal.Parse(inputSuperficieEspaceVert.Text), decimal.Parse(inputSuperficieEquipements.Text), decimal.Parse(inputSuperficieAmenagement.Text), decimal.Parse(inputAutresSuperficie.Text), inputRefProgramme.Text, inputNomProjet.Text);
                msh.LoadData("select * from permilotir where RefProgramme='" + RefProgramme + "' and NomProjet='" + inputNomProjet.Text + "'", DataGridPLotir);
                inputNumLotir.Text = inputDatePLotir.Text = inputNbrLots.Text = inputNbrIlot.Text = "";
                inputFraisPLotir.Text = "0.00";
                inputFrais.Text = "0.00";
                inputFraisDivers.Text = "0.00";
                inputSuperficieGlobal.Text = inputSuperficieVoiries.Text = inputSuperficieEspaceVert.Text = inputSuperficieEquipements.Text = inputSuperficieAmenagement.Text = inputAutresSuperficie.Text = "0";
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
                PLC.EditerPL(inputNumLotir.Text, inputDatePLotir.Text, decimal.Parse(inputFraisPLotir.Text), inputNbrIlot.Text, inputNbrLots.Text, decimal.Parse(inputSuperficieGlobal.Text), decimal.Parse(inputSuperficieVoiries.Text), decimal.Parse(inputSuperficieEspaceVert.Text), decimal.Parse(inputSuperficieEquipements.Text), decimal.Parse(inputSuperficieAmenagement.Text), decimal.Parse(inputAutresSuperficie.Text), inputRefProgramme.Text, inputNomProjet.Text, tempNumPL);
                msh.LoadData("select * from permilotir where RefProgramme='" + RefProgramme + "' and NomProjet='" + inputNomProjet + "'", DataGridPLotir);
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
                    inputFraisPLotir.Text = rdr["FraisDiver"].ToString();
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

        private void BtnSupprimerPLotir_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumPL == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Permis de lotir pour le supprimé", "Permis lotir", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                DirectoryCreator DC = new DirectoryCreator();
                DC.DeleteDirectory(@"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\PermisLotir\" + inputNumLotir.Text);
                PLC.SupprimerPL(tempNumPL);
                msh.LoadData("select * from permilotir where RefProgramme='" + RefProgramme + "' and NomProjet='" + inputNomProjet.Text  + "'", DataGridPLotir);
                inputNumLotir.Text = inputDatePLotir.Text = inputNbrIlot.Text = inputNbrLots.Text="";
                inputSuperficieGlobal.Text = inputSuperficieVoiries.Text = inputSuperficieEspaceVert.Text = inputSuperficieEquipements.Text = inputSuperficieAmenagement.Text = inputAutresSuperficie.Text = "0";
                inputFraisPLotir.Text = "0.00";
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
                getrefprojet();
                string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\PermisLotir\" + inputNumLotir.Text;

                OpenFolder(folderPath);
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
            getrefprojet();
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\PermisLotir\" + inputNumLotir.Text + @"\" + theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectoryPermisLotir(tempnumprojet, inputRefProgramme.Text, inputNumLotir.Text + "/" + theDirectory);
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolder))
                {
                    File.Delete(destinationFolder);
                }

                File.Copy(fileName, Path.Combine(Path.GetDirectoryName(fileName), destinationFolder));
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionné");
            }
        }

        private void BtnAjouterPC_Click(object sender, RoutedEventArgs e)
        {
            if (inputNumPermisConstruire.Text != "")
            {
                getrefprojet();
                DirectoryCreator DC = new DirectoryCreator();
                DC.CreateDirectoryPermisConstruire(tempnumprojet, inputRefProgramme.Text, inputNumPermisConstruire.Text);
                PermisDeConstruireController PDCC = new PermisDeConstruireController();
                PDCC.AjouterPermisConstruire(inputNumPermisConstruire.Text, inputDatePermisConstruire.Text, decimal.Parse(inputFraisDivers.Text), inputNbrLog.Text, decimal.Parse(inputSupLog.Text), inputNbrLoc.Text, decimal.Parse(inputSupLoc.Text), inputNbrBur.Text, decimal.Parse(inputSupBur.Text), inputNbrCave.Text, decimal.Parse(inputSuperficieCave.Text), inputNbrCC.Text, decimal.Parse(inputSuperficieCC.Text), inputNbrPlcS.Text, decimal.Parse(inputSuperficiePlcS.Text), inputRefProgramme.Text, inputNomProjet.Text);
                msh.LoadData("select * from permisdeconstruire where RefProgramme='" + RefProgramme + "' and NomProjet='" + inputNomProjet.Text + "'", DataGridPConstruire);
                inputNumPermisConstruire.Text = inputDatePermisConstruire.Text = inputNbrLog.Text = inputNbrLoc.Text = inputNbrBur.Text = inputNbrCave.Text = inputNbrCC.Text = inputNbrPlcS.Text = "";
                inputFraisDivers.Text = "0.00";
                inputFrais.Text = "0.00";
                inputFraisPLotir.Text = "0.00";
                inputSupLog.Text = inputSupLoc.Text = inputSupBur.Text = inputSuperficieCave.Text = inputSuperficieCC.Text = inputSuperficiePlcS.Text = "0";
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez remplir tous les champs pour ajouter un permis de construire", "Permis de construire", MessageBoxButton.OK, MessageBoxImage.Information);
            }

        }

        private void DataGridPConstruire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            DataGridCellInfo cell0 = DataGridPConstruire.SelectedCells[0];
            tempNumPC = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;

            string query = "select * from permisdeconstruire where NumPermis =" + tempNumPC;
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
                    inputNumPermisConstruire.Text = rdr["NumPermis"].ToString();
                    inputDatePermisConstruire.Text = rdr["DatePermisC"].ToString();
                    inputFraisDivers.Text = rdr["FraisDivers"].ToString();
                    inputNbrLog.Text = rdr["NbrLog"].ToString();
                    inputSupLog.Text = rdr["SupLog"].ToString();
                    inputNbrLoc.Text = rdr["NbrLoc"].ToString();
                    inputSupLoc.Text = rdr["SupLoc"].ToString();
                    inputNbrBur.Text = rdr["NbrBur"].ToString();
                    inputSupBur.Text = rdr["SupBur"].ToString();
                    inputNbrCave.Text = rdr["NbrCave"].ToString();
                    inputSuperficieCave.Text = rdr["SupCave"].ToString();
                    inputNbrCC.Text = rdr["NbrCC"].ToString();
                    inputSuperficieCC.Text = rdr["SupCC"].ToString();
                    inputNbrPlcS.Text = rdr["NbrPS"].ToString();
                    inputSuperficiePlcS.Text = rdr["SupPS"].ToString();


                    oneTime = false;
                }
            }
        }

        private void BtnModifierPC_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumPC == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Permis de construire pour le modifié", "Permis de construire", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                PermisDeConstruireController PDCC = new PermisDeConstruireController();
                PDCC.ModifierPermisConstruire(inputNumPermisConstruire.Text, inputDatePermisConstruire.Text, decimal.Parse(inputFraisDivers.Text), inputNbrLog.Text, decimal.Parse(inputSupLog.Text), inputNbrLoc.Text, decimal.Parse(inputSupLoc.Text), inputNbrBur.Text, decimal.Parse(inputSupBur.Text), inputNbrCave.Text, decimal.Parse(inputSuperficieCave.Text), inputNbrCC.Text, decimal.Parse(inputSuperficieCC.Text), inputNbrPlcS.Text, decimal.Parse(inputSuperficiePlcS.Text), inputRefProgramme.Text, inputNomProjet.Text, tempNumPC);
                msh.LoadData("select * from permisdeconstruire where RefProgramme='" + RefProgramme + "' and NomProjet='" + inputNomProjet.Text + "'", DataGridPConstruire);
            }
        }

        private void BtnSupprimerPC_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumPC == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Permis de construire pour le supprimé", "Permis de construire", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                DirectoryCreator DC = new DirectoryCreator();
                DC.DeleteDirectory(@"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\Permis de construire\" + inputNumPermisConstruire.Text);
                PermisDeConstruireController PDCC = new PermisDeConstruireController();
                PDCC.SupprimerPermisConstruire(tempNumPC);
                msh.LoadData("select * from permisdeconstruire where RefProgramme='" + RefProgramme + "' and NomProjet='" + inputNomProjet.Text + "'", DataGridPConstruire);
            }
            
        }

        public void SelectFile4(string theDirectory)
        {
            getrefprojet();
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\Permis de construire\" + inputNumPermisConstruire.Text + @"\" + theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectoryPermisConstruire(tempnumprojet, inputRefProgramme.Text, inputNumPermisConstruire.Text + "/" + theDirectory);
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolder))
                {
                    File.Delete(destinationFolder);
                }

                File.Copy(fileName, Path.Combine(Path.GetDirectoryName(fileName), destinationFolder));
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionné");
            }
        }

        private void BtnOuvrirPC_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumPC == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Permis de construire pour ouvrir le dossier", "Permis de construire", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                getrefprojet();
                string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + tempnumprojet + @"\Programme\" + inputRefProgramme.Text + @"\Permis de construire\" + inputNumPermisConstruire.Text;
                OpenFolder(folderPath);
            }
        }

        private void BtnJoindrePC_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumPC == "")
            {
                System.Windows.MessageBox.Show("Veuillez selectionné un Permis de construire pour joindre des fichiers", "Permis de construire", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
            {
                SelectFile4("Document Permis de construire");
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
    
    

    


