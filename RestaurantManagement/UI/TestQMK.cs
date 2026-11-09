using RestaurantManagement.Services;
using System.Text.Json;
namespace RestaurantManagement.UI
{
    public partial class TestQMK : Form
    {
        public TestQMK()
        {
            InitializeComponent();
        }

        private async void SendOTP_Click(object sender, EventArgs e)
        {
            string usrname = Usernametxt.Text.Trim();
            if (string.IsNullOrEmpty(usrname))
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập!");
                return;
            }
            SendOTP.Enabled = false;
            try
            {
                var (isSuccess, message) = await ApiService.ForgotPasswordAsync(usrname);

                MessageBox.Show(message, "Thông báo");
                if (isSuccess)
                {
                    this.Hide();
                    OTP otpForm = new() { Tag = usrname }; // Truyền username sang form OTP
                    otpForm.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}");
            }
            finally
            {
                SendOTP.Enabled = true;
            }

        }
    }
}
