using System;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class ChatClient
{
    private static TcpClient client = new TcpClient();

    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("Enter server IP: ");
        string ip = Console.ReadLine();
        Console.WriteLine("Enter your name: ");
        string name = Console.ReadLine();

        client.Connect(ip, 9050);

        Thread receiveThread = new Thread(ReceiveMessages);
        receiveThread.Start();

        while (true)
        {
            string message = Console.ReadLine();
            byte[] data = Encoding.ASCII.GetBytes(name + ": " + message);
            NetworkStream ns = client.GetStream();
            ns.Write(data, 0, data.Length);
        }
    }

    private static void ReceiveMessages()
    {
        while (true)
        {
            byte[] data = new byte[1024];
            NetworkStream ns = client.GetStream();
            int bytesRead = ns.Read(data, 0, data.Length);
            string message = Encoding.ASCII.GetString(data, 0, bytesRead);
            Console.WriteLine(message);
        }
    }
}