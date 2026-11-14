using System.Windows;
using System.Windows.Controls;
using RestaurantClient.Services;
using RestaurantShared.Models.SQLData;

namespace RestaurantClient.UI.Table
{
    public partial class TableMapView : UserControl
    {
        public TableMapView()
        {
            InitializeComponent();
            Loaded += async (s, e) => await LoadTablesAsync();
        }

        public async Task LoadTablesAsync()
        {
            try
            {
                var tables = await ApiService.GetTablesAsync();
                if (tables != null && tables.Count > 0)
                {
                    icTables.ItemsSource = tables;
                }
                else
                {
                    // Mock data mẫu nếu server chưa bật để designer/dev xem ngay giao diện
                    icTables.ItemsSource = new List<TableDATA>
                    {
                        new() { MaBan = "B01", TenBan = "Bàn 1", SucChua = 4, TrangThai = TableStatus.TRONG },
                        new() { MaBan = "B02", TenBan = "Bàn 2", SucChua = 4, TrangThai = TableStatus.CO_KHACH },
                        new() { MaBan = "B03", TenBan = "Bàn 3", SucChua = 6, TrangThai = TableStatus.DA_DAT },
                        new() { MaBan = "B04", TenBan = "Bàn 4", SucChua = 4, TrangThai = TableStatus.CHO_DON },
                        new() { MaBan = "VIP01", TenBan = "Phòng VIP 1", SucChua = 10, TrangThai = TableStatus.CO_KHACH },
                        new() { MaBan = "VIP02", TenBan = "Phòng VIP 2", SucChua = 12, TrangThai = TableStatus.TRONG }
                    };
                }
            }
            catch
            {
                // Fallback mock
                icTables.ItemsSource = new List<TableDATA>
                {
                    new() { MaBan = "B01", TenBan = "Bàn 1", SucChua = 4, TrangThai = TableStatus.TRONG },
                    new() { MaBan = "B02", TenBan = "Bàn 2", SucChua = 4, TrangThai = TableStatus.CO_KHACH }
                };
            }
        }

        private async void BtnRefresh_Click(object sender, RoutedEventArgs e)
        {
            await LoadTablesAsync();
        }
    }
}
