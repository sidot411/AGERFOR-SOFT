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
        public void AjouterFNPOS(int NumPayement, string NumDeci, string DateDeci, decimal MontantFNPOS)
        {
            try
            {
                msh.ExecuteQuery("update fnpos set NumDeciF='"+NumDeci+ "', DateDeciF=STR_TO_DATE('" + DateDeci + "', '%d/%m/%Y') , MontantFNPOS= '" + MontantFNPOS + "' where NumPayement='" + NumPayement + "'");
                MessageBox.Show("Le FNPOS à était bien ajouté");
            }
            catch (Exception)
            {
                MessageBox.Show("Le FNPOS n'a pas était ajouté ");
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
