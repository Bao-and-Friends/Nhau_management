namespace RestaurantManagement.UI

{
    using RestaurantManagement.UI.Network;
    using RestaurantShared.DTO;
    using Sunny.UI;
    using System.Net.Sockets;
    using System.Resources;
    using System.Text.Json;

    public partial class LoginUI : UIForm
    {
        public LoginUI()
        {
            InitializeComponent();
        }


        private void uiTextBox2_button_click(object sender, EventArgs e)
        {
            if (pwtxt.PasswordChar == '●')
            {
                // Hiển thị mật khẩu
                pwtxt.PasswordChar = '\0';
                pwtxt.ButtonSymbol = 61550;
            }
            else
            {
                // Ẩn mật khẩu
                pwtxt.PasswordChar = '●';
                pwtxt.ButtonSymbol = 61552;
            }
        }

        private async void Dangnhap_Click(object sender, EventArgs e)
        {
            string usrname = username.Text.Trim();
            string passwrd = pwtxt.Text;
            if (string.IsNullOrEmpty(usrname) || string.IsNullOrEmpty(passwrd))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!");
                return;
            }
            // Khóa nút để chống spam click
            Dangnhap.Enabled = false;
            try
            {
                // 1. Kết nối tới Server nếu chưa kết nối
                if (!TcpCustomer.Instance.ConnectServer())
                {
                    MessageBox.Show("Không thể kết nối đến Máy chủ! Vui lòng kiểm tra lại mạng");
                    Dangnhap.Enabled = true;
                    return;
                }
                // 2. Đóng gói NetworkPacket gửi qua TCP
                var packet = new NetworkPacket
                {
                    Action = NetworkAction.LOGIN,
                    Payload = JsonSerializer.Serialize(new LoginRequest(usrname, passwrd))
                }; 
                // 3. Chờ phản hồi từ Server
                NetworkPacket? response = await TcpCustomer.Instance.SendRequestAndWaitResponseAsync(packet);
                if (response != null && response.IsSuccess)
                {
                    // Đọc dữ liệu nhân viên từ phản hồi của Server
                    NhanVienDATA? nv = JsonSerializer.Deserialize<NhanVienDATA>(response.Payload);
                    MainForm main = new()
                    {
                        Tag = nv // Truyền trực tiếp dữ liệu nhân viên vào MainForm
                    };
                    Dangnhap.Enabled = true;
                    this.Hide();
                    main.ShowDialog();
                    pwtxt.Text = "";
                    this.Show();
                }
                else
                {
                    TcpCustomer.Instance.DisConnectServer();
                    MessageBox.Show(response?.Message ?? "Đăng nhập thất bại hoặc máy chủ mất kết nối!");
                }
            }
            finally
            {
                Dangnhap.Enabled = true;
            }
        }
    }
}
