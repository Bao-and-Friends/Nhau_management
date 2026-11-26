namespace RestaurantShared.Models.SQLData
{
    public class OrderDATA
    {
        public OrderDATA() { }
        public int MonID { get; set; }
        public string MaMon { get; set; } = string.Empty;
        public string TenMon { get; set; } = string.Empty;
        public decimal DonGia { get; set; }
        public string DonViTinh { get; set; } = string.Empty;
        public string TenDanhMuc { get; set; } = string.Empty;
        public string MoTa { get; set; } = string.Empty;
        public string? TrangThai { get; set; }
    }
}
