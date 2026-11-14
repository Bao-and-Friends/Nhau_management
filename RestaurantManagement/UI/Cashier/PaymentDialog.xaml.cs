using System.Windows;

namespace RestaurantClient.UI.Cashier
{
    public partial class PaymentDialog : Window
    {
        public PaymentDialog()
        {
            InitializeComponent();
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Thanh toán thành công! Hóa đơn đã được in và bàn đã chuyển sang trạng thái Chờ Dọn Dẹp.", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Information);
            Close();
        }
    }
}
