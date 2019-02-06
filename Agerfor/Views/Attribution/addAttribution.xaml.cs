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
        string NumAttribution = "";
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        public AddAttribution(string NumAttribution)
        {
            InitializeComponent();
            this.NumAttribution = NumAttribution;
            msh.FillDropDownList("select Type from typebiens", inputTypeBien, "Type");
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

        private void inputNumClient_MouseLeave(object sender, MouseEventArgs e)
        {
           
            string query3="Select * from client where NumClient='"+inputNumClient.Text+"'";
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


            string query4 = "Select RefProgramme from programme where NomProjet='" + inputNomProjet.Text + "'";
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
                inputNumProgramme.IsEnabled = inputNomProgramme.IsEnabled = false;
            }

            
            string query4 = "select DISTINCT NumIlot as NI from biens WHERE NomProjet='"+inputNomProjet.Text+"' and RefProgramme='"+inputNumProgramme.Text+"'";
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

        private void inputNumIlot_MouseLeave(object sender, MouseEventArgs e)
        {
            string query3 = "Select DISTINCT Numlot AS NL from biens WHERE NomProjet='" + inputNomProjet.Text + "' and RefProgramme='" + inputNumProgramme.Text + "' and NumIlot='"+inputNumIlot.Text+"'";
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

        private void inputTypeBien_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
        

            try
            {
                inputNumLot.IsEnabled = false;
                inputTypeBien.IsEnabled = false;
                if (inputTypeBien.SelectedValue.ToString() == "Terrain")
                {

                    inputNumBloc.IsEnabled = inputNiveau.IsEnabled = inputNbrPiece.IsEnabled = false;
                   
                    string query3 = "Select DISTINCT NumBien AS NB from biens WHERE NomProjet='" + inputNomProjet.Text + "' and RefProgramme='" + inputNumProgramme.Text + "' and NumIlot='" + inputNumIlot.Text + "' and Numlot='"+inputNumLot.Text+ "' and TypeBien='"+inputTypeBien.SelectedValue.ToString()+"'";
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

                        inputNumBien.AddItem(new AutoCompleteEntry(rdr3["NB"].ToString(), null));
                       
                    }
                    

                }
                else
                {
                    inputNumBloc.IsEnabled = inputNiveau.IsEnabled = inputNbrPiece.IsEnabled = true;
                    string query3 = "Select DISTINCT NumBloc AS NB from biens WHERE NomProjet='" + inputNomProjet.Text + "' and RefProgramme='" + inputNumProgramme.Text + "' and NumIlot='" + inputNumIlot.Text + "' and Numlot='"+inputNumLot.Text+ "' and TypeBien='"+inputTypeBien.SelectedValue.ToString()+"'";
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
                       
                    }
                    

                }
             
            }
            catch(Exception)
            { }
            
        }

       

        private void inputNumBloc_MouseLeave(object sender, MouseEventArgs e)
        {
            if (inputTypeBien.Text !="")
            {
                string query3 = "Select NumBien AS NB from biens WHERE NomProjet = '"+inputNomProjet.Text+"' and RefProgramme = '"+inputNumProgramme.Text+"' and NumIlot = '"+inputNumIlot.Text+"' and Numlot = '"+inputNumLot.Text+"' and TypeBien = '"+inputTypeBien.SelectedValue.ToString()+"' and NumBloc = '"+inputNumBloc.Text+"' AND NumEdd = (SELECT MAX(NumEdd) from biens WHERE NomProjet = '"+inputNomProjet.Text+"' and RefProgramme = '"+inputNumProgramme.Text+"')"; 
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
                    inputNumBloc.IsEnabled = false;
                    inputNumBien.AddItem(new AutoCompleteEntry(rdr3["NB"].ToString(), null));

                } }
            else
            {
                MessageBox.Show("Veuillez sélectioner d'abord un type de bien");
            }
        }

        private void inputNumBien_MouseLeave(object sender, MouseEventArgs e)
        {
           
            if (inputTypeBien.Text!="")
            {
                if (inputTypeBien.SelectedValue.ToString() == "Terrain")
                {
                    string query3 = "Select * from biens WHERE NomProjet='" + inputNomProjet.Text + "' and RefProgramme='" + inputNumProgramme.Text + "' and NumIlot='" + inputNumIlot.Text + "' and Numlot='" + inputNumLot.Text + "' and TypeBien='" + inputTypeBien.SelectedValue.ToString() + "' and NumBien='" + inputNumBien.Text + "'";
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

                        inputSup.Text = rdr3["Sup"].ToString();
                        inputPrixHT.Text = rdr3["PrixHT"].ToString();
                        inputTva.Text = rdr3["Tva"].ToString();
                        inputPrixTTC.Text = rdr3["PrixTTC"].ToString();
                        inputLimiteEst.Text = rdr3["LimiteEst"].ToString();
                        inputLimiteNord.Text = rdr3["LimiteNord"].ToString();
                        inputLimiteOuest.Text = rdr3["LimiteOuest"].ToString();
                        inputLimiteSud.Text = rdr3["LimiteSud"].ToString();


                    }
                }
                else
                {
                    string query3 = "Select * from biens WHERE NomProjet='" + inputNomProjet.Text + "' and RefProgramme='" + inputNumProgramme.Text + "' and NumIlot='" + inputNumIlot.Text + "' and Numlot='" + inputNumLot.Text + "' and TypeBien='" + inputTypeBien.SelectedValue.ToString() + "' and NumBien='" + inputNumBien.Text + "' and  NumBloc='" + inputNumBloc.Text + "'";
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
                        inputNiveau.Text = rdr3["Niveau"].ToString();
                        inputNbrPiece.Text = rdr3["NbrPiece"].ToString();
                        inputSup.Text = rdr3["Sup"].ToString();
                        inputPrixHT.Text = rdr3["PrixHT"].ToString();
                        inputTva.Text = rdr3["Tva"].ToString();
                        inputPrixTTC.Text = rdr3["PrixTTC"].ToString();
                        inputLimiteEst.Text = rdr3["LimiteEst"].ToString();
                        inputLimiteNord.Text = rdr3["LimiteNord"].ToString();
                        inputLimiteOuest.Text = rdr3["LimiteOuest"].ToString();
                        inputLimiteSud.Text = rdr3["LimiteSud"].ToString();


                    }

                }

            }
            else
            {
                MessageBox.Show("Veuillez selectionner un type bien d'abord");
            }
        }

        private void BtnAttribuerBien_Click(object sender, RoutedEventArgs e)
        {
            AttributionController AC = new AttributionController();
            AC.AjouterAttribution(int.Parse(inputNumAttri.Text), inputDateAttribution.Text, inputNumClient.Text, inputNumProjet.Text, inputNumProgramme.Text, inputNumIlot.Text, inputNumLot.Text, inputTypeBien.Text, inputNumBloc.Text, inputNumBien.Text);
        }
    }
}
