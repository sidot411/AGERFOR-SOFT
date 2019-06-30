using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class ProgrammeController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterProgramme(int RefProjet, string NomProgramme, string Site, string Daira, string Commune, string NatureProgramme, string TypeProgramme, string NombreBiens, decimal Superficie, string TypeVente, decimal CoutFoncier, decimal Tva, decimal CoutFoncierTTC, decimal PrixM2,decimal FraisAdm)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `programme` (`RefProjet`, `NomProgramme`, `Site`, `Daira`, `Commune`, `NatureProgramme`, `TypeProgramme`, `NombreBiens`, `Superficie`,`TypeVente`,`CoutFoncier`,`TVA`,`CoutFoncierTTC`,`PrixM2`,`FraisAdm`) VALUES ('" + RefProjet+"','"+NomProgramme+"', '"+Site+"', '"+Daira+"', '"+Commune+"', '"+NatureProgramme+"', '"+TypeProgramme+"', '"+NombreBiens+"', '"+Superficie+"','"+TypeVente+"','"+CoutFoncier+"','"+Tva+"','"+CoutFoncierTTC+"','"+PrixM2+"','"+FraisAdm+"')");
                    MessageBox.Show("Le programme a était ajouter avec succès");
            }
            catch (MySqlException myException)
            {
                MessageBox.Show("La référance "+NomProgramme+" existe déja veuillez entrer une référance différante - MySQLMessage: " + myException.Message + "\n" ,"Erreur", MessageBoxButton.OK, MessageBoxImage.Error);

            }


        }        
        public void Editprogramme(int RefProjet, string NomProgramme, string Site, string Daira, string Commune, string NatureProgramme, string TypeProgramme, string NombreBiens, decimal Superficie,string TypeVente, decimal CoutFoncier, decimal Tva, decimal CoutFoncierTTC, decimal PrixM2,decimal FraisAdm, int tempRefProgramme)
        {
            try
            {
                msh.ExecuteQuery("update programme set RefProjet='"+RefProjet+"', NomProgramme='" + NomProgramme + "',Site='" + Site + "',Daira='" + Daira + "',Commune='" + Commune + "',NatureProgramme='" + NatureProgramme + "',TypeProgramme='" + TypeProgramme + "',NombreBiens='" + NombreBiens + "',Superficie='" + Superficie + "',TypeVente='"+TypeVente+"', CoutFoncier ='"+CoutFoncier+"',TVA='"+Tva+"',CoutFoncierTTC='"+CoutFoncierTTC+"',PrixM2='"+PrixM2+ "',FraisAdm='"+ FraisAdm+"'  where RefProgramme='" + tempRefProgramme+"'");
                MessageBox.Show("Le programme a était modifié avec succès");
            }

            catch (Exception)
            {
                MessageBox.Show("Le pogramme n'a pas était modifié !");
            }
        }
        public void DeleteProgramme(int RefProgramme)
        {
            try
            {
                msh.ExecuteQuery("delete from programme where RefProgramme = '" + RefProgramme + "'");
                MessageBox.Show("Le programme "+RefProgramme+" à était supprimé");
            }

            catch (Exception)
            {
                MessageBox.Show("Le programme n'a pas était supprimer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        public void DeleteProgrammeFromProjet(int RefProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from programme where RefProjet = '" +RefProjet+ "'");
                MessageBox.Show("Le(s) programme(s) du projet "+RefProjet+" ont était bien supprimé");
            }

            catch (Exception)
            {
                MessageBox.Show("Le programme n'a pas était supprimer", "Erreur", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
      //  MessageBox.S

    }
}

