using RestaurantShared.DTOs;
using RestaurantShared.Models.SQLData;

namespace RestaurantModern.Services;

public interface IApiService
{
    StaffDATA? CurrentStaff { get; }
    string? Token { get; }
    bool IsLoggedIn { get; }
    bool IsServerConnected { get; }

    Task<LoginResponse> LoginAsync(string username, string password);
    void Logout();
    Task<IEnumerable<TableDATA>> GetTablesAsync();
    Task<IEnumerable<StaffDATA>> GetStaffAsync();
    Task<IEnumerable<BillDATA>> GetBillsAsync();
    Task<IEnumerable<OrderDATA>> GetDishesAsync();
    Task<ApiResponse> ForgotPasswordAsync(string username);
    Task<ApiResponse> VerifyOtpAsync(string username, string otp);
    Task<ApiResponse> ChangePasswordAsync(string username, string newPassword);
    Task<ApiResponse> RegisterStaffAsync(RegisterAccountRequest request);
}