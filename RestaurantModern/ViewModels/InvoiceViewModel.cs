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
    private bool _isLoading;

    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }

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
    public RelayCommand RefreshCommand { get; }
    public RelayCommand OpenTablesCommand { get; }
    public RelayCommand ViewDetailCommand { get; }

    public InvoiceViewModel(IApiService api, Action<string, object?> navigate)
    {
        _api = api;
        _navigate = navigate;

        FilterCommand = new RelayCommand(p => { if (p is string f) SelectedFilter = f; });
        RefreshCommand = new RelayCommand(async () => await LoadInvoicesAsync());
        OpenTablesCommand = new RelayCommand(() => _navigate("tables", null));
        ViewDetailCommand = new RelayCommand(p =>
        {
            if (p is InvoiceItemModel inv)
            {
                // Open payment or preview
                _navigate("payment", null);
            }
        });

        _ = LoadInvoicesAsync();
    }

    public async Task LoadInvoicesAsync()
    {
        IsLoading = true;
        try
        {
            var bills = await _api.GetBillsAsync();
            _allInvoices.Clear();
            foreach (var b in bills)
            {
                _allInvoices.Add(new InvoiceItemModel
                {
                    MaHD = b.MaHoaDon,
                    TenBan = !string.IsNullOrWhiteSpace(b.TenBan) ? b.TenBan : (b.BanID > 0 ? $"Bàn {b.BanID:D2}" : "Mang về"),
                    NgayLap = b.ThoiGianRa ?? b.ThoiGianVao,
                    NhanVienLap = !string.IsNullOrWhiteSpace(b.TenNhanVien) ? b.TenNhanVien : "Nhân viên",
                    TongTien = b.TongThanhToan,
                    PhuongThuc = !string.IsNullOrWhiteSpace(b.GhiChu) ? b.GhiChu : "Tiền mặt",
                    TrangThai = b.TrangThai
                });
            }
            ApplyFilters();
        }
        finally
        {
            IsLoading = false;
        }
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
