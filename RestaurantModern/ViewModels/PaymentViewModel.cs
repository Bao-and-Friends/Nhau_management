using System.Collections.ObjectModel;
using RestaurantModern.Models;
using RestaurantModern.Services;
using RestaurantModern.ViewModels.Common;

namespace RestaurantModern.ViewModels;

public class PaymentViewModel : ViewModelBase
{
    private readonly IApiService _api;
    private readonly Action<string, object?> _navigate;

    private InvoiceItemModel? _selectedInvoice;
    private string _paymentMethod = "VietQR";
    private decimal _customerCash = 1000000;
    private decimal _changeAmount;
    private string _notificationMessage = string.Empty;
    private bool _isLoading;

    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }

    public ObservableCollection<InvoiceItemModel> PendingInvoices { get; } = [];
    public ObservableCollection<OrderDetailItem> SelectedBillItems { get; } = [];

    public InvoiceItemModel? SelectedInvoice
    {
        get => _selectedInvoice;
        set
        {
            if (SetProperty(ref _selectedInvoice, value))
            {
                LoadBillItems();
                CalculateChange();
            }
        }
    }

    public string PaymentMethod
    {
        get => _paymentMethod;
        set => SetProperty(ref _paymentMethod, value);
    }

    public decimal CustomerCash
    {
        get => _customerCash;
        set
        {
            if (SetProperty(ref _customerCash, value)) CalculateChange();
        }
    }

    public decimal ChangeAmount
    {
        get => _changeAmount;
        set => SetProperty(ref _changeAmount, value);
    }

    public string NotificationMessage
    {
        get => _notificationMessage;
        set => SetProperty(ref _notificationMessage, value);
    }

    public RelayCommand SelectMethodCommand { get; }
    public RelayCommand CompletePaymentCommand { get; }
    public RelayCommand BackToTablesCommand { get; }

    public PaymentViewModel(IApiService api, Action<string, object?> navigate, TableItem? preselectedTable = null)
    {
        _api = api;
        _navigate = navigate;

        SelectMethodCommand = new RelayCommand(p => { if (p is string m) PaymentMethod = m; });
        BackToTablesCommand = new RelayCommand(() => _navigate("tables", null));
        CompletePaymentCommand = new RelayCommand(() =>
        {
            if (SelectedInvoice != null)
            {
                NotificationMessage = $"Thanh toán thành công cho {SelectedInvoice.TenBan} qua {PaymentMethod}!";
                SelectedInvoice.TrangThai = "Đã thanh toán";
                PendingInvoices.Remove(SelectedInvoice);
                SelectedInvoice = PendingInvoices.FirstOrDefault();
            }
        });

        _ = LoadInvoicesAsync(preselectedTable);
    }

    public async Task LoadInvoicesAsync(TableItem? preselectedTable)
    {
        IsLoading = true;
        try
        {
            PendingInvoices.Clear();
            var bills = await _api.GetBillsAsync();
            var pending = bills.Where(b => !b.TrangThai.Equals("Đã thanh toán", StringComparison.OrdinalIgnoreCase));

            foreach (var b in pending)
            {
                PendingInvoices.Add(new InvoiceItemModel
                {
                    MaHD = b.MaHoaDon,
                    TenBan = !string.IsNullOrWhiteSpace(b.TenBan) ? b.TenBan : (b.BanID > 0 ? $"Bàn {b.BanID:D2}" : "Mang về"),
                    NgayLap = b.ThoiGianVao,
                    NhanVienLap = !string.IsNullOrWhiteSpace(b.TenNhanVien) ? b.TenNhanVien : "Phục vụ",
                    TongTien = b.TongThanhToan,
                    PhuongThuc = !string.IsNullOrWhiteSpace(b.GhiChu) ? b.GhiChu : "VietQR",
                    TrangThai = b.TrangThai
                });
            }

            if (preselectedTable != null)
            {
                var match = PendingInvoices.FirstOrDefault(x => x.TenBan.Equals(preselectedTable.TenBan, StringComparison.OrdinalIgnoreCase) 
                                                             || (!string.IsNullOrEmpty(preselectedTable.MaBan) && x.TenBan.Contains(preselectedTable.MaBan, StringComparison.OrdinalIgnoreCase)));
                if (match != null)
                {
                    SelectedInvoice = match;
                    return;
                }
            }
            SelectedInvoice = PendingInvoices.FirstOrDefault();
        }
        finally
        {
            IsLoading = false;
        }
    }

    private void LoadBillItems()
    {
        SelectedBillItems.Clear();
        if (SelectedInvoice != null)
        {
            SelectedBillItems.Add(new OrderDetailItem { TenMon = "Lẩu Thái Hải Sản Đặc Biệt", SoLuong = 1, DonGia = 350000 });
            SelectedBillItems.Add(new OrderDetailItem { TenMon = "Bò Mỹ Nướng Tảng Sốt Phô Mai", SoLuong = 2, DonGia = 189000 });
            SelectedBillItems.Add(new OrderDetailItem { TenMon = "Bia Tiger Bạc (Lon)", SoLuong = 6, DonGia = 28000 });
        }
    }

    private void CalculateChange()
    {
        if (SelectedInvoice == null)
        {
            ChangeAmount = 0;
            return;
        }
        ChangeAmount = Math.Max(0, CustomerCash - SelectedInvoice.TongTien);
    }
}