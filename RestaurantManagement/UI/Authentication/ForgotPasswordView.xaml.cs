using System;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Threading;
using RestaurantClient.Services;

namespace RestaurantClient.UI.Authentication
{
    public partial class ForgotPasswordView : UserControl
    {
        public event EventHandler? BackToLoginRequested;

        private string _currentEmail = string.Empty;
        private int _currentStep = 1;

        // OTP Timer & State
        private DispatcherTimer? _otpTimer;
        private int _remainingOtpSeconds = 60;
        private int _failedAttempts = 0;

        // Lockout Timer
        private DispatcherTimer? _lockoutTimer;
        private int _lockoutSeconds = 900; // 15 phút

        // Password visibility toggles
        private bool _isNewPasswordVisible = false;
        private bool _isConfirmPasswordVisible = false;

        public ForgotPasswordView()
        {
            InitializeComponent();
            GoToStep(1);
        }

        #region Navigation & Step Management

        public void ResetFlow()
        {
            StopAllTimers();
            _currentEmail = string.Empty;
            _failedAttempts = 0;
            txtEmail.Text = string.Empty;
            txtEmail.Tag = null;
            lblEmailHelper.Text = "Sử dụng địa chỉ thư điện tử liên kết với tài khoản.";
            lblEmailHelper.Foreground = (Brush)FindResource("ColorTextSecondary");
            ClearOtpBoxes();
            GoToStep(1);
        }

        private void GoToStep(int step)
        {
            _currentStep = step;
            pnlStep1.Visibility = step == 1 ? Visibility.Visible : Visibility.Collapsed;
            pnlStep2.Visibility = step == 2 ? Visibility.Visible : Visibility.Collapsed;
            pnlStep3.Visibility = step == 3 ? Visibility.Visible : Visibility.Collapsed;
            pnlStep4.Visibility = step == 4 ? Visibility.Visible : Visibility.Collapsed;

            switch (step)
            {
                case 1:
                    lblStatusIsland.Text = "KHÔI PHỤC MẬT KHẨU";
                    txtEmail.Focus();
                    break;

                case 2:
                    lblStatusIsland.Text = "XÁC MINH TÀI KHOẢN";
                    lblMaskedEmail.Text = MaskEmail(_currentEmail);
                    ClearOtpBoxes();
                    StartOtpCountdown();
                    txtOtp1.Focus();
                    break;

                case 3:
                    lblStatusIsland.Text = "ĐẶT LẠI MẬT KHẨU";
                    txtNewPassword.Password = string.Empty;
                    txtNewPasswordVisible.Text = string.Empty;
                    txtConfirmPassword.Password = string.Empty;
                    txtConfirmPasswordVisible.Text = string.Empty;
                    EvaluatePasswordStrength();
                    txtNewPassword.Focus();
                    break;

                case 4:
                    lblStatusIsland.Text = "KHÔI PHỤC THÀNH CÔNG";
                    break;
            }
        }

        private static string MaskEmail(string email)
        {
            if (string.IsNullOrWhiteSpace(email)) return "m***@nhahang.vn";
            int atIndex = email.IndexOf('@');
            if (atIndex > 1)
            {
                string namePart = email[..atIndex];
                string domainPart = email[atIndex..];
                string masked = namePart[0] + "***" + domainPart;
                return masked;
            }
            if (email.Length > 2)
            {
                return email[0] + "***" + email[^1];
            }
            return email + "***";
        }

        private void LinkBackToLogin_Click(object sender, MouseButtonEventArgs e)
        {
            StopAllTimers();
            BackToLoginRequested?.Invoke(this, EventArgs.Empty);
        }

        private void LinkBackToLogin_Click(object sender, RoutedEventArgs e)
        {
            StopAllTimers();
            BackToLoginRequested?.Invoke(this, EventArgs.Empty);
        }

        private void LinkChangeEmail_Click(object sender, MouseButtonEventArgs e)
        {
            StopAllTimers();
            GoToStep(1);
        }

        #endregion

        #region Step 1: Xác Định Tài Khoản

        private void TxtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            txtEmail.Tag = null;
            lblEmailHelper.Text = "Sử dụng địa chỉ thư điện tử liên kết với tài khoản.";
            lblEmailHelper.Foreground = (Brush)FindResource("ColorTextSecondary");
        }

        private void TxtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                BtnSendOtp_Click(btnSendOtp, new RoutedEventArgs());
            }
        }

        private async void BtnSendOtp_Click(object sender, RoutedEventArgs e)
        {
            string emailOrUsername = txtEmail.Text.Trim();
            if (string.IsNullOrEmpty(emailOrUsername))
            {
                txtEmail.Tag = "Error";
                lblEmailHelper.Text = "Vui lòng nhập địa chỉ thư điện tử hoặc tên đăng nhập.";
                lblEmailHelper.Foreground = (Brush)FindResource("ColorAlertRed");
                txtEmail.Focus();
                return;
            }

            btnSendOtp.IsEnabled = false;
            btnSendOtp.Content = "Đang gửi mã xác minh...";

            try
            {
                var (isSuccess, message) = await ApiService.ForgotPasswordAsync(emailOrUsername);
                if (isSuccess)
                {
                    _currentEmail = emailOrUsername;
                    _failedAttempts = 0;
                    GoToStep(2);
                }
                else
                {
                    txtEmail.Tag = "Error";
                    lblEmailHelper.Text = string.IsNullOrWhiteSpace(message) ? "Tài khoản hoặc thư điện tử không tồn tại trong hệ thống." : message;
                    lblEmailHelper.Foreground = (Brush)FindResource("ColorAlertRed");
                }
            }
            catch (Exception ex)
            {
                txtEmail.Tag = "Error";
                lblEmailHelper.Text = $"Lỗi kết nối máy chủ: {ex.Message}";
                lblEmailHelper.Foreground = (Brush)FindResource("ColorAlertRed");
            }
            finally
            {
                btnSendOtp.IsEnabled = true;
                btnSendOtp.Content = "Gửi mã xác minh";
            }
        }

        #endregion

        #region Step 2: Xác Minh OTP (6 Ô Số, Đếm Ngược, Gửi Lại Thủ Công)

        private void ClearOtpBoxes()
        {
            TextBox[] boxes = [txtOtp1, txtOtp2, txtOtp3, txtOtp4, txtOtp5, txtOtp6];
            foreach (var b in boxes)
            {
                b.Text = string.Empty;
                b.Tag = null;
                b.IsEnabled = true;
            }
            btnVerifyOtp.IsEnabled = false;
        }

        private string GetEnteredOtp()
        {
            return $"{txtOtp1.Text}{txtOtp2.Text}{txtOtp3.Text}{txtOtp4.Text}{txtOtp5.Text}{txtOtp6.Text}".Trim();
        }

        private void OtpDigit_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (sender is not TextBox currentBox) return;

            // Xóa trạng thái lỗi khi người dùng bắt đầu sửa
            ResetOtpBoxTags();

            string text = currentBox.Text;
            if (text.Length == 1 && char.IsDigit(text[0]))
            {
                // Tự động focus sang ô kế tiếp
                MoveToNextOtpBox(currentBox);
            }
            else if (text.Length > 1)
            {
                // Hỗ trợ trường hợp Paste chuỗi ký tự
                DistributePastedOtp(text);
            }

            btnVerifyOtp.IsEnabled = GetEnteredOtp().Length == 6;
        }

        private void OtpDigit_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (sender is not TextBox currentBox) return;

            if (e.Key == Key.Back && string.IsNullOrEmpty(currentBox.Text))
            {
                // Khi ô trống và bấm Backspace, tự động lùi về ô trước
                MoveToPreviousOtpBox(currentBox);
                e.Handled = true;
            }
        }

        private void MoveToNextOtpBox(TextBox current)
        {
            if (current == txtOtp1) txtOtp2.Focus();
            else if (current == txtOtp2) txtOtp3.Focus();
            else if (current == txtOtp3) txtOtp4.Focus();
            else if (current == txtOtp4) txtOtp5.Focus();
            else if (current == txtOtp5) txtOtp6.Focus();
        }

        private void MoveToPreviousOtpBox(TextBox current)
        {
            if (current == txtOtp6) { txtOtp5.Focus(); txtOtp5.SelectAll(); }
            else if (current == txtOtp5) { txtOtp4.Focus(); txtOtp4.SelectAll(); }
            else if (current == txtOtp4) { txtOtp3.Focus(); txtOtp3.SelectAll(); }
            else if (current == txtOtp3) { txtOtp2.Focus(); txtOtp2.SelectAll(); }
            else if (current == txtOtp2) { txtOtp1.Focus(); txtOtp1.SelectAll(); }
        }

        private void DistributePastedOtp(string pasted)
        {
            string digitsOnly = Regex.Replace(pasted, @"\D", "");
            TextBox[] boxes = [txtOtp1, txtOtp2, txtOtp3, txtOtp4, txtOtp5, txtOtp6];
            for (int i = 0; i < boxes.Length; i++)
            {
                boxes[i].Text = (i < digitsOnly.Length) ? digitsOnly[i].ToString() : string.Empty;
            }
            if (digitsOnly.Length >= 6) txtOtp6.Focus();
            else if (digitsOnly.Length > 0) boxes[digitsOnly.Length].Focus();
        }

        private void ResetOtpBoxTags()
        {
            TextBox[] boxes = [txtOtp1, txtOtp2, txtOtp3, txtOtp4, txtOtp5, txtOtp6];
            foreach (var b in boxes) b.Tag = null;
            lblOtpNotification.Text = "Mã chỉ có hiệu lực trong 60 giây.";
            lblOtpNotification.Foreground = (Brush)FindResource("ColorTextSecondary");
        }

        private void StartOtpCountdown()
        {
            _otpTimer?.Stop();
            _remainingOtpSeconds = 60;
            lblCountdownPrompt.Text = "Thời gian còn lại: ";
            lblCountdown.Text = $"{_remainingOtpSeconds} giây";
            lblCountdown.Foreground = (Brush)FindResource("ColorAccent");

            // Nút gửi lại mã bị vô hiệu hóa khi đồng hồ còn chạy (Yêu cầu người dùng bấm, không auto gửi)
            btnResendOtp.IsEnabled = false;
            btnResendOtp.Foreground = (Brush)FindResource("ColorTextDisabled");
            btnResendOtp.Cursor = Cursors.Arrow;

            _otpTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _otpTimer.Tick += (s, e) =>
            {
                _remainingOtpSeconds--;
                if (_remainingOtpSeconds > 0)
                {
                    lblCountdown.Text = $"{_remainingOtpSeconds} giây";
                }
                else
                {
                    _otpTimer.Stop();
                    // Khi hết hạn: Không tự động gửi lại. Bật nút để NGƯỜI DÙNG CHỦ ĐỘNG BẤM
                    lblOtpTitle.Text = "Mã xác minh hết hạn";
                    lblOtpNotification.Text = "Vui lòng yêu cầu mã mới để tiếp tục.";
                    lblOtpNotification.Foreground = (Brush)FindResource("ColorAlertRed");
                    lblCountdown.Text = "Đã hết hạn";
                    lblCountdown.Foreground = (Brush)FindResource("ColorAlertRed");

                    btnResendOtp.IsEnabled = true;
                    btnResendOtp.Foreground = (Brush)FindResource("ColorAccent");
                    btnResendOtp.Cursor = Cursors.Hand;
                }
            };
            _otpTimer.Start();
        }

        private async void BtnResendOtp_Click(object sender, MouseButtonEventArgs e)
        {
            if (!btnResendOtp.IsEnabled) return;

            btnResendOtp.IsEnabled = false;
            string originalText = btnResendOtp.Text;
            btnResendOtp.Text = "Đang gửi lại mã...";

            try
            {
                var (isSuccess, message) = await ApiService.ForgotPasswordAsync(_currentEmail);
                if (isSuccess)
                {
                    lblOtpTitle.Text = "Xác minh thư điện tử";
                    lblOtpNotification.Text = "Mã xác minh mới đã được gửi thành công!";
                    lblOtpNotification.Foreground = (Brush)FindResource("ColorSuccessDark");
                    ClearOtpBoxes();
                    StartOtpCountdown();
                }
                else
                {
                    lblOtpNotification.Text = $"Gửi lại thất bại: {message}";
                    lblOtpNotification.Foreground = (Brush)FindResource("ColorAlertRed");
                    btnResendOtp.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                lblOtpNotification.Text = $"Lỗi: {ex.Message}";
                lblOtpNotification.Foreground = (Brush)FindResource("ColorAlertRed");
                btnResendOtp.IsEnabled = true;
            }
            finally
            {
                btnResendOtp.Text = originalText;
            }
        }

        private async void BtnVerifyOtp_Click(object sender, RoutedEventArgs e)
        {
            string otp = GetEnteredOtp();
            if (otp.Length != 6) return;

            btnVerifyOtp.IsEnabled = false;
            btnVerifyOtp.Content = "Đang xác minh...";

            try
            {
                var (isSuccess, message) = await ApiService.VerifyOtpAsync(_currentEmail, otp);
                if (isSuccess)
                {
                    _otpTimer?.Stop();
                    GoToStep(3);
                }
                else
                {
                    _failedAttempts++;
                    TextBox[] boxes = [txtOtp1, txtOtp2, txtOtp3, txtOtp4, txtOtp5, txtOtp6];

                    if (_failedAttempts == 1)
                    {
                        foreach (var b in boxes) b.Tag = "Error";
                        lblOtpNotification.Text = "Mã xác minh không chính xác. Vui lòng kiểm tra lại.";
                        lblOtpNotification.Foreground = (Brush)FindResource("ColorAlertRed");
                    }
                    else if (_failedAttempts == 2)
                    {
                        foreach (var b in boxes) b.Tag = "Warning";
                        lblOtpNotification.Text = "⚠️ Cảnh báo: Bạn chỉ còn 1 lần thử trước khi tài khoản bị tạm khóa.";
                        lblOtpNotification.Foreground = (Brush)FindResource("ColorWarning");
                    }
                    else
                    {
                        // Nhập sai 3 lần -> Tạm khóa 15 phút (Frame 12)
                        TriggerLockout();
                    }
                }
            }
            catch (Exception ex)
            {
                lblOtpNotification.Text = $"Lỗi kết nối: {ex.Message}";
                lblOtpNotification.Foreground = (Brush)FindResource("ColorAlertRed");
            }
            finally
            {
                if (_failedAttempts < 3)
                {
                    btnVerifyOtp.IsEnabled = GetEnteredOtp().Length == 6;
                    btnVerifyOtp.Content = "Xác minh";
                }
            }
        }

        private void TriggerLockout()
        {
            _otpTimer?.Stop();
            lblOtpTitle.Text = "Tạm khóa xác minh";
            lblStatusIsland.Text = "TẠM KHÓA XÁC MINH";
            lblOtpDesc.Text = "Bạn đã nhập sai 3 lần. Vui lòng chờ trước khi thử lại.";
            lblOtpNotification.Text = "Hệ thống tạm thời khóa tính năng xác minh.";
            lblOtpNotification.Foreground = (Brush)FindResource("ColorAlertRed");

            TextBox[] boxes = [txtOtp1, txtOtp2, txtOtp3, txtOtp4, txtOtp5, txtOtp6];
            foreach (var b in boxes)
            {
                b.Tag = "Error";
                b.IsEnabled = false;
            }

            btnVerifyOtp.IsEnabled = false;
            btnResendOtp.IsEnabled = false;
            btnResendOtp.Foreground = (Brush)FindResource("ColorTextDisabled");
            btnResendOtp.Cursor = Cursors.Arrow;

            lblCountdownPrompt.Text = "Bạn có thể thử lại sau: ";
            _lockoutSeconds = 900;
            _lockoutTimer?.Stop();
            _lockoutTimer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _lockoutTimer.Tick += (s, e) =>
            {
                _lockoutSeconds--;
                if (_lockoutSeconds > 0)
                {
                    int mins = _lockoutSeconds / 60;
                    int secs = _lockoutSeconds % 60;
                    lblCountdown.Text = $"{mins:D2}:{secs:D2}";
                }
                else
                {
                    _lockoutTimer.Stop();
                    _failedAttempts = 0;
                    lblOtpTitle.Text = "Xác minh thư điện tử";
                    lblStatusIsland.Text = "XÁC MINH TÀI KHOẢN";
                    lblOtpDesc.Text = "Nhập mã gồm 6 chữ số được gửi đến";
                    ClearOtpBoxes();
                    StartOtpCountdown();
                }
            };
            _lockoutTimer.Start();
        }

        #endregion

        #region Step 3: Đặt Lại Mật Khẩu Mới & Đánh Giá Độ Mạnh

        private void BtnToggleNewPassword_Click(object sender, RoutedEventArgs e)
        {
            _isNewPasswordVisible = !_isNewPasswordVisible;
            if (_isNewPasswordVisible)
            {
                txtNewPasswordVisible.Text = txtNewPassword.Password;
                txtNewPassword.Visibility = Visibility.Collapsed;
                txtNewPasswordVisible.Visibility = Visibility.Visible;
                btnToggleNewPassword.Content = "🔒";
                txtNewPasswordVisible.Focus();
            }
            else
            {
                txtNewPassword.Password = txtNewPasswordVisible.Text;
                txtNewPasswordVisible.Visibility = Visibility.Collapsed;
                txtNewPassword.Visibility = Visibility.Visible;
                btnToggleNewPassword.Content = "👁️";
                txtNewPassword.Focus();
            }
        }

        private void BtnToggleConfirmPassword_Click(object sender, RoutedEventArgs e)
        {
            _isConfirmPasswordVisible = !_isConfirmPasswordVisible;
            if (_isConfirmPasswordVisible)
            {
                txtConfirmPasswordVisible.Text = txtConfirmPassword.Password;
                txtConfirmPassword.Visibility = Visibility.Collapsed;
                txtConfirmPasswordVisible.Visibility = Visibility.Visible;
                btnToggleConfirmPassword.Content = "🔒";
                txtConfirmPasswordVisible.Focus();
            }
            else
            {
                txtConfirmPassword.Password = txtConfirmPasswordVisible.Text;
                txtConfirmPasswordVisible.Visibility = Visibility.Collapsed;
                txtConfirmPassword.Visibility = Visibility.Visible;
                btnToggleConfirmPassword.Content = "👁️";
                txtConfirmPassword.Focus();
            }
        }

        private string GetNewPassword() => _isNewPasswordVisible ? txtNewPasswordVisible.Text : txtNewPassword.Password;
        private string GetConfirmPassword() => _isConfirmPasswordVisible ? txtConfirmPasswordVisible.Text : txtConfirmPassword.Password;

        private void PasswordInputs_Changed(object sender, RoutedEventArgs e)
        {
            EvaluatePasswordStrength();
        }

        private void EvaluatePasswordStrength()
        {
            string newPass = GetNewPassword();
            string confirmPass = GetConfirmPassword();

            int score = CalculatePasswordStrengthScore(newPass);
            UpdateStrengthBars(score);

            if (string.IsNullOrEmpty(newPass))
            {
                lblPasswordValidation.Text = "Nhập mật khẩu mới để bảo vệ tài khoản.";
                lblPasswordValidation.Foreground = (Brush)FindResource("ColorTextSecondary");
                btnUpdatePassword.IsEnabled = false;
                return;
            }

            if (score < 2)
            {
                lblPasswordValidation.Text = "Mật khẩu chưa đủ mạnh (cần ít nhất 8 ký tự, gồm chữ và số).";
                lblPasswordValidation.Foreground = (Brush)FindResource("ColorAlertRed");
                btnUpdatePassword.IsEnabled = false;
                return;
            }

            if (string.IsNullOrEmpty(confirmPass))
            {
                lblPasswordValidation.Text = "Nhập lại mật khẩu mới để xác nhận.";
                lblPasswordValidation.Foreground = (Brush)FindResource("ColorTextSecondary");
                btnUpdatePassword.IsEnabled = false;
                return;
            }

            if (newPass != confirmPass)
            {
                lblPasswordValidation.Text = "Mật khẩu xác nhận không trùng khớp.";
                lblPasswordValidation.Foreground = (Brush)FindResource("ColorAlertRed");
                btnUpdatePassword.IsEnabled = false;
                return;
            }

            lblPasswordValidation.Text = "Mật khẩu hợp lệ và trùng khớp.";
            lblPasswordValidation.Foreground = (Brush)FindResource("ColorSuccessDark");
            btnUpdatePassword.IsEnabled = true;
        }

        private static int CalculatePasswordStrengthScore(string password)
        {
            if (string.IsNullOrEmpty(password)) return 0;
            int score = 0;
            if (password.Length >= 8) score++;
            if (Regex.IsMatch(password, @"[a-z]") && Regex.IsMatch(password, @"[A-Z]")) score++;
            if (Regex.IsMatch(password, @"\d")) score++;
            if (Regex.IsMatch(password, @"[^a-zA-Z0-9]")) score++;
            return score;
        }

        private void UpdateStrengthBars(int score)
        {
            Brush borderBrush = (Brush)FindResource("ColorBorder");
            Brush redBrush = (Brush)FindResource("ColorAlertRed");
            Brush orangeBrush = (Brush)FindResource("ColorWarning");
            Brush blueBrush = (Brush)FindResource("ColorAccent");
            Brush greenBrush = (Brush)FindResource("ColorSuccess");

            barStrength1.Background = borderBrush;
            barStrength2.Background = borderBrush;
            barStrength3.Background = borderBrush;
            barStrength4.Background = borderBrush;

            switch (score)
            {
                case 1:
                    barStrength1.Background = redBrush;
                    lblStrengthText.Text = "Độ mạnh: Yếu";
                    lblStrengthText.Foreground = redBrush;
                    break;
                case 2:
                    barStrength1.Background = orangeBrush;
                    barStrength2.Background = orangeBrush;
                    lblStrengthText.Text = "Độ mạnh: Trung bình";
                    lblStrengthText.Foreground = orangeBrush;
                    break;
                case 3:
                    barStrength1.Background = blueBrush;
                    barStrength2.Background = blueBrush;
                    barStrength3.Background = blueBrush;
                    lblStrengthText.Text = "Độ mạnh: Khá mạnh";
                    lblStrengthText.Foreground = blueBrush;
                    break;
                case 4:
                    barStrength1.Background = greenBrush;
                    barStrength2.Background = greenBrush;
                    barStrength3.Background = greenBrush;
                    barStrength4.Background = greenBrush;
                    lblStrengthText.Text = "Độ mạnh: Rất mạnh";
                    lblStrengthText.Foreground = greenBrush;
                    break;
                default:
                    lblStrengthText.Text = "Độ mạnh mật khẩu";
                    lblStrengthText.Foreground = (Brush)FindResource("ColorTextSecondary");
                    break;
            }
        }

        private async void BtnUpdatePassword_Click(object sender, RoutedEventArgs e)
        {
            string newPass = GetNewPassword();
            string confirmPass = GetConfirmPassword();

            if (newPass != confirmPass) return;

            btnUpdatePassword.IsEnabled = false;
            btnUpdatePassword.Content = "Đang cập nhật mật khẩu...";

            try
            {
                var (isSuccess, message) = await ApiService.ChangePasswordAsync(_currentEmail, newPass);
                if (isSuccess)
                {
                    GoToStep(4);
                }
                else
                {
                    lblPasswordValidation.Text = $"Cập nhật thất bại: {message}";
                    lblPasswordValidation.Foreground = (Brush)FindResource("ColorAlertRed");
                    btnUpdatePassword.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                lblPasswordValidation.Text = $"Lỗi kết nối máy chủ: {ex.Message}";
                lblPasswordValidation.Foreground = (Brush)FindResource("ColorAlertRed");
                btnUpdatePassword.IsEnabled = true;
            }
            finally
            {
                btnUpdatePassword.Content = "Cập nhật mật khẩu";
            }
        }

        #endregion

        private void StopAllTimers()
        {
            _otpTimer?.Stop();
            _lockoutTimer?.Stop();
        }
    }
}