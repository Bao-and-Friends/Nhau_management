using System;

namespace RestaurantShared.Models.SQLData
{
    public class StaffDATA
    {
        public StaffDATA() { }
        public int NhanVienID { get; set; } // Khóa chính (INT IDENTITY)
        public int Id { get => NhanVienID; set => NhanVienID = value; } // Alias tương thích với các tầng gọi Id
        public string MaNV { get; set; } = string.Empty; // Mã hiển thị (NV001, NV0001)
        public string HoTen { get; set; } = string.Empty;
        public DateTimeOffset NgaySinh { get; set; } = DateTimeOffset.MinValue;
        public string GioiTinh { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public string VaiTro { get; set; } = string.Empty;
        public string? Email { get; set; }
        public string? TrangThai { get; set; }
    }
}
