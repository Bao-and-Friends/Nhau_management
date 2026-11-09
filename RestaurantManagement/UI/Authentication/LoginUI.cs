using RestaurantClient.Services;
using Sunny.UI;

namespace RestaurantManagement.UI
{
 
    public partial class LoginUI : UIForm
    {
        public LoginUI()
        {
            InitializeComponent();
        }


        private void uiTextBox2_button_click(object sender, EventArgs e)
        {
            if (pwtxt.PasswordChar == '●')
            {
                // Hiển thị mật khẩu
                pwtxt.PasswordChar = '\0';
                pwtxt.ButtonSymbol = 61550;
            }
            else
            {
                // Ẩn mật khẩu
                pwtxt.PasswordChar = '●';
                pwtxt.ButtonSymbol = 61552;
            }
        }

        private async void Dangnhap_Click(object sender, EventArgs e)
        {
            string usrname = username.Text.Trim();
            string passwrd = pwtxt.Text;
            if (string.IsNullOrEmpty(usrname) || string.IsNullOrEmpty(passwrd))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!");
                return;
            }
            // Khóa nút để chống spam click
            Dangnhap.Enabled = false;
            try
            {
                var (isSuccess, message) = await ApiService.LoginAsync(usrname, passwrd);
                if (isSuccess)
                {
                    MainForm main = new() { Tag = ApiService.Staff };
                    this.Hide();
                    main.ShowDialog();
                    this.Show();
                }
                else
                {
                    MessageBox.Show(message);
                }
            }
            finally
            {
                Dangnhap.Enabled = true;
            }
        }

        private void QuenMatKhau_Click(object sender, EventArgs e)
        {
            TestQMK test = new();
            test.Show();
        }
    }
}
