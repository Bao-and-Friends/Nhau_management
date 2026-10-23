using RestaurantShared.DTO;

namespace RestaurantManagement.WPF.Models
{
    public static class UserSession
    {
        // Thông tin nhân viên đang đăng nhập trong phiên làm việc
        public static NhanVienDATA? CurrentStaff { get; set; }

        // Kiểm tra xem người dùng có quyền Quản lý hay không
        public static bool IsManager => CurrentStaff?.VaiTro?.Contains("Quản", System.StringComparison.OrdinalIgnoreCase) == true;

        // Xóa phiên làm việc khi đăng xuất
        public static void Clear()
        {
            CurrentStaff = null;
        }
    }
}
