using System.Windows;
using System.Windows.Controls;
using RestaurantModern.Dialogs;
using RestaurantModern.ViewModels;

namespace RestaurantModern.Views;

public partial class TableDetailView : UserControl
{
    public TableDetailView()
    {
        InitializeComponent();
    }

    private void OpenOrderModal_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is TableDetailViewModel vm)
        {
            var dlg = new OrderModal(vm.Table.TenBan)
            {
                Owner = Window.GetWindow(this)
            };

            if (dlg.ShowDialog() == true && dlg.SelectedItems.Count > 0)
            {
                vm.AddOrderItems(dlg.SelectedItems);
            }
        }
    }

    private void OpenTransferModal_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is TableDetailViewModel vm)
        {
            var dlg = new TableActionModal(vm.Table.TenBan, vm.Table.SucChua, startInMergeMode: false)
            {
                Owner = Window.GetWindow(this)
            };

            if (dlg.ShowDialog() == true)
            {
                // Action logged
            }
        }
    }

    private void OpenMergeModal_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is TableDetailViewModel vm)
        {
            var dlg = new TableActionModal(vm.Table.TenBan, vm.Table.SucChua, startInMergeMode: true)
            {
                Owner = Window.GetWindow(this)
            };

            if (dlg.ShowDialog() == true)
            {
                // Action logged
            }
        }
    }
}
