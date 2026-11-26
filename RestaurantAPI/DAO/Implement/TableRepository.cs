using Dapper;
using RestaurantAPI.DAO.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Implement
{
    public class TableRepository(DbSession session): ITableRepository
    {
        public async Task<IEnumerable<TableDATA>> GetAllTablesAsync()
        {
            string query = @"
                SELECT 
                    b.BanID,
                    b.MaBan, 
                    b.TenBan, 
                    b.SucChua, 
                    b.TrangThai,
                    hd.ThoiGianVao AS CheckIn,
                    hd.ThoiGianRa AS CheckOut 
                FROM BAN b
                OUTER APPLY (
                    SELECT TOP 1 hd.ThoiGianVao, hd.ThoiGianRa 
                    FROM HOADON hd 
                    WHERE hd.BanID = b.BanID AND hd.TrangThai = N'Chưa thanh toán'
                    ORDER BY hd.ThoiGianVao DESC
                ) hd";

            return await session.Connect.QueryAsync<TableDATA>(query, transaction: session.Transaction);
        }
    }
}
