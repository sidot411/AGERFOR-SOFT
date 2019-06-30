using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class VSPController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterMainLevee(string DateEtabliVSA, string RefP, string Etat,string Notaire,string AdresseNotaire)
        {
            try
            {
                msh.ExecuteQuery("insert into vsp (DateEtabliVSP,NumVSP,DateVSP,RefP,Etat,NomNotaire,AdresseNotaire) values (STR_TO_DATE('" + DateEtabliVSA + "','%d/%m/%Y'),NULL,NULL,'" + RefP + "','" + Etat + "','"+Notaire+"','"+AdresseNotaire+"')");
                MessageBox.Show("Le VSP a été bien ajoutée");
            }
            catch (Exception)
            {
                MessageBox.Show("Le VSP n'a pas été ajoutée");
            }
        }
        public void ValidationML(int NumVSP, string DateVSP, int CodeVSP)
        {
            try
            {
                msh.ExecuteQuery("update `VSP` set NumVSP='" + NumVSP + "', DateVSP=STR_TO_DATE('" + DateVSP + "','%d/%m/%Y'),Etat='Validée' where 	CodeVSP='" + CodeVSP + "'");
                MessageBox.Show("Le VSPà été bien validée");
            }
            catch (Exception)
            {
                MessageBox.Show("Le VSP n'a aps été validée");
            }


        }

        public void AnnulationMainLevee(int CodeVSP)
        {
            try
            {
                msh.ExecuteQuery("update `VSP` set Etat='Annulée' where CodeVSP='" + CodeVSP + "'");
                MessageBox.Show("Le VSP à été bien validée");
            }
            catch (Exception)
            {
                MessageBox.Show("Le VSP n'a aps été validée");
            }
        }

    }
}
