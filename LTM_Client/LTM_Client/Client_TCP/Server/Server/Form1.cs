using SimpleTCP;
using System;
using System.Windows.Forms;
using System.Text;
using System.Net.Sockets;


namespace Server
{
    public partial class Client : Form
    {
        public SimpleTcpClient tcpClient = new SimpleTcpClient();
        public Client()
        {
            InitializeComponent();
        }

        private void Client_DataReceived(object? sender, SimpleTCP.Message e)//them dau hoi sau object de khac phuc loi CS8622 object?
        {
            //tcpClient = new SimpleTcpClient();
            // object nonNullableSender = sender!;
            txtStatus.Invoke((MethodInvoker)delegate () {
                txtStatus.Text += e.MessageString;
            });

        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tcpClient = new SimpleTcpClient();
            tcpClient.StringEncoder = Encoding.UTF8;//khai bao using System.Text de dung Encoding
            tcpClient.DataReceived += Client_DataReceived;
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            tcpClient.Connect("127.0.0.1",8910);//dung dia chi ip va cong cua may chu thuc te
            btnConnect.Enabled = false;
        }

        private void btnSend_Click(object sender, EventArgs e)
        {
            tcpClient.WriteLineAndGetReply(txtMessage.Text, TimeSpan.FromSeconds(3));   
        }
    }
}
