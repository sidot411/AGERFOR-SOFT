using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class FNPOSController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterFNPOS(int NumPayement, string NumDeci, string DateDeci, decimal MontantFNPOS, string DateRecu, string NumRecu)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `fnpos` (`NumPayement`, `NumDeciF`, `DateDeciF`, `MontantFNPOS`, `DateRecu`, `NumRecu`) VALUES ('" + NumPayement + "', '" + NumDeci + "',STR_TO_DATE('" + DateDeci + "', '%d/%m/%Y') , '" + MontantFNPOS+ "',STR_TO_DATE('" + DateRecu + "', '%d/%m/%Y') , '" + NumRecu + "')");
                MessageBox.Show("Le CNL à était bien ajouté");
            }
            catch (Exception)
            {
                MessageBox.Show("Le CNL n'a pas était ajouté ");
            }
        }

        public void AnnulerFNPOS(int NumPayement)
        {
            try
            {
                msh.ExecuteQuery("delete from fnpos where NumPayement='" + NumPayement + "'");
                MessageBox.Show("Le CNL à était bien annulé");
            }
            catch (Exception)
            {
                MessageBox.Show("Le CNL n'a pas était annulé");
            }
        }
    }
}
