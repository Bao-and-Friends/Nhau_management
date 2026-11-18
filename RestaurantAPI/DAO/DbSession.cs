using Microsoft.Data.SqlClient;
using System.Data.Common;

namespace RestaurantAPI.DAO
{
    public class  DbSession(IConfiguration configuration) : IAsyncDisposable
    {
        public DbConnection Connect { get; } = new SqlConnection(configuration.GetConnectionString("DefaultConnection"));
        public DbTransaction? Transaction { get; set; }

        public async ValueTask DisposeAsync()
        {
            if (Transaction != null)
               await Transaction.DisposeAsync();
            if (Connect != null)
                await Connect.DisposeAsync();
            GC.SuppressFinalize(this);
        }
    }
}
