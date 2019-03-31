using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class ProjetMaitreController
    {
        MySqlHelper msh = new MySqlHelper();

        public void AjouterProjetMaitre(string NomProjet)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `projetmaitre` (`NomProjetM`) VALUES('" + NomProjet + "')");
                MessageBox.Show("Le projet maitre '" + NomProjet + "' à été bien ajouté");
            }
            catch (Exception)
            {
                MessageBox.Show("Le projet maitre '" + NomProjet + "' n'a pas été ajouté");

            }
        }

        public void SupprimeProjetMaitre(string NomProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from `projetmaitre` where NomProjetM='" + NomProjet + "'");
                MessageBox.Show("Le projet maitre '" + NomProjet + "' à été bien supprimé");
            }
            catch (Exception)
            {
                MessageBox.Show("Le projet maitre '" + NomProjet + "' n'a pas été supprimé");

            }
        }

        public void ModifierProjetMaitre(string NomProjet,string tempNom)
        {
            try
            {
                msh.ExecuteQuery("update `projetmaitre` set NomProjetM='" + NomProjet + "' where NomProjetM='"+tempNom+"'");
                MessageBox.Show("Le projet maitre '" + NomProjet + "' à été bien modifié");
            }
            catch (Exception)
            {
                MessageBox.Show("Le projet maitre '" + NomProjet + "' n'a pas été modifié");

            }

        }
    }
}
