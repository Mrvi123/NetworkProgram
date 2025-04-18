using System.Net;
using System.Net.Sockets;
using System.Text;

namespace Client_ConsoleBTH4_C3
{
    internal class Program
    {
        static async Task Main()
        {
            Console.WriteLine("Connecting to server...");

            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            await clientSocket.ConnectAsync(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050));

            Console.WriteLine("Connected to server.");

            byte[] buffer = new byte[1024];
            int receivedBytes = await clientSocket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
            Console.WriteLine("Server: " + Encoding.ASCII.GetString(buffer, 0, receivedBytes));

            _ = Task.Run(() => ReceiveMessages(clientSocket));

            while (true)
            {
                string message = Console.ReadLine();
                if (string.IsNullOrEmpty(message)) continue;
                if (message.ToLower() == "exit")
                {
                    Console.WriteLine("Disconnecting...");
                    clientSocket.Shutdown(SocketShutdown.Both);
                    clientSocket.Close();
                    break;
                }

                byte[] messageBytes = Encoding.ASCII.GetBytes(message);
                await clientSocket.SendAsync(new ArraySegment<byte>(messageBytes), SocketFlags.None);
            }
        }

        private static async Task ReceiveMessages(Socket clientSocket)
        {
            byte[] buffer = new byte[1024];

            try
            {
                while (true)
                {
                    int receivedBytes = await clientSocket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);
                    if (receivedBytes == 0) break;
                    Console.WriteLine("Server: " + Encoding.ASCII.GetString(buffer, 0, receivedBytes));
                }
            }
            catch
            {
                Console.WriteLine("Disconnected from server.");
            }
        }

    }
        //private static List<Socket> clients = new List<Socket>();

        //static void Main(string[] args)
        //{
        //    Console.WriteLine("Hello, World!");
        //}

        //    static async Task Main()
        //    {
        //        Console.WriteLine("Starting server...");

        //        Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        //        IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 9050);

        //        serverSocket.Bind(serverEndPoint);
        //        serverSocket.Listen(10);
        //        Console.WriteLine("Server started. Waiting for connections...");

        //        while (true)
        //        {
        //            Socket clientSocket = await Task.Factory.FromAsync(
        //                serverSocket.BeginAccept, serverSocket.EndAccept, null);

        //            lock (clients)
        //            {
        //                clients.Add(clientSocket);
        //            }

        //            Console.WriteLine("Client connected: " + clientSocket.RemoteEndPoint);
        //            _ = HandleClient(clientSocket);
        //        }
        //    }
        //    private static async Task HandleClient(Socket clientSocket)
        //    {
        //        byte[] buffer = new byte[1024];

        //        try
        //        {
        //            string welcomeMessage = "Welcome to the server!";
        //            await clientSocket.SendAsync(new ArraySegment<byte>(Encoding.ASCII.GetBytes(welcomeMessage)), SocketFlags.None);

        //            while (true)
        //            {
        //                int receivedBytes = await clientSocket.ReceiveAsync(new ArraySegment<byte>(buffer), SocketFlags.None);

        //                if (receivedBytes == 0)
        //                {
        //                    Console.WriteLine("Client disconnected: " + clientSocket.RemoteEndPoint);
        //                    lock (clients)
        //                    {
        //                        clients.Remove(clientSocket);
        //                    }
        //                    clientSocket.Close();
        //                    break;
        //                }

        //                string receivedText = Encoding.ASCII.GetString(buffer, 0, receivedBytes);
        //                Console.WriteLine("Client: " + receivedText);

        //                string responseText = receivedText.ToUpper();
        //                byte[] responseBytes = Encoding.ASCII.GetBytes(responseText);
        //                await clientSocket.SendAsync(new ArraySegment<byte>(responseBytes), SocketFlags.None);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            Console.WriteLine("Error: " + ex.Message);
        //            lock (clients)
        //            {
        //                clients.Remove(clientSocket);
        //            }
        //            clientSocket.Close();
        //        }
        //    }
        //}

    }

