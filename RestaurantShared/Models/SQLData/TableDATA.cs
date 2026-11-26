using System;

namespace RestaurantShared.Models.SQLData
{
    public class TableDATA
    {
        public TableDATA() { }

        public int BanID { get; set; }
        public string MaBan { get; set; } = string.Empty;
        public string TenBan { get; set; } = string.Empty;
        public int SucChua { get; set; } = 0;
        public string TrangThai { get; set; } = "Trống"; // 'Trống', 'Có Khách', 'Đã Đặt', 'Chờ Dọn'
        public DateTime? CheckIn { get; set; }
        public DateTime? CheckOut { get; set; }
    }
}
