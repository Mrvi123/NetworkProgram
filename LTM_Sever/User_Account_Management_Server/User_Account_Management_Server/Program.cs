using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Security.Cryptography;
using System.Xml.Linq;

namespace User_Account_Management_Server
{
     internal class Program
    {
        //Dictionary to store user accounts (username -> User object)
        private static Dictionary<string, User> users = new Dictionary<string, User>();
        private static string usersFilePath = "C:\\Users\\LENOVO\\OneDrive\\Máy tính\\users.txt";
        private static readonly object fileLock = new object();

        static void Main(string[] args)
        {
            //Console.WriteLine("Hello, World!");
            LoadUsers();

            // Define server port
            int port = 8888;
            TcpListener? server = null;

            try
            {
                //Create TCP listener
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");
                server = new TcpListener(localAddr, port);

                //Start listening for client requests
                server.Start();

                Console.WriteLine("User Management Server started");
                Console.WriteLine($"Listening on {localAddr}:{port}");
                Console.WriteLine("Press Ctrl+C to stop the server");

                //Enter the listening loop
                while (true)
                {
                    Console.WriteLine("Waiting for a connect...");

                    //Perform a blocking call to accept client request
                    TcpClient client = server.AcceptTcpClient();
                    Console.WriteLine("Client connected!");

                    //Create a thread to handle this client
                    #nullable disable //tắt tính năng cảnh báo nullable bằng lệnh nullable disable
                    Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClient));
                    clientThread.Start(client);

                }
            }
            catch (SocketException e)
            {
                Console.WriteLine($"SocketException: {e.Message}");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception: {e.Message}");
            }
            finally
            {
                //Stop listening for new clients
                server?.Stop();
            }

        }

        private static void HandleClient(object obj)
        {
            TcpClient client = (TcpClient)obj;
            NetworkStream stream = client.GetStream();

            byte[] buffer = new byte[1024];
            int bytesRead;

            try
            {
                //Read data sent by the client
                while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) != 0)
                {
                    string dataReceived = Encoding.ASCII.GetString(buffer, 0, bytesRead);
                    Console.WriteLine($"Received: {dataReceived}");

                    // Parse the command and parameters
                    string[] parts = dataReceived.Split('|');
                    string command = parts[0];
                    string response = "";

                    switch (command)
                    {
                        case "REGISTER":
                            if (parts.Length == 3)
                                response = RegisterUser(parts[1], parts[2]);//chú ý hàm này chưa định nghĩa nên ban đầu sẽ báo lỗi, tạo xong hàm thì sẽ hết báo lỗi    
                            else
                                response = "ERROR|Invalid parameters for registration";
                            break;

                        case "LOGIN":
                            if (parts.Length == 3)
                                response = LoginUser(parts[1], parts[2]);// tạo hàm LoginUser
                            else
                                response = "ERROR| Invalid parameters for login";
                            break;

                        case "CHANGEPASSWORD":
                            if (parts.Length == 4)
                                response = ChangePassword(parts[1], parts[2], parts[3]);// tạo hàm ChangePassword
                            else
                                response = "ERROR| Invalid parameters for account deletion ";
                            break;

                        default:
                            response = "ERROR| Unknow command";
                            break;

                    }

                    //Send the response back to the client
                    byte[] responseData = Encoding.ASCII.GetBytes(response);
                    stream.Write(responseData, 0, responseData.Length);
                    Console.WriteLine($"Sent: {response}");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Error handling client: {e.Message}");
            }
            finally
            {
                //Close connection
                stream.Close();
                client.Close();
                Console.WriteLine("Client disconnected");
            }
        }

        private static string HandleRegister(string username, User hashedPassword)//Mới tạo chưa test
        {
            if (users.ContainsKey(username))
            {
                return "Username already exists";
            }

            users[username] = hashedPassword;
            return "Registration successful";

        }

        private static string HandleLogin(string username, User hashedPassword) 
        {
            if(users.ContainsKey(username) && users[username] == hashedPassword)
            {
                return "Login successful";
            }

            return "Login failed";
        }


        private static string RegisterUser(string username, string password)
        {
            lock (users)
            {
                if (users.ContainsKey(username))
                {
                    return "ERROR| Username already exists";
                }

                // Hash the password
                string hashedPassword = HashPassword(password);

                //Create new user
                User newUser = new User(username, hashedPassword)//tự động gán user và password
                {
                    Username = "Viabc",//phải gán trục tiếp để kiểm tra
                    PasswordHash = "123"//phải gán trực tiếp để kiểm tra nếu ko thì "Invalid username or password"
                };

                //Add to dictionary
                users.Add(username, newUser);

                //Save to file
                SaveUsers();

                return "SUCESS|  Registration successful";
            }
        }

        private static string LoginUser(string username, string password)
        {
            lock (users)
            {
                if (!users.ContainsKey(username))
                {
                    return "ERROR| Invalid username or password ";
                }

                User user = users[username];
                string hashedPassword = HashPassword(password);

                if(user.PasswordHash != hashedPassword)
                {
                    return "SUCCESS | Login successful";
                }
                else
                {
                    return "ERROR | Invalid username or password";
                }
            }
        }

        private static string ChangePassword(string username, string oldPassword, string newPassword)
        {
            lock (users)
            {
                if (!users.ContainsKey(username))
                {
                    return "ERROR | User not found";
                }

                User user = users[username];
                string hashedOldPassword = HashPassword(oldPassword);
                if(user.PasswordHash != hashedOldPassword)
                {
                    return "ERROR | Current password is incorrect";
                }

                //Update password
                user.PasswordHash = HashPassword(newPassword);

                //Save changes
                SaveUsers();

                return "SUCCESS |Password changed successfully ";
            }
        }

        private static string DeleteAccount(string username, string password)
        {
            lock (users)
            {
                if (!users.ContainsKey(username))
                {
                    return "ERROR| Password is incorrect";
                }

                User user = users[username];
                string hashedPassword = HashPassword(password);

                if(user.PasswordHash != hashedPassword)
                {
                    return "ERROR | Password is incorrect";
                }

                //Remove user
                users.Remove(username);

                // Save changes
                SaveUsers();
                return "SUCCESS | Account deleted successfully";
            }
        }

        private static string HashPassword(string password)
        {
            using(SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));

                StringBuilder builder = new StringBuilder();
                for (int i = 0; i<bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
            
        }

        private static void SaveUsers()



        {
            lock (fileLock)
            {
                try
                {
                    using (StreamWriter writer = new StreamWriter(usersFilePath))
                    {
                        foreach (var user in users.Values)
                        {
                            writer.WriteLine($"{user.Username} | {user.PasswordHash}");
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error saving users:{ex.Message}");
                }
            }
        }

        private static void LoadUsers()
        {
            lock (fileLock)
            {
                try
                {
                    if (File.Exists(usersFilePath))
                    {
                        string[] lines = File.ReadAllLines(usersFilePath);
                        foreach (string line in lines)
                        {
                            string[] parts = line.Split('|');
                            if (parts.Length == 2)
                            {
                                User user = new User("Vi", "123")//tạo đây để đối chiếu mới username và password đã đăng ký
                                {
                                    Username = parts[0],
                                    PasswordHash = parts[1]
                                };

                                users[user.Username] = user;


                            }
                        }

                        Console.WriteLine($"Loaded{users.Count} user(s) from file");
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine($"Error loading users: {ex.Message}");
                }
            }
        }
    }

    class User
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }

        //Constructor
        public User(string username,string passwordHash)
        {
            Username = username;
            PasswordHash = passwordHash;
        }

        //Tạo đối tượng với constructor
        //User user = new User("Vi", "123");
    }

}
