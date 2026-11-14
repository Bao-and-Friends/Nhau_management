using System.Windows;
using System.Windows.Controls;

namespace RestaurantClient.UI.Cashier
{
    public partial class CashierView : UserControl
    {
        public CashierView()
        {
            InitializeComponent();
            dgActiveTables.ItemsSource = new List<object>
            {
                new { MaBan = "B02", TenBan = "Bàn 2", Duration = "1 giờ 15 phút", Subtotal = 910000, Status = "Chờ Thanh Toán" },
                new { MaBan = "VIP01", TenBan = "Phòng VIP 1", Duration = "2 giờ 30 phút", Subtotal = 2450000, Status = "Đang Phục Vụ" },
                new { MaBan = "B05", TenBan = "Bàn 5", Duration = "45 phút", Subtotal = 540000, Status = "Đang Phục Vụ" }
            };
        }

        private void BtnCheckout_Click(object sender, RoutedEventArgs e)
        {
            var dialog = new PaymentDialog();
            dialog.ShowDialog();
        }
    }
}
