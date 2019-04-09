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
        string TypeBien;
        string tempTypeBien = "";
        string tempNumLot = "";
        string tempNumIlot = "";
        string typevente;
        decimal CoutFoncierTTC;
        decimal prixm2;


        public CreationListeLog(int RefProjet, int refprogramme, int NumEdd, string TypeBien,string typevente, decimal CoutFoncierTTC, decimal prixm2)
        {
            InitializeComponent();

            inputPrixHT.IsEnabled =  false;
            msh.FillDropDownList("select ValeurTva from tva", inputTva, "ValeurTva");
            this.RefProgramme = refprogramme;
            this.RefProjet = RefProjet;
            this.NumEdd = NumEdd;
            this.TypeBien = TypeBien;
            this.typevente = typevente;
            this.CoutFoncierTTC = CoutFoncierTTC;
            this.prixm2 = prixm2;
            msh.FillDropDownList("select NumIlot from listeilot where RefProjet='" + RefProjet + "'",inputNumIlot,"NumIlot");

            if(TypeBien=="CNL" || TypeBien == "LPA" || TypeBien == "LSP" || TypeBien == "Promotionnel Semi Collectif" || TypeBien == "Promotionnel Individuel" || TypeBien == "Promotionnel Collectif")
            {
                inputTypeBien.Text = "Logement";
                inputTypeBien.IsEnabled = false;
            }
            
            if (inputTypeBien.Text == "Terrain")

            {
                inputNumBloc.IsEnabled = inputNiveau.IsEnabled = inputNbrPiece.IsEnabled = false;
                inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = true;
            }

            else

            {
                inputNumBloc.IsEnabled = inputNiveau.IsEnabled = inputNbrPiece.IsEnabled = true;
                inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = false;
            }
            if(typevente== "Vente par unité")
            {
                inputPrixHT.IsEnabled = inputTva.IsEnabled = false;
            }
            else
            {
                inputTva.IsEnabled = true;
                inputPrixHT.Text = prixm2.ToString();

            }

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

                string Numlot = "";
                List<string> someStringList = new List<string>();
                con = new MySqlConnection(Database.ConnectionString());
                con.Open();
                cmd = new MySqlCommand("select Numlot from biens WHERE RefProgramme='"+RefProgramme+"' and RefProjet='"+RefProjet+"' and NumEdd='"+NumEdd+"' and NumIlot='"+inputNumIlot.Text+"' and TypeBien = '"+inputTypeBien.Text+ "' and NumBloc='"+inputNumBloc.Text+"'" , con);
                rdr = cmd.ExecuteReader();
                {
                    while (rdr.Read())
                    {
                      Numlot = rdr.GetString("Numlot");
                      someStringList.Add(Numlot);
                    }
                    con.Close();
                    int i;
                    for (i = 0; i < someStringList.Count; i++)
                    {
                        if (inputNumLot.Text == someStringList[i])
                        {
                            MessageBox.Show("Le lot '" + inputNumLot.Text + "' existe déja veuillez introduire un nouveau");
                            inputNumLot.Text = "";
                            inputNumLot.Background = Brushes.LightYellow;


                        }
                      
                    }


                    if (inputNumLot.Text != "")
                    {
                        BC.AjouterBiens(RefProgramme, RefProjet, NumEdd, inputNumIlot.Text, inputTypeBien.Text , inputNumLot.Text, inputNumBloc.Text, inputNiveau.Text, inputNbrPiece.Text, decimal.Parse(inputSurH.Text),decimal.Parse(inputSurU.Text), decimal.Parse(inputPrixHT.Text), int.Parse(inputTva.Text), decimal.Parse(inputPrixTTC.Text), inputLimiteNord.Text, inputLimiteSud.Text, inputLimiteEst.Text, inputLimiteOuest.Text, inputEtat.Text);
                        inputNumLot.Background = Brushes.White;
                        inputNumIlot.Text = inputNumLot.Text = inputNumBloc.Text = inputNiveau.Text=inputNbrPiece.Text=inputSurH.Text = inputSurU.Text = inputLimiteEst.Text=inputLimiteNord.Text=inputLimiteOuest.Text=inputLimiteSud.Text="";
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
            tempNumLot = ((TextBlock)cell1.Column.GetCellContent(cell1.Item)).Text;
            DataGridCellInfo cell2 = dataViewListeBien.SelectedCells[2];
            tempTypeBien = ((TextBlock)cell2.Column.GetCellContent(cell2.Item)).Text;



            string query = "select * from biens where NumEdd='" + NumEdd + "' and RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "' and TypeBien='" + tempTypeBien + "' and Numlot='" + tempNumLot + "'";
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
                    inputNumLot.Text = rdr["Numlot"].ToString();
                    inputNumBloc.Text = rdr["NumBloc"].ToString();
                    inputNiveau.Text = rdr["Niveau"].ToString();
                    inputNbrPiece.Text = rdr["NbrPiece"].ToString();
                    inputSurH.Text = rdr["SurH"].ToString();
                    inputSurU.Text = rdr["SurU"].ToString();
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
            BC.ModifierBien(RefProgramme, RefProjet, NumEdd, inputNumIlot.Text, inputTypeBien.Text, inputNumLot.Text, inputNumBloc.Text, inputNiveau.Text, inputNbrPiece.Text, decimal.Parse(inputSurH.Text), decimal.Parse(inputSurU.Text), decimal.Parse(inputPrixHT.Text), int.Parse(inputTva.Text), decimal.Parse(inputPrixTTC.Text), inputLimiteNord.Text, inputLimiteSud.Text, inputLimiteEst.Text, inputLimiteOuest.Text,tempNumLot, tempTypeBien);
            msh.LoadData("select * from biens where RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "' and NumEdd='" + NumEdd + "'", dataViewListeBien);
          

        }
        private void inputPrixHT_TextChanged(object sender, TextChangedEventArgs e)
        {
/*
            try
            {
                inputPrixTTC.Text = ((decimal.Parse(inputPrixHT.Text) * ((decimal.Parse(inputSurH.Text) + decimal.Parse(inputSurU.Text)))) + ((decimal.Parse(inputPrixHT.Text) * (decimal.Parse(inputSurH.Text) + decimal.Parse(inputSurU.Text))) * (decimal.Parse(inputTva.Text)) / 100) + CoutFoncierTTC).ToString();

            }
            catch (Exception)
            {

            }*/
        }
/*
        private void inputTva_TextChanged(object sender, TextChangedEventArgs e)
        {

            try
            {
                inputPrixTTC.Text = (decimal.Parse(inputPrixHT.Text) + (decimal.Parse(inputPrixHT.Text) * (decimal.Parse(inputTva.Text)) / 100)).ToString();
            }
            catch (Exception)
            {

            }
        }*/

        private void BtnSupprimmerBien_Click(object sender, RoutedEventArgs e)
        {
            BC.SupprimerBien(tempNumIlot, inputNumLot.Text, inputNumBloc.Text, inputNiveau.Text, tempNumLot, tempTypeBien, RefProgramme, RefProjet, NumEdd);
            inputNumIlot.Text = inputNumLot.Text = inputNumBloc.Text = inputNiveau.Text = inputNbrPiece.Text = inputSurH.Text = inputSurU.Text =  inputLimiteEst.Text = inputLimiteNord.Text = inputLimiteOuest.Text = inputLimiteSud.Text = "";
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

     


        private void inputTva_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                inputPrixTTC.Text = ((((decimal.Parse(inputSurH.Text) + decimal.Parse(inputSurU.Text)) * decimal.Parse(inputPrixHT.Text)) + (((decimal.Parse(inputSurH.Text) + decimal.Parse(inputSurU.Text)) * decimal.Parse(inputPrixHT.Text))*(decimal.Parse(inputTva.SelectedValue.ToString())/100)))+CoutFoncierTTC).ToString();
            }
            catch (Exception)
            {

            }
        }

        private void inputSurH_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {

            try
            {
                inputPrixTTC.Text = ((((decimal.Parse(inputSurH.Text) + decimal.Parse(inputSurU.Text)) * decimal.Parse(inputPrixHT.Text)) + (((decimal.Parse(inputSurH.Text) + decimal.Parse(inputSurU.Text)) * decimal.Parse(inputPrixHT.Text)) * (decimal.Parse(inputTva.SelectedValue.ToString()) / 100))) + CoutFoncierTTC).ToString();
            }
            catch (Exception)
            {

            }

        }
    }
}

