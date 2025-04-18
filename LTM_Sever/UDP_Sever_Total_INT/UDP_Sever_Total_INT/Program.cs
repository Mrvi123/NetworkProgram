using System;
using System.Net.Sockets;
using System.IO;
using System.Threading.Tasks;
using System.Net;
using System.Text;

namespace UDP_Sever_Total_INT
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

            Console.WriteLine("Server started. Waiting for client messages...");
            Console.WriteLine($"Listening on port{port}");

            try
            {
                while (true)
                {
                    //Receive data from any client
                    IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                    byte[] receivedData = server.Receive(ref clientEndPoint);

                    //Convert received data to string
                    string message = Encoding.ASCII.GetString(receivedData);//muốn dùng được Encoding thì phải khai báo using System.Text
                    Console.WriteLine($"Received from {clientEndPoint}: {message}");

                    //Parse the two numbers from the message
                    string[] numbers = message.Split(',');
                    if(numbers.Length == 2 &&
                        int.TryParse(numbers[0], out int a) &&
                        int.TryParse(numbers[1], out int b))
                    {
                        // Calculate the sum
                        int sum = a + b;
                        Console.WriteLine($"Caculated sum: {a} + {b} = {sum}");

                        //Send the sum back to the client
                        byte[] responseData = Encoding.ASCII.GetBytes(sum.ToString());
                        server.Send(responseData, responseData.Length, clientEndPoint);
                        Console.WriteLine($"Sent result to client: {sum}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid data format received");
                        //Send error message back to client
                        byte[] errorData = Encoding.ASCII.GetBytes("Error: Invalid format. Please send two numbers separated by a comma.");
                        server.Send(errorData, errorData.Length, clientEndPoint);
                    }
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            finally{
                server.Close();
            }
        }
    }
}
