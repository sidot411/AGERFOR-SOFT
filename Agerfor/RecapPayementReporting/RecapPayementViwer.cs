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

namespace Agerfor.RecapPayementReporting
{
    public partial class RecapPayementViwer : Form
    {
        string NomProgramme;
        public RecapPayementViwer(string NomProgramme)
        {
            this.NomProgramme = NomProgramme;
            InitializeComponent();
        }

        private void report_Load(object sender, EventArgs e)
        {
           
                try
                {
               //   Clipboard.SetText("select NomClient,PrenomClient,NumBloc,Niveau,NumLot,SurH,MontantTotal,Reste,EtatFraisGestion,payement.NomProgramme,payement.EtatFraisGestion,SUM(MontantAV) AS Apport,MontantCNL,cnl.Etat,MontantFNPOS,MontantCb,FraisAdm,MontantAV from payement,ov,cnl,fnpos,creditb,programme where payement.NomProgramme='" + NomProgramme + "' AND payement.NumPayement = ov.NumPayement and payement.NumPayement = cnl.NumPayement AND payement.NumPayement = fnpos.NumPayement and payement.NumPayement = creditb.NumPayement AND payement.RefProgramme = programme.RefProgramme AND ov.NaturePayement!='Autre frais' GROUP BY ov.NumPayement");
                    string Query = @"select NomClient,PrenomClient,NumBloc,Niveau,NumLot,SurH,MontantTotal,Reste,EtatFraisGestion,payement.NomProgramme,payement.EtatFraisGestion,SUM(MontantAV) AS Apport,MontantCNL,cnl.Etat,MontantFNPOS,MontantCb,FraisAdm,MontantAV from payement,ov,cnl,fnpos,creditb,programme where payement.NomProgramme='" + NomProgramme+ "' AND payement.NumPayement = ov.NumPayement and payement.NumPayement = cnl.NumPayement AND payement.NumPayement = fnpos.NumPayement and payement.NumPayement = creditb.NumPayement AND payement.RefProgramme = programme.RefProgramme AND ov.NaturePayement!='Autre frais' GROUP BY ov.NumPayement ORDER BY NumBloc ASC, NumLot ASC";
                    MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                    RecapPayement FP = new RecapPayement();

                    MySqlDataAdapter dab = new MySqlDataAdapter(Query, con);
                    DataSet1 DSP = new DataSet1();

                    dab.Fill(DSP.DataTable1);
                    FP.SetDataSource((DataTable)DSP.DataTable1);

                    crystalReportViewer1.ReportSource = FP;
                    crystalReportViewer1.Refresh();
                    con.Close();

                }

                catch (Exception ex)
                {
                    MessageBox.Show("Veuillez introduire une requette \n" + ex.Message + "\n");
                }
            }
        }
    }

