namespace Capture_Image_Server_Ver2
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
            label2 = new Label();
            label3 = new Label();
            txtPort = new TextBox();
            txtSaveFile = new TextBox();
            lblStatus = new Label();
            btnBrowse = new Button();
            btnStartListen = new Button();
            btnStop = new Button();
            label5 = new Label();
            lsLog = new ListBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(265, 30);
            label1.Name = "label1";
            label1.Size = new Size(131, 15);
            label1.TabIndex = 0;
            label1.Text = "Desktop Monitor Server";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(97, 86);
            label2.Name = "label2";
            label2.Size = new Size(29, 15);
            label2.TabIndex = 1;
            label2.Text = "Port";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(97, 130);
            label3.Name = "label3";
            label3.Size = new Size(82, 15);
            label3.TabIndex = 2;
            label3.Text = "Folder Save To";
            // 
            // txtPort
            // 
            txtPort.Location = new Point(216, 86);
            txtPort.Name = "txtPort";
            txtPort.Size = new Size(126, 23);
            txtPort.TabIndex = 3;
            // 
            // txtSaveFile
            // 
            txtSaveFile.Location = new Point(216, 130);
            txtSaveFile.Name = "txtSaveFile";
            txtSaveFile.Size = new Size(126, 23);
            txtSaveFile.TabIndex = 4;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(97, 211);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(39, 15);
            lblStatus.TabIndex = 5;
            lblStatus.Text = "Status";
            // 
            // btnBrowse
            // 
            btnBrowse.Location = new Point(123, 172);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 23);
            btnBrowse.TabIndex = 6;
            btnBrowse.Text = "Browse";
            btnBrowse.UseVisualStyleBackColor = true;
            // 
            // btnStartListen
            // 
            btnStartListen.Location = new Point(227, 172);
            btnStartListen.Name = "btnStartListen";
            btnStartListen.Size = new Size(101, 23);
            btnStartListen.TabIndex = 7;
            btnStartListen.Text = "Start Listenning";
            btnStartListen.UseVisualStyleBackColor = true;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(370, 172);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 8;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            //btnStop.Click += btnStop_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(97, 259);
            label5.Name = "label5";
            label5.Size = new Size(27, 15);
            label5.TabIndex = 9;
            label5.Text = "Log";
            // 
            // lsLog
            // 
            lsLog.FormattingEnabled = true;
            lsLog.ItemHeight = 15;
            lsLog.Items.AddRange(new object[] { "Received From", "Received From" });
            lsLog.Location = new Point(177, 260);
            lsLog.Name = "lsLog";
            lsLog.Size = new Size(165, 94);
            lsLog.TabIndex = 10;
            // 
            // Server_Image
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lsLog);
            Controls.Add(label5);
            Controls.Add(btnStop);
            Controls.Add(btnStartListen);
            Controls.Add(btnBrowse);
            Controls.Add(lblStatus);
            Controls.Add(txtSaveFile);
            Controls.Add(txtPort);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Server_Image";
            Text = "Form1";
          //  Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtPort;
        private TextBox txtSaveFile;
        private Label lblStatus;
        private Button btnBrowse;
        private Button btnStartListen;
        private Button btnStop;
        private Label label5;
        private ListBox lsLog;
    }
}
