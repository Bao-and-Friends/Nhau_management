using ErrorOr;
using RestaurantAPI.DAO.Interface;
using RestaurantAPI.Services.Interface;
using RestaurantShared.DTOs;

namespace RestaurantAPI.Services
{
    public class AccountService(IUnitOfWork uow, IStaffRepository StaffRepo, IAccountRepository AccRepo): IAccountService
    {
        public async Task<ErrorOr<Success>> RegisterStaffAccountAsync(RegisterAccountRequest request)
        {
            // 1. Kiểm tra tính hợp lệ của dữ liệu đầu vào (Validation)
            if (string.IsNullOrWhiteSpace(request.Username))
                return Error.Validation("Account.EmptyUsername", "Tên đăng nhập không được để trống!");

            if (string.IsNullOrWhiteSpace(request.Password) || request.Password.Length < 6)
                return Error.Validation("Account.InvalidPassword", "Mật khẩu phải có ít nhất 6 ký tự!");

            if (string.IsNullOrWhiteSpace(request.HoTen))
                return Error.Validation("Account.EmptyHoTen", "Họ tên không được để trống!");

            // 2. Kiểm tra Username đã có ai dùng chưa
            if (await AccRepo.CheckUsernameExistsAsync(request.Username))
                return Error.Conflict("Account.DuplicateUsername", "Tên đăng nhập này đã tồn tại, vui lòng chọn tên khác!");

            // 3. Băm mật khẩu bảo mật bằng BCrypt
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // 4. 🔒 BẮT ĐẦU TRANSACTION QUA UNIT OF WORK
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
                return Error.Failure("Account.RegisterFailed", $"Lỗi khi lưu dữ liệu nhân viên: {ex.Message}");
            }

            return Result.Success;
        }

        public async Task<ErrorOr<Success>> ChangePasswordAsync(string username, string newPassword)
        {
            if (string.IsNullOrWhiteSpace(newPassword))
                return Error.Validation("Account.EmptyPassword", "Mật khẩu mới không được để trống!");

            if (newPassword.Length < 6)
                return Error.Validation("Account.ShortPassword", "Mật khẩu mới phải có ít nhất 6 ký tự!");

            string passwordHash = BCrypt.Net.BCrypt.HashPassword(newPassword);
            bool isUpdated = await AccRepo.UpdatePasswordHashAsync(username, passwordHash);
            if (!isUpdated)
                return Error.NotFound("Account.NotFound", "Tài khoản không tồn tại hoặc đổi mật khẩu thất bại!");

            return Result.Success;
        }
    }
}
