using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantShared.DTO
{
    public class RegisterRequest
    {
        public string MaTK { get; set; } = string.Empty;
        public string MaNV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public string GioiTinh { get; set; } = string.Empty;
        public string VaiTro { get; set; } = string.Empty;
        public DateTime? NgaySinh { get; set; }
        public string SDT { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
