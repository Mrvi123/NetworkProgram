using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class ClientTotal
{
    public static void Main(string[] args)
    {
        TcpClient client = new TcpClient("127.0.0.1", 8888); // Địa chỉ IP và cổng của Server

        NetworkStream stream = client.GetStream();

        // Nhập hai số nguyên a và b từ người dùng
        Console.Write("Nhập số nguyên a: ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Nhập số nguyên b: ");
        int b = int.Parse(Console.ReadLine());

        // Gửi a và b lên Server
        string inputString = a.ToString() + "," + b.ToString();
        byte[] sendData = Encoding.UTF8.GetBytes(inputString);
        stream.Write(sendData, 0, sendData.Length);

        // Nhận kết quả từ Server
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string result = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        // In kết quả ra màn hình
        Console.WriteLine("Tổng nhận được: " + result);

        client.Close();
    }
}