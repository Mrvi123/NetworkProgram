using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Server_ConsoleBTH4_C3

{
    internal class Program
    {
        private static List<Socket> clients = new List<Socket>();

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World!");
        //}

        static async Task Main()
        {
            Console.WriteLine("Starting server...");

            Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 9050);

            serverSocket.Bind(serverEndPoint);
            serverSocket.Listen(10);
            Console.WriteLine("Server started. Waiting for connections...");

            while (true)
            {
                Socket clientSocket = await Task.Factory.FromAsync(
                    serverSocket.BeginAccept, serverSocket.EndAccept, null);

                lock (clients)
                {
                    clients.Add(clientSocket);
                }

                Console.WriteLine("Client connected: " + clientSocket.RemoteEndPoint);
                _ = HandleClient(clientSocket);
            }
        }
        private static async Task HandleClient(Socket clientSocket)
        {
            byte[] buffer = new byte[1024];

            try
            {
                string welcomeMessage = "Welcome to the server!";
                await clientSocket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(welcomeMessage)), SocketFlags.None);

                while (true)
                {
                    int receivedBytes = await clientSocket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);

                    if (receivedBytes == 0)
                    {
                        Console.WriteLine("Client disconnected: " + clientSocket.RemoteEndPoint);
                        lock (clients)
                        {
                            clients.Remove(clientSocket);
                        }
                        clientSocket.Close();
                        break;
                    }

                    string receivedText = Encoding.ASCII.GetString(buffer, 0, receivedBytes);
                    Console.WriteLine("Client: " + receivedText);

                    string responseText = receivedText.ToUpper();
                    byte[] responseBytes = Encoding.ASCII.GetBytes(responseText);
                    await clientSocket.SendAsync(new ArraySegment<byte>(responseBytes), SocketFlags.None);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                lock (clients)
                {
                    clients.Remove(clientSocket);
                }
                clientSocket.Close();
            }
        }
    }
}
