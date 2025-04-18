namespace Client_TransFileSocketAsync
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
            label1 = new Label();
            lblReceivedClient = new Label();
            lblStatusClient = new Label();
            txtBrowseClient = new TextBox();
            txtReceivedClient = new TextBox();
            btnBrowseClient = new Button();
            btnReceivedClient = new Button();
            btnConnectClient = new Button();
            btnDisconnectClient = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(257, 26);
            label1.Name = "label1";
            label1.Size = new Size(165, 15);
            label1.TabIndex = 0;
            label1.Text = "CHƯƠNG TRÌNH TRUYỀN FILE";
            // 
            // lblReceivedClient
            // 
            lblReceivedClient.AutoSize = true;
            lblReceivedClient.Location = new Point(49, 86);
            lblReceivedClient.Name = "lblReceivedClient";
            lblReceivedClient.Size = new Size(77, 15);
            lblReceivedClient.TabIndex = 1;
            lblReceivedClient.Text = "NƠI LƯU FILE";
            lblReceivedClient.Click += label2_Click;
            // 
            // lblStatusClient
            // 
            lblStatusClient.AutoSize = true;
            lblStatusClient.Location = new Point(31, 160);
            lblStatusClient.Name = "lblStatusClient";
            lblStatusClient.Size = new Size(120, 15);
            lblStatusClient.TabIndex = 2;
            lblStatusClient.Text = "TRẠNG THÁI KẾT NỐI";
            // 
            // txtBrowseClient
            // 
            txtBrowseClient.Location = new Point(157, 83);
            txtBrowseClient.Name = "txtBrowseClient";
            txtBrowseClient.Size = new Size(328, 23);
            txtBrowseClient.TabIndex = 3;
            // 
            // txtReceivedClient
            // 
            txtReceivedClient.Location = new Point(157, 152);
            txtReceivedClient.Name = "txtReceivedClient";
            txtReceivedClient.Size = new Size(328, 23);
            txtReceivedClient.TabIndex = 4;
            txtReceivedClient.TextChanged += textBox2_TextChanged;
            // 
            // btnBrowseClient
            // 
            btnBrowseClient.Location = new Point(514, 83);
            btnBrowseClient.Name = "btnBrowseClient";
            btnBrowseClient.Size = new Size(75, 23);
            btnBrowseClient.TabIndex = 5;
            btnBrowseClient.Text = "Browse";
            btnBrowseClient.UseVisualStyleBackColor = true;
            // 
            // btnReceivedClient
            // 
            btnReceivedClient.Location = new Point(514, 170);
            btnReceivedClient.Name = "btnReceivedClient";
            btnReceivedClient.Size = new Size(75, 23);
            btnReceivedClient.TabIndex = 6;
            btnReceivedClient.Text = "Nhận file";
            btnReceivedClient.UseVisualStyleBackColor = true;
            btnReceivedClient.Click += button2_Click;
            // 
            // btnConnectClient
            // 
            btnConnectClient.Location = new Point(514, 127);
            btnConnectClient.Name = "btnConnectClient";
            btnConnectClient.Size = new Size(75, 23);
            btnConnectClient.TabIndex = 7;
            btnConnectClient.Text = "Connect";
            btnConnectClient.UseVisualStyleBackColor = true;
            // 
            // btnDisconnectClient
            // 
            btnDisconnectClient.Location = new Point(608, 127);
            btnDisconnectClient.Name = "btnDisconnectClient";
            btnDisconnectClient.Size = new Size(75, 23);
            btnDisconnectClient.TabIndex = 8;
            btnDisconnectClient.Text = "Disconnect";
            btnDisconnectClient.UseVisualStyleBackColor = true;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(723, 235);
            Controls.Add(btnDisconnectClient);
            Controls.Add(btnConnectClient);
            Controls.Add(btnReceivedClient);
            Controls.Add(btnBrowseClient);
            Controls.Add(txtReceivedClient);
            Controls.Add(txtBrowseClient);
            Controls.Add(lblStatusClient);
            Controls.Add(lblReceivedClient);
            Controls.Add(label1);
            Name = "Client";
            Text = "Client";
            Load += Client_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label lblReceivedClient;
        private Label lblStatusClient;
        private TextBox txtBrowseClient;
        private TextBox txtReceivedClient;
        private Button btnBrowseClient;
        private Button btnReceivedClient;
        private Button btnConnectClient;
        private Button btnDisconnectClient;
    }
}
