using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class CreditBancaireController
    {
        MySqlHelper msh = new MySqlHelper();

        public void AjouterCreditBancaire(int numpayement, string NumConvBan,string DateConv, string NomBanque, string BIC, decimal MontantCb)
        {
            try
            {
                msh.ExecuteQuery(" INSERT INTO `creditb` (`NumPayement`,`NumConvBan`, `DateConv`, `NomBanque`, `BIC`, `MontantCb`) VALUES('" + numpayement+"','" + NumConvBan+ "',STR_TO_DATE('" + DateConv + "', '%d/%m/%Y') , '" + NomBanque+"', '"+BIC+"', '"+MontantCb+"')");
                MessageBox.Show("Le crédit bancaire à était bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("Le crédit bancaire n'a pas était ajouté");
            }
        }
    }
}
