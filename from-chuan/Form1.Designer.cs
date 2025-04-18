namespace form_chuan
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
            txtMessage = new TextBox();
            btFile = new Button();
            label2 = new Label();
            cbMahoa = new ComboBox();
            cbChedo = new ComboBox();
            label3 = new Label();
            btKetnoi = new Button();
            btNgatketnoi = new Button();
            btGui = new Button();
            label4 = new Label();
            lvTinnhan = new ListView();
            label5 = new Label();
            txtTrangthai = new TextBox();
            button1 = new Button();
            button2 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 37);
            label1.Name = "label1";
            label1.Size = new Size(105, 17);
            label1.TabIndex = 0;
            label1.Text = "Nhap noi dung:";
            label1.Click += label1_Click;
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(142, 25);
            txtMessage.Multiline = true;
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(748, 36);
            txtMessage.TabIndex = 1;
            // 
            // btFile
            // 
            btFile.BackColor = SystemColors.ControlDarkDark;
            btFile.ForeColor = SystemColors.ButtonHighlight;
            btFile.Location = new Point(818, 25);
            btFile.Name = "btFile";
            btFile.Size = new Size(72, 40);
            btFile.TabIndex = 2;
            btFile.Text = "[File]";
            btFile.UseVisualStyleBackColor = false;
            btFile.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(25, 89);
            label2.Name = "label2";
            label2.Size = new Size(98, 17);
            label2.TabIndex = 3;
            label2.Text = "Chon ma hoa :";
            label2.Click += label2_Click;
            // 
            // cbMahoa
            // 
            cbMahoa.FormattingEnabled = true;
            cbMahoa.Items.AddRange(new object[] { "  Caesar ", "  Playfair ", "  Rail Fence" });
            cbMahoa.Location = new Point(142, 78);
            cbMahoa.Name = "cbMahoa";
            cbMahoa.Size = new Size(229, 28);
            cbMahoa.TabIndex = 5;
            // 
            // cbChedo
            // 
            cbChedo.FormattingEnabled = true;
            cbChedo.Items.AddRange(new object[] { "Thu cong ", "Tu dong" });
            cbChedo.Location = new Point(142, 117);
            cbChedo.Name = "cbChedo";
            cbChedo.Size = new Size(229, 28);
            cbChedo.TabIndex = 6;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 128);
            label3.Name = "label3";
            label3.Size = new Size(55, 17);
            label3.TabIndex = 7;
            label3.Text = "Che đo:";
            // 
            // btKetnoi
            // 
            btKetnoi.BackColor = Color.ForestGreen;
            btKetnoi.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btKetnoi.ForeColor = SystemColors.ButtonHighlight;
            btKetnoi.Location = new Point(381, 67);
            btKetnoi.Name = "btKetnoi";
            btKetnoi.Size = new Size(161, 48);
            btKetnoi.TabIndex = 8;
            btKetnoi.Text = "Ket Noi";
            btKetnoi.UseVisualStyleBackColor = false;
            btKetnoi.Click += btKetnoi_Click;
            // 
            // btNgatketnoi
            // 
            btNgatketnoi.BackColor = Color.FromArgb(192, 0, 0);
            btNgatketnoi.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btNgatketnoi.ForeColor = SystemColors.ButtonHighlight;
            btNgatketnoi.Location = new Point(548, 67);
            btNgatketnoi.Name = "btNgatketnoi";
            btNgatketnoi.Size = new Size(154, 48);
            btNgatketnoi.TabIndex = 9;
            btNgatketnoi.Text = "Ngat ket noi";
            btNgatketnoi.UseVisualStyleBackColor = false;
            btNgatketnoi.Click += btNgatketnoi_Click;
            // 
            // btGui
            // 
            btGui.BackColor = SystemColors.HotTrack;
            btGui.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btGui.ForeColor = SystemColors.ButtonHighlight;
            btGui.Location = new Point(735, 67);
            btGui.Name = "btGui";
            btGui.Size = new Size(155, 48);
            btGui.TabIndex = 10;
            btGui.Text = "Gui";
            btGui.UseVisualStyleBackColor = false;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(25, 180);
            label4.Name = "label4";
            label4.Size = new Size(67, 17);
            label4.TabIndex = 11;
            label4.Text = "Tin nhan:";
            // 
            // lvTinnhan
            // 
            lvTinnhan.BackColor = Color.Gainsboro;
            lvTinnhan.Location = new Point(142, 180);
            lvTinnhan.Name = "lvTinnhan";
            lvTinnhan.Size = new Size(729, 229);
            lvTinnhan.TabIndex = 12;
            lvTinnhan.UseCompatibleStateImageBehavior = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 437);
            label5.Name = "label5";
            label5.Size = new Size(75, 17);
            label5.TabIndex = 13;
            label5.Text = "Trang thai:";
            // 
            // txtTrangthai
            // 
            txtTrangthai.Location = new Point(142, 432);
            txtTrangthai.Multiline = true;
            txtTrangthai.Name = "txtTrangthai";
            txtTrangthai.Size = new Size(282, 34);
            txtTrangthai.TabIndex = 14;
            // 
            // button1
            // 
            button1.BackColor = Color.ForestGreen;
            button1.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.ButtonHighlight;
            button1.Location = new Point(560, 423);
            button1.Name = "button1";
            button1.Size = new Size(142, 45);
            button1.TabIndex = 15;
            button1.Text = "Ket noi";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click_1;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.ControlDarkDark;
            button2.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button2.ForeColor = SystemColors.ButtonHighlight;
            button2.Location = new Point(726, 423);
            button2.Name = "button2";
            button2.Size = new Size(145, 45);
            button2.TabIndex = 16;
            button2.Text = "Dung ket noi";
            button2.UseVisualStyleBackColor = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(902, 512);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(txtTrangthai);
            Controls.Add(label5);
            Controls.Add(lvTinnhan);
            Controls.Add(label4);
            Controls.Add(btGui);
            Controls.Add(btNgatketnoi);
            Controls.Add(btKetnoi);
            Controls.Add(label3);
            Controls.Add(cbChedo);
            Controls.Add(cbMahoa);
            Controls.Add(label2);
            Controls.Add(btFile);
            Controls.Add(txtMessage);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Name = "Form1";
            Text = "From client-Chatbox Secure";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtMessage;
        private Button btFile;
        private Label label2;
        private ComboBox cbMahoa;
        private ComboBox cbChedo;
        private Label label3;
        private Button btKetnoi;
        private Button btNgatketnoi;
        private Button btGui;
        private Label label4;
        private ListView lvTinnhan;
        private Label label5;
        private TextBox txtTrangthai;
        private Button button1;
        private Button button2;
    }
}
