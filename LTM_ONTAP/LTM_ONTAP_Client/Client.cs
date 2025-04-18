using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Reflection.Metadata.Ecma335;
using System.Diagnostics;

namespace LTM_ONTAP_Client
{
    internal class Client
    {
        static void Main(string[] args)
        {
            //Bai 3: Lap trinh dong bo voi TCP
            /* TcpClient client = new TcpClient("127.0.0.1", 5000);
             NetworkStream stream = client.GetStream();

             string message = Console.ReadLine();
             byte[] data = Encoding.UTF8.GetBytes(message);
             stream.Write(data, 0, data.Length);//Gui du lieu den dai ca Server

             byte[] buffer = new byte[1024];
             int bytesRead = stream.Read(buffer, 0, buffer.Length);
             string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
             Console.WriteLine($"Phan hoi tu dai ca Server la {response}");

             //client.Close();*/

            //======================================================================
            //Bai 4: Lap trinh dong bo voi UDP
            /*UdpClient client = new UdpClient();
            IPEndPoint serverEP = new IPEndPoint(IPAddress.Parse("127.0.0.1"),5000);
            
            string? message = Console.ReadLine();
            byte[] data = Encoding.UTF8.GetBytes(message);
            client.Send(data,data.Length,serverEP);//Gui du lieu toi server

            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            byte[] buffer = client.Receive(ref remoteEP);
            string response = Encoding.UTF8.GetString(buffer);
            Console.WriteLine($"Phan hoi tu server la: {response}");

            client.Close();*/

            //======================================================================
            //Bai 5:TCP nhan va phan hoi tin nhan 

            //tạo giao thức làm việc TcpClient
            /*TcpClient client = new TcpClient("127.0.0.1",80);
            NetworkStream stream = client.GetStream();

            string? message = Console.ReadLine();
            byte[] data = Encoding.UTF8.GetBytes(message);
            stream.Write(data, 0, data.Length);

            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string resoponse = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            Console.WriteLine($"Server gui {resoponse} day nay");

            // Lỗi này sẽ xảy ra nếu đặt stream.Close() và client.Close() trước thông báo Console.WriteLine("Da hoanh thanh viec ket noi");
            // : Unable to read data from the transport connection:
            // An established connection was aborted by the software in your host machine..
            //stream.Close();
            //client.Close();
            //cách khắc phục là bỏ stream và client sau Console
            Console.WriteLine("Da hoan thanh viec ket noi");
            //cách khắc phục
            //stream.Close();
            //client.Close();*/

            //======================================================================
            //Bai 6: TCP client gửi tin nhắn đến Server
            /*            while (true)
                        {
                            TcpClient client = new TcpClient("127.0.0.1", 5000);
                            NetworkStream stream = client.GetStream();

                            Console.Write("Nhập tin nhắn: ");
                            string message = Console.ReadLine();
                            if (message.ToLower() == "exit") break;

                            byte[] data = Encoding.UTF8.GetBytes(message);
                            stream.Write(data, 0, data.Length);

                            byte[] buffer = new byte[1024];
                            int bytesRead = stream.Read(buffer, 0, buffer.Length);
                            string response = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                            Console.WriteLine($"Phản hồi từ Server: {response}");

                            client.Close();

                        }*/

            //======================================================================
            //Bai 7: Truyền file từ Client đến Server qua TCP

            /*TcpClient client = new TcpClient("127.0.0.1", 5000);
            NetworkStream stream = client.GetStream();

            Console.Write("Nhập đường dẫn file: ");
            string filePath = Console.ReadLine();
            string fileName = Path.GetFileName(filePath);

            byte[] fileNameData = Encoding.UTF8.GetBytes(fileName);
            stream.Write(fileNameData, 0, fileNameData.Length);

            byte[] buffer = new byte[1024];
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int bytesRead;
                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    stream.Write(buffer, 0, bytesRead);
                }
            }

            Console.WriteLine("File đã gửi xong.");
            client.Close();*/

            //======================================================================
            //Bai 8: Chat hai chiều giữa Client và Server
            /* TcpClient client = new TcpClient("127.0.0.1", 5000);
             NetworkStream stream = client.GetStream();

             Thread readThread = new Thread(() =>
             {
                 while (true)
                 {
                     byte[] buffer = new byte[1024];
                     int bytesRead = stream.Read(buffer, 0, buffer.Length);
                     string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                     Console.WriteLine($"Server: {message}");
                 }
             });
             readThread.Start();

             while (true)
             {
                 Console.Write("Bạn: ");
                 string message = Console.ReadLine();
                 byte[] data = Encoding.UTF8.GetBytes(message);
                 stream.Write(data, 0, data.Length);
             }*/

            //======================================================================
            //Bai 9: Kiểm tra Ping với TCP

            /* TcpClient client = new TcpClient("127.0.0.1", 5000);
             NetworkStream stream = client.GetStream();

             Stopwatch sw = Stopwatch.StartNew();
             byte[] data = Encoding.UTF8.GetBytes("ping");
             stream.Write(data, 0, data.Length);

             byte[] buffer = new byte[1024];
             int bytesRead = stream.Read(buffer, 0, buffer.Length);
             sw.Stop();

             Console.WriteLine($"Phản hồi từ Server: {Encoding.UTF8.GetString(buffer, 0, bytesRead)} - Thời gian: {sw.ElapsedMilliseconds}ms");
             client.Close();*/

            //======================================================================
            //Bai 10:  UDP Server nhận và phản hồi tin nhắn

            /*UdpClient client = new UdpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            while (true)
            {
                Console.Write("Nhập tin nhắn: ");
                string message = Console.ReadLine();
                if (message.ToLower() == "exit") break;

                byte[] data = Encoding.UTF8.GetBytes(message);
                client.Send(data, data.Length, serverEndPoint);

                byte[] buffer = client.Receive(ref serverEndPoint);
                string response = Encoding.UTF8.GetString(buffer);
                Console.WriteLine($"Phản hồi từ Server: {response}");
            }*/

            //======================================================================
            //Bai 11: UDP Client gửi tin nhắn đến Server
            /*           UdpClient client = new UdpClient();
                       IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

                       while (true)
                       {
                           string message = "Ping từ Client";
                           byte[] data = Encoding.UTF8.GetBytes(message);
                           client.Send(data, data.Length, serverEndPoint);

                           Console.WriteLine("Đã gửi: " + message);
                           Thread.Sleep(2000); // Gửi mỗi 2 giây
                       }*/

            //======================================================================
            //Bài 12: Truyền file từ Client đến Server qua UDP
            /*UdpClient client = new UdpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);

            Console.Write("Nhập đường dẫn file: ");
            string filePath = Console.ReadLine();
            string fileName = Path.GetFileName(filePath);

            byte[] fileNameData = Encoding.UTF8.GetBytes(fileName);
            client.Send(fileNameData, fileNameData.Length, serverEndPoint);

            byte[] buffer = new byte[1024];
            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                int bytesRead;
                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    client.Send(buffer, bytesRead, serverEndPoint);
                }
            }

            byte[] endSignal = Encoding.UTF8.GetBytes("END");
            client.Send(endSignal, endSignal.Length, serverEndPoint);
            Console.WriteLine("File đã gửi xong.");*/

            //======================================================================
            //Bài 13: Chat giữa nhiều máy qua UDP


            /*const int port = 5000;
            const string multicastIP = "224.0.0.1";

            UdpClient udpClient = new UdpClient();
            udpClient.JoinMulticastGroup(IPAddress.Parse(multicastIP));

            IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(multicastIP), port);
            Thread receiveThread = new Thread(() =>
            {
                UdpClient receiver = new UdpClient(port);
                receiver.JoinMulticastGroup(IPAddress.Parse(multicastIP));

                while (true)
                {
                    byte[] buffer = receiver.Receive(ref remoteEndPoint);
                    Console.WriteLine($"Nhận: {Encoding.UTF8.GetString(buffer)}");
                }
            });
            receiveThread.Start();

            while (true)
            {
                string message = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(message);
                udpClient.Send(data, data.Length, remoteEndPoint);
            }*/

            //======================================================================
            //Bài 14: Kiểm tra Ping và đo tỉ lệ mất gói tin

            Console.OutputEncoding = Encoding.UTF8;
            UdpClient client = new UdpClient();
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 5000);
            int sent = 0, received = 0;

            for (int i = 0; i < 100; i++)
            {
                byte[] data = Encoding.UTF8.GetBytes("ping");
                client.Send(data, data.Length, serverEndPoint);
                sent++;

                client.Client.ReceiveTimeout = 1000;
                try
                {
                    byte[] buffer = client.Receive(ref serverEndPoint);
                    received++;
                }
                catch { }

                Console.WriteLine($"Gửi: {sent}, Nhận: {received}, Mất: {sent - received}");
            }
        }
    }
}
