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

        public void AjouterActe(string NumActe, string DateActe, string DateEnrgActe, string DatePubliActe,string Conservation, string RefProjet)
        {
            try
            {
                msh.ExecuteQuery("insert into acteprojet values('" + NumActe + "','" + DateActe + "','" + DateEnrgActe + "','" + DatePubliActe + "','"+Conservation+"','" + RefProjet+"')");
                MessageBox.Show("L'Acte à était bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("L'Acte n'à pas était ajouté");
            }
        }
        public void EditerActe(string NumActe, string DateActe, string DateEnrgActe, string DatePubliActe, string RefProjet, string Conservation, string tempNumActe)
        {
            try
            {
                msh.ExecuteQuery("update acteprojet set NumActe='" + NumActe + "',DateActe='" + DateActe + "',DateEnrgActe='" + DateEnrgActe + "',DatePubliActe='" + DatePubliActe + "',Conservation='"+Conservation+"' where RefProjet='"+RefProjet+"' and NumActe='"+tempNumActe+"'");
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
