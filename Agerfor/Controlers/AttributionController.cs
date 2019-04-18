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

        public void AjouterAttribution( string DateAttri, string NumClient, string NumProjet, string NumProgramme,string NatureProgramme,string TypeBien, string NumIlot, string Numlot, string NumBloc,int IdBien)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `attribution` ( `DateAttribution`, `NumClient`, `NumProjet`, `NumProgramme`, `NatureProgramme`, `TypeBien`, `NumIlot`, `Numlot`, `NumBloc`,`IdBien`) VALUES ( STR_TO_DATE('" + DateAttri + "', '%d/%m/%Y'), '"+NumClient+"', '"+NumProjet+"', '"+NumProgramme+"','"+NatureProgramme+"','"+TypeBien+"', '"+NumIlot+"', '"+Numlot+"', '"+NumBloc+"','"+IdBien+"')");
                MessageBox.Show("L'attribution a était bien ajouté");
              
                    }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ModifierAttribution(string DateAttri, string NumClient, string NumProjet, string NumProgramme,string NatureProgramme, string TypeBien, string NumIlot, string Numlot, string NumBloc, int IdBien, int tempnumattribution)
        {
            try
            {
                msh.ExecuteQuery("update attribution set DateAttribution=STR_TO_DATE('" + DateAttri + "', '%d/%m/%Y'),NumClient='" + NumClient + "',NumProjet='" + NumProjet + "',NumProgramme='" + NumProgramme + "',NatureProgramme='"+NatureProgramme+"',TypeBien='"+TypeBien+"',  NumIlot='" + NumIlot+"',Numlot='"+Numlot+"',NumBLoc='"+NumBloc+ "',IdBien='"+IdBien+"'  where NumA='" + tempnumattribution + "'");
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
