using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace LTM_Client
{
    internal class IPDomains
    {
        //public string domainName;
        internal class IPDomain
        {
            public IPDomain(string domainName)
            {
                Console.WriteLine("Domain name: ");
                string domain = Console.ReadLine();
                Console.WriteLine("New domain name: ");

                try
                {
                    //check input
                    if (string.IsNullOrEmpty(domain))
                    {
                        Console.WriteLine("Domain name can not empty");
                        return;//stop program
                    }
                    Console.WriteLine($"Searching IP for domain name: {domain}");
                    Console.WriteLine("-----------------------------");

                    //get information from host
                    IPHostEntry hostInfo = Dns.GetHostEntry(domain);

                    //show primary host name
                    Console.WriteLine($"Primary host name: {hostInfo.HostName}");

                    //Display all found IP addresses
                    Console.WriteLine("\nFound IP addresses:");
                    if (hostInfo.AddressList.Length == 0)
                    {
                        Console.WriteLine("\nNot found IP address");
                    }
                    else
                    {
                        int ipCount = 0;
                        foreach (IPAddress ip in hostInfo.AddressList)
                        {
                            ipCount++;
                            Console.WriteLine($"{ipCount}.{ip}(Version:{(ip.AddressFamily == AddressFamily.InterNetwork ? "IPv4" : "IPv6")})");
                        }
                        Console.WriteLine($"\nTotal number of IP addresses found: {ipCount}");
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine($"Domain name not found '{domain}'. Please re-enter");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }


        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\nEnter the domain name you are looking for (example:google.com)");
                Console.WriteLine("Enter 'exit' to exit");
                Console.Write("=>>");

                string input = Console.ReadLine()?.Trim().ToLower();
                //string LTM_Client.IPDomains input = new IPDomains();
                IPDomains.IPDomain domain = new IPDomains.IPDomain(input);

                if (string.IsNullOrEmpty(input) || input == "exit")
                {
                    Console.WriteLine("End of program");
                    break;
                }
                Console.WriteLine(input);
            }
        }


    }
}
