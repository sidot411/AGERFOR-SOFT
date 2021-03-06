﻿using DbConnection.Models;
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
    public partial class ProjetViwer : Form
    {
        public int RefProjet;
        public ProjetViwer(int RefProjet)
        {
            InitializeComponent();
            this.RefProjet = RefProjet;
        }

        private void report_Load(object sender, EventArgs e)
        {
            if (RefProjet != 0)
            {
                try
                {
                    MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                    FicheProjet FP = new FicheProjet();

                    string query = @"select *,DATE_FORMAT(DatePubliActe,'%d/%m/%y') AS DatePubli,DATE_FORMAT(DateRecu,'%d/%m/%y') AS DateR from projet,acteprojet where projet.RefProjet='" + RefProjet + "' and projet.RefProjet=acteprojet.RefProjet";
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
}

