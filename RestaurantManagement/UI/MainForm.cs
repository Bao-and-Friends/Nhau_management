using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Sunny.UI;

namespace RestaurantManagement.UI
{
    public partial class MainForm : UIForm
    {
        public MainForm()
        {
            InitializeComponent();
            // Tự động mở Sơ đồ bàn khi vào ứng dụng
            SwitchUserControl(new UC_SoDoBan());
        }

        private void uiLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            lblClock.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void btnOpenChat_Click(object sender, EventArgs e)
        {
            // Đảo ngược trạng thái ẩn/hiện của panel Chat
            panelChat.Visible = !panelChat.Visible;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            this.Close();
            // Mở lại form đăng nhập
            LoginUI login = new LoginUI();
            login.Show();
        }

        private void SwitchUserControl(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
            uc.BringToFront();
        }

        private void btnMenuBanAn_Click(object sender, EventArgs e)
        {
            SwitchUserControl(new UC_SoDoBan());
        }
    }
}
