using System.Net.Sockets;
using System.Text;
using System.IO;
using System;

namespace User_Account_Managemet_Client
{
    internal class Program
    {
            //Console.WriteLine("Hello, World!");
        private static string serverIp = "127.0.0.1";
        private static int serverPort = 8888;

        static void Main(string[] args)
        {
            Console.WriteLine("User Management Client");
            Console.WriteLine($"Connecting to server at {serverIp}:{serverPort}");

            bool running = true;

            while (running)
            {
                ShowMenu();
                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        Login();
                        break;
                    case "3":
                        ChangePassword();
                        break;
                    case "4":
                        DeleteAccount();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Exiting...");
                        break;
                    default:

                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                if (running)
                {
                    Console.WriteLine("\nPress any key to continue...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }

        private static void ShowMenu()
        {
            Console.WriteLine("\n===== User Management System =====");
            Console.WriteLine("1. Register a new account");
            Console.WriteLine("2. Login");
            Console.WriteLine("3. Change password");
            Console.WriteLine("4. Delete account");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice (1-5): ");
        }

        private static void Register()
        {
            Console.WriteLine("\n--- Register a new account ---");

            Console.Write("Enter username: ");
            string? username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = ReadPassword();

            //Mã hóa mật khẩu trước khi gửi lên server
            string hashedPassword = HashPassword(password);//tạo hàm HashPassword
            string command = $"REGISTER|{username}|{password}";
            string response = SendCommandToServer(command);

            DisplayResponse(response);
        }

        private static void Login()
        {
            Console.WriteLine("\n--- Login ---");

            Console.Write("Enter username: ");
            string? username = Console.ReadLine();

            Console.Write("Enter password: ");
            string? password = ReadPassword();

            //Mã hóa mật khẩu trước khi gửi đến server
            string hashedPassword = HashPassword(password);//Mới cập nhật

            string? command = $"LOGIN|{username}|{password}";
            string  response = SendCommandToServer(command);

            DisplayResponse(response);
        }//Mới cập nhật

        private static void ChangePassword()
        {
            Console.WriteLine("\n--- Change Password ---");

            Console.Write("Enter username: ");
            string? username = Console.ReadLine();

            Console.Write("Enter current password: ");
            string currentPassword = ReadPassword();

            Console.Write("Enter new password: ");
            string newPassword = ReadPassword();

            string command = $"CHANGEPASSWORD|{username}|{currentPassword}|{newPassword}";
            string response = SendCommandToServer(command);

            DisplayResponse(response);
        }

        private static string HashPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                foreach (byte b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }

                return builder.ToString();
            }
        }//Mới tạo chưa test

   /*     private static string HandleRegister(string username, string hashedPassword)
        {
            if (userAccounts.ContainsKey(username))
            {
                return "Username already exists";
            }

            userAccounts[username]= hashedPassword;
            return "Registration successful";
        }*/

        private static void DeleteAccount()
        {
            Console.WriteLine("\n--- Delete Account ---");

            Console.Write("Enter username: ");
            string? username = Console.ReadLine();

            Console.Write("Enter password: ");
            string password = ReadPassword();

            Console.Write("Are you sure you want to delete your account? (y/n): ");
            if (Console.ReadLine()?.ToLower() != "y")
            {
                Console.WriteLine("Account deletion cancelled.");
                return;
            }

            string command = $"DELETEACCOUNT|{username}|{password}";
            string response = SendCommandToServer(command);

            DisplayResponse(response);
        }

        private static string SendCommandToServer(string command)
        {
            try
            {
                // Create TCP client and connect to server
                using (TcpClient client = new TcpClient(serverIp, serverPort))
                {
                    using (NetworkStream stream = client.GetStream())
                    {
                        // Send command to server
                        byte[] data = Encoding.ASCII.GetBytes(command);
                        stream.Write(data, 0, data.Length);

                        // Receive response from server
                        byte[] responseBuffer = new byte[1024];
                        int bytesRead = stream.Read(responseBuffer, 0, responseBuffer.Length);
                        string response = Encoding.ASCII.GetString(responseBuffer, 0, bytesRead);

                        return response;
                    }
                }
            }
            catch (Exception ex)
            {
                return $"ERROR|Connection error: {ex.Message}";
            }
        }

        private static void DisplayResponse(string response)
        {
            string[] parts = response.Split('|');

            if (parts.Length >= 2)
            {
                string status = parts[0];
                string message = parts[1];

                if (status == "SUCCESS")
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Success: {message}");
                }
                else if (status == "ERROR")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Error: {message}");
                }
                else
                {
                    Console.WriteLine(response);
                }

                Console.ResetColor();
            }
            else
            {
                Console.WriteLine(response);
            }
        }

        private static string ReadPassword()
        {
            StringBuilder password = new StringBuilder();
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(true);

                // Ignore control keys like Backspace
                if (key.Key != ConsoleKey.Backspace && key.Key != ConsoleKey.Enter)
                {
                    password.Append(key.KeyChar);
                    Console.Write("*");
                }
                else if (key.Key == ConsoleKey.Backspace && password.Length > 0)
                {
                    password.Remove(password.Length - 1, 1);
                    Console.Write("\b \b");
                }
            }
            while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return password.ToString();
        }
    }
}

