using System.Windows;
using System.Windows.Controls;
using RestaurantModern.Dialogs;
using RestaurantModern.ViewModels;

namespace RestaurantModern.Views;

public partial class TableManagementView : UserControl
{
    public TableManagementView()
    {
        InitializeComponent();
    }

    private void AddTable_Click(object sender, RoutedEventArgs e)
    {
        if (DataContext is TableManagementViewModel vm)
        {
            var dlg = new AddTableModal
            {
                Owner = Window.GetWindow(this)
            };

            if (dlg.ShowDialog() == true && dlg.ResultTable != null)
            {
                vm.AddTable(dlg.ResultTable);
            }
        }
    }
}
