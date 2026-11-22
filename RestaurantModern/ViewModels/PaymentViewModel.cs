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

        LoadInvoices(preselectedTable);
    }

    private void LoadInvoices(TableItem? preselectedTable)
    {
        PendingInvoices.Clear();
        PendingInvoices.Add(new InvoiceItemModel { MaHD = "HD001", TenBan = "Bàn 02", NgayLap = DateTime.Now, NhanVienLap = "NV01 - Quản lý", TongTien = 895000, PhuongThuc = "VietQR", TrangThai = "Chờ thanh toán" });
        PendingInvoices.Add(new InvoiceItemModel { MaHD = "HD002", TenBan = "Bàn 03", NgayLap = DateTime.Now.AddMinutes(-30), NhanVienLap = "NV02 - Thu ngân", TongTien = 1450000, PhuongThuc = "Tiền mặt", TrangThai = "Chờ thanh toán" });
        PendingInvoices.Add(new InvoiceItemModel { MaHD = "HD003", TenBan = "Bàn 06", NgayLap = DateTime.Now.AddMinutes(-50), NhanVienLap = "NV01 - Quản lý", TongTien = 620000, PhuongThuc = "VietQR", TrangThai = "Chờ thanh toán" });
        PendingInvoices.Add(new InvoiceItemModel { MaHD = "HD004", TenBan = "Phòng VIP 01", NgayLap = DateTime.Now.AddHours(-1), NhanVienLap = "NV03 - Phục vụ", TongTien = 3850000, PhuongThuc = "VietQR", TrangThai = "Chờ thanh toán" });

        if (preselectedTable != null)
        {
            var match = PendingInvoices.FirstOrDefault(x => x.TenBan == preselectedTable.TenBan);
            if (match != null)
            {
                SelectedInvoice = match;
                return;
            }
        }
        SelectedInvoice = PendingInvoices.FirstOrDefault();
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