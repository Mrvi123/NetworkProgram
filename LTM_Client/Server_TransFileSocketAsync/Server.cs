using System;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Threading;
using System.Windows.Forms;
using System.Text;

namespace Server_TransFileSocketAsync
{
    public partial class Server : Form
    {

        private TcpListener server;
        private TcpClient client;
        private NetworkStream stream;
        private string filePath;

        public Server()
        {
            InitializeComponent();
        }

        private void btnBrowseServer_Click(object sender, EventArgs e)
        {//dung OpenFileDialog de tao bien 
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;// mở hộp thoại file chọn rồi chọn tên file
                    txtFileSelectServer.Text = filePath;//hiển thị đường dẫn của tệp tin
                }
            }
        }

        private void btnStartServer_Click(object sender, EventArgs e)
        {
            //Nếu đường dẫn trong biến filePath không tồn tại
            if (string.IsNullOrEmpty(filePath))
            {
                //Hộp thoại thông báo
                MessageBox.Show("Please select a file first");
                return;
            }

            int port = 9050;
            IPEndPoint serverEndPoint = new IPEndPoint(IPAddress.Any, 9050);
            server = new TcpListener(serverEndPoint);//lắng nghe trên cổng 9050 với bất kì địa chỉ IP nào kết nối tới
            server.Start();//Khởi động server
            lblStatusServer.Text = "Waiting for client...";

            while (true)
            {
                TcpClient client = server.AcceptTcpClient();
                Console.WriteLine($"[Server] đang lắng nghe trên cổng {9050}");

                NetworkStream stream = client.GetStream();
                byte[] buffer = new byte[1024];
                int bytesRead = stream.Read(buffer, 0, buffer.Length);
                string receivedMessage = Encoding.UTF8.GetString(buffer);

                Console.WriteLine($"Received {receivedMessage}");

                // Gửi phản hồi lại Client
                string response = "Dữ liệu đã được nhận!";
                byte[] responseData = Encoding.UTF8.GetBytes(response);
                stream.Write(responseData, 0, responseData.Length);

                //client.Close();

            }
            
            server.BeginAcceptTcpClient(new AsyncCallback(AcceptClient),null);
        }

        private void AcceptClient(IAsyncResult ar)
        {
            //server sẽ giao chấp nhận kết nối từ client thông qua luồng
            //Stream bằng giao thức Tcp, và đối tượng đại diện là ar
            client = server.EndAcceptTcpClient(ar);
            stream = client.GetStream();
            lblStatusServer.Invoke((MethodInvoker)delegate 
            {
                lblStatusServer.Text = "Client connected.";
            });

            byte[] fileNameBytes = Encoding.ASCII.GetBytes(Path.GetFileName(filePath));
            byte[] fileNameLength = BitConverter.GetBytes(fileNameBytes.Length);
            byte[] fileData = File.ReadAllBytes(filePath);
            byte[] fileDataLength = BitConverter.GetBytes(fileData.Length);

            stream.Write(fileNameLength, 0, fileNameLength.Length);
            stream.Write(fileNameBytes, 0, fileNameBytes.Length);
            stream.Write(fileDataLength, 0, fileDataLength.Length);
            stream.Write(fileData, 0, fileData.Length);

            lblStatusServer.Invoke((MethodInvoker)delegate{ lblStatusServer.Text = "File sent."; });
            //stream.Close();
            //client.Close();
            //server.Stop();
        }
    }
}
