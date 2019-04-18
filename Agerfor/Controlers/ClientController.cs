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
                msq.ExecuteQuery("insert into client(NumClient,DateCreation,Nom,Prenom,NomAr,PrenomAr,Sexe,DateNaissance,LieuNaissance,PrenomPere,PrenomPereAr,NomMere,PrenomMere,NomMereAr,PrenomMereAr,Cni,DateCni,LieuCni,Ville,Adress,Proffession,Tel,NomContact,TelContact,Situation,NomConj,PrénomConj,NomConjAR,PrenomConjAR,DateNaissanceConj,LieuNaissanceConj,ProfessionConj) values('" + NumClient + "',STR_TO_DATE('" + DateCreation + "', '%d/%m/%Y'),'" + Nom + "','" + Prenom + "','" + NomAr + "','" + PrenomAr + "','" + Sexe + "',STR_TO_DATE('" + DateNaissance + "', '%d/%m/%Y'),'" + LieuNaissance + "','" + PrenomPere + "','" + PrenomPereAr + "','" + NomMere + "','" + PrenomMere + "','" + NomMereAr + "','" + PrenomMereAr + "','" + Cni + "'?STR_TO_DATE('" + DateCni + "', '%d/%m/%Y'),'" + LieuCni + "','" + Ville + "','" + Adress + "','" + Proffession + "','" + Tel + "','" + NomContact + "','" + TelContact + "','"+Situation+"','" + NomConj + "','" + PrenomConj + "','" + NomConjAR + "','" + PrenomConjAR + "','" + DateNaissanceConj + "','" + LieuNaissanceConj + "','" + ProfessionConj +  "') ");
                MessageBox.Show("Le client a était ajouter avec succès");
            }

            catch(Exception)
            {
                MessageBox.Show("Le client n'a pas était ajouté !");
            }
        }

        public void Editclient(string NumClient, string DateCreation, string Nom, string Prenom, string NomAr, string PrenomAr, string Sexe, string DateNaissance, string LieuNaissance, string PrenomPere, string PrenomPereAr, string NomMere, string PrenomMere, string NomMereAr, string PrenomMereAr, string Cni, string DateCni, string LieuCni, string Ville, string Adress, string Proffession, string Tel, string NomContact, string TelContact, string Situation, string NomConj, string PrenomConj, string NomConjAR, string PrenomConjAR, string DateNaissanceConj, string LieuNaissanceConj, string ProfessionConj)
        {
            try
            {
                msq.ExecuteQuery("update client set NumClient='"+ NumClient+ "', DateCreation=STR_TO_DATE('" + DateCreation + "', '%d/%m/%Y'),Nom='" + Nom + "',Prenom='" + Prenom + "',NomAr='" + NomAr + "',PrenomAr='" + PrenomAr + "',Sexe='" + Sexe + "',DateNaissance=STR_TO_DATE('" + DateNaissance + "', '%d/%m/%Y'),LieuNaissance='" + LieuNaissance + "',PrenomPere='" + PrenomPere + "',PrenomPereAr='" + PrenomPereAr + "',NomMere='" + NomMere + "',PrenomMere='" + PrenomMere + "',NomMereAr='" + NomMereAr + "',PrenomMereAr='" + PrenomMereAr + "',Cni='" + Cni + "',DateCni=STR_TO_DATE('" + DateCni + "', '%d/%m/%Y'),LieuCni='" + LieuCni + "',Ville='" + Ville + "',Adress='" + Adress + "',Proffession='" + Proffession + "',Tel='" + Tel + "',NomContact='" + NomContact + "',TelContact='" + TelContact + "',Situation='" + Situation + "',NomConj='" + NomConj + "',PrénomConj='" + PrenomConj + "',NomConjAR='" + NomConjAR + "',PrenomConjAR='" + PrenomConjAR + "',DateNaissanceConj='" + DateNaissanceConj + "',LieuNaissanceConj='" + LieuNaissanceConj + "',ProfessionConj='" + ProfessionConj + "' where ID");
                MessageBox.Show("Le client a était modifié avec succès");
            }

            catch (Exception)
            {
                MessageBox.Show("Le client n'a pas était modifié !");
            }
        }

        public void DeleteClient(string NumClient)
        {
            try
            {
                msq.ExecuteQuery("delete from client where NumClient = '" + NumClient + "'");
                
            }

            catch (Exception)
            {
                MessageBox.Show("Le Client n'a pas était supprimer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
