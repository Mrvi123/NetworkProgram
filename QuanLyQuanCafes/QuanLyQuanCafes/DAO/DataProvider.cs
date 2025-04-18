using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafes.DAO
{
  /*  public partial class DataProvider : Form
    {
        public  DataProvider()
        {
            InitializeComponent();
        }

        private void DataProvider_Load(object sender, EventArgs e)
        {

        }
    }*/
    public class DataProvidera
    {
        private string connectionSTR = "Data Source=.\\sqlexpress;Initial Catalog = QuanLyQuanCafes;Integrated Security=True";//Tùy nếu khắc phục được lỗi không thể kết nối với SQL Sever thì tính sau
        // có gì thì coi lại video trong link sau và làm lại chỗ này: https://youtu.be/buwTuw8ByP4?si=ynXvd9jQNBH4Zx4t
        public int ExcuteNonQuery(string query, object[] parameter = null)
        {
            int data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
            connection.Open();

            SqlCommand command  = new SqlCommand(query, connection);

            if(parameter != null )
                {
                    string[] listPara = query.Split(',');
                    int i = 0;
                    foreach(string item in listPara) 
                    {
                        if (item.Contains('@')) 
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteNonQuery();

            connection.Close();
            }

              

            return data;
        }

        public object ExcuteNonScalar(string query, object[] parameter = null)
        {
            object data = 0;

            using (SqlConnection connection = new SqlConnection(connectionSTR))
            {
                connection.Open();

                SqlCommand command = new SqlCommand(query, connection);

                if (parameter != null)
                {
                    string[] listPara = query.Split(',');
                    int i = 0;
                    foreach (string item in listPara)
                    {
                        if (item.Contains('@'))
                        {
                            command.Parameters.AddWithValue(item, parameter[i]);
                            i++;
                        }
                    }
                }

                data = command.ExecuteScalar();

                connection.Close();
            }



            return data;
        }
    }
}
