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

namespace Agerfor.PrgReporting
{
    public partial class FicheProgramme : Form
    {
        int CodeProgramme;
        string NatureProgramme;
        public FicheProgramme(int CodeProgramme, string NatureProgramme)
        {
            InitializeComponent();
            this.CodeProgramme = CodeProgramme;
            this.NatureProgramme = NatureProgramme;
        }
        private void report_Load(object sender, EventArgs e)
        {
            if (NatureProgramme == "Logement")
            {
                try
                {
                    string query = "select * from projet,programme,edd,permisdeconstruire where programme.RefProgramme='" + CodeProgramme + "' and programme.RefProgramme= edd.RefProgramme and programme.RefProgramme = permisdeconstruire.RefProgramme AND programme.RefProjet = projet.RefProjet and edd.DatePubli=(SELECT MAX(DatePubli) from edd where RefProgramme='" + CodeProgramme + "')";
                    MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                    FichePrg FP = new FichePrg();
                    MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                    DataSet1 DSP = new DataSet1();
                    dab.Fill(DSP.DataTable1);
                    FP.SetDataSource((DataTable)DSP.DataTable1);

                    crystalReportViewer1.ReportSource = FP;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Veuillez selectionner un programme \n" + ex.Message + "\n");
                }
            }
            else if (NatureProgramme == "Terrain")
            {
                try
                {
                    string query = "select * from projet,programme,permilotir,cahierchargeprogramme where programme.RefProgramme='" + CodeProgramme + "' and programme.RefProgramme=cahierchargeprogramme.RefProgramme and programme.RefProgramme = permilotir.RefProgramme AND programme.RefProjet = projet.RefProjet and permilotir.DatePL=(SELECT MAX(DatePL) from permilotir where RefProgramme='" + CodeProgramme + "') and cahierchargeprogramme.DatePubli=(SELECT MAX(DatePubli) from cahierchargeprogramme where RefProgramme='" + CodeProgramme + "'))";
                    MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                    FichePrgT FP = new FichePrgT();
                    MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                    DataSet1 DSP = new DataSet1();
                    dab.Fill(DSP.DataTable1);
                    FP.SetDataSource((DataTable)DSP.DataTable1);

                    crystalReportViewer1.ReportSource = FP;
                    crystalReportViewer1.Refresh();
                    con.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Veuillez selectionner un programme \n" + ex.Message + "\n");
                }
            }
        }
    }
}

