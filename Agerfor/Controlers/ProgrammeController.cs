using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class ProgrammeController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterProgramme(string RefProgramme, string NomProgramme, string Site, string Daira, string Commune, string NatureProgramme, string TypeProgramme, string NombreBiens, decimal Superficie)
        {
            try
            {
                msh.ExecuteQuery("insert into programme values('" + RefProgramme + "','" + NomProgramme + "','" + Site + "','" + Daira + "','" + Commune+ "','" + NatureProgramme + "','" + TypeProgramme + "','" + NombreBiens + "','"+Superficie+"')");
                MessageBox.Show("Le programme a était ajouter avec succès");
            }

            catch (Exception)
            {
                MessageBox.Show("Le programme n'a pas était ajouté !");
            }
        }
        public void Editprogramme(string RefProgramme, string NomProgramme, string Site, string Daira, string Commune, string NatureProgramme, string TypeProgramme, string NombreBiens, decimal Superficie)
        {
            try
            {
                msh.ExecuteQuery("update programme set RefProgramme='" + RefProgramme + "',NomProgramme='" + NomProgramme + "',Site='" + Site + "',Daira='" + Daira + "',Commune='" + Commune + "',NatureProgramme='" + NatureProgramme + "',TypeProgramme='" + TypeProgramme + "',NombreBiens='" + NombreBiens + "',Superficie='" + Superficie + "' where RefProgramme");
                MessageBox.Show("Le programme a était modifié avec succès");
            }

            catch (Exception)
            {
                MessageBox.Show("Le pogramme n'a pas était modifié !");
            }
        }
        public void DeleteProgramme(string RefProgramme)
        {
            try
            {
                msh.ExecuteQuery("delete from programme where RefProgramme = '" + RefProgramme + "'");
                MessageBox.Show("Le programme a était supprimé");
            }

            catch (Exception)
            {
                MessageBox.Show("Le programme n'a pas était supprimer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}

