using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Agerfor.Controlers
{
    class Bdd
    {
        MySqlHelper msh = new MySqlHelper();


            public void EditDatabase (string Server, string BDDName, string Port, string User, string Password)
        {
            try
            {
                msh.ExecuteQuery("update bdd set Server='" + Server + "',BDDName='" + BDDName + "',Port='" + Port + "',User='" + User + "',Password='" + Password + "'");
                MessageBox.Show("Les information de la base de donnée en était bien modifier ");
            }
            catch(Exception)
            {
                MessageBox.Show("Les information de la base de donnée non aps était bien modifiée");
            }
        }
    }
}
