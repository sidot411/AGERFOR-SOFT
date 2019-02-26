using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class AddPayementController
    {
        MySqlHelper msh = new MySqlHelper();

        public void AjouterPayement(int NumAttribution, string NumClient, decimal MontantTotal, decimal MontantVerse, decimal Reste, decimal Credit)
        {
            try
            {
                msh.ExecuteQuery("insert into payement (NumAttribution,NumCient,MontantTotal,MontantVerse,Reste,Credit) values ('" + NumAttribution + "','" + NumClient + "','" + MontantTotal + "','" + MontantVerse + "','" + Reste + "','" + Credit + "')");
                MessageBox.Show("Le payement a était bien créer pour l'attribution N° '" + NumAttribution + "'");

            }
            catch(Exception)
            {
                  
                     
            }

        }
    }
}
