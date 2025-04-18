using System.Windows.Forms;
namespace Server_Sockets2
{
    partial class Server
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            rtbReceivedServer = new RichTextBox();
            label2 = new Label();
            btnStartServer = new Button();
            btnStopServer = new Button();
            txtStatusServer = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(52, 20);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 0;
            label1.Text = "Text received from client:";
            // 
            // rtbReceivedServer
            //

            rtbReceivedServer.Location = new Point(59, 50);
            rtbReceivedServer.Name = "rtbReceivedServer";
            rtbReceivedServer.Size = new Size(404, 251);
            rtbReceivedServer.TabIndex = 1;
            rtbReceivedServer.Text = "";
//            rtbReceivedServer.TextChanged += this.rtbReceivedServer_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(61, 324);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 2;
            label2.Text = "Connect status:";
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new Point(75, 368);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(75, 23);
            btnStartServer.TabIndex = 3;
            btnStartServer.Text = "Start";
            btnStartServer.UseVisualStyleBackColor = true;
            //btnStartServer.Click += this.btnStartServer;
            // 
            // btnStopServer
            // 
            btnStopServer.Location = new Point(323, 368);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new Size(75, 23);
            btnStopServer.TabIndex = 4;
            btnStopServer.Text = "Stop";
            btnStopServer.UseVisualStyleBackColor = true;
           // btnStopServer.Click += this.btnStopServer;
            // 
            // txtStatusServer
            // 
            txtStatusServer.Location = new Point(162, 325);
            txtStatusServer.Name = "txtStatusServer";
            txtStatusServer.Size = new Size(301, 23);
            txtStatusServer.TabIndex = 5;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtStatusServer);
            Controls.Add(btnStopServer);
            Controls.Add(btnStartServer);
            Controls.Add(label2);
            Controls.Add(rtbReceivedServer);
            Controls.Add(label1);
            Name = "Server";
            Text = "Server";
            Load += Form1_Load;
            ResumeLayout(true);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private RichTextBox rtbReceivedServer;
        private Label label2;
        private Button btnStartServer;
        private Button btnStopServer;
        private TextBox txtStatusServer;
    }
}
