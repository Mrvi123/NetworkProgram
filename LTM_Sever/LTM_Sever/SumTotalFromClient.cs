using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class ServerTotalFromClient
{
    public static void Main(string[] args)
    {
        TcpListener server = new TcpListener(IPAddress.Any, 8888);
        server.Start();

        Console.WriteLine("Server đang lắng nghe...");

        while (true)
        {
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client đã kết nối.");

            NetworkStream stream = client.GetStream();

            // Nhận hai số nguyên a và b từ Client
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);
            string[] numbers = data.Split(',');
            int a = int.Parse(numbers[0]);
            int b = int.Parse(numbers[1]);

            Console.WriteLine("Nhận từ Client: a = " + a + ", b = " + b);

            // Tính tổng a + b
            int sum = a + b;

            // Gửi tổng về cho Client
            string result = sum.ToString();
            byte[] sendData = Encoding.UTF8.GetBytes(result);
            stream.Write(sendData, 0, sendData.Length);

            Console.WriteLine("Gửi cho Client: " + sum);

            client.Close();
            Console.WriteLine("Client đã ngắt kết nối.");
        }
    }
}