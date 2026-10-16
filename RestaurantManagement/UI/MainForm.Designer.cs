namespace RestaurantManagement.UI
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            panelHeader = new Sunny.UI.UIPanel();
            uiPanel1 = new Sunny.UI.UIPanel();
            btnLogout = new Sunny.UI.UIButton();
            uiAvatar1 = new Sunny.UI.UIAvatar();
            uiLabel1 = new Sunny.UI.UILabel();
            btnOpenChat = new Sunny.UI.UIButton();
            uiPanel2 = new Sunny.UI.UIPanel();
            uiLabel2 = new Sunny.UI.UILabel();
            panelFooter = new Sunny.UI.UIPanel();
            lblClock = new Sunny.UI.UILabel();
            lblNetworkStatus = new Sunny.UI.UILabel();
            panelSidebar = new Sunny.UI.UIPanel();
            btnMenuBaoCao = new Sunny.UI.UIButton();
            btnMenuNhanVien = new Sunny.UI.UIButton();
            btnMenuKho = new Sunny.UI.UIButton();
            btnMenuThucDon = new Sunny.UI.UIButton();
            btnMenuBep = new Sunny.UI.UIButton();
            btnMenuThuNgan = new Sunny.UI.UIButton();
            btnMenuBanAn = new Sunny.UI.UIButton();
            panelContent = new Sunny.UI.UIPanel();
            panelChat = new Sunny.UI.UIPanel();
            timer1 = new System.Windows.Forms.Timer(components);
            panelHeader.SuspendLayout();
            uiPanel1.SuspendLayout();
            uiPanel2.SuspendLayout();
            panelFooter.SuspendLayout();
            panelSidebar.SuspendLayout();
            panelContent.SuspendLayout();
            SuspendLayout();
            // 
            // panelHeader
            // 
            panelHeader.Controls.Add(uiPanel1);
            panelHeader.Controls.Add(uiPanel2);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.FillColor = Color.FromArgb(250, 245, 240);
            panelHeader.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            panelHeader.Location = new Point(0, 35);
            panelHeader.Margin = new Padding(4, 5, 4, 5);
            panelHeader.MinimumSize = new Size(1, 1);
            panelHeader.Name = "panelHeader";
            panelHeader.RectColor = Color.Transparent;
            panelHeader.Size = new Size(1366, 53);
            panelHeader.TabIndex = 0;
            panelHeader.Text = null;
            panelHeader.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiPanel1
            // 
            uiPanel1.BackColor = Color.Transparent;
            uiPanel1.Controls.Add(btnLogout);
            uiPanel1.Controls.Add(uiAvatar1);
            uiPanel1.Controls.Add(uiLabel1);
            uiPanel1.Controls.Add(btnOpenChat);
            uiPanel1.Dock = DockStyle.Right;
            uiPanel1.FillColor = Color.Transparent;
            uiPanel1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            uiPanel1.Location = new Point(821, 0);
            uiPanel1.Margin = new Padding(4, 5, 4, 5);
            uiPanel1.MinimumSize = new Size(1, 1);
            uiPanel1.Name = "uiPanel1";
            uiPanel1.RectColor = Color.Transparent;
            uiPanel1.Size = new Size(545, 53);
            uiPanel1.TabIndex = 4;
            uiPanel1.Text = null;
            uiPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnLogout
            // 
            btnLogout.BackColor = Color.Transparent;
            btnLogout.FillColor = Color.FromArgb(230, 80, 80);
            btnLogout.FillHoverColor = Color.Transparent;
            btnLogout.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnLogout.Location = new Point(430, 13);
            btnLogout.MinimumSize = new Size(1, 1);
            btnLogout.Name = "btnLogout";
            btnLogout.Radius = 20;
            btnLogout.RectColor = Color.Transparent;
            btnLogout.Size = new Size(93, 32);
            btnLogout.TabIndex = 3;
            btnLogout.Text = "Đăng xuất";
            btnLogout.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnLogout.Click += btnLogout_Click;
            // 
            // uiAvatar1
            // 
            uiAvatar1.BackColor = Color.FromArgb(250, 245, 240);
            uiAvatar1.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            uiAvatar1.Location = new Point(116, 3);
            uiAvatar1.MinimumSize = new Size(1, 1);
            uiAvatar1.Name = "uiAvatar1";
            uiAvatar1.Size = new Size(36, 45);
            uiAvatar1.TabIndex = 1;
            uiAvatar1.Text = "uiAvatar1";
            // 
            // uiLabel1
            // 
            uiLabel1.AutoSize = true;
            uiLabel1.BackColor = Color.FromArgb(250, 245, 240);
            uiLabel1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            uiLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel1.Location = new Point(172, 16);
            uiLabel1.Name = "uiLabel1";
            uiLabel1.Size = new Size(197, 21);
            uiLabel1.TabIndex = 0;
            uiLabel1.Text = "Nguyen Van A  | Phuc vu";
            uiLabel1.TextAlign = ContentAlignment.MiddleLeft;
            uiLabel1.Click += uiLabel1_Click;
            // 
            // btnOpenChat
            // 
            btnOpenChat.BackColor = Color.Transparent;
            btnOpenChat.FillColor = Color.Chocolate;
            btnOpenChat.FillDisableColor = Color.Transparent;
            btnOpenChat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnOpenChat.LightColor = Color.Salmon;
            btnOpenChat.Location = new Point(0, 16);
            btnOpenChat.MinimumSize = new Size(1, 1);
            btnOpenChat.Name = "btnOpenChat";
            btnOpenChat.Radius = 20;
            btnOpenChat.RectColor = Color.Salmon;
            btnOpenChat.Size = new Size(107, 26);
            btnOpenChat.TabIndex = 2;
            btnOpenChat.Text = "💬 Trò chuyện";
            btnOpenChat.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnOpenChat.Click += btnOpenChat_Click;
            // 
            // uiPanel2
            // 
            uiPanel2.BackColor = Color.Transparent;
            uiPanel2.Controls.Add(uiLabel2);
            uiPanel2.Dock = DockStyle.Left;
            uiPanel2.FillColor = Color.Transparent;
            uiPanel2.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            uiPanel2.Location = new Point(0, 0);
            uiPanel2.Margin = new Padding(4, 5, 4, 5);
            uiPanel2.MinimumSize = new Size(1, 1);
            uiPanel2.Name = "uiPanel2";
            uiPanel2.RectColor = Color.Transparent;
            uiPanel2.Size = new Size(392, 53);
            uiPanel2.TabIndex = 5;
            uiPanel2.Text = null;
            uiPanel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLabel2
            // 
            uiLabel2.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 163);
            uiLabel2.ForeColor = Color.FromArgb(48, 48, 48);
            uiLabel2.Location = new Point(3, 13);
            uiLabel2.Name = "uiLabel2";
            uiLabel2.Size = new Size(440, 27);
            uiLabel2.TabIndex = 0;
            uiLabel2.Text = "🍽 THE GOURMET RESTAURANT";
            // 
            // panelFooter
            // 
            panelFooter.Controls.Add(lblClock);
            panelFooter.Controls.Add(lblNetworkStatus);
            panelFooter.Dock = DockStyle.Bottom;
            panelFooter.FillColor = Color.FromArgb(250, 245, 240);
            panelFooter.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            panelFooter.Location = new Point(0, 733);
            panelFooter.Margin = new Padding(4, 5, 4, 5);
            panelFooter.MinimumSize = new Size(1, 1);
            panelFooter.Name = "panelFooter";
            panelFooter.RectColor = Color.Transparent;
            panelFooter.Size = new Size(1366, 35);
            panelFooter.TabIndex = 1;
            panelFooter.Text = null;
            panelFooter.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lblClock
            // 
            lblClock.BackColor = Color.Transparent;
            lblClock.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblClock.ForeColor = Color.FromArgb(48, 48, 48);
            lblClock.Location = new Point(1153, 7);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(210, 23);
            lblClock.TabIndex = 2;
            lblClock.Text = "🕒 20:30:00 - 15/10/2026";
            // 
            // lblNetworkStatus
            // 
            lblNetworkStatus.BackColor = Color.Transparent;
            lblNetworkStatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            lblNetworkStatus.ForeColor = Color.ForestGreen;
            lblNetworkStatus.Location = new Point(3, 0);
            lblNetworkStatus.Name = "lblNetworkStatus";
            lblNetworkStatus.Size = new Size(338, 30);
            lblNetworkStatus.TabIndex = 1;
            lblNetworkStatus.Text = "\U0001f7e2 Đã kết nối Máy chủ TCP (127.0.0.1:8888)";
            lblNetworkStatus.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panelSidebar
            // 
            panelSidebar.Controls.Add(btnMenuBaoCao);
            panelSidebar.Controls.Add(btnMenuNhanVien);
            panelSidebar.Controls.Add(btnMenuKho);
            panelSidebar.Controls.Add(btnMenuThucDon);
            panelSidebar.Controls.Add(btnMenuBep);
            panelSidebar.Controls.Add(btnMenuThuNgan);
            panelSidebar.Controls.Add(btnMenuBanAn);
            panelSidebar.Dock = DockStyle.Left;
            panelSidebar.FillColor = Color.FromArgb(48, 40, 36);
            panelSidebar.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            panelSidebar.Location = new Point(0, 88);
            panelSidebar.Margin = new Padding(4, 5, 4, 5);
            panelSidebar.MinimumSize = new Size(1, 1);
            panelSidebar.Name = "panelSidebar";
            panelSidebar.RectColor = Color.Transparent;
            panelSidebar.Size = new Size(230, 645);
            panelSidebar.TabIndex = 2;
            panelSidebar.Text = null;
            panelSidebar.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // btnMenuBaoCao
            // 
            btnMenuBaoCao.BackColor = Color.Transparent;
            btnMenuBaoCao.FillColor = Color.RosyBrown;
            btnMenuBaoCao.FillHoverColor = Color.FromArgb(152, 98, 61);
            btnMenuBaoCao.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnMenuBaoCao.Location = new Point(3, 339);
            btnMenuBaoCao.MinimumSize = new Size(1, 1);
            btnMenuBaoCao.Name = "btnMenuBaoCao";
            btnMenuBaoCao.Radius = 20;
            btnMenuBaoCao.RectColor = Color.Transparent;
            btnMenuBaoCao.Size = new Size(224, 50);
            btnMenuBaoCao.TabIndex = 6;
            btnMenuBaoCao.Text = "📊 Thống kê Doanh thu";
            btnMenuBaoCao.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            // 
            // btnMenuNhanVien
            // 
            btnMenuNhanVien.BackColor = Color.Transparent;
            btnMenuNhanVien.FillColor = Color.RosyBrown;
            btnMenuNhanVien.FillHoverColor = Color.FromArgb(152, 98, 61);
            btnMenuNhanVien.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnMenuNhanVien.Location = new Point(3, 283);
            btnMenuNhanVien.MinimumSize = new Size(1, 1);
            btnMenuNhanVien.Name = "btnMenuNhanVien";
            btnMenuNhanVien.Radius = 20;
            btnMenuNhanVien.RectColor = Color.Transparent;
            btnMenuNhanVien.Size = new Size(224, 50);
            btnMenuNhanVien.TabIndex = 5;
            btnMenuNhanVien.Text = "👥 Quản lý Nhân sự";
            btnMenuNhanVien.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            // 
            // btnMenuKho
            // 
            btnMenuKho.BackColor = Color.Transparent;
            btnMenuKho.FillColor = Color.RosyBrown;
            btnMenuKho.FillHoverColor = Color.FromArgb(152, 98, 61);
            btnMenuKho.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnMenuKho.Location = new Point(3, 227);
            btnMenuKho.MinimumSize = new Size(1, 1);
            btnMenuKho.Name = "btnMenuKho";
            btnMenuKho.Radius = 20;
            btnMenuKho.RectColor = Color.Transparent;
            btnMenuKho.Size = new Size(224, 50);
            btnMenuKho.TabIndex = 4;
            btnMenuKho.Text = "📦 Quản lý Kho";
            btnMenuKho.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            // 
            // btnMenuThucDon
            // 
            btnMenuThucDon.BackColor = Color.Transparent;
            btnMenuThucDon.FillColor = Color.RosyBrown;
            btnMenuThucDon.FillHoverColor = Color.FromArgb(152, 98, 61);
            btnMenuThucDon.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnMenuThucDon.Location = new Point(3, 171);
            btnMenuThucDon.MinimumSize = new Size(1, 1);
            btnMenuThucDon.Name = "btnMenuThucDon";
            btnMenuThucDon.Radius = 20;
            btnMenuThucDon.RectColor = Color.Transparent;
            btnMenuThucDon.Size = new Size(224, 50);
            btnMenuThucDon.TabIndex = 3;
            btnMenuThucDon.Text = "📋 Quản lý Thực đơn";
            btnMenuThucDon.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            // 
            // btnMenuBep
            // 
            btnMenuBep.BackColor = Color.Transparent;
            btnMenuBep.FillColor = Color.RosyBrown;
            btnMenuBep.FillHoverColor = Color.FromArgb(152, 98, 61);
            btnMenuBep.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnMenuBep.Location = new Point(3, 115);
            btnMenuBep.MinimumSize = new Size(1, 1);
            btnMenuBep.Name = "btnMenuBep";
            btnMenuBep.Radius = 20;
            btnMenuBep.RectColor = Color.Transparent;
            btnMenuBep.Size = new Size(224, 50);
            btnMenuBep.TabIndex = 2;
            btnMenuBep.Text = "👨‍🍳 Khu vực Bếp, Bar";
            btnMenuBep.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            // 
            // btnMenuThuNgan
            // 
            btnMenuThuNgan.BackColor = Color.Transparent;
            btnMenuThuNgan.FillColor = Color.RosyBrown;
            btnMenuThuNgan.FillHoverColor = Color.FromArgb(152, 98, 61);
            btnMenuThuNgan.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnMenuThuNgan.Location = new Point(3, 59);
            btnMenuThuNgan.MinimumSize = new Size(1, 1);
            btnMenuThuNgan.Name = "btnMenuThuNgan";
            btnMenuThuNgan.Radius = 20;
            btnMenuThuNgan.RectColor = Color.Transparent;
            btnMenuThuNgan.Size = new Size(224, 50);
            btnMenuThuNgan.TabIndex = 1;
            btnMenuThuNgan.Text = "💵 Thu ngân, Thanh toán";
            btnMenuThuNgan.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            // 
            // btnMenuBanAn
            // 
            btnMenuBanAn.BackColor = Color.Transparent;
            btnMenuBanAn.FillColor = Color.RosyBrown;
            btnMenuBanAn.FillHoverColor = Color.FromArgb(152, 98, 61);
            btnMenuBanAn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnMenuBanAn.Location = new Point(3, 3);
            btnMenuBanAn.MinimumSize = new Size(1, 1);
            btnMenuBanAn.Name = "btnMenuBanAn";
            btnMenuBanAn.Radius = 20;
            btnMenuBanAn.RectColor = Color.Transparent;
            btnMenuBanAn.Size = new Size(224, 50);
            btnMenuBanAn.TabIndex = 0;
            btnMenuBanAn.Text = "\U0001fa91 Sơ đồ bàn, Đặt món";
            btnMenuBanAn.TipsFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 163);
            btnMenuBanAn.Click += btnMenuBanAn_Click;
            // 
            // panelContent
            // 
            panelContent.Controls.Add(panelChat);
            panelContent.Dock = DockStyle.Fill;
            panelContent.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            panelContent.Location = new Point(230, 88);
            panelContent.Margin = new Padding(4, 5, 4, 5);
            panelContent.MinimumSize = new Size(1, 1);
            panelContent.Name = "panelContent";
            panelContent.RectColor = Color.Transparent;
            panelContent.Size = new Size(1136, 645);
            panelContent.TabIndex = 3;
            panelContent.Text = null;
            panelContent.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // panelChat
            // 
            panelChat.Dock = DockStyle.Right;
            panelChat.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 163);
            panelChat.Location = new Point(816, 0);
            panelChat.Margin = new Padding(4, 5, 4, 5);
            panelChat.MinimumSize = new Size(1, 1);
            panelChat.Name = "panelChat";
            panelChat.RectColor = Color.Transparent;
            panelChat.Size = new Size(320, 645);
            panelChat.TabIndex = 0;
            panelChat.Text = null;
            panelChat.TextAlignment = ContentAlignment.MiddleCenter;
            panelChat.Visible = false;
            // 
            // timer1
            // 
            timer1.Tick += timer1_Tick;
            // 
            // MainForm
            // 
            AutoScaleMode = AutoScaleMode.None;
            ClientSize = new Size(1366, 768);
            Controls.Add(panelContent);
            Controls.Add(panelSidebar);
            Controls.Add(panelFooter);
            Controls.Add(panelHeader);
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(1024, 600);
            Name = "MainForm";
            RectColor = Color.Transparent;
            ShowFullScreen = true;
            Text = "RESTAURANT MANAGEMENT";
            TitleColor = Color.FromArgb(152, 98, 61);
            TitleFont = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            panelHeader.ResumeLayout(false);
            uiPanel1.ResumeLayout(false);
            uiPanel1.PerformLayout();
            uiPanel2.ResumeLayout(false);
            panelFooter.ResumeLayout(false);
            panelSidebar.ResumeLayout(false);
            panelContent.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UIPanel panelHeader;
        private Sunny.UI.UIPanel panelFooter;
        private Sunny.UI.UIPanel panelSidebar;
        private Sunny.UI.UIPanel panelContent;
        private Sunny.UI.UIPanel panelChat;
        private Sunny.UI.UILabel uiLabel1;
        private Sunny.UI.UIAvatar uiAvatar1;
        private Sunny.UI.UIButton btnLogout;
        private Sunny.UI.UIButton btnOpenChat;
        private Sunny.UI.UIButton btnMenuBep;
        private Sunny.UI.UIButton btnMenuThuNgan;
        private Sunny.UI.UIButton btnMenuBanAn;
        private Sunny.UI.UIButton btnMenuBaoCao;
        private Sunny.UI.UIButton btnMenuNhanVien;
        private Sunny.UI.UIButton btnMenuKho;
        private Sunny.UI.UIButton btnMenuThucDon;
        private Sunny.UI.UILabel lblClock;
        private Sunny.UI.UILabel lblNetworkStatus;
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UIPanel uiPanel1;
        private Sunny.UI.UIPanel uiPanel2;
        private Sunny.UI.UILabel uiLabel2;
    }
}