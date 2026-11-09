using System;
using System.Data;

namespace RestaurantShared.Models.SQLData
{
    public class AccountDATA
    {
        public AccountDATA() { }
        public string MaNV { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public string Email { get; set; } = string.Empty;
    }
}