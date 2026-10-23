namespace RestaurantManagement.UI

{
    using Sunny.UI;
    using System.Resources;
    using RestaurantShared.DAO;
    using RestaurantShared.DTO;
    using System.Net.Sockets;
    using RestaurantManagement.UI.Network;

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

        private void Dangnhap_Click(object sender, EventArgs e)
        {
            string usrname = username.Text.Trim();
            string passwrd = pwtxt.Text;
            string IDNhanVien = login(usrname, passwrd);
            if (IDNhanVien.CompareTo("") != 0)
            {
                MainForm main = new MainForm();
                this.Hide();
                main.Tag = IDNhanVien;
                main.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!");
            }
        }
        private string login(string username, string password)
        {

            return AccountDAO.Instance.Login(username, password);
        }
    }
}
