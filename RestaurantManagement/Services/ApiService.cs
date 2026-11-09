using RestaurantShared.Models.SQLData;
using System.DirectoryServices.ActiveDirectory;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Runtime.CompilerServices;
using System.Text.Json;
using static System.Net.WebRequestMethods;

namespace RestaurantManagement.Services
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
        public static async Task<(bool IsSuccess, string Message)> LoginAsync(string username, string password)
        {
            try
            {
                var response = await client.PostAsJsonAsync("api/auth/login", new
                {
                    Username = username,
                    Password = password
                });
                var result = await response.Content.ReadFromJsonAsync<LoginResponse>();
                if (response.IsSuccessStatusCode && result!=null)
                {
                    // Lấy Token và lưu vào biến tĩnh
                    Token = result.Token;
                    Staff = result.Staff;


                    // 👉 GẮN TOKEN VÀO HEADER ĐỂ CÁC REQUEST SAU TỰ CÓ QUYỀN
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                    return (true, "Đăng nhập thành công!");
                }
                else
                {
                    // Lấy câu thông báo lỗi từ Server (nếu có)
                    string msg = string.IsNullOrWhiteSpace(result?.Message) ? "Đăng nhập thất bại!" : result.Message;
                    return (false, msg);
                }
            }
            catch (Exception ex)
            {
                return (false, $"Lỗi kết nối máy chủ: {ex.Message}");
            }

        }
        public static void Logout()
        {
            Token = null;
            Staff = null;
            client.DefaultRequestHeaders.Authorization = null;
        }
        public static async Task<List<TableDATA>?> GetTablesAsync()
        {
            try
            {
                return await client.GetFromJsonAsync<List<TableDATA>>("api/table");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[Lỗi lấy danh sách bàn]: {ex.Message}");
                return null;
            }
        }

        public static async Task<(bool IsSuccess, string Message)> ForgotPasswordAsync(string username)
        {
            try
            {
                var response = await client.PostAsJsonAsync("api/auth/forgot-password", new { Username = username });
                var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                string msg = result.GetProperty("message").GetString()!;
                return (response.IsSuccessStatusCode, msg);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public static async Task<(bool IsSuccess, string Message)> VerifyOtpAsync(string username, string otp)
        {
            try
            {
                var response = await client.PostAsJsonAsync("api/auth/verify-otp", new { Username = username, Otp = otp });
                var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                string msg = result.GetProperty("message").GetString()!;
                return (response.IsSuccessStatusCode, msg);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        public static async Task<(bool IsSuccess, string Message)> ChangePasswordAsync(string username, string newPassword)
        {
            try
            {
                var response = await client.PostAsJsonAsync("api/auth/change-password", new { Username = username, NewPassword = newPassword });
                var result = await response.Content.ReadFromJsonAsync<JsonElement>();
                string msg = result.GetProperty("message").GetString()!;
                return (response.IsSuccessStatusCode, msg);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public record LoginResponse(bool IsSuccess, string? Token, StaffDATA? Staff, string? Message);
    }
}
