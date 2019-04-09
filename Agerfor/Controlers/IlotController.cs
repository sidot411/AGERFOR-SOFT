using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    
    class IlotController
    {
        MySqlHelper msh = new MySqlHelper();
        public void ajouterIlot(string NumILot, int CodeProjet)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `listeilot` (`NumIlot`, `RefProjet`) VALUES( '"+NumILot+"', '"+CodeProjet+"')");
                MessageBox.Show("Le Ilot à été bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("Le Ilot n'a pas été ajouter");
            }
        }

        public void modifierIlot(string NumIlot, int CodeProjet, int Id)
        {
            try
            {
                msh.ExecuteQuery("update `listeilot` set NumIlot='"+NumIlot+"',CodeProjet='"+CodeProjet+"' where Id='"+Id+"'");
                MessageBox.Show("Le Ilot à été bien modifié");
            }
            catch (Exception)
            {
                MessageBox.Show("Le Ilot n'a pas été modifié");
            }
        }
        public void SupprimerIlot(int Id)
        {
            try
            {
                msh.ExecuteQuery("delete from `listeilot` where Id='"+Id+"'");
                MessageBox.Show("Le Ilot à été bien supprimé");
            }
            catch (Exception)
            {
                MessageBox.Show("Le Ilot n'a pas été supprimé");
            }
        }

    }
}
