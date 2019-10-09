using DbConnection.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Agerfor.OVReporting
{
    public partial class OrdreVerssementR : Form
    {
        string NumOV;
        string userid;
      
        public OrdreVerssementR(string NumOV,string userid)
        {
            InitializeComponent();
            this.NumOV = NumOV;
            this.userid = userid;
           
        }

        private void report_Load(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                OrdreVerssements ov = new OrdreVerssements();
                Clipboard.SetText("SELECT Nom, Prenom, DATE_FORMAT(client.DateNaissance, '%d/%m/%Y') AS DateNaissance, client.LieuNaissance, Cni, DATE_FORMAT(DateCni, '%d/%m/%Y') AS DateCni, LieuCni, Tel, Reste, NumOV, MontantAV, TypePayement, biens.TypeBien, biens.TypeVente, programme.NomProgramme, site, commune, payement.NumLot, payement.NumIlot, payement.NumBloc, payement.Niveau, payement.SurH, biens.Tva as TvaL, programme.TVA, NaturePayement, NatureFrais, CompteB, AdresseB, IP, MAC, IdUser, UserName FROM client, payement, ov, biens, programme, Societe, attribution, users where NumVerssement = '" + NumOV+ "' and ov.NumPayement = payement.NumPayement AND payement.NumClient = client.NumClient and payement.RefProgramme = programme.RefProgramme AND payement.NumAttribution = attribution.NumA and attribution.IdBien = biens.Id and IdUser = '"+userid+"'");
                string query = @"SELECT Nom,Prenom,DATE_FORMAT(client.DateNaissance,'%d/%m/%Y') AS DateNaissance,client.LieuNaissance,Cni,DATE_FORMAT(DateCni,'%d/%m/%Y') AS DateCni,LieuCni,Tel,Reste,NumOV,MontantAV,TypePayement,biens.TypeBien,biens.TypeVente,programme.NomProgramme,site,commune,payement.NumLot,payement.NumIlot,payement.NumBloc,payement.Niveau,payement.SurH,biens.Tva as TvaL,programme.TVA,NaturePayement,NatureFrais,CompteB,AdresseB,IP,MAC,IdUser,UserName FROM client,payement,ov,biens,programme,Societe,attribution,users where NumVerssement='" + NumOV+ "' and ov.NumPayement=payement.NumPayement AND payement.NumClient = client.NumClient and payement.RefProgramme = programme.RefProgramme AND payement.NumAttribution = attribution.NumA and attribution.IdBien = biens.Id and IdUser='"+userid+"'";
                MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                DataSet1 DS = new DataSet1();
                dab.Fill(DS.DataTable1);
                ov.SetDataSource((DataTable)DS.DataTable1);
                crystalReportViewer1.ReportSource = ov;
                crystalReportViewer1.Refresh();
                con.Close();

            }

            catch (Exception ex)
            {
                MessageBox.Show("Veuillez selectionner un projet \n" + ex.Message + "\n");
            }
        }
    }
}

