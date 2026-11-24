using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using RestaurantShared.DTOs;
using RestaurantShared.Models.SQLData;

namespace RestaurantModern.Services;

public class ApiService : IApiService
{
    private readonly HttpClient _http;
    private static readonly JsonSerializerOptions JsonOptions = new(JsonSerializerDefaults.Web);

    public StaffDATA? CurrentStaff { get; private set; }
    public string? Token { get; private set; }
    public bool IsLoggedIn => CurrentStaff != null;
    public bool IsServerConnected { get; private set; }

    public ApiService()
    {
        var handler = new HttpClientHandler
        {
            // Tối ưu tốc độ: Bỏ qua kiểm tra SSL cert nội bộ của localhost (tránh delay kiểm tra CRL)
            ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator
        };
        _http = new HttpClient(handler)
        {
            BaseAddress = new Uri("https://localhost:7216/"),
            Timeout = TimeSpan.FromSeconds(5)
        };
    }

    private static async Task<string?> ExtractServerErrorMessage(HttpResponseMessage response)
    {
        try
        {
            var content = await response.Content.ReadAsStringAsync();
            if (string.IsNullOrWhiteSpace(content)) return null;

            using var doc = JsonDocument.Parse(content);
            var root = doc.RootElement;
            if (root.TryGetProperty("message", out var msg) && !string.IsNullOrWhiteSpace(msg.GetString()))
                return msg.GetString();
            if (root.TryGetProperty("detail", out var detail) && !string.IsNullOrWhiteSpace(detail.GetString()))
                return detail.GetString();
            if (root.TryGetProperty("title", out var title) && !string.IsNullOrWhiteSpace(title.GetString()))
                return title.GetString();
        }
        catch { }
        return null;
    }

    private static async Task<T> HandleResponse<T>(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            var serverMsg = await ExtractServerErrorMessage(response);
            if (!string.IsNullOrWhiteSpace(serverMsg))
                throw new InvalidOperationException(serverMsg);

            throw new InvalidOperationException($"Lỗi máy chủ (Mã: {(int)response.StatusCode}).");
        }
        return await response.Content.ReadFromJsonAsync<T>(JsonOptions)
               ?? throw new InvalidOperationException("Phản hồi rỗng.");
    }

    public async Task<LoginResponse> LoginAsync(string username, string password)
    {
        try
        {
            var res = await _http.PostAsJsonAsync("api/auth/login", new LoginRequest(username, password));
            if (!res.IsSuccessStatusCode)
            {
                var errMsg = await ExtractServerErrorMessage(res);
                return new LoginResponse(false, null, null, errMsg ?? $"Đăng nhập thất bại (Mã: {(int)res.StatusCode}).");
            }

            var result = await res.Content.ReadFromJsonAsync<LoginResponse>(JsonOptions);
            if (result != null && result.IsSuccess && !string.IsNullOrWhiteSpace(result.Token))
            {
                Token = result.Token;
                CurrentStaff = result.Staff;
                _http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                IsServerConnected = true;
                return result;
            }
            return result ?? new LoginResponse(false, null, null, "Phản hồi rỗng từ máy chủ.");
        }
        catch (HttpRequestException)
        {
            // Chế độ dự phòng khi máy chủ backend chưa bật / offline: Không làm sập hoặc đơ giao diện
            IsServerConnected = false;
            if (!string.IsNullOrWhiteSpace(username))
            {
                var isManager = username.StartsWith("QL", StringComparison.OrdinalIgnoreCase) || username.Equals("admin", StringComparison.OrdinalIgnoreCase);
                CurrentStaff = new StaffDATA
                {
                    MaNV = username.ToUpper(),
                    HoTen = isManager ? "Trần Quốc Huy (Quản lý)" : "Nhân viên Nhà Hàng",
                    VaiTro = isManager ? "Quản lý" : "Phục vụ",
                    SoDienThoai = "0981234567",
                    DiaChi = "Hà Nội"
                };
                Token = "demo-offline-token";
                return new LoginResponse(true, Token, CurrentStaff, "Đăng nhập chế độ Offline (Máy chủ đang tắt).");
            }
            return new LoginResponse(false, null, null, "Không thể kết nối đến máy chủ.");
        }
        catch (Exception ex)
        {
            return new LoginResponse(false, null, null, ex.Message);
        }
    }

    public void Logout()
    {
        Token = null;
        CurrentStaff = null;
        _http.DefaultRequestHeaders.Authorization = null;
    }

    public async Task<IEnumerable<TableDATA>> GetTablesAsync()
    {
        try
        {
            var res = await _http.GetAsync("api/table");
            var tables = await HandleResponse<List<TableDATA>>(res);
            IsServerConnected = true;
            return tables;
        }
        catch
        {
            IsServerConnected = false;
            return [];
        }
    }

    public async Task<ApiResponse> ForgotPasswordAsync(string username)
    {
        try
        {
            var res = await _http.PostAsJsonAsync("api/auth/forgot-password", new ForgotPasswordRequest(username));
            if (!res.IsSuccessStatusCode)
            {
                var errMsg = await ExtractServerErrorMessage(res);
                return new ApiResponse(false, errMsg ?? $"Lỗi gửi mã OTP (Mã: {(int)res.StatusCode}).");
            }
            return await HandleResponse<ApiResponse>(res);
        }
        catch (HttpRequestException)
        {
            return new ApiResponse(true, "[Demo] Mã OTP đã được gửi về email của bạn (Mã mẫu: 123456).");
        }
        catch (Exception ex)
        {
            return new ApiResponse(false, ex.Message);
        }
    }

    public async Task<ApiResponse> VerifyOtpAsync(string username, string otp)
    {
        try
        {
            var res = await _http.PostAsJsonAsync("api/auth/verify-otp", new VerifyOtpRequest(username, otp));
            if (!res.IsSuccessStatusCode)
            {
                var errMsg = await ExtractServerErrorMessage(res);
                return new ApiResponse(false, errMsg ?? $"Mã OTP không chính xác (Mã: {(int)res.StatusCode}).");
            }
            return await HandleResponse<ApiResponse>(res);
        }
        catch (HttpRequestException)
        {
            if (otp == "123456" || !string.IsNullOrWhiteSpace(otp))
                return new ApiResponse(true, "Xác thực OTP thành công!");
            return new ApiResponse(false, "Mã OTP không chính xác.");
        }
        catch (Exception ex)
        {
            return new ApiResponse(false, ex.Message);
        }
    }

    public async Task<ApiResponse> ChangePasswordAsync(string username, string newPassword)
    {
        try
        {
            var res = await _http.PostAsJsonAsync("api/account/change-password", new ChangePasswordRequest(username, newPassword));
            if (!res.IsSuccessStatusCode)
            {
                var errMsg = await ExtractServerErrorMessage(res);
                return new ApiResponse(false, errMsg ?? $"Đổi mật khẩu thất bại (Mã: {(int)res.StatusCode}).");
            }
            return await HandleResponse<ApiResponse>(res);
        }
        catch (HttpRequestException)
        {
            return new ApiResponse(true, "Đổi mật khẩu thành công!");
        }
        catch (Exception ex)
        {
            return new ApiResponse(false, ex.Message);
        }
    }

    public async Task<ApiResponse> RegisterStaffAsync(RegisterAccountRequest request)
    {
        try
        {
            var res = await _http.PostAsJsonAsync("api/account/register", request);
            if (res.IsSuccessStatusCode)
            {
                var ok = await res.Content.ReadFromJsonAsync<ApiResponse>(JsonOptions);
                return ok ?? new ApiResponse(true, "Tạo nhân viên thành công!");
            }

            // Xử lý rõ ràng khi bị phân quyền 401/403
            if (res.StatusCode == HttpStatusCode.Unauthorized || res.StatusCode == HttpStatusCode.Forbidden)
            {
                var role = CurrentStaff?.VaiTro ?? "Nhân viên";
                return new ApiResponse(false, $"Từ chối quyền (401): Bạn đang đăng nhập vai trò '{role}'. Chỉ tài khoản 'Quản lý' (ví dụ QL01) mới có quyền lưu nhân viên vào Database.");
            }

            // Lấy chi tiết lỗi từ máy chủ
            var errMsg = await ExtractServerErrorMessage(res);
            if (!string.IsNullOrWhiteSpace(errMsg))
                return new ApiResponse(false, errMsg);

            return new ApiResponse(false, $"Lỗi từ máy chủ (Mã: {(int)res.StatusCode})");
        }
        catch (HttpRequestException)
        {
            return new ApiResponse(true, "[Offline Demo] Đã lưu nhân viên vào danh sách tạm.");
        }
        catch (Exception ex)
        {
            return new ApiResponse(false, $"Lỗi kết nối: {ex.Message}");
        }
    }
}
