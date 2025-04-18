namespace Capture_Image_Client
{
    partial class Client_Image
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Client_Image));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtIPAddresServer = new TextBox();
            txtPort = new TextBox();
            btnStart = new Button();
            btnStop = new Button();
            btnMinimize = new Button();
            lblStatus = new Label();
            NotifyIcon = new NotifyIcon(components);
            timerSend = new System.Windows.Forms.Timer(components);
            numCap = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)numCap).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(272, 23);
            label1.Name = "label1";
            label1.Size = new Size(130, 15);
            label1.TabIndex = 0;
            label1.Text = "Desktop Monitor Client";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(57, 54);
            label2.Name = "label2";
            label2.Size = new Size(97, 15);
            label2.TabIndex = 1;
            label2.Text = "Server IP Address";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(57, 94);
            label3.Name = "label3";
            label3.Size = new Size(29, 15);
            label3.TabIndex = 2;
            label3.Text = "Port";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(57, 133);
            label4.Name = "label4";
            label4.Size = new Size(91, 15);
            label4.TabIndex = 3;
            label4.Text = "Capture Interval";
            // 
            // txtIPAddresServer
            // 
            txtIPAddresServer.Location = new Point(172, 51);
            txtIPAddresServer.Name = "txtIPAddresServer";
            txtIPAddresServer.Size = new Size(127, 23);
            txtIPAddresServer.TabIndex = 4;
            // 
            // txtPort
            // 
            txtPort.Location = new Point(172, 91);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(127, 23);
            txtPort.TabIndex = 5;
            // 
            // btnStart
            // 
            btnStart.Location = new Point(112, 192);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 7;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(210, 192);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 8;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // btnMinimize
            // 
            btnMinimize.Location = new Point(327, 192);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(75, 23);
            btnMinimize.TabIndex = 9;
            btnMinimize.Text = "Minimize to Tray";
            btnMinimize.UseVisualStyleBackColor = true;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(57, 236);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 10;
            lblStatus.Text = "Status";
            // 
            // NotifyIcon
            // 
            NotifyIcon.Icon = (Icon)resources.GetObject("NotifyIcon.Icon");
            NotifyIcon.Text = "Last sent";
            NotifyIcon.Visible = true;
            NotifyIcon.MouseDoubleClick += NotifyIcon_MouseDoubleClick;
            // 
            // numCap
            // 
            numCap.Location = new Point(171, 136);
            numCap.Name = "numCap";
            numCap.Size = new Size(120, 23);
            numCap.TabIndex = 12;
            // 
            // Client_Image
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(numCap);
            Controls.Add(lblStatus);
            Controls.Add(btnMinimize);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(txtPort);
            Controls.Add(txtIPAddresServer);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Client_Image";
            Text = "Client";
            ((System.ComponentModel.ISupportInitialize)numCap).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtIPAddresServer;
        private TextBox txtPort;
        private Button btnStart;
        private Button btnStop;
        private Button btnMinimize;
        private Label lblStatus;
        private NotifyIcon NotifyIcon;
        private System.Windows.Forms.Timer timerSend;
        private NumericUpDown numCap;
    }
}
