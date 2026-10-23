using System;
using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RestaurantManagement.WPF.Models
{
    public partial class StaffDisplayItem : ObservableObject
    {
        public string MaNV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; } = "Nam";
        public string SoDienThoai { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public string VaiTro { get; set; } = "Phục Vụ";
        public string TrangThai { get; set; } = "Đang làm";
        public string TenDangNhap { get; set; } = string.Empty;

        public string NgaySinhFormatted => NgaySinh != DateTime.MinValue ? NgaySinh.ToString("dd/MM/yyyy") : "--";

        // Màu badge theo chức vụ
        public Brush RoleBadgeBg => VaiTro switch
        {
            "Quản Lý" => new SolidColorBrush(Color.FromRgb(254, 242, 242)),   // Đỏ nhạt
            "Thu Ngân" => new SolidColorBrush(Color.FromRgb(239, 246, 255)),  // Xanh dương nhạt
            "Đầu Bếp" => new SolidColorBrush(Color.FromRgb(255, 251, 235)),   // Vàng nhạt
            _ => new SolidColorBrush(Color.FromRgb(241, 245, 249))            // Xám nhạt
        };

        public Brush RoleBadgeForeground => VaiTro switch
        {
            "Quản Lý" => (Brush)Application.Current.Resources["TableOccupiedBrush"],
            "Thu Ngân" => (Brush)Application.Current.Resources["TableReservedBrush"],
            "Đầu Bếp" => (Brush)Application.Current.Resources["TableBillReadyBrush"],
            _ => (Brush)Application.Current.Resources["TextSecondaryBrush"]
        };
    }
}
