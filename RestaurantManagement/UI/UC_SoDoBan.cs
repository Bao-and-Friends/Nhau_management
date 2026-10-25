using RestaurantShared.DTO;
using Sunny.UI;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace RestaurantManagement.UI
{
    public partial class UC_SoDoBan : UserControl
    {
        public UC_SoDoBan()
        {
            InitializeComponent();
            //LoadTable();
        }
        public static readonly int TableHeight = 200;
        public static readonly int TableWidth = 200;
        //private void LoadTable()
        //{
        //    List<TableDATA> listtable = TableDAO.Instance.GetListTable();
        //    foreach (TableDATA ban in listtable)
        //    {
        //        UIButton btn = new UIButton() { Width = TableWidth, Height = TableHeight, ForeColor = Color.White, RectColor = Color.FromArgb(243, 249, 255) };
        //        btn.Text = ban.TenBan + Environment.NewLine + ban.TrangThai;
        //        btn.Tag = ban;
        //        switch (ban.TrangThai)
        //        {
        //            case "Trống":
        //                btn.FillColor = Color.Silver;
        //                break;

        //            case "Có Khách":
        //                btn.FillColor = Color.FromArgb(46, 173, 114);
        //                break;

        //            case "Đã Đặt":
        //                btn.FillColor = Color.FromArgb(74, 144, 226);
        //                break;

        //            case "Chờ Dọn":
        //                btn.FillColor = Color.DarkRed;
        //                break;
        //        }
        //        btn.Click += btnban_click;
        //        fplSoDoBan.Add(btn);
        //    }
        //}
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
            string trangThai = ban.TrangThai?.Trim() ?? "Trống";

            // 3. Hiển thị thông tin Sức chứa + Giờ bắt đầu (chỉ hiện giờ khi bàn Có Khách / Đã Đặt)
            // Giả sử bạn thêm thuộc tính GioVao (DateTime?) vào TableDATA, hoặc tạm để chuỗi nếu chưa có
            if (trangThai == "Có Khách" || trangThai == "Đã Đặt")
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
                "Có Khách" => (Color.FromArgb(209, 250, 229), Color.FromArgb(6, 95, 70)),   // Xanh lá (Emerald)
                "Đã Đặt" => (Color.FromArgb(219, 234, 254), Color.FromArgb(30, 64, 175)),  // Xanh dương (Blue)
                "Chờ Dọn" => (Color.FromArgb(254, 226, 226), Color.FromArgb(153, 27, 27)),  // Đỏ nhạt (Red)
                _ => (Color.FromArgb(229, 231, 235), Color.FromArgb(55, 65, 81))    // Mặc định: Trống (Gray)
            };

            // 5. Gán trạng thái và màu sắc 1 lần duy nhất
            status.Text = trangThai;
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
