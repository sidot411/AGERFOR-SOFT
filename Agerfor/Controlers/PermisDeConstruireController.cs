using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class PermisDeConstruireController
    {
        MySqlHelper msh = new MySqlHelper();

        public void AjouterPermisConstruire(string NumPermisConstruire, string DatePermisC, decimal FraisDivers, string NbrLog, decimal SupLog, string NbrLoc, decimal SupLoc, string NbrBur, decimal SupBur, string NbrCave, decimal SupCave, string NbrCC, decimal SupCC, string NbrPS, decimal SupPS,string RefProgramme, string NomProjet)
        {
            try
            {
                msh.ExecuteQuery("insert into permisdeconstruire values ('" + NumPermisConstruire + "','"+DatePermisC+"','"+FraisDivers+"','"+NbrLog+"','"+SupLog+"','"+NbrLoc+"','"+SupLoc+"','"+NbrBur+"','"+SupBur+"','"+NbrCave+"','"+SupCave+"','"+NbrCC+"','"+SupCC+"','"+NbrPS+"','"+SupPS+"','"+RefProgramme+"','"+NomProjet+"')");
                MessageBox.Show("Le permis de construire à été bien ajouté");

            }
            catch(Exception)
            {
                MessageBox.Show("Le permis de construire n'a pas été ajouté");   
            }

        }

        public void ModifierPermisConstruire(string NumPermisConstruire,string DatePermisC,decimal FraisDivers, string NbrLog, decimal SupLog, string NbrLoc, decimal SupLoc, string NbrBur, decimal SupBur, string NbrCave, decimal SupCave, string NbrCC, decimal SupCC, string NbrPS, decimal SupPS , string RefProgramme, string NomProjet ,string tempNumPC )
        {
            try
            {
                msh.ExecuteQuery("update permisdeconstruire set NumPermis='" + NumPermisConstruire + "',DatePermisC='"+DatePermisC+"',FraisDivers='"+FraisDivers+"',NbrLog='"+NbrLog+"',SupLog='"+SupLog+"',NbrLoc='"+NbrLoc+"',SupLoc='"+SupLoc+"',NbrBur='"+NbrBur+"',SupBur='"+SupBur+"',NbrCave='"+NbrCave+"',SupCave='"+SupCave+"',NbrCC='"+NbrCC+"',SupCC='"+SupCC+"',NbrPS='"+NbrPS+"',SupPS='"+SupPS+"',RefProgramme='"+RefProgramme+"',NomProjet='"+NomProjet+"' where NumPermis='"+tempNumPC+"'");
                MessageBox.Show("Le permis de construire à été bien modifié");
            }
            catch(Exception)
            {
                MessageBox.Show("Le permis de construire n'a pas été modifié");
            }
        }

        public void SupprimerPermisConstruire (string NumPermisConstruire)
        {
            try
            {
                msh.ExecuteQuery("delete from permisdeconstruire where NumPermis='" + NumPermisConstruire + "'");
                MessageBox.Show("Le permis de construire à été bien supprimé");
            }
            catch(Exception)
            {
                MessageBox.Show("Le permis de construire n'a pas éé supprimé");
            }
        }

        public void SupprimerPermisConstruireFromProgramme(string tempRefProgramme)
        {
            try
            {
                msh.ExecuteQuery("delete from permisdeconstruire where RefProgramme='" + tempRefProgramme + "'");
                MessageBox.Show("Le permis de construire à été bien supprimé");
            }
            catch (Exception)
            {
                MessageBox.Show("Le permis de construire n'a pas éé supprimé");
            }
        }

        public void SupprimerPermisConstruireFromProjet(string tempNomProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from permisdeconstruire where RefProgramme='" + tempNomProjet + "'");
                MessageBox.Show("Le permis de construire à été bien supprimé");
            }
            catch (Exception)
            {
                MessageBox.Show("Le permis de construire n'a pas éé supprimé");
            }
        }
    }
}
