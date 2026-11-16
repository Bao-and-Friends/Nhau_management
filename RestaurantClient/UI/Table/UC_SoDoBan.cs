using RestaurantClient.Services;
using RestaurantShared.Models.SQLData;
using Sunny.UI;

namespace RestaurantManagement.UI
{
    public partial class UC_SoDoBan : UserControl
    {
        public UC_SoDoBan()
        {
            InitializeComponent();
            LoadTable();
        }
        public static readonly int TableHeight = 200;
        public static readonly int TableWidth = 200;
        private async void LoadTable()
        {

            // Đọc dữ liệu nhân viên từ phản hồi của Server
            List<TableDATA>? listtable = await ApiService.GetTablesAsync();
            if (listtable != null)
            {
                foreach (TableDATA ban in listtable)
                {
                    UIButton btn = new UIButton() { Width = TableWidth, Height = TableHeight, ForeColor = Color.White, RectColor = Color.FromArgb(243, 249, 255) };
                    string trangthai_VN = ban.TrangThai switch// biến định dạng chữ enum thành chữ tiếng việt cho đẹp
                    {
                        TableStatus.DA_DAT => "Đã Đặt",
                        TableStatus.CO_KHACH => "Có Khách",
                        TableStatus.CHO_DON => "Chờ Dọn",
                        _ => "Trống"
                    };
                    btn.Text = ban.TenBan + Environment.NewLine + trangthai_VN;
                    btn.Tag = ban;
                    switch (ban.TrangThai)
                    {
                        case TableStatus.TRONG:
                            btn.FillColor = Color.Silver;
                            break;

                        case TableStatus.CO_KHACH:
                            btn.FillColor = Color.FromArgb(46, 173, 114);
                            break;

                        case TableStatus.DA_DAT:
                            btn.FillColor = Color.FromArgb(74, 144, 226);
                            break;

                        case TableStatus.CHO_DON:
                            btn.FillColor = Color.DarkRed;
                            break;
                    }
                    btn.Click += btnban_click;
                    fplSoDoBan.Add(btn);
                }
            }
        }
        private void ShowBill(string tableid)
        {

        }
        private void btnban_click(object? sender, EventArgs e)
        {
            // 1. Kiểm tra ép kiểu an toàn tuyệt đối (tránh NullReferenceException)
            if (sender is not UIButton { Tag: TableDATA ban })
                return;

            Sodoban.Panel2Collapsed = false;
            TenBan.Text = ban.TenBan;

            // 2. Xác định trạng thái chuẩn hóa
            TableStatus trangThai = ban.TrangThai;

            // 3. Hiển thị thông tin Sức chứa + Giờ bắt đầu (chỉ hiện giờ khi bàn Có Khách / Đã Đặt)
            if (trangThai == TableStatus.CO_KHACH || trangThai == TableStatus.DA_DAT)
            {
                // Nếu TableDATA đã có thuộc tính GioVao: ban.GioVao?.ToString("HH:mm") ?? "--:--"
                string gioBatDau = "10:15"; // Thay bằng dữ liệu thực từ ban.GioVao hoặc Hóa đơn
                info.Text = $"Sức chứa: {ban.SucChua} người · Bắt đầu: {gioBatDau}";
            }
            else
            {
                info.Text = $"Sức chứa: {ban.SucChua} người";
            }

            // 4. Dùng Switch Expression chọn bộ màu (Nền, Chữ) gọn gàng
            (Color bgColor, Color textColor) = trangThai switch
            {
                TableStatus.CO_KHACH => (Color.FromArgb(209, 250, 229), Color.FromArgb(6, 95, 70)),   // Xanh lá (Emerald)
                TableStatus.DA_DAT => (Color.FromArgb(219, 234, 254), Color.FromArgb(30, 64, 175)),  // Xanh dương (Blue)
                TableStatus.CHO_DON => (Color.FromArgb(254, 226, 226), Color.FromArgb(153, 27, 27)),  // Đỏ nhạt (Red)
                _ => (Color.FromArgb(229, 231, 235), Color.FromArgb(55, 65, 81))    // Mặc định: Trống (Gray)
            };

            // 5. Gán trạng thái và màu sắc 1 lần duy nhất
            string trangthai_VN = ban.TrangThai switch// biến định dạng chữ enum thành chữ tiếng việt cho đẹp
            {
                TableStatus.DA_DAT => "Đã Đặt",
                TableStatus.CO_KHACH => "Có Khách",
                TableStatus.CHO_DON => "Chờ Dọn",
                _ => "Trống"
            };
            status.Text = trangthai_VN;
            status.FillColor = bgColor;
            status.FillDisableColor = bgColor;
            status.ForeColor = textColor;
            status.ForeDisableColor = textColor;

            // Lưu lại bàn đang chọn vào Tag của Panel2 để các nút "Gọi món", "Thanh toán" biết đang thao tác trên bàn nào
            Sodoban.Panel2.Tag = ban;
        }

        private void hidebtn_Click(object sender, EventArgs e)
        {
            Sodoban.Panel2Collapsed = true;
        }
    }
}
