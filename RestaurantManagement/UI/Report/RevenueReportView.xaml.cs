using System.Windows.Controls;

namespace RestaurantClient.UI.Report
{
    public partial class RevenueReportView : UserControl
    {
        public RevenueReportView()
        {
            InitializeComponent();
            dgRevenue.ItemsSource = new List<object>
            {
                new { Id = "HD20261114-001", Table = "Bàn 02", Time = "14/11/2026 20:15", Cashier = "Lê Dương Bảo", Total = 982800 },
                new { Id = "HD20261114-002", Table = "Phòng VIP 01", Time = "14/11/2026 19:40", Cashier = "Lê Dương Bảo", Total = 2450000 },
                new { Id = "HD20261114-003", Table = "Bàn 05", Time = "14/11/2026 18:50", Cashier = "Lê Dương Bảo", Total = 540000 }
            };
        }
    }
}
