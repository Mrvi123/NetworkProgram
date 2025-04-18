using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
namespace LTM_Client
{
    internal class IPV4_Address_Type
    {
        internal class checkIPV4Types
        {
            internal class checkIPV4Type 
            {
                public checkIPV4Type(string ipAddress)
                {
                    try
                    {
                        //Check valid ip address
                        if (!IPAddress.TryParse(ipAddress, out IPAddress ip))
                        {
                            Console.WriteLine($"IP address not valid{ipAddress}");
                            return;
                        }
                        //convert to a byte array for verification
                        byte[] bytes = ip.GetAddressBytes();

                        //handle IPV4 address
                        if (ip.AddressFamily != AddressFamily.InterNetwork)
                        {
                            Console.WriteLine("Not IPv4 addresses");
                        }

                        //Check Loopback address
                        if (bytes[0] == 127)
                        {
                            Console.WriteLine("Loopback address");
                        }

                        //Check Broadcast
                        if (bytes[0] == 255 && bytes[1] == 255 && bytes[2] == 255 && bytes[3] == 255)
                        {
                            Console.WriteLine("Broadcast Address");
                        }

                        //Check Multicast
                        if (bytes[0] >= 224 && bytes[0] <= 239)
                        {
                            Console.WriteLine("Multicast Address");
                        }

                        //Check Unicast
                        else
                        {
                            Console.WriteLine("Unicast Address");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Error{ex.Message}");
                        return;
                    }
                }
            }
            
        internal class PrinIPDetails 
            {
                public string PrintIPDetails(string ipAddress)
                {
                    Console.WriteLine("\n-------------------");
                    Console.WriteLine($"Check ip address:{ipAddress}");
                    Console.WriteLine("----------------------");
                    var checker = new checkIPV4Type(ipAddress);
                    return ipAddress;
                }
            }
            
        }
        static void Main() 
        {
            string ipAddress = "127.0.0.2";
            var input = new IPV4_Address_Type.checkIPV4Types.checkIPV4Type(ipAddress);
            var printer = new IPV4_Address_Type.checkIPV4Types.PrinIPDetails();
            printer.PrintIPDetails(ipAddress);
        }
    }
}
