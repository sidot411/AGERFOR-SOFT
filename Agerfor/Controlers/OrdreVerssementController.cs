using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{

    class OrdreVerssementController
    {
        MySqlHelper msh = new MySqlHelper();

        public void AjouterOV(int NumPayement, string NumOV, string DateOV, string DateEcheance, decimal MontantAV, string Etat, string DateRecu, string NumRecu)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `ov` (`NumPayement`, `NumOV`, `DateOV`, `DateEcheance`, `MontantAV`, `Etat`, `DateRecu`, `NumRecu`) VALUES('" + NumPayement + "', '" + NumOV + "', '" + DateOV + "', '" + DateEcheance + "', '" + MontantAV + "', '" + Etat + "', '" + DateRecu + "', '" + NumRecu + "')");
                MessageBox.Show("L'ordre de verssement à était bien  crée");
            }
            catch (Exception)
            {
                MessageBox.Show("L'ordre de verssement n'a pas étai crée");
            }
        }
        public void UpdateOV(string Etat, string DateRecu, string NumRecu, int tempNumVerssement)
        {
            try
            {
                msh.ExecuteQuery("update ov set Etat='"+Etat+"', DateRecu='" + DateRecu + "',NumRecu='" + NumRecu + "' where NumVerssement='" + tempNumVerssement + "'");
                MessageBox.Show("Le verssement à était bien validé");
            }
            catch(Exception)
            {
                MessageBox.Show("Le verssement n'a pas était validé !");
            }
        }
    }
}