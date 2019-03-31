using System;
using System.Windows;
using System.Windows.Controls;
using Agerfor.Controlers;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Data;
using System.Collections.Generic;
using System.Windows.Media;

namespace Agerfor.Views.Programme

{
    /// <summary>
    /// Interaction logic for CreationListeLog.xaml
    /// </summary>
    public partial class CreationListeLog : UserControl
    {
        
        BiensController BC = new BiensController();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        int RefProgramme = 0;
        int RefProjet = 0;
        int NumEdd = 0;
        string tempnumprojet = "";
        string tempTypeBien = "";
        string tempNumBien = "";
        string tempNumIlot = "";


        public CreationListeLog(int RefProjet, int refprogramme, int NumEdd)
        {
            InitializeComponent();
            msh.FillDropDownList("select Type from typebiens", inputTypeBien, "Type");
            this.RefProgramme = refprogramme;
            this.RefProjet = RefProjet;
            this.NumEdd = NumEdd;

        }
        private void Page_Loaded(object sender, RoutedEventArgs e)

        {
            msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "' and NumEdd='" + NumEdd + "'", dataViewListeBien);
        }

        private void BtnAjouterBien_Click(object sender, RoutedEventArgs e)
        {
           
            try
            {
                MySqlDataReader rdr = null;
                MySqlConnection con = null;
                MySqlCommand cmd = null;

                string Numbien = "";
                List<string> someStringList = new List<string>();
                con = new MySqlConnection(Database.ConnectionString());
                con.Open();
                cmd = new MySqlCommand("select NumBien from biens WHERE RefProgramme='"+RefProgramme+"' and RefProjet='"+RefProjet+"' and NumEdd='"+NumEdd+"' and NumIlot='"+inputNumIlot.Text+"' and Numlot='"+inputNumLot.Text+"' and TypeBien = '"+inputTypeBien.Text+ "' and NumBloc='"+inputNumBloc.Text+"'" , con);
                rdr = cmd.ExecuteReader();
                {
                    while (rdr.Read())
                    {
                      Numbien = rdr.GetString("NumBien");
                      someStringList.Add(Numbien);
                    }
                    con.Close();
                    int i;
                    for (i = 0; i < someStringList.Count; i++)
                    {
                        if (inputNumBien.Text == someStringList[i])
                        {
                            MessageBox.Show("Le num de bien '" + inputNumBien.Text + "' existe déja veuillez introduire un nouveau");
                            inputNumBien.Text = "";
                            inputNumBien.Background = Brushes.LightYellow;


                        }
                      
                    }


                    if (inputNumBien.Text != "")
                    {
                        BC.AjouterBiens(RefProgramme, RefProjet, NumEdd, inputNumIlot.Text, inputTypeBien.Text, inputNumBien.Text, inputNumLot.Text, inputNumBloc.Text, inputNiveau.Text, inputNbrPiece.Text, decimal.Parse(inputSup.Text), decimal.Parse(inputPrixHT.Text), int.Parse(inputTva.Text), decimal.Parse(inputPrixTTC.Text), inputLimiteNord.Text, inputLimiteSud.Text, inputLimiteEst.Text, inputLimiteOuest.Text, inputEtat.Text);
                        inputNumBien.Background = Brushes.White;
                        inputNumIlot.Text = inputNumLot.Text = inputNumBloc.Text =inputNumBien.Text=inputNiveau.Text=inputNbrPiece.Text=inputSup.Text=inputLimiteEst.Text=inputLimiteNord.Text=inputLimiteOuest.Text=inputLimiteSud.Text="";
                        inputPrixHT.Text = "0.00";
                        inputTva.Text = "0";
                        inputPrixTTC.Text = "0.00";
                      
                        msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and NomProjet='" + RefProjet + "' and NumEdd='" + NumEdd + "'", dataViewListeBien);
                        
                       
                    }

                }

            }
            catch (Exception)
            {
               
                
            }
        }           
            
            

        private void dataViewListeBien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewListeBien.SelectedCells[0];
            tempNumIlot = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;
            DataGridCellInfo cell1 = dataViewListeBien.SelectedCells[1];
            tempTypeBien = ((TextBlock)cell1.Column.GetCellContent(cell1.Item)).Text;
            DataGridCellInfo cell2 = dataViewListeBien.SelectedCells[2];
            tempNumBien = ((TextBlock)cell2.Column.GetCellContent(cell2.Item)).Text;



            string query = "select * from biens where NumEdd='" + NumEdd + "' and RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "' and TypeBien='" + tempTypeBien + "' and NumBien='" + tempNumBien + "'";
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
            BC.ModifierBien(RefProgramme, RefProjet, NumEdd, inputNumIlot.Text, inputTypeBien.Text, inputNumBien.Text, inputNumLot.Text, inputNumBloc.Text, inputNiveau.Text, inputNbrPiece.Text, decimal.Parse(inputSup.Text), decimal.Parse(inputPrixHT.Text), int.Parse(inputTva.Text), decimal.Parse(inputPrixTTC.Text), inputLimiteNord.Text, inputLimiteSud.Text, inputLimiteEst.Text, inputLimiteOuest.Text, tempNumBien, tempTypeBien);
            msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "' and NumEdd='" + NumEdd + "'", dataViewListeBien);
          

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
            BC.SupprimerBien(tempNumIlot, inputNumLot.Text, inputNumBloc.Text, inputNiveau.Text, tempNumBien, tempTypeBien, RefProgramme, RefProjet, NumEdd);
            inputNumIlot.Text = inputNumLot.Text = inputNumBloc.Text = inputNumBien.Text = inputNiveau.Text = inputNbrPiece.Text = inputSup.Text = inputLimiteEst.Text = inputLimiteNord.Text = inputLimiteOuest.Text = inputLimiteSud.Text = "";
            inputPrixHT.Text = "0.00";
            inputTva.Text = "0";
            inputPrixTTC.Text = "0.00";
            msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and NomProjet='" + RefProjet + "' and NumEdd='" + NumEdd + "'", dataViewListeBien);
           



        }

        private void SearchSwitch_Click(object sender, RoutedEventArgs e)
        {
            if (SearchSwitch.IsChecked == true)
            {
                inputPrixHT.IsEnabled = inputPrixTTC.IsEnabled = inputTva.IsEnabled = inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = false;
            }
            else
            {
                inputPrixHT.IsEnabled = inputPrixTTC.IsEnabled = inputTva.IsEnabled = inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = true;
            }
        }

        private void inputTypeBien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (inputTypeBien.SelectedValue.ToString() == "Terrain")

            {
                inputNumBloc.IsEnabled = inputNiveau.IsEnabled = inputNbrPiece.IsEnabled = false;
                inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = true  ;
            }

            else

            {
                inputNumBloc.IsEnabled = inputNiveau.IsEnabled = inputNbrPiece.IsEnabled = true;
                inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = false;
            }
        }

    }
}

