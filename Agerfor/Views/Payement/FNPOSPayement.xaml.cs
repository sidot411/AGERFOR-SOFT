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


namespace Agerfor.Views.Payement
{
    /// <summary>
    /// Interaction logic for FNPOSPayement.xaml
    /// </summary>
    public partial class FNPOSPayement : Window
    {
        int NumPayement;
        AddPayement AddPayement;
        decimal Reste;
        int NumAttribution;
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public FNPOSPayement(int NumPayement, decimal Reste, AddPayement AddPayement, int NumAttribution)
        {
            InitializeComponent();
            this.NumPayement = NumPayement;
            this.NumAttribution = NumAttribution;
            this.Reste = Reste;
            this.AddPayement = AddPayement;
            string query = "select * FROM fnpos where NumFNPOS=(select MAX(NumFNPOS)) and NumPayement='" + NumPayement + "'";
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
                inputDeciF.Text = rdr["NumDeciF"].ToString();
                inputDateDeciF.Text = rdr["DateDeciF"].ToString();
                inputMontantFNPOS.Text = rdr["MontantFNPOS"].ToString();
                
            }

            if (inputDeciF.Text != "")
            {
                BtnValiderFNPOS.IsEnabled = false;
            }
        }

        private void BtnValiderFNPOS_Click(object sender, RoutedEventArgs e)
        {

            if (decimal.Parse(inputMontantFNPOS.Text) <= Reste)
            {
                FNPOSController FNPOSC = new FNPOSController();
                FNPOSC.AjouterFNPOS(NumPayement, inputDeciF.Text, inputDateDeciF.Text, decimal.Parse(inputMontantFNPOS.Text));
                msh.ExecuteQuery("update payement set MontantVerse=MontantVerse+" + decimal.Parse(inputMontantFNPOS.Text) + ",Reste=MontantTotal-MontantVerse where NumPayement='" + NumPayement + "'");
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
                MainWindow mainWindows = (MainWindow)System.Windows.Application.Current.Windows[0];
                mainWindows.Frame.NavigationUIVisibility = NavigationUIVisibility.Hidden;
                mainWindows.Frame.Navigate(AddPayement);
                mainWindows.currentWindow.Text = "Payement";
                mainWindows.Activate();
                this.Close();
            }
            else
            {
                System.Windows.MessageBox.Show("Le montant FNPOS est supérieux au montant reste à payé du bien veuillez introduire une valeur inferieur");
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
                destinationFolder = AppDomain.CurrentDomain.BaseDirectory + @"Attribution\" + NumAttribution.ToString() + @"\" + theDirectory + @"\" + System.IO.Path.GetFileName(openFileDialog1.FileName);
                System.Windows.Forms.MessageBox.Show("operation réussi avec succès");
                if (File.Exists(destinationFolder))
                {
                    File.Delete(destinationFolder);
                }
                File.Copy(fileName, System.IO.Path.Combine(System.IO.Path.GetDirectoryName(fileName), destinationFolder));
                System.Windows.MessageBox.Show(destinationFolder.ToString());
            }
            else
            {
                System.Windows.MessageBox.Show("aucun fichier selectionner");
            }
        }

    }
}
