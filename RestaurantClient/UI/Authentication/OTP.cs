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
                var result = await ApiService.VerifyOtpAsync(username, otp);
                if (!result.IsError)
                {
                    MessageBox.Show("Xác thực OTP thành công!", "Thông báo");
                    this.Hide();
                    changePassword changeForm = new() { Tag = username }; // Truyền username sang form đổi mật khẩu
                    changeForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.FirstError.Description, "Thông báo");
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
                var result = await ApiService.ForgotPasswordAsync(username);
                if (!result.IsError)
                {
                    MessageBox.Show("Mã OTP đã được gửi lại!", "Thông báo");
                }
                else
                {
                    MessageBox.Show(result.FirstError.Description, "Thông báo");
                }
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
