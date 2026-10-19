using RestaurantShared.DAO;
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
            LoadTable();
        }

        private void LoadTable()
        {
            List<TableDATA> listtable = TableDAO.Instance.GetListTable();
            foreach (TableDATA ban in listtable)
            {
                UIButton btn = new UIButton() { Width = TableDATA.TableWidth, Height = TableDATA.TableHeight, ForeColor = Color.White, RectColor = Color.FromArgb(243, 249, 255) };
                btn.Text = ban.TenBan + Environment.NewLine + ban.TrangThai;
                btn.Tag = ban;
                switch (ban.TrangThai)
                {
                    case "Trống":
                        btn.FillColor = Color.Silver;
                        break;

                    case "Có Khách":
                        btn.FillColor = Color.FromArgb(46, 173, 114);
                        break;

                    case "Đã Đặt":
                        btn.FillColor = Color.FromArgb(74, 144, 226);
                        break;

                    case "Chờ Dọn":
                        btn.FillColor = Color.DarkRed;
                        break;
                }
                btn.Click += btnban_click;
                fplSoDoBan.Add(btn);
            }
        }
        private void ShowBill(string tableid)
        {

        }
        private void btnban_click(object? sender, EventArgs e)
        {
            Sodoban.Panel2Collapsed = false;
            TableDATA ban = (sender as UIButton).Tag as TableDATA;
            TenBan.Text = ban.TenBan;
            info.Text = "Sức chứa: " + ban.SucChua.ToString() + " người · Bắt Đầu: 10:15";//Bổ sung thêm giờ check in
            switch (ban.TrangThai?.Trim())
            {
                case "Trống":
                    status.Text = "Trống";
                    status.FillColor = Color.FromArgb(229, 231, 235);
                    status.FillDisableColor = Color.FromArgb(229, 231, 235);
                    status.ForeColor = Color.FromArgb(55, 65, 81);
                    status.ForeDisableColor = Color.FromArgb(55, 65, 81);
                    break;

                case "Có Khách":
                    status.Text = "Có Khách";
                    status.FillColor = Color.FromArgb(209, 250, 229);
                    status.FillDisableColor = Color.FromArgb(209, 250, 229);
                    status.ForeColor = Color.FromArgb(6, 95, 70);
                    status.ForeDisableColor = Color.FromArgb(6, 95, 70);
                    break;

                case "Đã Đặt":
                    status.Text = "Đã Đặt";
                    status.FillColor = Color.FromArgb(219, 234, 254);
                    status.FillDisableColor = Color.FromArgb(219, 234, 254);
                    status.ForeColor = Color.FromArgb(30, 64, 175);
                    status.ForeDisableColor = Color.FromArgb(30, 64, 175);
                    break;

                case "Chờ Dọn":
                    status.Text = "Chờ Dọn";
                    status.FillColor = Color.FromArgb(254, 226, 226);
                    status.FillDisableColor = Color.FromArgb(254, 226, 226);
                    status.ForeColor = Color.FromArgb(153, 27, 27);
                    status.ForeDisableColor = Color.FromArgb(153, 27, 27);
                    break;
            }
        }

        private void hidebtn_Click(object sender, EventArgs e)
        {
            Sodoban.Panel2Collapsed = true;
        }
    }
}
