using System.Windows.Forms;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using SimpleTCP;
using System.Text;

namespace Client_TCP
{
    public partial class Form1 : Form
    {
        public SimpleTcpServer server = new SimpleTcpServer();//nếu biến này không gán giá trị thì
        //vấn đề Dereference of a possibly null reference sẽ xuất hiện
        public Form1()
        {
            InitializeComponent();
        }

        /*SimpleTcpServer server;*/

        private void Form1_Load(object sender, EventArgs e)
        {
            //server = new SimpleTcpServer();
            server.Delimiter = 0x13;//enter
            server.StringEncoder = Encoding.UTF8;
            server.DataReceived += Server_DataReceived;
        }

        private void Server_DataReceived(object? sender, SimpleTCP.Message e)
        {
            //throw new NotImplementedException();
            txtStatus.Invoke((MethodInvoker)delegate ()
            {
                txtStatus.Text += e.MessageString;
                e.ReplyLine(string.Format("You said: {0}", e.MessageString));
            });
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            txtStatus.Text += "Server Starting......";
            System.Net.IPAddress ip = System.Net.IPAddress.Parse(txtHost.Text);//(long.Parse(txtHost.Text))
            server.Start(ip, Convert.ToInt32(txtPort.Text));
           // var listener = new tcplistener(ipaddress.any, 8910);
            //listener.server.setsocketoption(socketoptionlevel.socket, socketoptionname.reuseaddress, true);
            //listener.start();

        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (server.IsStarted)
                server.Stop();
        }
    }
}
