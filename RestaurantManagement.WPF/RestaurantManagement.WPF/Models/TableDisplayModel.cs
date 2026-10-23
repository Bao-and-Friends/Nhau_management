using System.Windows;
using System.Windows.Media;
using CommunityToolkit.Mvvm.ComponentModel;

namespace RestaurantManagement.WPF.Models
{
    public partial class TableDisplayModel : ObservableObject
    {
        public string MaBan { get; set; } = string.Empty;
        public string TenBan { get; set; } = string.Empty;
        public int SucChua { get; set; }
        public string KhuVuc { get; set; } = "Tầng 1";

        [ObservableProperty]
        [NotifyPropertyChangedFor(nameof(StatusBrush))]
        [NotifyPropertyChangedFor(nameof(StatusBadgeBg))]
        private string _trangThai = "Trống";

        [ObservableProperty]
        private string _thoiGianVao = string.Empty;

        [ObservableProperty]
        private decimal _tamTinh = 0;

        public string TamTinhFormatted => TamTinh > 0 ? $"{TamTinh:N0} đ" : "0 đ";

        // Hàm chuẩn hóa chuỗi trạng thái không sợ chữ hoa/thường hay khoảng trắng
        public static string NormalizeStatus(string? status)
        {
            if (string.IsNullOrWhiteSpace(status)) return "Trống";
            string s = status.Trim().ToLower();
            if (s.Contains("khách")) return "Có Khách";
            if (s.Contains("đặt")) return "Đã Đặt";
            if (s.Contains("dọn") || s.Contains("thanh toán")) return "Chờ Dọn";
            return "Trống";
        }

        // Tự động trả về Màu sắc trạng thái tương ứng
        public Brush StatusBrush
        {
            get
            {
                string norm = NormalizeStatus(TrangThai);
                return norm switch
                {
                    "Có Khách" => (Brush)Application.Current.Resources["TableOccupiedBrush"],
                    "Đã Đặt" => (Brush)Application.Current.Resources["TableReservedBrush"],
                    "Chờ Dọn" => (Brush)Application.Current.Resources["TableBillReadyBrush"],
                    _ => (Brush)Application.Current.Resources["TableAvailableBrush"]
                };
            }
        }

        // Màu nền nhạt cho Badge trạng thái
        public Brush StatusBadgeBg
        {
            get
            {
                string norm = NormalizeStatus(TrangThai);
                return norm switch
                {
                    "Có Khách" => new SolidColorBrush(Color.FromRgb(254, 242, 242)),   // Đỏ nhạt
                    "Đã Đặt" => new SolidColorBrush(Color.FromRgb(239, 246, 255)),     // Xanh dương nhạt
                    "Chờ Dọn" => new SolidColorBrush(Color.FromRgb(255, 251, 235)),    // Vàng nhạt
                    _ => new SolidColorBrush(Color.FromRgb(236, 253, 245))            // Xanh ngọc nhạt
                };
            }
        }
    }
}