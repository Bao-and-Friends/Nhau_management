namespace RestaurantClient.UI.Authentication
{
   
        partial class RegisterAccountUI
        {
            private System.ComponentModel.IContainer components = null;

            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }

        private void InitializeComponent()
        {
            txtHoTen = new Sunny.UI.UITextBox();
            cboVaiTro = new Sunny.UI.UIComboBox();
            txtSDT = new Sunny.UI.UITextBox();
            txtEmail = new Sunny.UI.UITextBox();
            cboGioiTinh = new Sunny.UI.UIComboBox();
            dtpNgaySinh = new Sunny.UI.UIDatePicker();
            txtDiaChi = new Sunny.UI.UITextBox();
            txtUsername = new Sunny.UI.UITextBox();
            txtPassword = new Sunny.UI.UITextBox();
            txtConfirmPassword = new Sunny.UI.UITextBox();
            btnSave = new Sunny.UI.UIButton();
            btnCancel = new Sunny.UI.UIButton();
            lblTitleNhanVien = new Sunny.UI.UILabel();
            lblTitleTaiKhoan = new Sunny.UI.UILabel();
            SuspendLayout();
            // 
            // txtHoTen
            // 
            txtHoTen.Font = new Font("Microsoft Sans Serif", 12F);
            txtHoTen.Location = new Point(30, 90);
            txtHoTen.Margin = new Padding(4, 5, 4, 5);
            txtHoTen.MinimumSize = new Size(1, 16);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Padding = new Padding(5);
            txtHoTen.ShowText = false;
            txtHoTen.Size = new Size(320, 35);
            txtHoTen.TabIndex = 1;
            txtHoTen.TextAlignment = ContentAlignment.MiddleLeft;
            txtHoTen.Watermark = "Họ và tên nhân viên (*)";
            // 
            // cboVaiTro
            // 
            cboVaiTro.DataSource = null;
            cboVaiTro.FillColor = Color.White;
            cboVaiTro.Font = new Font("Microsoft Sans Serif", 12F);
            cboVaiTro.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cboVaiTro.Items.AddRange(new object[] { "Phục vụ", "Thu ngân", "Đầu bếp", "Quản lý" });
            cboVaiTro.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cboVaiTro.Location = new Point(30, 140);
            cboVaiTro.Margin = new Padding(4, 5, 4, 5);
            cboVaiTro.MinimumSize = new Size(63, 0);
            cboVaiTro.Name = "cboVaiTro";
            cboVaiTro.Padding = new Padding(0, 0, 30, 2);
            cboVaiTro.Size = new Size(320, 35);
            cboVaiTro.SymbolSize = 24;
            cboVaiTro.TabIndex = 2;
            cboVaiTro.Text = "Phục vụ";
            cboVaiTro.TextAlignment = ContentAlignment.MiddleLeft;
            cboVaiTro.Watermark = "";
            // 
            // txtSDT
            // 
            txtSDT.Font = new Font("Microsoft Sans Serif", 12F);
            txtSDT.Location = new Point(30, 190);
            txtSDT.Margin = new Padding(4, 5, 4, 5);
            txtSDT.MinimumSize = new Size(1, 16);
            txtSDT.Name = "txtSDT";
            txtSDT.Padding = new Padding(5);
            txtSDT.ShowText = false;
            txtSDT.Size = new Size(320, 35);
            txtSDT.TabIndex = 3;
            txtSDT.TextAlignment = ContentAlignment.MiddleLeft;
            txtSDT.Watermark = "Số điện thoại (*)";
            // 
            // txtEmail
            // 
            txtEmail.Font = new Font("Microsoft Sans Serif", 12F);
            txtEmail.Location = new Point(30, 240);
            txtEmail.Margin = new Padding(4, 5, 4, 5);
            txtEmail.MinimumSize = new Size(1, 16);
            txtEmail.Name = "txtEmail";
            txtEmail.Padding = new Padding(5);
            txtEmail.ShowText = false;
            txtEmail.Size = new Size(320, 35);
            txtEmail.TabIndex = 4;
            txtEmail.TextAlignment = ContentAlignment.MiddleLeft;
            txtEmail.Watermark = "Email nhận OTP (*)";
            // 
            // cboGioiTinh
            // 
            cboGioiTinh.DataSource = null;
            cboGioiTinh.FillColor = Color.White;
            cboGioiTinh.Font = new Font("Microsoft Sans Serif", 12F);
            cboGioiTinh.ItemHoverColor = Color.FromArgb(155, 200, 255);
            cboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            cboGioiTinh.ItemSelectForeColor = Color.FromArgb(235, 243, 255);
            cboGioiTinh.Location = new Point(30, 290);
            cboGioiTinh.Margin = new Padding(4, 5, 4, 5);
            cboGioiTinh.MinimumSize = new Size(63, 0);
            cboGioiTinh.Name = "cboGioiTinh";
            cboGioiTinh.Padding = new Padding(0, 0, 30, 2);
            cboGioiTinh.Size = new Size(140, 35);
            cboGioiTinh.SymbolSize = 24;
            cboGioiTinh.TabIndex = 5;
            cboGioiTinh.Text = "Nam";
            cboGioiTinh.TextAlignment = ContentAlignment.MiddleLeft;
            cboGioiTinh.Watermark = "";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.DateCultureInfo = new System.Globalization.CultureInfo("");
            dtpNgaySinh.FillColor = Color.White;
            dtpNgaySinh.Font = new Font("Microsoft Sans Serif", 12F);
            dtpNgaySinh.Location = new Point(180, 290);
            dtpNgaySinh.Margin = new Padding(4, 5, 4, 5);
            dtpNgaySinh.MaxLength = 10;
            dtpNgaySinh.MinimumSize = new Size(63, 0);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Padding = new Padding(0, 0, 30, 2);
            dtpNgaySinh.Size = new Size(170, 35);
            dtpNgaySinh.SymbolDropDown = 61555;
            dtpNgaySinh.SymbolNormal = 61555;
            dtpNgaySinh.SymbolSize = 24;
            dtpNgaySinh.TabIndex = 6;
            dtpNgaySinh.Text = "2000-01-01";
            dtpNgaySinh.TextAlignment = ContentAlignment.MiddleLeft;
            dtpNgaySinh.Value = new DateTime(2000, 1, 1, 0, 0, 0, 0);
            dtpNgaySinh.Watermark = "";
            // 
            // txtDiaChi
            // 
            txtDiaChi.Font = new Font("Microsoft Sans Serif", 12F);
            txtDiaChi.Location = new Point(30, 340);
            txtDiaChi.Margin = new Padding(4, 5, 4, 5);
            txtDiaChi.MinimumSize = new Size(1, 16);
            txtDiaChi.Name = "txtDiaChi";
            txtDiaChi.Padding = new Padding(5);
            txtDiaChi.ShowText = false;
            txtDiaChi.Size = new Size(320, 35);
            txtDiaChi.TabIndex = 7;
            txtDiaChi.TextAlignment = ContentAlignment.MiddleLeft;
            txtDiaChi.Watermark = "Địa chỉ liên hệ";
            // 
            // txtUsername
            // 
            txtUsername.Font = new Font("Microsoft Sans Serif", 12F);
            txtUsername.Location = new Point(400, 90);
            txtUsername.Margin = new Padding(4, 5, 4, 5);
            txtUsername.MinimumSize = new Size(1, 16);
            txtUsername.Name = "txtUsername";
            txtUsername.Padding = new Padding(5);
            txtUsername.ShowText = false;
            txtUsername.Size = new Size(320, 35);
            txtUsername.TabIndex = 9;
            txtUsername.TextAlignment = ContentAlignment.MiddleLeft;
            txtUsername.Watermark = "Tên đăng nhập (*)";
            // 
            // txtPassword
            // 
            txtPassword.Font = new Font("Microsoft Sans Serif", 12F);
            txtPassword.ImeMode = ImeMode.Disable;
            txtPassword.Location = new Point(400, 140);
            txtPassword.Margin = new Padding(4, 5, 4, 5);
            txtPassword.MinimumSize = new Size(1, 16);
            txtPassword.Name = "txtPassword";
            txtPassword.Padding = new Padding(5);
            txtPassword.PasswordChar = '●';
            txtPassword.ShowText = false;
            txtPassword.Size = new Size(320, 35);
            txtPassword.TabIndex = 10;
            txtPassword.TextAlignment = ContentAlignment.MiddleLeft;
            txtPassword.Watermark = "Mật khẩu (Tối thiểu 6 ký tự) (*)";
            // 
            // txtConfirmPassword
            // 
            txtConfirmPassword.Font = new Font("Microsoft Sans Serif", 12F);
            txtConfirmPassword.ImeMode = ImeMode.Disable;
            txtConfirmPassword.Location = new Point(400, 190);
            txtConfirmPassword.Margin = new Padding(4, 5, 4, 5);
            txtConfirmPassword.MinimumSize = new Size(1, 16);
            txtConfirmPassword.Name = "txtConfirmPassword";
            txtConfirmPassword.Padding = new Padding(5);
            txtConfirmPassword.PasswordChar = '●';
            txtConfirmPassword.ShowText = false;
            txtConfirmPassword.Size = new Size(320, 35);
            txtConfirmPassword.TabIndex = 11;
            txtConfirmPassword.TextAlignment = ContentAlignment.MiddleLeft;
            txtConfirmPassword.Watermark = "Nhập lại mật khẩu (*)";
            // 
            // btnSave
            // 
            btnSave.FillColor = Color.FromArgb(46, 173, 114);
            btnSave.Font = new Font("Microsoft Sans Serif", 12F);
            btnSave.Location = new Point(580, 340);
            btnSave.MinimumSize = new Size(1, 1);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(140, 42);
            btnSave.TabIndex = 13;
            btnSave.Text = "Tạo Tài Khoản";
            btnSave.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnSave.Click += btnSave_Click;
            // 
            // btnCancel
            // 
            btnCancel.FillColor = Color.Gray;
            btnCancel.Font = new Font("Microsoft Sans Serif", 12F);
            btnCancel.Location = new Point(440, 340);
            btnCancel.MinimumSize = new Size(1, 1);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(120, 42);
            btnCancel.TabIndex = 12;
            btnCancel.Text = "Hủy Bỏ";
            btnCancel.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnCancel.Click += btnCancel_Click;
            // 
            // lblTitleNhanVien
            // 
            lblTitleNhanVien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitleNhanVien.ForeColor = Color.FromArgb(152, 98, 61);
            lblTitleNhanVien.Location = new Point(30, 50);
            lblTitleNhanVien.Name = "lblTitleNhanVien";
            lblTitleNhanVien.Size = new Size(250, 30);
            lblTitleNhanVien.TabIndex = 0;
            lblTitleNhanVien.Text = "📌 THÔNG TIN NHÂN VIÊN";
            // 
            // lblTitleTaiKhoan
            // 
            lblTitleTaiKhoan.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitleTaiKhoan.ForeColor = Color.FromArgb(152, 98, 61);
            lblTitleTaiKhoan.Location = new Point(400, 50);
            lblTitleTaiKhoan.Name = "lblTitleTaiKhoan";
            lblTitleTaiKhoan.Size = new Size(250, 30);
            lblTitleTaiKhoan.TabIndex = 8;
            lblTitleTaiKhoan.Text = "🔐 THÔNG TIN ĐĂNG NHẬP";
            // 
            // RegisterAccountUI
            // 
            ClientSize = new Size(760, 420);
            Controls.Add(lblTitleNhanVien);
            Controls.Add(txtHoTen);
            Controls.Add(cboVaiTro);
            Controls.Add(txtSDT);
            Controls.Add(txtEmail);
            Controls.Add(cboGioiTinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtDiaChi);
            Controls.Add(lblTitleTaiKhoan);
            Controls.Add(txtUsername);
            Controls.Add(txtPassword);
            Controls.Add(txtConfirmPassword);
            Controls.Add(btnCancel);
            Controls.Add(btnSave);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "RegisterAccountUI";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thêm Tài Khoản Nhân Viên";
            ZoomScaleRect = new Rectangle(22, 22, 760, 420);
            ResumeLayout(false);
        }

        private Sunny.UI.UITextBox txtHoTen;
            private Sunny.UI.UIComboBox cboVaiTro;
            private Sunny.UI.UITextBox txtSDT;
            private Sunny.UI.UITextBox txtEmail;
            private Sunny.UI.UIComboBox cboGioiTinh;
            private Sunny.UI.UIDatePicker dtpNgaySinh;
            private Sunny.UI.UITextBox txtDiaChi;
            private Sunny.UI.UITextBox txtUsername;
            private Sunny.UI.UITextBox txtPassword;
            private Sunny.UI.UITextBox txtConfirmPassword;
            private Sunny.UI.UIButton btnSave;
            private Sunny.UI.UIButton btnCancel;
            private Sunny.UI.UILabel lblTitleNhanVien;
            private Sunny.UI.UILabel lblTitleTaiKhoan;
        }
}