using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;
//private void InitializeComponent()
//{
//    throw new NotImplementedException();
//}
namespace Multi_Clientchat
{
    public partial class MultiClient : Form
    {

        private Socket clientSocket;
        private byte[] buffer = new byte[1024];

        public MultiClient()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            label1 = new Label();
            btnDisconnectFromClient = new Button();
            btnConnectFromClient = new Button();
            btnSendFromClient = new Button();
            txtMessageFromClient = new TextBox();
            txtStatusFromClient = new TextBox();
            label2 = new Label();
            lsDataSentToServerFromClient = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(16, 17);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "Enter string";
            // 
            // btnDisconnectFromClient
            // 
            btnDisconnectFromClient.Location = new Point(511, 252);
            btnDisconnectFromClient.Name = "btnDisconnectFromClient";
            btnDisconnectFromClient.Size = new Size(75, 23);
            btnDisconnectFromClient.TabIndex = 1;
            btnDisconnectFromClient.Text = "Disconnect";
            btnDisconnectFromClient.UseVisualStyleBackColor = true;
            btnDisconnectFromClient.Click += btnDisconnectFromClient_Click;
            // 
            // btnConnectFromClient
            // 
            btnConnectFromClient.Location = new Point(511, 209);
            btnConnectFromClient.Name = "btnConnectFromClient";
            btnConnectFromClient.Size = new Size(75, 23);
            btnConnectFromClient.TabIndex = 2;
            btnConnectFromClient.Text = "Connect";
            btnConnectFromClient.UseVisualStyleBackColor = true;
            btnConnectFromClient.Click += btnConnectFromClient_Click;
            // 
            // btnSendFromClient
            // 
            btnSendFromClient.Location = new Point(511, 20);
            btnSendFromClient.Name = "btnSendFromClient";
            btnSendFromClient.Size = new Size(75, 23);
            btnSendFromClient.TabIndex = 3;
            btnSendFromClient.Text = "Send";
            btnSendFromClient.UseVisualStyleBackColor = true;
            btnSendFromClient.Click += btnSendFromClient_Click;
            // 
            // txtMessageFromClient
            // 
            txtMessageFromClient.Location = new Point(108, 17);
            txtMessageFromClient.Name = "txtMessageFromClient";
            txtMessageFromClient.Size = new Size(358, 23);
            txtMessageFromClient.TabIndex = 4;
            // 
            // txtStatusFromClient
            // 
            txtStatusFromClient.Location = new Point(108, 292);
            txtStatusFromClient.Name = "txtStatusFromClient";
            txtStatusFromClient.Size = new Size(325, 23);
            txtStatusFromClient.TabIndex = 5;
            txtStatusFromClient.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(16, 300);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 6;
            label2.Text = "Connect status";
            // 
            // lsDataSentToServerFromClient
            // 
            lsDataSentToServerFromClient.Location = new Point(55, 58);
            lsDataSentToServerFromClient.Name = "lsDataSentToServerFromClient";
            lsDataSentToServerFromClient.Size = new Size(391, 207);
            lsDataSentToServerFromClient.TabIndex = 7;
            lsDataSentToServerFromClient.UseCompatibleStateImageBehavior = false;
            // 
            // MultiClient
            // 
            ClientSize = new Size(615, 355);
            Controls.Add(lsDataSentToServerFromClient);
            Controls.Add(label2);
            Controls.Add(txtStatusFromClient);
            Controls.Add(txtMessageFromClient);
            Controls.Add(btnSendFromClient);
            Controls.Add(btnConnectFromClient);
            Controls.Add(btnDisconnectFromClient);
            Controls.Add(label1);
            Name = "MultiClient";
            Text = "Client";
            Load += MultiClient_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private Label label1;
        private Button btnDisconnectFromClient;
        private Button btnConnectFromClient;
        private Button btnSendFromClient;
        private TextBox txtMessageFromClient;
        private TextBox txtStatusFromClient;
        private Label label2;

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private ListView lsDataSentToServerFromClient;

        private void MultiClient_Load(object sender, EventArgs e)
        {

        }

        private void btnConnectFromClient_Click(object sender, EventArgs e)
        {
            clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IPEndPoint endPoint = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 9050);
            clientSocket.BeginConnect(endPoint, new AsyncCallback(ConnectCallback), null);
        }

        private void ConnectCallback(IAsyncResult ar)
        {
            try
            {
                clientSocket.EndConnect(ar);
                txtStatusFromClient.Invoke((MethodInvoker)delegate
                {
                    txtStatusFromClient.Text = "Connected to server.";
                });

                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
            }
            catch (Exception ex)
            {
                txtStatusFromClient.Invoke((MethodInvoker)delegate
                {
                    txtStatusFromClient.Text = "Connection failed: " + ex.Message;
                });
            }
        }

        private void ReceiveCallback(IAsyncResult ar)
        {
            try
            {
                int received = clientSocket.EndReceive(ar);
                if (received == 0) return;

                string message = Encoding.ASCII.GetString(buffer, 0, received);
                lsDataSentToServerFromClient.Invoke((MethodInvoker)delegate
                {
                    lsDataSentToServerFromClient.Items.Add(new ListViewItem("Server: " + message));
                });

                clientSocket.BeginReceive(buffer, 0, buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveCallback), null);
            }
            catch (Exception ex)
            {
                txtStatusFromClient.Invoke((MethodInvoker)delegate
                {
                    txtStatusFromClient.Text = "Connection lost: " + ex.Message;
                });
            }
        }

        private void btnSendFromClient_Click(object sender, EventArgs e)
        {
            string message = txtMessageFromClient.Text;
            byte[] data = Encoding.ASCII.GetBytes(message);
            clientSocket.BeginSend(data, 0, data.Length, SocketFlags.None, new AsyncCallback(SendCallback), null);
            lsDataSentToServerFromClient.Items.Add(new ListViewItem("Client: " + message));
            lsDataSentToServerFromClient.Clear();
        }

        private void SendCallback(IAsyncResult ar)
        {
            clientSocket.EndSend(ar);
        }

        private void btnDisconnectFromClient_Click(object sender, EventArgs e)
        {
            clientSocket?.Close();
            txtStatusFromClient.Text = "Disconnected from server.";
        }
    }
}
