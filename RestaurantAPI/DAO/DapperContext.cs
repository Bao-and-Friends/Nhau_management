using Dapper;
using Microsoft.Data.SqlClient;

namespace RestaurantAPI.Data
{
    public class DapperContext
    {
        private readonly string _connectionString;
        public DapperContext(IConfiguration configuration)
        {
            // Đọc DefaultConnection 
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        private SqlConnection CreateConnection() => new SqlConnection(_connectionString);

        // 1. Hàm lấy danh sách (Thay thế ExecuteQuery trả về List DTO)
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null)
        {
            using var connection = CreateConnection();
            return await connection.QueryAsync<T>(sql, param);
        }
        // 2. Hàm lấy 1 dòng duy nhất (hoặc null nếu không tìm thấy)
        public async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null)
        {
            using var connection = CreateConnection();
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param);
        }
        // 3. Hàm Thêm / Sửa / Xóa (Thay thế ExecuteNonQuery trả về số dòng ảnh hưởng)
        public async Task<int> ExecuteAsync(string sql, object? param = null)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteAsync(sql, param);
        }
        // 4. Hàm lấy giá trị đơn lẻ (Thay thế ExecuteScalar như COUNT, MAX)
        public async Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null)
        {
            using var connection = CreateConnection();
            return await connection.ExecuteScalarAsync<T>(sql, param);
        }
    }
}
