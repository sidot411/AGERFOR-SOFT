using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Agerfor.Controlers
{
     public class ipPatchController
    {

        public static string getpath(string pathfolder, string ip)
        {
            if (ip.Length == 9)
            {
                StringBuilder sb = new StringBuilder(pathfolder);
                sb.Remove(13, 1);
                pathfolder = sb.ToString();
            }
            
            return pathfolder;
        }

    }
}
