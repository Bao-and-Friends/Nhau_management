using System;
using System.Data;

namespace RestaurantShared.Models.SQLData
{
    public class TableDATA
    {
        public TableDATA() { }

        // Khóa chính (Ví dụ: "B01", "VIP02")
        public string MaBan { get; set; } = string.Empty;
        public string TenBan { get; set; } = string.Empty;
        public int SucChua { get; set; } = 0;
        public string TrangThai { get; set; } = "Trống"; // Chuỗi tiếng Việt: 'Trống', 'Có Khách', 'Đã Đặt', 'Chờ Dọn'
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
