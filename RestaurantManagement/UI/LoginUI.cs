namespace RestaurantManagement.UI

{
    using Sunny.UI;
    using System.Resources;
    using RestaurantShared.DAO;

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
            if (true || login(usrname, passwrd))//dang bypass lam xong nho xoa
            {
                MainForm test = new();
                this.Hide();
                test.ShowDialog();
                this.Show();
            }
            else
            {

                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu");
            }
        }
        private bool login(string username, string password)
        {
            return AccountDAO.Instance.Login(username, password);
        }
    }
}
