using System;
using System.Net;
using System.Net.Sockets;

namespace WebApplication
{
    public class Utility
    {

        public static string GetLocalIPAddress()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    return ip.ToString();
                }
            }

            throw new Exception("No network adapters with an IPv4 address in the system!");
        }

        static string jsonPath;

        public static string JsonPath
        {
            get { return jsonPath; }
            set { jsonPath = value; }
        }

    }
}