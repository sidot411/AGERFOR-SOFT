using System;
using System.Windows.Controls;
using MySql.Data.MySqlClient;
using DbConnection.Models;
using System.Globalization;
using Agerfor.Controlers;
using System.Globalization;


namespace Agerfor.Views.Projet
{
    /// <summary>
    /// Interaction logic for AddProjet.xaml
    /// </summary>
    public partial class AddProjet : Page
    {
        ProjetController PC = new ProjetController();
        Agerfor.Controlers.MySqlHelper msh = new Agerfor.Controlers.MySqlHelper();
        string RefProjet = "";
        public AddProjet(string RefProjet)
        {
            InitializeComponent();
            msh.FillDropDownList("select NomWilaya from wilaya",inputConservProjet, "NomWilaya");
            msh.FillDropDownList("select NomWilaya from wilaya",inputWilayaProjet, "NomWilaya");
            msh.FillDropDownList("select NomWilaya from wilaya",inputDairaProjet, "NomWilaya");
            msh.FillDropDownList("select NomWilaya from wilaya",inputCommuneProjet, "NomWilaya");
            this.RefProjet = RefProjet;
            if (RefProjet !="")
            {
                string query = "select * from projet where RefProjet ="+RefProjet;
                MySqlDataReader rdr = null;
                MySqlConnection con = null;
                MySqlCommand cmd = null;

                con = new MySqlConnection(Database.ConnectionString);
                con.Open();
                cmd = new MySqlCommand(query);
                cmd.Connection = con;
                rdr = cmd.ExecuteReader();
                bool oneTime = true;
                while (rdr.Read())
                {

                    if (oneTime)
                    {
                        inputRefProjet.Text = rdr["RefProjet"].ToString();
                        inputNomProjet.Text = rdr["NomProjet"].ToString();
                        inputVolProjet.Text = rdr["VolProjet"].ToString();
                        inputConservProjet.Text = rdr["Conservation"].ToString();
                        inputVendeurProjet.Text = rdr["Vendeur"].ToString();
                        inputWilayaProjet.Text = rdr["Wilaya"].ToString();
                        inputDairaProjet.Text = rdr["Daira"].ToString();
                        inputCommuneProjet.Text = rdr["Commune"].ToString();
                        inputSuperficieProjet.Text = rdr["Superficie"].ToString();
                        inputNomGeo.Text = rdr["NomGeometre"].ToString();
                        inputAddressGeo.Text = rdr["AdresseGeometre"].ToString();
                        inputTelGeo.Text = rdr["NumGeometre"].ToString();
                        inputLimitNord.Text = rdr["LimiteNord"].ToString();
                        inputLimitEst.Text = rdr["LimiteEst"].ToString();
                        inputLimitOuest.Text = rdr["LimiteOuest"].ToString();
                        inputLimitSud.Text = rdr["LimiteSud"].ToString();
                        inputPrix.Text = rdr["PrixVente"].ToString();
                        inputNumReçu.Text = rdr["NumRecu"].ToString();
                        inputDateRecu.SelectedDate = DateTime.ParseExact(rdr["DateRecu"].ToString(), "dd-MM-yyyy", CultureInfo.InvariantCulture);


                       oneTime = false;
                    }
                }


                con.Close();
            }
        }

        private void BtnAjouterProjet_Click(object sender, System.Windows.RoutedEventArgs e)
        {
           
            PC.AjouterProjet(inputRefProjet.Text, inputNomProjet.Text, inputVolProjet.Text, inputConservProjet.Text, inputVendeurProjet.Text, inputWilayaProjet.Text, inputDairaProjet.Text, inputCommuneProjet.Text,double.Parse(inputSuperficieProjet.Text), inputNomGeo.Text, inputAddressGeo.Text, inputTelGeo.Text, inputLimitNord.Text, inputLimitEst.Text, inputLimitOuest.Text, inputLimitSud.Text,double.Parse(inputPrix.Text), inputNumReçu.Text, inputDateRecu.Text);
            AddProjet Addprojet = new AddProjet("");
            this.NavigationService.Navigate(Addprojet);
        }
    }

}
    
