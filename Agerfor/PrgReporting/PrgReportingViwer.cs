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
    public partial class PrgReportingViwer : Form
    {
        string query;
        public PrgReportingViwer(string query)
        {
            InitializeComponent();
            this.query = query;
        }


        private void report_Load(object sender, EventArgs e)
        {
                try
                {
                    MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                    PrgReporting FP = new PrgReporting();

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
                    MessageBox.Show("Veuillez selectionner un projet \n" + ex.Message + "\n");
                }
            }
        }


    }

