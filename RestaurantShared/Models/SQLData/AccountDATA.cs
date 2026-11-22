using System;
using System.Data;

namespace RestaurantShared.Models.SQLData
{
    public class AccountDATA
    {
        public AccountDATA() { }
        public int Id { get; set; }
        public int NVId { get; set; } // Khóa ngoại INT liên kết sang NHANVIEN(Id)
        public string TenDangNhap { get; set; } = string.Empty;
        public string MatKhau { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public string Email { get; set; } = string.Empty;
    }
}
