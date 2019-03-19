using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class CNLController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterCNL(int NumPayement, string NumDeci, string DateDeci, decimal MontantCNL, string DateRecu, string NumRecu)
        {
            try
            {

                msh.ExecuteQuery("INSERT INTO `cnl` (`NumPayement`, `NumDeci`, `DateDeci`, `MontantCNL`, `DateRecu`, `NumRecu`) VALUES ('" + NumPayement + "', '" + NumDeci + "',STR_TO_DATE('" + DateDeci + "', '%d/%m/%Y'), '" + MontantCNL + "',STR_TO_DATE('" + DateRecu + "', '%d/%m/%Y') , '" + NumRecu + "')");
                MessageBox.Show("Le CNL à était bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("Le CNL n'a pas était ajouté ");
            }
        }

        public void AnnulerCNL(int NumPayement)
        {
            try
            {
                msh.ExecuteQuery("delete from cnl where NumPayement='" + NumPayement + "'");
                MessageBox.Show("Le CNL à était bien annulé");
            }
            catch(Exception)
            {
                MessageBox.Show("Le CNL n'a pas était annulé");
            }
        }
    }
}
