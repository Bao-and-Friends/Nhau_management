using RestaurantManagement.UI.Network;
using RestaurantShared.DTO;
using Sunny.UI;
using System;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Text.Json;
using System.Windows.Forms;

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

            // 2. Lấy dữ liệu nhân viên an toàn từ this.Tag (không cần ép kiểu qua sender)
            if (this.Tag is NhanVienDATA nv)
            {
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

        private void MainForm_Close(object sender, EventArgs e)
        {
            TcpCustomer.Instance.DisConnectServer();
        }
        //role permission
        private void IdentifyRole(string manv)
        {

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

        private async void Trochuyen_Click(object sender, EventArgs e)
        {
         
            Trochuyen.Enabled = false;
            RegisterRequest request = new()
            {
                Username = "abc",
                Password = "Password123!",
                HoTen = "Lê Văn C",
                GioiTinh = "Nam",
                VaiTro = "Thu Ngân",
                NgaySinh = new DateTime(1999, 11, 20),
                SDT = "0938112233",
                Email = "levanc@quannhau.com",
                DiaChi = "Đông Hòa, Dĩ An, Bình Dương"
            };

            try
            {
                    NetworkPacket packet = new()
                    {
                        Action = NetworkAction.REGISTER,
                        Payload = JsonSerializer.Serialize(request)
                    };

                    var response = await TcpCustomer.Instance.SendRequestAndWaitResponseAsync(packet);

                    if (response != null)
                    {
                         MessageBox.Show(response.Message,"Thông báo");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"lỗi: {ex.ToString()}", "Thông báo");
            }
            finally
            {
                Trochuyen.Enabled = true;
            }
        }
     
    }
}