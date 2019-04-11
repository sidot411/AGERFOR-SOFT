using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class ActeController
    {
        MySqlHelper msh = new MySqlHelper();
        
        public void AjouterActe(string DateActe, string Volume,string RefPubli,decimal FraisPubli,string Pos,string Conservation,int RefProjet)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `acteprojet` (`DatePubliActe`, `Volume`, `RefPubli`, `FraisPubli`, `Pos`, `Conservation`, `RefProjet`) VALUES (STR_TO_DATE('" + DateActe + "', '%d/%m/%Y'), '"+Volume+"', '"+RefPubli+"', '"+FraisPubli+"', '"+Pos+"','"+Conservation+"', '"+RefProjet+"')");
                MessageBox.Show("L'Acte à était bien ajouté");
              //  messagebox.show
            }
            catch(Exception)
            {
                MessageBox.Show("L'Acte n'à pas était ajouté");
            }
        }
        public void EditerActe(string DateActe, string Volume,string RefPubli,decimal FraisPubli,string Pos,string Conservation,int RefProjet, int tempNumActe)
        {
            try
            {
                msh.ExecuteQuery("update acteprojet set DatePubliActe=STR_TO_DATE('" + DateActe + "', '%d/%m/%Y') ,Volume='" + Volume+"',RefPubli='"+RefPubli+"',FraisPubli='"+FraisPubli+"',Pos='"+Pos+"',Conservation='"+Conservation+"' where RefProjet='"+RefProjet+"' and NumActe='"+tempNumActe+"'");
                MessageBox.Show("L'Acte à était bien modifié");
            }
            catch (Exception)
            {
                MessageBox.Show("L'Acte n'à pas était modifié");
            }
        }
        public void SupprimerActe(string NumActe)
        {
            try
            {
                msh.ExecuteQuery("delete from acteprojet where NumActe = '" + NumActe + "'");
                MessageBox.Show("L'Acte à était bien supprimé");
            }
            catch (Exception)
            {
                MessageBox.Show("L'Acte n'à pas était supprimé");
            }
        }
        public void SupprimerActe2(string RefProjet)
        {
            try
            {
                msh.ExecuteQuery("delete from acteprojet where RefProjet = '" + RefProjet + "'");
                MessageBox.Show("L'Acte à était bien supprimé");
            }
            catch (Exception)
            {
                MessageBox.Show("L'Acte n'à pas était supprimé");
            }
        }
    }
}
