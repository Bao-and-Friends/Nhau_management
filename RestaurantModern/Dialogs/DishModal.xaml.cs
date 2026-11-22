using System.Windows;
using System.Windows.Controls;
using RestaurantModern.Models;

namespace RestaurantModern.Dialogs;

public partial class DishModal : Window
{
    public MenuItemModel? ResultDish { get; private set; }

    public DishModal()
    {
        InitializeComponent();
    }

    public DishModal(MenuItemModel editItem) : this()
    {
        TxtTitle.Text = "Chỉnh sửa món ăn";
        TxtTenMon.Text = editItem.TenMon;
        TxtDonViTinh.Text = editItem.DonViTinh;
        TxtDonGia.Text = editItem.DonGia.ToString("F0");
        foreach (ComboBoxItem item in CmbDanhMuc.Items)
        {
            if (item.Content.ToString() == editItem.DanhMuc)
            {
                CmbDanhMuc.SelectedItem = item;
                break;
            }
        }
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TxtTenMon.Text))
        {
            MessageBox.Show("Vui lòng nhập tên món ăn.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        if (!decimal.TryParse(TxtDonGia.Text.Replace(",", "").Replace(".", "").Trim(), out var donGia))
        {
            donGia = 100000;
        }

        var danhMuc = (CmbDanhMuc.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Món chính";
        var conMon = CmbTrangThai.SelectedIndex == 0;

        ResultDish = new MenuItemModel
        {
            MaMon = $"M{new Random().Next(100, 999)}",
            TenMon = TxtTenMon.Text.Trim(),
            DanhMuc = danhMuc,
            DonGia = donGia,
            DonViTinh = string.IsNullOrWhiteSpace(TxtDonViTinh.Text) ? "Phần" : TxtDonViTinh.Text.Trim(),
            ConMon = conMon,
            Icon = danhMuc.Contains("Đồ uống") ? "🍺" : danhMuc.Contains("Lẩu") ? "🍲" : danhMuc.Contains("Hải sản") ? "🦐" : "🥩"
        };

        DialogResult = true;
        Close();
    }
}
