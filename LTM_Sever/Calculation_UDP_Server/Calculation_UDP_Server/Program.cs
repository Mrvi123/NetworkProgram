using System.Net;
using System.Net.Sockets;
using System.IO;
using System;
using System.Threading.Tasks;
using System.Text;

namespace Calculation_UDP_Server
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            //Define the server port
            int port = 8888;

            //Create a UDP client
            UdpClient server = new UdpClient(port);

            Console.WriteLine("Calculation Server started. Waiting for client message...");
            Console.WriteLine($"Listen on port {port}");

            try
            {
                while (true)
                {
                    //Received data from any client
                    IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedData = server.Receive(ref clientEndPoint);

                    //Convert received data to string
                    string message = Encoding.ASCII.GetString(receivedData);
                    Console.WriteLine($"Received from {clientEndPoint}: {message}");

                    //Parse the message format: num1, operator, num2
                    string[] parts = message.Split(',');
                    if(parts.Length == 3 &&
                        int.TryParse(parts[0], out int num1) &&
                        int.TryParse(parts[2], out int num2))
                    {
                        // Get the operator
                        char operation = parts[1][0];

                        //Perform the calculation
                        double result = 0;
                        bool validOperation = true;

                        //Check
                        switch(operation){
                            case '+':
                                result = num1 + num2;
                                break;
                            case '-':
                                result = num1 - num2;
                                break;
                            case '*':
                                result = num1 * num2;
                                break;
                            case '/':
                                if (num2 != 0) {
                                    result = (double)num1 / num2;
                                }
                                else
                                {
                                    validOperation = false;
                                    Console.WriteLine("Error: Division by zero");
                                }
                                break;
                            default:
                                validOperation = false;
                                Console.WriteLine($"Error: Invalid operator '{operation}'");
                                result = num1 / num2;
                                break;
                        }

                        if (validOperation)
                        {
                            Console.WriteLine($"Calculated:{num1} {operation} {num2} = {result}");

                            //Send the result back to the client
                            byte[] responseData = Encoding.ASCII.GetBytes(result.ToString());
                            server.Send(responseData, responseData.Length, clientEndPoint);
                            Console.WriteLine($"Sent result to client: {result}");

                        }
                        else
                        {
                            //Send error message back to client
                            byte[] errorData = Encoding.ASCII.GetBytes("Error: Invalid format. Please send in format: num1, operator, num2");
                            server.Send(errorData, errorData.Length, clientEndPoint);

                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally
            {
                server.Close();
            }
        }
    }
}
