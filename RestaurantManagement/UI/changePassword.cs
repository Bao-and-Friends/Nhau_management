using RestaurantManagement.Services;
using System.Text.Json;
namespace RestaurantManagement.UI
{
    public partial class changePassword : Form
    {
        public changePassword()
        {
            InitializeComponent();
        }

        private async void Dangnhap_Click(object sender, EventArgs e)
        {
            string password = pwtxt.Text;
            string rePassword = REpwtxt.Text;
            if (this.Tag is not string username)
            {
                this.Close();
                return;
            }
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(rePassword))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ mật khẩu!");
                return;
            }
            if (password != rePassword)
            {
                MessageBox.Show("Mật khẩu nhập lại không khớp!");
                return;
            }
            Dangnhap.Enabled = false;
            try
            {
                // 👉 GỌI API ĐỔI MẬT KHẨU:
                var (isSuccess, message) = await ApiService.ChangePasswordAsync(username, password);
                MessageBox.Show(message, "Thông báo");
                if (isSuccess)
                {
                    this.Close(); // Đổi xong thì đóng form để quay về đăng nhập
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            finally
            {
                Dangnhap.Enabled = true;
            }
        }
    }
}
