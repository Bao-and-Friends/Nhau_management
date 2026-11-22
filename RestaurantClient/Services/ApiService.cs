using ErrorOr;
using Microsoft.Extensions.Configuration;
using RestaurantShared.DTOs;
using RestaurantShared.Models.SQLData;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;

namespace RestaurantClient.Services
{
    public static class ApiService
    {
        private static readonly HttpClient client = new()
        {
            // Địa chỉ Server API (Chính là cổng HTTP bạn đang chạy)
            BaseAddress = new Uri("https://localhost:7216"),
            Timeout = TimeSpan.FromSeconds(10)
        };

        public static string? Token { get; private set; } 
        public static StaffDATA? Staff { get; private set; } 


        /// <summary>
        /// Gọi API Đăng nhập (POST api/auth/login)
        /// </summary>
        public static async Task<ErrorOr<Success>> LoginAsync(string username, string password)
        {
            try
            {
                var response = await client.PostAsJsonAsync("api/auth/login", new LoginRequest(username, password));
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                if (response.IsSuccessStatusCode && result != null)
                {
                    // Lấy Token và lưu vào biến tĩnh
                    Token = result.Token;
                    Staff = result.Staff;

                    // 👉 GẮN TOKEN VÀO HEADER ĐỂ CÁC REQUEST SAU TỰ CÓ QUYỀN
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    return Result.Success;
                }
                else
                {
                    string msg = string.IsNullOrWhiteSpace(result?.Message) ? "Đăng nhập thất bại!" : result.Message;
                    return Error.Unauthorized("Auth.Failed", msg);
                }
            }
            catch (Exception ex)
            {
                return Error.Failure("Network.Error", $"Lỗi kết nối máy chủ: {ex.Message}");
            }
        }

        public static void Logout()
        {
            Token = null;
            Staff = null;
            client.DefaultRequestHeaders.Authorization = null;
        }

        public static async Task<ErrorOr<List<TableDATA>>> GetTablesAsync()
        {
            try
            {
                var response = await client.GetAsync("api/table");
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<List<TableDATA>>();
                    return data ?? new List<TableDATA>();
                }

                return Error.Failure("Table.LoadFailed", $"Lỗi máy chủ: {(int)response.StatusCode} {response.ReasonPhrase}");
            }
            catch (Exception ex)
            {
                return Error.Failure("Network.Error", $"Lỗi kết nối máy chủ: {ex.Message}");
            }
        }

        public static async Task<ErrorOr<Success>> ForgotPasswordAsync(string username)
        {
            try
            {
                var response = await client.PostAsJsonAsync("api/auth/forgot-password", new ForgotPasswordRequest(username));
                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                if (response.IsSuccessStatusCode && (result?.IsSuccess ?? false))
                {
                    return Result.Success;
                }

                return Error.Failure("Auth.OtpFailed", result?.Message ?? "Gửi OTP thất bại!");
            }
            catch (Exception ex)
            {
                return Error.Failure("Network.Error", ex.Message);
            }
        }

        public static async Task<ErrorOr<Success>> VerifyOtpAsync(string username, string otp)
        {
            try
            {
                var response = await client.PostAsJsonAsync("api/auth/verify-otp", new VerifyOtpRequest(username, otp));
                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                if (response.IsSuccessStatusCode && (result?.IsSuccess ?? false))
                {
                    return Result.Success;
                }

                return Error.Validation("Auth.OtpInvalid", result?.Message ?? "Mã OTP không chính xác hoặc đã hết hạn!");
            }
            catch (Exception ex)
            {
                return Error.Failure("Network.Error", ex.Message);
            }
        }

        public static async Task<ErrorOr<Success>> ChangePasswordAsync(string username, string newPassword)
        {
            try
            {
                var response = await client.PostAsJsonAsync("api/account/change-password", new ChangePasswordRequest(username, newPassword));
                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                if (response.IsSuccessStatusCode && (result?.IsSuccess ?? false))
                {
                    return Result.Success;
                }

                return Error.Failure("Account.ChangePasswordFailed", result?.Message ?? "Đổi mật khẩu thất bại!");
            }
            catch (Exception ex)
            {
                return Error.Failure("Network.Error", ex.Message);
            }
        }

        public static async Task<ErrorOr<Success>> RegisterAccountAsync(RegisterAccountRequest request)
        {
            try
            {
                var response = await client.PostAsJsonAsync("api/account/register", request);
                var result = await response.Content.ReadFromJsonAsync<ApiResponse>();
                if (response.IsSuccessStatusCode && (result?.IsSuccess ?? false))
                {
                    return Result.Success;
                }

                string msg = result?.Message ?? "Tạo tài khoản thất bại!";
                return Error.Failure("Account.RegisterFailed", msg);
            }
            catch (Exception ex)
            {
                return Error.Failure("Network.Error", $"Lỗi kết nối máy chủ: {ex.Message}");
            }
        }
    }
}
