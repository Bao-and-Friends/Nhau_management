using System;
using System.Drawing;
using System.Windows.Forms;
using RestaurantShared.DAO;
using RestaurantShared.DTO;
using Sunny.UI;

namespace RestaurantManagement.UI
{
    public partial class MainForm : UIForm
    {
        // Khởi tạo mặc định
        public MainForm()
        {
            InitializeComponent();

        }

        // Khởi tạo có truyền thông tin từ màn hình Đăng nhập


        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            timer1.Interval = 1000;
            timer1.Start();

            NhanVienDATA nv = NhanVienDAO.Instance.GetNhanVienbyID((sender as MainForm).Tag as string);
            this.Tag = nv;
            chucVu.Text = nv.VaiTro;
            Ten.Text = nv.HoTen;
            switch (nv.GioiTinh)
            {
                case "Nam":
                    GioiTinh.Symbol = 61827;
                    GioiTinh.FillDisableColor = Color.FromArgb(74, 144, 226); // Xanh dương
                    break;

                case "Nữ":
                    GioiTinh.Symbol = 61826;
                    GioiTinh.FillDisableColor = Color.FromArgb(230, 73, 128); // Hồng
                    break;
            }


            // Mặc định vừa mở phần mềm là hiện ngay Sơ đồ bàn
            SwitchUserControl(new UC_SoDoBan());
        }

        /// <summary>
        /// Phân quyền các nút Sidebar theo từng vai trò (Tự động dồn nút lên khi ẩn)
        /// </summary>

        // Sự kiện click nút Sơ đồ bàn
        private void btnSoDoBan_Click(object sender, EventArgs e)
        {
            SwitchUserControl(new UC_SoDoBan());
        }

        // Hàm nạp trang UserControl vào vùng trung tâm
        private void SwitchUserControl(UserControl uc)
        {
            a.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            a.Controls.Add(uc);
            uc.BringToFront();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
        }

        private void DangXuat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

    }
}