using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ListBox
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Xử lý sự kiện cho nút Nhập
       /* private void btnNhap_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu TextBox không rỗng
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                // Thêm giá trị từ TextBox vào ListBox
                listBox1.Items.Add(textBox1.Text);
                // Xóa TextBox
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá trị vào TextBox");
            }
        }*/

        // Xử lý sự kiện cho nút Tổng các phần tử trong List
        /*private void btnTongPhanTu_Click(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (var item in listBox1.Items)
            {
                // Cộng dồn giá trị các phần tử trong ListBox
                sum += int.Parse(item.ToString());
            }
            MessageBox.Show($"Tổng các phần tử trong List: {sum}");
        }*/

        // Xử lý sự kiện cho nút Xóa phần tử đầu và cuối
        private void btnXoaPhanTuDauCuoi_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count > 0)
            {
                // Xóa phần tử đầu tiên
                listBox1.Items.RemoveAt(0);
                // Xóa phần tử cuối cùng
                if (listBox1.Items.Count > 0)
                {
                    listBox1.Items.RemoveAt(listBox1.Items.Count - 1);
                }
            }
        }

        // Xử lý sự kiện cho nút Xóa phần tử thứ 2
        private void btnXoaPhanTu_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count >= 2)
            {
                // Xóa phần tử thứ 2 (index 1)
                listBox1.Items.RemoveAt(1);
            }
        }

        // Xử lý sự kiện cho nút Tăng mỗi phần tử lên 2
        private void btnTangLen2_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                // Tăng mỗi phần tử lên 2
                listBox1.Items[i] = (int.Parse(listBox1.Items[i].ToString()) + 2).ToString();
            }
        }

        // Xử lý sự kiện cho nút Thay bằng bình phương
        private void btnThayBangBinhPhuong_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listBox1.Items.Count; i++)
            {
                // Thay mỗi phần tử bằng bình phương của nó
                listBox1.Items[i] = (int.Parse(listBox1.Items[i].ToString()) * int.Parse(listBox1.Items[i].ToString())).ToString();
            }
        }

        private void btnNhap_Click_1(object sender, EventArgs e)
        {
            //Kiểm tra nếu TextBox không rỗng
            if (!string.IsNullOrEmpty(textBox1.Text))
            {
                // Thêm giá trị từ TextBox vào ListBox
                listBox1.Items.Add(textBox1.Text);
                // Xóa TextBox
                textBox1.Clear();
            }
            else
            {
                MessageBox.Show("Vui lòng nhập giá trị vào TextBox");
            }
        }

        private void btnTongPhanTu_Click_1(object sender, EventArgs e)
        {
            int sum = 0;
            foreach (var item in listBox1.Items)
            {
                // Cộng dồn giá trị các phần tử trong ListBox
                sum += int.Parse(item.ToString());
            }
            MessageBox.Show($"Tổng các phần tử trong List: {sum}");
        }

        private void btnKetThuc_Click(object sender, EventArgs e)
        {
            //Kiểm tra nếu Text không rỗng
            if (!string.IsNullOrEmpty(Text)) 
            {
                MessageBox.Show("Bạn có muốn đóng chương trình");
            }
                
            this.Close();
        }
    }
}
