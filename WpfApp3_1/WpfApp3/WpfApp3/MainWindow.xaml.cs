using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
//using System.Windows.Forms.Application.WpfApp3.Close;//tại vị trí FORMS THÌ chúng ta nên truyền tên Forms mà chúng ta đang tạo

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnGiai_Click(object sender, RoutedEventArgs e)
        {
            double a, b;
            try
            {
                a = double.Parse(txtA.Text);
                b = double.Parse(txtB.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return;
            }

            if (a == 0)
            {
                if (b == 0)
                {
                    txtNghiem.Text = "Phương trình có vô số nghiệm.";
                }
                else
                {
                    txtNghiem.Text = "Phương trình vô nghiệm.";
                }
            }
            else
            {
                double x = -b / a;
                txtNghiem.Text = "Nghiệm của phương trình là: " + x;
            }
        }

        private void btnXoa_Click(object sender, RoutedEventArgs e)
        {
            txtA.Text = "";
            txtB.Text = "";
            txtNghiem.Text = "";
            btnGiai.IsEnabled = true;
            btnXoa.IsEnabled = true;
        }

        private void btnThoat_Click(object sender, RoutedEventArgs e)
        {
            // Hiện hộp thoại xác nhận trước khi thoát
            if (MessageBox.Show("Bạn có muốn thoát chương trình?", "Xác nhận", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                Application.Current.MainWindow.Close();
            }
        }

        private void txtA_TextChanged(object sender, RoutedEventArgs e)
        {
            EnableButtons();
        }

        private void txtB_TextChanged(object sender, RoutedEventArgs e)
        {
            EnableButtons();
        }

        private void EnableButtons()
        {
            btnGiai.IsEnabled = true;
            btnXoa.IsEnabled = true;
        }
    }
}
