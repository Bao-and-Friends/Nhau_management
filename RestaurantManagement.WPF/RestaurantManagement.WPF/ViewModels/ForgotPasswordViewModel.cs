using System;
using System.Data;
using System.Windows;
using System.Windows.Threading;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using RestaurantShared.DAO;

namespace RestaurantManagement.WPF.ViewModels
{
    public partial class ForgotPasswordViewModel : BaseViewModel
    {
        // 1: Nhập SĐT, 2: Nhập OTP, 3: Đổi mật khẩu, 4: Thành công
        [ObservableProperty]
        private int _step = 1;

        [ObservableProperty]
        private string _phoneNumber = string.Empty;

        [ObservableProperty]
        private string _staffName = string.Empty;

        [ObservableProperty]
        private string _username = string.Empty;

        [ObservableProperty]
        private string _generatedOtp = string.Empty;

        [ObservableProperty]
        private string _otpInput = string.Empty;

        [ObservableProperty]
        private string _newPassword = string.Empty;

        [ObservableProperty]
        private string _confirmPassword = string.Empty;

        [ObservableProperty]
        private string _simulatedSmsMessage = string.Empty;

        [ObservableProperty]
        private string _countdownText = "02:00";

        [ObservableProperty]
        private string _errorMessage = string.Empty;

        [ObservableProperty]
        private bool _hasError = false;

        [ObservableProperty]
        private bool _canResendOtp = false;

        private DispatcherTimer? _timer;
        private int _countdownSeconds = 120;

        // BƯỚC 1: GỬI MÃ OTP VỀ SỐ ĐIỆN THOẠI
        [RelayCommand]
        private void SendOtp()
        {
            HasError = false;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(PhoneNumber))
            {
                HasError = true;
                ErrorMessage = "Vui lòng nhập số điện thoại!";
                return;
            }

            try
            {
                DataRow? row = AccountDAO.Instance.FindAccountByPhone(PhoneNumber.Trim());
                if (row == null)
                {
                    HasError = true;
                    ErrorMessage = "Không tìm thấy nhân viên nào với số điện thoại này!";
                    return;
                }

                StaffName = row["HoTen"]?.ToString() ?? "Nhân viên";
                Username = row["TenDangNhap"]?.ToString() ?? "";

                // Sinh mã OTP ngẫu nhiên 6 số
                GeneratedOtp = Random.Shared.Next(100000, 999999).ToString();

                // Giả lập tin nhắn SMS gửi về máy
                SimulatedSmsMessage = $"📲 [SMS GATEWAY] Xin chào {StaffName}! Mã xác thực OTP của bạn là: {GeneratedOtp}. Hiệu lực trong 2 phút.";

                // Bắt đầu đếm ngược 120 giây
                StartCountdown();

                Step = 2;
            }
            catch (Exception ex)
            {
                HasError = true;
                ErrorMessage = "Lỗi truy vấn: " + ex.Message;
            }
        }

        // BƯỚC 2: XÁC THỰC MÃ OTP
        [RelayCommand]
        private void VerifyOtp()
        {
            HasError = false;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(OtpInput))
            {
                HasError = true;
                ErrorMessage = "Vui lòng nhập mã OTP 6 chữ số!";
                return;
            }

            if (OtpInput.Trim() != GeneratedOtp)
            {
                HasError = true;
                ErrorMessage = "Mã OTP không chính xác, vui lòng thử lại!";
                return;
            }

            // OTP đúng -> Dừng đếm ngược và sang Bước 3
            _timer?.Stop();
            Step = 3;
        }

        // GỬI LẠI MÃ OTP
        [RelayCommand]
        private void ResendOtp()
        {
            GeneratedOtp = Random.Shared.Next(100000, 999999).ToString();
            SimulatedSmsMessage = $"📲 [SMS GATEWAY] Mã OTP mới của bạn là: {GeneratedOtp}. Hiệu lực trong 2 phút.";
            StartCountdown();
        }

        // BƯỚC 3: ĐẶT LẠI MẬT KHẨU MỚI
        [RelayCommand]
        private void ResetPassword()
        {
            HasError = false;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(NewPassword) || NewPassword.Length < 6)
            {
                HasError = true;
                ErrorMessage = "Mật khẩu mới phải có ít nhất 6 ký tự!";
                return;
            }

            if (NewPassword != ConfirmPassword)
            {
                HasError = true;
                ErrorMessage = "Xác nhận mật khẩu không khớp!";
                return;
            }

            try
            {
                bool success = AccountDAO.Instance.UpdatePassword(Username, NewPassword);
                if (success)
                {
                    Step = 4; // Hoàn tất thành công
                }
                else
                {
                    HasError = true;
                    ErrorMessage = "Không thể cập nhật mật khẩu. Vui lòng thử lại!";
                }
            }
            catch (Exception ex)
            {
                HasError = true;
                ErrorMessage = "Lỗi khi cập nhật CSDL: " + ex.Message;
            }
        }

        private void StartCountdown()
        {
            _countdownSeconds = 120;
            CanResendOtp = false;
            CountdownText = "02:00";

            _timer?.Stop();
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += (s, e) =>
            {
                _countdownSeconds--;
                int minutes = _countdownSeconds / 60;
                int seconds = _countdownSeconds % 60;
                CountdownText = $"{minutes:D2}:{seconds:D2}";

                if (_countdownSeconds <= 0)
                {
                    _timer.Stop();
                    CanResendOtp = true;
                    CountdownText = "Hết hạn";
                }
            };
            _timer.Start();
        }

        [RelayCommand]
        private void Close(Window window)
        {
            _timer?.Stop();
            window?.Close();
        }
    }
}
