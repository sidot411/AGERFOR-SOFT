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
        public void AjouterPL(string NumPL, string DatePL,decimal FraisDivers, string NbrIlos, string NbrLots, decimal SuperficieCG, decimal SuperficieVoiries, decimal SuperficieEV, decimal SuperficieEquip, decimal SuperficieAmenag, decimal AutreSuperficie, string RefProgramme, string NomProjet) 
        {
            try

            {
               msh.ExecuteQuery("INSERT INTO permilotir VALUES('"+NumPL+"','"+DatePL+"','"+FraisDivers+"','"+NbrIlos+"','"+NbrLots+"','"+SuperficieCG+"','"+SuperficieVoiries+"','"+SuperficieEV+"','"+SuperficieEquip+"','"+SuperficieAmenag+"','"+AutreSuperficie+"','"+RefProgramme+"','"+NomProjet+"')");    
               MessageBox.Show("Le permi de lotir a été bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("Le permi de lotir n'a pas été ajoutée");
            }

        }

        public void EditerPL(string NumPL, string DatePL, decimal FraisDivers, string NbrIlos, string NbrLots, decimal SuperficieCG, decimal SuperficieVoiries, decimal SuperficieEV, decimal SuperficieEquip, decimal SuperficieAmenag, decimal AutreSuperficie, string RefProgramme, string NomProjet, string tempNumPL) 
        { 
            try
            {
                msh.ExecuteQuery("update permilotir set NumPL='" + NumPL + "',DatePL='" + DatePL + "',FraisDiver='" + FraisDivers + "',NbrIlot='" + NbrIlos + "',NbrLots='" + NbrLots + "',SuperficieCG='" + SuperficieCG + "',SuperficieVoiries='" + SuperficieVoiries + "',SuperficieEV='" + SuperficieEV + "',SuperficieEquip='" + SuperficieEquip + "',SuperficieAmenag='" + SuperficieAmenag + "',AutreSupercie='" +AutreSuperficie+ "',RefProgramme='" +RefProgramme+ "',NomProjet='" +NomProjet+"' where NumPL='"+tempNumPL+"' and NomProjet='"+NomProjet+"'");
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

        public void SupprimerPLFromProjet(string NomProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from permilotir where NomProjet='" + NomProjet + "'");
                
            }
            catch (Exception)
            {
                
            }
        }


    }
}
