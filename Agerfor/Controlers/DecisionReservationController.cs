using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class DecisionReservationController
    {
        MySqlHelper msh = new MySqlHelper();


        public void AjouterDecision(string DateED, string RefP, string Etat)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `decisionr` (`DateEtabliDec`, `NumR`, `DateR`, `RefP`, `Etat`) VALUES (STR_TO_DATE('" + DateED + "','%d/%m/%Y'),NULL,NULL,'" + RefP + "', '" + Etat + "')");
            //  MessageBox.Show("INSERT INTO `decisionr` (`DateEtabliDec`, `NumR`, `DateR`, `RefP`, `Etat`) VALUES(STR_TO_DATE('" + DateED + "', '%d/%m/%Y'), NULL, NULL, '" + RefP + "', '" + Etat + "')");
                MessageBox.Show("La décision à été bien ajoutée");
            }
            catch(Exception)
            {
                MessageBox.Show("La décision n'a pas été ajoutée");
            }

        }
        public void ValidationDecision (int NumR, string DateR,int CodeDec)
        {
            try
            {
                msh.ExecuteQuery("update `decisionr` set NumR='" + NumR + "', DateR=STR_TO_DATE('" + DateR + "','%d/%m/%Y'),Etat='Validée' where CodeDec='" + CodeDec + "'");
                MessageBox.Show("La décision à été bien validée");
            }
            catch (Exception)
            {
                MessageBox.Show("La décision n'a aps été validée");
            }


        }

        public void AnnulationDecision(int CodeDec)
        {
            try
            {
                msh.ExecuteQuery("update `decisionr` set Etat='Annulée' where CodeDec='" + CodeDec + "'");
                MessageBox.Show("La décision à été bien validée");
            }
            catch (Exception)
            {
                MessageBox.Show("La décision n'a aps été validée");
            }
        }

    }
}
