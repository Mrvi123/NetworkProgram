using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Multi_Serverchat
{
    public partial class MultiServer : Form
    {
        private Socket serverSocket;
        private Socket clientSocket;
        private byte[] buffer = new byte[1024];

        public MultiServer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            serverSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            serverSocket.Bind(endPoint);
            serverSocket.Listen(10);
            txtStatus.Text = "Waiting for client...";
            serverSocket.BeginAccept(new AsyncCallback(AcceptCallback), null);
        }

        private void AcceptCallback(IAsyncResult ar)
        {
            clientSocket = serverSocket.EndAccept(ar);
            txtStatus.Invoke((MethodInvoker)delegate
            {
                txtStatus.Text = "Client connected: " + clientSocket.RemoteEndPoint.ToString();
            });

            clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                int received = clientSocket.EndReceive(ar);
                if (received == 0) return;

                string message = Encoding.ASCII.GetString(buffer, 0, received);
                lsReceivedDataFromClient.Invoke((MethodInvoker)delegate
                {
                    lsReceivedDataFromClient.Items.Add(new ListViewItem("Client: " + message));
                });

                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
            }
            catch (Exception ex)
            {
                txtStatus.Invoke((MethodInvoker)delegate
                {
                    txtStatus.Text = "Client disconnected: " + ex.Message;
                });
            }
        }


        private void MultiServer_Load(object sender, EventArgs e)
        {

        }

        private void btnSendDataToClient_Click(object sender, EventArgs e)
        {
            string message = txtMessage.Text;
            byte[] data = Encoding.ASCII.GetBytes(message);
            clientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
            lsReceivedDataFromClient.Items.Add(new ListViewItem("Server: " + message));
            txtMessage.Clear();
        }

        private void SendCallback(IAsyncResult ar)
        {
            clientSocket.EndSend(ar);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            {
                clientSocket?.Close();
                serverSocket?.Close();
                txtStatus.Text = "Server stopped.";
            }
        }
    }
}
