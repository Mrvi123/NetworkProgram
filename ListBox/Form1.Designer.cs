namespace ListBox
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button btnNhap;
        private System.Windows.Forms.Button btnTongPhanTu;
        private System.Windows.Forms.Button btnXoaPhanTuDauCuoi;
        private System.Windows.Forms.Button btnXoaPhanTu;
        private System.Windows.Forms.Button btnTangLen2;
        private System.Windows.Forms.Button btnThayBangBinhPhuong;
        private System.Windows.Forms.Button btnKetThuc;

        /// <summary>
        /// Clean up any resources being used.
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

        private void InitializeComponent()
        {
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.btnNhap = new System.Windows.Forms.Button();
            this.btnTongPhanTu = new System.Windows.Forms.Button();
            this.btnXoaPhanTuDauCuoi = new System.Windows.Forms.Button();
            this.btnXoaPhanTu = new System.Windows.Forms.Button();
            this.btnTangLen2 = new System.Windows.Forms.Button();
            this.btnThayBangBinhPhuong = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(12, 38);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(150, 199);
            this.listBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 12);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 20);
            this.textBox1.TabIndex = 1;
            // 
            // btnNhap
            // 
            this.btnNhap.Location = new System.Drawing.Point(118, 10);
            this.btnNhap.Name = "btnNhap";
            this.btnNhap.Size = new System.Drawing.Size(75, 23);
            this.btnNhap.TabIndex = 2;
            this.btnNhap.Text = "Nhập";
            this.btnNhap.UseVisualStyleBackColor = true;
            this.btnNhap.Click += new System.EventHandler(this.btnNhap_Click_1);
            // 
            // btnTongPhanTu
            // 
            this.btnTongPhanTu.Location = new System.Drawing.Point(180, 38);
            this.btnTongPhanTu.Name = "btnTongPhanTu";
            this.btnTongPhanTu.Size = new System.Drawing.Size(150, 23);
            this.btnTongPhanTu.TabIndex = 3;
            this.btnTongPhanTu.Text = "Tổng các phần tử trong List";
            this.btnTongPhanTu.UseVisualStyleBackColor = true;
            this.btnTongPhanTu.Click += new System.EventHandler(this.btnTongPhanTu_Click_1);
            // 
            // btnXoaPhanTuDauCuoi
            // 
            this.btnXoaPhanTuDauCuoi.Location = new System.Drawing.Point(180, 67);
            this.btnXoaPhanTuDauCuoi.Name = "btnXoaPhanTuDauCuoi";
            this.btnXoaPhanTuDauCuoi.Size = new System.Drawing.Size(150, 23);
            this.btnXoaPhanTuDauCuoi.TabIndex = 4;
            this.btnXoaPhanTuDauCuoi.Text = "Xóa phần tử đầu và cuối";
            this.btnXoaPhanTuDauCuoi.UseVisualStyleBackColor = true;
            this.btnXoaPhanTuDauCuoi.Click += new System.EventHandler(this.btnXoaPhanTuDauCuoi_Click);
            // 
            // btnXoaPhanTu
            // 
            this.btnXoaPhanTu.Location = new System.Drawing.Point(180, 96);
            this.btnXoaPhanTu.Name = "btnXoaPhanTu";
            this.btnXoaPhanTu.Size = new System.Drawing.Size(150, 23);
            this.btnXoaPhanTu.TabIndex = 5;
            this.btnXoaPhanTu.Text = "Xóa phần tử thứ 2";
            this.btnXoaPhanTu.UseVisualStyleBackColor = true;
            this.btnXoaPhanTu.Click += new System.EventHandler(this.btnXoaPhanTu_Click);
            // 
            // btnTangLen2
            // 
            this.btnTangLen2.Location = new System.Drawing.Point(180, 125);
            this.btnTangLen2.Name = "btnTangLen2";
            this.btnTangLen2.Size = new System.Drawing.Size(150, 23);
            this.btnTangLen2.TabIndex = 6;
            this.btnTangLen2.Text = "Tăng mỗi phần tử lên 2";
            this.btnTangLen2.UseVisualStyleBackColor = true;
            this.btnTangLen2.Click += new System.EventHandler(this.btnTangLen2_Click);
            // 
            // btnThayBangBinhPhuong
            // 
            this.btnThayBangBinhPhuong.Location = new System.Drawing.Point(180, 154);
            this.btnThayBangBinhPhuong.Name = "btnThayBangBinhPhuong";
            this.btnThayBangBinhPhuong.Size = new System.Drawing.Size(150, 23);
            this.btnThayBangBinhPhuong.TabIndex = 7;
            this.btnThayBangBinhPhuong.Text = "Thay bằng bình phương";
            this.btnThayBangBinhPhuong.UseVisualStyleBackColor = true;
            this.btnThayBangBinhPhuong.Click += new System.EventHandler(this.btnThayBangBinhPhuong_Click);
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Location = new System.Drawing.Point(66, 243);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(210, 38);
            this.btnKetThuc.TabIndex = 0;
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.UseVisualStyleBackColor = true;
            this.btnKetThuc.Click += new System.EventHandler(this.btnKetThuc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(342, 308);
            this.Controls.Add(this.btnKetThuc);
            this.Controls.Add(this.btnThayBangBinhPhuong);
            this.Controls.Add(this.btnTangLen2);
            this.Controls.Add(this.btnXoaPhanTu);
            this.Controls.Add(this.btnXoaPhanTuDauCuoi);
            this.Controls.Add(this.btnTongPhanTu);
            this.Controls.Add(this.btnNhap);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.listBox1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ListBox";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private System.Windows.Forms.Button button1;
    }
}

