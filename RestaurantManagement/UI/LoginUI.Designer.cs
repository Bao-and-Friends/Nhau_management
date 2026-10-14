namespace RestaurantManagement
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
            uiPanel2 = new Sunny.UI.UIPanel();
            uiLinkLabel1 = new Sunny.UI.UILinkLabel();
            uiButton1 = new Sunny.UI.UIButton();
            uiTextBox1 = new Sunny.UI.UITextBox();
            uiLabelTitle = new Sunny.UI.UILabel();
            pictureBox2 = new PictureBox();
            uiTextBox2 = new Sunny.UI.UITextBox();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1.SuspendLayout();
            uiPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 2;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 65F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 35F));
            tableLayoutPanel1.Controls.Add(uiPanel2, 1, 0);
            tableLayoutPanel1.Controls.Add(pictureBox1, 0, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 35);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1733, 982);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // uiPanel2
            // 
            uiPanel2.Controls.Add(uiLinkLabel1);
            uiPanel2.Controls.Add(uiButton1);
            uiPanel2.Controls.Add(uiTextBox1);
            uiPanel2.Controls.Add(uiLabelTitle);
            uiPanel2.Controls.Add(pictureBox2);
            uiPanel2.Controls.Add(uiTextBox2);
            uiPanel2.Dock = DockStyle.Fill;
            uiPanel2.FillColor = Color.FromArgb(245, 230, 211);
            uiPanel2.Font = new Font("Microsoft Sans Serif", 12F);
            uiPanel2.Location = new Point(1126, 0);
            uiPanel2.Margin = new Padding(0);
            uiPanel2.MinimumSize = new Size(1, 1);
            uiPanel2.Name = "uiPanel2";
            uiPanel2.RectColor = Color.White;
            uiPanel2.Size = new Size(607, 982);
            uiPanel2.TabIndex = 1;
            uiPanel2.Text = null;
            uiPanel2.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiLinkLabel1
            // 
            uiLinkLabel1.ActiveLinkColor = Color.FromArgb(184, 124, 80);
            uiLinkLabel1.Anchor = AnchorStyles.None;
            uiLinkLabel1.BackColor = Color.Transparent;
            uiLinkLabel1.Font = new Font("Segoe UI", 10F);
            uiLinkLabel1.ForeColor = Color.FromArgb(48, 48, 48);
            uiLinkLabel1.LinkBehavior = LinkBehavior.AlwaysUnderline;
            uiLinkLabel1.LinkColor = Color.FromArgb(152, 98, 61);
            uiLinkLabel1.Location = new Point(379, 427);
            uiLinkLabel1.Name = "uiLinkLabel1";
            uiLinkLabel1.Size = new Size(159, 43);
            uiLinkLabel1.TabIndex = 5;
            uiLinkLabel1.TabStop = true;
            uiLinkLabel1.Text = "Quên Mật Khẩu?";
            uiLinkLabel1.TextAlign = ContentAlignment.MiddleCenter;
            uiLinkLabel1.VisitedLinkColor = Color.FromArgb(230, 80, 80);
            // 
            // uiButton1
            // 
            uiButton1.Anchor = AnchorStyles.None;
            uiButton1.BackColor = Color.Transparent;
            uiButton1.FillColor = Color.FromArgb(152, 98, 61);
            uiButton1.FillColor2 = Color.Empty;
            uiButton1.FillHoverColor = Color.FromArgb(184, 124, 80);
            uiButton1.FillPressColor = Color.FromArgb(184, 124, 80);
            uiButton1.FillSelectedColor = Color.FromArgb(184, 124, 80);
            uiButton1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            uiButton1.Location = new Point(71, 473);
            uiButton1.MinimumSize = new Size(1, 1);
            uiButton1.Name = "uiButton1";
            uiButton1.Radius = 20;
            uiButton1.RectColor = Color.White;
            uiButton1.RectDisableColor = Color.White;
            uiButton1.RectHoverColor = Color.White;
            uiButton1.RectPressColor = Color.White;
            uiButton1.RectSelectedColor = Color.White;
            uiButton1.Size = new Size(467, 58);
            uiButton1.TabIndex = 4;
            uiButton1.Text = "ĐĂNG NHẬP";
            uiButton1.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiTextBox1
            // 
            uiTextBox1.Anchor = AnchorStyles.None;
            uiTextBox1.BackColor = Color.Transparent;
            uiTextBox1.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox1.Location = new Point(71, 272);
            uiTextBox1.Margin = new Padding(4, 5, 4, 5);
            uiTextBox1.MinimumSize = new Size(1, 16);
            uiTextBox1.Name = "uiTextBox1";
            uiTextBox1.Padding = new Padding(5);
            uiTextBox1.Radius = 20;
            uiTextBox1.RectColor = Color.FromArgb(152, 98, 61);
            uiTextBox1.ShowText = false;
            uiTextBox1.Size = new Size(467, 70);
            uiTextBox1.TabIndex = 2;
            uiTextBox1.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox1.Watermark = "Tên đăng nhập";
            uiTextBox1.WatermarkActiveColor = Color.White;
            uiTextBox1.WatermarkColor = Color.Black;
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
            uiLabelTitle.TabIndex = 1;
            uiLabelTitle.Text = "Welcome Back";
            uiLabelTitle.TextAlign = ContentAlignment.MiddleCenter;
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
            // uiTextBox2
            // 
            uiTextBox2.Anchor = AnchorStyles.None;
            uiTextBox2.BackColor = Color.Transparent;
            uiTextBox2.Font = new Font("Microsoft Sans Serif", 12F);
            uiTextBox2.Location = new Point(71, 352);
            uiTextBox2.Margin = new Padding(4, 5, 4, 5);
            uiTextBox2.MinimumSize = new Size(1, 16);
            uiTextBox2.Name = "uiTextBox2";
            uiTextBox2.Padding = new Padding(5);
            uiTextBox2.Radius = 20;
            uiTextBox2.RectColor = Color.FromArgb(152, 98, 61);
            uiTextBox2.ShowText = false;
            uiTextBox2.Size = new Size(467, 70);
            uiTextBox2.TabIndex = 3;
            uiTextBox2.TextAlignment = ContentAlignment.MiddleLeft;
            uiTextBox2.Watermark = "Mật khẩu";
            uiTextBox2.WatermarkActiveColor = Color.White;
            uiTextBox2.WatermarkColor = Color.Black;
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
            Text = "Đăng Nhập";
            TitleColor = Color.FromArgb(152, 98, 61);
            ZoomScaleRect = new Rectangle(22, 22, 1733, 1017);
            tableLayoutPanel1.ResumeLayout(false);
            uiPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
    }
}
