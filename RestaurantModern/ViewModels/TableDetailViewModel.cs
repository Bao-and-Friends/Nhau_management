using System.Collections.ObjectModel;
using RestaurantModern.Models;
using RestaurantModern.Services;
using RestaurantModern.ViewModels.Common;

namespace RestaurantModern.ViewModels;

public class TableDetailViewModel : ViewModelBase
{
    private readonly IApiService _api;
    private readonly Action<string, object?> _navigate;

    private TableItem _table;
    private decimal _subTotal;
    private decimal _vat;
    private decimal _discount;
    private decimal _grandTotal;

    public TableItem Table
    {
        get => _table;
        set => SetProperty(ref _table, value);
    }

    public ObservableCollection<OrderDetailItem> OrderItems { get; } = [];

    public decimal SubTotal { get => _subTotal; set => SetProperty(ref _subTotal, value); }
    public decimal Vat { get => _vat; set => SetProperty(ref _vat, value); }
    public decimal Discount { get => _discount; set => SetProperty(ref _discount, value); }
    public decimal GrandTotal { get => _grandTotal; set => SetProperty(ref _grandTotal, value); }

    public RelayCommand BackCommand { get; }
    public RelayCommand AddDishCommand { get; }
    public RelayCommand PayCommand { get; }
    public RelayCommand RemoveDishCommand { get; }

    public TableDetailViewModel(TableItem table, IApiService api, Action<string, object?> navigate)
    {
        _api = api;
        _navigate = navigate;
        _table = table;

        BackCommand = new RelayCommand(() => _navigate("tables", null));
        PayCommand = new RelayCommand(() => _navigate("payment", _table));

        AddDishCommand = new RelayCommand(() =>
        {
            OrderItems.Add(new OrderDetailItem
            {
                MaMon = $"M{OrderItems.Count + 1:D3}",
                TenMon = "Bò nướng tảng sốt tiêu xanh",
                SoLuong = 1,
                DonGia = 189000,
                TrangThai = "Vừa gọi"
            });
            Recalculate();
        });

        RemoveDishCommand = new RelayCommand(p =>
        {
            if (p is OrderDetailItem item)
            {
                OrderItems.Remove(item);
                Recalculate();
            }
        });

        LoadFigmaDemoOrders();
    }

    public void AddOrderItems(IEnumerable<OrderDetailItem> items)
    {
        foreach (var item in items)
        {
            var existing = OrderItems.FirstOrDefault(x => x.MaMon == item.MaMon);
            if (existing != null)
            {
                existing.SoLuong += item.SoLuong;
            }
            else
            {
                OrderItems.Add(new OrderDetailItem
                {
                    MaMon = item.MaMon,
                    TenMon = item.TenMon,
                    DonGia = item.DonGia,
                    SoLuong = item.SoLuong,
                    TrangThai = "Đang chế biến"
                });
            }
        }
        Recalculate();
    }

    private void LoadFigmaDemoOrders()
    {
        // Khớp chính xác các món trong Figma 6:283
        OrderItems.Clear();
        OrderItems.Add(new OrderDetailItem { MaMon = "M01", TenMon = "Gà chiên giòn", SoLuong = 2, DonGia = 95000 });
        OrderItems.Add(new OrderDetailItem { MaMon = "M02", TenMon = "Khoai tây chiên", SoLuong = 1, DonGia = 45000 });
        OrderItems.Add(new OrderDetailItem { MaMon = "M03", TenMon = "Nước ngọt", SoLuong = 3, DonGia = 25000 });
        Recalculate();
    }

    public void Recalculate()
    {
        SubTotal = OrderItems.Sum(x => x.ThanhTien);
        Vat = SubTotal * 0.08m;
        Discount = 0;
        GrandTotal = SubTotal + Vat - Discount;
        Table.TongTienTamTinh = GrandTotal;
    }
}
