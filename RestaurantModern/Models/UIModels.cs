namespace RestaurantModern.Models;

public class NavigationItem
{
    public string Title { get; set; } = string.Empty;
    public string Tag { get; set; } = string.Empty;
    public string Icon { get; set; } = "📌";
    public string Subtitle { get; set; } = string.Empty;
}

public class TableItem
{
    public int BanID { get; set; }
    public string MaBan { get; set; } = string.Empty;
    public string TenBan { get; set; } = string.Empty;
    public int SucChua { get; set; } = 4;
    public string TrangThai { get; set; } = "Trống";
    public string KhuVuc { get; set; } = "Tầng 1";
    public DateTime? CheckIn { get; set; }
    public decimal TongTienTamTinh { get; set; }

    public string StatusBadgeColor => TrangThai switch
    {
        "Có Khách" => "#F97316",
        "Đã Đặt" => "#2563EB",
        "Chờ Dọn" => "#64748B",
        _ => "#16A34A"
    };

    public string StatusBadgeBackground => TrangThai switch
    {
        "Có Khách" => "#FFEDD5",
        "Đã Đặt" => "#DBEAFE",
        "Chờ Dọn" => "#F1F5F9",
        _ => "#DCFCE7"
    };

    public string StatusIcon => TrangThai switch
    {
        "Có Khách" => "👥",
        "Đã Đặt" => "📅",
        "Chờ Dọn" => "🧹",
        _ => "🪑"
    };
}

public class OrderDetailItem
{
    public string MaMon { get; set; } = string.Empty;
    public string TenMon { get; set; } = string.Empty;
    public int SoLuong { get; set; } = 1;
    public decimal DonGia { get; set; }
    public decimal ThanhTien => SoLuong * DonGia;
    public string TrangThai { get; set; } = "Đang phục vụ";
    public string GhiChu { get; set; } = string.Empty;
}

public class MenuItemModel
{
    public string MaMon { get; set; } = string.Empty;
    public string TenMon { get; set; } = string.Empty;
    public string DanhMuc { get; set; } = "Món chính";
    public decimal DonGia { get; set; }
    public string DonViTinh { get; set; } = "Đĩa";
    public bool ConMon { get; set; } = true;
    public string Icon { get; set; } = "🍲";
    public string StatusText => ConMon ? "Đang phục vụ" : "Hết món";
    public string StatusBg => ConMon ? "#DCFCE7" : "#FEE2E2";
    public string StatusFg => ConMon ? "#16A34A" : "#EF4444";
}

public class StaffItemModel
{
    public string MaNV { get; set; } = string.Empty;
    public string HoTen { get; set; } = string.Empty;
    public string VaiTro { get; set; } = "Phục vụ";
    public string SoDienThoai { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string TrangThai { get; set; } = "Đang làm việc";
}

public class InvoiceItemModel
{
    public string MaHD { get; set; } = string.Empty;
    public string TenBan { get; set; } = string.Empty;
    public DateTime NgayLap { get; set; } = DateTime.Now;
    public string NhanVienLap { get; set; } = string.Empty;
    public decimal TongTien { get; set; }
    public string PhuongThuc { get; set; } = "Tiền mặt";
    public string TrangThai { get; set; } = "Đã thanh toán";
    public string StatusBg => TrangThai == "Đã thanh toán" ? "#DCFCE7" : "#FFEDD5";
    public string StatusFg => TrangThai == "Đã thanh toán" ? "#16A34A" : "#F97316";
}

public class ChatContactModel
{
    public string HoTen { get; set; } = string.Empty;
    public string VaiTro { get; set; } = string.Empty;
    public bool IsOnline { get; set; } = true;
    public string DisplayText => $"● {HoTen} · {VaiTro}";
    public string StatusColor => IsOnline ? "#16A34A" : "#94A3B8";
}

public class ChatMessageModel
{
    public string SenderName { get; set; } = string.Empty;
    public string SenderRole { get; set; } = string.Empty;
    public string Text { get; set; } = string.Empty;
    public string TimeText { get; set; } = string.Empty;
    public bool IsMe { get; set; }
    public string BubbleBackground => IsMe ? "#E8F1FA" : "#F2F6FC";
    public string BubbleForeground => "#1D2E48";
    public string HorizontalAlign => IsMe ? "Right" : "Left";
}

public class PromoItemModel
{
    public string MaVoucher { get; set; } = string.Empty;
    public string TenChuongTrinh { get; set; } = string.Empty;
    public string HinhThuc { get; set; } = "Giảm 10%";
    public string DieuKien { get; set; } = "Hóa đơn từ 500k";
    public string HanDung { get; set; } = "31/12/2026";
    public string TrangThai { get; set; } = "Đang áp dụng";
    public string StatusBg => TrangThai == "Đang áp dụng" ? "#DCFCE7" : "#FEE2E2";
    public string StatusFg => TrangThai == "Đang áp dụng" ? "#16A34A" : "#EF4444";
}

public class LogItemModel
{
    public string ThoiGian { get; set; } = string.Empty;
    public string NguoiThucHien { get; set; } = string.Empty;
    public string ChucNang { get; set; } = string.Empty;
    public string HanhDong { get; set; } = string.Empty;
    public string KetQua { get; set; } = "Thành công";
    public string ResultBg => KetQua == "Thành công" ? "#DCFCE7" : "#FEE2E2";
    public string ResultFg => KetQua == "Thành công" ? "#16A34A" : "#EF4444";
}
