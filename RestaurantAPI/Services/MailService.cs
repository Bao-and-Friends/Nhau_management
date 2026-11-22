using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using RestaurantAPI.Models.Configuration;

namespace RestaurantAPI.Services
{
    public class MailService(IOptions<EmailConfig> config)
    {
        public async Task<bool> SendEmailAsync(string toEmail, string subject, string htmlBody)
        {
            try
            {
                var emailSettings = config.Value;

                // 1. Tạo nội dung thư bằng MimeKit
                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("The Gourmet Restaurant", emailSettings.SenderEmail));
                message.To.Add(new MailboxAddress("", toEmail));
                message.Subject = subject;

                var bodyBuilder = new BodyBuilder
                {
                    HtmlBody = htmlBody
                };
                message.Body = bodyBuilder.ToMessageBody();

                // 2. Gửi thư bằng MailKit SmtpClient (Chuẩn async và mã hóa TLS)
                using var client = new SmtpClient();

                // Kết nối máy chủ Gmail cổng 587
                await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);

                // Xác thực tài khoản Gmail bằng App Password
                await client.AuthenticateAsync(emailSettings.SenderEmail, emailSettings.AppPassword);

                // Gửi thư
                await client.SendAsync(message);

                // Ngắt kết nối an toàn
                await client.DisconnectAsync(true);

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Lỗi gửi mail MailKit]: {ex.Message}");
                return false;
            }
        }
    }
}
