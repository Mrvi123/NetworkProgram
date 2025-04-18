using System;
using System.Net.Http.Headers;
using System.Threading;
using System.Threading.Tasks;

class Abort
{
    static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        //Tạo một CancellationTokenSource
        CancellationTokenSource cts = new CancellationTokenSource();//phải khai báo cts với new CancellationTokenSource chứ không phải CancellationToken
        CancellationToken token = cts.Token;

        //Chạy một luồng công việc trong Tasks
        Task task = Task.Run(() => {
            while (!token.IsCancellationRequested)
            {
                Console.WriteLine("Luồng đang chạy...");
                Thread.Sleep(500);
            }
            Console.WriteLine("Luồng đã bị dừng...");
        },token);

        //Đợi một chút trước khi luồng được hủy
        Thread.Sleep(2000);
        Console.WriteLine("Yêu cầu dừng luồng...");
        cts.Cancel();//Yêu cầu hủy luồng

        //Đợi task hoàn tất
        task.Wait();
        Console.WriteLine("Chương trình kết thúc");
    }
}
//Không hỗ trợ phương thức Abort vì xảy ra vì trong các phiên bản .NET hiện đại (bao gồm .NET Core, .NET 5/6/7), phương thức Thread.Abort() không còn được hỗ trợ.
//cách khắc phục là lui về phiên bản cũ hơn của .NET, pb .NET.Framework 4.8
//hoặc dùng CancellationToken để hủy luồng
//using System;
//using System.Threading;

//class Abort
//{
//    static void Main()
//    {
//        Console.OutputEncoding = System.Text.Encoding.UTF8;
//        // Tạo một luồng mới
//        Thread thread = new Thread(DoWork);

//        // Bắt đầu luồng
//        thread.Start();

//        // Đợi một chút trước khi hủy luồng
//        Thread.Sleep(2000);

//        Console.WriteLine("Hủy luồng...");
//        thread.Abort(); // Yêu cầu hủy luồng

//        Console.WriteLine("Luồng đã được hủy.");
//    }

//    static void DoWork()
//    {
//        try
//        {
//            while (true)
//            {
//                Console.WriteLine("Luồng đang chạy...");
//                Thread.Sleep(500); // Giả lập công việc
//            }
//        }
//        catch (ThreadAbortException e)
//        {
//            Console.WriteLine("ThreadAbortException: Luồng bị hủy.");
//        }
//        finally
//        {
//            Console.WriteLine("Khối finally được thực thi.");
//        }
//    }
//}

////Error
////Unhandled exception. System.PlatformNotSupportedException: Thread abort is not supported on this platform.
////   at System.Threading.Thread.Abort()
////   at Abort.Main() in C:\Users\LENOVO\source\repos\Abort_method\Abort_method\Abort.cs:line 19
