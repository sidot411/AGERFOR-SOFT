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
        public void Ajouterlot(string RefProgramme, string NomProjet,string NumCC, string NumIlot, string NumLot, decimal Sup, decimal PrixHT,int Tva,decimal PrixTTC, string LimiteNord,string LimiteSud, string LimiteEst, string LimiteOuest, string Etat)
        {
            try
            {
                msh.ExecuteQuery("insert into lot  values ('" + RefProgramme + "','" + NomProjet + "','"+NumCC+"','" + NumIlot + "','" + NumLot + "','"+Sup+"','" + PrixHT + "','"+Tva+"','"+PrixTTC+"','" + LimiteNord + "','" + LimiteSud + "','" + LimiteEst + "','" + LimiteOuest + "','"+Etat+"')");
                MessageBox.Show("Le lot a été bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("Le lot n'a pas été ajouter");
            }
        }

        public void Modifierlot(string RefProgramme, string NomProjet,string NumCC, string NumIlot, string NumLot, decimal Sup, decimal PrixHT, int Tva, decimal PrixTTC, string LimiteNord, string LimiteSud, string LimiteEst, string LimiteOuest, string tempNumLot, string Etat)
        {
            try
            {
                msh.ExecuteQuery("update lot set RefProgramme='" + RefProgramme + "',NomProjet='" + NomProjet + "',NumCC='"+NumCC+"', NumIlot='" + NumIlot + "',NumLot='" + NumLot + "',Sup='" + Sup + "',PrixHT='" + PrixHT + "',Tva='" + Tva + "',PrixTTC='" + PrixTTC + "',LimiteNord='" + LimiteNord + "',LimiteSud='" + LimiteSud + "',LimiteEst='" + LimiteEst + "',LimiteOuest='" + LimiteOuest + "',Etat='"+Etat+"' where NumLot='" + tempNumLot + "' and RefProgramme=+'" + RefProgramme + "' and NomProjet='" + NomProjet + "' and NumCC='"+NumCC+"'");
                MessageBox.Show("Le Lot à été bien modifié"); 
            }
            catch(Exception)
            {
                MessageBox.Show("Le Lot n'a pas été modifié");
            }
        }

        public void SupprimerLot(string NumLot, string RefProgramme, string NomProjet, string NumCC)
        {
            try
            {
                msh.ExecuteQuery("delete from lot where NumLot='" + NumLot + "' and RefProgramme='"+RefProgramme+"' and NomProjet='"+NomProjet+"' and NumCC='"+NumCC+"'");
                MessageBox.Show("Le lot numéro " + NumLot + " à été bien supprimé");
            }
            catch(Exception)
            {
                MessageBox.Show("Le lot numéro " + NumLot + " n'a pas été supprimé");
            }

        }

        public void LotsModificatif(string PreviousNumCC, string CurrentNumCC, string RefProgramme, string NomProjet)
        {
            try
            {
                msh.ExecuteQuery("CREATE TEMPORARY TABLE temporary_Lot AS SELECT * FROM Lot WHERE RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "' and  NumCC='" + PreviousNumCC + "' and Etat IN ('Réservé','Libre'); UPDATE temporary_lot SET NumCC = '" + CurrentNumCC + "'; INSERT INTO lot SELECT * FROM temporary_lot; ");
                MessageBox.Show("Les lots en état libre et réservé on était bien importé dans le nouveau cahier des charges");
            }
            catch (Exception)
            {
                MessageBox.Show("Les lots en état libre et réservé n'on pas était importé dans le nouveau cahier des charges");
            }
        }


    }
}
