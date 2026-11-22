using RestaurantModern.Services;
using RestaurantModern.ViewModels.Common;

namespace RestaurantModern.ViewModels;

public class AuthViewModel : ViewModelBase
{
    private readonly IApiService _api;
    private readonly Action _onLoginSuccess;

    private string _currentStep = "Login"; // "Login", "Forgot", "Otp", "Reset", "Success"
    private string _username = "";
    private string _password = "";
    private string _otpCode = "";
    private string _newPassword = "";
    private string _confirmPassword = "";
    private string _errorMessage = "";
    private bool _isSuccessMessage;
    private bool _isLoading;

    public string CurrentStep
    {
        get => _currentStep;
        set => SetProperty(ref _currentStep, value);
    }

    public string Username { get => _username; set => SetProperty(ref _username, value); }
    public string Password { get => _password; set => SetProperty(ref _password, value); }
    public string OtpCode { get => _otpCode; set => SetProperty(ref _otpCode, value); }
    public string NewPassword { get => _newPassword; set => SetProperty(ref _newPassword, value); }
    public string ConfirmPassword { get => _confirmPassword; set => SetProperty(ref _confirmPassword, value); }

    public string ErrorMessage
    {
        get => _errorMessage;
        set
        {
            if (SetProperty(ref _errorMessage, value))
            {
                OnPropertyChanged(nameof(HasAlert));
                OnPropertyChanged(nameof(AlertBackground));
                OnPropertyChanged(nameof(AlertBorder));
                OnPropertyChanged(nameof(AlertForeground));
                OnPropertyChanged(nameof(AlertIcon));
            }
        }
    }

    public bool IsSuccessMessage
    {
        get => _isSuccessMessage;
        set
        {
            if (SetProperty(ref _isSuccessMessage, value))
            {
                OnPropertyChanged(nameof(AlertBackground));
                OnPropertyChanged(nameof(AlertBorder));
                OnPropertyChanged(nameof(AlertForeground));
                OnPropertyChanged(nameof(AlertIcon));
            }
        }
    }

    public bool HasAlert => !string.IsNullOrWhiteSpace(ErrorMessage);
    public string AlertBackground => IsSuccessMessage ? "#DCFCE7" : "#FEE2E2";
    public string AlertBorder => IsSuccessMessage ? "#86EFAC" : "#FCA5A5";
    public string AlertForeground => IsSuccessMessage ? "#15803D" : "#B91C1C";
    public string AlertIcon => IsSuccessMessage ? "✓" : "⚠";

    public bool IsLoading { get => _isLoading; set => SetProperty(ref _isLoading, value); }

    public AsyncRelayCommand LoginCommand { get; }
    public AsyncRelayCommand SendOtpCommand { get; }
    public AsyncRelayCommand VerifyOtpCommand { get; }
    public AsyncRelayCommand ResetPasswordCommand { get; }
    public RelayCommand SwitchStepCommand { get; }
    public RelayCommand FillDemoCommand { get; }

    public AuthViewModel(IApiService api, Action onLoginSuccess)
    {
        _api = api;
        _onLoginSuccess = onLoginSuccess;

        SwitchStepCommand = new RelayCommand(p =>
        {
            if (p is string step)
            {
                CurrentStep = step;
                ErrorMessage = string.Empty;
                IsSuccessMessage = false;
            }
        });

        FillDemoCommand = new RelayCommand(p =>
        {
            if (p is string role)
            {
                if (role == "Quản lý") { Username = "QL01"; Password = "password123"; }
                else if (role == "Thu ngân") { Username = "TN01"; Password = "password123"; }
                else { Username = "nguyenvana"; Password = "password123"; }
                ErrorMessage = string.Empty;
            }
        });

        LoginCommand = new AsyncRelayCommand(async () =>
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                IsSuccessMessage = false;
                ErrorMessage = "Vui lòng nhập tên đăng nhập.";
                return;
            }

            IsLoading = true;
            ErrorMessage = string.Empty;
            try
            {
                var res = await _api.LoginAsync(Username, Password);
                if (res.IsSuccess)
                {
                    _onLoginSuccess();
                }
                else
                {
                    IsSuccessMessage = false;
                    ErrorMessage = res.Message ?? "Đăng nhập thất bại. Vui lòng kiểm tra lại tài khoản hoặc mật khẩu.";
                }
            }
            finally
            {
                IsLoading = false;
            }
        });

        SendOtpCommand = new AsyncRelayCommand(async () =>
        {
            if (string.IsNullOrWhiteSpace(Username))
            {
                IsSuccessMessage = false;
                ErrorMessage = "Vui lòng nhập tên đăng nhập.";
                return;
            }

            IsLoading = true;
            ErrorMessage = string.Empty;
            try
            {
                var res = await _api.ForgotPasswordAsync(Username);
                CurrentStep = "Otp";
                IsSuccessMessage = res.IsSuccess;
                ErrorMessage = res.Message ?? "Mã OTP đã được gửi đến email đăng ký của bạn.";
            }
            finally
            {
                IsLoading = false;
            }
        });

        VerifyOtpCommand = new AsyncRelayCommand(async () =>
        {
            if (string.IsNullOrWhiteSpace(OtpCode))
            {
                IsSuccessMessage = false;
                ErrorMessage = "Vui lòng nhập mã OTP gồm 6 chữ số.";
                return;
            }

            IsLoading = true;
            ErrorMessage = string.Empty;
            try
            {
                var res = await _api.VerifyOtpAsync(Username, OtpCode);
                if (res.IsSuccess)
                {
                    CurrentStep = "Reset";
                    IsSuccessMessage = true;
                    ErrorMessage = "Xác thực mã OTP thành công! Vui lòng thiết lập mật khẩu mới.";
                }
                else
                {
                    IsSuccessMessage = false;
                    ErrorMessage = res.Message ?? "Mã OTP không hợp lệ hoặc đã hết hạn.";
                }
            }
            finally
            {
                IsLoading = false;
            }
        });

        ResetPasswordCommand = new AsyncRelayCommand(async () =>
        {
            if (string.IsNullOrWhiteSpace(NewPassword))
            {
                IsSuccessMessage = false;
                ErrorMessage = "Vui lòng nhập mật khẩu mới.";
                return;
            }

            if (NewPassword.Length < 6)
            {
                IsSuccessMessage = false;
                ErrorMessage = "Mật khẩu mới phải có ít nhất 6 ký tự.";
                return;
            }

            if (NewPassword != ConfirmPassword)
            {
                IsSuccessMessage = false;
                ErrorMessage = "Mật khẩu xác nhận không trùng khớp.";
                return;
            }

            IsLoading = true;
            ErrorMessage = string.Empty;
            try
            {
                var res = await _api.ChangePasswordAsync(Username, NewPassword);
                if (res.IsSuccess)
                {
                    CurrentStep = "Success";
                    ErrorMessage = string.Empty;
                }
                else
                {
                    IsSuccessMessage = false;
                    ErrorMessage = res.Message ?? "Đổi mật khẩu thất bại. Vui lòng thử lại.";
                }
            }
            finally
            {
                IsLoading = false;
            }
        });
    }
}
