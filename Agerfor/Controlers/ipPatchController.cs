using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

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

            else if (ip.Length==11)
            {
                StringBuilder sb = new StringBuilder(pathfolder);
                sb.Remove(15, 1);
                pathfolder = sb.ToString();
            }

            else  if(ip.Length==12)
            {
                StringBuilder sb = new StringBuilder(pathfolder);
                sb.Remove(16, 1);
                pathfolder = sb.ToString();
            }
            else if (ip.Length == 13)
            {
                StringBuilder sb = new StringBuilder(pathfolder);
                sb.Remove(17, 1);
                pathfolder = sb.ToString();
            }
            else if (ip.Length == 14)
            {
                StringBuilder sb = new StringBuilder(pathfolder);
                sb.Remove(18, 1);
                pathfolder = sb.ToString();
            }
            else if (ip.Length == 15)
            {
                StringBuilder sb = new StringBuilder(pathfolder);
                sb.Remove(19, 1);
                pathfolder = sb.ToString();
            }

            return pathfolder;
        }

    }
}
