using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class LotController
    {
        MySqlHelper msh = new MySqlHelper();
        public void Ajouterlot(string RefProgramme, string NomProjet, string NumIlot, string NumLot, decimal Sup, decimal PrixHT,int Tva,decimal PrixTTC, string LimiteNord,string LimiteSud, string LimiteEst, string LimiteOuest)
        {
            try
            {
                msh.ExecuteQuery("insert into lot  values ('" + RefProgramme + "','" + NomProjet + "','" + NumIlot + "','" + NumLot + "','"+Sup+"','" + PrixHT + "','"+Tva+"','"+PrixTTC+"','" + LimiteNord + "','" + LimiteSud + "','" + LimiteEst + "','" + LimiteOuest + "')");
                MessageBox.Show("Le lot a été bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("Le lot n'a pas été ajouter");
            }
        }

        public void Modifierlot(string RefProgramme, string NomProjet, string NumIlot, string NumLot, decimal Sup, decimal PrixHT, int Tva, decimal PrixTTC, string LimiteNord, string LimiteSud, string LimiteEst, string LimiteOuest, string tempNumLot)
        {
            try
            {
                msh.ExecuteQuery("update lot set RefProgramme='" + RefProgramme + "',NomProjet='" + NomProjet + "',NumIlot='" + NumIlot + "',NumLot='" + NumLot + "',Sup='" + Sup + "',PrixHT='" + PrixHT + "',Tva='" + Tva + "',PrixTTC='" + PrixTTC + "',LimiteNord='" + LimiteNord + "',LimiteSud='" + LimiteSud + "',LimiteEst='" + LimiteEst + "',LimiteOuest='" + LimiteOuest + "' where NumLot='" + tempNumLot + "' and RefProgramme=+'" + RefProgramme + "' and NomProjet='" + NomProjet + "'");
                MessageBox.Show("Le Lot à été bien modifié"); 
            }
            catch(Exception)
            {
                MessageBox.Show("Le Lot n'a pas été modifié");
            }
        }

        public void SupprimerLot(string NumLot)
        {
            try
            {
                msh.ExecuteQuery("delete from lot where NumLot='" + NumLot + "'");
                MessageBox.Show("Le lot numéro " + NumLot + " à été bien supprimé");
            }
            catch(Exception)
            {
                MessageBox.Show("Le lot numéro " + NumLot + " n'a pas été supprimé");
            }

        }
            

      }
}
