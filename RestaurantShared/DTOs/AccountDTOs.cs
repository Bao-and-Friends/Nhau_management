using System;

namespace RestaurantShared.DTOs
{
    // Yêu cầu tạo tài khoản nhân viên mới
    public record RegisterAccountRequest(
        string Username,
        string Password,
        string HoTen,
        string VaiTro,
        string GioiTinh,
        DateTimeOffset? NgaySinh,
        string? SoDienThoai,
        string? Email,
        string? DiaChi
    );

    // Thông tin tài khoản gửi qua SignalR khi tạo tài khoản thành công
    public record NewAccountNotification(
        string MaNV,
        string Username,
        string HoTen,
        string VaiTro,
        string? SoDienThoai,
        string? Email
    );
}
