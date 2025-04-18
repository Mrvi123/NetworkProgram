using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class Client
{
    public static void Main(string[] args)
    {
        // Khởi tạo đối tượng TcpClient để kết nối đến Server
        TcpClient client = new TcpClient("127.0.0.1", 8888); // Địa chỉ IP và cổng của Server

        // Lấy stream để đọc và ghi dữ liệu
        NetworkStream stream = client.GetStream();

        // Nhập chuỗi từ người dùng
        Console.Write("Nhập chuỗi: ");
        string inputString = Console.ReadLine();

        // Gửi chuỗi lên Server
        byte[] sendData = Encoding.UTF8.GetBytes(inputString);
        stream.Write(sendData, 0, sendData.Length);

        // Nhận kết quả từ Server
        byte[] buffer = new byte[1024];
        int bytesRead = stream.Read(buffer, 0, buffer.Length);
        string result = Encoding.UTF8.GetString(buffer, 0, bytesRead);

        // In kết quả ra màn hình
        Console.WriteLine("Kết quả nhận được: " + result);

        // Đóng kết nối
        client.Close();
    }
}