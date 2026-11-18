using RestaurantAPI.DAO.Interface;
using RestaurantAPI.Services.Interface;
using RestaurantShared.DTOs;

namespace RestaurantAPI.Services
{
    public class AccountService(IUnitOfWork uow, IStaffRepository StaffRepo, IAccountRepository AccRepo): IAccountService
    {
        public async Task<(bool IsSuccess, string Message)> RegisterStaffAccountAsync(RegisterAccountRequest request)
        {
            // 1. Kiểm tra Username đã có ai dùng chưa
            if (await AccRepo.CheckUsernameExistsAsync(request.Username))
                return (false, "Tên đăng nhập này đã tồn tại, vui lòng chọn tên khác!");

            // 2. Băm mật khẩu bảo mật bằng BCrypt
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // 3. 🔒 BẮT ĐẦU TRANSACTION QUA UNIT OF WORK
            await uow.BeginTransactionAsync();
            try
            {
                // Thêm vào bảng NHANVIEN (dùng chung Connection và Transaction)
                int nvId = await StaffRepo.InsertAsync(request.HoTen, request.GioiTinh, request.VaiTro, request.NgaySinh, request.SoDienThoai, request.DiaChi);

                // Thêm vào bảng TAIKHOAN liên kết qua NVId
                await AccRepo.InsertAccountAsync(nvId, request.Username, passwordHash, request.Email);

                // ✅ Xác nhận lưu cả 2 bảng thành công vào DB
                await uow.CommitAsync();
            }
            catch (Exception ex)
            {
                // ❌ Nếu có bất kỳ lỗi nào -> Tự động hủy sạch, không có dữ liệu rác
                await uow.RollbackAsync();
                return (false, $"Lỗi khi lưu dữ liệu nhân viên: {ex.Message}");
            }

            return (true, "Tạo nhân viên thành công!");
        }

        public async Task<(bool IsSuccess, string Message)> ChangePasswordAsync(string username, string newPassword)
        {
            bool isUpdated = await AccRepo.ChangePasswordAsync(username, newPassword);
            if (!isUpdated)
                return (false, "Đổi mật khẩu thất bại!");

            return (true, "Đổi mật khẩu thành công!");
        }
    }
}
