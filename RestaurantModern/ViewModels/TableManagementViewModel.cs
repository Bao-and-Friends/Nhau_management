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

    private int _totalTables;
    private int _emptyTables;
    private int _occupiedTables;
    private int _cleaningTables;

    public int TotalTables { get => _totalTables; set => SetProperty(ref _totalTables, value); }
    public int EmptyTables { get => _emptyTables; set => SetProperty(ref _emptyTables, value); }
    public int OccupiedTables { get => _occupiedTables; set => SetProperty(ref _occupiedTables, value); }
    public int CleaningTables { get => _cleaningTables; set => SetProperty(ref _cleaningTables, value); }

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
        UpdateCounts();
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
                    BanID = t.BanID,
                    MaBan = t.MaBan,
                    TenBan = t.TenBan,
                    SucChua = t.SucChua,
                    TrangThai = t.TrangThai,
                    KhuVuc = khuVuc,
                    CheckIn = t.CheckIn
                });
            }
            UpdateCounts();
            ApplyFilters();
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void UpdateCounts()
    {
        TotalTables = _allTables.Count;
        EmptyTables = _allTables.Count(t => t.TrangThai.Equals("Trống", StringComparison.OrdinalIgnoreCase));
        OccupiedTables = _allTables.Count(t => t.TrangThai.Equals("Có Khách", StringComparison.OrdinalIgnoreCase));
        CleaningTables = _allTables.Count(t => t.TrangThai.Equals("Chờ Dọn", StringComparison.OrdinalIgnoreCase) 
                                           || t.TrangThai.Equals("Chưa dọn", StringComparison.OrdinalIgnoreCase)
                                           || t.TrangThai.Equals("Chờ dọn", StringComparison.OrdinalIgnoreCase));
    }

    private void ApplyFilters()
    {
        FilteredTables.Clear();
        var query = _allTables.AsEnumerable();

        if (SelectedFilter != "Tất cả")
        {
            if (SelectedFilter.Equals("Chờ Dọn", StringComparison.OrdinalIgnoreCase) || SelectedFilter.Equals("Chưa dọn", StringComparison.OrdinalIgnoreCase))
            {
                query = query.Where(t => t.TrangThai.Equals("Chờ Dọn", StringComparison.OrdinalIgnoreCase)
                                      || t.TrangThai.Equals("Chưa dọn", StringComparison.OrdinalIgnoreCase)
                                      || t.TrangThai.Equals("Chờ dọn", StringComparison.OrdinalIgnoreCase));
            }
            else
            {
                query = query.Where(t => t.TrangThai.Equals(SelectedFilter, StringComparison.OrdinalIgnoreCase));
            }
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
