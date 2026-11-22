using System.Windows;
using System.Windows.Controls;
using RestaurantModern.Dialogs;
using RestaurantModern.Models;
using RestaurantModern.ViewModels;

namespace RestaurantModern.Views;

public partial class MenuView : UserControl
{
    public MenuView()
    {
        InitializeComponent();
    }

    private void AddDish_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is MenuViewModel vm)
        {
            var dlg = new DishModal
            {
                Owner = Window.GetWindow(this)
            };

            if (dlg.ShowDialog() == true && dlg.ResultDish != null)
            {
                vm.AddDish(dlg.ResultDish);
            }
        }
    }

    private void EditDish_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button btn && btn.Tag is MenuItemModel item && DataContext is MenuViewModel vm)
        {
            var dlg = new DishModal(item)
            {
                Owner = Window.GetWindow(this)
            };

            if (dlg.ShowDialog() == true && dlg.ResultDish != null)
            {
                item.TenMon = dlg.ResultDish.TenMon;
                item.DanhMuc = dlg.ResultDish.DanhMuc;
                item.DonGia = dlg.ResultDish.DonGia;
                item.DonViTinh = dlg.ResultDish.DonViTinh;
                item.ConMon = dlg.ResultDish.ConMon;
                item.Icon = dlg.ResultDish.Icon;
                vm.FilteredDishes.Clear();
                // trigger refresh
                vm.FilterCommand.Execute("Tất cả");
            }
        }
    }
}
