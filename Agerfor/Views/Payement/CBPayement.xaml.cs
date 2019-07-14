using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Windows.Navigation;
using System;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Agerfor.Views.Payement
{
    /// <summary>
    /// Interaction logic for CBPayement.xaml
    /// </summary>
    public partial class CBPayement : Window
    {
        int NumPayement;
        int NumAttribution;
        AddPayement AddPayement;

        decimal Reste;
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public CBPayement(int NumPayement, decimal Reste, AddPayement AddPayement,int NumAttribution)
        {
            InitializeComponent();
            this.NumPayement = NumPayement;
            this.AddPayement = AddPayement;
            this.NumAttribution = NumAttribution;
            this.Reste = Reste;
            string query = "select * FROM creditb  where NumCB=(select MAX(NumCB)) and NumPayement='" + NumPayement + "'";
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
                inputNumConv.Text = rdr["NumConvBan"].ToString();
                inputDateConv.Text = rdr["DateConv"].ToString();
                inputNomBanque.Text = rdr["NomBanque"].ToString();
                inputBIC.Text = rdr["BIC"].ToString();
                inputMontant.Text = rdr["MontantCb"].ToString();
            }

            if (inputNumConv.Text != "")
            {
                BtnValiderCB.IsEnabled = false;
            }
        }

        private void BtnValiderCB_Click(object sender, RoutedEventArgs e)
        {
            if (decimal.Parse(inputMontant.Text) <= Reste)
            {
                CreditBancaireController CBC = new CreditBancaireController();
                CBC.ValiderCreditBancaire(NumPayement,inputNumConv.Text, inputDateConv.Text, inputNomBanque.Text, inputBIC.Text, decimal.Parse(inputMontant.Text));
                msh.ExecuteQuery("update payement set MontantVerse=MontantVerse+" + decimal.Parse(inputMontant.Text) + ",Reste=MontantTotal-MontantVerse where NumPayement='" + NumPayement + "'");
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
                System.Windows.MessageBox.Show("Le montant CNL est supérieux au montant reste à payé du bien veuillez introduire une valeur inferieur");
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
    }
}
