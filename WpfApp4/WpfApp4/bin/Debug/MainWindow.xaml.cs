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

namespace WpfApp4
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

        private void btnNhap(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtNhap1.Text))
            {
                //truyền dữ liệu từ textb1 sang textb2
                TxtNhap2.Text = TxtNhap1.Text;
            }
            else
            {
                //hiển thị thông báo lỗi nếu text1 rỗng
                MessageBox.Show("Vui long nhap du lieu vao textbox 1");
            }
        }

    }
}
