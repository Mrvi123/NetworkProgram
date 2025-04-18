using System;
using System.Collections.Concurrent;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace Capture_Image_Server
{
    public partial class Server_Image : Form
    {
        public UdpClient udpListener;
        private Thread listenThread;
        private bool isListening = false;

        // Tạm lưu dữ liệu từ từng ảnh
        private ConcurrentDictionary<string, ChunkedImage> receivedImages = new();

        public Server_Image()
        {
            InitializeComponent();
            btnStop.Enabled = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnStartListen_Click(object sender, EventArgs e)
        {
            //IPAddress udpListener = IPAddress.Any;
            int port = 8080;
            udpListener = new UdpClient(new IPEndPoint(IPAddress.Any,port));
            isListening = true;

            listenThread = new Thread(ListenForData);
            listenThread.IsBackground = true;
            listenThread.Start();

            lblStatus.Text = "Đang lắng nghe...";
            btnStartListen.Enabled = true;//false
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            isListening = true;//false
            udpListener?.Close();
            lblStatus.Text = "Đã dừng.";
            btnStartListen.Enabled = true;
            btnStop.Enabled = true;//false
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (FolderBrowserDialog dialog = new FolderBrowserDialog())
            {
                dialog.Description = "Chọn thư mục để lưu ảnh từ client";
                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    //string clientFolder = Path.Combine(txtSaveFile.Text, IPAddress.Any);
                    txtSaveFile.Text = dialog.SelectedPath;
                }
            }
        }

        private void ListenForData()
        {
            try
            {
                while (isListening)
                {
                    IPEndPoint remoteEP = new IPEndPoint(IPAddress.Any, 0);
                    byte[] received = udpListener.Receive(ref remoteEP);

                    ThreadPool.QueueUserWorkItem(_ => HandleReceivedPacket(received, remoteEP.Address.ToString()));
                }
            }
            catch (Exception ex)
            {
                AddLog("Lỗi: " + ex.Message);
            }
        }

        private void HandleReceivedPacket(byte[] packet, string senderIP)
        {
            try
            {
                string header = Encoding.UTF8.GetString(packet, 0, 100);
                string[] parts = header.Split('|');
                if (parts.Length < 4) return;

                string imageID = parts[0];
                int chunkIndex = int.Parse(parts[1]);
                int totalChunks = int.Parse(parts[2]);

                int headerLength = Encoding.UTF8.GetByteCount($"{imageID}|{chunkIndex}|{totalChunks}|");
                byte[] chunkData = new byte[packet.Length - headerLength];
                Buffer.BlockCopy(packet, headerLength, chunkData, 0, chunkData.Length);

                if (!receivedImages.ContainsKey(imageID))
                    receivedImages[imageID] = new ChunkedImage(totalChunks, senderIP);

                receivedImages[imageID].AddChunk(chunkIndex, chunkData);

                // Nếu đã đủ chunk
                if (receivedImages[imageID].IsComplete)
                {
                    byte[] fullImageData = receivedImages[imageID].CombineChunks();
                    SaveImage(senderIP, fullImageData);
                    receivedImages.TryRemove(imageID, out _);
                }
            }
            catch (Exception ex)
            {
                AddLog("Xử lý lỗi: " + ex.Message);
            }
        }

        private void SaveImage(string clientIP, byte[] imageData)
        {
            try
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                using (Image image = Image.FromStream(ms))
                {
                    string clientFolder = Path.Combine("txtSaveFile.Text", clientIP);
                    Directory.CreateDirectory(clientFolder);
                    string filename = Path.Combine(clientFolder, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".jpg");
                    image.Save(filename, ImageFormat.Jpeg);
                    AddLog($"Đã lưu ảnh từ {clientIP}: {Path.GetFileName(filename)}");
                }
            }
            catch (Exception ex)
            {
                AddLog("Lỗi lưu ảnh: " + ex.Message);
            }
        }

        private void AddLog(string message)
        {
            if (lsLog.InvokeRequired)
            {
                lsLog.Invoke(new Action<string>(AddLog), message);
            }
            else
            {
                lsLog.Items.Insert(0, $"[{DateTime.Now:HH:mm:ss}] {message}");
            }
        }
        
    }

    public class ChunkedImage
    {
        private readonly int totalChunks;
        private readonly byte[][] chunks;
        public bool IsComplete => receivedCount == totalChunks;
        private int receivedCount = 0;
        public string ClientIP { get; }

        public ChunkedImage(int totalChunks, string ip)
        {
            this.totalChunks = totalChunks;
            this.ClientIP = ip;
            chunks = new byte[totalChunks][];
        }

        public void AddChunk(int index, byte[] data)
        {
            if (index < totalChunks && chunks[index] == null)
            {
                chunks[index] = data;
                Interlocked.Increment(ref receivedCount);
            }
        }

        public byte[] CombineChunks()
        {
            using (MemoryStream ms = new MemoryStream())
            {
                foreach (var chunk in chunks)
                {
                    if (chunk != null)
                        ms.Write(chunk, 0, chunk.Length);
                }
                return ms.ToArray();
            }
        }
    }
}
