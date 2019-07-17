using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class UsersControlle
    {
        MySqlHelper msh = new MySqlHelper();

        public void AddUser(string UserName,string Password, string Division, string UserRole, string Sprojet, string Sprogramme, string Sclient,
            string Sdemande, string Sattribution, string Spayement,string Sremboursement, string Sparametre)
        {
            try
            {
                msh.ExecuteQuery("INSERT INTO `users` (`UserName`, `UserPassword`, `Divison`, `Role`, `Sprojet`, `Sprogramme`, `Sclient`, `Sdemande`, `Sattribution`, `Spayement`, `Sremboursement`, `Sparametre`) VALUES ('"+UserName+ "',AES_ENCRYPT ('"+Password+"','BCGE2380A579C'),'"+Division+"', '"+UserRole+"', '"+Sprojet+"', '"+Sprogramme+"', '"+Sclient+"', '"+Sdemande+"', '"+Sattribution+"', '"+Spayement+"', '"+Sremboursement+"', '"+Sparametre+"')");
               // Clipboard.SetText("INSERT INTO `users` (`UserName`, `UserPassword`, `Divison`, `Role`, `Sprojet`, `Sprogramme`, `Sclient`, `Sdemande`, `Sattribution`, `Spayement`, `Sremboursement`, `Sparametre`) VALUES ('" + UserName + "',AES_ENCRYPT ('" + Password + "','AGERFOR31'),'" + Division + "', '" + UserRole + "', '" + Sprojet + "', '" + Sprogramme + "', '" + Sclient + "', '" + Sdemande + "', '" + Sattribution + "', '" + Spayement + "', '" + Sremboursement + "', '" + Sparametre + "')");

                MessageBox.Show("L'utilisateur a été bien ajouté");
            }
            catch(Exception)
            {
                MessageBox.Show("Le nom d'utilisateur existe déja veuillez introduire un nouveau");
            }
        }

        public void EditUser(string UserName, string Password, string Division, string UserRole, string Sprojet, string Sprogramme, string Sclient,
            string Sdemande, string Sattribution, string Spayement, string Sremboursement, string Sparametre, string tempUserName)
        {
            try
            {
                msh.ExecuteQuery("update `users` set UserName='"+UserName+ "', UserPassword=AES_ENCRYPT ('" + Password + "','BCGE2380A579C'), Divison='"+Division+"',Role='"+UserRole+"', Sprojet='"+Sprojet+"',Sprogramme='"+Sprogramme+"',Sclient='"+Sclient+"', Sdemande='"+Sdemande+"', Sattribution='"+Sattribution+"', Spayement='"+Spayement+"', Sremboursement='"+Sremboursement+"', Sparametre='"+Sparametre+ "' where UserName='"+tempUserName+"'");
               
                MessageBox.Show("L'utilisateur a été bien modifié");
            }
            catch (Exception)
            {
                MessageBox.Show("L'utilisateur n'a pas été modifié");
            }
        }

        public void deleteUser(string UserName)
        {
            try
            {
                msh.ExecuteQuery("delete from users where UserName='" + UserName + "'");
                MessageBox.Show("L'utilisateur a été bien supprimé");
            }
            catch (Exception)
            {
                MessageBox.Show("L'utilisateur n'a pas été supprimé");
            }
        }
    }
}
