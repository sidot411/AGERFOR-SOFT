using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class CahierChargeProgrammeController
    {
        MySqlHelper msh = new MySqlHelper();

        public void AjouterCahierCharge (string NomProjet, string RefProgramme, string NumCahierCharge, string DateEnre, string Volume, string NumPubli, string DatePubli,string Conservation, string Notaire,string TelNotaire,string AdresseNotaire, decimal SuperficieCessible, decimal SuperficieVoirie,decimal SuperficieEv, decimal SuperficieEq, decimal AutreSuperficie, string NomPrenomGeo, string AdresseGeo, string TelGeo)
        {
            try
            {
                msh.ExecuteQuery("insert into cahierchargeprogramme values ('"+NomProjet+"','"+RefProgramme+"', '" + NumCahierCharge + "','"+DateEnre+"','"+Volume+"','"+NumPubli+"','"+DatePubli+"','"+Conservation+"','"+Notaire+"','"+TelNotaire+"','"+AdresseNotaire+"','"+SuperficieCessible+"','"+SuperficieVoirie+"','"+SuperficieEv+"','"+SuperficieEq+"','"+AutreSuperficie+"','"+NomPrenomGeo+"','"+AdresseGeo+"','"+TelGeo+"')");
                MessageBox.Show("Le cahier de charge à été bien ajouté");
            }
            catch(Exception)
            {

            }
        }


      


        public void ModifierCahierCharge(string NomProjet, string RefProgramme, string NumCahierCharge, string DateEnre, string Volume, string NumPubli, string DatePubli, string Conservation, string Notaire, string TelNotaire, string AdresseNotaire, decimal SuperficieCessible, decimal SuperficieVoirie, decimal SuperficieEv, decimal SuperficieEq, decimal AutreSuperficie, string NomPrenomGeo, string AdresseGeo, string TelGeo, string tempNumCahierDeCharge)

        {
            try
            {
                msh.ExecuteQuery("update cahierchargeprogramme set NomProjet='" + NomProjet + "',RefProgramme='" + RefProgramme + "',NumCahierCharge='" + NumCahierCharge + "', DateEnre='" + DateEnre + "',Volume='"+ Volume+"' where NumCahierCharge = '" + tempNumCahierDeCharge + "' and NomProjet = '" + NomProjet + "' and RefProgramme = '" + RefProgramme + "'"); 

                                MessageBox.Show("Le cahier de charge à été bien modifié");
            }
            catch(Exception)
            {

            }

        }
        /*
       ,NumPubli='" + NumPubli + "',DatePuli='" + DatePubli + "',Conservation='" + Conservation + "',Notaire='" + Notaire + "',TelNotaire='" + TelNotaire + "',AdresseNotaire='" + AdresseNotaire + "',SuperficieCessible='" + SuperficieCessible + "',SuperficieVoirie='" + SuperficieVoirie + "',SuperficieEv='" + SuperficieEv + "',SuperficieEq='" + SuperficieEq + "',AutreSuperficie='" + AutreSuperficie + "',NomPreomGeo='" + NomPrenomGeo + "',AdresseGeo='" + AdresseGeo + "',TelGeo='" + TelGeo + "' where NumCahierCharge = '"+tempNumCahierDeCharge+"' and NomProjet = '"+NomProjet+ "' and RefProgramme = '"+RefProgramme+"'");*/


        public void SupprimerCahierCharge()
        {

        }
    }
}
