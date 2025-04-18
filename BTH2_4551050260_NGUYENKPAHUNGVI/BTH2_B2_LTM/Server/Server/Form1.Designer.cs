namespace Server
{
    partial class Client
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
            txtPort = new TextBox();
            label2 = new Label();
            txtHost = new TextBox();
            btnConnect = new Button();
            label1 = new Label();
            txtMessage = new TextBox();
            btnSend = new Button();
            txtStatus = new TextBox();
            SuspendLayout();
            // 
            // txtPort
            // 
            txtPort.Location = new Point(303, 24);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(58, 23);
            txtPort.TabIndex = 9;
            txtPort.Text = "8910";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(259, 32);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 8;
            label2.Text = "Port:";
            // 
            // txtHost
            // 
            txtHost.Location = new Point(135, 24);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(100, 23);
            txtHost.TabIndex = 7;
            txtHost.Text = "127.0.0.1";
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(377, 28);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 6;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            btnConnect.Click += btnConnect_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 32);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 5;
            label1.Text = "Host:";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(137, 60);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(315, 74);
            txtMessage.TabIndex = 10;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(377, 140);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 11;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(135, 169);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(315, 127);
            txtStatus.TabIndex = 12;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 319);
            Controls.Add(txtStatus);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(txtPort);
            Controls.Add(label2);
            Controls.Add(txtHost);
            Controls.Add(btnConnect);
            Controls.Add(label1);
            Name = "Client";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Client";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtPort;
        private Label label2;
        private TextBox txtHost;
        private Button btnConnect;
        private Label label1;
        private TextBox txtMessage;
        private Button btnSend;
        private TextBox txtStatus;
    }
}
