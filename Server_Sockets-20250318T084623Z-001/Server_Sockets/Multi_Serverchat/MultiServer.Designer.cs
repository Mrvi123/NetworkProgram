namespace Multi_Serverchat
{
    partial class MultiServer
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
            btnStart = new Button();
            btnStop = new Button();
            lsReceivedDataFromClient = new ListView();
            txtStatus = new TextBox();
            btnSendDataToClient = new Button();
            txtMessage = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(41, 23);
            label1.Name = "label1";
            label1.Size = new Size(115, 15);
            label1.TabIndex = 0;
            label1.Text = "Received from client";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(53, 329);
            label2.Name = "label2";
            label2.Size = new Size(86, 15);
            label2.TabIndex = 1;
            label2.Text = "Connect status";
            // 
            // btnStart
            // 
            btnStart.Location = new Point(85, 377);
            btnStart.Name = "btnStart";
            btnStart.Size = new Size(75, 23);
            btnStart.TabIndex = 2;
            btnStart.Text = "Start";
            btnStart.UseVisualStyleBackColor = true;
            btnStart.Click += button1_Click;
            // 
            // btnStop
            // 
            btnStop.Location = new Point(353, 377);
            btnStop.Name = "btnStop";
            btnStop.Size = new Size(75, 23);
            btnStop.TabIndex = 3;
            btnStop.Text = "Stop";
            btnStop.UseVisualStyleBackColor = true;
            btnStop.Click += btnStop_Click;
            // 
            // lsReceivedDataFromClient
            // 
            lsReceivedDataFromClient.Location = new Point(63, 63);
            lsReceivedDataFromClient.Name = "lsReceivedDataFromClient";
            lsReceivedDataFromClient.Size = new Size(394, 245);
            lsReceivedDataFromClient.TabIndex = 4;
            lsReceivedDataFromClient.UseCompatibleStateImageBehavior = false;
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(155, 326);
            txtStatus.Name = "txtStatus";
            txtStatus.Size = new Size(339, 23);
            txtStatus.TabIndex = 5;
            // 
            // btnSendDataToClient
            // 
            btnSendDataToClient.Location = new Point(475, 63);
            btnSendDataToClient.Name = "btnSendDataToClient";
            btnSendDataToClient.Size = new Size(75, 23);
            btnSendDataToClient.TabIndex = 6;
            btnSendDataToClient.Text = "Send";
            btnSendDataToClient.UseVisualStyleBackColor = true;
            btnSendDataToClient.Click += btnSendDataToClient_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(480, 104);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(173, 23);
            txtMessage.TabIndex = 7;
            // 
            // MultiServer
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtMessage);
            Controls.Add(btnSendDataToClient);
            Controls.Add(txtStatus);
            Controls.Add(lsReceivedDataFromClient);
            Controls.Add(btnStop);
            Controls.Add(btnStart);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "MultiServer";
            Text = "Server";
            Load += MultiServer_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button btnStart;
        private Button btnStop;
        private ListView lsReceivedDataFromClient;
        private TextBox txtStatus;
        private Button btnSendDataToClient;
        private TextBox txtMessage;
    }
}
