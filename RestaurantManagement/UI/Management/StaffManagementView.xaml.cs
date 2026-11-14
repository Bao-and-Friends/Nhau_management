using System.Windows.Controls;
using RestaurantShared.Models.SQLData;

namespace RestaurantClient.UI.Management
{
    public partial class StaffManagementView : UserControl
    {
        public StaffManagementView()
        {
            InitializeComponent();
            dgStaff.ItemsSource = new List<StaffDATA>
            {
                new() { MaNV = "NV01", HoTen = "Nguyễn Quốc Huy", VaiTro = "Quản Lý", GioiTinh = "Nam", SoDienThoai = "0901234567", TrangThai = "Hoạt động" },
                new() { MaNV = "NV02", HoTen = "Trần Trí Bảo", VaiTro = "Bếp Trưởng", GioiTinh = "Nam", SoDienThoai = "0912345678", TrangThai = "Hoạt động" },
                new() { MaNV = "NV03", HoTen = "Lê Dương Bảo", VaiTro = "Thu Ngân", GioiTinh = "Nam", SoDienThoai = "0923456789", TrangThai = "Hoạt động" },
                new() { MaNV = "NV04", HoTen = "Phạm Thị Mai", VaiTro = "Phục Vụ", GioiTinh = "Nữ", SoDienThoai = "0934567890", TrangThai = "Hoạt động" }
            };
        }
    }
}
