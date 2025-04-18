using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Abort_method2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            //Tạo và bắt đầu một luồng
            Thread thread = new Thread(DoWork);
            thread.Start();

            //Đợi một chút và hủy luồng
            Thread.Sleep(2000);//sự khác nhau vo với khi dùng thread
            Console.WriteLine("Yêu cầu hủy luồng...");
            thread.Abort();// sự khác nhau so với khi dùng Thread

            //Đợi luồng hoàn tất
            thread.Join();
            Console.WriteLine("Luồng đã bị hủy");
        }


        static void DoWork()
        {
            try
            {
                while (true)
                {
                    Console.WriteLine("Luồng đang chạy");
                    Thread.Sleep(500);
                }
            }
            catch(ThreadAbortException e)
            {
                Console.WriteLine("Ngoại lệ ThreadAbortException: Luồng đã bị hủy", e.Message);
            }
            finally
            {
                Console.WriteLine("Khối finally được thực thi trước khi thoát");
            }
        }
    }
}
