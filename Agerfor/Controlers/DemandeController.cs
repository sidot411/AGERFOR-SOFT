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
      

        public void ajouterDemande(string DateDemande,string RefClient, string Motif, string StatutDemande, string TypeDemande)
        {
            try
            {
                msq.ExecuteQuery("insert into demande(DateDemande,RefClient,Motif,TypeDemande,StatutDemande) values('" + DateDemande + "','" + RefClient + "','" + Motif + "','" + TypeDemande + "','" + StatutDemande + "')");
                MessageBox.Show("La demande a était ajouter avec succès");
            }

            catch (Exception)
            {
                MessageBox.Show("La demande n'a pas était ajouté !");
            }
        }
    }
}
