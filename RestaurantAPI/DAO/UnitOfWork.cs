using RestaurantAPI.DAO.Interface;

namespace RestaurantAPI.DAO
{
    public class UnitOfWork(DbSession session) : IUnitOfWork
    {
        private readonly DbSession _session = session;

        // 1. BẮT ĐẦU TRANSACTION
        public async Task BeginTransactionAsync()
        {
            if (_session.Connect.State != System.Data.ConnectionState.Open)
                await _session.Connect.OpenAsync();
            _session.Transaction = await _session.Connect.BeginTransactionAsync();
        }

        // 2. XÁC NHẬN TRANSACTION
        public async Task CommitAsync()
        {
            if (_session.Transaction != null)
            {
                await _session.Transaction.CommitAsync();
            }
        }

        // 3. HỦY BỎ TRANSACTION
        public async Task RollbackAsync()
        {
            if (_session.Transaction != null)
            {
                await _session.Transaction.RollbackAsync();
            }
        }

        public async ValueTask DisposeAsync()
        {
             await _session.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}