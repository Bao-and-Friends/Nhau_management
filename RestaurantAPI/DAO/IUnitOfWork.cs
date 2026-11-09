using Microsoft.Data.SqlClient;
using RestaurantAPI.Data;

namespace RestaurantAPI.DAO
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        SqlConnection Connection { get; }
        SqlTransaction? Transaction { get; }
        // 1. Quản lý Giao dịch (Transaction)
        Task BeginTransactionAsync();
        Task CommitAsync();
        Task RollbackAsync();
        // 2. Các hàm thực thi Dapper (Tự động kèm Transaction nếu đang chạy giao dịch)
        Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null);
        Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null);
        Task<int> ExecuteAsync(string sql, object? param = null);
        Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null);
        // 3. Khai báo các DAO thuộc quyền quản lý của Unit of Work
        StaffDAO Staffs { get; }
        AccountDAO Accounts { get; }
        TableDAO Tables { get; }
    }
}
