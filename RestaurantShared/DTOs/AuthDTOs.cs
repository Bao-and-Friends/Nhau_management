using RestaurantShared.Models.SQLData;

namespace RestaurantShared.DTOs
{
    // Yêu cầu đăng nhập
    public record LoginRequest(string Username, string Password);

    // Kết quả trả về khi đăng nhập
    public record LoginResponse(bool IsSuccess, string? Token, StaffDATA? Staff, string? Message);

    // Yêu cầu quên mật khẩu (gửi OTP)
    public record ForgotPasswordRequest(string Username);

    // Yêu cầu xác thực OTP
    public record VerifyOtpRequest(string Username, string Otp);

    // Yêu cầu đổi mật khẩu
    public record ChangePasswordRequest(string Username, string NewPassword);

    // Kết quả phản hồi chung (Common API Response)
    public record ApiResponse(bool IsSuccess, string? Message);
}
