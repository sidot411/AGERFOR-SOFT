﻿
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Agerfor.Controlers;
using WPFAutoCompleteTextbox;

namespace Agerfor.Views.Attribution
{
    /// <summary>
    /// Interaction logic for AddAttribution.xaml
    /// </summary>
    public partial class AddAttribution : Page
    {
        int tempNumAttribution;
        string NumAttribution = "";
        string DateAttribution = "";
        string NumClient = "";
        string NumProjet = "";
        string NumPRogramme = "";
        string NumIlot = "";
        string Numlot = "";
        string TypeBien = "";
        string NumBloc = "";
        string NatureProgramme = "";
        string Idbiens = "";
        int tempIdbien;
        int tempIdbien2;
        decimal tempMontantVers;
        decimal tempreste;
        int tempNumPayement;

        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public AddAttribution(string NumAttribution, string DateAttribution, string NumClient, string NumProjet, string NumProgramme, string NumIlot, string Numlot, string TypeBien, string NumBloc, string NatureProgramme, string Idbiens)
        {
            InitializeComponent();
            this.NumAttribution = NumAttribution;
            this.DateAttribution = DateAttribution;
            this.NumClient = NumClient;
            this.NumProjet = NumProjet;
            this.NumPRogramme = NumProgramme;
            this.NumIlot = NumIlot;
            this.Numlot = Numlot;
            this.TypeBien = TypeBien;
            this.NumBloc = NumBloc;
            this.Idbiens = Idbiens;

            this.NatureProgramme = NatureProgramme;


            inputEtat.SelectedIndex = 1;
            inputEtat.IsEnabled = false;

            if (NumAttribution != "")
            {

                if (NatureProgramme == "Logement")
                {
                    //Clipboard.SetText("Select * from client, projet, programme, biens, attribution where NumA='" + NumAttribution + "' and DateAttribution=STR_TO_DATE('" + DateAttribution + "','%d/%m/%Y') and attribution.NumClient='" + NumClient + "' and attribution.NumProjet='" + NumProjet + "' and attribution.NumProgramme='" + NumProgramme + "' and 	attribution.NumIlot='" + NumIlot + "' and attribution.Numlot='" + Numlot + "' and attribution.TypeBien='" + TypeBien + "' and attribution.NumBloc='" + NumBloc + "' and attribution.IdBien='"+Idbiens+"' and attribution.NumClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumIlot = biens.NumIlot AND attribution.Numlot = biens.Numlot AND attribution.TypeBien = biens.TypeBien AND attribution.NumBloc = biens.NumBloc AND biens.NumEdd = (SELECT MAX(NumEdd) FROM biens where projet.RefProjet=biens.RefProjet and programme.RefProgramme)");

                    string queryload = "Select *,biens.LimiteNord AS LimiteNordB ,biens.LimiteSud AS LimiteSudB ,biens.LimiteEst AS LimiteEstB,biens.LimiteOuest AS LimiteOuestB from client, projet, programme, biens, attribution where NumA='" + NumAttribution + "' and DateAttribution=STR_TO_DATE('" + DateAttribution + "','%d/%m/%Y') and attribution.NumClient='" + NumClient + "' and attribution.NumProjet='" + NumProjet + "' and attribution.NumProgramme='" + NumProgramme + "' and 	attribution.NumIlot='" + NumIlot + "' and attribution.Numlot='" + Numlot + "' and attribution.TypeBien='" + TypeBien + "' and attribution.NumBloc='" + NumBloc + "' and attribution.NumClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumIlot = biens.NumIlot AND attribution.Numlot = biens.Numlot AND attribution.TypeBien = biens.TypeBien AND attribution.NumBloc = biens.NumBloc AND biens.NumEdd = (SELECT MAX(NumEdd) FROM biens where projet.RefProjet=biens.RefProjet and programme.RefProgramme)";
                    MySqlDataReader rdrL = null;
                    MySqlConnection conL = null;
                    MySqlCommand cmdL = null;
                    conL = new MySqlConnection(Database.ConnectionString());
                    conL.Open();
                    cmdL = new MySqlCommand(queryload);
                    cmdL.Connection = conL;
                    rdrL = cmdL.ExecuteReader();
                    bool oneTimeL = true;
                    while (rdrL.Read())
                    {
                        inputNumAttri.Text = rdrL["NumA"].ToString();
                        inputDateAttribution.Text = rdrL["DateAttribution"].ToString();
                        inputNumClient.Text = rdrL["NumClient"].ToString();
                        inputNomClient.Text = rdrL["Nom"].ToString();
                        inputPrenomClient.Text = rdrL["Prenom"].ToString();
                        inputDateNaissance.Text = rdrL["DateNaissance"].ToString();
                        inputNumCNI.Text = rdrL["Cni"].ToString();
                        inputNumProjet.Text = rdrL["NumProjet"].ToString();
                        inputNomProjet.Text = rdrL["NomProjet"].ToString();
                        inputNumProgramme.Text = rdrL["NumProgramme"].ToString();
                        inputNomProgramme.Text = rdrL["NomProgramme"].ToString();
                        inputNumIlot.Text = rdrL["NumIlot"].ToString();
                        inputNumLot.Text = rdrL["Numlot"].ToString();
                        inputNumBloc.Text = rdrL["NumBloc"].ToString();
                        inputNiveau.Text = rdrL["Niveau"].ToString();
                        inputNbrPiece.Text = rdrL["NbrPiece"].ToString();
                        inputTypeBien.Text = rdrL["TypeBien"].ToString();
                        inputSurH.Text = rdrL["SurH"].ToString();
                        inputSurU.Text = rdrL["SurU"].ToString();
                        inputPrixHT.Text = rdrL["PrixHT"].ToString();
                        inputTva.Text = rdrL["Tva"].ToString();
                        inputPrixTTC.Text = rdrL["PrixTTC"].ToString();
                        inputLimiteEst.Text = rdrL["LimiteEstB"].ToString();
                        inputLimiteNord.Text = rdrL["LimiteNordB"].ToString();
                        inputLimiteOuest.Text = rdrL["LimiteOuestB"].ToString();
                        inputLimiteSud.Text = rdrL["LimiteSudB"].ToString();
                        inputEtat.Text = rdrL["Etat"].ToString();
                        inputNatureProgramme.Text = rdrL["NatureProgramme"].ToString();
                        inputTypeProgramme.Text = rdrL["TypeProgramme"].ToString();
                        inputDateDLE.Text = rdrL["DateDLE"].ToString();
                        inputDateDLR.Text = rdrL["DateDLR"].ToString();
                        inputRefDL.Text = rdrL["RefDL"].ToString();
                        tempIdbien2 = int.Parse(rdrL["Id"].ToString());
                        tempIdbien = int.Parse(rdrL["Id"].ToString());

                    }
                    BtnAttribuerBien.IsEnabled = false;
                }

                else
                {
                    string queryload = "Select * from client, projet, programme, lot, attribution where NumA='" + NumAttribution + "' and DateAttribution='" + DateAttribution + "' and attribution.NumClient='" + NumClient + "' and attribution.NumProjet='" + NumProjet + "' and attribution.NumProgramme='" + NumProgramme + "' and 	attribution.NumIlot='" + NumIlot + "' and attribution.Numlot='" + Numlot + "'  and attribution.NumClient = client.NumClient AND attribution.NumProjet = projet.RefProjet AND attribution.NumProgramme = programme.RefProgramme AND attribution.NumIlot = lot.NumIlot AND attribution.Numlot = lot.Numlot AND lot.NumCC = (SELECT MAX(NumCC) FROM lot where projet.NomProjet=lot.NomPRojet and programme.RefProgramme=lot.RefProgramme)";
                    MySqlDataReader rdrL = null;
                    MySqlConnection conL = null;
                    MySqlCommand cmdL = null;
                    conL = new MySqlConnection(Database.ConnectionString());
                    conL.Open();
                    cmdL = new MySqlCommand(queryload);
                    cmdL.Connection = conL;
                    rdrL = cmdL.ExecuteReader();
                    bool oneTimeL = true;
                    while (rdrL.Read())
                    {
                        inputNumAttri.Text = rdrL["NumA"].ToString();
                        inputDateAttribution.Text = rdrL["DateAttribution"].ToString();
                        inputNumClient.Text = rdrL["NumClient"].ToString();
                        inputNomClient.Text = rdrL["Nom"].ToString();
                        inputPrenomClient.Text = rdrL["Prenom"].ToString();
                        inputDateNaissance.Text = rdrL["DateNaissance"].ToString();
                        inputNumCNI.Text = rdrL["Cni"].ToString();
                        inputNumProjet.Text = rdrL["NumProjet"].ToString();
                        inputNomProjet.Text = rdrL["NomProjet"].ToString();
                        inputNumProgramme.Text = rdrL["NumProgramme"].ToString();
                        inputNomProgramme.Text = rdrL["NomProgramme"].ToString();
                        inputNumIlot.Text = rdrL["NumIlot"].ToString();
                        inputNumLot.Text = rdrL["Numlot"].ToString();
                        inputSurH.Text = rdrL["SurH"].ToString();
                        inputSurU.Text = rdrL["SurU"].ToString();
                        inputPrixHT.Text = rdrL["PrixHT"].ToString();
                        inputTva.Text = rdrL["Tva"].ToString();
                        inputPrixTTC.Text = rdrL["PrixTTC"].ToString();
                        inputLimiteEst.Text = rdrL["LimiteEst"].ToString();
                        inputLimiteNord.Text = rdrL["LimiteNord"].ToString();
                        inputLimiteOuest.Text = rdrL["LimiteOuest"].ToString();
                        inputLimiteSud.Text = rdrL["LimiteSud"].ToString();
                        inputEtat.Text = rdrL["Etat"].ToString();
                        inputNumBloc.IsEnabled = false;
                        inputNiveau.IsEnabled = false;
                        inputNbrPiece.IsEnabled = false;



                    }
                    BtnAttribuerBien.IsEnabled = false;
                }
            }

            else
            {

                string query = "select MAX(NumA)+1 AS Num from attribution;";
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
                    if (rdr["Num"].ToString() == "")
                    {
                        inputNumAttri.Text = "1";
                    }
                    else
                    {
                        inputNumAttri.Text = rdr["Num"].ToString();
                    }
                }
                inputNumAttri.IsEnabled = false;


                string query2 = "Select NumClient from client";
                MySqlDataReader rdr2 = null;
                MySqlConnection con2 = null;
                MySqlCommand cmd2 = null;
                con2 = new MySqlConnection(Database.ConnectionString());
                con2.Open();
                cmd2 = new MySqlCommand(query2);
                cmd2.Connection = con2;
                rdr2 = cmd2.ExecuteReader();

                while (rdr2.Read())
                {
                    inputNumClient.AddItem(new AutoCompleteEntry(rdr2["NumClient"].ToString(), null));
                }

                string query3 = "Select * from projet";
                MySqlDataReader rdr3 = null;
                MySqlConnection con3 = null;
                MySqlCommand cmd3 = null;
                con3 = new MySqlConnection(Database.ConnectionString());
                con3.Open();
                cmd3 = new MySqlCommand(query3);
                cmd3.Connection = con3;
                rdr3 = cmd3.ExecuteReader();

                while (rdr3.Read())
                {
                    inputNumProjet.AddItem(new AutoCompleteEntry(rdr3["RefProjet"].ToString(), null));
                }

            }

        }



        private void inputNumClient_MouseLeave(object sender, MouseEventArgs e)

        {


            string query3 = "Select * from client where NumClient='" + inputNumClient.Text + "'";
            MySqlDataReader rdr3 = null;
            MySqlConnection con3 = null;
            MySqlCommand cmd3 = null;
            con3 = new MySqlConnection(Database.ConnectionString());
            con3.Open();
            cmd3 = new MySqlCommand(query3);
            cmd3.Connection = con3;
            rdr3 = cmd3.ExecuteReader();

            while (rdr3.Read())
            {
                inputNomClient.Text = rdr3["Nom"].ToString();
                inputPrenomClient.Text = rdr3["Prenom"].ToString();
                inputDateNaissance.Text = rdr3["DateNaissance"].ToString();
                inputNumCNI.Text = rdr3["Cni"].ToString();
                inputNumClient.IsEnabled = inputNomClient.IsEnabled = inputPrenomClient.IsEnabled = inputDateNaissance.IsEnabled = inputNumCNI.IsEnabled = false;

            }

        }

        private void inputNumProjet_MouseLeave(object sender, MouseEventArgs e)
        {

            string query3 = "Select * from projet where RefProjet='" + inputNumProjet.Text + "'";
            MySqlDataReader rdr3 = null;
            MySqlConnection con3 = null;
            MySqlCommand cmd3 = null;
            con3 = new MySqlConnection(Database.ConnectionString());
            con3.Open();
            cmd3 = new MySqlCommand(query3);
            cmd3.Connection = con3;
            rdr3 = cmd3.ExecuteReader();

            while (rdr3.Read())
            {
                inputNomProjet.Text = rdr3["NomProjet"].ToString();
                inputNumProjet.IsEnabled = inputNomProjet.IsEnabled = false;
            }


            string query4 = "Select RefProgramme from programme where RefProjet='" + inputNumProjet.Text + "'";
            MySqlDataReader rdr4 = null;
            MySqlConnection con4 = null;
            MySqlCommand cmd4 = null;
            con4 = new MySqlConnection(Database.ConnectionString());
            con4.Open();
            cmd4 = new MySqlCommand(query4);
            cmd4.Connection = con4;
            rdr4 = cmd4.ExecuteReader();

            while (rdr4.Read())
            {
                inputNumProgramme.AddItem(new AutoCompleteEntry(rdr4["RefProgramme"].ToString(), null));

            }


        }

        private void inputNumProgramme_MouseLeave(object sender, MouseEventArgs e)
        {

            string query3 = "Select * from programme where RefProgramme='" + inputNumProgramme.Text + "'";
            MySqlDataReader rdr3 = null;
            MySqlConnection con3 = null;
            MySqlCommand cmd3 = null;
            con3 = new MySqlConnection(Database.ConnectionString());
            con3.Open();
            cmd3 = new MySqlCommand(query3);
            cmd3.Connection = con3;
            rdr3 = cmd3.ExecuteReader();

            while (rdr3.Read())
            {
                inputNomProgramme.Text = rdr3["NomProgramme"].ToString();
                inputNatureProgramme.Text = rdr3["NatureProgramme"].ToString();
                NatureProgramme = rdr3["NatureProgramme"].ToString();
                inputTypeProgramme.Text = rdr3["TypeProgramme"].ToString();
                inputNatureProgramme.IsEnabled = inputTypeProgramme.IsEnabled = inputNumProgramme.IsEnabled = inputNomProgramme.IsEnabled = false;

            }

            if (NatureProgramme == "Logement")
            {
                string query4 = "select DISTINCT NumIlot as NI from biens WHERE RefProjet='" + inputNumProjet.Text + "' and RefProgramme='" + inputNumProgramme.Text + "'";
                MySqlDataReader rdr4 = null;
                MySqlConnection con4 = null;
                MySqlCommand cmd4 = null;
                con4 = new MySqlConnection(Database.ConnectionString());
                con4.Open();
                cmd4 = new MySqlCommand(query4);
                cmd4.Connection = con4;
                rdr4 = cmd4.ExecuteReader();

                while (rdr4.Read())
                {
                    inputNumIlot.AddItem(new AutoCompleteEntry(rdr4["NI"].ToString(), null));
                }
            }
            else
            {

                string query4 = "select DISTINCT NumIlot as NI from lot WHERE RefProjet='" + inputNumProjet.Text + "' and RefProgramme='" + inputNumProgramme.Text + "' and NumCC=(SELECT MAX(NumCC) from lot WHERE RefProjet = '" + inputNumProjet.Text + "' and RefProgramme = '" + inputNumProgramme.Text + "')";
                MySqlDataReader rdr4 = null;
                MySqlConnection con4 = null;
                MySqlCommand cmd4 = null;
                con4 = new MySqlConnection(Database.ConnectionString());
                con4.Open();
                cmd4 = new MySqlCommand(query4);
                cmd4.Connection = con4;
                rdr4 = cmd4.ExecuteReader();

                while (rdr4.Read())
                {
                    inputNumIlot.AddItem(new AutoCompleteEntry(rdr4["NI"].ToString(), null));

                    inputNumBloc.IsEnabled = false;
                    inputNiveau.IsEnabled = false;
                    inputNbrPiece.IsEnabled = false;



                }
            }

        }

        private void inputNumIlot_MouseLeave(object sender, MouseEventArgs e)
        {

            if (NatureProgramme == "Logement")
            {
                string query3 = "Select DISTINCT NumBloc AS NB from biens WHERE RefProjet='" + inputNumProjet.Text + "' and RefProgramme='" + inputNumProgramme.Text + "' and NumIlot='" + inputNumIlot.Text + "'";
                MySqlDataReader rdr3 = null;
                MySqlConnection con3 = null;
                MySqlCommand cmd3 = null;
                con3 = new MySqlConnection(Database.ConnectionString());
                con3.Open();
                cmd3 = new MySqlCommand(query3);
                cmd3.Connection = con3;
                rdr3 = cmd3.ExecuteReader();

                while (rdr3.Read())
                {

                    inputNumBloc.AddItem(new AutoCompleteEntry(rdr3["NB"].ToString(), null));
                    inputNumIlot.IsEnabled = false;
                }
            }
            else
            {
                string query3 = "Select DISTINCT Numlot AS NL from lot WHERE RefProjet='" + inputNomProjet.Text + "' and RefProgramme='" + inputNumProgramme.Text + "' and NumIlot='" + inputNumIlot.Text + "' and NumCC=(SELECT MAX(NumCC) from lot WHERE RefProjet = '" + inputNomProjet.Text + "' and RefProgramme = '" + inputNumProgramme.Text + "') and Etat='Libre' ";
                MySqlDataReader rdr3 = null;
                MySqlConnection con3 = null;
                MySqlCommand cmd3 = null;
                con3 = new MySqlConnection(Database.ConnectionString());
                con3.Open();
                cmd3 = new MySqlCommand(query3);
                cmd3.Connection = con3;
                rdr3 = cmd3.ExecuteReader();

                while (rdr3.Read())
                {

                    inputNumLot.AddItem(new AutoCompleteEntry(rdr3["NL"].ToString(), null));
                    inputNumIlot.IsEnabled = false;
                }
            }

        }

        private void inputNumBloc_MouseLeave(object sender, MouseEventArgs e)
        {


            string query3 = "Select Numlot AS NL from biens WHERE RefProjet = '" + inputNumProjet.Text + "' and RefProgramme = '" + inputNumProgramme.Text + "' and NumIlot = '" + inputNumIlot.Text + "' and NumBloc = '" + inputNumBloc.Text + "' AND NumEdd = (SELECT MAX(NumEdd) from biens WHERE RefProjet = '" + inputNumProjet.Text + "' and RefProgramme = '" + inputNumProgramme.Text + "')   ";
            MySqlDataReader rdr3 = null;
            MySqlConnection con3 = null;
            MySqlCommand cmd3 = null;
            con3 = new MySqlConnection(Database.ConnectionString());
            con3.Open();
            cmd3 = new MySqlCommand(query3);
            cmd3.Connection = con3;
            rdr3 = cmd3.ExecuteReader();

            while (rdr3.Read())
            {
                inputNumLot.AddItem(new AutoCompleteEntry(rdr3["NL"].ToString(), null));
                inputNumBloc.IsEnabled = false;


            }

        }



        private void BtnAttribuerBien_Click(object sender, RoutedEventArgs e)
        {
            DirectoryCreator dcr = new DirectoryCreator();
            BiensController BC = new BiensController();
            dcr.CreateDirectory3(inputNumAttri.Text);
            AttributionController AC = new AttributionController();
            AC.AjouterAttribution(inputDateAttribution.Text, inputNumClient.Text, inputNumProjet.Text, inputNumProgramme.Text, inputNatureProgramme.Text, inputTypeBien.Text, inputNumIlot.Text, inputNumLot.Text, inputNumBloc.Text, tempIdbien, inputDateDLE.Text, inputDateDLR.Text, inputRefDL.Text);
            BC.ModifierEtat(tempIdbien, inputEtat.Text);
            AddPayementController APC = new AddPayementController();
            APC.AjouterPayement(inputDateAttribution.Text, int.Parse(inputNumAttri.Text), inputNumClient.Text, inputNomClient.Text, inputPrenomClient.Text, inputDateNaissance.Text, inputNumCNI.Text, int.Parse(inputNumProjet.Text), inputNomProjet.Text, int.Parse(inputNumProgramme.Text), inputNomProgramme.Text, inputNumIlot.Text, inputNumLot.Text, inputTypeBien.Text, inputNumBloc.Text, inputNiveau.Text, inputNbrPiece.Text, decimal.Parse(inputSurH.Text), decimal.Parse(inputSurU.Text), decimal.Parse(inputPrixTTC.Text), 0, decimal.Parse(inputPrixTTC.Text));

            string queryL = "Select NumA from Attribution where NumA=(select MAX(NumA) from attribution)";
            MySqlDataReader rdrL = null;
            MySqlConnection conL = null;
            MySqlCommand cmdL = null;
            conL = new MySqlConnection(Database.ConnectionString());
            conL.Open();
            cmdL = new MySqlCommand(queryL);
            cmdL.Connection = conL;
            rdrL = cmdL.ExecuteReader();

            while (rdrL.Read())
            {
               tempNumAttribution  = int.Parse(rdrL["NumA"].ToString());
            }
            MessageBox.Show(tempNumAttribution.ToString());

            string queryL2 = "Select NumPayement from payement where NumAttribution='" + tempNumAttribution + "'";

            MySqlDataReader rdrL2 = null;
            MySqlConnection conL2 = null;
            MySqlCommand cmdL2 = null;
            conL2 = new MySqlConnection(Database.ConnectionString());
            conL2.Open();
            cmdL2 = new MySqlCommand(queryL2);
            cmdL2.Connection = conL2;
            rdrL2 = cmdL2.ExecuteReader();
        
            while (rdrL2.Read())
            {
                tempNumPayement =int.Parse(rdrL2["NumPayement"].ToString());   
            }
            msh.ExecuteQuery("INSERT INTO `cnl` (`NumCNL`, `NumPayement`, `Etat`, `NumDeci`, `DateDeci`, `MontantCNL`, `DateConservation`, `DateControle`, `DateReserve`) VALUES (NULL, '"+tempNumAttribution+"', 'Non Admis', '', NULL, NULL, NULL, NULL, NULL)");
            msh.ExecuteQuery("INSERT INTO `creditb` (`NumCB`, `NumPayement`, `NumConvBan`, `DateConv`, `NomBanque`, `BIC`, `MontantCb`) VALUES (NULL, '"+tempNumAttribution+"', '', NULL, '', '', NULL)");
            msh.ExecuteQuery("INSERT INTO `fnpos` (`NumFNPOS`, `NumPayement`, `NumDeciF`, `DateDeciF`, `MontantFNPOS`) VALUES (NULL, '"+tempNumAttribution+"', NULL, NULL, NULL)");
           
            BtnAttribuerBien.IsEnabled = false;
         

        Attribution A = new Attribution("");
        this.NavigationService.Navigate(A);

        }

        private void inputNumLot_MouseLeave(object sender, MouseEventArgs e)
        {
           
            if (NatureProgramme == "Logement")
            {
                string query4 = "Select * from biens WHERE RefProjet='" + inputNumProjet.Text + "' and RefProgramme='" + inputNumProgramme.Text + "' and NumIlot='" + inputNumIlot.Text + "' and NumBloc='" + inputNumBloc.Text + "' and NumLot='" + inputNumLot.Text + "' and NumEdd=(SELECT MAX(NumEdd) from biens WHERE RefProjet = '" + inputNumProjet.Text + "' and RefProgramme = '" + inputNumProgramme.Text + "')";
             
                MySqlDataReader rdr4 = null;
                MySqlConnection con4 = null;
                MySqlCommand cmd4 = null;
                con4 = new MySqlConnection(Database.ConnectionString());
                con4.Open();
                cmd4 = new MySqlCommand(query4);
                cmd4.Connection = con4;
                rdr4 = cmd4.ExecuteReader();

                while (rdr4.Read())
                {
                    inputNiveau.Text = rdr4["Niveau"].ToString();
                    inputNbrPiece.Text = rdr4["NbrPiece"].ToString();
                    inputSurH.Text = rdr4["SurH"].ToString();
                    inputSurU.Text = rdr4["SurU"].ToString();
                    inputPrixHT.Text = rdr4["PrixHT"].ToString();
                    inputTva.Text = rdr4["Tva"].ToString();
                    inputPrixTTC.Text = rdr4["PrixTTC"].ToString();
                    inputLimiteEst.Text = rdr4["LimiteEst"].ToString();
                    inputLimiteNord.Text = rdr4["LimiteNord"].ToString();
                    inputLimiteOuest.Text = rdr4["LimiteOuest"].ToString();
                    inputLimiteSud.Text = rdr4["LimiteSud"].ToString();
                    inputTypeBien.Text = rdr4["TypeBien"].ToString();
                    tempIdbien = int.Parse(rdr4["Id"].ToString());
                    inputSurH.IsEnabled = inputSurU.IsEnabled = inputPrixHT.IsEnabled = inputTva.IsEnabled = inputPrixTTC.IsEnabled = inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = false;
                    

                }

            }


            else
            {
                string query3 = "Select * from lot WHERE RefProjet='" + inputNumProjet.Text + "' and RefProgramme='" + inputNumProgramme.Text + "' and NumIlot='" + inputNumIlot.Text + "' and NumLot='" + inputNumLot.Text + "' and NumCC=(SELECT MAX(NumCC) from lot WHERE RefProjet = '" + inputNomProjet.Text + "' and RefProgramme = '" + inputNumProgramme.Text + "')";
                MySqlDataReader rdr3 = null;
                MySqlConnection con3 = null;
                MySqlCommand cmd3 = null;
                con3 = new MySqlConnection(Database.ConnectionString());
                con3.Open();
                cmd3 = new MySqlCommand(query3);
                cmd3.Connection = con3;
                rdr3 = cmd3.ExecuteReader();

                while (rdr3.Read())
                {

                    // inputSup.Text = rdr3["Sup"].ToString();
                    inputPrixHT.Text = rdr3["PrixHT"].ToString();
                    inputTva.Text = rdr3["Tva"].ToString();
                    inputPrixTTC.Text = rdr3["PrixTTC"].ToString();
                    inputLimiteEst.Text = rdr3["LimiteEst"].ToString();
                    inputLimiteNord.Text = rdr3["LimiteNord"].ToString();
                    inputLimiteOuest.Text = rdr3["LimiteOuest"].ToString();
                    inputLimiteSud.Text = rdr3["LimiteSud"].ToString();
                    //  inputSup.IsEnabled = inputPrixHT.IsEnabled = inputTva.IsEnabled = inputPrixTTC.IsEnabled = inputLimiteEst.IsEnabled = inputLimiteNord.IsEnabled = inputLimiteOuest.IsEnabled = inputLimiteSud.IsEnabled = false;



                }
            }
        }

        private void BtnOv_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Btnmodifier_Click(object sender, RoutedEventArgs e)
        {
            
            
            AttributionController AC = new AttributionController();
            AC.ModifierAttribution(inputDateAttribution.Text, inputNumClient.Text, inputNumProjet.Text, inputNumProgramme.Text, inputNatureProgramme.Text, inputTypeBien.Text, inputNumIlot.Text, inputNumLot.Text, inputNumBloc.Text, tempIdbien,int.Parse(inputNumAttri.Text), inputDateDLE.Text, inputDateDLR.Text, inputRefDL.Text);

            if (tempIdbien != tempIdbien2)
            {
               
                BiensController BC = new BiensController();
                BC.ModifierEtat(tempIdbien2, "Libre");
                BC.ModifierEtat(tempIdbien, "Réservé");

            }
            string queryload = "Select MontantVerse from payement where NumAttribution='"+inputNumAttri.Text+"'";
            MySqlDataReader rdrP = null;
            MySqlConnection conP = null;
            MySqlCommand cmdP = null;
            conP = new MySqlConnection(Database.ConnectionString());
            conP.Open();
            cmdP = new MySqlCommand(queryload);
            cmdP.Connection = conP;
            rdrP = cmdP.ExecuteReader();
            bool oneTimeP = true;
            while (rdrP.Read())
            {
                tempMontantVers = decimal.Parse(rdrP["MontantVerse"].ToString());
            }
            conP.Close();
          
            tempreste = decimal.Parse(inputPrixTTC.Text) - tempMontantVers;

            AddPayementController APC = new AddPayementController();
            APC.ModifierPayement(int.Parse(inputNumProjet.Text), inputNomProjet.Text,int.Parse(inputNumProgramme.Text), inputNomProgramme.Text, inputNumIlot.Text, inputNumLot.Text, inputTypeBien.Text, inputNumBloc.Text, inputNiveau.Text, inputNbrPiece.Text,decimal.Parse(inputSurH.Text),decimal.Parse(inputSurU.Text), decimal.Parse(inputPrixTTC.Text), tempreste,int.Parse(inputNumAttri.Text));

        }
    }
}
