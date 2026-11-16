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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            timer1 = new System.Windows.Forms.Timer(components);
            pnlHeadder = new Sunny.UI.UIPanel();
            header = new Sunny.UI.UITableLayoutPanel();
            panel4 = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            Trochuyen = new Sunny.UI.UISymbolButton();
            DangXuat = new Sunny.UI.UISymbolButton();
            Ten = new Sunny.UI.UILabel();
            chucVu = new Sunny.UI.UILabel();
            sep2 = new Panel();
            GioiTinh = new Sunny.UI.UISymbolButton();
            Ten_nhaHang = new Sunny.UI.UILabel();
            sep1 = new Panel();
            pictureBox1 = new PictureBox();
            primary_pnl = new Sunny.UI.UITableLayoutPanel();
            footer = new Sunny.UI.UIPanel();
            lblTime = new Sunny.UI.UILabel();
            lblConnectionStatus = new Sunny.UI.UILabel();
            main = new Sunny.UI.UITableLayoutPanel();
            a = new Sunny.UI.UIPanel();
            Sidebar = new Sunny.UI.UIFlowLayoutPanel();
            btnsodoban = new Sunny.UI.UISymbolButton();
            pnlHeadder.SuspendLayout();
            header.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            primary_pnl.SuspendLayout();
            footer.SuspendLayout();
            main.SuspendLayout();
            Sidebar.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += Timer1_Tick;
            // 
            // pnlHeadder
            // 
            pnlHeadder.BackColor = Color.FromArgb(241, 228, 216);
            pnlHeadder.Controls.Add(header);
            pnlHeadder.Dock = DockStyle.Fill;
            pnlHeadder.FillColor = Color.Empty;
            pnlHeadder.FillColor2 = Color.Empty;
            pnlHeadder.Font = new Font("Microsoft Sans Serif", 12F);
            pnlHeadder.Location = new Point(0, 0);
            pnlHeadder.Margin = new Padding(0);
            pnlHeadder.MinimumSize = new Size(1, 1);
            pnlHeadder.Name = "pnlHeadder";
            pnlHeadder.RectColor = Color.FromArgb(255, 252, 248);
            pnlHeadder.Size = new Size(1366, 65);
            pnlHeadder.TabIndex = 0;
            pnlHeadder.Text = null;
            pnlHeadder.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // header
            // 
            header.ColumnCount = 12;
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 69F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 13F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.7931328F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.6984673F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.851788759F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.7249813F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.4801121F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 13F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.306463F));
            header.Controls.Add(panel4, 10, 0);
            header.Controls.Add(panel2, 3, 0);
            header.Controls.Add(panel1, 1, 0);
            header.Controls.Add(Trochuyen, 4, 0);
            header.Controls.Add(DangXuat, 11, 0);
            header.Controls.Add(Ten, 7, 0);
            header.Controls.Add(chucVu, 9, 0);
            header.Controls.Add(sep2, 8, 0);
            header.Controls.Add(GioiTinh, 6, 0);
            header.Controls.Add(Ten_nhaHang, 2, 0);
            header.Controls.Add(sep1, 5, 0);
            header.Controls.Add(pictureBox1, 0, 0);
            header.Dock = DockStyle.Fill;
            header.ForeColor = Color.FromArgb(241, 228, 216);
            header.Location = new Point(0, 0);
            header.Margin = new Padding(0);
            header.Name = "header";
            header.RowCount = 1;
            header.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            header.Size = new Size(1366, 65);
            header.TabIndex = 0;
            header.TagString = null;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.None;
            panel4.BackColor = Color.FromArgb(220, 203, 192);
            panel4.Location = new Point(1290, 0);
            panel4.Margin = new Padding(0);
            panel4.Name = "panel4";
            panel4.Size = new Size(8, 65);
            panel4.TabIndex = 11;
            // 
            // panel2
            // 
            panel2.Anchor = AnchorStyles.None;
            panel2.BackColor = Color.FromArgb(220, 203, 192);
            panel2.Location = new Point(402, 0);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(8, 65);
            panel2.TabIndex = 10;
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.FromArgb(220, 203, 192);
            panel1.Location = new Point(71, 0);
            panel1.Margin = new Padding(0);
            panel1.Name = "panel1";
            panel1.Size = new Size(8, 65);
            panel1.TabIndex = 9;
            // 
            // Trochuyen
            // 
            Trochuyen.Cursor = Cursors.Hand;
            Trochuyen.Dock = DockStyle.Fill;
            Trochuyen.FillColor = Color.FromArgb(223, 194, 168);
            Trochuyen.FillHoverColor = Color.FromArgb(234, 215, 197);
            Trochuyen.FillPressColor = Color.FromArgb(223, 194, 168);
            Trochuyen.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            Trochuyen.ForeColor = Color.FromArgb(75, 52, 38);
            Trochuyen.Location = new Point(415, 3);
            Trochuyen.MinimumSize = new Size(1, 1);
            Trochuyen.Name = "Trochuyen";
            Trochuyen.Radius = 30;
            Trochuyen.RectColor = Color.FromArgb(241, 228, 216);
            Trochuyen.RectDisableColor = Color.FromArgb(241, 228, 216);
            Trochuyen.RectHoverColor = Color.FromArgb(241, 228, 216);
            Trochuyen.RectPressColor = Color.FromArgb(241, 228, 216);
            Trochuyen.RectSelectedColor = Color.FromArgb(241, 228, 216);
            Trochuyen.Size = new Size(240, 59);
            Trochuyen.Symbol = 61574;
            Trochuyen.SymbolColor = Color.FromArgb(109, 71, 46);
            Trochuyen.SymbolSize = 40;
            Trochuyen.TabIndex = 1;
            Trochuyen.Text = "Trò chuyện";
            Trochuyen.TipsFont = new Font("Microsoft Sans Serif", 9F);
            Trochuyen.Click += Trochuyen_Click;
            // 
            // DangXuat
            // 
            DangXuat.BackColor = Color.FromArgb(241, 228, 216);
            DangXuat.Cursor = Cursors.Hand;
            DangXuat.Dock = DockStyle.Fill;
            DangXuat.FillColor = Color.FromArgb(217, 83, 79);
            DangXuat.FillHoverColor = Color.FromArgb(199, 71, 66);
            DangXuat.FillPressColor = Color.FromArgb(178, 57, 53);
            DangXuat.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            DangXuat.Location = new Point(1304, 3);
            DangXuat.MinimumSize = new Size(1, 1);
            DangXuat.Name = "DangXuat";
            DangXuat.Radius = 30;
            DangXuat.RectColor = Color.FromArgb(217, 83, 79);
            DangXuat.RectDisableColor = Color.FromArgb(217, 83, 79);
            DangXuat.RectHoverColor = Color.FromArgb(217, 83, 79);
            DangXuat.RectPressColor = Color.FromArgb(217, 83, 79);
            DangXuat.RectSelectedColor = Color.FromArgb(217, 83, 79);
            DangXuat.Size = new Size(59, 59);
            DangXuat.Symbol = 61579;
            DangXuat.SymbolSize = 40;
            DangXuat.TabIndex = 2;
            DangXuat.TipsFont = new Font("Microsoft Sans Serif", 9F);
            DangXuat.Click += DangXuat_Click;
            // 
            // Ten
            // 
            Ten.BackColor = Color.FromArgb(241, 228, 216);
            Ten.Dock = DockStyle.Fill;
            Ten.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Ten.ForeColor = Color.FromArgb(109, 71, 46);
            Ten.ImageAlign = ContentAlignment.MiddleLeft;
            Ten.Location = new Point(728, 0);
            Ten.Margin = new Padding(0);
            Ten.Name = "Ten";
            Ten.Size = new Size(341, 65);
            Ten.TabIndex = 4;
            Ten.Text = "Tên Nhân Viên";
            Ten.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // chucVu
            // 
            chucVu.BackColor = Color.FromArgb(241, 228, 216);
            chucVu.Dock = DockStyle.Fill;
            chucVu.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            chucVu.ForeColor = Color.FromArgb(109, 71, 46);
            chucVu.Location = new Point(1081, 0);
            chucVu.Margin = new Padding(0);
            chucVu.Name = "chucVu";
            chucVu.Size = new Size(207, 65);
            chucVu.TabIndex = 5;
            chucVu.Text = "Chức Vụ";
            chucVu.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sep2
            // 
            sep2.Anchor = AnchorStyles.None;
            sep2.BackColor = Color.FromArgb(220, 203, 192);
            sep2.Location = new Point(1071, 0);
            sep2.Margin = new Padding(0);
            sep2.Name = "sep2";
            sep2.Size = new Size(8, 65);
            sep2.TabIndex = 6;
            // 
            // GioiTinh
            // 
            GioiTinh.Dock = DockStyle.Fill;
            GioiTinh.Enabled = false;
            GioiTinh.FillColor = Color.FromArgb(74, 144, 226);
            GioiTinh.Font = new Font("Microsoft Sans Serif", 12F);
            GioiTinh.ForeDisableColor = Color.White;
            GioiTinh.Location = new Point(671, 3);
            GioiTinh.MinimumSize = new Size(1, 1);
            GioiTinh.Name = "GioiTinh";
            GioiTinh.Radius = 14;
            GioiTinh.RectDisableColor = Color.Empty;
            GioiTinh.Size = new Size(54, 59);
            GioiTinh.Symbol = 61827;
            GioiTinh.SymbolDisableColor = Color.White;
            GioiTinh.SymbolSize = 40;
            GioiTinh.TabIndex = 3;
            GioiTinh.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // Ten_nhaHang
            // 
            Ten_nhaHang.BackColor = Color.FromArgb(241, 228, 216);
            Ten_nhaHang.Dock = DockStyle.Fill;
            Ten_nhaHang.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 163);
            Ten_nhaHang.ForeColor = Color.FromArgb(109, 71, 46);
            Ten_nhaHang.Location = new Point(82, 0);
            Ten_nhaHang.Margin = new Padding(0);
            Ten_nhaHang.Name = "Ten_nhaHang";
            Ten_nhaHang.Size = new Size(318, 65);
            Ten_nhaHang.TabIndex = 7;
            Ten_nhaHang.Text = "THE GOURMET RESTAURANT";
            Ten_nhaHang.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // sep1
            // 
            sep1.Anchor = AnchorStyles.None;
            sep1.BackColor = Color.FromArgb(220, 203, 192);
            sep1.Location = new Point(659, 0);
            sep1.Margin = new Padding(0);
            sep1.Name = "sep1";
            sep1.Size = new Size(8, 65);
            sep1.TabIndex = 6;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(241, 228, 216);
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Margin = new Padding(0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(69, 65);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // primary_pnl
            // 
            primary_pnl.ColumnCount = 1;
            primary_pnl.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            primary_pnl.Controls.Add(footer, 0, 2);
            primary_pnl.Controls.Add(main, 0, 1);
            primary_pnl.Controls.Add(pnlHeadder, 0, 0);
            primary_pnl.Dock = DockStyle.Fill;
            primary_pnl.Location = new Point(0, 35);
            primary_pnl.Margin = new Padding(0);
            primary_pnl.Name = "primary_pnl";
            primary_pnl.RowCount = 3;
            primary_pnl.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            primary_pnl.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            primary_pnl.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            primary_pnl.Size = new Size(1366, 733);
            primary_pnl.TabIndex = 0;
            primary_pnl.TagString = null;
            // 
            // footer
            // 
            footer.BackColor = Color.FromArgb(241, 228, 216);
            footer.Controls.Add(lblTime);
            footer.Controls.Add(lblConnectionStatus);
            footer.Dock = DockStyle.Fill;
            footer.FillColor = Color.FromArgb(241, 228, 216);
            footer.Font = new Font("Microsoft Sans Serif", 12F);
            footer.Location = new Point(0, 698);
            footer.Margin = new Padding(0);
            footer.MinimumSize = new Size(1, 1);
            footer.Name = "footer";
            footer.RectColor = Color.Empty;
            footer.RectSides = ToolStripStatusLabelBorderSides.None;
            footer.Size = new Size(1366, 35);
            footer.TabIndex = 11;
            footer.Text = null;
            footer.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // lblTime
            // 
            lblTime.BackColor = Color.Transparent;
            lblTime.Dock = DockStyle.Right;
            lblTime.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTime.ForeColor = Color.FromArgb(139, 90, 58);
            lblTime.Location = new Point(939, 0);
            lblTime.Margin = new Padding(0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(427, 35);
            lblTime.TabIndex = 1;
            lblTime.Text = "time";
            lblTime.TextAlign = ContentAlignment.MiddleRight;
            // 
            // lblConnectionStatus
            // 
            lblConnectionStatus.BackColor = Color.Transparent;
            lblConnectionStatus.Dock = DockStyle.Left;
            lblConnectionStatus.Font = new Font("Segoe UI", 9F);
            lblConnectionStatus.ForeColor = Color.FromArgb(57, 132, 91);
            lblConnectionStatus.Location = new Point(0, 0);
            lblConnectionStatus.Margin = new Padding(0);
            lblConnectionStatus.Name = "lblConnectionStatus";
            lblConnectionStatus.Size = new Size(120, 35);
            lblConnectionStatus.TabIndex = 0;
            lblConnectionStatus.Text = "● Đã kết nối";
            lblConnectionStatus.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // main
            // 
            main.ColumnCount = 2;
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 270F));
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            main.Controls.Add(a, 1, 0);
            main.Controls.Add(Sidebar, 0, 0);
            main.Dock = DockStyle.Fill;
            main.Location = new Point(0, 65);
            main.Margin = new Padding(0);
            main.Name = "main";
            main.RowCount = 1;
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            main.Size = new Size(1366, 633);
            main.TabIndex = 12;
            main.TagString = null;
            // 
            // a
            // 
            a.Dock = DockStyle.Fill;
            a.FillColor = Color.FromArgb(241, 228, 216);
            a.FillColor2 = Color.Empty;
            a.Font = new Font("Microsoft Sans Serif", 12F);
            a.Location = new Point(270, 0);
            a.Margin = new Padding(0);
            a.MinimumSize = new Size(1, 1);
            a.Name = "a";
            a.RectColor = Color.Empty;
            a.Size = new Size(1096, 633);
            a.TabIndex = 3;
            a.Text = null;
            a.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // Sidebar
            // 
            Sidebar.Controls.Add(btnsodoban);
            Sidebar.Dock = DockStyle.Fill;
            Sidebar.FillColor = Color.FromArgb(152, 98, 61);
            Sidebar.FlowDirection = FlowDirection.TopDown;
            Sidebar.Font = new Font("Microsoft Sans Serif", 12F);
            Sidebar.Location = new Point(0, 0);
            Sidebar.Margin = new Padding(0);
            Sidebar.MinimumSize = new Size(1, 1);
            Sidebar.Name = "Sidebar";
            Sidebar.Padding = new Padding(8);
            Sidebar.RectColor = Color.Empty;
            Sidebar.RectSides = ToolStripStatusLabelBorderSides.None;
            Sidebar.ShowText = false;
            Sidebar.Size = new Size(270, 633);
            Sidebar.TabIndex = 4;
            Sidebar.Text = "uiFlowLayoutPanel1";
            Sidebar.TextAlignment = ContentAlignment.MiddleCenter;
            Sidebar.WrapContents = false;
            // 
            // btnsodoban
            // 
            btnsodoban.BackColor = Color.Transparent;
            btnsodoban.FillColor = Color.FromArgb(139, 90, 58);
            btnsodoban.FillColor2 = Color.Empty;
            btnsodoban.FillHoverColor = Color.FromArgb(158, 108, 75);
            btnsodoban.FillPressColor = Color.FromArgb(115, 72, 45);
            btnsodoban.FillSelectedColor = Color.Empty;
            btnsodoban.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnsodoban.Location = new Point(15, 8);
            btnsodoban.MinimumSize = new Size(1, 1);
            btnsodoban.Name = "btnsodoban";
            btnsodoban.Radius = 50;
            btnsodoban.RectColor = Color.FromArgb(139, 90, 58);
            btnsodoban.RectDisableColor = Color.FromArgb(139, 90, 58);
            btnsodoban.RectHoverColor = Color.FromArgb(139, 90, 58);
            btnsodoban.RectPressColor = Color.FromArgb(139, 90, 58);
            btnsodoban.RectSelectedColor = Color.FromArgb(139, 90, 58);
            btnsodoban.Size = new Size(244, 75);
            btnsodoban.Symbol = 61449;
            btnsodoban.SymbolColor = Color.FromArgb(245, 230, 211);
            btnsodoban.SymbolSize = 40;
            btnsodoban.TabIndex = 14;
            btnsodoban.Text = "Sơ Đồ Bàn";
            btnsodoban.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnsodoban.Click += btnSoDoBan_Click;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(144F, 144F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1366, 768);
            Controls.Add(primary_pnl);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IconImage = (Image)resources.GetObject("$this.IconImage");
            MaximumSize = new Size(2560, 1440);
            MinimumSize = new Size(1024, 600);
            Name = "MainForm";
            RectColor = Color.Transparent;
            ShowFullScreen = true;
            Text = "RESTAURANT MANAGEMENT";
            TitleColor = Color.FromArgb(152, 98, 61);
            TitleFont = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            //FormClosed += MainForm_Close;
            Load += MainForm_Load;
            pnlHeadder.ResumeLayout(false);
            header.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            primary_pnl.ResumeLayout(false);
            footer.ResumeLayout(false);
            main.ResumeLayout(false);
            Sidebar.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UIPanel pnlHeadder;
        private Sunny.UI.UITableLayoutPanel header;
        private Panel panel4;
        private Panel panel2;
        private Panel panel1;
        private Sunny.UI.UISymbolButton Trochuyen;
        private Sunny.UI.UISymbolButton DangXuat;
        private Sunny.UI.UILabel Ten;
        private Sunny.UI.UILabel chucVu;
        private Panel sep2;
        private Sunny.UI.UISymbolButton GioiTinh;
        private Sunny.UI.UILabel Ten_nhaHang;
        private Panel sep1;
        private PictureBox pictureBox1;
        private Sunny.UI.UITableLayoutPanel primary_pnl;
        private Sunny.UI.UIPanel footer;
        private Sunny.UI.UILabel lblTime;
        private Sunny.UI.UILabel lblConnectionStatus;
        private Sunny.UI.UIPanel a;
        private Sunny.UI.UITableLayoutPanel main;
        private Sunny.UI.UIFlowLayoutPanel Sidebar;
        private Sunny.UI.UISymbolButton btnsodoban;
    }
}