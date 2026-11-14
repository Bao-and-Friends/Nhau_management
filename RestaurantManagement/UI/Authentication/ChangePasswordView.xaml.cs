using System.Windows;
using System.Windows.Controls;
using RestaurantClient.Services;

namespace RestaurantClient.UI.Authentication
{
    public partial class ChangePasswordView : UserControl
    {
        public string Username { get; set; } = string.Empty;

        public ChangePasswordView()
        {
            InitializeComponent();
        }

        private async void BtnChangePassword_Click(object sender, RoutedEventArgs e)
        {
            string newPassword = txtNewPassword.Password;
            string confirmPassword = txtConfirmPassword.Password;

            if (string.IsNullOrEmpty(newPassword) || string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (newPassword != confirmPassword)
            {
                MessageBox.Show("Mật khẩu xác nhận không khớp!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            btnChangePassword.IsEnabled = false;
            try
            {
                var (isSuccess, message) = await ApiService.ChangePasswordAsync(Username, newPassword);
                MessageBox.Show(message, isSuccess ? "Thành Công" : "Lỗi", MessageBoxButton.OK, isSuccess ? MessageBoxImage.Information : MessageBoxImage.Error);
            }
            finally
            {
                btnChangePassword.IsEnabled = true;
            }
        }
    }
}
