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
    public partial class ListeD : Form
    {
        public string query;
        public ListeD(string query)
        {
            InitializeComponent();
            this.query = query;
        }

        private void report_Load(object sender, EventArgs e)
        {
           
                try
                {
                    MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                    ListeDemande LD = new ListeDemande();
                    MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                    DataSet1 DSP = new DataSet1();
                    dab.Fill(DSP.DataTable1);
                    LD.SetDataSource((DataTable)DSP.DataTable1);
                    crystalReportViewer1.ReportSource = LD;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }

                catch (Exception ex)
                {
                   
                }
            }
        }
    }

