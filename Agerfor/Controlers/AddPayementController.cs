using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class AddPayementController
    {
        MySqlHelper msh = new MySqlHelper();

        public void AjouterPayement(string DatePayement, int NumAttribution,string NumClient,string NomClient,string prenom, string DateNaissance,string NumCni,int RefProjet, string NomProjet,int RefProgramme, string NomProgramme,string NumIlot,string NumLot,string TypeBien,string NumBloc,string Niveau, string NbrP, decimal SurH,decimal SurU, decimal MontantTotal, decimal MontantVerse, decimal Reste)
        { 
            try
            {
                msh.ExecuteQuery("INSERT INTO `payement` (`DatePayement`, `NumAttribution`, `NumClient`, `NomClient`, `PrenomClient`, `DateNaissance`, `NumCni`, `RefProjet`, `NomProjet`, `RefProgramme`, `NomProgramme`, `NumIlot`, `NumLot`, `TypeBien`, `NumBloc`, `Niveau`, `NbrP`, `SurH`, `SurU`, `MontantTotal`, `MontantVerse`, `Reste`) VALUES(STR_TO_DATE('" + DatePayement + "', '%d/%m/%Y') , '" + NumAttribution + "', '" + NumClient + "', '" + NomClient + "', '" + prenom + "', '" + DateNaissance + "', '" + NumCni + "', '" + RefProjet + "', '" + NomProjet + "', '" + RefProgramme + "', '" + NomProgramme + "', '" + NumIlot + "', '" + NumLot + "', '" + TypeBien + "', '" + NumBloc + "', '" + Niveau + "', '" + NbrP + "', '" + SurH + "', '" + SurU + "', '" + MontantTotal + "', '" + MontantVerse + "', '" + Reste + "') ");
                MessageBox.Show("Le payement à était bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("Le payement n'a pas était ajouté");
                     
            }

        }

        public void ModifierPayement (int RefProjet, string NomProjet, int RefProgramme, string NomProgramme, string NumIlot, string NumLot, string TypeBien, string NumBloc, string Niveau, string NbrP, decimal SurH, decimal SurU, decimal MontantTotal, decimal Reste, int numAtri)
        {
            try
            {
                msh.ExecuteQuery("update payement set RefProjet='" + RefProjet + "',NomProjet='" + NomProjet + "',RefProgramme='" + RefProgramme + "',NomProgramme='" + NomProgramme + "',NumIlot='" + NumIlot + "',NumLot='" + NumLot + "',TypeBien='" + TypeBien + "',NumBloc='" + NumBloc + "',Niveau='" + Niveau + "',NbrP='" + NbrP + "',SurH='" + SurH + "',SurU='" + SurU + "',MontantTotal='" + MontantTotal + "',Reste='" + Reste + "' where NumAttribution='"+numAtri+"'");
                MessageBox.Show("le payement à été bien modifier");
            }
            catch(Exception)
            {
                MessageBox.Show("le payement n'a pas été bien modifier");
            }
        }
    }
}
