using System;
using System.Windows;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagement.WPF.Models;

namespace RestaurantManagement.WPF.ViewModels
{
    public partial class MainViewModel : BaseViewModel
    {
        // View đang hiển thị ở vùng trung tâm
        [ObservableProperty]
        private BaseViewModel? _currentViewModel;

        // Thông tin hiển thị trên Header
        [ObservableProperty]
        private string _employeeName = "Nguyễn Văn A";

        [ObservableProperty]
        private string _role = "Thu Ngân";

        // Quyền Quản lý (dùng để ẩn/hiện menu Quản lý & Đăng ký nhân viên)
        [ObservableProperty]
        private bool _isManagerRole = false;

        [ObservableProperty]
        private string _currentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");

        [ObservableProperty]
        private bool _isConnected = true;

        [ObservableProperty]
        private string _selectedNavTab = "SoDoBan";

        private readonly DispatcherTimer _timer;
        private readonly TableManagementViewModel _tableManagementViewModel = new();
        private StaffManagementViewModel? _staffManagementViewModel;

        public MainViewModel()
        {
            // Đồng hồ thời gian thực cập nhật mỗi giây
            _timer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(1)
            };
            _timer.Tick += (s, e) =>
            {
                CurrentTime = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss");
            };
            _timer.Start();

            // Mặc định nạp Sơ đồ bàn
            CurrentViewModel = _tableManagementViewModel;
        }

        // Lệnh chuyển Tab từ Sidebar
        [RelayCommand]
        private void Navigate(string destination)
        {
            SelectedNavTab = destination;

            if (destination == "SoDoBan")
            {
                CurrentViewModel = _tableManagementViewModel;
            }
            else if (destination == "NhanVien")
            {
                // Chỉ Quản lý mới vào được
                if (IsManagerRole)
                {
                    _staffManagementViewModel ??= new StaffManagementViewModel();
                    _staffManagementViewModel.LoadStaffList();
                    CurrentViewModel = _staffManagementViewModel;
                }
                else
                {
                    MessageBox.Show("Bạn không có quyền quản trị nhân sự!", "Từ chối truy cập", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
        }

        // Lệnh Đăng xuất chuẩn
        [RelayCommand]
        private void Logout()
        {
            var result = MessageBox.Show(
                "Bạn có chắc chắn muốn kết thúc ca làm việc và đăng xuất không?",
                "Xác nhận đăng xuất",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                UserSession.Clear();
                var loginWindow = new Views.LoginWindow();
                loginWindow.Show();

                foreach (Window window in Application.Current.Windows)
                {
                    if (window is MainWindow)
                    {
                        window.Close();
                        break;
                    }
                }
            }
        }
    }
}
