using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class ConventionController
    {
        MySqlHelper msh = new MySqlHelper();


        public void AjouterConvention (string NomProjet, string RefProgramme, string NumDec, string DateDec, string NumAW, string DateAW, string DateConv, string NatureA, decimal SupT, decimal PrixU, string Majoration)
        {
            try
            {
                msh.ExecuteQuery("insert into convention values('"+NomProjet+"','"+RefProgramme+"', '" + NumDec + "','" + DateDec + "','" + NumAW + "','" + DateAW + "','" + DateConv + "','" + NatureA + "','" + SupT + "','" + PrixU + "','" + Majoration + "')");
                MessageBox.Show("La convention à été bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("La convention n'a pas été ajouté");
            }
        }

        public void ModifierConvention(string NomProjet, string RefProgramme, string NumDec, string DateDec, string NumAW, string DateAW, string DateConv, string NatureA, decimal SupT, decimal PrixU, string Majoration, string tempNumDec)

        {
            try
            {
                msh.ExecuteQuery("update convention set NomProjet='" + NomProjet + "',RefProgramme='" + RefProgramme + "',NumDec='" + NumDec + "',DateDec='" + DateDec + "',NumAW='" + NumAW + "',DateAW='" + DateAW + "',DateConv='" + DateConv + "',NatureA='" + NatureA + "',SupT='" + SupT + "',PrixU='" + PrixU + "',Majoration='" + Majoration + "' where NumDec='" + tempNumDec + "' and NomProjet = '" + NomProjet + "' and RefProgramme = '" + RefProgramme + "'");
                MessageBox.Show("La convention à été bien modifié");
            }
            catch(Exception)
            {
                MessageBox.Show("La convention n'a pas été modifié");
            }
        }
        public void SupprimerConvention(string NumDec)
        {
            try
            {
                msh.ExecuteQuery("delete from convention where NumDec='" + NumDec + "'");
                MessageBox.Show("La convention à été bien supprimé");
            }
            catch(Exception)
            {
                MessageBox.Show("La convention n'a pas été supprimé!");
            }
        }

        public void SupprimerConventionFromProgramme(string tempRefProgramme)
        {
            try
            {
                msh.ExecuteQuery("delete from convention where RefProgramme='" + tempRefProgramme + "'");
                
            }
            catch (Exception)
            {
                
            }
        }

        public void SupprimerConventionFromProjet(string tempNomProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from convention where NomProjet='" + tempNomProjet + "'");

            }
            catch (Exception)
            {

            }
        }
    }
}
