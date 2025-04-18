using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using LTM_Client;

namespace LTM_Client
{
    internal class IPLocals
    {

        string hostname;
        List<IPAddress> ipAddress;

         internal IPLocals(string hostname)
        {
            this.hostname = hostname;
            this.ipAddress = Dns.GetHostAddresses(hostname).ToList();
            //Console.WriteLine(hostname);
        }

        internal void DisplayInfo()
        {
            Console.WriteLine($"Hostname:{hostname}");
            Console.WriteLine("IP Addresses");
            foreach (IPAddress ipadd in ipAddress)
            {
                Console.WriteLine($"-{ipadd}({ipadd.AddressFamily})");
            }
        }

        static void Main(string[] args)
        {
            string hostname = Dns.GetHostName();
            //string result = hostname;
            LTM_Client.IPLocals local = new IPLocals(hostname);
            local.DisplayInfo();
            //*IPAddress[] hostIPs = Dns.GetHostAddresses(hostname);
        }
    }
}

   /* internal class Program 
    {
        static Main() 
        {
            string hostname = Dns.GetHostName();
            //string result = hostname;
            IPLocal local = new IPLocal(hostname);
            local.DisplayInfo();
            *//*IPAddress[] hostIPs = Dns.GetHostAddresses(hostname);
            foreach(IPAddress ipadd in hostIPs) 
            {
            result = result + "\n" + ipadd.ToString();
                Console.WriteLine(result);
            }*//*
        }
    }
}*/
