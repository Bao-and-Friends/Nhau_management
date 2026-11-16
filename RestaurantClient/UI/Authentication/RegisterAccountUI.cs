using RestaurantClient.Services;
using RestaurantShared.DTOs;
using Sunny.UI;
using System.Text.RegularExpressions;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RestaurantClient.UI.Authentication
{
    public partial class RegisterAccountUI : UIForm
    {
        public RegisterAccountUI()
        {
            InitializeComponent();
        }

        private async void btnSave_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra tính hợp lệ dữ liệu nhập
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ và tên nhân viên!", "Thông báo", MessageBoxButtons.OK);
                txtHoTen.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập Số điện thoại!", "Thông báo", MessageBoxButtons.OK);
                txtSDT.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text.Trim()))
            {
                MessageBox.Show("Email không hợp lệ! Vui lòng nhập đúng để nhận thông báo tài khoản.","Thông báo",MessageBoxButtons.OK);
                txtEmail.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(txtUsername.Text) || txtUsername.Text.Contains(' '))
            {
                MessageBox.Show("Tên đăng nhập không được rỗng và không chứa dấu cách", "Thông báo", MessageBoxButtons.OK);
                txtUsername.Focus();
                return;
            }
            if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("Mật khẩu phải có tối thiểu 6 ký tự!", "Thông báo", MessageBoxButtons.OK);
                txtPassword.Focus();
                return;
            }
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                MessageBox.Show("Mật khẩu xác nhận không trùng khớp!", "Thông báo", MessageBoxButtons.OK);
                txtConfirmPassword.Focus();
                return;
            }
            // 2. Gom dữ liệu vào Record dùng chung RegisterAccountRequest
            var request = new RegisterAccountRequest(
                Username: txtUsername.Text.Trim(),
                Password: txtPassword.Text,
                HoTen: txtHoTen.Text.Trim(),
                VaiTro: cboVaiTro.SelectedItem?.ToString() ?? "Phục vụ",
                GioiTinh: cboGioiTinh.SelectedItem?.ToString() ?? "Nam",
                NgaySinh: dtpNgaySinh.Value,
                SoDienThoai: txtSDT.Text.Trim(),
                Email: txtEmail.Text.Trim(),
                DiaChi: txtDiaChi.Text.Trim()
            );
            btnSave.Enabled = false;
            btnSave.Text = "Đang tạo...";
            // 3. Gọi Web API
            var (isSuccess, message) = await ApiService.RegisterAccountAsync(request);
            btnSave.Enabled = true;
            btnSave.Text = "Tạo Tài Khoản";
            if (isSuccess)
            {
                MessageBox.Show(message,"Thông Báo", MessageBoxButtons.OK);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                UIMessageBox.ShowError(message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private bool IsValidEmail(string email)
        {
            return Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
        }

       
    }
}