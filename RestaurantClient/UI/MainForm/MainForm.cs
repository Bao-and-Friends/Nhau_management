using RestaurantClient.Services;
using RestaurantClient.UI.Authentication;
using RestaurantShared.Models.SQLData;
using Sunny.UI;
using System.Text.Json;

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
            // 1. Khởi chạy đồng hồ thời gian thực
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            timer1.Interval = 1000;
            timer1.Start();

            //2.Lấy dữ liệu nhân viên an toàn từ this.Tag(không cần ép kiểu qua sender)
            if (this.Tag is StaffDATA nv)
            {
                IdentifyRole(nv.VaiTro);
                Ten.Text = nv.HoTen;
                chucVu.Text = nv.VaiTro;

                // Dùng Switch Expression kèm Trim() để chọn Icon và Màu sắc theo giới tính
                (int symbol, Color color) = (nv.GioiTinh?.Trim()) switch
                {
                    "Nam" => (61827, Color.FromArgb(74, 144, 226)),  // Icon Nam - Xanh dương
                    "Nữ" => (61826, Color.FromArgb(230, 73, 128)),  // Icon Nữ - Hồng
                    _ => (61447, Color.FromArgb(107, 114, 128))  // Mặc định: Icon User chung - Xám
                };

                GioiTinh.Symbol = symbol;
                GioiTinh.FillColor = color;
                GioiTinh.FillDisableColor = color;

                // Gợi ý: Có thể phân quyền ẩn/hiện nút Menu tại đây dựa vào nv.VaiTro
                // IdentifyRole(nv.VaiTro);
            }

            // 3. Hiển thị màn hình Sơ đồ bàn mặc định
            SwitchUserControl(new UC_SoDoBan());
        }


        //role permission
        private void IdentifyRole(string role)
        {
            // Ví dụ: Nút Trochuyen đổi thành nút Quản lý nhân viên/Tạo tài khoản
            // Chỉ hiển thị cho Quản lý
            
        }
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
            ApiService.Logout();
            this.Close();
        }

        private void Trochuyen_Click(object sender, EventArgs e)
        {
            var form = new RegisterAccountUI();
            form.ShowDialog();
        }
    }
}