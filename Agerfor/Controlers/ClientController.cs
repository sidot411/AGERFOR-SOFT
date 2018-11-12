using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class ClientController
    {
        MySqlHelper msq = new MySqlHelper();

        public void ajouterclient (string NumClient,string DateCreation, string Nom, string Prenom, string NomAr , string PrenomAr, string Sexe, string DateNaissance, string LieuNaissance, string PrenomPere , string PrenomPereAr, string NomMere, string PrenomMere, string NomMereAr, string PrenomMereAr, string Cni, string DateCni , string LieuCni, string Ville, string Adress, string Proffession , string Tel , string NomContact , string TelContact, string Situation , string NomConj , string PrenomConj, string NomConjAR , string PrenomConjAR , string DateNaissanceConj, string LieuNaissanceConj, string ProfessionConj)
        {
            try
            {
                msq.ExecuteQuery("insert into client values('" + NumClient + "','" + DateCreation + "','" + Nom + "','" + Prenom + "','" + NomAr + "','" + PrenomAr + "','" + Sexe + "','" + DateNaissance + "','" + LieuNaissance + "','" + PrenomPere + "','" + PrenomPereAr + "','" + NomMere + "','" + PrenomMere + "','" + NomMereAr + "','" + PrenomMereAr + "','" + Cni + "','" + DateCni + "','" + LieuCni + "','" + Ville + "','" + Adress + "','" + Proffession + "','" + Tel + "','" + NomContact + "','" + TelContact + "','"+Situation+"','" + NomConj + "','" + PrenomConj + "','" + NomConjAR + "','" + PrenomConjAR + "','" + DateNaissanceConj + "','" + LieuNaissanceConj + "','" + ProfessionConj +  "') ");
                MessageBox.Show("Le client a était ajouter avec succès");
            }

            catch(Exception)
            {
                MessageBox.Show("Le client n'a pas était ajouté !");
            }
        }
    }
}
