using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Text;
using System.CodeDom.Compiler;
using System.Windows.Forms;//them try catch de thu ket noi

namespace Client
{
    public partial class Client : Form
    {
        private Socket client;
        private byte[] data = new byte[1024];
        private int size = 1024;
            
        public Client()
        {
            InitializeComponent();
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            txtStatus.Text = "Connecting...";
            Socket newsock = new Socket(AddressFamily.InterNetwork,
                SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint iep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            newsock.BeginConnect(iep, new AsyncCallback(Connected), newsock);
            //new AsyncCallback(Connected)
            //Connected là phương thức sẽ khởi tạo và truyền method Connected này vào AsyncCallbac()
        }

        void Connected(IAsyncResult iar)
        {
            client = (Socket)iar.AsyncState;
            try
            {
                client.EndConnect(iar);
                txtStatus.Text = "Connected to: " + client.RemoteEndPoint.ToString();//RemoteEndPoint() là gì ?
                client.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), client);
            }
            catch (SocketException)
            {
                txtStatus.Text = "Error connecting";
                Console.WriteLine(txtStatus.Text);
            }
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            string messageText = txtMessage.Text;
            byte[] message = Encoding.ASCII.GetBytes(txtMessage.Text);
            //Encoding.ASCII.GetBytes(txtMessage.Text); có tác dụng gì ?
            txtMessage.Clear();// Clear method có tác dụng gì ?
            client.BeginSend(message, 0, message.Length, SocketFlags.None,
                new AsyncCallback(SendData), client);

            //Thêm dữ liệu vào ListView của Client
            //ListView item = new ListViewItem("Client: ");
            //listView1.Items.Add("Hello");
        }

        void SendData(IAsyncResult iar)
        {
            Socket remote = (Socket)iar.AsyncState;//AsyncState là gì ? Có tác dụng gì ?
            //int sent = remote.EndSend(iar);//remote.EndSend(iar) là gì ? Có tác dụng gì trong lập trình bất đồng bộ
            //Phương thức BeginReceiveData được dùng như thế nào ?
            //remote.BeginReceive(data, 0, size, SocketFlags.None,
            //    new AsyncCallback(ReceiveData), remote);

            try
            {
                int sent = remote.EndSend(iar);
                if (sent > 0)
                {
                    Console.WriteLine("Message sent successfully");
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtStatus.Text = "Message sent successfully";
                    });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending data: "+ex.Message);
                this.Invoke((MethodInvoker)delegate
                {
                    txtStatus.Text = "Error sending data:"+ex.Message;
                });
            }
            remote.BeginReceive(data, 0, size, SocketFlags.None,
               new AsyncCallback(ReceiveData), remote);
        }


        void ReceiveData(IAsyncResult iar)
        {
            Socket remote = (Socket)(iar.AsyncState);
            //int
            int recv = remote.EndReceive(iar);
            //string stringData = Encoding.ASCII.GetString(data, 0, recv);
            // recv.Items.Add(stringData);
            try
            {
                if(recv > 0)
                {
                    string stringData = Encoding.ASCII.GetString(data, 0, recv);
                    this.Invoke((MethodInvoker)delegate
                    {
                        txtStatus.Text = "Server: " + stringData;
                    });
                    
                    remote.BeginReceive(data, 0, size, SocketFlags.None, new AsyncCallback(ReceiveData), remote);
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error receiving data: " + ex.Message);
            }


        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            client.Close();
            txtStatus.Text = "Disconnected";
        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
