using Microsoft.AspNetCore.Mvc;
using RestaurantAPI.Data;
using RestaurantAPI.Services;

namespace RestaurantAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController(AccountDAO accountDao, StaffDAO staffDao, AuthService authService, OTPService otpService, MailService mailService) : ControllerBase
    {
        // 1. API ĐĂNG NHẬP
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto request)
        {
            var (isSuccess, maNV, message) = await accountDao.ValidateLoginAsync(request.Username, request.Password);
            if (!isSuccess)
                return Unauthorized(new { isSuccess = false, message });

            var staff = await staffDao.GetByIdAsync(maNV);
            if (staff == null)
                return NotFound(new { isSuccess = false, message = "Không tìm thấy thông tin nhân viên!" });

            // Sinh Token
            string token = authService.GenerateToken(staff, request.Username);
            return Ok(new
            {
                isSuccess = true,
                token = token,
                staff = staff
            });
        }

        // 2. API QUÊN MẬT KHẨU (Gửi OTP)
        [HttpPost("forgot-password")]
        public async Task<IActionResult> ForgotPassword([FromBody] ForgotPasswordDto request)
        {
            string? email = await accountDao.GetEmailByUsernameAsync(request.Username);
            if (string.IsNullOrEmpty(email))
                return BadRequest(new { isSuccess = false, message = "Tài khoản không tồn tại hoặc chưa có email!" });

            if (otpService.IsOtpSent(request.Username))
                return BadRequest(new { isSuccess = false, message = "Mã OTP vừa được gửi. Vui lòng chờ 2 phút!" });

            string otp = otpService.GenerateOTP();
            otpService.SaveOTP(request.Username, otp);

            // Gửi email bằng MailKit
            string htmlBody = $@"
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

            bool isSent = await mailService.SendEmailAsync(email, "Mã OTP Xác Thực - The Gourmet Restaurant", htmlBody);
            if (!isSent)
                return StatusCode(500, new { isSuccess = false, message = "Không thể gửi email OTP, vui lòng thử lại sau!" });

            return Ok(new { isSuccess = true, message = "Mã OTP đã được gửi về email của bạn." });
        }

        // 3. API XÁC THỰC OTP
        [HttpPost("verify-otp")]
        public IActionResult VerifyOtp([FromBody] VerifyOtpDto request)
        {
            bool isValid = otpService.VerifyOTP(request.Username, request.Otp);
            if (!isValid)
                return BadRequest(new { isSuccess = false, message = "Mã OTP không chính xác hoặc đã hết hạn!" });

            return Ok(new { isSuccess = true, message = "Xác thực OTP thành công!" });
        }

        // 4. API ĐỔI MẬT KHẨU
        [HttpPost("change-password")]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto request)
        {
            bool isUpdated = await accountDao.ChangePasswordAsync(request.Username, request.NewPassword);
            if (!isUpdated)
                return BadRequest(new { isSuccess = false, message = "Đổi mật khẩu thất bại!" });

            return Ok(new { isSuccess = true, message = "Đổi mật khẩu thành công!" });
        }
    }

    // Các DTO nhận dữ liệu từ Client gửi lên:
    public record LoginDto(string Username, string Password);
    public record ForgotPasswordDto(string Username);
    public record VerifyOtpDto(string Username, string Otp);
    public record ChangePasswordDto(string Username, string NewPassword);
}
