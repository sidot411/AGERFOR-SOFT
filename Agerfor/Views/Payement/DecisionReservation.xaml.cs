using Agerfor.Controlers;
using DbConnection.Models;
using MySql.Data.MySqlClient;
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
using System.Windows.Shapes;
using Agerfor.DecisionReporting;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Agerfor.Views.Payement
{
    /// <summary>
    /// Interaction logic for DecisionReservation.xaml
    /// </summary>
    public partial class DecisionReservation : Window
    {
        int NumP;
        int tempCodeDec;
        int NumAttribution;
        string tempNumCNL;
        string tempNumFNPOS;
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public DecisionReservation(int NumP,int NumAttribution)
        {
            InitializeComponent();
            this.NumP = NumP;
            this.NumAttribution = NumAttribution;
            inputCodeP.Text = NumP.ToString();
            inputEtatDec.IsEnabled = inputDateEnreg.IsEnabled = inputNumdecison.IsEnabled = false;
            msh.LoadData("select * from decisionr where RefP='" + NumP + "'", dataViewDec);

        }

        private void BtnDec_Click(object sender, RoutedEventArgs e)
        {

            DecisionReservationController DRC = new DecisionReservationController();
            DRC.AjouterDecision(inputDateetabli.Text, inputCodeP.Text, inputEtatDec.Text);
            msh.LoadData("select * from decisionr where RefP='" + NumP + "'", dataViewDec);

        }

        private void dataViewDec_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewDec.SelectedCells[0];
            tempCodeDec = int.Parse(((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text);

            string query = "select * from decisionr where CodeDec='" + tempCodeDec + "'";
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
                inputCodeDecision.Text = rdr["CodeDec"].ToString();
                inputDateetabli.Text = rdr["DateEtabliDec"].ToString();
                inputDateEnreg.Text = rdr["DateR"].ToString();
                inputNumdecison.Text = rdr["NumR"].ToString();
                inputCodeP.Text = rdr["RefP"].ToString();
                inputEtatDec.Text = rdr["Etat"].ToString();
            }
            inputDateEnreg.IsEnabled = inputNumdecison.IsEnabled = IsEnabled;
            BtnDec.IsEnabled = inputCodeP.IsEnabled = inputCodeDecision.IsEnabled = false;

        }

        private void BtnNewDec_Click(object sender, RoutedEventArgs e)
        {
            msh.LoadData("select * from decisionr where RefP='" + NumP + "'", dataViewDec);
            inputCodeDecision.Text = inputDateEnreg.Text = inputNumdecison.Text = string.Empty;
            inputDateetabli.Text = System.DateTime.Now.ToString();
            inputEtatDec.Text = "En cours";
            inputDateEnreg.IsEnabled = inputNumdecison.IsEnabled = inputCodeDecision.IsEnabled = false;


        }

        private void BtnValiderDec_Click(object sender, RoutedEventArgs e)
        {
            if (inputDateEnreg.Text != "" && inputNumdecison.Text != "")
            {
                DecisionReservationController DRC = new DecisionReservationController();
                DRC.ValidationDecision(int.Parse(inputNumdecison.Text), inputDateEnreg.Text, int.Parse(inputCodeP.Text));
                msh.LoadData("select * from decisionr where RefP='" + NumP + "'", dataViewDec);
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez remplir la date d'enregsitrement et le numéro de la décision");
            }

        }

        private void BtnImpriDec_Click(object sender, RoutedEventArgs e)
        {
            string query = "select COUNT(NumDeci) AS countcnl from cnl where NumPayement = '" + inputCodeP.Text + "'";
            string query2 = "select COUNT(NumFNPOS) AS countfnpos from fnpos where NumPayement='" + inputCodeP.Text + "'";
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
            }
            confn.Close();

            DecisionViwer DV = new DecisionViwer(int.Parse(inputCodeDecision.Text), tempNumCNL, tempNumFNPOS);
            DV.Show();


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
