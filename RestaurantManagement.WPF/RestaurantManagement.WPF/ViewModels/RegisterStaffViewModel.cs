using System;
using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantShared.DAO;
using RestaurantShared.DTO;

namespace RestaurantManagement.WPF.ViewModels
{
    public partial class RegisterStaffViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _maNV = string.Empty;

        [ObservableProperty]
        private string _hoTen = string.Empty;

        [ObservableProperty]
        private DateTime _ngaySinh = new(2000, 1, 1);

        [ObservableProperty]
        private string _gioiTinh = "Nam";

        [ObservableProperty]
        private string _soDienThoai = string.Empty;

        [ObservableProperty]
        private string _diaChi = string.Empty;

        [ObservableProperty]
        private string _vaiTro = "Phục Vụ";

        [ObservableProperty]
        private string _tenDangNhap = string.Empty;

        [ObservableProperty]
        private string _matKhau = "123456";

        [ObservableProperty]
        private string _confirmMatKhau = "123456";

        [ObservableProperty]
        private string _errorMessage = string.Empty;

        [ObservableProperty]
        private bool _hasError = false;

        public ObservableCollection<string> RolesList { get; } = new()
        {
            "Phục Vụ",
            "Thu Ngân",
            "Đầu Bếp",
            "Quản Lý"
        };

        public ObservableCollection<string> GendersList { get; } = new()
        {
            "Nam",
            "Nữ"
        };

        public RegisterStaffViewModel()
        {
            // Tự động sinh mã nhân viên tiếp theo
            MaNV = NhanVienDAO.Instance.GetNextStaffCode();
        }

        [RelayCommand]
        private void RegisterStaff(Window window)
        {
            HasError = false;
            ErrorMessage = string.Empty;

            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(HoTen))
            {
                HasError = true;
                ErrorMessage = "Vui lòng nhập Họ và tên nhân viên!";
                return;
            }

            if (string.IsNullOrWhiteSpace(SoDienThoai))
            {
                HasError = true;
                ErrorMessage = "Vui lòng nhập Số điện thoại nhân viên!";
                return;
            }

            if (string.IsNullOrWhiteSpace(TenDangNhap))
            {
                HasError = true;
                ErrorMessage = "Vui lòng nhập Tên đăng nhập tài khoản!";
                return;
            }

            if (string.IsNullOrWhiteSpace(MatKhau) || MatKhau.Length < 6)
            {
                HasError = true;
                ErrorMessage = "Mật khẩu phải có ít nhất 6 ký tự!";
                return;
            }

            if (MatKhau != ConfirmMatKhau)
            {
                HasError = true;
                ErrorMessage = "Xác nhận mật khẩu không khớp!";
                return;
            }

            try
            {
                var nv = new NhanVienDATA(
                    maNV: MaNV.Trim(),
                    hoTen: HoTen.Trim(),
                    ngaySinh: NgaySinh,
                    gioiTinh: GioiTinh,
                    soDienThoai: SoDienThoai.Trim(),
                    diaChi: DiaChi.Trim(),
                    vaiTro: VaiTro,
                    trangThai: "Đang làm"
                );

                bool success = AccountDAO.Instance.CreateStaffAndAccount(nv, TenDangNhap.Trim(), MatKhau.Trim(), out string error);

                if (success)
                {
                    MessageBox.Show(
                        $"Đăng ký thành công nhân viên: {HoTen}\nTài khoản: {TenDangNhap}\nMật khẩu khởi tạo: {MatKhau}",
                        "Thành công",
                        MessageBoxButton.OK,
                        MessageBoxImage.Information);

                    window?.Close();
                }
                else
                {
                    HasError = true;
                    ErrorMessage = error;
                }
            }
            catch (Exception ex)
            {
                HasError = true;
                ErrorMessage = "Lỗi khi lưu vào CSDL: " + ex.Message;
            }
        }

        [RelayCommand]
        private void Close(Window window)
        {
            window?.Close();
        }
    }
}
