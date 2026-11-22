using System.Windows;
using RestaurantModern.Services;
using RestaurantModern.ViewModels;

namespace RestaurantModern;

public partial class AuthWindow : Window
{
    private readonly IApiService _api;
    private readonly AuthViewModel _vm;

    public AuthWindow() : this(new ApiService()) { }

    public AuthWindow(IApiService api)
    {
        InitializeComponent();
        _api = api;
        _vm = new AuthViewModel(_api, OnLoginSuccess);
        DataContext = _vm;
        TxtPassword.Password = _vm.Password ?? string.Empty;

        TxtPassword.PasswordChanged += (s, e) =>
        {
            if (_vm.Password != TxtPassword.Password)
                _vm.Password = TxtPassword.Password;
        };

        _vm.PropertyChanged += (s, e) =>
        {
            if (e.PropertyName == nameof(AuthViewModel.Password))
            {
                if (TxtPassword.Password != _vm.Password)
                    TxtPassword.Password = _vm.Password ?? string.Empty;
            }
            else if (e.PropertyName == nameof(AuthViewModel.CurrentStep))
            {
                UpdateStepVisibility(_vm.CurrentStep);
            }
        };
    }

    private void UpdateStepVisibility(string step)
    {
        LoginPanel.Visibility = step == "Login" ? Visibility.Visible : Visibility.Collapsed;
        ForgotPanel.Visibility = step == "Forgot" ? Visibility.Visible : Visibility.Collapsed;
        OtpPanel.Visibility = step == "Otp" ? Visibility.Visible : Visibility.Collapsed;
        ResetPanel.Visibility = step == "Reset" ? Visibility.Visible : Visibility.Collapsed;
        SuccessPanel.Visibility = step == "Success" ? Visibility.Visible : Visibility.Collapsed;
    }

    private void OnLoginSuccess()
    {
        Dispatcher.Invoke(() =>
        {
            var mainWindow = new MainWindow(_api);
            mainWindow.Show();
            Close();
        });
    }

    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        _vm.Password = TxtPassword.Password;
        _vm.LoginCommand.Execute(null);
    }

    private void GoForgot_Click(object sender, RoutedEventArgs e)
    {
        _vm.CurrentStep = "Forgot";
        _vm.ErrorMessage = string.Empty;
    }

    private void GoLogin_Click(object sender, RoutedEventArgs e)
    {
        _vm.CurrentStep = "Login";
        _vm.ErrorMessage = string.Empty;
    }

    private void SendOtp_Click(object sender, RoutedEventArgs e)
    {
        _vm.SendOtpCommand.Execute(null);
    }

    private void VerifyOtp_Click(object sender, RoutedEventArgs e)
    {
        _vm.VerifyOtpCommand.Execute(null);
    }

    private void ResetPassword_Click(object sender, RoutedEventArgs e)
    {
        _vm.ResetPasswordCommand.Execute(null);
    }
}
