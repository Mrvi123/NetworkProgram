using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.IO;

namespace UDP_Client_Total_INT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Server details
            string serverIP = "127.0.0.1";
            int serverPort = 8888;

            //Create a UDP client
            UdpClient client = new UdpClient();

            try
            {
                Console.WriteLine("UDP client started");
                Console.WriteLine($"Connecting to server at {serverIP}:{serverPort}");

                //Set up server endpoint
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

                while (true)
                {
                    //Get input from user
                    Console.WriteLine("\n Enter two integers (a and b):");

                    Console.Write("Enter a: ");
                    if(!int.TryParse(Console.ReadLine(), out int a))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer.");
                        continue;
                    }

                    Console.WriteLine("Enter b: ");
                    if(!int.TryParse(Console.ReadLine(), out int b))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer. ");
                        continue;
                    }

                    //Format the message (a,b)
                    string message = $"{a},{b}";

                    //Convert message to bytes and send to server
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    client.Send(data, data.Length, serverEndPoint);
                    Console.WriteLine($"Sent to message {message}");

                    //Receive response from server
                    IPEndPoint responseEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] responseData = client.Receive(ref responseEndPoint);
                    string response = Encoding.ASCII.GetString(responseData);

                    //Display the result
                    Console.WriteLine("------------------------------");
                    Console.WriteLine($"Received from server: {response}");
                    Console.WriteLine($"Sum of {a} and {b} is: {response}");
                    Console.WriteLine("-------------------------------");

                    //Ask if user wants to continue
                    Console.Write("Calculate another sum?(y/n): ");
                    string? answer = Console.ReadLine()?.ToLower();// nhớ thêm dấu hỏi để nói cho chương trình biết rằng
                    //biến này có thể null hoặc không null chỉ chờ tới lúc gọi thì mới biết được, bằng cách nhập vào giá trị
                    if( answer != "y" && answer != "yes")
                    {
                        break;
                    }
                }
            }catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                client.Close();
            }
        }
    }
}
