using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.DAO; 
using RestaurantAPI.Models.Configuration;
using RestaurantShared.Models.SQLData;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantAPI.Services
{
    
    public class AuthService(
        IOptions<JwtConfig> config,
        IUnitOfWork uow, 
        OTPService otpService,
        MailService mailService)
    {
        // 1. NGHIỆP VỤ ĐĂNG NHẬP
        public async Task<(bool IsSuccess, string? Token, StaffDATA? Staff, string Message)> LoginAsync(string username, string password)
        {
            var (isSuccess, maNV, message) = await uow.Accounts.ValidateLoginAsync(username, password);
            if (!isSuccess)
                return (false, null, null, message);

            var staff = await uow.Staffs.GetByIdAsync(maNV);
            if (staff == null)
                return (false, null, null, "Không tìm thấy thông tin nhân viên!");

            string token = GenerateToken(staff, username);
            return (true, token, staff, "Đăng nhập thành công!");
        }

        // 2. NGHIỆP VỤ GỬI OTP QUÊN MẬT KHẨU
        public async Task<(bool IsSuccess, string Message)> SendForgotPasswordOtpAsync(string username)
        {
            string? email = await uow.Accounts.GetEmailByUsernameAsync(username);
            if (string.IsNullOrEmpty(email))
                return (false, "Tài khoản không tồn tại hoặc chưa cập nhật email!");

            if (otpService.IsOtpSent(username))
                return (false, "Mã OTP vừa được gửi. Vui lòng chờ 2 phút!");

            string otp = otpService.GenerateOTP();
            otpService.SaveOTP(username, otp);

            string htmlBody = $@"
                <div style='font-family: Arial, sans-serif; padding: 20px;'>
                    <h2 style='color: #d9534f;'>THE GOURMET RESTAURANT</h2>
                    <p>Mã OTP xác thực tài khoản của bạn là:</p>
                    <h1 style='color: #0275d8; letter-spacing: 5px;'>{otp}</h1>
                    <p>Mã này có hiệu lực trong vòng <b>2 phút</b>.</p>
                </div>";

            bool isSent = await mailService.SendEmailAsync(email, "Mã OTP Xác Thực - The Gourmet Restaurant", htmlBody);
            if (!isSent)
                return (false, "Không thể gửi email OTP, vui lòng thử lại sau!");

            return (true, "Mã OTP đã được gửi về email của bạn.");
        }

        // 3. NGHIỆP VỤ XÁC THỰC OTP
        public (bool IsSuccess, string Message) VerifyOtp(string username, string otp)
        {
            bool isValid = otpService.VerifyOTP(username, otp);
            if (!isValid)
                return (false, "Mã OTP không chính xác hoặc đã hết hạn!");

            return (true, "Xác thực OTP thành công!");
        }

        // 4. NGHIỆP VỤ ĐỔI MẬT KHẨU
    

        // 5. HÀM SINH TOKEN (Dùng nội bộ)
        public string GenerateToken(StaffDATA staff, string username)
        {
            var jwt = config.Value;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.SecretKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(ClaimTypes.NameIdentifier, staff.MaNV),
                new Claim(ClaimTypes.Name, username),
                new Claim("FullName", staff.HoTen),
                new Claim(ClaimTypes.Role, staff.VaiTro)
            };

            var token = new JwtSecurityToken(
                issuer: jwt.Issuer,
                audience: jwt.Audience,
                claims: claims,
                expires: DateTime.UtcNow.AddHours(jwt.ExpiryHours),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

    }
}