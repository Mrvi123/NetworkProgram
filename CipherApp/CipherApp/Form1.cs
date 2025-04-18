using System;
using System.Collections.Generic;
using System.Windows.Forms;

public class Form1 : Form
{
    private TextBox inputTextBox, keyTextBox, outputTextBox;
    private Button encryptButton, decryptButton, loadFileButton;
    private ComboBox cipherTypeComboBox;

    public Form1()
    {
        this.Text = "Cipher Application";
        this.Size = new System.Drawing.Size(400, 300);

        Label cipherLabel = new Label() { Text = "Chọn hệ mã hóa:", Top = 20, Left = 20 };
        cipherTypeComboBox = new ComboBox() { Top = 20, Left = 150, Width = 200 };
        cipherTypeComboBox.Items.AddRange(new string[] { "Caesar", "PlayFair", "Rail Fence" });

        Label keyLabel = new Label() { Text = "Khóa:", Top = 60, Left = 20 };
        keyTextBox = new TextBox() { Top = 60, Left = 150, Width = 200 };

        Label inputLabel = new Label() { Text = "Thông điệp:", Top = 100, Left = 20 };
        inputTextBox = new TextBox() { Top = 100, Left = 150, Width = 200 };

        Label outputLabel = new Label() { Text = "Kết quả:", Top = 140, Left = 20 };
        outputTextBox = new TextBox() { Top = 140, Left = 150, Width = 200, ReadOnly = true };

        encryptButton = new Button() { Text = "Mã hóa", Top = 180, Left = 50 };
        decryptButton = new Button() { Text = "Giải mã", Top = 180, Left = 150 };
        loadFileButton = new Button() { Text = "Tải từ file", Top = 180, Left = 250 };

        encryptButton.Click += (sender, e) => ProcessCipher(true);
        decryptButton.Click += (sender, e) => ProcessCipher(false);
        loadFileButton.Click += (sender, e) => LoadFromFile();

        this.Controls.Add(cipherLabel);
        this.Controls.Add(cipherTypeComboBox);
        this.Controls.Add(keyLabel);
        this.Controls.Add(keyTextBox);
        this.Controls.Add(inputLabel);
        this.Controls.Add(inputTextBox);
        this.Controls.Add(outputLabel);
        this.Controls.Add(outputTextBox);
        this.Controls.Add(encryptButton);
        this.Controls.Add(decryptButton);
        this.Controls.Add(loadFileButton);
    }

    private class PlayFairCipher
    {
        private char[,] matrix;

        public PlayFairCipher(string key)
        {
            matrix = GenerateMatrix(key);
        }

        private char[,] GenerateMatrix(string key)
        {
            string fullKey = key.ToUpper() + "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            HashSet<char> used = new HashSet<char>();
            char[,] mat = new char[5, 5];
            int index = 0;

            for (int i = 0; i < fullKey.Length; i++)
            {
                char ch = fullKey[i];
                if (ch == 'J') ch = 'I';
                if (!used.Contains(ch))
                {
                    mat[index / 5, index % 5] = ch;
                    used.Add(ch);
                    index++;
                }
            }
            return mat;
        }

        private (int, int) FindPosition(char ch)
        {
            if (ch == 'J') ch = 'I';
            for (int i = 0; i < 5; i++)
                for (int j = 0; j < 5; j++)
                    if (matrix[i, j] == ch)
                        return (i, j);
            return (-1, -1);
        }

        private string ProcessMessage(string message, bool encrypt)
        {
            message = message.ToUpper().Replace("J", "I").Replace(" ", "");
            List<char> processedMessage = new List<char>();

            for (int i = 0; i < message.Length; i++)
            {
                processedMessage.Add(message[i]);
                if (i < message.Length - 1 && message[i] == message[i + 1])
                    processedMessage.Add('X');
            }
            if (processedMessage.Count % 2 != 0)
                processedMessage.Add('X');

            string result = "";
            for (int i = 0; i < processedMessage.Count; i += 2)
            {
                var (r1, c1) = FindPosition(processedMessage[i]);
                var (r2, c2) = FindPosition(processedMessage[i + 1]);

                if (r1 == r2)
                {
                    result += matrix[r1, (c1 + (encrypt ? 1 : 4)) % 5];
                    result += matrix[r2, (c2 + (encrypt ? 1 : 4)) % 5];
                }
                else if (c1 == c2)
                {
                    result += matrix[(r1 + (encrypt ? 1 : 4)) % 5, c1];
                    result += matrix[(r2 + (encrypt ? 1 : 4)) % 5, c2];
                }
                else
                {
                    result += matrix[r1, c2];
                    result += matrix[r2, c1];
                }
            }
            return result;
        }

        public string Encrypt(string message)
        {
            return ProcessMessage(message, true);
        }

        public string Decrypt(string cipherText)
        {
            return ProcessMessage(cipherText, false);
        }
    }
    private void ProcessCipher(bool encrypt)
    {
        string? cipherType = cipherTypeComboBox.SelectedItem?.ToString();
        string key = keyTextBox.Text;
        string input = inputTextBox.Text;
        string output = "";

        if (cipherType == "Caesar")
        {
            if (!int.TryParse(key, out int shift))
            {
                MessageBox.Show("Khóa phải là số nguyên.");
                return;
            }
            output = encrypt ? CaesarEncrypt(input, shift) : CaesarDecrypt(input, shift);
        }
        else if (cipherType == "PlayFair")
        {
            PlayFairCipher cipher = new PlayFairCipher(key);
            output = encrypt ? cipher.Encrypt(input) : cipher.Decrypt(input);
        }
        else if (cipherType == "Rail Fence")
        {
            if (!int.TryParse(key, out int height))
            {
                MessageBox.Show("Khóa phải là số nguyên.");
                return;
            }
            output = encrypt ? RailFenceEncrypt(input, height) : RailFenceDecrypt(input, height);
        }

        outputTextBox.Text = output;
    }

    private void LoadFromFile()
    {
        OpenFileDialog openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            inputTextBox.Text = System.IO.File.ReadAllText(openFileDialog.FileName);
        }
    }

    private string CaesarEncrypt(string message, int key)
    {
        string result = "";
        foreach (char ch in message)
        {
            if (char.IsLetter(ch))
            {
                char offset = char.IsUpper(ch) ? 'A' : 'a';
                result += (char)(((ch + key - offset) % 26) + offset);
            }
            else
            {
                result += ch;
            }
        }
        return result;
    }

    private string CaesarDecrypt(string cipherText, int key)
    {
        return CaesarEncrypt(cipherText, 26 - key);
    }

    private string RailFenceEncrypt(string message, int height)
    {
        if (height <= 1) return message;
        char[,] rail = new char[height, message.Length];
        bool down = false;
        int row = 0;
        for (int i = 0; i < message.Length; i++)
        {
            if (row == 0 || row == height - 1)
                down = !down;
            rail[row, i] = message[i];
            row += down ? 1 : -1;
        }
        string result = "";
        for (int i = 0; i < height; i++)
            for (int j = 0; j < message.Length; j++)
                if (rail[i, j] != '\0')
                    result += rail[i, j];
        return result;
    }

    private string RailFenceDecrypt(string cipherText, int height)
    {
        if (height <= 1) return cipherText;
        char[,] rail = new char[height, cipherText.Length];
        bool down = false;
        int row = 0, index = 0;
        for (int i = 0; i < cipherText.Length; i++)
        {
            if (row == 0 || row == height - 1)
                down = !down;
            rail[row, i] = '*';
            row += down ? 1 : -1;
        }
        for (int i = 0; i < height; i++)
            for (int j = 0; j < cipherText.Length; j++)
                if (rail[i, j] == '*' && index < cipherText.Length)
                    rail[i, j] = cipherText[index++];
        string result = "";
        row = 0;
        down = false;
        for (int i = 0; i < cipherText.Length; i++)
        {
            if (row == 0 || row == height - 1)
                down = !down;
            result += rail[row, i];
            row += down ? 1 : -1;
        }
        return result;
    }

    //[STAThread]
    public static void main(string []args)
    {
        Application.EnableVisualStyles();
        Application.Run(new Form1());
    }
}

//public class PlayFairCipher
//{
//    private char[,] matrix;

//    public PlayFairCipher(string key)
//    {
//        matrix = GenerateMatrix(key);
//    }

//    private char[,] GenerateMatrix(string key)
//    {
//        string fullKey = key.ToUpper() + "ABCDEFGHIKLMNOPQRSTUVWXYZ";
//        HashSet<char> used = new HashSet<char>();
//        char[,] mat = new char[5, 5];
//        int index = 0;

//        for (int i = 0; i < fullKey.Length; i++)
//        {
//            char ch = fullKey[i];
//            if (ch == 'J') ch = 'I';
//            if (!used.Contains(ch))
//            {
//                mat[index / 5, index % 5] = ch;
//                used.Add(ch);
//                index++;
//            }
//        }
//        return mat;
//    }

//    private (int, int) FindPosition(char ch)
//    {
//        if (ch == 'J') ch = 'I';
//        for (int i = 0; i < 5; i++)
//            for (int j = 0; j < 5; j++)
//                if (matrix[i, j] == ch)
//                    return (i, j);
//        return (-1, -1);
//    }

//    private string ProcessMessage(string message, bool encrypt)
//    {
//        message = message.ToUpper().Replace("J", "I").Replace(" ", "");
//        List<char> processedMessage = new List<char>();

//        for (int i = 0; i < message.Length; i++)
//        {
//            processedMessage.Add(message[i]);
//            if (i < message.Length - 1 && message[i] == message[i + 1])
//                processedMessage.Add('X');
//        }
//        if (processedMessage.Count % 2 != 0)
//            processedMessage.Add('X');

//        string result = "";
//        for (int i = 0; i < processedMessage.Count; i += 2)
//        {
//            var (r1, c1) = FindPosition(processedMessage[i]);
//            var (r2, c2) = FindPosition(processedMessage[i + 1]);

//            if (r1 == r2)
//            {
//                result += matrix[r1, (c1 + (encrypt ? 1 : 4)) % 5];
//                result += matrix[r2, (c2 + (encrypt ? 1 : 4)) % 5];
//            }
//            else if (c1 == c2)
//            {
//                result += matrix[(r1 + (encrypt ? 1 : 4)) % 5, c1];
//                result += matrix[(r2 + (encrypt ? 1 : 4)) % 5, c2];
//            }
//            else
//            {
//                result += matrix[r1, c2];
//                result += matrix[r2, c1];
//            }
//        }
//        return result;
//    }

//    public string Encrypt(string message)
//    {
//        return ProcessMessage(message, true);
//    }

//    public string Decrypt(string cipherText)
//    {
//        return ProcessMessage(cipherText, false);
//    }
//}

