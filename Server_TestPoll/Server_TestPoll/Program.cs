using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class ChatServer
{
    private static List<Socket> clientSockets = new List<Socket>();
    private static Socket serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    static void Main(string[] args)
    {
        Console.WriteLine("Starting server...");
        serverSocket.Bind(new IPEndPoint(IPAddress.Any, 8888));
        serverSocket.Listen(5);
        serverSocket.Blocking = false;

        while (true)
        {
            CheckForNewConnections();
            CheckForClientMessages();
            Thread.Sleep(100); // Giảm tải CPU
        }
    }

    private static void CheckForNewConnections()
    {
        if (serverSocket.Poll(0, SelectMode.SelectRead))
        {
            Socket clientSocket = serverSocket.Accept();
            clientSockets.Add(clientSocket);
            Console.WriteLine("Client connected: " + clientSocket.RemoteEndPoint);
        }
    }

    private static void CheckForClientMessages()
    {
        foreach (var clientSocket in clientSockets.ToArray())
        {
            if (clientSocket.Poll(0, SelectMode.SelectRead))
            {
                byte[] buffer = new byte[1024];
                int bytesRead = clientSocket.Receive(buffer);

                if (bytesRead == 0)
                {
                    Console.WriteLine("Client disconnected: " + clientSocket.RemoteEndPoint);
                    clientSockets.Remove(clientSocket);
                    clientSocket.Close();
                }
                else
                {
                    string message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine("Received: " + message);
                    BroadcastMessage(message, clientSocket);
                }
            }
        }
    }

    private static void BroadcastMessage(string message, Socket senderSocket)
    {
        foreach (var clientSocket in clientSockets)
        {
            if (clientSocket != senderSocket)
            {
                clientSocket.Send(Encoding.ASCII.GetBytes(message));
            }
        }
    }
}
//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;

//class TcpServer
//{
//    static void Main(string[] args)
//    {
//        int recv;
//        byte[] data = new byte[1024];
//        IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 8080);
//        Socket newsock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
//        newsock.Bind(ipep);
//        newsock.Listen(10);
//        Console.WriteLine("Waiting for a client...");
//        bool result = true;
//        IPEndPoint newclient = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080);
//        int i = 0;
//        while (true)
//        {
//            i++;
//            Console.WriteLine("polling for accept#{0}...", i);
//            result = newsock.Poll(1000000, SelectMode.SelectRead);
//            if (result)
//            {
//                break;
//            }
//        }
//        Socket client = newsock.Accept();
//        IPEndPoint remoteEndPoint = (IPEndPoint)client.RemoteEndPoint;//CHECK LỖI
//        //(IPEndPoint)client.RemoteEndPoint;
//        Console.WriteLine("Connected with {0} at port {1}", remoteEndPoint.Address, remoteEndPoint.Port);

//        string welcome = "Welcome to my test server";
//        data = Encoding.ASCII.GetBytes(welcome);
//        client.Send(data, data.Length, SocketFlags.None);
//        i = 0;
//        while (true)
//        {
//            Console.WriteLine("polling for receive #{0}...", i);
//            i++;
//            result = client.Poll(3000000, SelectMode.SelectRead);
//            if (result)
//            {
//                data = new byte[1024];
//                i = 0;
//                recv = client.Receive(data);
//                if (Encoding.ASCII.GetString(data, 0, recv).Equals("quit")) break;
//                Console.WriteLine(Encoding.ASCII.GetString(data, 0, recv));
//                client.Send(data, recv, 0);
//            }
//        }
//        Console.WriteLine("Disconnected from {0}",
//        newclient.Address);
//        client.Close();
//        newsock.Close();


//static void Main()
//{
//    Console.OutputEncoding = System.Text.Encoding.UTF8;
//    // Thiết lập thông tin server
//    int port = 8080; // Cổng server lắng nghe
//    IPAddress ipAddress = IPAddress.Any; // Lắng nghe trên mọi địa chỉ IP

//    // Tạo socket TCP
//    TcpListener server = new TcpListener(ipAddress, port);

//    try
//    {
//        // Bắt đầu lắng nghe
//        server.Start();
//        Console.WriteLine("Server đã khởi động và lắng nghe trên cổng " + port);

//        while (true)
//        {
//            Console.WriteLine("Đang chờ kết nối từ client...");

//            // Chấp nhận một kết nối từ client
//            TcpClient client = server.AcceptTcpClient();
//            Console.WriteLine("Client đã kết nối!");

//            // Nhận luồng dữ liệu từ client
//            NetworkStream stream = client.GetStream();

//            // Đọc dữ liệu từ client
//            byte[] buffer = new byte[1024];
//            int bytesRead = stream.Read(buffer, 0, buffer.Length);
//            string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);

//            Console.WriteLine("Dữ liệu nhận được từ client: " + message);

//            // Gửi phản hồi lại cho client
//            string response = "Server đã nhận: " + message;
//            byte[] responseData = Encoding.UTF8.GetBytes(response);
//            stream.Write(responseData, 0, responseData.Length);

//            // Đóng kết nối với client
//            client.Close();
//        }
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine("Có lỗi xảy ra: " + e.Message);
//    }
//    finally
//    {
//        // Ngừng server
//        server.Stop();
//        Console.WriteLine("Server đã dừng.");
//    }
//}



