using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
//using System.Int64;
namespace Capture_Image_Client
{
    public partial class Client_Image : Form
    {
        private UdpClient udpClient;
        private int packetSize = 60000; // Kích thước tối đa 60KB
        private string serverIP;
        private int serverPort;
        //private int timerSend;
        public Client_Image()
        {
            InitializeComponent();
            btnStop.Enabled = true;//false
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                byte[] imageData = CaptureAndCompressScreen();
                SendImageInChunks(imageData);
            }
            catch (Exception ex)
            {
                lblStatus.Text = "Lỗi: " + ex.Message;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            serverIP = txtIPAddresServer.Text;//txtIPAddresServer.Text.Trim()
            serverPort = int.Parse(txtPort.Text.Trim());
            timerSend.Interval = (int)numCap.Value * 1000;
            timerSend.Start();
            lblStatus.Text = "Đang gửi ảnh...";
            btnStart.Enabled = false;
            btnStop.Enabled = true;
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            timerSend.Stop();
            lblStatus.Text = "Đã dừng.";
            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {

        }

        private byte[] CaptureAndCompressScreen()
        {
            Rectangle bounds = Screen.PrimaryScreen.Bounds;
            using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
            {
                using (Graphics g = Graphics.FromImage(bitmap))
                {
                    g.CopyFromScreen(Point.Empty, Point.Empty, bounds.Size);
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    ImageCodecInfo jpegCodec = GetEncoder(ImageFormat.Jpeg);
                    EncoderParameters encoderParams = new EncoderParameters(1);
                    encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 50L);
                    bitmap.Save(ms, jpegCodec, encoderParams);
                    return ms.ToArray();
                }
            }
        }

        private void SendImageInChunks(byte[] data)
        {
            udpClient = new UdpClient();
            int totalChunks = (int)Math.Ceiling((double)data.Length / packetSize);
            string imageID = Guid.NewGuid().ToString();

            for (int i = 0; i < totalChunks; i++)
            {
                int offset = i * packetSize;
                int size = Math.Min(packetSize, data.Length - offset);
                byte[] chunkData = new byte[size];
                Array.Copy(data, offset, chunkData, 0, size);

                // Header gồm: imageID|chunkIndex|totalChunks
                string header = $"{imageID}|{i}|{totalChunks}|";
                byte[] headerBytes = Encoding.UTF8.GetBytes(header);
                byte[] packet = new byte[headerBytes.Length + chunkData.Length];
                Buffer.BlockCopy(headerBytes, 0, packet, 0, headerBytes.Length);
                Buffer.BlockCopy(chunkData, 0, packet, headerBytes.Length, chunkData.Length);

                udpClient.Send(packet, packet.Length, serverIP, serverPort);
            }
        }

        private void NotifyIcon_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private ImageCodecInfo GetEncoder(ImageFormat format)
        {
            return Array.Find(ImageCodecInfo.GetImageDecoders(), c => c.FormatID == format.Guid);
        }
    }

}
