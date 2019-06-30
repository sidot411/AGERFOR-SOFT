using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class CNLController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterCNL(int NumPayement, string Etat)
        {
            try
            {

                msh.ExecuteQuery("INSERT INTO `cnl` (`NumPayement`,`Etat`) VALUES ('" + NumPayement + "', '" + Etat + "'");
                MessageBox.Show("Le CNL à était bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("Le CNL n'a pas était ajouté ");
            }
        }

       // STR_TO_DATE('" + DateDeci + "', '%d/%m/%Y'), '" + MontantCNL + "',STR_TO_DATE('" + DateRecu + "', '%d/%m/%Y') , '" + NumRecu + "')");

        public void updateDateConservation(string DateConserv, string Etat, int NumPayement)
        {
            try
            {

                msh.ExecuteQuery("Update `cnl` set DateConservation=STR_TO_DATE('" + DateConserv + "', '%d/%m/%Y'),Etat='"+Etat+ "' where 	NumPayement='"+NumPayement+"'");
                MessageBox.Show("La date de conservation à été bien modifier");
            }
            catch (Exception)
            {
                MessageBox.Show("La date de conservation n'a pas été bien modifier");
            }
        }
        public void deleteDateConservation(string DateConserv, string Etat, int NumPayement)
        {
            try
            {

                msh.ExecuteQuery("Update `cnl` set DateConservation=NULL,Etat='" + Etat + "' where 	NumPayement='" + NumPayement + "'");
                MessageBox.Show("La date de conservation à été bien supprimer");
            }
            catch (Exception)
            {
                MessageBox.Show("La date de conservation n'a pas été bien supprimer");
            }
        }

        public void updateDateControle(string DateControle, string Etat, int NumPayement)
        {
            try
            {

                msh.ExecuteQuery("Update `cnl` set DateControle=STR_TO_DATE('" + DateControle + "', '%d/%m/%Y'),Etat='" + Etat + "' where 	NumPayement='" + NumPayement + "'");
                MessageBox.Show("La date du controle à été bien modifier");
            }
            catch (Exception)
            {
                MessageBox.Show("La date du controle n'a pas été bien modifier");
            }
        }

        public void DeleteDateControle(string DateControle, string Etat, int NumPayement)
        {
            try
            {

                msh.ExecuteQuery("Update `cnl` set DateControle=NULL,Etat='" + Etat + "' where 	NumPayement='" + NumPayement + "'");
                MessageBox.Show("La date du controle à été bien modifier");
            }
            catch (Exception)
            {
                MessageBox.Show("La date du controle n'a pas été bien modifier");
            }
        }

        public void updateDateReserve(string DateReserve, string Etat, int NumPayement)
        {
            try
            {

                msh.ExecuteQuery("Update `cnl` set DateReserve=STR_TO_DATE('" + DateReserve + "', '%d/%m/%Y'),Etat='" + Etat + "' where NumPayement='" + NumPayement + "'");
                MessageBox.Show("La date Reserve à été bien modifier");
            }
            catch (Exception)
            {
                MessageBox.Show("La date Reserve n'a pas été bien modifier");
            }
        }

        public void DeleteDateReserve(string DateReserve, string Etat, int NumPayement)
        {
            try
            {

                msh.ExecuteQuery("Update `cnl` set DateReserve=NULL,Etat='" + Etat + "' where NumPayement='" + NumPayement + "'");
                MessageBox.Show("La date Reserve à été bien modifier");
            }
            catch (Exception)
            {
                MessageBox.Show("La date Reserve n'a pas été bien modifier");
            }
        }

        public void ValidationCNL(int NumPayement, string NumDecision, string dateDecision, decimal montant,string DateConservation)
        {
            try
            {

                msh.ExecuteQuery("Update `cnl` set NumDeci='"+NumDecision+ "',DateDeci=STR_TO_DATE('" + dateDecision + "', '%d/%m/%Y'),MontantCNL='" + montant+ "',DateConservation=STR_TO_DATE('" + DateConservation + "', '%d/%m/%Y'),Etat='Admis+conservation' where NumPayement='" + NumPayement + "'");
                MessageBox.Show("Le CNL à été bien valider");
            }
            catch (Exception)
            {
                MessageBox.Show("Le CNL n'a pas été valider");
            }
        }

        public void UpdateEtat(string Etat, int NumPayement)
        {
            try
            {

                msh.ExecuteQuery("Update `cnl` set Etat='" + Etat + "' where NumPayement='" + NumPayement + "'");
                MessageBox.Show("L'état CNL à été bien modifier");
            }
            catch (Exception)
            {
                MessageBox.Show("L'état CNL n'a pas été modifier");
            }
        }


        public void AnnulerCNL(int NumPayement)
        {
            try
            {
                msh.ExecuteQuery("delete from cnl where NumPayement='" + NumPayement + "'");
                MessageBox.Show("Le CNL à était bien annulé");
            }
            catch(Exception)
            {
                MessageBox.Show("Le CNL n'a pas était annulé");
            }
        }
    }
}
