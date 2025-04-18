using System.Net.Sockets;
using System.Text;

namespace Client_NguyenKpaHungVi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TcpClient client = new TcpClient("127.0.0.1",80);
            NetworkStream stream = client.GetStream();

            while (true) 
            {
                //string? message = Console.ReadLine();

                //stream.Write(data, 0, data.Length)

                /* byte[] buffer = new byte[1024];
                 //string hoten = Console.ReadLine();
                 //string dtb = Console.ReadLine();
                 string message = Console.ReadLine();
                 int bytesRead = stream.Read(buffer, 0, buffer.Length);
                 //string message = Encoding.UTF8.GetString(buffer, 0, bytesRead);
                 byte[] data = Encoding.UTF8.GetBytes(message);
                 stream.Write(data, 0, data.Length);
                 Console.WriteLine($"Nhan duoc tu Server la: {message}");*/

                string? hoten = Console.ReadLine();
                byte[] data = Encoding.UTF8.GetBytes(hoten);
                string dtb = Console.ReadLine();
                byte[] data2 = Encoding.UTF8.GetBytes(dtb);
                stream.Write(data, 0, data.Length);
                stream.Write(data2 , 0, data2.Length);
                byte[] buffer = new byte[1024];

                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string resoponse = Encoding.UTF8.GetString(buffer, 0,bytesRead);
                Console.WriteLine($"Server gui: {resoponse} ");


                //client.Close();
                //stream.Close();
            }
        }
    }
}
