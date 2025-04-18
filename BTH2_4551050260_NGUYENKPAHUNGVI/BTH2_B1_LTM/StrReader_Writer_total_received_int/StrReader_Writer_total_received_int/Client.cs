// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
// Error: No such host is known. xảy ra khi chạy lần đầu tiên

using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Transactions;

namespace TcpCalculator
{
    class Client
    {
        static async Task Main(string[] args)
        {
            //Client Configuration
            string serverIP = "127.0.0.1";
            int port = 8888;

            Console.WriteLine("Calculator Client");

            //Get server IP
            Console.WriteLine("Enter server IP (default 127.0.0.1): ");
            string? userInput = Console.ReadLine();//giá trị không phải nullable tuy nhiên nên đặt dấu ? để xác định đây là nguồn dữ liệu sẽ nhập vào mà không có null
            if (!string.IsNullOrEmpty(userInput))
            {
                serverIP = userInput;
            }
            try
            {
                using (TcpClient client = new TcpClient())
                {
                    //Connect to the server
                    Console.WriteLine($"Connecting to server {serverIP}:{port}...");
                    await client.ConnectAsync(serverIP, port);
                    Console.WriteLine("Connected to server!");

                    using (NetworkStream networkStream = client.GetStream())
                    using (StreamReader reader = new StreamReader(networkStream))
                    using (StreamWriter writer = new StreamWriter(networkStream) { AutoFlush = true })
                    {
                        while (true)
                        {
                            //Get first number
                            Console.WriteLine("Enter first number(or 'exit' to quit: )");
                            string? input1 = Console.ReadLine();//giá trị không phải nullable tuy nhiên nên đặt dấu ? để xác định đây là nguồn dữ liệu sẽ nhập vào mà không có null

                            if (input1?.ToLower() == "exit")////input có thể null nên cách khắc phục bằng việc thêm ? sau input1 giá trị không phải nullable tuy nhiên nên đặt dấu ? để xác định đây là nguồn dữ liệu sẽ nhập vào mà không có null
                                break;
                            if (!int.TryParse(input1, out _))
                            {
                                Console.WriteLine("Invalid number. Please try again.");
                                continue;
                            }

                            // Get operator
                            Console.Write("Enter operator (+, -, *, /): ");
                            string? op = Console.ReadLine();//giá trị không phải nullable tuy nhiên nên đặt dấu ? để xác định đây là nguồn dữ liệu sẽ nhập vào mà không có null

                            if (op != "+" && op != "-" && op != "*" && op != "/")
                            {
                                Console.WriteLine("Invalid operator. Please try again.");
                                continue;
                            }

                            //Get second number
                            Console.Write("Enter second number: ");
                            string? input2 = Console.ReadLine();//đặt câu hỏi tại sao lại dùng ReadLine mà không phải ReadKey, hay Read
                            //giá trị không phải nullable tuy nhiên nên đặt dấu ? để xác định đây là nguồn dữ liệu sẽ nhập vào mà không có null
                            if (!int.TryParse(input2, out _))
                            {
                                Console.WriteLine("Invalid number. Please try again.");
                                continue;
                            }

                            // Send expression to server
                            string expression = $"{input1} {op} {input2}";
                            await writer.WriteLineAsync(expression);
                            {
                                Console.WriteLine("Sending: " + expression);

                                //Receive result from server
                                string result = await reader.ReadToEndAsync();
                                if (result.StartsWith("ERROR:"))
                                {
                                    Console.WriteLine(result);
                                }
                                else
                                {
                                    Console.WriteLine($"Result: {input1} {op} {input2}");
                                }

                                Console.WriteLine();
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();//Chờ người dùng nhấn phím
        }
    }
}
