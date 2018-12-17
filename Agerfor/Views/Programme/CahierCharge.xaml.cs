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
using MySql.Data.MySqlClient;
using DbConnection.Models;

namespace Agerfor.Views.Programme
{
    /// <summary>
    /// Interaction logic for CahierCharge.xaml
    /// </summary>
    public partial class CahierCharge : UserControl
    {
        CahierChargeProgrammeController CCPC = new CahierChargeProgrammeController();
        Controlers.MySqlHelper msh = new Controlers.MySqlHelper();
        string RefProgramme = "";
        string NomProjet = "";
        string tempNumCahierDeCharge = "";
        public CahierCharge(string NomProjet, string refprogramme)
        {
            InitializeComponent();
            title.Text = "Cahier de charge";
            this.RefProgramme = refprogramme;
            this.NomProjet = NomProjet;

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)

        {
           
            msh.LoadData("select * from cahierchargeprogramme where RefProgramme='"+RefProgramme+"' and NomProjet='"+NomProjet+"'", dataViewCahierCharge);
        }

        private void BtnAjouterCC_Click(object sender, RoutedEventArgs e)
        {
          
            CCPC.AjouterCahierCharge(NomProjet,RefProgramme,inputNumCahierCharge.Text,inputDateEnreg.Text,inputVolume.Text,inputNumPubli.Text,inputDatePubli.Text,inputConservation.Text,inputNotaire.Text,inputTelNotaire.Text,inputAdresseNotaire.Text,decimal.Parse(inputSuperficieCessible.Text),decimal.Parse(inputSuperficieVoirie.Text),decimal.Parse(inputSuperficieEv.Text),decimal.Parse(inputSuperficieEq.Text),decimal.Parse(inputAutreSuperficie.Text),inputNomGeo.Text,inputAddressGeo.Text,inputTelGeo.Text);
            msh.LoadData("select * from cahierchargeprogramme where RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'", dataViewCahierCharge);
        }

        private void dataViewCahierCharge_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            DataGridCellInfo cell0 = dataViewCahierCharge.SelectedCells[0];
            tempNumCahierDeCharge = ((TextBlock)cell0.Column.GetCellContent(cell0.Item)).Text;

            string query = "select * from cahierchargeprogramme where NumCahierCharge =" + tempNumCahierDeCharge;
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
                    inputNumCahierCharge.Text = rdr["NumCahierCharge"].ToString();
                    inputDateEnreg.Text = rdr["DateEnre"].ToString();

                    oneTime = false;
                }
            }
        }
    }
}
