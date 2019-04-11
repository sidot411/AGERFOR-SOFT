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

namespace Agerfor.BiensReporting
{
    public partial class BienViwer : Form
    {
        int CodeProjet;
        int CodeProgramme;
        int NumEdd;
        string Query2;
        public BienViwer(int CodeProjet,int CodeProgramme,int NumEDD, string Query2)
        {
            InitializeComponent();
            this.CodeProjet = CodeProjet;
            this.CodeProgramme = CodeProgramme;
            this.NumEdd = NumEDD;
            this.Query2 = Query2;
        }

        private void report_Load(object sender, EventArgs e)
        {

            try
            {
                MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                Bien FP = new Bien();

                string query = "SELECT DISTINCT projet.RefProjet,projet.NomProjet,programme.RefProgramme,programme.NomProgramme,edd.Volume,edd.RefPubli,DATE_FORMAT(edd.DatePubli, '%d/%m/%Y') AS DatePubli from biens,projet,programme,edd WHERE biens.RefProjet = projet.RefProjet and biens.RefProgramme = programme.RefProgramme AND biens.NumEdd = edd.NumEdd and biens.RefProjet='"+CodeProjet+"' and biens.RefProgramme='"+CodeProgramme+"' and biens.NumEdd='"+NumEdd+"'";
                MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                DataSet1BR DS = new DataSet1BR();
                dab.Fill(DS.DataTable1);
                FP.SetDataSource((DataTable)DS.DataTable1);

               

            
                MySqlDataAdapter dab2 = new MySqlDataAdapter(Query2, con);
                DataSet2BR DS2 = new DataSet2BR();
                dab2.Fill(DS2.DataTable1);
                FP.OpenSubreport("ResearchB.rpt").SetDataSource((DataTable)DS2.DataTable1);

                crystalReportViewer1.ReportSource = FP;
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

