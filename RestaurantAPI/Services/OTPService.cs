using Microsoft.Extensions.Caching.Memory;
using System.Security.Cryptography;

namespace RestaurantAPI.Services
{
    public class OTPService(IMemoryCache cache)
    {
        public string GenerateOTP()
        {
            return RandomNumberGenerator.GetInt32(100000, 1000000).ToString();
        }

        public void SaveOTP(string email, string otpCode)
        {
            // Chuẩn hóa key (ví dụ: chuyển email/username về chữ thường để tránh nhầm lẫn)
            string cacheKey = $"OTP_{email.Trim().ToLower()}";
            var cacheOptions = new MemoryCacheEntryOptions()
                // Đặt thời gian hết hạn tuyệt đối: Đúng 2 phút là tự động biến mất khỏi RAM
                .SetAbsoluteExpiration(TimeSpan.FromMinutes(2))
                // Đặt độ ưu tiên cao để không bị hệ điều hành tự ý dọn trước hạn
                .SetPriority(CacheItemPriority.High);
            cache.Set(cacheKey, otpCode, cacheOptions);
        }
        public bool VerifyOTP(string key, string inputOtp)
        {
            string cacheKey = $"OTP_{key.Trim().ToLower()}";
            // Thử lấy mã OTP từ RAM ra
            if (cache.TryGetValue(cacheKey, out string? correctOtp))
            {
                // So sánh mã trong RAM với mã người dùng nhập
                if (string.Equals(correctOtp, inputOtp?.Trim()))
                {
                    // ⚠️ BẢO MẬT: Sau khi nhập đúng, XÓA NGAY LẬP TỨC khỏi RAM
                    // Đảm bảo mã chỉ dùng được ĐÚNG 1 LẦN DUY NHẤT (One-Time Password)
                    cache.Remove(cacheKey);
                    return true;
                }
            }
            // Trả về false nếu: Sai mã HOẶC mã đã quá 2 phút nên tự hủy khỏi RAM
            return false;
        }
        public bool IsOtpSent(string key)
        {
            string cacheKey = $"OTP_{key.Trim().ToLower()}";
            return cache.TryGetValue(cacheKey, out _);
        }
    }
}
