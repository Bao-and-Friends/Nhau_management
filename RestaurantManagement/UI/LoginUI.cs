namespace RestaurantManagement
    
{
    using Sunny.UI;
    using System.Resources;

    public partial class LoginUI : UIForm
    {
        private bool isPasswordVisible = false;
        public LoginUI()
        {
            InitializeComponent();

        }

        
        private void uiTextBox2_button_click(object sender, EventArgs e)
        {
            if (uiTextBox2.PasswordChar == '●')
            {
                // Hiển thị mật khẩu
                uiTextBox2.PasswordChar = '\0';
                uiTextBox2.ButtonSymbol = 61550;
            }
            else
            {
                // Ẩn mật khẩu
                uiTextBox2.PasswordChar = '●';
                uiTextBox2.ButtonSymbol = 61552;
            }
        }
    }
}
