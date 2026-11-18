using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Interface
{
    public interface IAccountRepository
    {
        Task<bool> CheckUsernameExistsAsync(string username);
        Task<(bool IsSuccess, int NVId, string Message)> ValidateLoginAsync(string username, string password);
        Task<string?> GetEmailByUsernameAsync(string username);
        Task<bool> ChangePasswordAsync(string username, string newPassword);
        Task<bool> InsertAccountAsync(int nvId, string username, string passwordHash, string? email);
    }
}
