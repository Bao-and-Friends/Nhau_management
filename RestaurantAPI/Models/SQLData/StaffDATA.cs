using System;
using System.Data;

namespace RestaurantAPI.Models.SQLData
{
    public class StaffDATA
    {
        public StaffDATA() { }
        public string MaNV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTimeOffset NgaySinh { get; set; } = DateTimeOffset.MinValue;
        public string GioiTinh { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public string VaiTro { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;


    }
}