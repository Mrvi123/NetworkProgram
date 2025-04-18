namespace Client_TCP
{
    partial class Form1
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
            btnStart = new Button();
            txtHost = new TextBox();
            txtPort = new TextBox();
            label2 = new Label();
            btnStop = new Button();
            txtStatus = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 23);
            label1.Name = "label1";
            label1.Size = new Size(35, 15);
            label1.TabIndex = 0;
            label1.Text = "Host:";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(330, 19);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 1;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += btnStart_Click;
            // 
            // txtHost
            // 
            txtHost.Location = new Point(88, 15);
            txtHost.Name = "txtHost";
            txtHost.Size = new Size(100, 23);
            txtHost.TabIndex = 2;
            txtHost.Text = "127.0.0.1";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(256, 15);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(58, 23);
            txtPort.TabIndex = 4;
            txtPort.Text = "8910";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(212, 23);
            label2.Name = "label2";
            label2.Size = new Size(32, 15);
            label2.TabIndex = 3;
            label2.Text = "Port:";
            // 
            // btnStop
            // 
            btnStop.Location = new Point(426, 19);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 5;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(85, 50);
            txtStatus.Multiline = true;
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(416, 211);
            txtStatus.TabIndex = 6;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(567, 314);
            Controls.Add(txtStatus);
            Controls.Add(btnStop);
            Controls.Add(txtPort);
            Controls.Add(label2);
            Controls.Add(txtHost);
            Controls.Add(btnStart);
            Controls.Add(label1);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sever";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button btnStart;
        private TextBox txtHost;
        private TextBox txtPort;
        private Label label2;
        private Button btnStop;
        private TextBox txtStatus;
    }
}
