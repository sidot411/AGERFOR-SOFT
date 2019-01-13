using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;

namespace Agerfor.Views.Programme
{
    /// <summary>
    /// Interaction logic for CreationListeLog.xaml
    /// </summary>
    public partial class CreationListeLog : UserControl
    {
        BiensController BC = new BiensController();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        string RefProgramme = "";
        string NomProjet = "";
        string NumEdd = "";
        string tempnumprojet = "";
        string tempTypeBien = "";
        string tempNumBien = "";
   
        public CreationListeLog(string NomProjet, string refprogramme,string NumEdd)
        {
            InitializeComponent();
            
            this.RefProgramme = refprogramme;
            this.NomProjet = NomProjet;
            this.NumEdd = NumEdd;
            
        }
        private void Page_Loaded(object sender, RoutedEventArgs e)

        {
            msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "' and NumEdd='"+NumEdd+"'", dataViewListeBien);
        }

        private void BtnAjouterBien_Click(object sender, RoutedEventArgs e)
        {
            BC.AjouterBiens(RefProgramme, NomProjet,NumEdd,inputNumIlot.Text,inputTypeBien.Text,inputNumBien.Text,inputNumLot.Text,inputNumBloc.Text,inputNiveau.Text,inputNbrPiece.Text, decimal.Parse(inputSup.Text), decimal.Parse(inputPrixHT.Text), int.Parse(inputTva.Text), decimal.Parse(inputPrixTTC.Text), inputLimiteNord.Text, inputLimiteSud.Text, inputLimiteEst.Text, inputLimiteOuest.Text,inputEtat.Text);
            msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "' and NumEdd='"+NumEdd+"'", dataViewListeBien);  
            inputPrixHT.Text = inputPrixTTC.Text = "0.00";
            inputSup.Text = inputTva.Text = "0";
        }

        private void dataViewListeBien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell1 = dataViewListeBien.SelectedCells[1];
            tempTypeBien = ((TextBlock)cell1.Column.GetCellContent(cell1.Item)).Text;
            DataGridCellInfo cell2 = dataViewListeBien.SelectedCells[2];
            tempNumBien = ((TextBlock)cell2.Column.GetCellContent(cell2.Item)).Text;



            string query = "select * from biens where NumEdd='"+NumEdd+"' and RefProgramme='"+RefProgramme+"' and NomProjet='"+NomProjet+"' and TypeBien='"+tempTypeBien+"' and NumBien='"+tempNumBien+"'";
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
                    inputTypeBien.Text = rdr["TypeBien"].ToString();
                    inputNumBien.Text = rdr["NumBien"].ToString();
                    inputNumLot.Text = rdr["NumLot"].ToString();
                    inputNumBloc.Text = rdr["NumBloc"].ToString();
                    inputNiveau.Text = rdr["Niveau"].ToString();
                    inputNbrPiece.Text = rdr["NbrPiece"].ToString();
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

        private void BtnModifierBien_Click(object sender, RoutedEventArgs e)
        {
            BC.ModifierBien(RefProgramme, NomProjet, NumEdd, inputNumIlot.Text, inputTypeBien.Text, inputNumBien.Text, inputNumLot.Text, inputNumBloc.Text, inputNiveau.Text, inputNbrPiece.Text, decimal.Parse(inputSup.Text), decimal.Parse(inputPrixHT.Text), int.Parse(inputTva.Text), decimal.Parse(inputPrixTTC.Text), inputLimiteNord.Text, inputLimiteSud.Text, inputLimiteEst.Text, inputLimiteOuest.Text, tempNumBien, tempTypeBien);
            msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "' and NumEdd='" + NumEdd + "'", dataViewListeBien);
            inputNumIlot.Text = inputNumLot.Text = inputLimiteNord.Text = inputLimiteOuest.Text = inputLimiteSud.Text = inputLimiteEst.Text = inputTypeBien.Text = inputNumBien.Text = inputNumBloc.Text = inputNiveau.Text = inputNbrPiece.Text = "";
            inputPrixHT.Text = inputPrixTTC.Text = "0.00";
            inputSup.Text = inputTva.Text = "0";


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

        private void BtnSupprimmerBien_Click(object sender, RoutedEventArgs e)
        {
            BC.SupprimerBien(tempNumBien, tempTypeBien, RefProgramme, NomProjet, NumEdd);
            msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "' and NumEdd='" + NumEdd + "'", dataViewListeBien);
            inputNumIlot.Text = inputNumLot.Text = inputLimiteNord.Text = inputLimiteOuest.Text = inputLimiteSud.Text = inputLimiteEst.Text = inputTypeBien.Text = inputNumBien.Text= inputNumBloc.Text=inputNiveau.Text=inputNbrPiece.Text="";
            inputPrixHT.Text = inputPrixTTC.Text = "0.00";
            inputSup.Text = inputTva.Text = "0";
            
        }
    }
}

