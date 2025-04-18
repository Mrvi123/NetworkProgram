using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;

class ThreadedTcpSrvr
{
    private TcpListener client;
    private List<TcpClient> clients = new List<TcpClient>();

    public ThreadedTcpSrvr()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        client = new TcpListener(IPAddress.Any, 9050);
        client.Start();
        Console.WriteLine("Waiting for clients...");
        while (true)
        {
            while (!client.Pending())
            {
                Thread.Sleep(1000);
            }
            ConnectionThread newconnection = new ConnectionThread();
            newconnection.threadListener = this.client;
            newconnection.Clients = clients;
            Thread newthread = new Thread(new ThreadStart(newconnection.HandleConnection));
            newthread.Start();
        }
    }

    public static void Main()
    {
        ThreadedTcpSrvr server = new ThreadedTcpSrvr();
    }
}

class ConnectionThread
{
    public TcpListener threadListener;
    public List<TcpClient> Clients;
    private static int connections = 0;

    public void HandleConnection()
    {
        int recv;
        byte[] data = new byte[1024];
        TcpClient client = threadListener.AcceptTcpClient();
        NetworkStream ns = client.GetStream();
        connections++;
        Clients.Add(client);
        Console.WriteLine("New client accepted: {0} active connections", connections);

        string welcome = "Welcome to my test server";
        data = Encoding.ASCII.GetBytes(welcome);
        ns.Write(data, 0, data.Length);

        while (true)
        {
            data = new byte[1024];
            try
            {
                recv = ns.Read(data, 0, data.Length);
                if (recv == 0)
                    break;

                string message = Encoding.ASCII.GetString(data, 0, recv);
                Console.WriteLine("Received: " + message);
                BroadcastMessage(message, client);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                break;
            }
        }

        ns.Close();
        client.Close();
        Clients.Remove(client);
        connections--;
        Console.WriteLine("Client disconnected: {0} active connections", connections);
    }

    private void BroadcastMessage(string message, TcpClient senderClient)
    {
        byte[] data = Encoding.ASCII.GetBytes(message);
        foreach (var client in Clients)
        {
            if (client != senderClient)
            {
                NetworkStream ns = client.GetStream();
                ns.Write(data, 0, data.Length);
            }
        }
    }
}