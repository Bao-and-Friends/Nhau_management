namespace RestaurantManagement.UI
{
    partial class UC_SoDoBan
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            Sodoban = new Sunny.UI.UISplitContainer();
            fplSoDoBan = new Sunny.UI.UIFlowLayoutPanel();
            uiTableLayoutPanel1 = new Sunny.UI.UITableLayoutPanel();
            OrderInfo = new Sunny.UI.UIDataGridView();
            featureBtn = new Sunny.UI.UIFlowLayoutPanel();
            TienInfo = new Sunny.UI.UITableLayoutPanel();
            lblTongtien = new Sunny.UI.UILabel();
            lbltien = new Sunny.UI.UIPanel();
            headder = new Sunny.UI.UITableLayoutPanel();
            info = new Sunny.UI.UIPanel();
            TenBan = new Sunny.UI.UIPanel();
            status = new Sunny.UI.UIButton();
            hidebtn = new Sunny.UI.UISymbolButton();
            (Sodoban).BeginInit();
            Sodoban.Panel1.SuspendLayout();
            Sodoban.Panel2.SuspendLayout();
            Sodoban.SuspendLayout();
            uiTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)OrderInfo).BeginInit();
            TienInfo.SuspendLayout();
            headder.SuspendLayout();
            SuspendLayout();
            // 
            // Sodoban
            // 
            Sodoban.CollapsePanel = Sunny.UI.UISplitContainer.UICollapsePanel.Panel2;
            Sodoban.Dock = DockStyle.Fill;
            Sodoban.Location = new Point(0, 0);
            Sodoban.Margin = new Padding(0);
            Sodoban.MinimumSize = new Size(20, 20);
            Sodoban.Name = "Sodoban";
            // 
            // Sodoban.Panel1
            // 
            Sodoban.Panel1.BackColor = Color.FromArgb(241, 228, 216);
            Sodoban.Panel1.Controls.Add(fplSoDoBan);
            Sodoban.Panel1.RightToLeft = RightToLeft.No;
            // 
            // Sodoban.Panel2
            // 
            Sodoban.Panel2.BackColor = Color.FromArgb(241, 228, 200);
            Sodoban.Panel2.Controls.Add(uiTableLayoutPanel1);
            Sodoban.Panel2.RightToLeft = RightToLeft.No;
            Sodoban.Panel2Collapsed = true;
            Sodoban.RightToLeft = RightToLeft.No;
            Sodoban.Size = new Size(1120, 633);
            Sodoban.SplitterDistance = 725;
            Sodoban.SplitterWidth = 11;
            Sodoban.TabIndex = 0;
            // 
            // fplSoDoBan
            // 
            fplSoDoBan.Dock = DockStyle.Fill;
            fplSoDoBan.FillColor = Color.FromArgb(241, 228, 216);
            fplSoDoBan.Font = new Font("Microsoft Sans Serif", 12F);
            fplSoDoBan.Location = new Point(0, 0);
            fplSoDoBan.Margin = new Padding(0);
            fplSoDoBan.MinimumSize = new Size(1, 1);
            fplSoDoBan.Name = "fplSoDoBan";
            fplSoDoBan.Padding = new Padding(2);
            fplSoDoBan.RectColor = Color.Transparent;
            fplSoDoBan.RectSides = ToolStripStatusLabelBorderSides.None;
            fplSoDoBan.ShowText = false;
            fplSoDoBan.Size = new Size(1120, 633);
            fplSoDoBan.TabIndex = 0;
            fplSoDoBan.Text = null;
            fplSoDoBan.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // uiTableLayoutPanel1
            // 
            uiTableLayoutPanel1.BackColor = Color.Transparent;
            uiTableLayoutPanel1.ColumnCount = 1;
            uiTableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.Controls.Add(OrderInfo, 0, 1);
            uiTableLayoutPanel1.Controls.Add(featureBtn, 0, 3);
            uiTableLayoutPanel1.Controls.Add(TienInfo, 0, 2);
            uiTableLayoutPanel1.Controls.Add(headder, 0, 0);
            uiTableLayoutPanel1.Dock = DockStyle.Fill;
            uiTableLayoutPanel1.Location = new Point(0, 0);
            uiTableLayoutPanel1.Margin = new Padding(0);
            uiTableLayoutPanel1.Name = "uiTableLayoutPanel1";
            uiTableLayoutPanel1.RowCount = 4;
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 60F));
            uiTableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 200F));
            uiTableLayoutPanel1.Size = new Size(384, 633);
            uiTableLayoutPanel1.TabIndex = 0;
            uiTableLayoutPanel1.TagString = null;
            // 
            // OrderInfo
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(235, 243, 255);
            OrderInfo.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            OrderInfo.BackgroundColor = Color.FromArgb(241, 228, 216);
            OrderInfo.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            OrderInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            OrderInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = SystemColors.Window;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle3.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            OrderInfo.DefaultCellStyle = dataGridViewCellStyle3;
            OrderInfo.Dock = DockStyle.Fill;
            OrderInfo.EnableHeadersVisualStyles = false;
            OrderInfo.Font = new Font("Microsoft Sans Serif", 12F);
            OrderInfo.GridColor = Color.FromArgb(80, 160, 255);
            OrderInfo.Location = new Point(0, 75);
            OrderInfo.Margin = new Padding(0);
            OrderInfo.Name = "OrderInfo";
            OrderInfo.RectColor = Color.Empty;
            OrderInfo.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = Color.FromArgb(235, 243, 255);
            dataGridViewCellStyle4.Font = new Font("Microsoft Sans Serif", 12F);
            dataGridViewCellStyle4.ForeColor = Color.FromArgb(48, 48, 48);
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(80, 160, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.White;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.True;
            OrderInfo.RowHeadersDefaultCellStyle = dataGridViewCellStyle4;
            OrderInfo.RowHeadersWidth = 62;
            dataGridViewCellStyle5.BackColor = Color.White;
            dataGridViewCellStyle5.Font = new Font("Microsoft Sans Serif", 12F);
            OrderInfo.RowsDefaultCellStyle = dataGridViewCellStyle5;
            OrderInfo.SelectedIndex = -1;
            OrderInfo.Size = new Size(384, 298);
            OrderInfo.StripeOddColor = Color.FromArgb(235, 243, 255);
            OrderInfo.TabIndex = 2;
            // 
            // featureBtn
            // 
            featureBtn.Dock = DockStyle.Fill;
            featureBtn.FillColor = Color.FromArgb(241, 228, 216);
            featureBtn.Font = new Font("Microsoft Sans Serif", 12F);
            featureBtn.Location = new Point(0, 433);
            featureBtn.Margin = new Padding(0);
            featureBtn.MinimumSize = new Size(1, 1);
            featureBtn.Name = "featureBtn";
            featureBtn.Padding = new Padding(2);
            featureBtn.RectColor = Color.Empty;
            featureBtn.ShowText = false;
            featureBtn.Size = new Size(384, 200);
            featureBtn.TabIndex = 3;
            featureBtn.Text = "uiFlowLayoutPanel1";
            featureBtn.TextAlignment = ContentAlignment.MiddleCenter;
            // 
            // TienInfo
            // 
            TienInfo.BackColor = Color.FromArgb(223, 194, 168);
            TienInfo.ColumnCount = 2;
            TienInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TienInfo.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            TienInfo.Controls.Add(lblTongtien, 0, 0);
            TienInfo.Controls.Add(lbltien, 1, 0);
            TienInfo.Dock = DockStyle.Fill;
            TienInfo.Location = new Point(0, 373);
            TienInfo.Margin = new Padding(0);
            TienInfo.Name = "TienInfo";
            TienInfo.RowCount = 1;
            TienInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TienInfo.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            TienInfo.Size = new Size(384, 60);
            TienInfo.TabIndex = 4;
            TienInfo.TagString = null;
            // 
            // lblTongtien
            // 
            lblTongtien.BackColor = Color.Transparent;
            lblTongtien.Dock = DockStyle.Fill;
            lblTongtien.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongtien.ForeColor = Color.FromArgb(152, 98, 61);
            lblTongtien.Location = new Point(3, 0);
            lblTongtien.Name = "lblTongtien";
            lblTongtien.Size = new Size(186, 60);
            lblTongtien.TabIndex = 0;
            lblTongtien.Text = "Tổng Tiền";
            lblTongtien.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lbltien
            // 
            lbltien.BackColor = Color.Transparent;
            lbltien.Dock = DockStyle.Fill;
            lbltien.FillColor = Color.Transparent;
            lbltien.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltien.ForeColor = Color.FromArgb(152, 98, 61);
            lbltien.Location = new Point(192, 0);
            lbltien.Margin = new Padding(0);
            lbltien.MinimumSize = new Size(1, 1);
            lbltien.Name = "lbltien";
            lbltien.RectColor = Color.Empty;
            lbltien.Size = new Size(192, 60);
            lbltien.TabIndex = 1;
            lbltien.Text = "000000 đ";
            lbltien.TextAlignment = ContentAlignment.MiddleRight;
            // 
            // headder
            // 
            headder.BackColor = Color.FromArgb(223, 194, 168);
            headder.ColumnCount = 2;
            headder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68.4895859F));
            headder.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 31.510416F));
            headder.Controls.Add(info, 0, 1);
            headder.Controls.Add(TenBan, 0, 0);
            headder.Controls.Add(status, 1, 1);
            headder.Controls.Add(hidebtn, 1, 0);
            headder.Dock = DockStyle.Fill;
            headder.Location = new Point(0, 0);
            headder.Margin = new Padding(0);
            headder.Name = "headder";
            headder.RowCount = 1;
            headder.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            headder.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            headder.Size = new Size(384, 75);
            headder.TabIndex = 5;
            headder.TagString = null;
            // 
            // info
            // 
            info.Dock = DockStyle.Fill;
            info.FillColor = Color.Empty;
            info.Font = new Font("Segoe UI Semibold", 8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            info.ForeColor = Color.FromArgb(109, 71, 46);
            info.Location = new Point(4, 42);
            info.Margin = new Padding(4, 5, 4, 5);
            info.MinimumSize = new Size(1, 1);
            info.Name = "info";
            info.RectColor = Color.Empty;
            info.Size = new Size(255, 28);
            info.TabIndex = 5;
            info.Text = "Sức chứa: 4 người · Bắt Đầu: 10:15";
            info.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // TenBan
            // 
            TenBan.Dock = DockStyle.Fill;
            TenBan.FillColor = Color.Empty;
            TenBan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TenBan.ForeColor = Color.FromArgb(109, 71, 46);
            TenBan.Location = new Point(4, 5);
            TenBan.Margin = new Padding(4, 5, 4, 5);
            TenBan.MinimumSize = new Size(1, 1);
            TenBan.Name = "TenBan";
            TenBan.RectColor = Color.Empty;
            TenBan.Size = new Size(255, 27);
            TenBan.TabIndex = 3;
            TenBan.Text = "Tên bàn";
            TenBan.TextAlignment = ContentAlignment.MiddleLeft;
            // 
            // status
            // 
            status.Dock = DockStyle.Fill;
            status.Enabled = false;
            status.FillColor = Color.Empty;
            status.FillColor2 = Color.Empty;
            status.FillDisableColor = Color.Empty;
            status.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            status.Location = new Point(266, 40);
            status.MinimumSize = new Size(1, 1);
            status.Name = "status";
            status.Radius = 31;
            status.RectColor = Color.Empty;
            status.RectDisableColor = Color.Empty;
            status.RectSides = ToolStripStatusLabelBorderSides.None;
            status.Size = new Size(115, 32);
            status.TabIndex = 1;
            status.Text = "status";
            status.TipsFont = new Font("Microsoft Sans Serif", 9F);
            // 
            // hidebtn
            // 
            hidebtn.Anchor = AnchorStyles.Right;
            hidebtn.FillColor = Color.FromArgb(192, 0, 0);
            hidebtn.FillHoverColor = Color.FromArgb(201, 67, 63);
            hidebtn.FillPressColor = Color.FromArgb(172, 50, 48);
            hidebtn.Font = new Font("Microsoft Sans Serif", 12F);
            hidebtn.Location = new Point(343, 3);
            hidebtn.MinimumSize = new Size(1, 1);
            hidebtn.Name = "hidebtn";
            hidebtn.RectColor = Color.Empty;
            hidebtn.RectSides = ToolStripStatusLabelBorderSides.None;
            hidebtn.Size = new Size(38, 31);
            hidebtn.Symbol = 61453;
            hidebtn.TabIndex = 2;
            hidebtn.TipsFont = new Font("Microsoft Sans Serif", 9F);
            hidebtn.Click += hidebtn_Click;
            // 
            // UC_SoDoBan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 245, 247);
            Controls.Add(Sodoban);
            Margin = new Padding(0);
            Name = "UC_SoDoBan";
            Size = new Size(1120, 633);
            Sodoban.Panel1.ResumeLayout(false);
            Sodoban.Panel2.ResumeLayout(false);
            (Sodoban).EndInit();
            Sodoban.ResumeLayout(false);
            uiTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)OrderInfo).EndInit();
            TienInfo.ResumeLayout(false);
            headder.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Sunny.UI.UISplitContainer Sodoban;
        private Sunny.UI.UIFlowLayoutPanel fplSoDoBan;
        private Sunny.UI.UITableLayoutPanel uiTableLayoutPanel1;
        private Sunny.UI.UIDataGridView OrderInfo;
        private Sunny.UI.UIFlowLayoutPanel featureBtn;
        private Sunny.UI.UITableLayoutPanel TienInfo;
        private Sunny.UI.UILabel lblTongtien;
        private Sunny.UI.UIPanel lbltien;
        private Sunny.UI.UITableLayoutPanel headder;
        private Sunny.UI.UIButton status;
        private Sunny.UI.UIPanel info;
        private Sunny.UI.UIPanel TenBan;
        private Sunny.UI.UISymbolButton hidebtn;
    }
}
