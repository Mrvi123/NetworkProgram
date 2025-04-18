using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            btnTongCacPhanTu.MouseUp += btnTongCacPhanTu_MouseUp;
            btnKetThuc.Move += btnKetThuc_Move;
        }

        private void btnKetThuc_Move(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonNhap_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(textBoxInput.Text))
            {
                listBoxItems.Items.Add(textBoxInput.Text);
                textBoxInput.Clear();
                textBoxInput.Focus();
            }
        }

        private void buttonTongCacPhanTu_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (string item in listBoxItems.Items)
            {
                if (int.TryParse(item, out int number))
                {
                    sum += number;
                }
            }
            MessageBox.Show($"Tổng các phần tử trong List: {sum}");
        }

        private void buttonXoaCacPhanTuDauVaCuoi_Click(object sender, EventArgs e)
        {
            if (listBoxItems.Items.Count > 0)
            {
                listBoxItems.Items.RemoveAt(0);
            }
            if (listBoxItems.Items.Count > 0)
            {
                listBoxItems.Items.RemoveAt(listBoxItems.Items.Count - 1);
            }
        }

        private void buttonXoaPhanTuDangChon_Click(object sender, EventArgs e)
        {
            if (listBoxItems.SelectedIndex != -1)
            {
                listBoxItems.Items.RemoveAt(listBoxItems.SelectedIndex);
            }
        }

        private void buttonTangMoiPhanTuLen2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBoxItems.Items.Count; i++)
            {
                if (int.TryParse(listBoxItems.Items[i].ToString(), out int number))
                {
                    listBoxItems.Items[i] = (number + 2).ToString();
                }
            }
        }
        private void buttonThayBangBinhPhuong_Click(object sender, EventArgs e ) 
        {
            for(int i = 0; i < listBoxItems.Items.Count; i++) 
            {
                if (int.TryParse(listBoxItems.Items[i].ToString(), out int number)) 
                {
                    listBoxItems.Items[i] = (number * number).ToString();
                }
            }
        }

        private void btnTongCacPhanTu_MouseUp(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left) 
            {
                MessageBox.Show("Left Click");
            }else if(e.Button == MouseButtons.Middle) 
            {
                MessageBox.Show("Right Click");
            }else if (e.Button == MouseButtons.Right) 
            {
                MessageBox.Show("Right Click");
            }
        }

        private void btnKetThuc_Layout(object sender, LayoutEventArgs e) 
        {
            
        }

    }
}
