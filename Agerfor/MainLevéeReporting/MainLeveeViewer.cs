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

namespace Agerfor.MainLevéeReporting
{
    public partial class MainLeveeViewer : Form
    {
        int CodeML;
        string NumDeci;
        string NumDeciF;
        string NumConv;
        int NumP;
        public MainLeveeViewer(int CodeML, string NumDeci, string NumDeciF, string NumConv, int NumP)
        {
            InitializeComponent();
            this.CodeML = CodeML;
            this.NumDeci = NumDeci;
            this.NumDeciF = NumDeciF;
            this.NumConv = NumConv;
            this.NumP = NumP;
        }


        private void report_Load(object sender, EventArgs e)
        {
            if (NumDeci != "0" && NumDeciF == "0" && NumConv =="0")
            {
                
                if (CodeML != 0)
                {
                    try
                    {
                        MySqlConnection con = new MySqlConnection(Database.ConnectionString());

                        MainLevee cr1 = new MainLevee();

                        string query = @"select payement.NumPayement,NumA,DateDLR,NumDeci,DateDeci,MontantCNL,Nom,Prenom,client.DateNaissance,LieuNaissance,PrenomPere,NomMere,PrenomMere,Adress,Tel,programme.NomProgramme,FraisAdm,Site,CoutFoncier,programme.TVA AS TVAF,CoutFoncierTTC,NbrPiece,biens.NumIlot,biens.NumBloc,biens.Niveau,biens.Numlot,biens.SurH,PrixHT,biens.Tva,PrixTTC,NomNotaire,mainlevee.AdresseNotaire,sum(MontantAV) AS Apport,NumML,DateML from ov,edd,biens,programme,client,cnl,attribution,payement,mainlevee where CodeML='" + CodeML + "' AND mainlevee.RefP = payement.NumPayement AND payement.NumAttribution = attribution.NumA AND payement.NumPayement = cnl.NumPayement AND attribution.NumClient = client.NumClient AND attribution.NumProgramme = programme.RefProgramme AND attribution.IdBien = biens.Id AND programme.RefProgramme = edd.RefProgramme AND payement.NumPayement = ov.NumPayement and ov.Etat='Terminé'";
                        MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                        DataSet1 DSP = new DataSet1();
                        dab.Fill(DSP.DataTable1);
                        cr1.SetDataSource((DataTable)DSP.DataTable1);

                        string query3 = @"select NumML,DateML from mainlevee where RefP='" + NumP + "' ORDER BY CodeML DESC LIMIT 1,1";
                        MySqlDataAdapter dab3 = new MySqlDataAdapter(query3, con);
                        DataSet2 ds3 = new DataSet2();
                        dab3.Fill(ds3.DataTable1);
                        cr1.OpenSubreport("PreviousML.rpt").SetDataSource((DataTable)ds3.DataTable1);

                        string query4 = @"select NumOV,DateOV,MontantAV from ov WHERE NumPayement='" + NumP + "' AND Etat='Terminé' AND NaturePayement!='Autre frais' ORDER BY DateOV";
                        MySqlDataAdapter dab4 = new MySqlDataAdapter(query4, con);
                        DataSetOV ds4 = new DataSetOV();
                        dab4.Fill(ds4.DataTable1);
                        cr1.OpenSubreport("ListeVersement.rpt").SetDataSource((DataTable)ds4.DataTable1);

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
            else if (NumDeci != "0" && NumDeciF != "0" && NumConv=="0")
            {
              
                if (CodeML != 0)
                {

                    try
                    {
                        MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                        MainLevee cr1 = new MainLevee();

                        string query = @"select payement.NumPayement,NumA,DateDLR,NumDeci,DateDeci,MontantCNL,NumDeciF,DateDeciF,MontantFNPOS,Nom,Prenom,client.DateNaissance,LieuNaissance,PrenomPere,NomMere,PrenomMere,Adress,Tel,programme.NomProgramme,FraisAdm,Site,CoutFoncier,programme.TVA AS TVAF,CoutFoncierTTC,NbrPiece,biens.NumIlot,biens.NumBloc,biens.Niveau,biens.Numlot,biens.SurH,PrixHT,biens.Tva,PrixTTC,NomNotaire,mainlevee.AdresseNotaire,sum(MontantAV) AS Apport, NumML, DateML,MontantCb from ov, edd, biens, programme, client, cnl,creditb,fnpos, attribution, payement, mainlevee where CodeML = '" + CodeML + "' AND mainlevee.RefP = payement.NumPayement AND payement.NumAttribution = attribution.NumA AND payement.NumPayement = cnl.NumPayement AND payement.NumPayement = creditb.NumPayement AND payement.NumPayement = fnpos.NumPayement AND attribution.NumClient = client.NumClient AND attribution.NumProgramme = programme.RefProgramme AND attribution.IdBien = biens.Id AND programme.RefProgramme = edd.RefProgramme AND payement.NumPayement = ov.NumPayement and ov.Etat = 'Terminé'";
                        MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                        DataSet1 DSP = new DataSet1();
                        dab.Fill(DSP.DataTable1);
                        cr1.SetDataSource((DataTable)DSP.DataTable1);


                        string query3 = @"select NumML,DateML from mainlevee where  RefP='" + NumP + "' ORDER BY CodeML DESC LIMIT 1,1 ";
                        MySqlDataAdapter dab3 = new MySqlDataAdapter(query3, con);
                        DataSet2 ds3 = new DataSet2();
                        dab3.Fill(ds3.DataTable1);
                        cr1.OpenSubreport("PreviousML.rpt").SetDataSource((DataTable)ds3.DataTable1);


                        string query4 = @"select NumOV,DateOV,MontantAV from ov WHERE NumPayement='" + NumP + "' AND Etat='Terminé' AND NaturePayement!='Autre frais' ORDER BY DateOV";
                        MySqlDataAdapter dab4 = new MySqlDataAdapter(query4, con);
                        DataSetOV ds4 = new DataSetOV();
                        dab4.Fill(ds4.DataTable1);
                        cr1.OpenSubreport("ListeVersement.rpt").SetDataSource((DataTable)ds4.DataTable1);

                        crystalReportViewer1.ReportSource = cr1;
                        crystalReportViewer1.Refresh();
                        con.Close();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Veuillez selectionner une main levée \n" + ex.Message + "\n");
                    }

                }
            }
            else if (NumDeci != "0" && NumDeciF != "0" && NumConv != "0")
            {
              
                if (CodeML != 0)
                {

                    try
                    {
                        MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                        MainLevee cr1 = new MainLevee();

                        string query = @"select payement.NumPayement,NumA,DateDLR,NumDeci,DateDeci,MontantCNL,NumDeciF,DateDeciF,MontantFNPOS,Nom,Prenom,client.DateNaissance,LieuNaissance,PrenomPere,NomMere,PrenomMere,Adress,Tel,programme.NomProgramme,FraisAdm,Site,CoutFoncier,programme.TVA AS TVAF,CoutFoncierTTC,NbrPiece,biens.NumIlot,biens.NumBloc,biens.Niveau,biens.Numlot,biens.SurH,PrixHT,biens.Tva,PrixTTC,NomNotaire,mainlevee.AdresseNotaire,sum(MontantAV) AS Apport, NumML, DateML,MontantCb from creditb,ov, edd, biens, programme, client, cnl,fnpos, attribution, payement, mainlevee where CodeML = '" + CodeML + "' AND mainlevee.RefP = payement.NumPayement AND payement.NumAttribution = attribution.NumA AND payement.NumPayement = cnl.NumPayement AND payement.NumPayement = fnpos.NumPayement AND payement.NumPayement = creditb.NumPayement AND attribution.NumClient = client.NumClient AND attribution.NumProgramme = programme.RefProgramme AND attribution.IdBien = biens.Id AND programme.RefProgramme = edd.RefProgramme AND payement.NumPayement = ov.NumPayement and ov.Etat = 'Terminé'";
                        MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                        DataSet1 DSP = new DataSet1();
                        dab.Fill(DSP.DataTable1);
                        cr1.SetDataSource((DataTable)DSP.DataTable1);


                        string query3 = @"select NumML,DateML from mainlevee where  RefP='" + NumP + "' ORDER BY CodeML DESC LIMIT 1,1 ";
                        MySqlDataAdapter dab3 = new MySqlDataAdapter(query3, con);
                        DataSet2 ds3 = new DataSet2();
                        dab3.Fill(ds3.DataTable1);
                        cr1.OpenSubreport("PreviousML.rpt").SetDataSource((DataTable)ds3.DataTable1);

                   
                        string query4 = @"select NumOV,DateOV,MontantAV from ov WHERE NumPayement='" + NumP + "' AND Etat='Terminé' AND NaturePayement!='Autre frais' ORDER BY DateOV";
                        MySqlDataAdapter dab4 = new MySqlDataAdapter(query4, con);
                        DataSetOV ds4 = new DataSetOV();
                        dab4.Fill(ds4.DataTable1);
                        cr1.OpenSubreport("ListeVersement.rpt").SetDataSource((DataTable)ds4.DataTable1);

                        crystalReportViewer1.ReportSource = cr1;
                        crystalReportViewer1.Refresh();
                        con.Close();

                    }

                    catch (Exception ex)
                    {
                        MessageBox.Show("Veuillez selectionner une main levée \n" + ex.Message + "\n");
                    }

                }

                else if (NumDeci != "0" && NumDeciF == "0" && NumConv != "0")
                {
                    if (CodeML != 0)
                    {

                        try
                        {
                            MySqlConnection con = new MySqlConnection(Database.ConnectionString());
                            MainLevee cr1 = new MainLevee();

                            string query = @"select payement.NumPayement,NumA,DateDLR,NumDeci,DateDeci,MontantCNL,Nom,Prenom,client.DateNaissance,LieuNaissance,PrenomPere,NomMere,PrenomMere,Adress,Tel,programme.NomProgramme,FraisAdm,Site,CoutFoncier,programme.TVA AS TVAF,CoutFoncierTTC,NbrPiece,biens.NumIlot,biens.NumBloc,biens.Niveau,biens.Numlot,biens.SurH,PrixHT,biens.Tva,PrixTTC,NomNotaire,mainlevee.AdresseNotaire,sum(MontantAV) AS Apport, NumML, DateML,MontantCb from creditb,ov, edd, biens, programme, client, cnl,attribution, payement, mainlevee where CodeML = '" + CodeML + "' AND mainlevee.RefP = payement.NumPayement AND payement.NumAttribution = attribution.NumA AND payement.NumPayement = cnl.NumPayement AND payement.NumPayement = creditb.NumPayement AND attribution.NumClient = client.NumClient AND attribution.NumProgramme = programme.RefProgramme AND attribution.IdBien = biens.Id AND programme.RefProgramme = edd.RefProgramme AND payement.NumPayement = ov.NumPayement and ov.Etat = 'Terminé'";
                            MySqlDataAdapter dab = new MySqlDataAdapter(query, con);
                            DataSet1 DSP = new DataSet1();
                            dab.Fill(DSP.DataTable1);
                            cr1.SetDataSource((DataTable)DSP.DataTable1);


                            string query3 = @"select NumML,DateML from mainlevee where  RefP='" + NumP + "' ORDER BY CodeML DESC LIMIT 1,1 ";
                            MySqlDataAdapter dab3 = new MySqlDataAdapter(query3, con);
                            DataSet2 ds3 = new DataSet2();
                            dab3.Fill(ds3.DataTable1);
                            cr1.OpenSubreport("PreviousML.rpt").SetDataSource((DataTable)ds3.DataTable1);


                            string query4 = @"select NumOV,DateOV,MontantAV from ov WHERE NumPayement='" + NumP + "' AND Etat='Terminé' AND NaturePayement!='Autre frais' ORDER BY DateOV";
                            MySqlDataAdapter dab4 = new MySqlDataAdapter(query4, con);
                            DataSetOV ds4 = new DataSetOV();
                            dab4.Fill(ds4.DataTable1);
                            cr1.OpenSubreport("ListeVersement.rpt").SetDataSource((DataTable)ds4.DataTable1);

                            crystalReportViewer1.ReportSource = cr1;
                            crystalReportViewer1.Refresh();
                            con.Close();

                        }

                        catch (Exception ex)
                        {
                            MessageBox.Show("Veuillez selectionner une main levée \n" + ex.Message + "\n");
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
}



