using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Client
{
    partial class Client:Form
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
            btnSend = new Button();
            btnConnect = new Button();
            btnDisconnect = new Button();
            label2 = new Label();
            txtStatus = new TextBox();
            listView1 = new ListView();
            label3 = new Label();
            textBox1 = new TextBox();
            btnNhap = new Button();
            label4 = new Label();
            button1 = new Button();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            //SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(42, 21);
            label1.Name = "label1";
            label1.Size = new Size(93, 15);
            label1.TabIndex = 0;
            label1.Text = "Enter text string:";
            // 
            // txtMessage
            // 
            txtMessage.Location = new Point(147, 24);
            txtMessage.Name = "txtMessage";
            txtMessage.Size = new Size(354, 23);
            txtMessage.TabIndex = 1;
            //txtMessage.TextChanged += txtMessage_TextChanged;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(520, 30);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(75, 23);
            btnSend.TabIndex = 2;
            btnSend.Text = "Send";
            btnSend.UseVisualStyleBackColor = true;
            //btnSend.Click += btnSend_Click;
            // 
            // btnConnect
            // 
            btnConnect.Location = new Point(520, 268);
            btnConnect.Name = "btnConnect";
            btnConnect.Size = new Size(75, 23);
            btnConnect.TabIndex = 4;
            btnConnect.Text = "Connect";
            btnConnect.UseVisualStyleBackColor = true;
            //btnConnect.Click += btnConnect_Click;
            // 
            // btnDisconnect
            // 
            btnDisconnect.Location = new Point(520, 297);
            btnDisconnect.Name = "btnDisconnect";
            btnDisconnect.Size = new Size(75, 23);
            btnDisconnect.TabIndex = 5;
            btnDisconnect.Text = "Disconnect";
            btnDisconnect.UseVisualStyleBackColor = true;
            //btnDisconnect.Click += btnDisconnect_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(56, 344);
            label2.Name = "label2";
            label2.Size = new Size(106, 15);
            label2.TabIndex = 6;
            label2.Text = "Connection status:";
            // 
            // txtStatus
            // 
            txtStatus.Location = new Point(174, 347);
            txtStatus.Name = "txtStatus";
            txtStatus.ReadOnly = true;
            txtStatus.Size = new Size(327, 23);
            txtStatus.TabIndex = 7;
            // 
            // listView1
            // 
            listView1.Location = new Point(74, 154);
            listView1.Name = "listView1";
            listView1.Size = new Size(198, 107);
            listView1.TabIndex = 8;
            listView1.UseCompatibleStateImageBehavior = false;
            //listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(72, 77);
            label3.Name = "label3";
            label3.Size = new Size(42, 15);
            label3.TabIndex = 9;
            label3.Text = "listbox";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(72, 95);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(200, 23);
            textBox1.TabIndex = 10;
            // 
            // btnNhap
            // 
            //btnNhap.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnNhap.Location = new Point(72, 124);
            btnNhap.Name = "btnNhap";
            btnNhap.Size = new Size(200, 24);
            btnNhap.TabIndex = 11;
            btnNhap.Text = "Nhập";
            btnNhap.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(428, 77);
            label4.Name = "label4";
            label4.Size = new Size(73, 15);
            label4.TabIndex = 12;
            label4.Text = "xử lý Listbox";
            // 
            // button1
            // 
            button1.Location = new Point(407, 119);
            button1.Name = "button1";
            button1.Size = new Size(200, 30);
            button1.TabIndex = 13;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(407, 183);
            button2.Name = "button2";
            button2.Size = new Size(200, 24);
            button2.TabIndex = 14;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(407, 154);
            button3.Name = "button3";
            button3.Size = new Size(200, 24);
            button3.TabIndex = 15;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            //button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.Location = new Point(407, 212);
            button4.Name = "button4";
            button4.Size = new Size(200, 24);
            button4.TabIndex = 16;
            button4.Text = "button4";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Location = new Point(407, 238);
            button5.Name = "button5";
            button5.Size = new Size(200, 24);
            button5.TabIndex = 17;
            button5.Text = "button5";
            button5.UseVisualStyleBackColor = true;
            // 
            // button6
            // 
            button6.Location = new Point(289, 401);
            button6.Name = "button6";
            button6.Size = new Size(75, 23);
            button6.TabIndex = 18;
            button6.Text = "button6";
            button6.UseVisualStyleBackColor = true;
            // 
            // Client
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(label4);
            Controls.Add(btnNhap);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(listView1);
            Controls.Add(txtStatus);
            Controls.Add(label2);
            Controls.Add(btnDisconnect);
            Controls.Add(btnConnect);
            Controls.Add(btnSend);
            Controls.Add(txtMessage);
            Controls.Add(label1);
            Name = "Client";
            Text = "Client";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtMessage;
        private Button btnSend;
        //private RichTextBox rtbMessages;
        private Button btnConnect;
        private Button btnDisconnect;
        private Label label2;
        private TextBox txtStatus;
        private ListView listView1;
        private Label label3;
        private TextBox textBox1;
        private Button btnNhap;
        private Label label4;
        private Button button1;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}
