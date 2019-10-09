using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Agerfor.Controlers;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using Agerfor.MainLevéeReporting;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Agerfor.Views.Payement
{
    /// <summary>
    /// Interaction logic for MainLeve.xaml
    /// </summary>
    public partial class MainLeve : Window
    {
        int NumP;
        int tempCodeML;
        string tempNumCNL;
        string tempNumFNPOS;
        string tempNumConv;
        string id;
        string username;
        string ip;
        string mac;
        int NumAttribution;
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public MainLeve(int NumP, int NumAttribution, string id,string username)
        {
            InitializeComponent();
            this.NumP = NumP;
            this.NumAttribution = NumAttribution;
            this.id = id;
            this.username = username;
            inputCodeP.Text = NumP.ToString();
            inputEtatML.IsEnabled = inputDateEnreg.IsEnabled = inputNumML.IsEnabled = false;
            msh.LoadData("select * from mainlevee where RefP='" + NumP + "'", dataViewML);
            msh.FillDropDownList("select NomNotaire from notaire", inputNotaire, "NomNotaire");
        }

        private void BtnDec_Click(object sender, RoutedEventArgs e)
        {
            MainLeveeController MLC = new MainLeveeController();
            MLC.AjouterMainLevee(inputDateetabli.Text, inputCodeP.Text, inputEtatML.Text,inputNotaire.Text,inputadrNotaire.Text);
            msh.LoadData("select * from mainlevee where RefP='" + NumP + "'", dataViewML);
        }

        private void dataViewML_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewML.SelectedCells[0];
            tempCodeML = int.Parse(((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text);

            string query = "select * from mainlevee where CodeML='" + tempCodeML + "'";
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
                inputCodeML.Text = rdr["CodeML"].ToString();
                inputDateetabli.Text = rdr["DateEtabliML"].ToString();
                inputDateEnreg.Text = rdr["DateML"].ToString();
                inputNumML.Text = rdr["NumML"].ToString();
                inputCodeP.Text = rdr["RefP"].ToString();
                inputEtatML.Text = rdr["Etat"].ToString();
                inputNotaire.Text = rdr["NomNotaire"].ToString();
                inputadrNotaire.Text = rdr["AdresseNotaire"].ToString();
            }
            inputDateEnreg.IsEnabled = inputNumML.IsEnabled = IsEnabled;
            BtnDec.IsEnabled = inputCodeP.IsEnabled = inputCodeML.IsEnabled = false;
        }

        private void BtnNewDec_Click(object sender, RoutedEventArgs e)
        {
            msh.LoadData("select * from mainlevee where RefP='" + NumP + "'", dataViewML);
            inputCodeML.Text = inputDateEnreg.Text = inputNumML.Text = string.Empty;
            inputDateetabli.Text = System.DateTime.Now.ToString();
            inputEtatML.Text = "En cours";
            inputDateEnreg.IsEnabled = inputNumML.IsEnabled = inputCodeML.IsEnabled = false;
        }

        private void BtnValiderML_Click(object sender, RoutedEventArgs e)
        {
            if (inputDateEnreg.Text != "" && inputNumML.Text != "")
            {
                MainLeveeController MLC = new MainLeveeController();
                MLC.ValidationML(int.Parse(inputNumML.Text), inputDateEnreg.Text, int.Parse(inputCodeP.Text));
                msh.LoadData("select * from mainlevee where RefP='" + NumP + "'", dataViewML);
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez remplir la date d'enregsitrement et le numéro de la main levée");
            }

        }

        private void BtnImpriML_Click(object sender, RoutedEventArgs e)
        {
            string query4 = "select IP,MAC from users where UserName='" + username + "' and IdUser='" + id + "'";
            MySqlDataReader rdr = null;
            MySqlConnection con = null;
            MySqlCommand cmd = null;
            con = new MySqlConnection(Database.ConnectionString());
            con.Open();
            cmd = new MySqlCommand(query4);
            cmd.Connection = con;
            rdr = cmd.ExecuteReader();
            bool oneTime4 = true;
            while (rdr.Read())
            {
                ip = rdr["IP"].ToString();
                mac = rdr["MAC"].ToString();

            }

            if (GetIpAdress.GetLocalIPAddress() != ip)
            {
                msh.ExecuteQuery("update users set IP='" + GetIpAdress.GetLocalIPAddress() + "' where IdUser='" + id + "'");
            }

            else if (GetMacAdresse.GetMacAdress() != mac)
            {
                msh.ExecuteQuery("update users set MAC='" + GetMacAdresse.GetMacAdress() + "' where IdUser='" + id + "'");
            }




            string query = "select COUNT(NumDeci) AS countcnl from cnl where NumPayement = '" + inputCodeP.Text + "'";
            string query2 = "select COUNT(NumFNPOS) AS countfnpos from fnpos where NumPayement='" + inputCodeP.Text + "'";
            string query3 = "select COUNT(NumConvBan) AS countconv from creditb where NumPayement='" + inputCodeP.Text + "' AND NumConvBan!=''";

            MySqlDataReader rdrcnl = null;
            MySqlConnection concnl = null;
            MySqlCommand cmdcnl = null;
            concnl = new MySqlConnection(Database.ConnectionString());
            concnl.Open();
            cmdcnl = new MySqlCommand(query);
            cmdcnl.Connection = concnl;
            rdrcnl = cmdcnl.ExecuteReader();
            bool oneTime = true;
            while (rdrcnl.Read())
            {
                tempNumCNL = rdrcnl["countcnl"].ToString();
                System.Windows.MessageBox.Show(tempNumCNL);
            }
            concnl.Close();
            MySqlDataReader rdrfn = null;
            MySqlConnection confn = null;
            MySqlCommand cmdfn = null;
            confn = new MySqlConnection(Database.ConnectionString());
            confn.Open();
            cmdfn = new MySqlCommand(query2);
            cmdfn.Connection = confn;
            rdrfn = cmdfn.ExecuteReader();
            bool oneTime2 = true;
            while (rdrfn.Read())
            {
                tempNumFNPOS = rdrfn["countfnpos"].ToString();
                System.Windows.MessageBox.Show(tempNumFNPOS);
            }
            confn.Close();
            MySqlDataReader rdrconv = null;
            MySqlConnection conconv = null;
            MySqlCommand cmdconv = null;
            conconv = new MySqlConnection(Database.ConnectionString());
            conconv.Open();
            cmdconv = new MySqlCommand(query3);
            cmdconv.Connection = conconv;
            rdrconv = cmdconv.ExecuteReader();
            bool oneTime3 = true;
            while (rdrconv.Read())
            {
                tempNumConv = rdrconv["countconv"].ToString();
                System.Windows.MessageBox.Show(tempNumConv);
            }
            confn.Close();

            MainLeveeViewer ML = new MainLeveeViewer(int.Parse(inputCodeML.Text), tempNumCNL, tempNumFNPOS,tempNumConv, int.Parse(inputCodeP.Text),id);
            ML.Show();

        }

        private void inputNotaire_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string query = "select AdresseNotaire from notaire where NomNotaire='" + inputNotaire.SelectedValue + "'";
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
                inputadrNotaire.Text = rdr["AdresseNotaire"].ToString();
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
