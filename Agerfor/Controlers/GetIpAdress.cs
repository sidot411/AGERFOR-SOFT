using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Agerfor.Controlers
{
    class GetIpAdress
    {
        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    string IP = ip.ToString();
                    return IP;
                }
            }
            throw new Exception("No network adapters with an IPv4 address in the system!");
        }
    }
}
