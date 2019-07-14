using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class OvSoldeController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterOvSolde(string DateOvSolde,int CodeClient, string DateEchOvSolde, string NomProgramme,decimal Montant, string EtatOvSolde, string DateRecu, string NumRecu)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `ovsolde` ( `CodeClient`, `DateOvSolde`, `DateEchOvSolde`, `NomProgramme`, `Montant`, `EtatOvSolde`) VALUES ('" + CodeClient + "',STR_TO_DATE('" + DateOvSolde+ "','%d/%m/%Y'),STR_TO_DATE('" + DateEchOvSolde + "','%d/%m/%Y'),'"+NomProgramme+"','"+Montant+"', '"+EtatOvSolde+ "' )");
                MessageBox.Show("L'OV a été bien ajouté");
            }
            catch(Exception )
            {
                MessageBox.Show("L'OV n'a pas été ajouté");
            }
        }
        public void validerOvSolde(string DateRecu, string NumRecu, string Etat)
        {
            try
            {
                msh.ExecuteQuery("update ovsolde set DateRecu=STR_TO_DATE('" + DateRecu + "','%d/%m/%Y'), NumRecu='" + NumRecu + "', EtatOvSolde='" + Etat+"'");
     
            }
            catch(Exception)
            {
                MessageBox.Show("L'OV n'a pas été validé");
            }
        }
        public void UseOvSolde(string id)
        {
            try
            {
                msh.ExecuteQuery("update ovsolde set EtatOvSolde='Utilisé'");
            }
            catch (Exception)
            {
                MessageBox.Show("Le l'apport n'a pas été utilisé dans le paiement !");
            }
        }
    }
}
