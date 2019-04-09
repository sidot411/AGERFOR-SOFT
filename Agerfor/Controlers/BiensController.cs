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
        public void AjouterBiens(int RefProgramme, int RefProjet,int NumEdd, string NumIlot,string TypeBien, string NumLot,string NumBloc, string Niveau, string NbrPiece, decimal SupH,decimal SupU, decimal PrixHT, int Tva, decimal PrixTTC, string LimiteNord, string LimiteSud, string LimiteEst, string LimiteOuest, string Etat)
        {
            try
            {
                msh.ExecuteQuery("insert into biens  values ('" + RefProgramme + "','" + RefProjet + "','"+NumEdd+"', '" + NumIlot + "','"+TypeBien+"', '" + NumLot + "','"+NumBloc+"','"+Niveau+"', '"+NbrPiece+"', '" + SupH + "','"+SupU+"','" + PrixHT + "','" + Tva + "','" + PrixTTC + "','" + LimiteNord + "','" + LimiteSud + "','" + LimiteEst + "','" + LimiteOuest + "','"+Etat+"')");
                MessageBox.Show("Le bien a été bien ajouté");
            }
            catch (Exception)
            {
                MessageBox.Show("Le bien n'a pas été ajouter");
            }
        }

        public void ModifierBien(int RefProgramme, int RefProjet,int NumEdd, string NumIlot, string TypeBien, string NumLot, string NumBloc, string Niveau, string NbrPiece, decimal SupH,decimal SupU, decimal PrixHT, int Tva, decimal PrixTTC, string LimiteNord, string LimiteSud, string LimiteEst, string LimiteOuest, string tempNumlot ,string tempTypeBien)
        {
            try
            {
                msh.ExecuteQuery("update biens set RefProgramme='" + RefProgramme + "',RefProjet='" + RefProjet + "',NumEdd='"+NumEdd+"', NumIlot='" + NumIlot + "',TypeBien='"+TypeBien+"', NumLot='" + NumLot + "',NumBloc='"+NumBloc+"',Niveau='"+Niveau+"',NbrPiece='"+NbrPiece+"', SupH='" + SupH + "',SupU='"+SupU+"', PrixHT='" + PrixHT + "',Tva='" + Tva + "',PrixTTC='" + PrixTTC + "',LimiteNord='" + LimiteNord + "',LimiteSud='" + LimiteSud + "',LimiteEst='" + LimiteEst + "',LimiteOuest='" + LimiteOuest + "' where TypeBien='"+tempTypeBien+"' and  Numlot='"+tempNumlot+"' and RefProgramme=+'" + RefProgramme + "' and RefProjet='" + RefProjet + "' and NumEdd='"+NumEdd+"'");
                MessageBox.Show("Le Bien à été bien modifié");
            }
            catch (Exception)
            {
                MessageBox.Show("Le Bien n'a pas été modifié");
            }
        }

        public void SupprimerBien(string NumILot, string NumLot, string NumBloc, string Niveau , string tempNumlot, string tempTypeBien, int RefProgramme, int RefProjet, int NumEdd)
        {
            try
            {
                msh.ExecuteQuery("delete from biens  where NumIlot='"+NumILot+"' and NumLot='"+NumLot+"' and NumBloc='"+NumBloc+"' and Niveau='"+Niveau+"' and TypeBien='" + tempTypeBien + "' and  Numlot='" + tempNumlot + "' and RefProgramme=+'" + RefProgramme + "' and RefProjet='" + RefProjet + "' and NumEdd='" + NumEdd + "'");
                MessageBox.Show("Le bien numéro " + tempNumlot + " à été bien supprimé");
            }
            catch (Exception)
            {
                MessageBox.Show("Le bien numéro " + tempNumlot + " n'a pas été supprimé");
            }

        }

        public void BiensEddModificatif(int PreviousNumEDD, int CurrentNumEDD, int RefProgramme, int RefProjet)
        {
            try
            {
                msh.ExecuteQuery("CREATE TEMPORARY TABLE temporary_biens AS SELECT * FROM biens WHERE RefProgramme='"+RefProgramme+ "' and RefProjet='"+RefProjet+"' and  NumEdd='" + PreviousNumEDD + "' and Etat IN ('Réservé','Libre'); UPDATE temporary_biens SET NumEdd = '" + CurrentNumEDD + "'; INSERT INTO biens SELECT * FROM temporary_biens; ");
                MessageBox.Show("Les biens en état libre et réservé on était bien importé dans le nouveau EDD");
            }
            catch(Exception)
            {
                MessageBox.Show("Les biens en pas état libre et réservé n'on pas était inmporté dans le nouveau EDD");
            }
        }

        public void SupprimerLogFromEDD(int NumEDD,int RefProgramme, int RefProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from biens where NumEdd='" + NumEDD + "' and RefProgramme='"+RefProgramme+"' and RefProjet='"+RefProjet+"'");
            }
            catch(Exception)
            {

            }
        }

        public void SupprimerLogFromProgramme(int RefProgramme, int RefProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from biens where  RefProgramme='" + RefProgramme + "' and RefProjet='" + RefProjet + "'");
            }
            catch (Exception)
            {

            }
        }

        public void SupprimerLogFromProjet(int RefProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from biens where RefProjet='" + RefProjet + "'");
            }
            catch (Exception)
            {

            }
        }

    }
}
  