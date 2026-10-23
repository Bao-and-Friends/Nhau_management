using RestaurantSever;
using RestaurantSever.Network;
using System;

public class Program
{
    static void Main(string[] args)
    {
        // 1. Khởi động Server và chạy luồng chờ Client kết nối
        TcpSever.Instance.StartSever();

        Console.WriteLine("Đang chờ nhân viên kết nối...");

        // Tạm dừng một nhịp nhỏ hoặc đợi đến khi client kết nối thành công 
        // (Trong thực tế bạn có thể viết cơ chế chờ hoặc sự kiện, đây viết đơn giản để test)
        System.Threading.Thread.Sleep(2000);

        Console.WriteLine("Bắt đầu vòng lặp lắng nghe dữ liệu từ Client...");

        // 2. Vòng lặp liên tục nhận dữ liệu
        while (true)
        {
            // Gọi hàm nhận dữ liệu kiểu int (hoặc kiểu Object khác tùy bạn)
            int? data = TcpSever.Instance.Receive<int>();

            // Nếu nhận được dữ liệu hợp lệ từ client
            if (data != null)
            {
                Console.WriteLine($"Đã nhận được dữ liệu: {data}");
            }
            else
            {
                // Nếu data == null nghĩa là client có thể đã ngắt kết nối hoặc tạm thời chưa gửi
                System.Threading.Thread.Sleep(100); // Nghỉ ngắn tránh chiếm 100% CPU
            }
        }
    }
}