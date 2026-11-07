using RestaurantManagement.UI.Network;
using RestaurantShared.DTO;
using RestaurantShared.DTO.Request.Authentication;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Text.Json;
using System.Windows.Forms;

namespace RestaurantManagement.UI
{
    public partial class changePassword : Form
    {
        public changePassword()
        {
            InitializeComponent();
        }

        private async void Dangnhap_Click(object sender, EventArgs e)
        {
            string password = pwtxt.Text.Trim();
            string REpassword = REpwtxt.Text.Trim();

            if (this.Tag is not  string username )
            {
                this.Close();
                return;
            }
            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
            if(string.IsNullOrEmpty(REpassword))
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu");
                return;
            }
            if(password!=REpassword)
            {
                MessageBox.Show("Mật khẩu và mật khẩu nhập lại không giống nhau!");
                return;
            }
            Dangnhap.Enabled = false;
            try
            {
                if (!TcpCustomer.Instance.ConnectServer())
                {
                    MessageBox.Show("Không thể kết nối đến Máy chủ! Vui lòng kiểm tra lại mạng");
                    Dangnhap.Enabled = true;
                    return;
                }
                var packet = new NetworkPacket
                {
                    Action = NetworkAction.CHANGE_PASSWORD,
                    Payload = JsonSerializer.Serialize(new ChangePasswordRequest(username, password))
                };
                // 3. Chờ phản hồi từ Server
                NetworkPacket? response = await TcpCustomer.Instance.SendRequestAndWaitResponseAsync(packet);
                if (response == null)
                {
                    TcpCustomer.Instance.DisConnectServer();
                    MessageBox.Show("Xác thực OTP thất bại!", "Thông báo");
                    this.Close();
                    return;
                }
                if (response.IsSuccess == false)
                {
                    TcpCustomer.Instance.DisConnectServer();
                    MessageBox.Show(response.Message, "Thông báo");
                    this.Close();
                    return;
                }
                MessageBox.Show(response.Message, "Thông báo");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
            finally
            {
                Dangnhap.Enabled = true;

            }
        }
    }
}
