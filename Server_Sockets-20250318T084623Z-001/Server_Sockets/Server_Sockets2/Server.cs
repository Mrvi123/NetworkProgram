using System;
using System.Threading.Tasks;
using System.Net;
using System.Windows.Forms;
using System.Net.Sockets;

namespace Server_Sockets2
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

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }


    }
}
