using RestaurantClient.Services;
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
                var result = await ApiService.ForgotPasswordAsync(usrname);
                if (!result.IsError)
                {
                    MessageBox.Show("Mã OTP đã được gửi về email của bạn.", "Thông báo");
                    this.Hide();
                    OTP otpForm = new() { Tag = usrname }; // Truyền username sang form OTP
                    otpForm.ShowDialog();
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
                SendOTP.Enabled = true;
            }

        }
    }
}
