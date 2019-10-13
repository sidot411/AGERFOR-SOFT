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


namespace Agerfor.ProjetReporting
{
    public partial class ListeProjetsViwer : Form
    {
        string query;
        public ListeProjetsViwer(string query)
        {
            InitializeComponent();
            this.query = query;
        }

        private void report_Load(object sender, EventArgs e)
        {
            try
            {
                MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                ListeProjets FP = new ListeProjets();

                MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                DataSetProjet DSP = new DataSetProjet();
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

