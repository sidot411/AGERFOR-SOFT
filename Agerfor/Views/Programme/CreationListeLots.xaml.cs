using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.IO;
using System.Diagnostics;
using System.Windows.Forms;
using System.Windows.Navigation;
using MaterialDesignThemes.Wpf;
using System.Data;
using System.Windows.Media;

namespace Agerfor.Views.Programme
{
    /// <summary>
    /// Interaction logic for CreationListeLots.xaml
    /// </summary>
    public partial class CreationListeLots : System.Windows.Controls.UserControl
    {
        LotController LC = new LotController();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        string RefProgramme = "";
        string NomProjet = "";
        string tempnumprojet = "";
        string tempNumLot = "";
        string NumCahierCharge = "";

        public CreationListeLots(string NomProjet, string refprogramme, string NumCahierCharge)
        {
            InitializeComponent();

            this.RefProgramme = refprogramme;
            this.NomProjet = NomProjet;
            this.NumCahierCharge = NumCahierCharge;
        }
        
        private void Page_Loaded(object sender, RoutedEventArgs e)

        {
           
            msh.LoadData("select * from lot where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "' and NumCC='" + NumCahierCharge + "'", dataViewListeLot);
            
        }

        private void BtnAjouterLots_Click(object sender, RoutedEventArgs e)
        {
            LC.Ajouterlot(RefProgramme, NomProjet, NumCahierCharge, inputNumIlot.Text, inputNumLot.Text, decimal.Parse(inputSup.Text), decimal.Parse(inputPrixHT.Text), int.Parse(inputTva.Text), decimal.Parse(inputPrixTTC.Text), inputLimiteNord.Text, inputLimiteSud.Text, inputLimiteEst.Text, inputLimiteOuest.Text, inputEtat.Text);
            msh.LoadData("select * from lot where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "' and NumCC='" + NumCahierCharge + "'", dataViewListeLot);
            inputNumIlot.Text = inputNumLot.Text = inputLimiteNord.Text = inputLimiteOuest.Text = inputLimiteSud.Text = inputLimiteEst.Text = "";
            inputPrixHT.Text = inputPrixTTC.Text = "0.00";
            inputSup.Text = inputTva.Text = "0";
        }

        private void dataViewListeLot_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewListeLot.SelectedCells[1];
            tempNumLot = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;


            string query = "select * from lot where NumLot='" + tempNumLot + "' and RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "' and NumCC='" + NumCahierCharge + "'";
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
                    inputNumIlot.Text = rdr["NumIlot"].ToString();
                    inputNumLot.Text = rdr["NumLot"].ToString();
                    inputSup.Text = rdr["Sup"].ToString();
                    inputPrixHT.Text = rdr["PrixHT"].ToString();
                    inputTva.Text = rdr["Tva"].ToString();
                    inputPrixTTC.Text = rdr["PrixTTC"].ToString();
                    inputLimiteNord.Text = rdr["LimiteNord"].ToString();
                    inputLimiteSud.Text = rdr["LimiteSud"].ToString();
                    inputLimiteEst.Text = rdr["LimiteEst"].ToString();
                    inputLimiteOuest.Text = rdr["LimiteOuest"].ToString();
                    oneTime = false;
                }
            }
        }

        private void BtnModifierLots_Click(object sender, RoutedEventArgs e)
        {
            LC.Modifierlot(RefProgramme, NomProjet, NumCahierCharge, inputNumIlot.Text, inputNumLot.Text, decimal.Parse(inputSup.Text), decimal.Parse(inputPrixHT.Text), int.Parse(inputTva.Text), decimal.Parse(inputPrixTTC.Text), inputLimiteNord.Text, inputLimiteSud.Text, inputLimiteEst.Text, inputLimiteOuest.Text, tempNumLot, inputEtat.Text);
            msh.LoadData("select * from lot where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "' and NumCC='" + NumCahierCharge + "'", dataViewListeLot);
            inputNumIlot.Text = inputNumLot.Text = inputLimiteNord.Text = inputLimiteOuest.Text = inputLimiteSud.Text = inputLimiteEst.Text = "";
            inputPrixHT.Text = inputPrixTTC.Text = "0.00";
            inputSup.Text = inputTva.Text = "0";
        }

        private void BtnSupprimmerLots_Click(object sender, RoutedEventArgs e)
        {
            LC.SupprimerLot(tempNumLot, RefProgramme, NomProjet, NumCahierCharge);
            msh.LoadData("select * from lot where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "' and NumCC='" + NumCahierCharge + "'", dataViewListeLot);
            inputNumIlot.Text = inputNumLot.Text = inputLimiteNord.Text = inputLimiteOuest.Text = inputLimiteSud.Text = inputLimiteEst.Text = "";
            inputPrixHT.Text = inputPrixTTC.Text = "0.00";
            inputTva.Text = inputSup.Text = "0";
        }

        private void inputPrixHT_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                inputPrixTTC.Text = (decimal.Parse(inputPrixHT.Text) + (decimal.Parse(inputPrixHT.Text) * (decimal.Parse(inputTva.Text)) / 100)).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void inputTva_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                inputPrixTTC.Text = (decimal.Parse(inputPrixHT.Text) + (decimal.Parse(inputPrixHT.Text) * (decimal.Parse(inputTva.Text)) / 100)).ToString();
            }
            catch (Exception)
            {

            }
        }

       
   
        }
    }


    
