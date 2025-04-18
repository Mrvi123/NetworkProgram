using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Calculation_UDP_Client
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            // Server details
            string serverIP = "127.0.0.1";
            int serverPort = 8888;

            //Create a UDP client
            UdpClient client = new UdpClient();

            try//try không có ngoặc kiểu này nha Thuận try này đúng, try() này sai
            {
                Console.WriteLine("UDP Caculation Client started: ");
                Console.WriteLine($"Connecting to server at {serverIP}:{serverPort}");

                //Set up server endpoint
                IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse(serverIP), serverPort);

                while (true) 
                {
                    //Get input from user
                    Console.WriteLine("\nEnter calculation details: ");

                    Console.WriteLine("Enter first number: ");
                    if(!int.TryParse(Console.ReadLine(), out int num1))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer");
                        continue;
                    }

                    Console.WriteLine("Enter operator (+, -, *, /): ");
                    string? opInput = Console.ReadLine();
                    if(string.IsNullOrEmpty(opInput) || !IsValidOperator(opInput[0]))//Hàm IsValidOperator chưa được khởi tạo
                    {
                        Console.WriteLine("Invalid operator. Please use +, -, * or /");
                        continue;
                    }

                    char op = opInput[0];

                    Console.Write("Enter second number: ");
                    if(!int.TryParse(Console.ReadLine(), out int num2))
                    {
                        Console.WriteLine("Invalid input. Please enter an integer");
                        continue;
                    }

                    //Format the message (num1, op, num2)
                    string message = $"{num1},{op},{num2}";

                    //Convert message to bytes and send to server
                    byte[] data = Encoding.ASCII.GetBytes(message);
                    client.Send(data, data.Length, serverEndPoint);
                    Console.WriteLine($"Sent to server: {message}");

                    //Receive response from server
                    IPEndPoint responseEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] responseData = client.Receive(ref responseEndPoint);
                    string response = Encoding.ASCII.GetString(responseData);

                    //Display the result
                    Console.WriteLine("--------------------------");
                    Console.WriteLine($"Received from server: {response}");
                    Console.WriteLine($"Result of{num1} {op} {num2} = {response}");
                    Console.WriteLine("--------------------------");

                    //Ask if user wants to continue
                    Console.Write("Perform another calculation ? (y/n): ");
                    string? answer = Console.ReadLine()?.ToLower();
                    if(answer !="yes" && answer !="y")
                    {
                        break;
                    }
                }
            }
            catch (Exception ex) //biến ex phải trùng với biến ex.Message vì đây là biến cần quan tâm
            { 
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                client.Close();
            }

            static bool IsValidOperator(char op)
            {
                return op == '+' || op == '-' || op == '*' || op == '/' ;
            }
        }
    }
}
