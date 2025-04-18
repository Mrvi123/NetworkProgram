using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace Server_NguyenKpaHungVi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpListener server = new TcpListener(IPAddress.Any, 80);
            server.Start();
            Console.WriteLine("---->Server dang lang nghe...");
            while (true) {
                TcpClient client = server.AcceptTcpClient();
                //Lay du lieu tu luong
                NetworkStream stream = client.GetStream();

                try
                {
                    while (true)
                    {
                        //tao o nho dem (buffer) de chua du lieu tam
                        byte[] buffer1 = new byte[1024];
                        //tao noi de luu tru gia tri doc duoc tu luồng
                        int bytesRead1 = stream.Read(buffer1, 0,
                        buffer1.Length);
                        string message = Encoding.UTF8.GetString
                        (buffer1, 0, bytesRead1);

                        byte[] buffer2 = new byte[1024];
                        int bytesRead2 = stream.Read 
                            (buffer2, 0, buffer2.Length);
                        string message2 = Encoding.UTF8.GetString
                        (buffer2, 0, bytesRead2);

                        Console.WriteLine($"Nhan duoc {message} tu Client");
                        //Console.WriteLine($"Nhan duoc {message2} Client");
                        string response;
                        if (message2 == "5.0" || message2 == "1.0" || message2 == "2.0" || message2 == "3.0" || message2 == "4.0")
                        {
                            response = message + " dat loai Yeu";
                        }
                        else if (message2 == "5.1" || message2 == "6.4")
                        {

                            response = message +" dat loai Trung Binh";
                        }
                        else if (message2 == "7.9" || message2 == "6.5")
                        {
                            response = message + " dat loai Kha";
                            /*//tạo phản hồi và gửi đến Client
                            response = "Bye bye Client";
                            byte[] byteMessage = Encoding.UTF8.GetBytes
                            (response);
                            stream.Write(byteMessage, 0,
                            byteMessage.Length);
                            break;//dùng để thoát vòng lặp và đóng kết */

                        }
                        else if(message2 == "8.9"|| message2 == "8.0")
                        {
                            response = message + " dat loai Gioi";
                        }
                        else if(message2 == "9.0" || message2 == "9.1" || message2 == "10.0")
                        {
                            response = message + "dat loai Xuat sac";
                        }
                        else
                        {
                            response = "Khong biet";
                        }
                        byte[] data = Encoding.UTF8.GetBytes(response);
                        stream.Write(data, 0, data.Length);
                    }
                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"Loi:{ex.Message}");
                }
                finally
                {
                    stream.Close();
                    client.Close();
                    Console.WriteLine("Da dong ket noi");

                }

            }
        }
    }
}
