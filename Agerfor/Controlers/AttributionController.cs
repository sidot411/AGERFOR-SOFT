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

        public void AjouterAttribution(int NumAttri, string DateAttri, string NumClient, string NumProjet, string NumProgramme,string NatureProgramme, string NumIlot, string Numlot, string TypeBien, string NumBloc, string NumBien)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO attribution(NumA,DateAttribution,NumClient,NumProjet,NumProgramme,NatureProgramme, NumIlot,Numlot,TypeBien,NumBloc,NumBien) VALUES ('" + NumAttri+"', '"+DateAttri+"', '"+NumClient+"', '"+NumProjet+"', '"+NumProgramme+"','"+NatureProgramme+"', '"+NumIlot+"', '"+Numlot+"', '"+TypeBien+"', '"+NumBloc+"', '"+NumBien+"')");
                MessageBox.Show("L'attribution a était bien ajouté");
              
                    }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        public void ModifierAttribution(string NumAttri, string DateAttri, string CodeClient, string NumProjet, string NumProgramme, string NumBien, string tempNumAttri)
        {
            try
            {
                msh.ExecuteQuery("update attribution set NumAttribution='" + NumAttri + "',DateAttribution='" + DateAttri + "',CodeClient='" + CodeClient + "',NumProjet='" + NumProjet + "',NumProgramme='" + NumProgramme + "',NumBien='" + NumBien + "' where NumAttribution='" + tempNumAttri + "'");
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
