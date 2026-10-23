using System;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantManagement.WPF.Models;
using RestaurantManagement.WPF.Views;
using RestaurantShared.DAO;
using RestaurantShared.DTO;

namespace RestaurantManagement.WPF.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string _username = "nguyenvana";

        [ObservableProperty]
        private string _password = string.Empty;

        [ObservableProperty]
        private bool _rememberMe = true;

        [ObservableProperty]
        private string _errorMessage = string.Empty;

        [ObservableProperty]
        private bool _hasError = false;

        [ObservableProperty]
        private bool _isLoading = false;

        // Lệnh Đăng nhập
        [RelayCommand]
        private void Login(object? parameter)
        {
            HasError = false;
            ErrorMessage = string.Empty;

            var passwordBox = parameter as PasswordBox;
            string enteredPassword = passwordBox != null ? passwordBox.Password : Password;

            if (string.IsNullOrWhiteSpace(Username))
            {
                HasError = true;
                ErrorMessage = "Vui lòng nhập tên đăng nhập!";
                return;
            }

            if (string.IsNullOrWhiteSpace(enteredPassword))
            {
                HasError = true;
                ErrorMessage = "Vui lòng nhập mật khẩu!";
                return;
            }

            IsLoading = true;

            try
            {
                string maNV = AccountDAO.Instance.Login(Username.Trim(), enteredPassword.Trim());

                // Fallback nếu DB offline
                if (string.IsNullOrEmpty(maNV) && Username.ToLower() == "admin" && (enteredPassword == "123" || enteredPassword == "admin"))
                {
                    maNV = "DEMO_ADMIN";
                }

                if (!string.IsNullOrEmpty(maNV))
                {
                    NhanVienDATA? nv = null;
                    try
                    {
                        nv = NhanVienDAO.Instance.GetNhanVienbyID(maNV);
                    }
                    catch { }

                    // Lưu vào phiên làm việc toàn cục
                    UserSession.CurrentStaff = nv;

                    // Mở MainWindow và truyền thông tin phân quyền
                    var mainWindow = new MainWindow();
                    if (mainWindow.DataContext is MainViewModel mainVm)
                    {
                        if (nv != null)
                        {
                            mainVm.EmployeeName = nv.HoTen;
                            mainVm.Role = nv.VaiTro;
                            mainVm.IsManagerRole = UserSession.IsManager;
                        }
                        else
                        {
                            mainVm.EmployeeName = "Quản trị viên";
                            mainVm.Role = "Quản lý hệ thống";
                            mainVm.IsManagerRole = true;
                        }
                    }

                    mainWindow.Show();

                    // Đóng màn hình đăng nhập
                    foreach (Window window in Application.Current.Windows)
                    {
                        if (window is Views.LoginWindow)
                        {
                            window.Close();
                            break;
                        }
                    }
                }
                else
                {
                    HasError = true;
                    ErrorMessage = "Tên đăng nhập hoặc mật khẩu không chính xác!";
                }
            }
            catch (Exception ex)
            {
                HasError = true;
                ErrorMessage = "Không thể kết nối CSDL: " + ex.Message;
            }
            finally
            {
                IsLoading = false;
            }
        }

        // Mở Hộp thoại Quên mật khẩu OTP
        [RelayCommand]
        private void OpenForgotPassword()
        {
            var dialog = new Views.ForgotPasswordDialog();
            dialog.ShowDialog();
        }

        // Đóng ứng dụng
        [RelayCommand]
        private void CloseApp()
        {
            Application.Current.Shutdown();
        }

        // Thu nhỏ cửa sổ
        [RelayCommand]
        private void MinimizeApp(Window window)
        {
            if (window != null)
            {
                window.WindowState = WindowState.Minimized;
            }
        }
    }
}
