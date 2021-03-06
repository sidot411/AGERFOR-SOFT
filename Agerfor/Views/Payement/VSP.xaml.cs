﻿using System;
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
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using Agerfor.VSPReporting;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;

namespace Agerfor.Views.Payement
{
    /// <summary>
    /// Interaction logic for VSP.xaml
    /// </summary>
    public partial class VSP : Window
    {
        int NumP;
        int NumAttribution;
        int tempCodeVSP;
        string tempNumCNL;
        string tempNumFNPOS;
        string tempNumConv;
        string id;
        string username;
        string ip;
        string mac;
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public VSP(int NumP,int NumAttribution, string id,string username)
        {


            InitializeComponent();
            this.NumP = NumP;
            this.NumAttribution = NumAttribution;
            this.id = id;
            this.username = username;
            inputCodeP.Text = NumP.ToString();
            inputEtatVSP.IsEnabled = inputDateEnreg.IsEnabled = inputNumVSP.IsEnabled = false;
            msh.LoadData("select * from vsp where RefP='" + NumP + "'", dataViewVSP);
            msh.FillDropDownList("select NomNotaire from notaire", inputNotaire, "NomNotaire");
        }

        private void BtnDec_Click(object sender, RoutedEventArgs e)
        {
            VSPController VSPC = new VSPController();
            VSPC.AjouterMainLevee(inputDateetabli.Text, inputCodeP.Text, inputEtatVSP.Text,inputNotaire.Text,inputadrNotaire.Text);
            msh.LoadData("select * from vsp where RefP='" + NumP + "'", dataViewVSP);
        }

        private void dataViewML_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewVSP.SelectedCells[0];
            tempCodeVSP = int.Parse(((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text);

            string query = "select * from vsp where CodeVSP='" + tempCodeVSP + "'";
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
                inputCodeVSP.Text = rdr["CodeVSP"].ToString();
                inputDateetabli.Text = rdr["DateEtabliVSP"].ToString();
                inputDateEnreg.Text = rdr["DateVSP"].ToString();
                inputNumVSP.Text = rdr["NumVSP"].ToString();
                inputCodeP.Text = rdr["RefP"].ToString();
                inputEtatVSP.Text = rdr["Etat"].ToString();
                inputNotaire.Text = rdr["NomNotaire"].ToString();
                inputadrNotaire.Text = rdr["AdresseNotaire"].ToString();
            }
            inputDateEnreg.IsEnabled = inputNumVSP.IsEnabled = IsEnabled;
            BtnDec.IsEnabled = inputCodeP.IsEnabled = inputCodeVSP.IsEnabled = false;
        }

        private void BtnNewVSP_Click(object sender, RoutedEventArgs e)
        {
            msh.LoadData("select * from vsp where RefP='" + NumP + "'", dataViewVSP);
            inputCodeVSP.Text = inputDateEnreg.Text = inputNumVSP.Text = inputNotaire.Text = inputadrNotaire.Text = string.Empty;
            inputDateetabli.Text = System.DateTime.Now.ToString();
            inputEtatVSP.Text = "En cours";
            inputDateEnreg.IsEnabled = inputNumVSP.IsEnabled = inputCodeVSP.IsEnabled = false;
        }

        private void BtnValiderML_Click(object sender, RoutedEventArgs e)
        {
            if (inputDateEnreg.Text != "" && inputNumVSP.Text != "")
            {
                VSPController VSPC = new VSPController();
                VSPC.ValidationML(int.Parse(inputNumVSP.Text), inputDateEnreg.Text, tempCodeVSP);
                msh.LoadData("select * from vsp where RefP='" + NumP + "'", dataViewVSP);
            }
            else
            {
                System.Windows.MessageBox.Show("Veuillez remplir la date d'enregsitrement et le numéro dU VSP");
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
            string query3 = "select COUNT(NumConvBan) AS countconv from creditb where NumPayement='" + inputCodeP.Text + "'";

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
            }
            confn.Close();


            VSPViwer VSPV = new VSPViwer(int.Parse(inputCodeVSP.Text), tempNumCNL, tempNumFNPOS,tempNumConv, int.Parse(inputCodeP.Text),id);
            VSPV.Show();

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
