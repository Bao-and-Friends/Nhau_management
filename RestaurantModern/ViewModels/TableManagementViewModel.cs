using System.Collections.ObjectModel;
using RestaurantModern.Models;
using RestaurantModern.Services;
using RestaurantModern.ViewModels.Common;

namespace RestaurantModern.ViewModels;

public class TableManagementViewModel : ViewModelBase
{
    private readonly IApiService _api;
    private readonly Action<string, object?> _navigate;
    private readonly List<TableItem> _allTables = [];

    private string _selectedFilter = "Tất cả";
    private string _selectedArea = "Tất cả";
    private string _searchText = string.Empty;
    private bool _isLoading;

    public ObservableCollection<TableItem> FilteredTables { get; } = [];

    public string SelectedFilter
    {
        get => _selectedFilter;
        set
        {
            if (SetProperty(ref _selectedFilter, value)) ApplyFilters();
        }
    }

    public string SelectedArea
    {
        get => _selectedArea;
        set
        {
            if (SetProperty(ref _selectedArea, value)) ApplyFilters();
        }
    }

    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value)) ApplyFilters();
        }
    }

    public bool IsLoading { get => _isLoading; set => SetProperty(ref _isLoading, value); }

    public RelayCommand FilterCommand { get; }
    public RelayCommand AreaCommand { get; }
    public RelayCommand RefreshCommand { get; }
    public RelayCommand SelectTableCommand { get; }

    public TableManagementViewModel(IApiService api, Action<string, object?> navigate)
    {
        _api = api;
        _navigate = navigate;

        FilterCommand = new RelayCommand(p => { if (p is string s) SelectedFilter = s; });
        AreaCommand = new RelayCommand(p => { if (p is string s) SelectedArea = s; });
        RefreshCommand = new RelayCommand(async () => await LoadTablesAsync());
        SelectTableCommand = new RelayCommand(p =>
        {
            if (p is TableItem item) _navigate("table-detail", item);
        });

        _ = LoadTablesAsync();
    }

    public void AddTable(TableItem table)
    {
        _allTables.Add(table);
        ApplyFilters();
    }

    public async Task LoadTablesAsync()
    {
        IsLoading = true;
        try
        {
            var raw = await _api.GetTablesAsync();
            _allTables.Clear();
            foreach (var t in raw)
            {
                var khuVuc = "Tầng 1";
                if (t.MaBan.StartsWith("VIP", StringComparison.OrdinalIgnoreCase))
                    khuVuc = "VIP";
                else if (int.TryParse(t.MaBan.TrimStart('B'), out var num) && num > 4)
                    khuVuc = "Tầng 2";

                _allTables.Add(new TableItem
                {
                    MaBan = t.MaBan,
                    TenBan = t.TenBan,
                    SucChua = t.SucChua,
                    TrangThai = t.TrangThai,
                    KhuVuc = khuVuc,
                    CheckIn = t.CheckIn
                });
            }

            if (_allTables.Count == 0)
            {
                // Fallback demo tables matching Figma 6:148
                _allTables.AddRange([
                    new() { MaBan = "B01", TenBan = "Bàn 01", SucChua = 4, TrangThai = "Trống", KhuVuc = "Tầng 1" },
                    new() { MaBan = "B02", TenBan = "Bàn 02", SucChua = 6, TrangThai = "Có Khách", KhuVuc = "Tầng 1", CheckIn = DateTime.Now.AddMinutes(-40) },
                    new() { MaBan = "B03", TenBan = "Bàn 03", SucChua = 4, TrangThai = "Có Khách", KhuVuc = "Tầng 1", CheckIn = DateTime.Now.AddMinutes(-20) },
                    new() { MaBan = "B04", TenBan = "Bàn 04", SucChua = 2, TrangThai = "Trống", KhuVuc = "Tầng 1" },
                    new() { MaBan = "B05", TenBan = "Bàn 05", SucChua = 6, TrangThai = "Chờ Dọn", KhuVuc = "Tầng 2" },
                    new() { MaBan = "B06", TenBan = "Bàn 06", SucChua = 8, TrangThai = "Đã Đặt", KhuVuc = "Tầng 2" },
                    new() { MaBan = "B07", TenBan = "Bàn 07", SucChua = 4, TrangThai = "Trống", KhuVuc = "Tầng 2" },
                    new() { MaBan = "B08", TenBan = "Bàn 08", SucChua = 6, TrangThai = "Có Khách", KhuVuc = "Tầng 2", CheckIn = DateTime.Now.AddHours(-1) },
                    new() { MaBan = "B09", TenBan = "Bàn 09", SucChua = 4, TrangThai = "Trống", KhuVuc = "Sân vườn" },
                    new() { MaBan = "VIP01", TenBan = "Bàn VIP 01", SucChua = 10, TrangThai = "Có Khách", KhuVuc = "VIP", CheckIn = DateTime.Now.AddMinutes(-15) }
                ]);
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
        FilteredTables.Clear();
        var query = _allTables.AsEnumerable();

        if (SelectedFilter != "Tất cả")
        {
            query = query.Where(t => t.TrangThai.Equals(SelectedFilter, StringComparison.OrdinalIgnoreCase));
        }

        if (SelectedArea != "Tất cả")
        {
            query = query.Where(t => t.KhuVuc.Equals(SelectedArea, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            query = query.Where(t => t.TenBan.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                                     t.MaBan.Contains(SearchText, StringComparison.OrdinalIgnoreCase));
        }

        foreach (var table in query)
        {
            FilteredTables.Add(table);
        }
    }
}
