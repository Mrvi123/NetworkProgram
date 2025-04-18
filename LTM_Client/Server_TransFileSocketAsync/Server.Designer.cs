namespace Server_TransFileSocketAsync
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
            lblSelectFileServer = new Label();
            lblStatusServer = new Label();
            txtFileSelectServer = new TextBox();
            txtStatusServer = new TextBox();
            btnBrowseServer = new Button();
            btnStartServer = new Button();
            btnStopServer = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(269, 25);
            label1.Name = "label1";
            label1.Size = new Size(165, 15);
            label1.TabIndex = 0;
            label1.Text = "CHƯƠNG TRÌNH TRUYỀN FILE";
            // 
            // lblSelectFileServer
            // 
            lblSelectFileServer.AutoSize = true;
            lblSelectFileServer.Location = new Point(35, 100);
            lblSelectFileServer.Name = "lblSelectFileServer";
            lblSelectFileServer.Size = new Size(71, 15);
            lblSelectFileServer.TabIndex = 1;
            lblSelectFileServer.Text = "File đã chọn";
            // 
            // lblStatusServer
            // 
            lblStatusServer.AutoSize = true;
            lblStatusServer.Location = new Point(35, 165);
            lblStatusServer.Name = "lblStatusServer";
            lblStatusServer.Size = new Size(98, 15);
            lblStatusServer.TabIndex = 2;
            lblStatusServer.Text = "Trạng thái kết nối";
            // 
            // txtFileSelectServer
            // 
            txtFileSelectServer.Location = new Point(158, 97);
            txtFileSelectServer.Name = "txtFileSelectServer";
            txtFileSelectServer.Size = new Size(255, 23);
            txtFileSelectServer.TabIndex = 3;
            // 
            // txtStatusServer
            // 
            txtStatusServer.Location = new Point(158, 165);
            txtStatusServer.Name = "txtStatusServer";
            txtStatusServer.Size = new Size(255, 23);
            txtStatusServer.TabIndex = 4;
            // 
            // btnBrowseServer
            // 
            btnBrowseServer.Location = new Point(464, 92);
            btnBrowseServer.Name = "btnBrowseServer";
            btnBrowseServer.Size = new Size(75, 23);
            btnBrowseServer.TabIndex = 5;
            btnBrowseServer.Text = "Browse";
            btnBrowseServer.UseVisualStyleBackColor = true;
            btnBrowseServer.Click += btnBrowseServer_Click;
            // 
            // btnStartServer
            // 
            btnStartServer.Location = new Point(464, 139);
            btnStartServer.Name = "btnStartServer";
            btnStartServer.Size = new Size(75, 23);
            btnStartServer.TabIndex = 6;
            btnStartServer.Text = "Start";
            btnStartServer.UseVisualStyleBackColor = true;
            // 
            // btnStopServer
            // 
            btnStopServer.Location = new Point(464, 181);
            btnStopServer.Name = "btnStopServer";
            btnStopServer.Size = new Size(75, 23);
            btnStopServer.TabIndex = 7;
            btnStopServer.Text = "Stop";
            btnStopServer.UseVisualStyleBackColor = true;
            // 
            // Server
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 254);
            Controls.Add(btnStopServer);
            Controls.Add(btnStartServer);
            Controls.Add(btnBrowseServer);
            Controls.Add(txtStatusServer);
            Controls.Add(txtFileSelectServer);
            Controls.Add(lblStatusServer);
            Controls.Add(lblSelectFileServer);
            Controls.Add(label1);
            Name = "Server";
            Text = "Server";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblSelectFileServer;
        private Label lblStatusServer;
        private TextBox txtFileSelectServer;
        private TextBox txtStatusServer;
        private Button btnBrowseServer;
        private Button btnStartServer;
        private Button btnStopServer;
    }
}
