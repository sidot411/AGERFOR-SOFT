﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class EddController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterEdd(int RefProjet, string RefProgramme, string DatePubli, string Volume, string Conservation, string Notaire, string TelNotaire, string AdresseNotaire, string NomPrenomGeo, string AdresseGeo, string TelGeo, string NbrLog, decimal SupLog, string NbrLoc, decimal SupLoc, string NbrBur, decimal SupBur, string NbrCave, decimal SupCave, string NbrEQ, decimal SuperficieEQ, string NbrPS, decimal SuperficiePS)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `edd` (`RefProjet`, `RefProgramme`, `DatePubli`, `Volume`, `Conservation`, `Notaire`, `TelNotaire`, `AdresseNotaire`, `NomPrenomGeo`, `AdresseGeo`, `TelGeo`, `NbrLog`, `SuperficieLog`, `NbrLoc`, `SuperficeiLoc`, `NbrBur`, `SuperficieBur`, `NbrCave`, `SuperficieCave`, `NbrEQ`, `SuperficieEQ`, `NbrPS`, `SuperficiePS`) VALUES('"+RefProjet+"', '"+RefProgramme+ "',STR_TO_DATE('" + DatePubli + "', '%d/%m/%Y') , '" + Volume+"', '"+Conservation+"', '"+Notaire+"', '"+TelNotaire+"', '"+AdresseNotaire+"', '"+NomPrenomGeo+"', '"+AdresseGeo+"', '"+TelGeo+"', '"+NbrLog+"', '"+SupLog+"', '"+NbrLoc+"', '"+SupLoc+"', '"+NbrBur+"', '"+SupBur+"', '"+NbrCave+"', '"+SupCave+"', '"+NbrEQ+"', '"+SuperficieEQ+"', '"+NbrPS+"', '"+SuperficiePS+"')");
                    MessageBox.Show("Le EDD à été bien ajouté");
            }
            catch (Exception)
            {
                MessageBox.Show("Le EDD n'a pas été ajouté");
            }
        }

        public void ModifierEdd(int RefProjet, string RefProgramme, string DatePubli, string Volume, string Conservation, string Notaire, string TelNotaire, string AdresseNotaire, string NomPrenomGeo, string AdresseGeo, string TelGeo, string NbrLog, decimal SupLog, string NbrLoc, decimal SupLoc, string NbrBur, decimal SupBur, string NbrCave, decimal SupCave, string NbrCC, decimal SuperficieCC, string NbrPS, decimal SuperficiePS, string tempNumEDD)

        {
            try
            {
                msh.ExecuteQuery("update edd set RefProjet='" + RefProjet + "',RefProgramme='" + RefProgramme + "',DatePubli=STR_TO_DATE('" + DatePubli+ "', '%d/%m/%Y'),Volume='" + Volume + "',Conservation='" + Conservation + "',Notaire='" + Notaire + "',TelNotaire='" + TelNotaire + "',AdresseNotaire='" + AdresseNotaire + "',NomPrenomGeo='" + NomPrenomGeo + "',AdresseGeo='" + AdresseGeo + "',TelGeo='" + TelGeo + "',NbrLog='" + NbrLog + "',SuperficieLog='" + SupLog + "',NbrLoc='" + NbrLoc + "',SuperficeiLoc='" + SupLoc + "',NbrBur='" + NbrBur + "',SuperficieBur='" + SupBur + "',NbrCave='" + NbrCave + "',SuperficieCave='" + SupCave + "',NbrEQ='" + NbrCC + "',SuperficieEQ='" + SuperficieCC + "',NbrPS='" + NbrPS + "',SuperficiePS='" + SuperficiePS + "' where NumEdd = '" + tempNumEDD + "'");
                MessageBox.Show("Le EDD à été bien modifier");
            }
            catch (Exception)
            {
                MessageBox.Show("Le EDD n'a pas été modifier");
            }
        }
        public void SupprimerEdd(string NumEdd)
        {
            try
            {
                msh.ExecuteQuery("delete from edd where NumEdd='" + NumEdd + "'");
                MessageBox.Show("Le EDD à été bien supprimé");
            }
            catch (Exception)
            {
                MessageBox.Show("Le EDD n'a aps été supprimé");
            }
        }

        public void SupprimerEddFromProgramme(string tempRefProgramme)
        {
            try
            {
                msh.ExecuteQuery("delete from Edd where RefProgramme='" + tempRefProgramme + "'");

            }
            catch (Exception)
            {

            }
        }

        public void SupprimerEddFromProjet(string tempNomProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from Edd where NomProjet='" + tempNomProjet + "'");

            }
            catch (Exception)
            {

            }
        }
    }
}
