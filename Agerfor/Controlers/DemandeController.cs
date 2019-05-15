using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Agerfor.Controlers
{
    class DemandeController
    {
        MySqlHelper msq = new MySqlHelper();
      

        public void ajouterDemande(string DateDemande,string RefClient, string Motif, string StatutDemande, string TypeDemande,string NatureDemande)
        {
            try
            {
                msq.ExecuteQuery("insert into demande(DateDemande,RefClient,Motif,NatureDemande,TypeDemande,StatutDemande,DateReponse) values (STR_TO_DATE('" + DateDemande + "','%d/%m/%Y'),'" + RefClient + "','" + Motif + "','"+NatureDemande+"', '" + TypeDemande + "','" + StatutDemande + "',NULL)");
                MessageBox.Show("La demande a était ajouter avec succès");
            }

            catch (Exception)
            {
                MessageBox.Show("La demande n'a pas était ajouté !");
            }
        }
        public void supprimerDemande(string Numdemande)
        {
            try
            {
                msq.ExecuteQuery("delete from demande where NumDemande='" + Numdemande + "'");
                MessageBox.Show("La demande a était supprimée avec succès");
            }
            catch(Exception)
            {
                MessageBox.Show("La demande n'a pas était supprimée !");
            }
        } 
        public void accepterDemande(string NumDemande)
        {
            try
            {
                MessageBox.Show("update demande set StatutDemande='Acceptée',  DateReponse = STR_TO_DATE('" + (System.DateTime.Now.Date).ToString("dd/MM/yyyy") + "','%d/%m/%Y') where NumDemande='" + NumDemande + "'");
                msq.ExecuteQuery("update demande set StatutDemande='Acceptée',  DateReponse = STR_TO_DATE('"+(System.DateTime.Now.Date).ToString("dd/MM/yyyy") +"','%d/%m/%Y') where NumDemande='"+NumDemande+"'");
                MessageBox.Show("La demande à était Acceptée");
            }
                catch(Exception)
            {
                MessageBox.Show("La demande n'a pas était Acceptée");
            }
        }
        public void RefuserDemande(string NumDemande)
        {
            try
            {
                msq.ExecuteQuery("update demande set StatutDemande='Refusée', DateReponse = STR_TO_DATE('" + (System.DateTime.Now.Date).ToString("dd/MM/yyyy") + "','%d/%m/%Y') where NumDemande='" + NumDemande + "'");
                MessageBox.Show("La demande à était Refusée");
            }
            catch (Exception)
            {
                MessageBox.Show("La demande n'a pas était Refusée");
            }
        }
        public void AnnulerDemande(string NumDemande)
        {
            try
            {
                msq.ExecuteQuery("update demande set StatutDemande='Annulée' where NumDemande='" + NumDemande + "'");
                MessageBox.Show("La demande à était Annulée");
            }
            catch (Exception)
            {
                MessageBox.Show("La demande n'a pas était Annulée");
            }
        }
    }
}
