using RestaurantAPI.DAO;
using RestaurantAPI.Data;
using RestaurantShared.DTOs;

namespace RestaurantAPI.Services
{
    public class AccountService(IUnitOfWork uow, MailService mailService)
    {
        public async Task<(bool IsSuccess, string Message)> RegisterStaffAccountAsync(RegisterAccountRequest request)
        {
            // 1. Kiểm tra Username đã có ai dùng chưa
            if (await uow.Accounts.CheckUsernameExistsAsync(request.Username))
                return (false, "Tên đăng nhập này đã tồn tại, vui lòng chọn tên khác!");

            // 2. Tự động sinh Mã nhân viên tiếp theo (NV01 -> NV02...)
            string nextMaNV = await uow.Staffs.GenerateNextMaNVAsync();

            // 3. Băm mật khẩu bảo mật bằng BCrypt
            string passwordHash = BCrypt.Net.BCrypt.HashPassword(request.Password);

            // 4. 🔒 BẮT ĐẦU TRANSACTION QUA UNIT OF WORK
            await uow.BeginTransactionAsync();
            try
            {
                // Thêm vào bảng NHANVIEN (dùng chung Connection và Transaction)
                await uow.Staffs.InsertAsync(
                    nextMaNV, request.HoTen, request.GioiTinh, request.VaiTro,
                    request.NgaySinh, request.SoDienThoai, request.Email, request.DiaChi,
                    uow.Connection, uow.Transaction
                );

                // Thêm vào bảng TAIKHOAN (dùng chung Connection và Transaction)
                await uow.Accounts.InsertAccountAsync(
                    nextMaNV, request.Username, passwordHash,
                    uow.Connection, uow.Transaction
                );

                // ✅ Xác nhận lưu cả 2 bảng thành công vào DB
                await uow.CommitAsync();
            }
            catch (Exception ex)
            {
                // ❌ Nếu có bất kỳ lỗi nào -> Tự động hủy sạch, không có dữ liệu rác
                await uow.RollbackAsync();
                return (false, $"Lỗi khi lưu dữ liệu nhân viên: {ex.Message}");
            }

            // 5. Gửi email thông báo thông tin tài khoản cho nhân viên (chạy nền)
            if (!string.IsNullOrWhiteSpace(request.Email))
            {
                _ = Task.Run(async () =>
                {
                    try
                    {
                        string body = $@"
                            <div style='font-family: Arial, sans-serif; padding: 20px;'>
                                <h2 style='color: #2e7d32;'>Chào mừng {request.HoTen} đến với nhà hàng!</h2>
                                <p>Tài khoản làm việc của bạn đã được khởi tạo thành công:</p>
                                <ul>
                                    <li><b>Mã nhân viên:</b> {nextMaNV}</li>
                                    <li><b>Tên đăng nhập:</b> {request.Username}</li>
                                    <li><b>Chức vụ:</b> {request.VaiTro}</li>
                                </ul>
                                <p>Vui lòng đăng nhập phần mềm để bắt đầu làm việc.</p>
                            </div>";
                        await mailService.SendEmailAsync(request.Email, "Thông tin tài khoản nhân viên", body);
                    }
                    catch { /* Không làm ảnh hưởng luồng chính nếu gửi mail thất bại */ }
                });
            }

            return (true, $"Tạo nhân viên thành công với Mã: {nextMaNV}");
        }
        public async Task<(bool IsSuccess, string Message)> ChangePasswordAsync(string username, string newPassword)
        {
            bool isUpdated = await uow.Accounts.ChangePasswordAsync(username, newPassword);
            if (!isUpdated)
                return (false, "Đổi mật khẩu thất bại!");

            return (true, "Đổi mật khẩu thành công!");
        }
    }
}
