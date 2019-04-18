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
                msh.ExecuteQuery("INSERT INTO `payement` (`DatePayement`, `NumAttribution`, `NumClient`, `NomClient`, `PrenomClient`, `DateNaissance`, `NumCni`, `RefProjet`, `NomProjet`, `RefProgramme`, `NomProgramme`, `NumIlot`, `NumLot`, `TypeBien`, `NumBloc`, `Niveau`, `NbrP`, `SurH`, `SurU`, `MontantTotal`, `MontantVerse`, `Reste`) VALUES( '" + DatePayement + "', '" + NumAttribution + "', '" + NumClient + "', '" + NomClient + "', '" + prenom + "', '" + DateNaissance + "', '" + NumCni + "', '" + RefProjet + "', '" + NomProjet + "', '" + RefProgramme + "', '" + NomProgramme + "', '" + NumIlot + "', '" + NumLot + "', '" + TypeBien + "', '" + NumBloc + "', '" + Niveau + "', '" + NbrP + "', '" + SurH + "', '" + SurU + "', '" + MontantTotal + "', '" + MontantVerse + "', '" + Reste + "') ");
                MessageBox.Show("Le payement à était bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("Le payement n'a pas était ajouté");
                     
            }

        }
    }
}
