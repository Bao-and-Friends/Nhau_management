using System.Collections.ObjectModel;
using RestaurantModern.Models;
using RestaurantModern.Services;
using RestaurantModern.ViewModels.Common;

namespace RestaurantModern.ViewModels;

public class InvoiceViewModel : ViewModelBase
{
    private readonly IApiService _api;
    private readonly Action<string, object?> _navigate;
    private readonly List<InvoiceItemModel> _allInvoices = [];

    private string _selectedFilter = "Tất cả";
    private string _searchText = string.Empty;
    private InvoiceItemModel? _selectedInvoice;

    public ObservableCollection<InvoiceItemModel> FilteredInvoices { get; } = [];

    public string SelectedFilter
    {
        get => _selectedFilter;
        set { if (SetProperty(ref _selectedFilter, value)) ApplyFilters(); }
    }

    public string SearchText
    {
        get => _searchText;
        set { if (SetProperty(ref _searchText, value)) ApplyFilters(); }
    }

    public InvoiceItemModel? SelectedInvoice
    {
        get => _selectedInvoice;
        set => SetProperty(ref _selectedInvoice, value);
    }

    public RelayCommand FilterCommand { get; }
    public RelayCommand OpenTablesCommand { get; }
    public RelayCommand ViewDetailCommand { get; }

    public InvoiceViewModel(IApiService api, Action<string, object?> navigate)
    {
        _api = api;
        _navigate = navigate;

        FilterCommand = new RelayCommand(p => { if (p is string f) SelectedFilter = f; });
        OpenTablesCommand = new RelayCommand(() => _navigate("tables", null));
        ViewDetailCommand = new RelayCommand(p =>
        {
            if (p is InvoiceItemModel inv)
            {
                // Open payment or preview
                _navigate("payment", null);
            }
        });

        LoadDemoInvoices();
    }

    private void LoadDemoInvoices()
    {
        _allInvoices.Clear();
        _allInvoices.AddRange([
            new() { MaHD = "HD001", TenBan = "Bàn 02", NgayLap = DateTime.Now.AddMinutes(-40), NhanVienLap = "Trần Thị B", TongTien = 310000, PhuongThuc = "Chuyển khoản VietQR", TrangThai = "Chờ thanh toán" },
            new() { MaHD = "HD002", TenBan = "Bàn 05", NgayLap = DateTime.Now.AddHours(-1), NhanVienLap = "Nguyễn Văn A", TongTien = 780000, PhuongThuc = "Tiền mặt", TrangThai = "Đã thanh toán" },
            new() { MaHD = "HD003", TenBan = "Bàn 01", NgayLap = DateTime.Now.AddHours(-2), NhanVienLap = "Trần Thị B", TongTien = 1250000, PhuongThuc = "Chuyển khoản VietQR", TrangThai = "Đã thanh toán" },
            new() { MaHD = "HD004", TenBan = "Bàn 08", NgayLap = DateTime.Now.AddHours(-3), NhanVienLap = "Lê Văn C", TongTien = 450000, PhuongThuc = "Tiền mặt", TrangThai = "Đã thanh toán" },
            new() { MaHD = "HD005", TenBan = "Bàn 03", NgayLap = DateTime.Now.AddHours(-4), NhanVienLap = "Nguyễn Văn A", TongTien = 620000, PhuongThuc = "Chuyển khoản VietQR", TrangThai = "Đã thanh toán" },
            new() { MaHD = "HD006", TenBan = "Bàn 07", NgayLap = DateTime.Now.AddHours(-5), NhanVienLap = "Trần Thị B", TongTien = 890000, PhuongThuc = "Tiền mặt", TrangThai = "Đã thanh toán" },
        ]);
        ApplyFilters();
    }

    private void ApplyFilters()
    {
        FilteredInvoices.Clear();
        var q = _allInvoices.AsEnumerable();
        if (SelectedFilter != "Tất cả") q = q.Where(x => x.TrangThai.Equals(SelectedFilter, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrWhiteSpace(SearchText))
            q = q.Where(x => x.MaHD.Contains(SearchText, StringComparison.OrdinalIgnoreCase) || x.TenBan.Contains(SearchText, StringComparison.OrdinalIgnoreCase));

        foreach (var item in q) FilteredInvoices.Add(item);
    }
}
