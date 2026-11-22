using System.Collections.ObjectModel;
using RestaurantModern.Models;
using RestaurantModern.Services;
using RestaurantModern.ViewModels.Common;

namespace RestaurantModern.ViewModels;

public class OverviewViewModel : ViewModelBase
{
    private readonly IApiService _api;
    private readonly Action<string, object?> _navigate;

    private int _totalTables;
    private int _occupiedTables;
    private int _emptyTables;
    private int _cleaningTables;
    private decimal _todayRevenue = 14850000;
    private bool _isLoading;

    public int TotalTables { get => _totalTables; set => SetProperty(ref _totalTables, value); }
    public int OccupiedTables { get => _occupiedTables; set => SetProperty(ref _occupiedTables, value); }
    public int EmptyTables { get => _emptyTables; set => SetProperty(ref _emptyTables, value); }
    public int CleaningTables { get => _cleaningTables; set => SetProperty(ref _cleaningTables, value); }
    public decimal TodayRevenue { get => _todayRevenue; set => SetProperty(ref _todayRevenue, value); }
    public bool IsLoading { get => _isLoading; set => SetProperty(ref _isLoading, value); }

    public ObservableCollection<TableItem> ActiveTables { get; } = [];

    public RelayCommand RefreshCommand { get; }
    public RelayCommand ViewAllTablesCommand { get; }
    public RelayCommand SelectTableCommand { get; }

    public RelayCommand OpenTablesCommand { get; }
    public RelayCommand OpenPaymentCommand { get; }
    public RelayCommand OpenChatCommand { get; }
    public RelayCommand OpenInvoicesCommand { get; }

    public OverviewViewModel(IApiService api, Action<string, object?> navigate)
    {
        _api = api;
        _navigate = navigate;

        RefreshCommand = new RelayCommand(async () => await LoadDataAsync());
        ViewAllTablesCommand = new RelayCommand(() => _navigate("tables", null));
        SelectTableCommand = new RelayCommand(p =>
        {
            if (p is TableItem item) _navigate("table-detail", item);
        });

        OpenTablesCommand = new RelayCommand(() => _navigate("tables", null));
        OpenPaymentCommand = new RelayCommand(() => _navigate("payment", null));
        OpenChatCommand = new RelayCommand(() => _navigate("chat", null));
        OpenInvoicesCommand = new RelayCommand(() => _navigate("invoices", null));

        _ = LoadDataAsync();
    }

    public async Task LoadDataAsync()
    {
        IsLoading = true;
        try
        {
            var raw = await _api.GetTablesAsync();
            TotalTables = raw.Count;
            OccupiedTables = raw.Count(t => t.TrangThai.Equals("Có Khách", StringComparison.OrdinalIgnoreCase));
            EmptyTables = raw.Count(t => t.TrangThai.Equals("Trống", StringComparison.OrdinalIgnoreCase));
            CleaningTables = raw.Count(t => t.TrangThai.Equals("Chờ Dọn", StringComparison.OrdinalIgnoreCase) || t.TrangThai.Equals("Đã Đặt", StringComparison.OrdinalIgnoreCase));

            ActiveTables.Clear();
            foreach (var t in raw.Take(8))
            {
                ActiveTables.Add(new TableItem
                {
                    MaBan = t.MaBan,
                    TenBan = t.TenBan,
                    SucChua = t.SucChua,
                    TrangThai = t.TrangThai,
                    CheckIn = t.CheckIn,
                    TongTienTamTinh = t.TrangThai == "Có Khách" ? (decimal)new Random().Next(450, 2500) * 1000 : 0
                });
            }
        }
        finally
        {
            IsLoading = false;
        }
    }
}
