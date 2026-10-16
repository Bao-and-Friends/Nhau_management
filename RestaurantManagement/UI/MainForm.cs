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
            //SwitchUserControl(new UC_SoDoBan());
        }
        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

            timer1.Interval = 1000;
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }
        private void DangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SwitchUserControl(UserControl uc)
        {
            panelContent.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            panelContent.Controls.Add(uc);
            uc.BringToFront();
        }
    }
}
