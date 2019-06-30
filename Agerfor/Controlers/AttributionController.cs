using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Agerfor.Controlers;

namespace Agerfor.Controlers
{
    class AttributionController
    {
        MySqlHelper msh = new MySqlHelper();

        public void AjouterAttribution( string DateAttri, string NumClient, string NumProjet, string NumProgramme,string NatureProgramme,string TypeBien, string NumIlot, string Numlot, string NumBloc,int IdBien,string DateDLE,string DateDLR,string RefDL)
        {
            try
            {
                if (DateDLR !="" && DateDLE!="")
                {
                    msh.ExecuteQuery("INSERT INTO `attribution` ( `DateAttribution`, `NumClient`, `NumProjet`, `NumProgramme`, `NatureProgramme`, `TypeBien`, `NumIlot`, `Numlot`, `NumBloc`,`IdBien`,`DateDLE`,`DateDLR`,`RefDL`) VALUES ( STR_TO_DATE('" + DateAttri + "', '%d/%m/%Y'), '" + NumClient + "', '" + NumProjet + "', '" + NumProgramme + "','" + NatureProgramme + "','" + TypeBien + "', '" + NumIlot + "', '" + Numlot + "', '" + NumBloc + "','" + IdBien + "',STR_TO_DATE('" + DateDLE + "', '%d/%m/%Y'),STR_TO_DATE('" + DateDLR + "', '%d/%m/%Y'),'" + RefDL + "')");
                }
                else if (DateDLR == "" && DateDLE=="")
                {
                    msh.ExecuteQuery("INSERT INTO `attribution` ( `DateAttribution`, `NumClient`, `NumProjet`, `NumProgramme`, `NatureProgramme`, `TypeBien`, `NumIlot`, `Numlot`, `NumBloc`,`IdBien`,`DateDLE`,`DateDLR`,`RefDL`) VALUES ( STR_TO_DATE('" + DateAttri + "', '%d/%m/%Y'), '" + NumClient + "', '" + NumProjet + "', '" + NumProgramme + "','" + NatureProgramme + "','" + TypeBien + "', '" + NumIlot + "', '" + Numlot + "', '" + NumBloc + "','" + IdBien + "',NULL,NULL,'" + RefDL + "')");

                }
                else if(DateDLR != "" && DateDLE == "")
                {
                    msh.ExecuteQuery("INSERT INTO `attribution` ( `DateAttribution`, `NumClient`, `NumProjet`, `NumProgramme`, `NatureProgramme`, `TypeBien`, `NumIlot`, `Numlot`, `NumBloc`,`IdBien`,`DateDLE`,`DateDLR`,`RefDL`) VALUES ( STR_TO_DATE('" + DateAttri + "', '%d/%m/%Y'), '" + NumClient + "', '" + NumProjet + "', '" + NumProgramme + "','" + NatureProgramme + "','" + TypeBien + "', '" + NumIlot + "', '" + Numlot + "', '" + NumBloc + "','" + IdBien + "',NULL,STR_TO_DATE('" + DateDLR + "', '%d/%m/%Y'),'" + RefDL + "')");

                }
                else if (DateDLR == "" && DateDLE != "")
                {
                    msh.ExecuteQuery("INSERT INTO `attribution` ( `DateAttribution`, `NumClient`, `NumProjet`, `NumProgramme`, `NatureProgramme`, `TypeBien`, `NumIlot`, `Numlot`, `NumBloc`,`IdBien`,`DateDLE`,`DateDLR`,`RefDL`) VALUES ( STR_TO_DATE('" + DateAttri + "', '%d/%m/%Y'), '" + NumClient + "', '" + NumProjet + "', '" + NumProgramme + "','" + NatureProgramme + "','" + TypeBien + "', '" + NumIlot + "', '" + Numlot + "', '" + NumBloc + "','" + IdBien + "',STR_TO_DATE('" + DateDLE + "', '%d/%m/%Y'),NULL,'" + RefDL + "')");

                }

                MessageBox.Show("L'attribution a était bien ajouté");
              
                    }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ModifierAttribution(string DateAttri, string NumClient, string NumProjet, string NumProgramme,string NatureProgramme, string TypeBien, string NumIlot, string Numlot, string NumBloc, int IdBien, int tempnumattribution, string DateDLE, string DateDLR, string RefD)
        {
            try
            {
                msh.ExecuteQuery("update attribution set DateAttribution=STR_TO_DATE('" + DateAttri + "', '%d/%m/%Y'),NumClient='" + NumClient + "',NumProjet='" + NumProjet + "',NumProgramme='" + NumProgramme + "',NatureProgramme='"+NatureProgramme+"',TypeBien='"+TypeBien+"',  NumIlot='" + NumIlot+"',Numlot='"+Numlot+"',NumBloc='"+NumBloc+ "',IdBien='"+IdBien+ "',DateDLE=STR_TO_DATE('" + DateDLE + "', '%d/%m/%Y'),	DateDLR=STR_TO_DATE('" + DateDLR + "', '%d/%m/%Y'),RefDL='" + RefD+"'  where NumA='" + tempnumattribution + "'");  
                MessageBox.Show("L'attribution a était bien modifié");
            }
            catch(Exception)
            {
                MessageBox.Show("L'attribution n'a pas était modifié");
            }
        }
        public void SupprimerAttribution(string NumAttribution)
        {
            try
            {
                msh.ExecuteQuery("delete from attribution where NumA='" + NumAttribution + "'");
                MessageBox.Show("L'attribution a était bien supprimé");
            }
            catch(Exception)
            {
                MessageBox.Show("L'attribution n'a pas était supprimé");
            }
        }



    }
}
