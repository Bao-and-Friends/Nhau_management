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
            uiTableLayoutPanel2 = new Sunny.UI.UITableLayoutPanel();
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
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            footer = new Sunny.UI.UIPanel();
            lblTime = new Sunny.UI.UILabel();
            lblConnectionStatus = new Sunny.UI.UILabel();
            main = new Sunny.UI.UITableLayoutPanel();
            a = new Sunny.UI.UIPanel();
            uiFlowLayoutPanel1 = new Sunny.UI.UIFlowLayoutPanel();
            btnsodoban = new Sunny.UI.UISymbolButton();
            btnhoadon = new Sunny.UI.UISymbolButton();
            btnthanhtoan = new Sunny.UI.UISymbolButton();
            btndoanhthu = new Sunny.UI.UISymbolButton();
            uiSymbolButton6 = new Sunny.UI.UISymbolButton();
            uiSymbolButton7 = new Sunny.UI.UISymbolButton();
            uiSymbolButton8 = new Sunny.UI.UISymbolButton();
            pnlHeadder.SuspendLayout();
            uiTableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            uiTableLayoutPanel1.SuspendLayout();
            footer.SuspendLayout();
            main.SuspendLayout();
            uiFlowLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // timer1
            // 
            timer1.Tick += Timer1_Tick;
            // 
            // pnlHeadder
            // 
            pnlHeadder.BackColor = Color.FromArgb(241, 228, 216);
            pnlHeadder.Controls.Add(uiTableLayoutPanel2);
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
            // uiTableLayoutPanel2
            // 
            uiTableLayoutPanel2.ColumnCount = 12;
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 69F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 13F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 26.7931328F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 20.6984673F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 0.851788759F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 60F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28.7249813F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 12F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 17.4801121F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 13F));
            uiTableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 5.306463F));
            uiTableLayoutPanel2.Controls.Add(panel4, 10, 0);
            uiTableLayoutPanel2.Controls.Add(panel2, 3, 0);
            uiTableLayoutPanel2.Controls.Add(panel1, 1, 0);
            uiTableLayoutPanel2.Controls.Add(Trochuyen, 4, 0);
            uiTableLayoutPanel2.Controls.Add(DangXuat, 11, 0);
            uiTableLayoutPanel2.Controls.Add(Ten, 7, 0);
            uiTableLayoutPanel2.Controls.Add(chucVu, 9, 0);
            uiTableLayoutPanel2.Controls.Add(sep2, 8, 0);
            uiTableLayoutPanel2.Controls.Add(GioiTinh, 6, 0);
            uiTableLayoutPanel2.Controls.Add(Ten_nhaHang, 2, 0);
            uiTableLayoutPanel2.Controls.Add(sep1, 5, 0);
            uiTableLayoutPanel2.Controls.Add(pictureBox1, 0, 0);
            uiTableLayoutPanel2.Dock = DockStyle.Fill;
            uiTableLayoutPanel2.ForeColor = Color.FromArgb(241, 228, 216);
            uiTableLayoutPanel2.Location = new Point(0, 0);
            uiTableLayoutPanel2.Margin = new Padding(0);
            uiTableLayoutPanel2.Name = "uiTableLayoutPanel2";
            uiTableLayoutPanel2.RowCount = 1;
            uiTableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel2.Size = new Size(1366, 65);
            uiTableLayoutPanel2.TabIndex = 0;
            uiTableLayoutPanel2.TagString = null;
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
            Ten.Text = "Nguyễn Ngọc Huỳnh Như";
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
            chucVu.Text = "Phục Vụ";
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
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.ColumnCount = 1;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.Controls.Add(footer, 0, 2);
            uiTableLayoutPanel1.Controls.Add(main, 0, 1);
            uiTableLayoutPanel1.Controls.Add(pnlHeadder, 0, 0);
            uiTableLayoutPanel1.Dock = DockStyle.Fill;
            uiTableLayoutPanel1.Location = new Point(0, 35);
            uiTableLayoutPanel1.Margin = new Padding(0);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 3;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 65F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 35F));
            uiTableLayoutPanel1.Size = new Size(1366, 733);
            uiTableLayoutPanel1.TabIndex = 0;
            uiTableLayoutPanel1.TagString = null;
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
            footer.RectColor = Color.FromArgb(247, 241, 235);
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
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 246F));
            main.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            main.Controls.Add(a, 1, 0);
            main.Controls.Add(uiFlowLayoutPanel1, 0, 0);
            main.Dock = DockStyle.Fill;
            main.Location = new Point(3, 68);
            main.Name = "main";
            main.RowCount = 1;
            main.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            main.Size = new Size(1360, 627);
            main.TabIndex = 12;
            main.TagString = null;
            // 
            // a
            // 
            a.Dock = DockStyle.Fill;
            a.FillColor = Color.FromArgb(241, 228, 216);
            a.FillColor2 = Color.Empty;
            a.Font = new Font("Microsoft Sans Serif", 12F);
            a.Location = new Point(246, 0);
            a.Margin = new Padding(0);
            a.MinimumSize = new Size(1, 1);
            a.Name = "a";
            a.RectColor = Color.Empty;
            a.Size = new Size(1114, 627);
            a.TabIndex = 3;
            a.Text = null;
            a.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiFlowLayoutPanel1
            // 
            uiFlowLayoutPanel1.Controls.Add(btnsodoban);
            uiFlowLayoutPanel1.Controls.Add(btnhoadon);
            uiFlowLayoutPanel1.Controls.Add(btnthanhtoan);
            uiFlowLayoutPanel1.Controls.Add(btndoanhthu);
            uiFlowLayoutPanel1.Controls.Add(uiSymbolButton6);
            uiFlowLayoutPanel1.Controls.Add(uiSymbolButton7);
            uiFlowLayoutPanel1.Controls.Add(uiSymbolButton8);
            uiFlowLayoutPanel1.Dock = DockStyle.Fill;
            uiFlowLayoutPanel1.FillColor = Color.FromArgb(152, 98, 61);
            uiFlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            uiFlowLayoutPanel1.Font = new Font("Microsoft Sans Serif", 12F);
            uiFlowLayoutPanel1.Location = new Point(0, 0);
            uiFlowLayoutPanel1.Margin = new Padding(0);
            uiFlowLayoutPanel1.MinimumSize = new Size(1, 1);
            uiFlowLayoutPanel1.Name = "uiFlowLayoutPanel1";
            uiFlowLayoutPanel1.Padding = new Padding(8);
            uiFlowLayoutPanel1.ShowText = false;
            uiFlowLayoutPanel1.Size = new Size(246, 627);
            uiFlowLayoutPanel1.TabIndex = 4;
            uiFlowLayoutPanel1.Text = "uiFlowLayoutPanel1";
            uiFlowLayoutPanel1.TextAlignment = ContentAlignment.MiddleCenter;
            uiFlowLayoutPanel1.WrapContents = false;
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
            btnsodoban.Size = new Size(220, 75);
            btnsodoban.Symbol = 61449;
            btnsodoban.SymbolColor = Color.FromArgb(245, 230, 211);
            btnsodoban.SymbolSize = 40;
            btnsodoban.TabIndex = 14;
            btnsodoban.Text = "Sơ đồ bàn";
            btnsodoban.TipsFont = new Font("Microsoft Sans Serif", 9F);
            btnsodoban.Click += btnSoDoBan_Click;
            // 
            // btnhoadon
            // 
            btnhoadon.BackColor = Color.Transparent;
            btnhoadon.FillColor = Color.FromArgb(139, 90, 58);
            btnhoadon.FillColor2 = Color.Empty;
            btnhoadon.FillHoverColor = Color.FromArgb(158, 108, 75);
            btnhoadon.FillPressColor = Color.FromArgb(115, 72, 45);
            btnhoadon.FillSelectedColor = Color.Empty;
            btnhoadon.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnhoadon.Location = new Point(15, 89);
            btnhoadon.MinimumSize = new Size(1, 1);
            btnhoadon.Name = "btnhoadon";
            btnhoadon.Radius = 50;
            btnhoadon.RectColor = Color.FromArgb(139, 90, 58);
            btnhoadon.RectDisableColor = Color.FromArgb(139, 90, 58);
            btnhoadon.RectHoverColor = Color.FromArgb(139, 90, 58);
            btnhoadon.RectPressColor = Color.FromArgb(139, 90, 58);
            btnhoadon.RectSelectedColor = Color.FromArgb(139, 90, 58);
            btnhoadon.Size = new Size(220, 75);
            btnhoadon.Symbol = 61674;
            btnhoadon.SymbolColor = Color.FromArgb(245, 230, 211);
            btnhoadon.SymbolSize = 40;
            btnhoadon.TabIndex = 15;
            btnhoadon.Text = "Hóa Đơn";
            btnhoadon.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btnthanhtoan
            // 
            btnthanhtoan.BackColor = Color.Transparent;
            btnthanhtoan.FillColor = Color.FromArgb(139, 90, 58);
            btnthanhtoan.FillColor2 = Color.Empty;
            btnthanhtoan.FillHoverColor = Color.FromArgb(158, 108, 75);
            btnthanhtoan.FillPressColor = Color.FromArgb(115, 72, 45);
            btnthanhtoan.FillSelectedColor = Color.Empty;
            btnthanhtoan.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btnthanhtoan.Location = new Point(15, 170);
            btnthanhtoan.MinimumSize = new Size(1, 1);
            btnthanhtoan.Name = "btnthanhtoan";
            btnthanhtoan.Radius = 50;
            btnthanhtoan.RectColor = Color.FromArgb(139, 90, 58);
            btnthanhtoan.RectDisableColor = Color.FromArgb(139, 90, 58);
            btnthanhtoan.RectHoverColor = Color.FromArgb(139, 90, 58);
            btnthanhtoan.RectPressColor = Color.FromArgb(139, 90, 58);
            btnthanhtoan.RectSelectedColor = Color.FromArgb(139, 90, 58);
            btnthanhtoan.Size = new Size(220, 75);
            btnthanhtoan.Symbol = 61597;
            btnthanhtoan.SymbolColor = Color.FromArgb(245, 230, 211);
            btnthanhtoan.SymbolSize = 40;
            btnthanhtoan.TabIndex = 16;
            btnthanhtoan.Text = "Thanh Toán";
            btnthanhtoan.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // btndoanhthu
            // 
            btndoanhthu.BackColor = Color.Transparent;
            btndoanhthu.FillColor = Color.FromArgb(139, 90, 58);
            btndoanhthu.FillColor2 = Color.Empty;
            btndoanhthu.FillHoverColor = Color.FromArgb(158, 108, 75);
            btndoanhthu.FillPressColor = Color.FromArgb(115, 72, 45);
            btndoanhthu.FillSelectedColor = Color.Empty;
            btndoanhthu.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            btndoanhthu.Location = new Point(15, 251);
            btndoanhthu.MinimumSize = new Size(1, 1);
            btndoanhthu.Name = "btndoanhthu";
            btndoanhthu.Radius = 50;
            btndoanhthu.RectColor = Color.FromArgb(139, 90, 58);
            btndoanhthu.RectDisableColor = Color.FromArgb(139, 90, 58);
            btndoanhthu.RectHoverColor = Color.FromArgb(139, 90, 58);
            btndoanhthu.RectPressColor = Color.FromArgb(139, 90, 58);
            btndoanhthu.RectSelectedColor = Color.FromArgb(139, 90, 58);
            btndoanhthu.Size = new Size(220, 75);
            btndoanhthu.Symbol = 61568;
            btndoanhthu.SymbolColor = Color.FromArgb(245, 230, 211);
            btndoanhthu.SymbolSize = 40;
            btndoanhthu.TabIndex = 17;
            btndoanhthu.Text = "Doanh Thu";
            btndoanhthu.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiSymbolButton6
            // 
            uiSymbolButton6.BackColor = Color.Transparent;
            uiSymbolButton6.FillColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton6.FillColor2 = Color.Empty;
            uiSymbolButton6.FillHoverColor = Color.FromArgb(158, 108, 75);
            uiSymbolButton6.FillPressColor = Color.FromArgb(115, 72, 45);
            uiSymbolButton6.FillSelectedColor = Color.Empty;
            uiSymbolButton6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            uiSymbolButton6.Location = new Point(15, 332);
            uiSymbolButton6.MinimumSize = new Size(1, 1);
            uiSymbolButton6.Name = "uiSymbolButton6";
            uiSymbolButton6.Radius = 50;
            uiSymbolButton6.RectColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton6.RectDisableColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton6.RectHoverColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton6.RectPressColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton6.RectSelectedColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton6.Size = new Size(220, 75);
            uiSymbolButton6.Symbol = 61449;
            uiSymbolButton6.SymbolColor = Color.FromArgb(245, 230, 211);
            uiSymbolButton6.SymbolSize = 40;
            uiSymbolButton6.TabIndex = 18;
            uiSymbolButton6.Text = "uiSymbolButton6";
            uiSymbolButton6.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiSymbolButton7
            // 
            uiSymbolButton7.BackColor = Color.Transparent;
            uiSymbolButton7.FillColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton7.FillColor2 = Color.Empty;
            uiSymbolButton7.FillHoverColor = Color.FromArgb(158, 108, 75);
            uiSymbolButton7.FillPressColor = Color.FromArgb(115, 72, 45);
            uiSymbolButton7.FillSelectedColor = Color.Empty;
            uiSymbolButton7.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            uiSymbolButton7.Location = new Point(15, 413);
            uiSymbolButton7.MinimumSize = new Size(1, 1);
            uiSymbolButton7.Name = "uiSymbolButton7";
            uiSymbolButton7.Radius = 50;
            uiSymbolButton7.RectColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton7.RectDisableColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton7.RectHoverColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton7.RectPressColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton7.RectSelectedColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton7.Size = new Size(220, 75);
            uiSymbolButton7.Symbol = 61449;
            uiSymbolButton7.SymbolColor = Color.FromArgb(245, 230, 211);
            uiSymbolButton7.SymbolSize = 40;
            uiSymbolButton7.TabIndex = 19;
            uiSymbolButton7.Text = "uiSymbolButton7";
            uiSymbolButton7.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // uiSymbolButton8
            // 
            uiSymbolButton8.BackColor = Color.Transparent;
            uiSymbolButton8.FillColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton8.FillColor2 = Color.Empty;
            uiSymbolButton8.FillHoverColor = Color.FromArgb(158, 108, 75);
            uiSymbolButton8.FillPressColor = Color.FromArgb(115, 72, 45);
            uiSymbolButton8.FillSelectedColor = Color.Empty;
            uiSymbolButton8.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            uiSymbolButton8.Location = new Point(15, 494);
            uiSymbolButton8.MinimumSize = new Size(1, 1);
            uiSymbolButton8.Name = "uiSymbolButton8";
            uiSymbolButton8.Radius = 50;
            uiSymbolButton8.RectColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton8.RectDisableColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton8.RectHoverColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton8.RectPressColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton8.RectSelectedColor = Color.FromArgb(139, 90, 58);
            uiSymbolButton8.Size = new Size(220, 75);
            uiSymbolButton8.Symbol = 61449;
            uiSymbolButton8.SymbolColor = Color.FromArgb(245, 230, 211);
            uiSymbolButton8.SymbolSize = 40;
            uiSymbolButton8.TabIndex = 20;
            uiSymbolButton8.Text = "uiSymbolButton8";
            uiSymbolButton8.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(96F, 96F);
            AutoScaleMode = AutoScaleMode.Dpi;
            ClientSize = new Size(1366, 768);
            Controls.Add(uiTableLayoutPanel1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            IconImage = (Image)resources.GetObject("$this.IconImage");
            MaximumSize = new Size(1920, 1080);
            MinimumSize = new Size(1024, 600);
            Name = "MainForm";
            RectColor = Color.Transparent;
            ShowFullScreen = true;
            Text = "RESTAURANT MANAGEMENT";
            TitleColor = Color.FromArgb(152, 98, 61);
            TitleFont = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 163);
            ZoomScaleRect = new Rectangle(15, 15, 800, 450);
            Load += MainForm_Load;
            pnlHeadder.ResumeLayout(false);
            uiTableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            uiTableLayoutPanel1.ResumeLayout(false);
            footer.ResumeLayout(false);
            main.ResumeLayout(false);
            uiFlowLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Timer timer1;
        private Sunny.UI.UIPanel pnlHeadder;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel2;
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
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UIPanel footer;
        private Sunny.UI.UILabel lblTime;
        private Sunny.UI.UILabel lblConnectionStatus;
        private Sunny.UI.UIPanel a;
        private Sunny.UI.UITableLayoutPanel main;
        private Sunny.UI.UIFlowLayoutPanel uiFlowLayoutPanel1;
        private Sunny.UI.UISymbolButton btnsodoban;
        private Sunny.UI.UISymbolButton uiSymbolButton8;
        private Sunny.UI.UISymbolButton uiSymbolButton7;
        private Sunny.UI.UISymbolButton uiSymbolButton6;
        private Sunny.UI.UISymbolButton btndoanhthu;
        private Sunny.UI.UISymbolButton btnthanhtoan;
        private Sunny.UI.UISymbolButton btnhoadon;
    }
}