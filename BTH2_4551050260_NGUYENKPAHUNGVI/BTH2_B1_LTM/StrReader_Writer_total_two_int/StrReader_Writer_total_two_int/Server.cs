// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;
using System.Data.SqlTypes;
using System.IO;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Net.WebSockets;
using System.Threading.Tasks;

namespace TcpCalculator
{
    class Server
    {
        static async Task Main(string[] args)
        {
            //Server configuration
            int port = 8888;
            IPAddress ipAddress = IPAddress.Any;

            Console.WriteLine("Calculator Server");//tính toán từ server

            //Create TCP listener
            TcpListener listener = new TcpListener(ipAddress, port);

            try
            {
                listener.Start();//khi tcp bắt đầu việc lắng nghe
                Console.WriteLine($"Server started. Listening on port {port}");//thì sẽ hiển thị thông báo đang lắng nghe trên cổng 8888
                while (true) {
                    //Wait for client connection
                    TcpClient client = await listener.AcceptTcpClientAsync();//tạo một biến client có kiểu TcpClient dùng để kết nối với máy khách
                    IPEndPoint? remoteEndPoint = client.Client.RemoteEndPoint as IPEndPoint;
                    if(remoteEndPoint != null)
                    {
                        Console.WriteLine($"Client connected: {remoteEndPoint.Address}");
                        //Console.WriteLine($"Client connected: {((IPEndPoint)client.Client.RemoteEndPoint as IPEndPoint)?.Address}");//CS8600 Converting null literal or possible null value to non - nullable type.StrReader_Writer_total_two_int
                    }
                    else
                    {
                        Console.WriteLine("Failed to get remote endpoint.");
                    }
                    


                    //Handle client request in a separate task
                    _ = Task.Run(() =>HandleClientAsync(client));//phương thức HandleClientAsync chưa được khởi tạo vì vậy sai cũng bình thường cách khắc phục là khởi tạo một phương thức mang tên HandleClientAsync
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Server error: {ex.Message}");
            }
            finally
            {
                listener.Stop();
            }
        }

        //hàm xử lý từ phía Client dùng để trả về các Task không đồng bộ
        static async Task HandleClientAsync(TcpClient client)
        {
            try
            {
                using (client)
                using (NetworkStream networkStream = client.GetStream())
                using (StreamReader reader = new StreamReader(networkStream))
                using (StreamWriter writer = new StreamWriter(networkStream) { AutoFlush = true })
                {
                    //Read the expression from client
                    string? expression = await reader.ReadLineAsync();
                    if (expression == null)
                    {
                        await writer.WriteLineAsync("ERROR: No input received");
                        return;
                    }
                     Console.WriteLine($"Received: {expression}");


                    //Parse expression
                    string[] parts = expression.Split(' ');//chỗ đây sẽ warnings nếu không tạo điều kiện kiểm tra phía trên
                    if (parts.Length != 3)
                    {
                        await writer.WriteLineAsync("ERROR: Invalid format. Use: number operator number");
                        return;
                    }
                    if (!int.TryParse(parts[0], out int num1) || !int.TryParse(parts[2], out int num2))//đặt câu hỏi tại sao dùng !int mà không dùng int.TryParse
                    {
                        await writer.WriteLineAsync("ERROR: Invailid numbers");
                        return;
                    }

                    string op = parts[1];
                    double result;

                    //Perform calculation
                    switch (op)
                    {
                        case "+":
                            result = num1 + num2;
                            break;
                        case "-":
                            result = num2 - num1;
                            break;
                        case "*":
                            result = num1 * num2;
                            break;
                        case "/":
                            //result = num2 * num1;
                            if(num2 == 0)
                            {
                                await writer.WriteLineAsync("ERROR: Division by zero");
                                return;
                            }
                            result = (double)num1 / num2;
                            break;
                        default:
                            await writer.WriteLineAsync("ERROR: Invalid operator. Use +, -, *, /");
                            return;
                    }

                    //Send result back to client
                    string resultString = result.ToString();
                    await writer.WriteLineAsync(resultString);
                    Console.WriteLine($"Sent result:{resultString}");
                }


            }
            catch (Exception ex) {
                Console.WriteLine($"Error handling client:{ex.Message}");
            }
        }
    }
}
