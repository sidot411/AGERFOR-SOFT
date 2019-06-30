using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class MainLeveeController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterMainLevee(string DateEML, string RefP, string Etat, string Notaire,string AdresseNotaire)
        {
            try
            {
                msh.ExecuteQuery("insert into mainlevee (DateEtabliML,NumML,DateML,RefP,Etat,NomNotaire,AdresseNotaire) values (STR_TO_DATE('" + DateEML + "','%d/%m/%Y'),NULL,NULL,'" + RefP + "','" + Etat + "','"+Notaire+"','"+AdresseNotaire+"')");
                MessageBox.Show("La main levée a été bien ajoutée");
            }
            catch(Exception)
            {
                MessageBox.Show("La main levée n'a pas été ajoutée");
            }
        }

        public void ValidationML(int NumML, string DateML, int CodeML)
        {
            try
            {
                msh.ExecuteQuery("update `mainlevee` set NumML='" + NumML + "', DateML=STR_TO_DATE('" + DateML + "','%d/%m/%Y'),Etat='Validée' where CodeML='" + CodeML + "'");
                MessageBox.Show("La Mai Levée à été bien validée");
            }
            catch (Exception)
            {
                MessageBox.Show("La Main Levée n'a aps été validée");
            }


        }

        public void AnnulationMainLevee(int CodeML)
        {
            try
            {
                msh.ExecuteQuery("update `mainlevee` set Etat='Annulée' where CodeML='" + CodeML + "'");
                MessageBox.Show("La Main Levee à été bien validée");
            }
            catch (Exception)
            {
                MessageBox.Show("La Main Levee n'a aps été validée");
            }
        }



    }
}
