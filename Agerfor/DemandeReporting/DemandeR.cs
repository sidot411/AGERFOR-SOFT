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

namespace Agerfor.DemandeReporting
{
    public partial class DemandeR : Form
    {
        public int RefClient;
        public int NumDemande;
        public DemandeR(int RefClient,int NumDeamnde)
        {
            InitializeComponent();
            this.RefClient = RefClient;
            this.NumDemande = NumDeamnde;

        }

        private void report_Load(object sender, EventArgs e)
        {
            if (RefClient != 0 && NumDemande!=0)
            {
                try
                {
                    MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                    CrystalReport1 cr1 = new CrystalReport1();

                    string query = @"select * from client,demande where client.NumClient='"+RefClient+"' and NumDemande='"+NumDemande+"' and client.NumClient = demande.RefClient";
                    MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                    DataSet1 DSP = new DataSet1();
                    dab.Fill(DSP.DataTable1);
                    cr1.SetDataSource((DataTable)DSP.DataTable1);

                    crystalReportViewer1.ReportSource = cr1 ;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Veuillez selectionner une demande \n" + ex.Message + "\n");
                }
            }
        }
    }
}

