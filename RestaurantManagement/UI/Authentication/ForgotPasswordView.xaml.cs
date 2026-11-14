using System.Windows;
using System.Windows.Controls;
using RestaurantClient.Services;

namespace RestaurantClient.UI.Authentication
{
    public partial class ForgotPasswordView : UserControl
    {
        public ForgotPasswordView()
        {
            InitializeComponent();
        }

        private async void BtnSendOtp_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            btnSendOtp.IsEnabled = false;
            try
            {
                var (isSuccess, message) = await ApiService.ForgotPasswordAsync(username);
                MessageBox.Show(message, isSuccess ? "Thành Công" : "Lỗi", MessageBoxButton.OK, isSuccess ? MessageBoxImage.Information : MessageBoxImage.Error);
            }
            finally
            {
                btnSendOtp.IsEnabled = true;
            }
        }
    }
}
