using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agerfor.Controlers
{
    class LogController
    {
        MySqlHelper msh = new MySqlHelper();
        public void AddLog(string UserName, string Division, string UserRole, string Date, string Time)
        {
            msh.ExecuteQuery("INSERT INTO `log` (`UserName`, `Division`, `UserRole`, `Date`, `Time`, `Mac`, `Action`) VALUES ('"+UserName+"', '', '', '', '', '', '')")
        }
    }
}
