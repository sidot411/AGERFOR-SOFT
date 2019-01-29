using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class AttributionController
    {
        MySqlHelper msh = new MySqlHelper();

        public void AjouterAttribution(string NumAttri, string DateAttri, string CodeClient, string NumProjet, string NumProgramme, string NumBien)
        {
            try
            {
                msh.ExecuteQuery("insert into attribution values '" + NumAttri + "','" + DateAttri + "','" + CodeClient + "','" + NumProjet + "','" + NumProgramme + "','" + NumBien + "'");
                MessageBox.Show("L'attribution a était bien ajouté");   
                    }
            catch(Exception)
            {
                MessageBox.Show("L'attribution n'a pas était ajouté");
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
                msh.ExecuteQuery("delete from attribution where NumAttribution='" + NumAttribution + "'");
                MessageBox.Show("L'attribution a était bien supprimé");
            }
            catch(Exception)
            {
                MessageBox.Show("L'attribution n'a pas était supprimé");
            }
        }



    }
}
