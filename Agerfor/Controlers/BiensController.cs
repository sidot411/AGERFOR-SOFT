using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;


namespace Agerfor.Controlers
{
    class BiensController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AjouterBiens(string RefProgramme, string NomProjet,string NumEdd, string NumIlot,string TypeBien,string NumBien, string NumLot,string NumBloc, string Niveau, string NbrPiece, decimal Sup, decimal PrixHT, int Tva, decimal PrixTTC, string LimiteNord, string LimiteSud, string LimiteEst, string LimiteOuest, string Etat)
        {
            try
            {
                msh.ExecuteQuery("insert into biens  values ('" + RefProgramme + "','" + NomProjet + "','"+NumEdd+"', '" + NumIlot + "','"+TypeBien+"','"+NumBien+"', '" + NumLot + "','"+NumBloc+"','"+Niveau+"', '"+NbrPiece+"', '" + Sup + "','" + PrixHT + "','" + Tva + "','" + PrixTTC + "','" + LimiteNord + "','" + LimiteSud + "','" + LimiteEst + "','" + LimiteOuest + "','"+Etat+"')");
                MessageBox.Show("Le bien a été bien ajouté");
            }
            catch (Exception)
            {
                MessageBox.Show("Le bien n'a pas été ajouter");
            }
        }

        public void ModifierBien(string RefProgramme, string NomProjet,string NumEdd, string NumIlot, string TypeBien, string NumBien, string NumLot, string NumBloc, string Niveau, string NbrPiece, decimal Sup, decimal PrixHT, int Tva, decimal PrixTTC, string LimiteNord, string LimiteSud, string LimiteEst, string LimiteOuest, string tempNumBien ,string tempTypeBien)
        {
            try
            {
                msh.ExecuteQuery("update biens set RefProgramme='" + RefProgramme + "',NomProjet='" + NomProjet + "',NumEdd='"+NumEdd+"', NumIlot='" + NumIlot + "',TypeBien='"+TypeBien+"',NumBien='"+NumBien+"', NumLot='" + NumLot + "',NumBloc='"+NumBloc+"',Niveau='"+Niveau+"',NbrPiece='"+NbrPiece+"', Sup='" + Sup + "',PrixHT='" + PrixHT + "',Tva='" + Tva + "',PrixTTC='" + PrixTTC + "',LimiteNord='" + LimiteNord + "',LimiteSud='" + LimiteSud + "',LimiteEst='" + LimiteEst + "',LimiteOuest='" + LimiteOuest + "' where TypeBien='"+tempTypeBien+"' and  NumBien='"+tempNumBien+"' and RefProgramme=+'" + RefProgramme + "' and NomProjet='" + NomProjet + "' and NumEdd='"+NumEdd+"'");
                MessageBox.Show("Le Bien à été bien modifié");
            }
            catch (Exception)
            {
                MessageBox.Show("Le Bien n'a pas été modifié");
            }
        }

        public void SupprimerBien(string tempNumBien, string tempTypeBien, string RefProgramme, string NomProjet, string NumEdd)
        {
            try
            {
                msh.ExecuteQuery("delete from biens  where TypeBien='" + tempTypeBien + "' and  NumBien='" + tempNumBien + "' and RefProgramme=+'" + RefProgramme + "' and NomProjet='" + NomProjet + "' and NumEdd='" + NumEdd + "'");
                MessageBox.Show("Le bien numéro " + tempNumBien + " à été bien supprimé");
            }
            catch (Exception)
            {
                MessageBox.Show("Le bien numéro " + tempNumBien + " n'a pas été supprimé");
            }

        }

        public void BiensEddModificatif(string PreviousNumEDD, string CurrentNumEDD, string RefProgramme, string NomProjet)
        {
            try
            {
                msh.ExecuteQuery("CREATE TEMPORARY TABLE temporary_biens AS SELECT * FROM biens WHERE RefProgramme='"+RefProgramme+ "' and NomProjet='"+NomProjet+"' and  NumEdd='" + PreviousNumEDD + "' and Etat IN ('Réservé','Libre'); UPDATE temporary_biens SET NumEdd = '" + CurrentNumEDD + "'; INSERT INTO biens SELECT * FROM temporary_biens; ");
                MessageBox.Show("Les biens en état libre et réservé on était bien importé dans le nouveau EDD");
            }
            catch(Exception)
            {
                MessageBox.Show("Les biens en pas état libre et réservé n'on pas était inmporté dans le nouveau EDD");
            }
        }

        public void SupprimerLogFromEDD(string NumEDD,string RefProgramme, string NomProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from biens where NumEdd='" + NumEDD + "' and RefProgramme='"+RefProgramme+"' and NomProjet='"+NomProjet+"'");
            }
            catch(Exception)
            {

            }
        }

        public void SupprimerLogFromProgramme(string RefProgramme, string NomProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from biens where  RefProgramme='" + RefProgramme + "' and NomProjet='" + NomProjet + "'");
            }
            catch (Exception)
            {

            }
        }

        public void SupprimerLogFromProjet(string NomProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from biens where NomProjet='" + NomProjet + "'");
            }
            catch (Exception)
            {

            }
        }

    }
}
  