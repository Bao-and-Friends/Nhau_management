using Sunny.UI;

namespace RestaurantManagement.UI
{
    partial class LoginUI
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginUI));
            tableLayoutPanel1 = new TableLayoutPanel();
            pictureBox1 = new PictureBox();
            formDangNhap = new UIPanel();
            username = new UITextBox();
            pictureBox2 = new PictureBox();
            QuenMatKhau = new UILinkLabel();
            Dangnhap = new UIButton();
            uiLabelTitle = new UILabel();
            pwtxt = new UITextBox();
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            formDangNhap.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Controls.Add(formDangNhap, 1, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 35);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1733, 982);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1126, 982);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 2;
            pictureBox1.TabStop = false;
            // 
            // formDangNhap
            // 
            formDangNhap.Controls.Add(username);
            formDangNhap.Controls.Add(pictureBox2);
            formDangNhap.Controls.Add(QuenMatKhau);
            formDangNhap.Controls.Add(Dangnhap);
            formDangNhap.Controls.Add(uiLabelTitle);
            formDangNhap.Controls.Add(pwtxt);
            formDangNhap.Dock = DockStyle.Fill;
            formDangNhap.FillColor = Color.FromArgb(245, 230, 211);
            formDangNhap.Font = new Font("Microsoft Sans Serif", 12F);
            formDangNhap.Location = new Point(1126, 0);
            formDangNhap.Margin = new Padding(0);
            formDangNhap.MinimumSize = new Size(1, 1);
            formDangNhap.Name = "formDangNhap";
            formDangNhap.RectColor = Color.White;
            formDangNhap.Size = new Size(607, 982);
            formDangNhap.TabIndex = 0;
            formDangNhap.Text = null;
            formDangNhap.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // username
            // 
            username.Anchor = AnchorStyles.None;
            username.BackColor = Color.Transparent;
            username.ButtonFillColor = Color.Empty;
            username.ButtonFillHoverColor = Color.Empty;
            username.ButtonFillPressColor = Color.Empty;
            username.ButtonForeColor = Color.Empty;
            username.ButtonForeHoverColor = Color.Empty;
            username.ButtonForePressColor = Color.Empty;
            username.ButtonRectColor = Color.Empty;
            username.ButtonRectHoverColor = Color.Empty;
            username.ButtonRectPressColor = Color.Empty;
            username.ButtonStyleInherited = false;
            username.ButtonSymbol = 61550;
            username.ButtonSymbolSize = 30;
            username.FillColor2 = Color.Empty;
            username.FillDisableColor = Color.Empty;
            username.FillReadOnlyColor = Color.Empty;
            username.Font = new Font("Microsoft Sans Serif", 12F);
            username.ForeColor = Color.Empty;
            username.ForeDisableColor = Color.Empty;
            username.ForeReadOnlyColor = Color.Empty;
            username.Icon = (Image)resources.GetObject("username.Icon");
            username.Location = new Point(71, 272);
            username.Margin = new Padding(4, 5, 4, 5);
            username.MinimumSize = new Size(1, 16);
            username.Name = "username";
            username.Padding = new Padding(5);
            username.Radius = 20;
            username.RectColor = Color.Empty;
            username.RectDisableColor = Color.Empty;
            username.RectReadOnlyColor = Color.Empty;
            username.ScrollBarBackColor = Color.Empty;
            username.ScrollBarColor = Color.Empty;
            username.ScrollBarStyleInherited = false;
            username.ShowText = false;
            username.Size = new Size(467, 70);
            username.TabIndex = 0;
            username.TextAlignment = ContentAlignment.MiddleLeft;
            username.Watermark = "Tên đăng nhập";
            username.WatermarkColor = Color.FromArgb(184, 124, 80);
            // 
            // pictureBox2
            // 
            pictureBox2.Anchor = AnchorStyles.None;
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = (Image)resources.GetObject("pictureBox2.Image");
            pictureBox2.Location = new Point(241, 99);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(128, 122);
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.TabIndex = 0;
            pictureBox2.TabStop = false;
            // 
            // QuenMatKhau
            // 
            QuenMatKhau.ActiveLinkColor = Color.FromArgb(184, 124, 80);
            QuenMatKhau.Anchor = AnchorStyles.None;
            QuenMatKhau.BackColor = Color.Transparent;
            QuenMatKhau.Font = new Font("Segoe UI", 10F);
            QuenMatKhau.ForeColor = Color.FromArgb(48, 48, 48);
            QuenMatKhau.LinkBehavior = LinkBehavior.AlwaysUnderline;
            QuenMatKhau.LinkColor = Color.FromArgb(152, 98, 61);
            QuenMatKhau.Location = new Point(379, 427);
            QuenMatKhau.Name = "QuenMatKhau";
            QuenMatKhau.Size = new Size(159, 43);
            QuenMatKhau.TabIndex = 3;
            QuenMatKhau.TabStop = true;
            QuenMatKhau.Text = "Quên Mật Khẩu?";
            QuenMatKhau.TextAlign = ContentAlignment.MiddleCenter;
            QuenMatKhau.VisitedLinkColor = Color.FromArgb(230, 80, 80);
            // 
            // Dangnhap
            // 
            Dangnhap.Anchor = AnchorStyles.None;
            Dangnhap.BackColor = Color.Transparent;
            Dangnhap.FillColor = Color.FromArgb(152, 98, 61);
            Dangnhap.FillColor2 = Color.Empty;
            Dangnhap.FillHoverColor = Color.FromArgb(184, 124, 80);
            Dangnhap.FillPressColor = Color.FromArgb(184, 124, 80);
            Dangnhap.FillSelectedColor = Color.FromArgb(184, 124, 80);
            Dangnhap.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Dangnhap.Location = new Point(71, 473);
            Dangnhap.MinimumSize = new Size(1, 1);
            Dangnhap.Name = "Dangnhap";
            Dangnhap.Radius = 20;
            Dangnhap.RectColor = Color.Empty;
            Dangnhap.RectDisableColor = Color.Empty;
            Dangnhap.RectHoverColor = Color.Black;
            Dangnhap.RectPressColor = Color.Empty;
            Dangnhap.RectSelectedColor = Color.Black;
            Dangnhap.Size = new Size(467, 58);
            Dangnhap.TabIndex = 2;
            Dangnhap.Text = "ĐĂNG NHẬP";
            Dangnhap.TipsColor = Color.Empty;
            Dangnhap.TipsFont = new Font("Microsoft Sans Serif", 9F);
            Dangnhap.TipsForeColor = Color.Empty;
            Dangnhap.Click += Dangnhap_Click;
            // 
            // uiLabelTitle
            // 
            uiLabelTitle.Anchor = AnchorStyles.None;
            uiLabelTitle.BackColor = Color.Transparent;
            uiLabelTitle.Font = new Font("Segoe UI Semibold", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiLabelTitle.ForeColor = Color.FromArgb(56, 42, 34);
            uiLabelTitle.Location = new Point(155, 208);
            uiLabelTitle.Name = "uiLabelTitle";
            uiLabelTitle.Size = new Size(311, 47);
            uiLabelTitle.TabIndex = 0;
            uiLabelTitle.Text = "Welcome Back";
            uiLabelTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // pwtxt
            // 
            pwtxt.Anchor = AnchorStyles.None;
            pwtxt.BackColor = Color.Transparent;
            pwtxt.ButtonFillColor = Color.Empty;
            pwtxt.ButtonFillHoverColor = Color.Empty;
            pwtxt.ButtonFillPressColor = Color.Empty;
            pwtxt.ButtonForeColor = Color.FromArgb(184, 124, 80);
            pwtxt.ButtonForeHoverColor = Color.FromArgb(184, 124, 80);
            pwtxt.ButtonForePressColor = Color.FromArgb(184, 124, 80);
            pwtxt.ButtonRectColor = Color.Empty;
            pwtxt.ButtonRectHoverColor = Color.Empty;
            pwtxt.ButtonRectPressColor = Color.Empty;
            pwtxt.ButtonStyleInherited = false;
            pwtxt.ButtonSymbol = 61550;
            pwtxt.ButtonSymbolSize = 30;
            pwtxt.FillColor2 = Color.Empty;
            pwtxt.FillDisableColor = Color.Empty;
            pwtxt.FillReadOnlyColor = Color.Empty;
            pwtxt.Font = new Font("Microsoft Sans Serif", 12F);
            pwtxt.ForeColor = Color.Empty;
            pwtxt.ForeDisableColor = Color.Empty;
            pwtxt.ForeReadOnlyColor = Color.Empty;
            pwtxt.Icon = (Image)resources.GetObject("pwtxt.Icon");
            pwtxt.Location = new Point(71, 352);
            pwtxt.Margin = new Padding(4, 5, 4, 5);
            pwtxt.MinimumSize = new Size(1, 16);
            pwtxt.Name = "pwtxt";
            pwtxt.Padding = new Padding(5);
            pwtxt.PasswordChar = '●';
            pwtxt.Radius = 20;
            pwtxt.RectColor = Color.Empty;
            pwtxt.RectDisableColor = Color.Empty;
            pwtxt.RectReadOnlyColor = Color.Empty;
            pwtxt.ScrollBarBackColor = Color.Empty;
            pwtxt.ScrollBarColor = Color.Empty;
            pwtxt.ScrollBarStyleInherited = false;
            pwtxt.ShowButton = true;
            pwtxt.ShowText = false;
            pwtxt.Size = new Size(467, 70);
            pwtxt.TabIndex = 1;
            pwtxt.TextAlignment = ContentAlignment.MiddleLeft;
            pwtxt.Watermark = "Mật khẩu";
            pwtxt.WatermarkColor = Color.FromArgb(184, 124, 80);
            pwtxt.ButtonClick += uiTextBox2_button_click;
            // 
            // LoginUI
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1733, 1017);
            Controls.Add(tableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximumSize = new Size(2560, 1368);
            MinimumSize = new Size(190, 40);
            Name = "LoginUI";
            Text = "";
            TitleColor = Color.FromArgb(152, 98, 61);
            ZoomScaleRect = new Rectangle(22, 22, 1733, 1017);
            tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            formDangNhap.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);

        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private Sunny.UI.UIPanel uiPanel2;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Sunny.UI.UILabel uiLabelTitle;
        private Sunny.UI.UITextBox uiTextBox1;
        private Sunny.UI.UITextBox uiTextBox2;
        private Sunny.UI.UIButton uiButton1;
        private Sunny.UI.UILinkLabel uiLinkLabel1;
        private UIButton Dangnhap;
        private UITextBox pwtxt;
        private UIPanel formDangNhap;
        private UILinkLabel QuenMatKhau;
        private UITextBox username;
    }
}
