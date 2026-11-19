using System.Collections.ObjectModel;
using RestaurantModern.Models;
using RestaurantModern.ViewModels.Common;

namespace RestaurantModern.ViewModels;

public class LogsViewModel : ViewModelBase
{
    private readonly List<LogItemModel> _allLogs = [];
    private string _searchText = string.Empty;

    public ObservableCollection<LogItemModel> FilteredLogs { get; } = [];

    public string SearchText
    {
        get => _searchText;
        set { if (SetProperty(ref _searchText, value)) ApplyFilters(); }
    }

    public RelayCommand RefreshCommand { get; }

    public LogsViewModel()
    {
        RefreshCommand = new RelayCommand(LoadDemoLogs);
        LoadDemoLogs();
    }

    private void LoadDemoLogs()
    {
        _allLogs.Clear();
        _allLogs.AddRange([
            new() { ThoiGian = DateTime.Now.ToString("dd/MM/yyyy HH:mm"), NguoiThucHien = "Trần Quốc Huy (Quản lý)", ChucNang = "Hệ thống", HanhDong = "Đăng nhập thành công vào hệ thống", KetQua = "Thành công" },
            new() { ThoiGian = DateTime.Now.AddMinutes(-8).ToString("dd/MM/yyyy HH:mm"), NguoiThucHien = "Nguyễn Văn A (Phục vụ)", ChucNang = "Gọi món", HanhDong = "Bàn 02: Gọi thêm 1 Lẩu Thái, 2 Bia Tiger", KetQua = "Thành công" },
            new() { ThoiGian = DateTime.Now.AddMinutes(-20).ToString("dd/MM/yyyy HH:mm"), NguoiThucHien = "Trần Thị B (Thu ngân)", ChucNang = "Thanh toán", HanhDong = "HD002: Bàn 05 thanh toán 780.000 đ", KetQua = "Thành công" },
            new() { ThoiGian = DateTime.Now.AddMinutes(-35).ToString("dd/MM/yyyy HH:mm"), NguoiThucHien = "Nguyễn Văn A (Phục vụ)", ChucNang = "Chuyển bàn", HanhDong = "Chuyển Bàn 03 sang Bàn 05 theo yêu cầu khách", KetQua = "Thành công" },
            new() { ThoiGian = DateTime.Now.AddMinutes(-50).ToString("dd/MM/yyyy HH:mm"), NguoiThucHien = "Lê Văn C (Quản lý)", ChucNang = "Thực đơn", HanhDong = "Cập nhật đơn giá món Bò nướng tảng", KetQua = "Thành công" },
            new() { ThoiGian = DateTime.Now.AddHours(-2).ToString("dd/MM/yyyy HH:mm"), NguoiThucHien = "Trần Thị B (Thu ngân)", ChucNang = "Thanh toán", HanhDong = "HD003: Bàn 01 thanh toán VietQR 1.250.000 đ", KetQua = "Thành công" },
            new() { ThoiGian = DateTime.Now.AddHours(-3).ToString("dd/MM/yyyy HH:mm"), NguoiThucHien = "Hoàng Văn D (Bếp trưởng)", ChucNang = "Kho nguyên liệu", HanhDong = "Nhập kho 20kg Thịt bò tươi, 5 thùng Bia Tiger", KetQua = "Thành công" }
        ]);
        ApplyFilters();
    }

    private void ApplyFilters()
    {
        FilteredLogs.Clear();
        var q = _allLogs.AsEnumerable();
        if (!string.IsNullOrWhiteSpace(SearchText))
            q = q.Where(x => x.NguoiThucHien.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                             x.ChucNang.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                             x.HanhDong.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

        foreach (var item in q) FilteredLogs.Add(item);
    }
}
