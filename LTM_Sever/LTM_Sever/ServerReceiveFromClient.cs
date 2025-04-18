using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

public class SeverReceiveStringClient
{
    public static void Main(string[] args)
    {
        // Khởi tạo đối tượng TcpListener để lắng nghe kết nối từ Client
        TcpListener server = new TcpListener(IPAddress.Any, 8888);

        // Bắt đầu lắng nghe
        server.Start();

        Console.WriteLine("Server đang lắng nghe...");

        while (true)
        {
            // Chấp nhận kết nối từ Client
            TcpClient client = server.AcceptTcpClient();
            Console.WriteLine("Client đã kết nối.");

            // Lấy stream để đọc và ghi dữ liệu
            NetworkStream stream = client.GetStream();

            // Đọc dữ liệu từ Client
            byte[] buffer = new byte[1024];
            int bytesRead = stream.Read(buffer, 0, buffer.Length);
            string data = Encoding.UTF8.GetString(buffer, 0, bytesRead);

            Console.WriteLine("Nhận từ Client: " + data);

            // Chuyển đổi chuỗi thành chữ in hoa
            string upperCaseData = data.ToUpper();

            // Gửi kết quả về cho Client
            byte[] sendData = Encoding.UTF8.GetBytes(upperCaseData);
            stream.Write(sendData, 0, sendData.Length);

            Console.WriteLine("Gửi cho Client: " + upperCaseData);

            // Đóng kết nối
            client.Close();
            Console.WriteLine("Client đã ngắt kết nối.");
        }
    }
}