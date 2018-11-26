using System;
using System.Windows;
namespace Agerfor.Controlers
{
    class ProjetController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterProjet(string RefProjet, string NomProjet, string VolProjet, string Conservation, string Vendeur, string Wilaya, string Daira, string Commune, double Superficie, string NomGeometre, string AdresseGeometre, string NumGeometre, string LimiteNord, string LimiteEst, string LimiteOuest, string LimiteSud, double PrixVente, string NumRecu, string DateRecu)
        {
            try
            {
                msh.ExecuteQuery("insert into projet values('" + RefProjet + "','" + NomProjet + "','" + VolProjet + "','" + Conservation + "','" + Vendeur + "','" + Wilaya + "','" + Daira + "','" + Commune + "','" + Superficie + "','" + NomGeometre + "','" + AdresseGeometre + "','" + NumGeometre + "','" + LimiteNord + "','" + LimiteEst + "','" + LimiteOuest + "','" + LimiteSud + "','" + PrixVente + "','" + NumRecu + "','" + DateRecu + "')");
                MessageBox.Show("Le projet a était ajouter avec succès");
            }

            catch (Exception)
            {
                MessageBox.Show("Le projet n'a pas était ajouté !");
            }
        }
        public void Editprojet(string RefProjet, string NomProjet, string VolProjet, string Conservation, string Vendeur, string Wilaya, string Daira, string Commune, string Superficie, string NomGeometre, string AdresseGeometre, string NumGeometre, string LimiteNord, string LimiteEst, string LimiteOuest, string LimiteSud, string PrixVente, string NumRecu, string DateRecu)
        {
            try
            {
                msh.ExecuteQuery("update projet set RefProjet='" + RefProjet + "',NomProjet='" + NomProjet + "',VolProjet='" + VolProjet + "',Conservation='" + Conservation + "',Vendeur='" + Vendeur + "',Wilaya='" + Wilaya + "',Daira='" + Daira + "',Commune='" + Commune + "',Superficie='" + Superficie + "',NomGeometre='" + NomGeometre + "',AdresseGeometre='" + AdresseGeometre + "',NumGeometre='" + NumGeometre + "',LimiteNord='" + LimiteNord + "',LimiteEst='" + LimiteEst + "',LimiteOuest='" + LimiteOuest + "',LimiteSud='" + LimiteSud + "',PrixVente='" + PrixVente + "',NumRecu='" + NumRecu + "',DateRecu='" + DateRecu + "'");
                MessageBox.Show("Le projet a était modifié avec succès");
            }

            catch (Exception)
            {
                MessageBox.Show("Le projet n'a pas était modifié !");
            }
        }
        public void DeleteProjet(string RefProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from projet where RefProjet = '" +RefProjet+ "'");

            }

            catch (Exception)
            {
                MessageBox.Show("Le projet n'a pas était supprimer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
