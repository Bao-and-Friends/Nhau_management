using System;

namespace RestaurantShared.Models.SQLData
{
    public class BillDATA
    {
        public BillDATA() { }
        public int HoaDonID { get; set; }
        public string MaHoaDon { get; set; } = string.Empty;
        public int BanID { get; set; }
        public string? MaBan { get; set; }
        public string? TenBan { get; set; }
        public int? NhanVienID { get; set; }
        public string? TenNhanVien { get; set; }
        public int? KhuyenMaiID { get; set; }
        public string? TenKM { get; set; }
        public DateTime ThoiGianVao { get; set; } = DateTime.Now;
        public DateTime? ThoiGianRa { get; set; }
        public decimal TongTienHang { get; set; }
        public decimal PhuThu { get; set; }
        public decimal GiamGia { get; set; }
        public decimal ThueVAT { get; set; }
        public decimal TongThanhToan { get; set; }
        public string TrangThai { get; set; } = "Chưa thanh toán";
        public string? GhiChu { get; set; }
    }
}
