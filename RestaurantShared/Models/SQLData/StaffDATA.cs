using System;
using System.Data;

namespace RestaurantShared.Models.SQLData
{
    public class StaffDATA
    {
        public StaffDATA() { }
        public int Id { get; set; } // Khóa chính nội bộ (INT)
        public string MaNV { get; set; } = string.Empty; // Mã hiển thị (NV0001)
        public string HoTen { get; set; } = string.Empty;
        public DateTimeOffset NgaySinh { get; set; } = DateTimeOffset.MinValue;
        public string GioiTinh { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public string VaiTro { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;
    }
}
