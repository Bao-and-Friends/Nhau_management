using System.Collections.ObjectModel;
using RestaurantModern.Services;
using RestaurantModern.ViewModels.Common;

namespace RestaurantModern.ViewModels;

public class StockItemModel
{
    public string MaNL { get; set; } = string.Empty;
    public string TenNL { get; set; } = string.Empty;
    public decimal SoLuongTon { get; set; }
    public string DonViTinh { get; set; } = "kg";
    public decimal DinhMucToiThieu { get; set; }
    public string TrangThai => SoLuongTon <= DinhMucToiThieu ? "Cảnh báo hết" : "Đủ tồn kho";
    public string StatusColor => SoLuongTon <= DinhMucToiThieu ? "#EF4444" : "#16A34A";
}

public class StockViewModel : ViewModelBase
{
    public ObservableCollection<StockItemModel> StockItems { get; } = [];

    public StockViewModel()
    {
        StockItems.Add(new StockItemModel { MaNL = "NL01", TenNL = "Thịt Bò Mỹ Ba Chỉ", SoLuongTon = 18.5m, DonViTinh = "kg", DinhMucToiThieu = 5.0m });
        StockItems.Add(new StockItemModel { MaNL = "NL02", TenNL = "Mực Lá Tươi Phú Quốc", SoLuongTon = 3.2m, DonViTinh = "kg", DinhMucToiThieu = 5.0m });
        StockItems.Add(new StockItemModel { MaNL = "NL03", TenNL = "Tôm Sú Biển Loại 1", SoLuongTon = 12.0m, DonViTinh = "kg", DinhMucToiThieu = 4.0m });
        StockItems.Add(new StockItemModel { MaNL = "NL04", TenNL = "Bia Tiger Bạc 24 lon/thùng", SoLuongTon = 45, DonViTinh = "Thùng", DinhMucToiThieu = 10 });
        StockItems.Add(new StockItemModel { MaNL = "NL05", TenNL = "Rau Cần, Nấm, Bắp Cay", SoLuongTon = 25.0m, DonViTinh = "kg", DinhMucToiThieu = 8.0m });
        StockItems.Add(new StockItemModel { MaNL = "NL06", TenNL = "Nước Cốt Lẩu Thái Đậm Đà", SoLuongTon = 8.0m, DonViTinh = "Lít", DinhMucToiThieu = 10.0m });
    }
}

public class ShiftItemModel
{
    public string Ca { get; set; } = string.Empty;
    public string Gio { get; set; } = string.Empty;
    public string NhanVien { get; set; } = string.Empty;
    public string ViTri { get; set; } = string.Empty;
    public string GhiChu { get; set; } = string.Empty;
}

public class ShiftsViewModel : ViewModelBase
{
    public ObservableCollection<ShiftItemModel> Shifts { get; } = [];

    public ShiftsViewModel()
    {
        Shifts.Add(new ShiftItemModel { Ca = "Ca Sáng", Gio = "08:00 - 14:00", NhanVien = "Trần Quốc Huy (Quản lý), Nguyễn Thu Hà (Thu ngân)", ViTri = "Khu vực sảnh chính", GhiChu = "Kiểm kê đầu ngày" });
        Shifts.Add(new ShiftItemModel { Ca = "Ca Chiều / Tối", Gio = "14:00 - 23:00", NhanVien = "Lê Hoàng Long, Đỗ Quỳnh Mai (Phục vụ)", ViTri = "Khu vực tầng 1 & VIP", GhiChu = "Đông khách cuối tuần" });
        Shifts.Add(new ShiftItemModel { Ca = "Ca Bếp", Gio = "09:00 - 22:00", NhanVien = "Phạm Đình Bảo (Bếp trưởng)", ViTri = "Khu vực bếp nấu", GhiChu = "Nhận nguyên liệu 10h" });
    }
}

public class RevenueStatsViewModel : ViewModelBase
{
    public string TongDoanhThuThang { get; } = "345,850,000 đ";
    public string DoanhThuHomNay { get; } = "14,850,000 đ";
    public string SoHoaDonHomNay { get; } = "28 Hóa đơn";
    public string MonBanChayNhat { get; } = "Lẩu Thái Hải Sản Đặc Biệt (42 phần)";
}

public class ProfileViewModel : ViewModelBase
{
    private readonly IApiService _api;
    private string _currentPassword = string.Empty;
    private string _newPassword = string.Empty;
    private string _confirmPassword = string.Empty;
    private string _message = string.Empty;
    private bool _isSuccess;

    public string HoTen => _api.CurrentStaff?.HoTen ?? "Trần Quốc Huy";
    public string MaNV => _api.CurrentStaff?.MaNV ?? "NV001";
    public string VaiTro => _api.CurrentStaff?.VaiTro ?? "Quản lý";
    public string SoDienThoai => _api.CurrentStaff?.SoDienThoai ?? "0987654321";
    public string DiaChi => _api.CurrentStaff?.DiaChi ?? "Hà Nội";

    public string CurrentPassword { get => _currentPassword; set => SetProperty(ref _currentPassword, value); }
    public string NewPassword { get => _newPassword; set => SetProperty(ref _newPassword, value); }
    public string ConfirmPassword { get => _confirmPassword; set => SetProperty(ref _confirmPassword, value); }
    public string Message { get => _message; set => SetProperty(ref _message, value); }
    public bool IsSuccess { get => _isSuccess; set => SetProperty(ref _isSuccess, value); }

    public AsyncRelayCommand ChangePasswordCommand { get; }

    public ProfileViewModel(IApiService api)
    {
        _api = api;
        ChangePasswordCommand = new AsyncRelayCommand(async () =>
        {
            if (string.IsNullOrWhiteSpace(NewPassword) || NewPassword != ConfirmPassword)
            {
                Message = "Mật khẩu mới không trùng khớp!";
                IsSuccess = false;
                return;
            }

            var res = await _api.ChangePasswordAsync(MaNV, NewPassword);
            Message = res.Message ?? "Đổi mật khẩu thành công!";
            IsSuccess = res.IsSuccess;
            if (res.IsSuccess)
            {
                CurrentPassword = string.Empty;
                NewPassword = string.Empty;
                ConfirmPassword = string.Empty;
            }
        });
    }
}