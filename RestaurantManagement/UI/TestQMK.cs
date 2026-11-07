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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace RestaurantManagement.UI
{
    public partial class TestQMK : Form
    {
        public TestQMK()
        {
            InitializeComponent();
        }

        private async void SendOTP_Click(object sender, EventArgs e)
        {
            string usrname = Usernametxt.Text.Trim();
            if (string.IsNullOrEmpty(usrname) )
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập");
                return;
            }
            SendOTP.Enabled = false;
          try
            {
                if (!TcpCustomer.Instance.ConnectServer())
                {
                    MessageBox.Show("Không thể kết nối đến Máy chủ! Vui lòng kiểm tra lại mạng");
                    SendOTP.Enabled = true;
                    return;
                }
                var packet = new NetworkPacket
                {
                    Action = NetworkAction.FORGET_PASSWORD,
                    Payload = JsonSerializer.Serialize(new ForgetPasswordRequest(usrname))
                };
                // 3. Chờ phản hồi từ Server
                NetworkPacket? response = await TcpCustomer.Instance.SendRequestAndWaitResponseAsync(packet);
                if(response == null)
                {
                     TcpCustomer.Instance.DisConnectServer();
                      MessageBox.Show("Gửi yêu cầu thất bại!", "Thông báo");
                        return;
                }
                if(response.IsSuccess == false)
                {
                    TcpCustomer.Instance.DisConnectServer();
                    MessageBox.Show(response.Message, "Thông báo");
                    return;
                }
                MessageBox.Show(response.Message, "Thông báo");
                this.Hide();
                OTP otp = new();
                otp.Tag = usrname;
                otp.ShowDialog();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
            finally
            {
                SendOTP.Enabled = true;

            }

        }
    }
}
