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
    public partial class OTP : Form
    {
        public OTP()
        {
            InitializeComponent();
        }

        private async void OTPVerify_Click(object sender, EventArgs e)
        {
            string Otp = Otptxt.Text.Trim();
            if (this.Tag is not string username)
            {
                this.Close();
                return;
            }
            if (string.IsNullOrEmpty(Otp))
            {
                MessageBox.Show("Vui lòng nhập mã OTP");
                return;
            }
            OTPVerify.Enabled = false;
            try
            {
                if (!TcpCustomer.Instance.ConnectServer())
                {
                    MessageBox.Show("Không thể kết nối đến Máy chủ! Vui lòng kiểm tra lại mạng");
                    OTPVerify.Enabled = true;
                    return;
                }
                var packet = new NetworkPacket
                {
                    Action = NetworkAction.OTP_VERIFY,
                    Payload = JsonSerializer.Serialize(new OtpVerifyRequest(username, Otp))
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
                    MessageBox.Show(response.Message, "Thông báo");
                    return;
                }
                MessageBox.Show(response.Message, "Thông báo");
                this.Hide();
                changePassword changer = new();
                changer.Tag = username;
                changer.ShowDialog();
                this.Close();

            }
            catch
            {

            }
            finally
            {
                OTPVerify.Enabled = true;

            }
        }

        private async void ResendOTPbtn_Click(object sender, EventArgs e)
        {
            if (this.Tag is not string username)
            {
                this.Close();
                return;
            }
            ResendOTPbtn.Enabled = false;
            try
            {
              
                if (!TcpCustomer.Instance.ConnectServer())
                {
                    MessageBox.Show("Không thể kết nối đến Máy chủ! Vui lòng kiểm tra lại mạng");
                    ResendOTPbtn.Enabled = true;
                    return;
                }
                var packet = new NetworkPacket
                {
                    Action = NetworkAction.OTP_RESEND,
                    Payload = JsonSerializer.Serialize(new ResendOtpRequest(username))
                };
                // 3. Chờ phản hồi từ Server
                NetworkPacket? response = await TcpCustomer.Instance.SendRequestAndWaitResponseAsync(packet);
                if (response == null)
                {
                    MessageBox.Show("Gửi yêu cầu thất bại!", "Thông báo");
                    return;
                }
                if (response.IsSuccess == false)
                {
                    MessageBox.Show(response.Message, "Thông báo");
                    return;
                }
                MessageBox.Show(response.Message, "Thông báo");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi");
            }
            finally
            {
                ResendOTPbtn.Enabled = true;

            }
        }
    }
}
