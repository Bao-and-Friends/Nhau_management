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
}
