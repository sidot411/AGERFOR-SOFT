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
using System.Data;
using Agerfor.ProjetReporting;
using MaterialDesignThemes.Wpf;

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
        int RefProjet = 0;
        string Query = "";
        int tempID;
        string tempNumActeProjet = "";
        string UserRole;


        public AddProjet(int RefProjet,string UserRole)
        {
            InitializeComponent();


            msh.FillDropDownList("select NomConservation from conservation", inputConserv, "NomConservation");
            msh.FillDropDownList("select NomWilaya from wilaya", inputWilayaProjet, "NomWilaya");
            msh.FillDropDownList("select NomProjetM from projetmaitre", inputProjetMaitre,"NomProjetM");
            this.UserRole = UserRole;
            this.RefProjet = RefProjet;

            if (RefProjet != 0)
            {
                string query = "select * from projet where RefProjet =" + RefProjet;
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
                        inputRefProjet.Text = rdr["RefProjet"].ToString();
                        inputNomProjet.Text = rdr["NomProjet"].ToString();
                        inputProjetMaitre.Text = rdr["ProjetMaitre"].ToString();
                        inputVendeurProjet.Text = rdr["Vendeur"].ToString();
                        inputWilayaProjet.Text = rdr["Wilaya"].ToString();
                        inputDairaProjet.Text = rdr["Daira"].ToString();
                        inputCommuneProjet.Text = rdr["Commune"].ToString();
                        inputPayement.Text = rdr["Payement"].ToString();
                        inputSuperficieProjet.Text = rdr["Superficie"].ToString();
                        inputLimitNord.Text = rdr["LimiteNord"].ToString();
                        inputLimitEst.Text = rdr["LimiteEst"].ToString();
                        inputLimitOuest.Text = rdr["LimiteOuest"].ToString();
                        inputLimitSud.Text = rdr["LimiteSud"].ToString();
                        inputMontantCB.Text = rdr["MontantCessionB"].ToString();
                        inputMontantC.Text = rdr["MontantCession"].ToString();
                        inputNumReçu.Text = rdr["NumRecu"].ToString();
                        inputDateRecu.Text = rdr["DateRecu"].ToString();

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
            else
            {
                string query2 = "select MAX(RefProjet)+1 AS Num from projet;";
                MySqlDataReader rdr2 = null;
                MySqlConnection con2 = null;
                MySqlCommand cmd2 = null;
                con2 = new MySqlConnection(Database.ConnectionString());
                con2.Open();
                cmd2 = new MySqlCommand(query2);
                cmd2.Connection = con2;
                rdr2 = cmd2.ExecuteReader();
                bool oneTime2 = true;
                while (rdr2.Read())
                {
                    if (rdr2["Num"].ToString() == "")
                    {
                        inputRefProjet.Text = "1";
                    }
                    else
                    {
                        inputRefProjet.Text = rdr2["Num"].ToString();
                    }
                }
            }
            inputRefProjet.IsEnabled = false;

            string query3 = "select MAX(NumActe)+1 AS Num2 from acteprojet;";
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
                    inputNumAct.Text = "1";
                }
                else
                {
                    inputNumAct.Text = rdr3["Num2"].ToString();
                }
            }
            inputNumAct.IsEnabled = false;
        }

 
        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            if (Query =="")
            {
                msh.LoadData("select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS Date from acteprojet where RefProjet='" + inputRefProjet.Text+"'", dataViewActeProjet);
                msh.LoadData("select * from listeilot where RefProjet='" + RefProjet + "'",dataViewIlot);
            }
            else
            {
                msh.LoadData(Query, dataViewActeProjet);
            }
        }

        private void BtnAjouterProjet_Click(object sender, System.Windows.RoutedEventArgs e)
        {

           // if (inputRefProjet.Text != "" && inputNomProjet.Text != "" && inputConservProjet.Text != "" && inputDairaProjet.Text != "" && inputCommuneProjet.Text != "" && inputSuperficieProjet.Text != ""  && inputLimitNord.Text != "" && inputLimitEst.Text != "" && inputLimitOuest.Text != "" && inputLimitSud.Text != "" && inputNumReçu.Text != "" && inputDateRecu.Text != "")
           // {
                DirectoryCreator dcr = new DirectoryCreator();
                dcr.CreateDirectory(inputRefProjet.Text);

                PC.AjouterProjet(inputNomProjet.Text, inputProjetMaitre.Text, inputVendeurProjet.Text, inputWilayaProjet.Text, inputDairaProjet.Text, inputCommuneProjet.Text, inputPayement.Text,decimal.Parse(inputSuperficieProjet.Text), inputLimitNord.Text, inputLimitEst.Text, inputLimitOuest.Text, inputLimitSud.Text, decimal.Parse(inputMontantCB.Text), decimal.Parse(inputMontantC.Text), inputNumReçu.Text, inputDateRecu.Text);

                if (System.Windows.MessageBox.Show("Voulez-vous attacher des documents au projet?", "Question", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.No)
                {
                    AddProjet Addprojet = new AddProjet(0,UserRole);
                    this.NavigationService.Navigate(Addprojet);
                }
                else
                {
                    SelectFile("Document-Projet");
                    AddProjet Addprojet = new AddProjet(0,UserRole);
                    this.NavigationService.Navigate(Addprojet);
                }


               
         //   }
       //     else
          //  {
              //  System.Windows.MessageBox.Show("Veuillez introduire toutes les informations nécessaires !", "Projet", MessageBoxButton.OK, MessageBoxImage.Information);
          //  }
        }

        private void BtnModifierProjet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            PC.Editprojet(inputNomProjet.Text, inputProjetMaitre.Text, inputVendeurProjet.Text, inputWilayaProjet.Text, inputDairaProjet.Text, inputCommuneProjet.Text, inputPayement.Text, decimal.Parse(inputSuperficieProjet.Text), inputLimitNord.Text, inputLimitEst.Text, inputLimitOuest.Text, inputLimitSud.Text, decimal.Parse(inputMontantCB.Text), decimal.Parse(inputMontantC.Text), inputNumReçu.Text, inputDateRecu.Text,RefProjet);

            RefProjet = int.Parse(inputRefProjet.Text);
            AddProjet Addprojet = new AddProjet(RefProjet,UserRole);
            this.NavigationService.Navigate(Addprojet);
        }

       

        private void dataViewActeProjet_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            DataGridCellInfo cell0 = dataViewActeProjet.SelectedCells[0];
            tempNumActeProjet = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;

            string query = "select * from acteprojet where NumActe =" + tempNumActeProjet;
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
                    inputNumAct.Text = rdr["NumActe"].ToString();
                    inputDatepubliActe.Text = rdr["DatePubliActe"].ToString();
                    inputVolume.Text = rdr["Volume"].ToString();
                    inputRefPub.Text = rdr["RefPubli"].ToString();
                    inputFraisActe.Text = rdr["FraisPubli"].ToString();
                    inputPOS.Text = rdr["Pos"].ToString();
                    inputConserv.Text = rdr["Conservation"].ToString();
                    
                    oneTime = false;
                }
            }

        }

        private void BtnAjouterActe_Click(object sender, RoutedEventArgs e)
        {
           



            if (inputNumAct.Text !="")
             {
                 string Acte = "Acte";
                 DirectoryCreator dcr = new DirectoryCreator();
                 dcr.CreateDirectory(inputRefProjet.Text + "/" + Acte + "/");
                 AC.AjouterActe(inputDatepubliActe.Text, inputVolume.Text, inputRefPub.Text, decimal.Parse(inputFraisActe.Text), inputPOS.Text, inputConserv.Text,int.Parse(inputRefProjet.Text));
                 PC.Editprojet(inputNomProjet.Text, inputProjetMaitre.Text, inputVendeurProjet.Text, inputWilayaProjet.Text, inputDairaProjet.Text, inputCommuneProjet.Text, inputPayement.Text, decimal.Parse(inputSuperficieProjet.Text), inputLimitNord.Text, inputLimitEst.Text, inputLimitOuest.Text, inputLimitSud.Text, decimal.Parse(inputMontantCB.Text), decimal.Parse(inputMontantC.Text), inputNumReçu.Text, inputDateRecu.Text, RefProjet);
                 RefProjet = int.Parse(inputRefProjet.Text);
                 msh.LoadData("select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS Date from acteprojet where RefProjet='" + inputRefProjet.Text + "'", dataViewActeProjet);
            }
             else
             {
                 System.Windows.MessageBox.Show("Veuillez introduire toutes les informations nécessaires !", "Projet", MessageBoxButton.OK, MessageBoxImage.Information);
             }
        }

        private void BtnModifierActe_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumActeProjet != "")
            {
                AC.EditerActe(inputDatepubliActe.Text,inputVolume.Text,inputRefPub.Text,decimal.Parse(inputFraisActe.Text),inputPOS.Text,inputConserv.Text,RefProjet,int.Parse(tempNumActeProjet));
                RefProjet = int.Parse(inputRefProjet.Text);
                msh.LoadData("select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS Date from acteprojet where RefProjet='" + inputRefProjet.Text + "'", dataViewActeProjet);
                decimal sum = 0;
                foreach (DataRowView row in dataViewActeProjet.ItemsSource)
                {
                    sum += (decimal)row["FraisPubli"];
                }
                inputMontantC.Text = (decimal.Parse(inputMontantCB.Text) + sum).ToString();
                PC.Editprojet(inputNomProjet.Text, inputProjetMaitre.Text, inputVendeurProjet.Text, inputWilayaProjet.Text, inputDairaProjet.Text, inputCommuneProjet.Text, inputPayement.Text, decimal.Parse(inputSuperficieProjet.Text), inputLimitNord.Text, inputLimitEst.Text, inputLimitOuest.Text, inputLimitSud.Text, decimal.Parse(inputMontantCB.Text), decimal.Parse(inputMontantC.Text), inputNumReçu.Text, inputDateRecu.Text, RefProjet);
               
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez sélectionner un Acte !", "Acte projet", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnSupprimerActe_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumActeProjet != "")
            {
                DirectoryCreator DC = new DirectoryCreator();
                DC.DeleteDirectory(@"Projet\" + inputRefProjet.Text + @"\Acte\" + tempNumActeProjet);
                AC.SupprimerActe(inputNumAct.Text);
                msh.LoadData("select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS Date from acteprojet where RefProjet='" + inputRefProjet.Text + "'", dataViewActeProjet);
                decimal sum = 0;
                foreach (DataRowView row in dataViewActeProjet.ItemsSource)
                {
                    sum += (decimal)row["FraisPubli"];
                }
                System.Windows.MessageBox.Show(sum.ToString());
                inputMontantC.Text = (decimal.Parse(inputMontantCB.Text) + sum + decimal.Parse(inputFraisActe.Text)).ToString();
                RefProjet = int.Parse(inputRefProjet.Text);
                PC.Editprojet(inputNomProjet.Text, inputProjetMaitre.Text, inputVendeurProjet.Text, inputWilayaProjet.Text, inputDairaProjet.Text, inputCommuneProjet.Text, inputPayement.Text, decimal.Parse(inputSuperficieProjet.Text), inputLimitNord.Text, inputLimitEst.Text, inputLimitOuest.Text, inputLimitSud.Text, decimal.Parse(inputMontantCB.Text), decimal.Parse(inputMontantC.Text), inputNumReçu.Text, inputDateRecu.Text, RefProjet);
                string query3 = "select MAX(NumActe)+1 AS Num2 from acteprojet;";
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
                        inputNumAct.Text = "1";
                    }
                    else
                    {
                        inputNumAct.Text = rdr3["Num2"].ToString();
                    }
                }
                inputNumAct.IsEnabled = false;
                inputDatepubliActe.Text = inputVolume.Text = inputRefPub.Text = inputPOS.Text = inputConserv.Text = string.Empty;
                inputFraisActe.Text = "0.00"; 
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez sélectionner un Acte !", "Acte projet", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + inputRefProjet.Text+ @"\" + theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
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
            if(tempNumActeProjet != "")
            {
                
                string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Projet\" + inputRefProjet.Text + @"\Acte\";
                OpenFolder(folderPath);
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez sélectionner un Acte !", "Acte projet", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }

        private void BtnJoindre_Click(object sender, RoutedEventArgs e)
        {
            if (tempNumActeProjet != "")
            {
                SelectFile2("Acte");
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez sélectionner un Acte !", "Acte projet", MessageBoxButton.OK, MessageBoxImage.Information);
            }
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

        private void BtnAnnulerProjet_Click(object sender, RoutedEventArgs e)
        {
            Projet p = new Projet("",UserRole);
            NavigationService.Navigate(p);
        }

        private void inputMontantCB_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (tempNumActeProjet == "")
            {

                decimal sum = 0;
                foreach (DataRowView row in dataViewActeProjet.ItemsSource)
                {
                    sum += (decimal)row["FraisPubli"];
                }

                inputMontantC.Text = (decimal.Parse(inputMontantCB.Text) + sum + decimal.Parse(inputFraisActe.Text)).ToString();
            }
        }

        private void BtnimprimerProjet_Click(object sender, RoutedEventArgs e)
        {
            ProjetViwer PV = new ProjetViwer(RefProjet);
            PV.Show();
        }

        private void BtnPermiLotir_Click(object sender, RoutedEventArgs e)
        {
            PermisLotir PL = new PermisLotir(RefProjet);
            DialogHost.Show(PL);
            PL.title.Text="Permis Lotir";
        }

        private void BtnAjouterIlot_Click(object sender, RoutedEventArgs e)
        {
            IlotController IC = new IlotController();
            IC.ajouterIlot(inputIlot.Text, int.Parse(inputRefProjet.Text));
            msh.LoadData("select * from listeilot where RefProjet='" + RefProjet + "'", dataViewIlot);
            inputIlot.Text = string.Empty;
        }

        private void dataViewIlot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewIlot.SelectedCells[0];
            tempID = int.Parse(((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text);
            DataGridCellInfo cell1 = dataViewIlot.SelectedCells[1];
            inputIlot.Text = ((TextBlock)cell1.Column.GetCellContent(cell1.Item)).Text;
            
        }

        private void BtnModifierIlot_Click(object sender, RoutedEventArgs e)
        {
            IlotController IC = new IlotController();
            IC.modifierIlot(inputIlot.Text, int.Parse(inputRefProjet.Text), tempID);
            msh.LoadData("select * from listeilot where RefProjet='" + RefProjet + "'", dataViewIlot);
            inputIlot.Text = string.Empty;
            
        }

        private void BtnSupprimerIlot_Click(object sender, RoutedEventArgs e)
        {
            IlotController IC = new IlotController();
            IC.SupprimerIlot(tempID);
            msh.LoadData("select * from listeilot where RefProjet='" + RefProjet + "'", dataViewIlot);
            inputIlot.Text = string.Empty;
        }
    }

}
    
