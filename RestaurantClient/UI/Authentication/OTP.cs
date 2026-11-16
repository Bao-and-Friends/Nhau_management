using RestaurantClient.Services;
using RestaurantClient.UI;

namespace RestaurantManagement.UI
{
    public partial class OTP : Form
    {
        public OTP()
        {
            InitializeComponent();
        }

        private async void OTPVerify_Click(object sender, EventArgs e)
        {
            string otp = Otptxt.Text.Trim();
            if (this.Tag is not string username)
            {
                this.Close();
                return;
            }
            if (string.IsNullOrEmpty(otp))
            {
                MessageBox.Show("Vui lòng nhập mã OTP!");
                return;
            }
            OTPVerify.Enabled = false;
            try
            {
                // 👉 GỌI API XÁC THỰC OTP:
                var (isSuccess, message) = await ApiService.VerifyOtpAsync(username, otp);
                MessageBox.Show(message, "Thông báo");
                if (isSuccess)
                {
                    this.Hide();
                    changePassword changeForm = new() { Tag = username }; // Truyền username sang form đổi mật khẩu
                    changeForm.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            finally
            {
                OTPVerify.Enabled = true;
            }
        }

        private async void ResendOTPbtn_Click(object sender, EventArgs e)
        {
            if (this.Tag is not string username) return;
            ResendOTPbtn.Enabled = false;
            try
            {
                var (isSuccess, message) = await ApiService.ForgotPasswordAsync(username);
                MessageBox.Show(message, "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            finally
            {
                ResendOTPbtn.Enabled = true;
            }
        }
    }
}
