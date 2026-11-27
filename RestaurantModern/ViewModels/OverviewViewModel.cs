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
    private decimal _todayRevenue;
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
            var rawTables = (await _api.GetTablesAsync()).ToList();
            var rawBills = (await _api.GetBillsAsync()).ToList();

            TotalTables = rawTables.Count;
            OccupiedTables = rawTables.Count(t => t.TrangThai.Equals("Có Khách", StringComparison.OrdinalIgnoreCase));
            EmptyTables = rawTables.Count(t => t.TrangThai.Equals("Trống", StringComparison.OrdinalIgnoreCase));
            CleaningTables = rawTables.Count(t => t.TrangThai.Equals("Chờ Dọn", StringComparison.OrdinalIgnoreCase)
                                               || t.TrangThai.Equals("Chưa dọn", StringComparison.OrdinalIgnoreCase)
                                               || t.TrangThai.Equals("Chờ dọn", StringComparison.OrdinalIgnoreCase));

            // Tính doanh thu thực tế từ các hóa đơn đã thanh toán
            var paidBillsToday = rawBills.Where(b => b.TrangThai.Equals("Đã thanh toán", StringComparison.OrdinalIgnoreCase)
                                                  && ((b.ThoiGianRa.HasValue && b.ThoiGianRa.Value.Date == DateTime.Today)
                                                      || b.ThoiGianVao.Date == DateTime.Today)).ToList();
            if (paidBillsToday.Count > 0)
            {
                TodayRevenue = paidBillsToday.Sum(b => b.TongThanhToan);
            }
            else
            {
                TodayRevenue = rawBills.Where(b => b.TrangThai.Equals("Đã thanh toán", StringComparison.OrdinalIgnoreCase)).Sum(b => b.TongThanhToan);
            }

            ActiveTables.Clear();
            foreach (var t in rawTables.Take(8))
            {
                // Lấy tiền tạm tính thực tế từ hóa đơn đang mở của bàn (nếu có)
                var pendingBill = rawBills.FirstOrDefault(b => (b.BanID == t.BanID || (!string.IsNullOrEmpty(b.MaBan) && b.MaBan == t.MaBan))
                                                            && !b.TrangThai.Equals("Đã thanh toán", StringComparison.OrdinalIgnoreCase));
                decimal tongTienTamTinh = pendingBill?.TongThanhToan ?? 0;

                ActiveTables.Add(new TableItem
                {
                    BanID = t.BanID,
                    MaBan = t.MaBan,
                    TenBan = t.TenBan,
                    SucChua = t.SucChua,
                    TrangThai = t.TrangThai,
                    CheckIn = t.CheckIn,
                    TongTienTamTinh = tongTienTamTinh
                });
            }
        }
        finally
        {
            IsLoading = false;
        }
    }
}
