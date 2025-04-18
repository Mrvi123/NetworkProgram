// See https://aka.ms/new-console-template for more information
using System;
using System.Net;
using System.Net.Sockets;

class Program
{
    static void Main()
    {
        Console.WriteLine("Nhap dia chi ip: ");
        string input = Console.ReadLine();

        IPAddress address;
        if (IPAddress.TryParse(input, out address))
        {
            switch (address.AddressFamily)
            {
                case AddressFamily.InterNetwork:
                    Console.WriteLine("Day la dia chi ipV4");
                    break;
                case AddressFamily.InterNetworkV6:
                    Console.WriteLine("Day la dia chi ipV6");
                    break;
            }
        }
        else Console.WriteLine("Dia chi ip khong hop le");
    }
}