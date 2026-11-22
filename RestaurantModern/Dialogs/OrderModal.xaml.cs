using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using RestaurantModern.Models;

namespace RestaurantModern.Dialogs;

public partial class OrderModal : Window
{
    private readonly List<MenuItemModel> _availableDishes = [];
    private string _currentCategory = "Tất cả";

    public ObservableCollection<OrderDetailItem> SelectedItems { get; } = [];

    public OrderModal(string tableName)
    {
        InitializeComponent();
        TxtModalTitle.Text = $"Gọi món · {tableName}";

        LstSelectedItems.ItemsSource = SelectedItems;
        SelectedItems.CollectionChanged += (s, e) => UpdateSummary();

        InitAvailableDishes();
        ApplyFilter();
    }

    private void InitAvailableDishes()
    {
        _availableDishes.Clear();
        _availableDishes.AddRange([
            new() { MaMon = "M001", TenMon = "Lẩu Thái Hải Sản Thập Cẩm", DanhMuc = "Lẩu & Nướng", DonGia = 350000, Icon = "🍲" },
            new() { MaMon = "M002", TenMon = "Lẩu Bò Nhúng Giấm", DanhMuc = "Lẩu & Nướng", DonGia = 320000, Icon = "🍲" },
            new() { MaMon = "M003", TenMon = "Bò Nướng Tảng Sốt Tiêu", DanhMuc = "Món chính", DonGia = 189000, Icon = "🥩" },
            new() { MaMon = "M004", TenMon = "Sườn Heo Nướng BBQ", DanhMuc = "Món chính", DonGia = 175000, Icon = "🍖" },
            new() { MaMon = "M005", TenMon = "Gà Hấp Lá Chanh", DanhMuc = "Món chính", DonGia = 160000, Icon = "🍗" },
            new() { MaMon = "M006", TenMon = "Mực Chiên Bơ Tỏi", DanhMuc = "Món chính", DonGia = 145000, Icon = "🦑" },
            new() { MaMon = "M007", TenMon = "Tôm Sú Hấp Bia", DanhMuc = "Món chính", DonGia = 195000, Icon = "🦐" },
            new() { MaMon = "M011", TenMon = "Bia Tiger Crystal (Lon)", DanhMuc = "Đồ uống", DonGia = 28000, Icon = "🍺" },
            new() { MaMon = "M012", TenMon = "Bia Heineken Silver (Lon)", DanhMuc = "Đồ uống", DonGia = 32000, Icon = "🍺" },
            new() { MaMon = "M013", TenMon = "Nước Ngọt Coca Cola", DanhMuc = "Đồ uống", DonGia = 18000, Icon = "🥤" },
            new() { MaMon = "M014", TenMon = "Nước Suối Lavie", DanhMuc = "Đồ uống", DonGia = 12000, Icon = "💧" },
        ]);
    }

    private void ApplyFilter()
    {
        var q = _availableDishes.AsEnumerable();
        if (_currentCategory != "Tất cả")
            q = q.Where(x => x.DanhMuc == _currentCategory);

        var search = TxtSearchDish.Text?.Trim() ?? string.Empty;
        if (!string.IsNullOrEmpty(search))
            q = q.Where(x => x.TenMon.Contains(search, StringComparison.OrdinalIgnoreCase));

        LstDishes.ItemsSource = q.ToList();
    }

    private void Category_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is string cat)
        {
            _currentCategory = cat;
            ApplyFilter();
        }
    }

    private void SearchDish_TextChanged(object sender, TextChangedEventArgs e)
    {
        ApplyFilter();
    }

    private void PickDish_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is MenuItemModel dish)
        {
            var existing = SelectedItems.FirstOrDefault(x => x.MaMon == dish.MaMon);
            if (existing != null)
            {
                existing.SoLuong++;
                UpdateSummary();
            }
            else
            {
                SelectedItems.Add(new OrderDetailItem
                {
                    MaMon = dish.MaMon,
                    TenMon = dish.TenMon,
                    DonGia = dish.DonGia,
                    SoLuong = 1
                });
            }
        }
    }

    private void IncreaseQty_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is OrderDetailItem item)
        {
            item.SoLuong++;
            UpdateSummary();
        }
    }

    private void DecreaseQty_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is OrderDetailItem item)
        {
            if (item.SoLuong > 1)
            {
                item.SoLuong--;
                UpdateSummary();
            }
            else
            {
                SelectedItems.Remove(item);
            }
        }
    }

    private void RemoveItem_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is OrderDetailItem item)
        {
            SelectedItems.Remove(item);
        }
    }

    private void UpdateSummary()
    {
        var totalQty = SelectedItems.Sum(x => x.SoLuong);
        var totalMoney = SelectedItems.Sum(x => x.ThanhTien);
        TxtTotalItems.Text = $"{totalQty} món";
        TxtTotalAmount.Text = $"{totalMoney:N0} đ";

        // Refresh List
        LstSelectedItems.Items.Refresh();
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void Confirm_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedItems.Count == 0)
        {
            MessageBox.Show("Vui lòng chọn ít nhất 1 món ăn.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        DialogResult = true;
        Close();
    }
}
