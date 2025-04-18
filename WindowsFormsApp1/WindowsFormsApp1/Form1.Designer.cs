namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonNhap = new System.Windows.Forms.Button();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.btnTongCacPhanTu = new System.Windows.Forms.Button();
            this.btnXoaCacPhanTuDauVaCuoi = new System.Windows.Forms.Button();
            this.btnXoaPhanTuDangChon = new System.Windows.Forms.Button();
            this.btnTangMoiPhanTuLen2 = new System.Windows.Forms.Button();
            this.btnThayBangBinhPhuong = new System.Windows.Forms.Button();
            this.btnKetThuc = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(89, 65);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(139, 20);
            this.textBoxInput.TabIndex = 0;
            // 
            // buttonNhap
            // 
            this.buttonNhap.Location = new System.Drawing.Point(89, 95);
            this.buttonNhap.Name = "buttonNhap";
            this.buttonNhap.Size = new System.Drawing.Size(139, 34);
            this.buttonNhap.TabIndex = 1;
            this.buttonNhap.Text = "Nhập";
            this.buttonNhap.UseVisualStyleBackColor = true;
            this.buttonNhap.Click += new System.EventHandler(this.buttonNhap_Click);
            // 
            // listBoxItems
            // 
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.Location = new System.Drawing.Point(89, 135);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.Size = new System.Drawing.Size(139, 134);
            this.listBoxItems.TabIndex = 2;
            // 
            // btnTongCacPhanTu
            // 
            this.btnTongCacPhanTu.Location = new System.Drawing.Point(402, 65);
            this.btnTongCacPhanTu.Name = "btnTongCacPhanTu";
            this.btnTongCacPhanTu.Size = new System.Drawing.Size(147, 23);
            this.btnTongCacPhanTu.TabIndex = 3;
            this.btnTongCacPhanTu.Text = "Tổng các phần tử trong List";
            this.btnTongCacPhanTu.UseVisualStyleBackColor = true;
            // 
            // btnXoaCacPhanTuDauVaCuoi
            // 
            this.btnXoaCacPhanTuDauVaCuoi.Location = new System.Drawing.Point(402, 116);
            this.btnXoaCacPhanTuDauVaCuoi.Name = "btnXoaCacPhanTuDauVaCuoi";
            this.btnXoaCacPhanTuDauVaCuoi.Size = new System.Drawing.Size(147, 23);
            this.btnXoaCacPhanTuDauVaCuoi.TabIndex = 4;
            this.btnXoaCacPhanTuDauVaCuoi.Text = "Xóa phần tử đầu và cuối";
            this.btnXoaCacPhanTuDauVaCuoi.UseVisualStyleBackColor = true;
            // 
            // btnXoaPhanTuDangChon
            // 
            this.btnXoaPhanTuDangChon.Location = new System.Drawing.Point(402, 165);
            this.btnXoaPhanTuDangChon.Name = "btnXoaPhanTuDangChon";
            this.btnXoaPhanTuDangChon.Size = new System.Drawing.Size(147, 23);
            this.btnXoaPhanTuDangChon.TabIndex = 5;
            this.btnXoaPhanTuDangChon.Text = "Xóa phần tử đang chọn";
            this.btnXoaPhanTuDangChon.UseVisualStyleBackColor = true;
            // 
            // btnTangMoiPhanTuLen2
            // 
            this.btnTangMoiPhanTuLen2.Location = new System.Drawing.Point(402, 209);
            this.btnTangMoiPhanTuLen2.Name = "btnTangMoiPhanTuLen2";
            this.btnTangMoiPhanTuLen2.Size = new System.Drawing.Size(147, 23);
            this.btnTangMoiPhanTuLen2.TabIndex = 6;
            this.btnTangMoiPhanTuLen2.Text = "Tăng mỗi phần tử lên 2";
            this.btnTangMoiPhanTuLen2.UseVisualStyleBackColor = true;
            // 
            // btnThayBangBinhPhuong
            // 
            this.btnThayBangBinhPhuong.Location = new System.Drawing.Point(402, 251);
            this.btnThayBangBinhPhuong.Name = "btnThayBangBinhPhuong";
            this.btnThayBangBinhPhuong.Size = new System.Drawing.Size(147, 23);
            this.btnThayBangBinhPhuong.TabIndex = 7;
            this.btnThayBangBinhPhuong.Text = "Thay bằng bình phương";
            this.btnThayBangBinhPhuong.UseVisualStyleBackColor = true;
            // 
            // btnKetThuc
            // 
            this.btnKetThuc.Location = new System.Drawing.Point(89, 305);
            this.btnKetThuc.Name = "btnKetThuc";
            this.btnKetThuc.Size = new System.Drawing.Size(460, 23);
            this.btnKetThuc.TabIndex = 8;
            this.btnKetThuc.Text = "Kết thúc";
            this.btnKetThuc.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Cambria", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(309, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(122, 32);
            this.label1.TabIndex = 9;
            this.label1.Text = "LISTBOX";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 413);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnKetThuc);
            this.Controls.Add(this.btnThayBangBinhPhuong);
            this.Controls.Add(this.btnTangMoiPhanTuLen2);
            this.Controls.Add(this.btnXoaPhanTuDangChon);
            this.Controls.Add(this.btnXoaCacPhanTuDauVaCuoi);
            this.Controls.Add(this.btnTongCacPhanTu);
            this.Controls.Add(this.listBoxItems);
            this.Controls.Add(this.buttonNhap);
            this.Controls.Add(this.textBoxInput);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonNhap;
        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.Button btnTongCacPhanTu;
        private System.Windows.Forms.Button btnXoaCacPhanTuDauVaCuoi;
        private System.Windows.Forms.Button btnXoaPhanTuDangChon;
        private System.Windows.Forms.Button btnTangMoiPhanTuLen2;
        private System.Windows.Forms.Button btnThayBangBinhPhuong;
        private System.Windows.Forms.Button btnKetThuc;
        private System.Windows.Forms.Label label1;
    }
}

