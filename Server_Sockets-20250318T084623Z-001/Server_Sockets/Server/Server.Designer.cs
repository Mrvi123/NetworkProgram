using System.Net.Sockets;

namespace Server
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

            //if (btnStartServer != null) {
            //    btnStartServer.Shutdown(SocketShutdown.Both);
            //    btnStartServer.Close();
            //    btnStartServer.Dispose();
            //}
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
            txtStatusServer = new TextBox();
            btnStartServer = new Button();
            btnStopServer = new Button();
            lsReceivedDataFromClient = new ListView();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(49, 13);
            label1.Name = "label1";
            label1.Size = new Size(139, 15);
            label1.TabIndex = 0;
            label1.Text = "Text received from client:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(49, 359);
            label2.Name = "label2";
            label2.Size = new Size(89, 15);
            label2.TabIndex = 2;
            label2.Text = "Connect status:";
            // 
            // txtStatusServer
            // 
            txtStatusServer.Location = new Point(153, 351);
            txtStatusServer.Name = "txtStatusServer";
            txtStatusServer.Size = new Size(368, 23);
            txtStatusServer.TabIndex = 3;
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new Point(143, 391);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(75, 23);
            btnStartServer.TabIndex = 4;
            btnStartServer.Text = "Start";
            btnStartServer.UseVisualStyleBackColor = true;
            btnStartServer.Click += button1_Click;
            // 
            // btnStopServer
            // 
            btnStopServer.Location = new Point(335, 391);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new Size(75, 23);
            btnStopServer.TabIndex = 5;
            btnStopServer.Text = "Stop";
            btnStopServer.UseVisualStyleBackColor = true;
            btnStopServer.Click += button2_Click;
            // 
            // lsReceivedDataFromClient
            // 
            lsReceivedDataFromClient.Location = new Point(49, 48);
            lsReceivedDataFromClient.Name = "lsReceivedDataFromClient";
            lsReceivedDataFromClient.Size = new Size(472, 258);
            lsReceivedDataFromClient.TabIndex = 6;
            lsReceivedDataFromClient.UseCompatibleStateImageBehavior = false;
           // lsReceivedDataFromClient.SelectedIndexChanged += this.lsReceivedDataFromClient_SelectedIndexChanged_1;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(lsReceivedDataFromClient);
            Controls.Add(btnStopServer);
            Controls.Add(btnStartServer);
            Controls.Add(txtStatusServer);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Server";
            Text = "Server";
            Load += Server_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private TextBox txtStatusServer;
        private Button btnStartServer;
        private Button btnStopServer;
        private ListView lsReceivedDataFromClient;
        //private Form Server;
    }
}
