using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Interface
{
    public interface IAccountRepository
    {
        Task<bool> CheckUsernameExistsAsync(string username);
        Task<AccountDATA?> GetByUsernameAsync(string username);
        Task<string?> GetEmailByUsernameAsync(string username);
        Task<bool> UpdatePasswordHashAsync(string username, string passwordHash);
        Task<bool> InsertAccountAsync(int nvId, string username, string passwordHash, string? email);
    }
}
