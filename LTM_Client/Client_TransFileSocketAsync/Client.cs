using System;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace Client_TransFileSocketAsync
{
    public partial class Client : Form
    {
        private TcpClient client;
        private NetworkStream stream;
        private string savePath;

        public Client()
        {
            InitializeComponent();
        }

        private void Client_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnBrowseClient_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog())
            {
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    string savePath = folderBrowserDialog.SelectedPath;
                    txtBrowseClient.Text = savePath;
                    MessageBox.Show($"Bạn đã chọn:{savePath}");

                    if (string.IsNullOrEmpty(savePath))
                    {
                        MessageBox.Show($"Không có đường dẫn{savePath}");
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)//btn ReceivedClient
        {
            string savePath = "";//phải khởi tạo giá trị nếu không sẽ lỗi
            if (string.IsNullOrEmpty(savePath))
            {
                MessageBox.Show("Please select a save location first.");
                return;
            }

            try
            {
                TcpClient client = new TcpClient("127.0.0.1", 9050);
                NetworkStream stream = client.GetStream();
                txtReceivedClient.Text = "Connected to server.";

                // Nhận độ dài tên file
                byte[] fileNameLengthBytes = new byte[sizeof(int)];
                stream.Read(fileNameLengthBytes, 0, fileNameLengthBytes.Length);
                int fileNameLength = BitConverter.ToInt32(fileNameLengthBytes, 0);

                // Nhận tên file
                byte[] fileNameBytes = new byte[fileNameLength];
                stream.Read(fileNameBytes, 0, fileNameBytes.Length);
                string fileName = Encoding.ASCII.GetString(fileNameBytes);

                // Nhận độ dài dữ liệu file
                byte[] fileDataLengthBytes = new byte[sizeof(int)];
                stream.Read(fileDataLengthBytes, 0, fileDataLengthBytes.Length);
                int fileDataLength = BitConverter.ToInt32(fileDataLengthBytes, 0);

                // Nhận dữ liệu file
                byte[] fileDataBytes = new byte[fileDataLength];
                stream.Read(fileDataBytes, 0, fileDataBytes.Length);

                // Lưu file vào thư mục đã chọn
                string fullPath = Path.Combine(savePath, fileName);
                File.WriteAllBytes(fullPath, fileDataBytes);

                txtReceivedClient.Text = "File received.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                Console.WriteLine("Lam lai di");
                // Đóng kết nối
                stream.Close();
                client.Close();
            }
        }
    }

}

