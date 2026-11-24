using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantShared.Models.SQLData
{
    public class OrderDATA
    {
        public OrderDATA() { }
        public string TenMon { get; set; } = string.Empty;
        public float DonGia { get; set; }
        public string DonViTinh { get; set; } = string.Empty;
        public string TenDanhMuc { get; set; } = string.Empty;
        public string MoTa { get; set; } = string.Empty;
    }
}
