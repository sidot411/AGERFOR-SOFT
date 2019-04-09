using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    
    class PermiLotirController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterPL(string DatePL, string NbrIlos, string NbrLots,decimal SurfaceB, decimal SuperficieCG, decimal SuperficieVoiries, decimal SuperficieEV, decimal SuperficieEquip, decimal SuperficieAmenag, decimal AutreSuperficie,int refProjet) 
        {
            try

            {
               msh.ExecuteQuery("INSERT INTO `permilotir` (`DatePL`, `NbrIlot`, `NbrLots`,`SurfaceBrute`, `SuperficieCG`, `SuperficieVoiries`, `SuperficieEV`, `SuperficieEquip`, `SuperficieAmenag`, `AutreSupercie`, `RefProjet`) VALUES ('" + DatePL+"','"+NbrIlos+"', '"+NbrLots+"','"+SurfaceB+"', '"+SuperficieCG+"', '"+SuperficieVoiries+"', '"+SuperficieEV+"', '"+SuperficieEquip+"', '"+SuperficieAmenag+"', '"+AutreSuperficie+"', '"+refProjet+"')");    
               MessageBox.Show("Le permi de lotir a été bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("Le permi de lotir n'a pas été ajoutée");
            }

        }

        public void EditerPL(string DatePL, string NbrIlos, string NbrLots, decimal SurfaceB, decimal SuperficieCG, decimal SuperficieVoiries, decimal SuperficieEV, decimal SuperficieEquip, decimal SuperficieAmenag, decimal AutreSuperficie, int RefProjet, string tempNumPL) 
        { 
            try
            {
                msh.ExecuteQuery("update permilotir set DatePL='" + DatePL + "',NbrIlot='" + NbrIlos + "',NbrLots='" + NbrLots + "',SurfaceBrute='"+SurfaceB+"', SuperficieCG='" + SuperficieCG + "',SuperficieVoiries='" + SuperficieVoiries + "',SuperficieEV='" + SuperficieEV + "',SuperficieEquip='" + SuperficieEquip + "',SuperficieAmenag='" + SuperficieAmenag + "',AutreSupercie='" +AutreSuperficie+ "',RefProjet='" +RefProjet+"' where NumPL='"+tempNumPL+"' and RefProjet='"+RefProjet+"'");
                MessageBox.Show("Le permi de lotir a été bien modifié");
            }
            catch(Exception)
            {
                MessageBox.Show("Le permi de lotir n'a pas été modifié");
            }
        }
        public void SupprimerPL(string NumPL)
        {
            try
            {
                msh.ExecuteQuery("delete from permilotir where NumPL='" + NumPL + "'");
                MessageBox.Show("Le permi de lotir a été bien supprimé");
            }
            catch(Exception)
            {
                MessageBox.Show("Le permi de lotir n'a pas été supprimé");
            }
        }
        public void SupprimerPLFromProgramme(string refprogramme)
        {
            try
            {
                msh.ExecuteQuery("delete from permilotir where RefProgramme='" + refprogramme + "'");
                
            }
            catch (Exception)
            {
               
            }
        }

        public void SupprimerPLFromProjet(int RefProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from permilotir where RefProjet='" +RefProjet + "'");
                
            }
            catch (Exception)
            {
                
            }
        }


    }
}
