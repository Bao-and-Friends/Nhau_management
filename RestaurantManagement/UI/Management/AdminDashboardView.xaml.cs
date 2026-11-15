using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using RestaurantClient.Services;
using RestaurantShared.Models.SQLData;

namespace RestaurantClient.UI.Management
{
    public partial class AdminDashboardView : UserControl
    {
        public event EventHandler<string>? NavigateRequested;

        public AdminDashboardView()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private async void LoadDashboardData()
        {
            try
            {
                // Gọi API lấy dữ liệu bàn nếu có kết nối
                var tables = await ApiService.GetTablesAsync();
                if (tables != null && tables.Count > 0)
                {
                    int total = tables.Count;
                    int occupied = tables.Count(t => t.TrangThai == TableStatus.CO_KHACH);
                    int empty = tables.Count(t => t.TrangThai == TableStatus.TRONG);

                    lblTotalTables.Text = $"{total} Bàn";
                    lblOccupiedTables.Text = $"{occupied} Bàn";
                    lblEmptyTables.Text = $"{empty} Bàn";
                }
            }
            catch
            {
                // Fallback hiển thị số liệu mẫu từ Figma thiết kế
            }
        }

        private void BtnQuickAddStaff_Click(object sender, RoutedEventArgs e)
        {
            NavigateRequested?.Invoke(this, "Staff");
        }

        private void BtnQuickUpdateFood_Click(object sender, RoutedEventArgs e)
        {
            NavigateRequested?.Invoke(this, "Food");
        }

        private void BtnQuickCheckInventory_Click(object sender, RoutedEventArgs e)
        {
            NavigateRequested?.Invoke(this, "Inventory");
        }

        private void BtnQuickRevenueReport_Click(object sender, RoutedEventArgs e)
        {
            NavigateRequested?.Invoke(this, "Revenue");
        }
    }
}