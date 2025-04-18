using System;
using System.Net;
using System.Threading;
using System.Net.Sockets;
using System.Text;
using System.IO;//them try catch
namespace Server
{
    public partial class Server : Form
    {
        private byte[] data = new byte[1024];
        private int size = 1024;
        private Socket server;
        public Server()
        {
            InitializeComponent();

        }

        //private void lsReceivedDataFromClient_()
        //{
        //    ListView item = new ListViewItem("Client: " + messageText);
        //}

        private void Server_Load(object sender, EventArgs e)
        {
            txtStatusServer.Text = "Server is ready.";
        }

        private void button1_Click(object sender, EventArgs e)// button1_Click
        {
            server = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            //Cho phép sử dụng lại địa chỉ IP/port ngay cả khi chưa được giải phóng hoàn toàn
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            server.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
            server.Bind(iep);
            server.Listen(10);
            server.BeginAccept(new AsyncCallback(AcceptConn), server);
            txtStatusServer.Text = "Waiting from client...";
        }

        void AcceptConn(IAsyncResult iar)
        {
            Socket oldServer = (Socket)iar.AsyncState;
            Socket client = oldServer.EndAccept(iar);
            //textBox1.Text = "Connected to: " + client.RemoteEndPoint.ToString();
            //Cập nhật thông tin client đã kết nối
            this.Invoke((MethodInvoker)delegate
            {
                txtStatusServer.Text = "Connected to: " + client.RemoteEndPoint.ToString();
            });
            string stringData = "Welcome to my server";
            byte[] message1 = Encoding.ASCII.GetBytes(stringData);
            
            client.BeginSend(message1, 0, message1.Length, SocketFlags.None, new AsyncCallback(ReceiveData), client);//tạo hàm SendData

            client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), client);
        }

        void SendData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            int sent = client.EndSend(iar);
            client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), client);
        }

        void ReceiveData(IAsyncResult iar)
        {
            Socket client = (Socket)iar.AsyncState;
            //int recv = client.EndReceive(iar);
            try
            {
                int recv = client.EndReceive(iar);
                if (recv > 0)//recv == 0
                {
                    string stringData = Encoding.ASCII.GetString(data, 0, recv);

                    this.Invoke((MethodInvoker)delegate
                    {
                        lsReceivedDataFromClient.Text = "Received: " + stringData;
                        ListViewItem item = new ListViewItem("Client:" + stringData);
                        lsReceivedDataFromClient.Items.Add(item);

                    });

                    client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), client);
                    //client.Close();
                    //txtStatusServer.Text = "Waiting for client ...";
                    //server.BeginAccept(new AsyncCallback(AcceptConn), server);
                    //return;
                }
            }
            catch (Exception ex) 
            { 
                Console.WriteLine("Error: can not connect" + ex.Message);
            }
            //if (recv == 0)
            //{
            //    //client.Close();
            //    txtStatusServer.Text = "Waiting for client ...";
            //    server.BeginAccept(new AsyncCallback(AcceptConn), server);
            //    return;
            //}

            string receivedData = Encoding.ASCII.GetString(data, 0, size);//ASCII không phải ACSII
            //result.Items.Add(receivedData)
            receivedData = receivedData.ToUpper();
            byte[] message2 = Encoding.ASCII.GetBytes(receivedData);
            client.BeginSend(message2, 0, message2.Length, SocketFlags.None, new AsyncCallback(SendData), client);

        }

        //Stop connected from client
        private void button2_Click(object sender, EventArgs e)
        {

            if (server != null)
            {
                server.Shutdown(SocketShutdown.Both);
                server.Close();
                server.Dispose();
            }
            //Close();
        }

        //private void btnStopServer_Click()
        //{

        //    if (server != null)
        //    {
        //        server.Shutdown(SocketShutdown.Both);
        //        server.Close();
        //        server.Dispose();
        //    }
        //    Close();
        //}

        private void lsReceivedDataFromClient_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

    }
}
