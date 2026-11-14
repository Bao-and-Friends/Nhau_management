using System.Windows;
using System.Windows.Controls;
using RestaurantClient.Services;

namespace RestaurantClient.UI.Authentication
{
    public partial class OtpVerificationView : UserControl
    {
        public string Username { get; set; } = string.Empty;

        public OtpVerificationView()
        {
            InitializeComponent();
        }

        private async void BtnVerifyOtp_Click(object sender, RoutedEventArgs e)
        {
            string otp = txtOtp.Text.Trim();
            if (string.IsNullOrEmpty(otp))
            {
                MessageBox.Show("Vui lòng nhập mã OTP!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            btnVerifyOtp.IsEnabled = false;
            try
            {
                var (isSuccess, message) = await ApiService.VerifyOtpAsync(Username, otp);
                MessageBox.Show(message, isSuccess ? "Thành Công" : "Lỗi", MessageBoxButton.OK, isSuccess ? MessageBoxImage.Information : MessageBoxImage.Error);
            }
            finally
            {
                btnVerifyOtp.IsEnabled = true;
            }
        }
    }
}
