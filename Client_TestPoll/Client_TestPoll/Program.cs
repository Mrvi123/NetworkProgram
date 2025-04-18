using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.IO;

class ChatClient
{
    private static Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

    static void Main(string[] args)
    {
        Console.WriteLine("Enter server IP: ");
        string? ip = Console.ReadLine();
        Console.WriteLine("Enter your name: ");
        string? name = Console.ReadLine();

        clientSocket.Connect(ip, 8888);//tự nhập ip
        clientSocket.Blocking = false;

        Thread receiveThread = new Thread(ReceiveMessages);
        receiveThread.Start();

        while (true)
        {
            string? message = Console.ReadLine();
            clientSocket.Send(Encoding.ASCII.GetBytes(name + ": " + message));
        }
    }

    private static void ReceiveMessages()
    {
        while (true)
        {
            if (clientSocket.Poll(0, SelectMode.SelectRead))
            {
                byte[] buffer = new byte[1024];
                int bytesRead = clientSocket.Receive(buffer);

                if (bytesRead == 0)
                {
                    Console.WriteLine("Disconnected from server.");
                    Environment.Exit(0);
                }

                string? message = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                Console.WriteLine(message);
            }
            Thread.Sleep(100); // Giảm tải CPU
        }
    }
}
//using System;
//using System.Net;
//using System.Net.Sockets;
//using System.Text;

//// tuần sau tuần sau nữa làm kt gk, tuần tới bỏ, tuần sau tuần bỏ làm gk
//class Program
//{
//    static void Main()
//    {
//        Console.OutputEncoding = System.Text.Encoding.UTF8;
//        // Tạo socket
//        Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

//        // Kết nối đến một server (thay IP và port phù hợp)
//        socket.Connect(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 8080));

//        //Nhận thông điệp từ Server
//        byte[] buffer = new byte[1024];
//        int bytesRead = socket.Receive(buffer);
//        Console.WriteLine("SERVER GƯI: " + Encoding.UTF8.GetString(buffer, 0, bytesRead));

//        //Gửi và nhận dữ liệu từ server
//        while (true)
//        {
//            Console.Write("Nhận dữ liệu từ server (gõ quit để thoát): ");
//            string message = Console.ReadLine();
//            buffer = new byte[1024];
//            buffer = Encoding.UTF8.GetBytes(message);
//            socket.Send(buffer);

//            if (message.Equals("quit")) break;

//            bytesRead = socket.Receive(buffer);
//            Console.WriteLine("Server phản hồi: " + Encoding.UTF8.GetString(buffer, 0, bytesRead));
//        }

//        socket.Close();
//        //// Kiểm tra nếu dữ liệu sẵn sàng để đọc
//        //if (socket.Poll(1000000, SelectMode.SelectRead)) // 1 giây (1,000,000 micro giây)
//        //{
//        //    if (socket.Available > 0) // Kiểm tra nếu có dữ liệu trong buffer
//        //    {
//        //        byte[] buffer = new byte[socket.Available];
//        //        int bytesRead = socket.Receive(buffer);

//        //        Console.WriteLine("Đã đọc dữ liệu: " + System.Text.Encoding.UTF8.GetString(buffer, 0, bytesRead));
//        //    }
//        //    else
//        //    {
//        //        Console.WriteLine("Kết nối bị đóng từ phía server.");
//        //    }
//        //}
//        //else
//        //{
//        //    Console.WriteLine("Không có dữ liệu để đọc.");
//        //}

//        // Đóng socket
//        socket.Close();
//    }
//}
