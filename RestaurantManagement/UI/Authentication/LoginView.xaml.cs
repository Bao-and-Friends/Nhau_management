using System.Windows;
using System.Windows.Controls;
using RestaurantClient.Services;

namespace RestaurantClient.UI.Authentication
{
    public partial class LoginView : UserControl
    {
        public event EventHandler? LoginSuccess;

        public LoginView()
        {
            InitializeComponent();
        }

        private async void BtnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Password;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông Báo", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            btnLogin.IsEnabled = false;
            try
            {
                var (isSuccess, message) = await ApiService.LoginAsync(username, password);
                if (isSuccess)
                {
                    LoginSuccess?.Invoke(this, EventArgs.Empty);
                }
                else
                {
                    MessageBox.Show(message, "Đăng Nhập Thất Bại", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi kết nối máy chủ: {ex.Message}", "Lỗi", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                btnLogin.IsEnabled = true;
            }
        }
    }
}
