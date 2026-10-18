namespace RestaurantManagement.UI

{
    using Sunny.UI;
    using System.Resources;
    using RestaurantShared.DAO;
    using RestaurantShared.DTO;

    public partial class LoginUI : UIForm
    {
        private bool isPasswordVisible = false;
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

        private void Dangnhap_Click(object sender, EventArgs e)
        {
            string usrname = username.Text;
            string passwrd = pwtxt.Text;
            if (true || login(usrname, passwrd)) // Đang bypass kiểm thử
            {
                string tenNV = "Nguyễn Văn A";
                string chucVu = "Phục Vụ";
                string maVaiTro = "VT03";
                MainForm main = new MainForm(tenNV, chucVu, maVaiTro);
                this.Hide();
                main.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }
        private bool login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }
    }
}
