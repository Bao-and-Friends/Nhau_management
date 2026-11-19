using System.Windows;
using System.Windows.Controls;
using RestaurantModern.Models;

namespace RestaurantModern.Dialogs;

public partial class AddTableModal : Window
{
    public TableItem? ResultTable { get; private set; }

    public AddTableModal()
    {
        InitializeComponent();
    }

    private void Close_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }

    private void Save_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(TxtTenBan.Text))
        {
            MessageBox.Show("Vui lòng nhập tên bàn.", "Thông báo", MessageBoxButton.OK, MessageBoxImage.Warning);
            return;
        }

        var sucChuaStr = (CmbSucChua.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "4 chỗ";
        int sucChua = 4;
        if (sucChuaStr.StartsWith("2")) sucChua = 2;
        else if (sucChuaStr.StartsWith("6")) sucChua = 6;
        else if (sucChuaStr.StartsWith("8")) sucChua = 8;
        else if (sucChuaStr.StartsWith("10")) sucChua = 10;

        var khuVuc = (CmbKhuVuc.SelectedItem as ComboBoxItem)?.Content?.ToString() ?? "Tầng 1";

        ResultTable = new TableItem
        {
            MaBan = $"B{new Random().Next(20, 99)}",
            TenBan = TxtTenBan.Text.Trim(),
            SucChua = sucChua,
            KhuVuc = khuVuc,
            TrangThai = "Trống"
        };

        DialogResult = true;
        Close();
    }
}
