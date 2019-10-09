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

namespace Agerfor.DecisionReporting
{
    public partial class DecisionViwer : Form
    {
        int NumR;
        string NumDeci;
        string NumDeciF;
        string id;
        public DecisionViwer(int NumR, string NumDeci, string NumDeciF,string id)
        {
            InitializeComponent();
            this.NumR = NumR;
            this.NumDeci = NumDeci;
            this.NumDeciF = NumDeciF;
            this.id = id;
        }

        private void report_Load(object sender, EventArgs e)
        {
            if (NumDeci !="0" && NumDeciF=="0")
            {
              
                if (NumR != 0)
                {
                    try
                    {
                        MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                        DecisionReporting cr1 = new DecisionReporting();

                      //  Clipboard.SetText("select payement.NumPayement,NumA,DateDLR,NumDeci,DateDeci,MontantCNL,Nom,Prenom,client.DateNaissance,LieuNaissance,PrenomPere,NomMere,PrenomMere,Adress,programme.NomProgramme,FraisAdm,Site,CoutFoncierTTC,NbrPiece,biens.NumIlot,biens.NumBloc,biens.Niveau,biens.Numlot,biens.SurH,PrixTTC,Notaire,AdresseNotaire,sum(MontantAV) AS Apport,NumR,DateR,IP,MAC,UserName,IdUser from ov,edd,biens,programme,client,cnl,attribution,payement,decisionr,users where CodeDec='" + NumR + "'  AND decisionr.RefP = payement.NumPayement AND payement.NumAttribution = attribution.NumA AND payement.NumPayement = cnl.NumPayement AND attribution.NumClient = client.NumClient AND attribution.NumProgramme = programme.RefProgramme AND attribution.IdBien = biens.Id AND programme.RefProgramme = edd.RefProgramme AND payement.NumPayement = ov.NumPayement and ov.Etat='Terminé' and IdUser='" + id + "'");
                        string query = @"select payement.NumPayement,NumA,DateDLR,NumDeci,DateDeci,MontantCNL,Nom,Prenom,client.DateNaissance,LieuNaissance,PrenomPere,NomMere,PrenomMere,Adress,programme.NomProgramme,FraisAdm,Site,CoutFoncierTTC,NbrPiece,biens.NumIlot,biens.NumBloc,biens.Niveau,biens.Numlot,biens.SurH,PrixTTC,Notaire,AdresseNotaire,sum(MontantAV) AS Apport,NumR,DateR,IP,MAC,UserName,IdUser from ov,edd,biens,programme,client,cnl,attribution,payement,decisionr,users where CodeDec='"+NumR+"'  AND decisionr.RefP = payement.NumPayement AND payement.NumAttribution = attribution.NumA AND payement.NumPayement = cnl.NumPayement AND attribution.NumClient = client.NumClient AND attribution.NumProgramme = programme.RefProgramme AND attribution.IdBien = biens.Id AND programme.RefProgramme = edd.RefProgramme AND payement.NumPayement = ov.NumPayement and ov.Etat='Terminé' and IdUser='"+id+"'";
                        MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                        DataSet2 DSP = new DataSet2();
                        dab.Fill(DSP.DataTable1);
                        cr1.SetDataSource((DataTable)DSP.DataTable1);

                        string query3 = @"select NumR,DateR from decisionr where CodeDec='"+NumR+"' ORDER BY CodeDec DESC LIMIT 1,1";
                        MySqlDataAdapter dab3 = new MySqlDataAdapter(query3, con);
                        DataSet4 ds3 = new DataSet4();
                        dab3.Fill(ds3.DataTable1);
                        cr1.OpenSubreport("PreviousDec.rpt").SetDataSource((DataTable)ds3.DataTable1);

                        crystalReportViewer1.ReportSource = cr1;
                        crystalReportViewer1.Refresh();
                        con.Close();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Veuillez selectionner une décison \n" + ex.Message + "\n");
                    }

                }
            }
            else if (NumDeci != "0" && NumDeciF != "0")
            {

                  

                if (NumR != 0)
                {
                   
                    try
                    {
                        MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                        DecisionReporting cr1 = new DecisionReporting();

                        string query = @"select payement.NumPayement,NumA,DateDLR,NumDeci,DateDeci,NumDeciF,DateDeciF,MontantCNL,MontantFNPOS,Nom,Prenom,client.DateNaissance,LieuNaissance,PrenomPere,NomMere,PrenomMere,Adress,programme.NomProgramme,Site,CoutFoncierTTC,NbrPiece,biens.NumIlot,biens.NumBloc,biens.Niveau,biens.Numlot,biens.SurH,PrixTTC,Notaire,AdresseNotaire,sum(MontantAV) AS Apport,NumR,DateR,FraisAdm,IP,MAC,UserName,IdUser from fnpos,ov,edd,biens,programme,client,cnl,attribution,payement,decisionr,users where CodeDec='1'  AND decisionr.RefP = payement.NumPayement AND payement.NumAttribution = attribution.NumA AND payement.NumPayement = cnl.NumPayement AND payement.NumPayement = fnpos.NumPayement AND attribution.NumClient = client.NumClient AND attribution.NumProgramme = programme.RefProgramme AND attribution.IdBien = biens.Id AND programme.RefProgramme = edd.RefProgramme AND payement.NumPayement = ov.NumPayement and ov.Etat='Terminé' and IdUser='" + id + "'";
                        MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                        DataSet2 DSP = new DataSet2();
                        dab.Fill(DSP.DataTable1);
                        cr1.SetDataSource((DataTable)DSP.DataTable1);

                        string query3 = @"select NumR,DateR from decisionr where CodeDec='" + NumR + "' ORDER BY CodeDec DESC LIMIT 1,1";
                        MySqlDataAdapter dab3 = new MySqlDataAdapter(query3, con);
                        DataSet4 ds3 = new DataSet4();
                        dab3.Fill(ds3.DataTable1);
                        cr1.OpenSubreport("PreviousDec.rpt").SetDataSource((DataTable)ds3.DataTable1);

                        crystalReportViewer1.ReportSource = cr1;
                        crystalReportViewer1.Refresh();
                        con.Close();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Veuillez selectionner une décison \n" + ex.Message + "\n");
                    }

                }
            }
            else
            {
                MessageBox.Show("Veuillez d'abord remplir les informations du CNL et/ou fnpos ");
            }
        }
    }
}
