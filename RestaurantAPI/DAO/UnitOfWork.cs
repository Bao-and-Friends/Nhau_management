using Dapper;
using Microsoft.Data.SqlClient;
using RestaurantAPI.DAO;

namespace RestaurantAPI.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly string _connectionString;
        private SqlConnection? _connection;
        private SqlTransaction? _transaction;
        public SqlConnection Connection => _connection ?? throw new InvalidOperationException("Chưa mở kết nối. Hãy gọi BeginTransactionAsync() trước!");
        public SqlTransaction? Transaction => _transaction;

        // Các DAO con
        public StaffDAO Staffs { get; }
        public AccountDAO Accounts { get; }
        public TableDAO Tables { get; }

        public UnitOfWork(
            IConfiguration configuration,
            StaffDAO staffDao,
            AccountDAO accountDao,
            TableDAO tableDao)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
            Staffs = staffDao;
            Accounts = accountDao;
            Tables = tableDao;
        }

        // Tự động mở kết nối dùng chung nếu chưa mở
        private async Task<SqlConnection> GetOpenConnectionAsync()
        {
            if (_connection == null)
            {
                _connection = new SqlConnection(_connectionString);
                await _connection.OpenAsync();
            }
            else if (_connection.State != System.Data.ConnectionState.Open)
            {
                await _connection.OpenAsync();
            }
            return _connection;
        }

        // 1. BẮT ĐẦU TRANSACTION
        public async Task BeginTransactionAsync()
        {
            var conn = await GetOpenConnectionAsync();
            _transaction = conn.BeginTransaction();
        }

        // 2. XÁC NHẬN TRANSACTION
        public async Task CommitAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        // 3. HỦY BỎ TRANSACTION
        public async Task RollbackAsync()
        {
            try
            {
                if (_transaction != null)
                {
                    await _transaction.RollbackAsync();
                }
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        // 4. CÁC HÀM DAPPER TỰ ĐỘNG ĐÍNH KÈM TRANSACTION NẾU CÓ
        public async Task<IEnumerable<T>> QueryAsync<T>(string sql, object? param = null)
        {
            var conn = await GetOpenConnectionAsync();
            return await conn.QueryAsync<T>(sql, param, _transaction);
        }

        public async Task<T?> QueryFirstOrDefaultAsync<T>(string sql, object? param = null)
        {
            var conn = await GetOpenConnectionAsync();
            return await conn.QueryFirstOrDefaultAsync<T>(sql, param, _transaction);
        }

        public async Task<int> ExecuteAsync(string sql, object? param = null)
        {
            var conn = await GetOpenConnectionAsync();
            return await conn.ExecuteAsync(sql, param, _transaction);
        }

        public async Task<T?> ExecuteScalarAsync<T>(string sql, object? param = null)
        {
            var conn = await GetOpenConnectionAsync();
            return await conn.ExecuteScalarAsync<T>(sql, param, _transaction);
        }

        private async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        // Tự động đóng kết nối khi Request kết thúc (chống rò rỉ Connection)
        public async ValueTask DisposeAsync()
        {
            await DisposeTransactionAsync();
            if (_connection != null)
            {
                await _connection.DisposeAsync();
                _connection = null;
            }
        }
    }
}