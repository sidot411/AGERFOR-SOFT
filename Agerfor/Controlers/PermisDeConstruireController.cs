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

        public void AjouterPermisConstruire(string DatePermisC,  string NbrLog, decimal SupLog, string NbrLoc, decimal SupLoc, string NbrBur, decimal SupBur, string NbrCave, decimal SupCave, string NbrCC, decimal SupCC, string NbrPS, decimal SupPS,int RefProgramme, int RefProjet)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `permisdeconstruire` (`DatePermisC`, `NbrLog`, `SupLog`, `NbrLoc`, `SupLoc`, `NbrBur`, `SupBur`, `NbrCave`, `SupCave`, `NbrCC`, `SupCC`, `NbrPS`, `SupPS`, `RefProgramme`, `RefProjet`) VALUES (STR_TO_DATE('" + DatePermisC + "', '%d/%m/%Y'),'" + NbrLog + "','" + SupLog + "','" + NbrLoc + "','" + SupLoc + "','" + NbrBur + "','" + SupBur + "','" + NbrCave + "','" + SupCave + "','" + NbrCC + "','" + SupCC + "','" + NbrPS + "','" + SupPS + "','" + RefProgramme + "','" + RefProjet + "')");
                MessageBox.Show("Le permis de construire à été bien ajouté");

            }
            catch(Exception)
            {
                MessageBox.Show("Le permis de construire n'a pas été ajouté");   
            }

        }

        public void ModifierPermisConstruire(string DatePermisC,string NbrLog, decimal SupLog, string NbrLoc, decimal SupLoc, string NbrBur, decimal SupBur, string NbrCave, decimal SupCave, string NbrCC, decimal SupCC, string NbrPS, decimal SupPS , int RefProgramme, int NomProjet ,int tempNumPC )
        {
            try
            {
                msh.ExecuteQuery("update permisdeconstruire set DatePermisC=STR_TO_DATE('" + DatePermisC + "', '%d/%m/%Y'),NbrLog='" + NbrLog+"',SupLog='"+SupLog+"',NbrLoc='"+NbrLoc+"',SupLoc='"+SupLoc+"',NbrBur='"+NbrBur+"',SupBur='"+SupBur+"',NbrCave='"+NbrCave+"',SupCave='"+SupCave+"',NbrCC='"+NbrCC+"',SupCC='"+SupCC+"',NbrPS='"+NbrPS+"',SupPS='"+SupPS+"',RefProgramme='"+RefProgramme+"',NomProjet='"+NomProjet+"' where NumPermis='"+tempNumPC+"'");
                MessageBox.Show("Le permis de construire à été bien modifié");
            }
            catch(Exception)
            {
                MessageBox.Show("Le permis de construire n'a pas été modifié");
            }
        }

        public void SupprimerPermisConstruire (int NumPermisConstruire)
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
                
            }
            catch (Exception)
            {
                
            }
        }

        public void SupprimerPermisConstruireFromProjet(int RefProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from permisdeconstruire where RefProjet='" + RefProjet + "'");
                
            }
            catch (Exception)
            {
                
            }
        }
    }
}
