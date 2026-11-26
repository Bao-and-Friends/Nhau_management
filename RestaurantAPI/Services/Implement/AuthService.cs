using ErrorOr;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using RestaurantAPI.DAO.Interface;
using RestaurantAPI.Models.Configuration;
using RestaurantAPI.Services.Interface;
using RestaurantShared.DTOs;
using RestaurantShared.Models.SQLData;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace RestaurantAPI.Services.Implement
{
    
    public class AuthService(
        IOptions<JwtConfig> config,
       IAccountRepository AccRepo, 
       IStaffRepository StaffRepo,
        OTPService otpService,
        MailService mailService) : IAuthService
    {
        // 1. NGHIỆP VỤ ĐĂNG NHẬP
        public async Task<ErrorOr<LoginResponse>> LoginAsync(string username, string password)
        {
            // 1.1 Kiểm tra tài khoản trong database
            var account = await AccRepo.GetByUsernameAsync(username);
            if (account == null)
                return Error.NotFound("Account.NotFound", "Tài khoản không tồn tại!");

            // 1.2 Kiểm tra trạng thái tài khoản
            string trangThai = account.TrangThai?.Trim() ?? string.Empty;
            if (trangThai.Equals("Khóa", StringComparison.OrdinalIgnoreCase) || trangThai == "0")
                return Error.Unauthorized("Account.Locked", "Tài khoản đã bị khóa!");

            // 1.3 Kiểm tra mật khẩu (Bắt buộc mã hóa BCrypt)
            string hashPwd = account.MatKhau?.Trim() ?? string.Empty;
            bool isPasswordValid = false;
            if (hashPwd.StartsWith("$2a$") || hashPwd.StartsWith("$2b$") || hashPwd.StartsWith("$2y$"))
            {
                try
                {
                    isPasswordValid = BCrypt.Net.BCrypt.Verify(password, hashPwd);
                }
                catch
                {
                    isPasswordValid = false;
                }
            }

            if (!isPasswordValid)
                return Error.Unauthorized("Account.InvalidPassword", "Mật khẩu không chính xác!");

            // 1.4 Lấy thông tin nhân viên
            var staff = await StaffRepo.GetByIdAsync(account.NhanVienID);
            if (staff == null)
                return Error.NotFound("Staff.NotFound", "Tài  khoản chưa được gán cho bất kỳ nhân viên nào!");

            // 1.5 Sinh JWT Token
            string token = GenerateToken(staff, username);
            return new LoginResponse(true, token, staff, "Đăng nhập thành công!");
        }

        // 2. NGHIỆP VỤ GỬI OTP QUÊN MẬT KHẨU
        public async Task<ErrorOr<Success>> SendForgotPasswordOtpAsync(string username)
        {
            string? email = await AccRepo.GetEmailByUsernameAsync(username);
            if (string.IsNullOrEmpty(email))
                return Error.NotFound("Account.NoEmail", "Tài khoản không tồn tại hoặc chưa cập nhật email!");

            if (otpService.IsOtpSent(username))
                return Error.Conflict("Otp.Cooldown", "Mã OTP vừa được gửi. Vui lòng chờ 2 phút!");

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
                return Error.Failure("Email.SendFailed", "Không thể gửi email OTP, vui lòng thử lại sau!");

            return Result.Success;
        }

        // 3. NGHIỆP VỤ XÁC THỰC OTP
        public ErrorOr<Success> VerifyOtp(string username, string otp)
        {
            bool isValid = otpService.VerifyOTP(username, otp);
            if (!isValid)
                return Error.Validation("Otp.Invalid", "Mã OTP không chính xác hoặc đã hết hạn!");

            return Result.Success;
        }


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
                new Claim(ClaimTypes.Role, staff.VaiTro.Trim())
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