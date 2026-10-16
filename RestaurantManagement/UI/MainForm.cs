using System;
using System.Drawing;
using System.Windows.Forms;
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
        public MainForm(string tenNhanVien, string tenChucVu, string maVaiTro) : this()
        {
            // 1. Cập nhật thông tin lên Header
            Ten.Text = tenNhanVien;
            chucVu.Text = tenChucVu;

            // 2. Áp dụng phân quyền hiển thị nút trên Sidebar
            ApplyRolePermissions(maVaiTro);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            timer1.Interval = 1000;
            timer1.Start();

            // Mặc định vừa mở phần mềm là hiện ngay Sơ đồ bàn
            SwitchUserControl(new UC_SoDoBan());
        }

        /// <summary>
        /// Phân quyền các nút Sidebar theo từng vai trò (Tự động dồn nút lên khi ẩn)
        /// </summary>
        public void ApplyRolePermissions(string maVaiTro)
        {
            // 1. Mặc định bật tất cả các nút và panel
            btnSoDoBan.Visible = true;
            btnMonAn.Visible = true;
            btnHoaDon.Visible = true;
            btnThanhToan.Visible = true;
            btnKho.Visible = true;
            btnNhanVien.Visible = true;
            btnBaoCao.Visible = true;
            b.Visible = true;
            c.Visible = true;
            d.Visible = true;
            e.Visible = true;
            f.Visible = true;
            g.Visible = true;
            // 2. Phân quyền theo từng vai trò cụ thể
            switch (maVaiTro)
            {
                case "VT02": // PHỤC VỤ (Chỉ hiện: Sơ đồ bàn & Món ăn)
                             // Ẩn 5 nút không thuộc quyền
                    btnHoaDon.Visible = false;
                    btnThanhToan.Visible = false;
                    btnKho.Visible = false;
                    btnNhanVien.Visible = false;
                    btnBaoCao.Visible = false;
                    // Giữa "Sơ đồ bàn" và "Món ăn" chỉ cần DUY NHẤT 1 đệm b = true:
                    b.Visible = true;   // <-- BẬT ĐỆM NÀY ĐỂ TÁCH 2 NÚT RA!
                    c.Visible = false;  // Tắt để không bị dồn
                    d.Visible = false;  // Tắt để không bị dồn
                    e.Visible = false;
                    f.Visible = false;
                    g.Visible = false;
                    break;
                case "VT03": // THU NGÂN (Hiện: Sơ đồ bàn, Hóa đơn, Thanh toán, Món ăn)
                    btnKho.Visible = false;
                    btnNhanVien.Visible = false;
                    btnBaoCao.Visible = false;
                    // 4 nút này đứng liền nhau nên cần 3 đệm giữa chúng:
                    b.Visible = true;
                    c.Visible = true;
                    d.Visible = true;
                    // Tắt các đệm phía sau
                    e.Visible = false;
                    f.Visible = false;
                    g.Visible = false;
                    break;
                case "VT01": // QUẢN LÝ (Hiện tất cả 7 nút)
                             // Cả 7 nút đều hiện nên giữ nguyên tất cả panel đệm b, c, d, e, f, g = true
                    break;
            }
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
            this.Close();
        }

        private void btnSoDoBan_Click_1(object sender, EventArgs e)
        {
            SwitchUserControl(new UC_SoDoBan());
        }

        private void panelContent_Click(object sender, EventArgs e)
        {

        }
    }
}