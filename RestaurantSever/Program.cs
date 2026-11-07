using RestaurantSever;
using RestaurantSever.Network;
using System;
using System.Text;

public class Program
{
    static void Main(string[] args)
    {
        RestaurantShared.AppConfig.Instance.Load();
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;
        // 1. Khởi động Server và chạy luồng chờ Client kết nối
        TcpServer.Instance.StartServer();

        Console.WriteLine("Đang chờ nhân viên kết nối...");

        Console.ReadLine();



    }
}