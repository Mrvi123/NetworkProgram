using System;
using System.Windows;

namespace YourNamespace
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Sự kiện nhấn nút "Giải"
        private void Giai_Click(object sender, RoutedEventArgs e)
        {
            // Kiểm tra đầu vào
            if (string.IsNullOrWhiteSpace(txtA.Text) || string.IsNullOrWhiteSpace(txtB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ giá trị A và B", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Chuyển đổi A và B từ chuỗi thành số thực
            if (double.TryParse(txtA.Text, out double a) && double.TryParse(txtB.Text, out double b))
            {
                if (a == 0 && b == 0)
                {
                    txtKQ.Text = "Vô số nghiệm";
                }
                else if (a == 0)
                {
                    txtKQ.Text = "Vô nghiệm";
                }
                else
                {
                    double x = -b / a;
                    txtKQ.Text = x.ToString();
                }
            }
            else
            {
                MessageBox.Show("Giá trị A và B phải là số", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        // Sự kiện nhấn nút "Xóa"
        private void Xoa_Click(object sender, RoutedEventArgs e)
        {
            // Xóa toàn bộ các giá trị trong TextBox
            txtA.Text = "";
            txtB.Text = "";
            txtKQ.Text = "";
        }
    }
}
