using System;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace LTM_ONTAP
{
    internal class Server
    {
        static void Main(string[] args)
        {

            //Bai 1: Doc file ghi va ghi noi dung tu file source sang file destination
            /* //Console.WriteLine("Hello, World!");
             //Duong dan toi file nguon (file can doc)
             string sourceFilePath = @"C:\Users\LENOVO\source\repos\LTM_ONTAP\LTM_ONTAP\source.txt";
         //C: \Users\LENOVO\source\repos\LTM_ONTAP\LTM_ONTAP
             //Duong dan toi file dich (file can ghi)
             string destinationFilePath = @"C:\Users\LENOVO\source\repos\LTM_ONTAP\LTM_ONTAP\destination.txt";
             Exception e = new Exception("Loi xay ra");
             try
             {
                 using (FileStream sourceFile = new FileStream(sourceFilePath, FileMode.Open))//err
                 {
                     using (FileStream destinationFile = new FileStream(destinationFilePath, FileMode.Create))
                     {
                         //Doc noi dung file nguon
                         byte[] content = new byte[sourceFile.Length];
                         sourceFile.Read(content, 0, (int)sourceFile.Length);

                         //Ghi noi dung vao file dich
                         destinationFile.Write(content, 0, content.Length);
                     }
                 }
                 Console.WriteLine("Da ghi file thanh cong");
             }
             catch (FileNotFoundException ex)
             {
                 Console.WriteLine("Loi khong the tim thay file: ",ex.Message);
             }
             catch (IOException ex)
             {
                 Console.WriteLine("Loi doc/ghi file: ",ex.Message);
             }
             catch(Exception ex) { 
                 Console.WriteLine("Loi khac: ",ex.Message);
             }*/


            //Bai 2: Bai toan rut tien cay ATM
            //Khoi tao so du ban dau
            /*decimal accountBalance = 500000;//So du ban dau la 500000 VND

            Console.WriteLine("Chao mung den voi may ATM!");
            Console.WriteLine("So du hien tai cua ban la: " + accountBalance + " VND");

            while (true)
            {
                Console.WriteLine("\nNhap so tien ban muon rut (hoac nhan 0 de thoat): ");
                string input = Console.ReadLine();

                if (decimal.TryParse(input, out decimal withdrawaAmount))
                {
                    if (withdrawaAmount == 0)
                    {
                        Console.WriteLine("Cam on ban da su dung dich vu nay. Bye bye");
                        break;
                    }

                    if (withdrawaAmount < 0)
                    {
                        Console.WriteLine("So tien rut ra phai lon hon 0 nhan anh trai");
                    }
                    else if (withdrawaAmount > accountBalance)
                    {
                        Console.WriteLine("So tien it ma doi rut lon troi, nhap lai di");
                    }
                    else
                    {
                        accountBalance -= withdrawaAmount;
                        Console.WriteLine("Giao dich thanh tai nha quy khach");
                        Console.WriteLine("So du con lai la " + accountBalance + " VND");
                    }
                }
                else
                {
                    Console.WriteLine("Du lieu nhap vao khong hop le. Warnning!");
                }
            }*/

            //======================================================================
            //Bai 3: Lap trinh dong bo voi TCP/UDP
            /*TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Server dang lang nghe..;");

            while (true)
            {
                //client se la nguoi dai dien de chap nhan ket noi tu cac client khac
                //do server dang ban viec voi do con
                TcpClient client = server.AcceptTcpClient();//cho ket noi (dong bo)
                //client se lay du lieu ma ben client con khac gui toi
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Server da nhan: {message} tu thang client");

                string response = "\nServer nhan duoc: " + message;
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                stream.Write(responseData, 0, responseData.Length);//Gui phan hoi (dong bo) cho client

                //client.Close();
            }*/

            //======================================================================
            //Bai 4: Lap trinh dong bo voi TCP/UDP
            /*UdpClient server = new UdpClient(5000);
            IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("UDP Server dang lang nghe...");

            while (true)
            {
                byte[] buffer = server.Receive(ref remoteEP);
                //nhan duoc xong ma hoa thanh chuoi
                string message = Encoding.UTF8.GetString(buffer);
                //in ra thong bao da nhan duoc cai gi
                Console.WriteLine($"Server da nhan duoc {message} tu client");

                //tao bien de gui lai thong bao cho client, bien nay la chuoi nhap vao
                 string? response = "Server chu Vi da nhan duoc "+message+" cua vo roi nha";
                //chuyen doi gia tri thanh bytes de gui cho client
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                //dung phuong thuc Send de gui cho client
                server.Send(responseData, responseData.Length, remoteEP);//Gui phan hoi den client (dong bo)

                //server.Close();*/

            //======================================================================
            //Bai 5:TCP nhan va phan hoi tin nhan

            /*TcpListener server = new TcpListener(IPAddress.Any, 80);
            server.Start();
            Console.WriteLine("Server dang lang nghe...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                //Lay du lieu tu luong
                NetworkStream stream = client.GetStream();

                try
                {
                    while (true) 
                    {
                        //tao o nho dem (buffer) de chua du lieu tam
                        byte[] buffer = new byte[1024];
                        //tao noi de luu tru gia tri doc duoc tu luồng
                        int bytesRead = stream.Read(buffer, 0, buffer.Length);
                        string message = Encoding.UTF8.GetString(buffer,0,bytesRead);
                        //đưa ra thông báo để biết nhận cái gì từ client
                        Console.WriteLine($"Nhan duoc {message} tu be Client");

                        string response;
                        if (message.ToLower() == "hello")
                        {
                            response = "Xin chao";
                        }
                        else if (message.ToLower() == "time")
                        {
                            //Thuộc tính DataTime giúp lấy thời gian kết hợp với Now có nghĩa lấy thời gian hiện tại
                            //Sau đó in chuỗi ra bằng ToString() method
                            response = DateTime.Now.ToString("yyyy:mm:dd");
                        }
                        else if (message.ToLower() == "bye")
                        {
                            //tạo phản hồi và gửi đến Client
                            response = "Bye bye Client";
                            byte[] byteMessage = Encoding.UTF8.GetBytes(response);
                            stream.Write(byteMessage, 0, byteMessage.Length);
                            break;//dùng để thoát vòng lặp và đóng kết nối
                        }
                        else 
                        {
                            response = "I do not understand";
                        }
                        byte[] data = Encoding.UTF8.GetBytes(response);
                        stream.Write(data, 0, data.Length);
                    }
                    

                }
                catch (Exception ex) 
                {
                    Console.WriteLine($"Loi: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine("Client da dong ket noi");
                    //stream.Close();
                    //client.Close();
                }
            }*/

            //======================================================================
            //Bai 6: TCP client gửi tin nhắn đến Server

            /*    TcpListener server = new TcpListener(IPAddress.Any, 5000);
                server.Start();
                Console.WriteLine("Server đang chạy...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient(); // Chờ kết nối từ Client
                    NetworkStream stream = client.GetStream();
                    byte[] buffer = new byte[1024];

                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Client gửi: {message}");

                    string response = "Server nhận: " + message;
                    byte[] responseData = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseData, 0, responseData.Length);

                    client.Close();
                
            
                }*/

            //======================================================================
            //Bai 7: Truyền file từ Client đến Server qua TCP
            /*TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Server đang chờ file...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();

                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string fileName = Encoding.UTF8.GetString(buffer, 0, bytesRead);

                using (FileStream fs = new FileStream("received_" + fileName, FileMode.Create))
                {
                    while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        fs.Write(buffer, 0, bytesRead);
                    }
                }

                Console.WriteLine($"File {fileName} đã nhận xong.");
                client.Close();

            }*/

            //======================================================================
            //Bai 8: Chat hai chiều giữa Client và Server

            /*    TcpListener server = new TcpListener(IPAddress.Any, 5000);
                server.Start();
                Console.WriteLine("Server đang chạy...");

                while (true)
                {
                    TcpClient client = server.AcceptTcpClient();
                    Thread clientThread = new Thread(HandleClient);
                    clientThread.Start(client);
                }
            }

            static void HandleClient(object obj)
            {
                TcpClient client = (TcpClient)obj;
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                while (true)
                {
                    int bytesRead = stream.Read(buffer, 0, buffer.Length);
                    string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Client: {message}");

                    Console.Write("Nhập phản hồi: ");
                    string response = Console.ReadLine();
                    byte[] responseData = Encoding.UTF8.GetBytes(response);
                    stream.Write(responseData, 0, responseData.Length);

                }*/

            //======================================================================
            //Bai 9: Kiểm tra Ping với TCP

            /*TcpListener server = new TcpListener(IPAddress.Any, 5000);
            server.Start();
            Console.WriteLine("Ping Server đang chạy...");

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];

                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                Console.WriteLine($"Nhận: {message}");

                byte[] response = Encoding.UTF8.GetBytes("pong");
                stream.Write(response, 0, response.Length);
                client.Close();
            }*/

            //======================================================================
            //Bai 10:  UDP Server nhận và phản hồi tin nhắn

            /*           UdpClient server = new UdpClient(5000);
                        IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                        Console.WriteLine("UDP Server đang chạy...");

                        while (true)
                        {
                            byte[] buffer = server.Receive(ref clientEndPoint);
                            string message = Encoding.UTF8.GetString(buffer);
                            Console.WriteLine($"Nhận từ {clientEndPoint}: {message}");

                            string response = "Server nhận: " + message;
                            byte[] responseData = Encoding.UTF8.GetBytes(response);
                            server.Send(responseData, responseData.Length, clientEndPoint);
                        }*/


            //======================================================================
            //Bai 11: UDP Client gửi tin nhắn đến Server

            /*           UdpClient server = new UdpClient(5000);
                       IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
                       Console.WriteLine("UDP Server đang chạy...");

                       while (true)
                       {
                           byte[] buffer = server.Receive(ref clientEndPoint);
                           string message = Encoding.UTF8.GetString(buffer);
                           Console.WriteLine($"Nhận từ {clientEndPoint}: {message}");

                           string response = "Server nhận: " + message;
                           byte[] responseData = Encoding.UTF8.GetBytes(response);
                           server.Send(responseData, responseData.Length, clientEndPoint);
                       }*/

            //======================================================================
            //Bài 12: Truyền file từ Client đến Server qua UDP

            /* UdpClient server = new UdpClient(5000);
             IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
             Console.WriteLine("Server đang chờ file...");

             byte[] fileNameData = server.Receive(ref clientEndPoint);
             string fileName = Encoding.UTF8.GetString(fileNameData);
             Console.WriteLine($"Nhận file: {fileName}");

             using (FileStream fs = new FileStream("received_" + fileName, FileMode.Create))
             {
                 while (true)
                 {
                     byte[] buffer = server.Receive(ref clientEndPoint);
                     if (Encoding.UTF8.GetString(buffer) == "END") break;
                     fs.Write(buffer, 0, buffer.Length);
                 }
             }

             Console.WriteLine("File đã nhận xong.");*/

            //======================================================================
            //Bài 13: Chat giữa nhiều máy qua UDP

            /*            const int port = 5000;
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
            UdpClient server = new UdpClient(5000);
            IPEndPoint clientEndPoint = new IPEndPoint(IPAddress.Any, 0);
            Console.WriteLine("Ping Server đang chạy...");

            while (true)
            {
                byte[] buffer = server.Receive(ref clientEndPoint);
                string message = Encoding.UTF8.GetString(buffer);
                Console.WriteLine($"Nhận: {message}");

                byte[] response = Encoding.UTF8.GetBytes("pong");
                server.Send(response, response.Length, clientEndPoint);
            }
        }
    }
}

