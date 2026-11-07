using Microsoft.IdentityModel.Tokens;
using RestaurantSever.DAO;
using RestaurantSever.Services;
using RestaurantShared.DTO;
using RestaurantShared.Network;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Net;
using System.Net.Mail;
using System.Net.Sockets;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestaurantSever.Network
{
    public class TcpServer: TCPManager
    {
        private static readonly Lazy<TcpServer> sv = new(() => new TcpServer());
        public static TcpServer Instance => sv.Value;
        private TcpServer() { }
        private TcpListener? server;

        public void StartServer()
        {
            server = new(iep);
            server.Start();
            Console.WriteLine($"[SERVER] Đang chạy tại cổng {iep.Port}...");
            // Vòng lặp chấp nhận kết nối đa luồng
            Task.Run(AcceptLoop);
        }
        private async Task AcceptLoop()
        {
            while (server != null)
            {
                try
                {
                    TcpClient clientSocket = await server.AcceptTcpClientAsync().ConfigureAwait(false);
                    Console.WriteLine($"[+] Client kết nối: {clientSocket.Client.RemoteEndPoint}");

                    // Mỗi client được xử lý trên 1 Task riêng biệt
                   await HandleClientAsync(clientSocket);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Accept Error]: {ex.Message}");
                    break;
                }
            }
        }
        // Vòng lặp nhận và xử lý gói tin của 1 Client cụ thể
        private async Task HandleClientAsync(TcpClient clientSocket)
        {
            // Bọc cả clientSocket và stream trong using
            using (clientSocket)
            await using (NetworkStream stream = clientSocket.GetStream())
            {
                string clientEndPoint = clientSocket.Client.RemoteEndPoint?.ToString() ?? "Unknown";

                try
                {
                    while (clientSocket.Connected)
                    {
                        // 1. Nhận gói tin
                        NetworkPacket? request = await ReceiveAsync<NetworkPacket>(stream);
                        if (request == null) break; // Client ngắt kết nối chủ động

                        Console.WriteLine($"[Nhận lệnh]: {request.Action} từ {clientEndPoint}");

                        // 2. Xử lý nghiệp vụ
                        NetworkPacket response = ProcessRequest(request);

                        // 3. Gửi phản hồi
                        await SendAsync(stream, response);
                    }
                }
                catch (IOException)
                {
                    // Xảy ra khi Client bị ngắt kết nối đột ngột giữa chừng
                    Console.WriteLine($"[!] Kết nối từ {clientEndPoint} bị ngắt đột ngột.");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"[Lỗi xử lý Client {clientEndPoint}]: {ex.Message}");
                }
                finally
                {
                    Console.WriteLine($"[-] {clientEndPoint} đã ngắt kết nối.");
                }
            }
        }
        // Bóc tách hành động nghiệp vụ
        private NetworkPacket ProcessRequest(NetworkPacket req)
        {
            switch (req.Action)
            {
                case NetworkAction.LOGIN:
                    return Process_LOGIN(req);

                case NetworkAction.GET_TABLE_LIST:
                    return Process_GET_TABLE_LIST(req);

                case NetworkAction.REGISTER:
                    return Process_REGISTER(req);

                case NetworkAction.FORGET_PASSWORD:
                    return Process_FORGET_PASSWORD(req);

                case NetworkAction.OTP_VERIFY:
                    return Process_OTP_VERIFY(req);

                case NetworkAction.OTP_RESEND:
                    return Process_RESEND_OTP(req);

                case NetworkAction.CHANGE_PASSWORD:
                    return Process_CHANGE_PASSWORD(req);

                default:
                    return new NetworkPacket { Action = NetworkAction.UNKNOW, IsSuccess = false, Message = "Lệnh không hợp lệ" };
            }
        }

        private NetworkPacket Process_LOGIN(NetworkPacket req)
        {
            var loginData = JsonSerializer.Deserialize<LoginRequest>(req.Payload);
            string maNV = AccountDAO.Instance.Login(loginData?.Username ?? "", loginData?.Password ?? "");

            if (!string.IsNullOrEmpty(maNV))
            {
                NhanVienDATA? nv = NhanVienDAO.Instance.GetNhanVienbyID(maNV);
                return new NetworkPacket
                {
                    Action = NetworkAction.LOGIN_RESPONSE,
                    IsSuccess = true,
                    Message = "Đăng nhập thành công!",
                    Payload = JsonSerializer.Serialize(nv)
                };
            }
            return new NetworkPacket { Action = NetworkAction.LOGIN_RESPONSE, IsSuccess = false, Message = "Sai tài khoản hoặc mật khẩu!" };
        }
        private NetworkPacket Process_GET_TABLE_LIST(NetworkPacket req)
        {
            var tables = TableDAO.Instance.GetListTable();
            return new NetworkPacket
            {
                Action = NetworkAction.GET_TABLE_LIST_RESPONSE,
                IsSuccess = true,
                Payload = JsonSerializer.Serialize(tables)
            };
        }
        private NetworkPacket Process_REGISTER(NetworkPacket req)
        {
            var registerData = JsonSerializer.Deserialize<RegisterRequest>(req.Payload);
            if (registerData != null)
            {
                var result = AccountDAO.Instance.RegisterAccount(registerData);
                return new NetworkPacket
                {
                    Action = NetworkAction.REGISTER_RESPONSE,
                    IsSuccess = result.IsSuccess,
                    Message = result.Message
                };
            }
            return new NetworkPacket
            {
                Action = NetworkAction.REGISTER_RESPONSE,
                IsSuccess = false,
                Message = "không nhận được phản hồi từ máy chủ!"
            };
        }
        private NetworkPacket Process_FORGET_PASSWORD(NetworkPacket req)//dùng để gửi OTP
        {
            var ForgetPasswordData = JsonSerializer.Deserialize<ForgetPasswordRequest>(req.Payload);
            if (ForgetPasswordData != null)
            {
                var emailNV = AccountDAO.Instance.GetEmailByUsername(ForgetPasswordData.Username);
                if(string.IsNullOrEmpty(emailNV))
                {
                    return new NetworkPacket
                    {
                        Action = NetworkAction.FORGET_PASSWORD_RESPONSE,
                        IsSuccess = false,
                        Message = $" Tên tài khoản {ForgetPasswordData.Username} không tồn tại hoặc chưa được cập nhật email"
                    };
                }
                string otpCode = OTPService.Instance.CreateOTP();
                var result = CreateAndFormatOtpMail(otpCode);//tao subject va body cho mail
                using MailMessage? mail = MailService.Instance.CreateMail(emailNV, result.subject, result.body);
                if (mail == null)
                {
                    return new NetworkPacket
                    {
                        Action = NetworkAction.FORGET_PASSWORD_RESPONSE,
                        IsSuccess = false,
                        Message = "Không thể tạo email khôi phục!"
                    };
                }
                if (MailService.Instance.Send(mail) == false)
                {
                    return new NetworkPacket
                    {
                        Action = NetworkAction.FORGET_PASSWORD_RESPONSE,
                        IsSuccess = false,
                        Message = "Gửi OTP không thành công!"
                    };
                }
                else
                {
                    OTPService.Instance.SaveOTP(ForgetPasswordData.Username, otpCode);
                }
                return new NetworkPacket
                {
                    Action = NetworkAction.FORGET_PASSWORD_RESPONSE,
                    IsSuccess = true,
                    Message = "Mã OTP đã đươc gửi tới mail của bạn!"
                };
            }
            return new NetworkPacket
            {
                Action = NetworkAction.FORGET_PASSWORD_RESPONSE,
                IsSuccess = false,
                Message = "không nhận được phản hồi từ máy chủ!"
            };


        }
        private NetworkPacket Process_RESEND_OTP(NetworkPacket req)
        {
            var respone = JsonSerializer.Deserialize<ResendOtpRequest>(req.Payload);
            if (respone != null)
            {
                if (OTPService.Instance.isOTPSended(respone.username))
                {
                    return new NetworkPacket
                    {
                        Action = NetworkAction.OTP_VERIFY_RESPONSE,
                        IsSuccess = true,
                        Message = "OTP đã được gửi vui lòng thử lại sau 2 phút nữa!"
                    };
                }
                string otpCode = OTPService.Instance.CreateOTP();
                var result = CreateAndFormatOtpMail(otpCode);//tao subject va body cho mail
                var emailNV = AccountDAO.Instance.GetEmailByUsername(respone.username);
                using MailMessage? mail = MailService.Instance.CreateMail(emailNV, result.subject, result.body);
                if (mail == null)
                {
                    return new NetworkPacket
                    {
                        Action = NetworkAction.OTP_RESEND_RESPONSE,
                        IsSuccess = false,
                        Message = "Không thể tạo email khôi phục!"
                    };
                }
                if (MailService.Instance.Send(mail) == false)
                {
                    return new NetworkPacket
                    {
                        Action = NetworkAction.OTP_RESEND_RESPONSE,
                        IsSuccess = false,
                        Message = "Gửi OTP không thành công!"
                    };
                }
                else
                {
                    OTPService.Instance.SaveOTP(respone.username, otpCode);
                }
                return new NetworkPacket
                {
                    Action = NetworkAction.OTP_RESEND_RESPONSE,
                    IsSuccess = true,
                    Message = "Mã OTP mới đã đươc gửi tới mail của bạn!"
                };
            }
            return new NetworkPacket
            {
                Action = NetworkAction.OTP_RESEND_RESPONSE,
                IsSuccess = false,
                Message = "không nhận được phản hồi từ máy chủ!"
            };

        }
        private NetworkPacket Process_OTP_VERIFY(NetworkPacket req)
        {
            var respone = JsonSerializer.Deserialize<OtpVerifyRequest>(req.Payload);
            if(respone != null)
            {
                if(OTPService.Instance.VerifyOTP(respone.Username,respone.Otp))
                {
                    return new NetworkPacket
                    {
                        Action = NetworkAction.OTP_VERIFY_RESPONSE,
                        IsSuccess = true,
                        Message = "OTP hợp lệ"
                    };
                }
                return new NetworkPacket
                {
                    Action = NetworkAction.OTP_VERIFY_RESPONSE,
                    IsSuccess = false,
                    Message = "Mã OTP sai hoặc đã hết hạn"
                };
            }
            return new NetworkPacket
            {
                Action = NetworkAction.OTP_VERIFY_RESPONSE,
                IsSuccess = false,
                Message = "không nhận được phản hồi từ máy chủ!"
            };

        }
        private NetworkPacket Process_CHANGE_PASSWORD(NetworkPacket req)
        {
            var response = JsonSerializer.Deserialize<ChangePasswordRequest>(req.Payload);
            if(response!=null)
            {
               if(AccountDAO.Instance.ChangePassword(response.Username, response.Password))
                {
                    return new NetworkPacket
                    {
                        Action = NetworkAction.CHANGE_PASSWORD_RESPONSE,
                        IsSuccess = true,
                        Message = "Đổi mật khẩu thành công!"
                    };
                }
                return new NetworkPacket
                {
                    Action = NetworkAction.CHANGE_PASSWORD_RESPONSE,
                    IsSuccess = false,
                    Message = "có lỗi xảy ra trong quá trình đổi mật khẩu!"
                };
            }
            return new NetworkPacket
            {
                Action = NetworkAction.CHANGE_PASSWORD_RESPONSE,
                IsSuccess = false,
                Message = "không nhận được phản hồi từ máy chủ!"
            };
        }

        private (string subject,string body) CreateAndFormatOtpMail(string otp)//tạo mail OTP và định dạng cho đẹp
        {
            string subject = "Mã xác nhận (OTP) khôi phục mật khẩu";
            string body = $@"
        <div style='font-family: ""Segoe UI"", Arial, sans-serif; max-width: 500px; margin: 0 auto; padding: 20px; border: 1px solid #eaeaea; border-radius: 10px; background-color: #ffffff;'>
            <div style='text-align: center; border-bottom: 2px solid #f0f0f0; padding-bottom: 15px; margin-bottom: 20px;'>
                <h2 style='color: #d9534f; margin: 0;'>Khôi Phục Mật Khẩu</h2>
            </div>
            
            <p style='color: #333333; font-size: 15px; line-height: 1.6;'>Xin chào,</p>
            <p style='color: #333333; font-size: 15px; line-height: 1.6;'>Hệ thống vừa nhận được yêu cầu cấp lại mật khẩu cho tài khoản liên kết với email này. Dưới đây là mã xác nhận (OTP) của bạn:</p>
            
            <div style='text-align: center; margin: 35px 0;'>
                <span style='display: inline-block; font-size: 36px; font-weight: bold; color: #ffffff; background-color: #28a745; padding: 15px 40px; border-radius: 8px; letter-spacing: 10px;'>
                    {otp}
                </span>
            </div>
            
            <p style='color: #555555; font-size: 14px; line-height: 1.5;'>Mã này có hiệu lực trong vòng <b>5 phút</b>. Vì lý do bảo mật, <b>TUYỆT ĐỐI KHÔNG</b> chia sẻ mã này cho bất kỳ ai, kể cả nhân viên của chúng tôi.</p>
            <p style='color: #555555; font-size: 14px; line-height: 1.5;'>Nếu bạn không yêu cầu đổi mật khẩu, vui lòng bỏ qua email này. Tài khoản của bạn vẫn an toàn.</p>
            
            <hr style='border: 0; border-top: 1px solid #eaeaea; margin: 30px 0 20px;' />
            
            <p style='font-size: 12px; color: #999999; text-align: center; margin: 0;'>
                &copy; {DateTime.Now.Year} Phần mềm QuanLyQuanNhau.<br/>
                Đồ án môn học - Không phản hồi lại email này.
            </p>
        </div>";
            return (subject, body);
        }
    }
}

