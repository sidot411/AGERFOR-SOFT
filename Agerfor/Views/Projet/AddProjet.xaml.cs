using System;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Globalization;
using Agerfor.Controlers;
using System.Threading;
using System.Windows;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;


namespace Agerfor.Views.Projet
{
    /// <summary>
    /// Interaction logic for AddProjet.xaml
    /// </summary>
    public partial class AddProjet : Page
    {
        ProjetController PC = new ProjetController();
        ActeController AC = new ActeController();
        Agerfor.Controlers.MySqlHelper msh = new Agerfor.Controlers.MySqlHelper();
        string RefProjet = "";
        string Query = "";
        string TempNumActe = "";
 
  

        public AddProjet(string RefProjet)
        {
            InitializeComponent();

            Thread.CurrentThread.CurrentUICulture = CultureInfo.GetCultureInfo("en-US");
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            msh.FillDropDownList("select NomConservation from conservation",inputConservProjet, "NomConservation");
            msh.FillDropDownList("select NomWilaya from wilaya",inputWilayaProjet, "NomWilaya");
        
            this.RefProjet = RefProjet;
            if (RefProjet !="")
            {
                string query = "select * from projet where RefProjet ="+ RefProjet;
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
                        inputRefProjet.Text = rdr["RefProjet"].ToString();
                        inputNomProjet.Text = rdr["NomProjet"].ToString();
                        inputVolProjet.Text = rdr["VolProjet"].ToString();
                        inputConservProjet.Text = rdr["Conservation"].ToString();
                        inputVendeurProjet.Text = rdr["Vendeur"].ToString();
                        inputWilayaProjet.Text = rdr["Wilaya"].ToString();
                        inputDairaProjet.Text = rdr["Daira"].ToString();
                        inputCommuneProjet.Text = rdr["Commune"].ToString();
                        inputSuperficieProjet.Text = rdr["Superficie"].ToString();
                        inputNomGeo.Text = rdr["NomGeometre"].ToString();
                        inputAddressGeo.Text = rdr["AdresseGeometre"].ToString();
                        inputTelGeo.Text = rdr["NumGeometre"].ToString();
                        inputLimitNord.Text = rdr["LimiteNord"].ToString();
                        inputLimitEst.Text = rdr["LimiteEst"].ToString();
                        inputLimitOuest.Text = rdr["LimiteOuest"].ToString();
                        inputLimitSud.Text = rdr["LimiteSud"].ToString();
                        inputPrix.Text = rdr["PrixVente"].ToString();
                        inputNumReçu.Text = rdr["NumRecu"].ToString();
                        inputDateRecu.SelectedDate = DateTime.ParseExact(rdr["DateRecu"].ToString(), "dd/MM/yyyy", CultureInfo.InvariantCulture);
                        /*
                       inputNumAct.Text = rdr["NumActe"].ToString();

                       inputDateActe.SelectedDate = DateTime.ParseExact(rdr["DateActe"].ToString(), "dd-MM-yyyy", CultureInfo.InstalledUICulture);
                       inputEnrgActe.SelectedDate = DateTime.ParseExact(rdr["DateEnrgActe"].ToString(), "dd-MM-yyyy", CultureInfo.InstalledUICulture);
                       inputDatepubliActe.SelectedDate = DateTime.ParseExact(rdr["DatePubliActe"].ToString(), "dd-MM-yyyy", CultureInfo.InstalledUICulture);*/

                        oneTime = false;
                    }
                }


                con.Close();
            }
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Query =="")
            {
                msh.LoadData("select * from acteprojet where RefProjet='"+inputRefProjet.Text+"'", dataViewActeProjet);
            }
            else
            {
                msh.LoadData(Query, dataViewActeProjet);
            }
        }

        private void BtnAjouterProjet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
    
            
            DirectoryCreator dcr = new DirectoryCreator();
            dcr.CreateDirectory(inputRefProjet.Text);     
            PC.AjouterProjet(inputRefProjet.Text, inputNomProjet.Text, inputVolProjet.Text, inputConservProjet.Text, inputVendeurProjet.Text, inputWilayaProjet.Text, inputDairaProjet.Text, inputCommuneProjet.Text, decimal.Parse(inputSuperficieProjet.Text), inputNomGeo.Text, inputAddressGeo.Text, inputTelGeo.Text, inputLimitNord.Text, inputLimitEst.Text, inputLimitOuest.Text, inputLimitSud.Text, decimal.Parse(inputPrix.Text), inputNumReçu.Text, inputDateRecu.Text); 
            AddProjet Addprojet = new AddProjet("");
            this.NavigationService.Navigate(Addprojet);
        }

        private void BtnModifierProjet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PC.Editprojet(inputRefProjet.Text, inputNomProjet.Text, inputVolProjet.Text, inputConservProjet.Text, inputVendeurProjet.Text, inputWilayaProjet.Text, inputDairaProjet.Text, inputCommuneProjet.Text,decimal.Parse(inputSuperficieProjet.Text), inputNomGeo.Text, inputAddressGeo.Text, inputTelGeo.Text, inputLimitNord.Text, inputLimitEst.Text, inputLimitOuest.Text, inputLimitSud.Text,decimal.Parse(inputPrix.Text), inputNumReçu.Text, inputDateRecu.Text);
            RefProjet = inputRefProjet.Text;
            AddProjet Addprojet = new AddProjet(RefProjet);
            this.NavigationService.Navigate(Addprojet);
        }

       

        private void dataViewActeProjet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string tempNumActeProgramme = "";
            DataGridCellInfo cell0 = dataViewActeProjet.SelectedCells[0];
            tempNumActeProgramme = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;

            string query = "select * from acteprojet where NumActe =" + tempNumActeProgramme;
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
                    inputNumAct.Text = rdr["NumActe"].ToString();
                    inputDateActe.Text = rdr["DateActe"].ToString();
                    inputEnrgActe.Text = rdr["DateEnrgActe"].ToString();
                    inputDatepubliActe.Text = rdr["DatePubliActe"].ToString();
                    inputConservProjet.Text = rdr["Conservation"].ToString();
                    
                    oneTime = false;
                }
            }

        }

        private void BtnAjouterActe_Click(object sender, RoutedEventArgs e)
        {
            string Acte="Acte";
            DirectoryCreator dcr = new DirectoryCreator();
            dcr.CreateDirectory(inputRefProjet.Text + "/" +Acte +"/"+inputNumAct.Text);

            AC.AjouterActe(inputNumAct.Text, inputDateActe.Text, inputEnrgActe.Text, inputDatepubliActe.Text,inputConservProjet.Text, inputRefProjet.Text);
            RefProjet = inputRefProjet.Text;
            AddProjet Addprojet = new AddProjet(RefProjet);
            this.NavigationService.Navigate(Addprojet);
        }

        private void BtnModifierActe_Click(object sender, RoutedEventArgs e)
        {
            
            AC.EditerActe(inputNumAct.Text, inputDateActe.Text, inputEnrgActe.Text, inputDatepubliActe.Text, inputConservProjet.Text, inputRefProjet.Text,TempNumActe);
            RefProjet = inputRefProjet.Text;
            AddProjet Addprojet = new AddProjet(RefProjet);
            this.NavigationService.Navigate(Addprojet);
        }

        private void BtnSupprimerActe_Click(object sender, RoutedEventArgs e)
        {
           
            DirectoryCreator DC = new DirectoryCreator();
            DC.DeleteDirectory(@"Projet\" + inputRefProjet.Text + @"\Acte\" + TempNumActe); 
            AC.SupprimerActe(inputNumAct.Text);
            RefProjet = inputRefProjet.Text;
            AddProjet Addprojet = new AddProjet(RefProjet);
            this.NavigationService.Navigate(Addprojet);
        }

        private void BtnOpenFolder_Click(object sender, RoutedEventArgs e)
        {
            {
                string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + inputRefProjet.Text;
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
                dcr.CreateDirectory(inputRefProjet.Text + "/");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        }

        private void BtnUploadFiles_Click(object sender, RoutedEventArgs e)
        {
            SelectFile("Document-Projet");
        }
        public void SelectFile(string theDirectory)
        {
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + inputRefProjet.Text + @"\" +theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectory(inputRefProjet.Text + "/" + theDirectory + "/");
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
        public void SelectFile2(string theDirectory)
        {
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + inputRefProjet.Text+ @"\" + theDirectory + @"\" +inputNumAct.Text+ @"\" + Path.GetFileName(openFileDialog1.FileName);
                dcr.CreateDirectory(inputRefProjet.Text + "/" + theDirectory + "/");
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



        private void BtnOuvrirActe_Click(object sender, RoutedEventArgs e)
        {
            {
                
                string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + inputRefProjet.Text + @"\Acte\" + inputNumAct.Text;
                OpenFolder(folderPath);
            }
        }

        private void BtnJoindre_Click(object sender, RoutedEventArgs e)
        {
            SelectFile2("Acte");
        }

        private void inputWilayaProjet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            inputDairaProjet.Items.Clear();
            msh.FillDropDownList("select NomDaira from wilaya,daira where NomWilaya='" +inputWilayaProjet.SelectedItem.ToString() + "'and daira.IdWilaya=wilaya.NumWilaya", inputDairaProjet, "NomDaira");

        }



        private void inputDairaProjet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            inputCommuneProjet.Items.Clear();
            msh.FillDropDownList("select NomCommune from commune,daira where NomDaira='" + inputDairaProjet.SelectedItem.ToString() + "'and daira.IdDaira=commune.IdDaira", inputCommuneProjet, "NomCommune");

        }
    }

}
    
