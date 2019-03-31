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

namespace Agerfor.ListeProjetReporting
{
    public partial class ListeProjetViwer : Form
    {
        public ListeProjetViwer()
        {
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
            
                try
                {
                    MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                    ListeProjet FP = new ListeProjet();

                    string query = @"select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS DatePubli,DATE_FORMAT(DateRecu,'%d/%m/%y') AS DateR from projet,acteprojet where projet.RefProjet=acteprojet.RefProjet";
                    MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                    DataSet1 DS = new DataSet1();
                    dab.Fill(DS.DataTable1);
                    FP.SetDataSource((DataTable)DS.DataTable1);

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
