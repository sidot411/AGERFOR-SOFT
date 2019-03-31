using System;
using System.Windows;
namespace Agerfor.Controlers
{
    class ProjetController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterProjet(string NomProjet,string projetmaitre, string Vendeur, string Wilaya, string Daira, string Commune,string Payement, decimal Superficie, string LimiteNord, string LimiteEst, string LimiteOuest, string LimiteSud, decimal MontantCessionB,decimal MontantCession, string NumRecu, string DateRecu)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `projet` (`NomProjet`, `ProjetMaitre`, `Vendeur`, `Wilaya`, `Daira`, `Commune`, `Payement`, `Superficie`, `LimiteNord`, `LimiteEst`, `LimiteOuest`, `LimiteSud`, `MontantCessionB`, `MontantCession`, `NumRecu`, `DateRecu`) VALUES ('" + NomProjet+"', '"+projetmaitre+"', '"+Vendeur+"','"+Wilaya+"','"+Daira+"','"+Commune+"','"+Payement+"','"+Superficie+"','"+LimiteNord+"','"+LimiteEst+"','"+LimiteOuest+"','"+LimiteSud+"','"+MontantCessionB+"','"+MontantCession+"','"+NumRecu+ "',STR_TO_DATE('" + DateRecu + "', '%d/%m/%Y') )");
                MessageBox.Show("Le projet a était ajouter avec succès");
            }

            catch (Exception)
            {
                MessageBox.Show("Le projet n'a pas était ajouté !");
            }
        }
        public void Editprojet(string NomProjet, string projetmaitre, string Vendeur, string Wilaya, string Daira, string Commune, string Payement, decimal Superficie, string LimiteNord, string LimiteEst, string LimiteOuest, string LimiteSud, decimal MontantCessionB, decimal MontantCession, string NumRecu, string DateRecu,int RefProjet)
        {
            try
            {
                msh.ExecuteQuery("update projet set NomProjet='" + NomProjet + "',ProjetMaitre='" + projetmaitre + "', Vendeur='" + Vendeur + "', Wilaya='" + Wilaya + "', Daira='" + Daira + "',Commune='" + Commune + "',Payement='" + Payement + "',Superficie='" + Superficie + "',LimiteNord='" + LimiteNord + "',LimiteEst='" + LimiteEst + "',LimiteOuest='" + LimiteOuest + "',LimiteSud='" + LimiteSud + "',MontantCessionB='" + MontantCessionB + "',MontantCession='" + MontantCession + "',NumRecu='" + NumRecu + "',DateRecu=STR_TO_DATE('" + DateRecu + "', '%d/%m/%Y') where RefProjet='" + RefProjet + "'");
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
