using System;
using System.Collections.ObjectModel;
using System.Data;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagement.WPF.Models;
using RestaurantManagement.WPF.Views;
using RestaurantShared.DAO;

namespace RestaurantManagement.WPF.ViewModels
{
    public partial class StaffManagementViewModel : BaseViewModel
    {
        [ObservableProperty]
        private ObservableCollection<StaffDisplayItem> _staffList = new();

        [ObservableProperty]
        private StaffDisplayItem? _selectedStaff;

        [ObservableProperty]
        private int _totalStaffCount = 0;

        public StaffManagementViewModel()
        {
            LoadStaffList();
        }

        [RelayCommand]
        public void LoadStaffList()
        {
            StaffList.Clear();

            try
            {
                DataTable table = NhanVienDAO.Instance.GetListNhanVienWithAccount();
                foreach (DataRow row in table.Rows)
                {
                    StaffList.Add(new StaffDisplayItem
                    {
                        MaNV = row["MaNV"]?.ToString() ?? "",
                        HoTen = row["HoTen"]?.ToString() ?? "",
                        NgaySinh = row["NgaySinh"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgaySinh"]),
                        GioiTinh = row["GioiTinh"]?.ToString() ?? "Nam",
                        SoDienThoai = row["SoDienThoai"]?.ToString() ?? "",
                        DiaChi = row["DiaChi"]?.ToString() ?? "",
                        VaiTro = row["VaiTro"]?.ToString() ?? "Phục Vụ",
                        TrangThai = row["TrangThai"]?.ToString() ?? "Đang làm",
                        TenDangNhap = row["TenDangNhap"]?.ToString() ?? "--"
                    });
                }
            }
            catch
            {
                // Fallback nếu CSDL có sự cố
            }

            TotalStaffCount = StaffList.Count;
        }

        // Mở cửa sổ Đăng ký nhân viên mới (Chỉ dành cho Quản lý)
        [RelayCommand]
        private void OpenRegisterDialog()
        {
            var dialog = new RegisterStaffDialog();
            dialog.ShowDialog();

            // Tải lại danh sách sau khi thêm mới
            LoadStaffList();
        }
    }
}
