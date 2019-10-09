using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Windows.Navigation;
using System;
using MaterialDesignThemes.Wpf;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using Agerfor.OVReporting;
using System.Data;
using System.Net;
using System.Net.Sockets;
using System.Net.NetworkInformation;
using Agerfor.Controlers;

namespace Agerfor.Views.Payement
{
    /// <summary>
    /// Interaction logic for ListeVers.xaml
    /// </summary>
    public partial class ListeVers : Window
    {
        OrdreVerssementController OVC = new OrdreVerssementController();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        int tempNumOV = 0;
        int NumAttribution;
        int NumPayement;
        int tempNumVerssement;
        string tempApport;
        decimal Reste;
        string CodeClient;
        string NomProgramme;
        string id;
        string username;
        string ip;
        string mac;
        AddPayement AddPayement;

        public ListeVers(int NumPayement, decimal Reste, int NumAttribution, AddPayement AddPayement, string CodeClient, string NomProgramme,string id,string username)
        {

            InitializeComponent();
            msh.FillDropDownList("select NatureP from naturepayement", inputNaturePayement, "NatureP");
            inputNatureFrais.IsEnabled = false;
            msh.LoadData("select * from ov where NumPayement='" + NumPayement + "'", dataViewOV);
            this.NumPayement = NumPayement;
            this.Reste = Reste;
            this.AddPayement = AddPayement;
            this.NumAttribution = NumAttribution;
            this.CodeClient = CodeClient;
            this.NomProgramme = NomProgramme;
            this.id = id;
            this.username = username;

            inputNumPayement.Text = NumPayement.ToString();
            inputEtat.IsEnabled = false;

            string query = "SELECT count(IdOvSolde) as APPORT FROM `ovsolde` WHERE CodeClient='1' and NomProgramme='LPA 160 logts' and EtatOvSolde='Terminé'";
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
                tempApport = rdr["APPORT"].ToString();
            }
            if (int.Parse(tempApport) == 0)
            {
                BtnimportApport.IsEnabled = false;
            }
            else
            {
                BtnimportApport.IsEnabled = true;
            }


        }

       

        private void BtnOV_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.MessageBox.Show(inputNaturePayement.Text);

            if (inputNaturePayement.Text != "Autre frais")
            {
                if (decimal.Parse(inputMontant.Text) <= Reste)
                {
                    OVC.AjouterOV(NumPayement, inputNumOV.Text, inputDateVersement.Text, inputDateEcheance.Text, decimal.Parse(inputMontant.Text), inputEtat.Text, inputDateRecu.Text, inputNumRecu.Text, inputTypePayement.Text, inputNaturePayement.Text, inputNatureFrais.Text);
                    msh.LoadData("select * from ov where NumPayement='" + NumPayement + "'", dataViewOV);
                }
                else

                {
                    System.Windows.MessageBox.Show("Le montant est supérieux au montant reste à payé du bien veuillez introduire une valeur inferieur");
                }
            }
            else
            {
                OVC.AjouterOV(NumPayement, inputNumOV.Text, inputDateVersement.Text, inputDateEcheance.Text, decimal.Parse(inputMontant.Text), inputEtat.Text, inputDateRecu.Text, inputNumRecu.Text, inputTypePayement.Text, inputNaturePayement.Text, inputNatureFrais.Text);
                msh.LoadData("select * from ov where NumPayement='" + NumPayement + "'", dataViewOV);
            }
        }

        private void dataViewOV_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewOV.SelectedCells[0];
            tempNumOV = int.Parse(((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text);

            string query = "select * from ov where NumPayement='" + NumPayement + "' and NumVerssement='" + tempNumOV + "'";
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
                tempNumVerssement = int.Parse(rdr["NumVerssement"].ToString());
                inputNumOV.Text = rdr["NumOV"].ToString();
                inputDateVersement.Text = rdr["DateOV"].ToString();
                inputDateEcheance.Text = rdr["DateEcheance"].ToString();
                inputMontant.Text = rdr["MontantAV"].ToString();
                inputEtat.Text = rdr["Etat"].ToString();
                inputDateRecu.Text = rdr["DateRecu"].ToString();
                inputNumRecu.Text = rdr["NumRecu"].ToString();
                inputTypePayement.Text = rdr["TypePayement"].ToString();
                inputNaturePayement.Text = rdr["NaturePayement"].ToString();
                inputNatureFrais.Text = rdr["NatureFrais"].ToString();
                inputNumPayement.IsEnabled = inputNumOV.IsEnabled = inputDateVersement.IsEnabled = inputDateEcheance.IsEnabled = inputMontant.IsEnabled = false;
                BtnOV.IsEnabled = false;
            }
        }


        private void BtnNewOv_Click(object sender, RoutedEventArgs e)
        {

            inputNumOV.Text = inputDateVersement.Text = inputDateEcheance.Text = inputMontant.Text = inputDateRecu.Text = inputNumRecu.Text = string.Empty;
            inputNumPayement.IsEnabled = inputNumOV.IsEnabled = inputDateVersement.IsEnabled = inputDateEcheance.IsEnabled = inputMontant.IsEnabled = true;
            msh.LoadData("select * from ov where NumPayement='" + NumPayement + "'", dataViewOV);
            BtnOV.IsEnabled = true;



        }

        private void BtnValiderverssement_Click(object sender, RoutedEventArgs e)
        {

            if (inputNumRecu.Text != "" && inputDateRecu.Text != "")
            {
                if (inputNumOV.Text != "")
                {
                    OrdreVerssementController OVC = new OrdreVerssementController();
                    OVC.UpdateOV("Terminé", inputDateRecu.Text, inputNumRecu.Text, tempNumVerssement);
                    if (inputNaturePayement.Text != "Autre frais")
                    {
                        msh.ExecuteQuery("update payement set MontantVerse=MontantVerse+" + decimal.Parse(inputMontant.Text) + ",Reste=MontantTotal-MontantVerse where NumPayement='" + NumPayement + "'");
                    }

                    if (inputNaturePayement.Text == "Autre frais" && inputNatureFrais.Text == "Frais de gestion")
                    {
                        msh.ExecuteQuery("update payement set EtatFraisGestion='Payé' where NumPayement='" + inputNumPayement.Text + "'");
                    }

                    msh.LoadData("select * from ov where NumPayement='" + NumPayement + "'", dataViewOV);
                    string query = "select * from payement where NumPayement='" + NumPayement + "'";
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
                        AddPayement.inputprixtotal.Text = rdr["MontantTotal"].ToString();
                        AddPayement.inputprixpayer.Text = rdr["MontantVerse"].ToString();
                        AddPayement.inputReste.Text = rdr["Reste"].ToString();

                    }
                    AddPayement.BtnCNL.IsEnabled = AddPayement.BtnFNPOS.IsEnabled = AddPayement.BtnCB.IsEnabled = true;

                    MainWindow mainWindows = (MainWindow)System.Windows.Application.Current.Windows[0];
                    mainWindows.Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
                    mainWindows.Frame.Navigate(AddPayement);
                    mainWindows.currentWindow.Text = "Payement";
                    mainWindows.Activate();
                    this.Close();


                }
                else
                {
                    System.Windows.MessageBox.Show("Veuillez selectionner un OV");
                }
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez remplir le Num et la date du recu de verssement !");
            }


        }

        private void BtnUploadFiles_Click(object sender, RoutedEventArgs e)
        {
            SelectFile("Payements");
        }
        public void SelectFile(string theDirectory)
        {
            string destinationFolder;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            DirectoryCreator dcr = new DirectoryCreator();
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var fileName = openFileDialog1.FileName;
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Attribution\" + NumAttribution.ToString() + @"\" + theDirectory + @"\" + Path.GetFileName(openFileDialog1.FileName);
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolder))
                {
                    File.Delete(destinationFolder);
                }
                File.Copy(fileName, Path.Combine(Path.GetDirectoryName(fileName), destinationFolder));
                System.Windows.MessageBox.Show(destinationFolder.ToString());
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionner");
            }
        }

        private void BtnOpenFolder_Click(object sender, RoutedEventArgs e)
        {

            string folderPath = AppDomain.CurrentDomain.BaseDirectory + @"Attribution\" + NumAttribution.ToString() + @"\Payements\";
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
                dcr.CreateDirectory3(NumAttribution.ToString() + "/");
                ProcessStartInfo startInfo = new ProcessStartInfo
                {
                    Arguments = folderPath,
                    FileName = "explorer.exe"
                };
                Process.Start(startInfo);
            }
        }

        private void BtnImpriOv_Click(object sender, RoutedEventArgs e)
        {
            
            
            string query = "select IP,MAC from users where UserName='"+username+ "' and IdUser='"+id+"'";
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
                ip = rdr["IP"].ToString();
                mac = rdr["MAC"].ToString();

            }

            if (GetIpAdress.GetLocalIPAddress() != ip)
            {
                msh.ExecuteQuery("update users set IP='" + GetIpAdress.GetLocalIPAddress() + "' where IdUser='" + id + "'");
            }

            else if (GetMacAdresse.GetMacAdress() !=mac)
            {
                msh.ExecuteQuery("update users set MAC='" + GetMacAdresse.GetMacAdress() + "' where IdUser='" + id + "'");
            }
            
        
            OrdreVerssementR OVR = new OrdreVerssementR(tempNumOV.ToString(),id);
            OVR.ShowDialog();
        }

        private void inputNaturePayement_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (inputNaturePayement.SelectedItem.ToString() == "Autre frais")
            {
                inputNatureFrais.IsEnabled = true;
                msh.FillDropDownList("select NatureF from naturefrais where NatureP='" + inputNaturePayement.SelectedItem.ToString() + "'", inputNatureFrais, "NatureF");
            }
            else
            {
                inputNatureFrais.IsEnabled = false;
            }
        }

        private void BtnimportApport_Click(object sender, RoutedEventArgs e)
        {
           
      
            
            if (int.Parse(tempApport) != 0)
            {
                DataTable DT = new DataTable();
                string query = "SELECT IdOvSolde,DATE_FORMAT(DateOvSolde,'%Y-%m-%d') AS DateOvSolde, DATE_FORMAT(DateEchOvSolde,'%Y-%m-%d') AS DateEchOvSolde,Montant,EtatOvSolde, DATE_FORMAT(DateRecu,'%Y-%m-%d') AS DateRecu,NumRecu FROM `ovsolde` WHERE CodeClient='1' and NomProgramme='LPA 160 logts' and EtatOvSolde='Terminé'";

                MySqlConnection con = null;
                MySqlCommand cmd = null;
                con = new MySqlConnection(Database.ConnectionString());
                cmd = new MySqlCommand(query);
                cmd.Connection = con;
                con.Open();
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                da.Fill(DT);
                con.Close();
                da.Dispose();
                for(int i=0;i<int.Parse(tempApport);i++)
                {
                    string ID = DT.Rows[i]["IdOvSolde"].ToString();
                    string DateOvSolde = DT.Rows[i]["DateOvSolde"].ToString();
                    string DateEchOvSolde = DT.Rows[i]["DateEchOvSolde"].ToString(); 
                    string Montant = DT.Rows[i]["Montant"].ToString();
                    string EtatOvSolde = DT.Rows[i]["EtatOvSolde"].ToString();
                    string DateRecu = DT.Rows[i]["DateRecu"].ToString();
                    string NumRecu = DT.Rows[i]["NumRecu"].ToString();

                    OvSoldeController OSC = new OvSoldeController();
                    OSC.UseOvSolde(ID);
                    msh.ExecuteQuery("insert into ov (NumPayement,DateOV,DateEcheance,MontantAV,Etat,DateRecu,NumRecu) values ('" + inputNumPayement.Text + "','" + DateOvSolde + "','" + DateEchOvSolde + "','" + Montant + "','" + EtatOvSolde + "','" + DateRecu + "','" + NumRecu + "')");
                    if (inputNaturePayement.Text != "Autre frais")
                    {
                        msh.ExecuteQuery("update payement set MontantVerse=MontantVerse+" + decimal.Parse(Montant) + ",Reste=MontantTotal-MontantVerse where NumPayement='" + NumPayement + "'");
                    }

                    msh.LoadData("select * from ov where NumPayement='" + NumPayement + "'", dataViewOV);
                    string query2 = "select * from payement where NumPayement='" + NumPayement + "'";
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
                        AddPayement.inputprixtotal.Text = rdr2["MontantTotal"].ToString();
                        AddPayement.inputprixpayer.Text = rdr2["MontantVerse"].ToString();
                        AddPayement.inputReste.Text = rdr2["Reste"].ToString();

                    }

                    MainWindow mainWindows = (MainWindow)System.Windows.Application.Current.Windows[0];
                    mainWindows.Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
                    mainWindows.Frame.Navigate(AddPayement);
                    mainWindows.currentWindow.Text = "Payement";
                    mainWindows.Activate();
                    this.Close();
                }

            }
        }

      
    }
}
