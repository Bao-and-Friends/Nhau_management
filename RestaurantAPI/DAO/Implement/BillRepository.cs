using Dapper;
using RestaurantAPI.DAO.Interface;
using RestaurantShared.Models.SQLData;

namespace RestaurantAPI.DAO.Implement
{
    public class BillRepository(DbSession session) : IBillRepository
    {
        public async Task<IEnumerable<BillDATA>> GetAllBillAsync()
        {
            string query = @"
                SELECT 
                    hd.HoaDonID,
                    hd.MaHoaDon,
                    hd.BanID,
                    b.MaBan,
                    b.TenBan,
                    hd.NhanVienID,
                    nv.HoTen AS TenNhanVien,
                    hd.KhuyenMaiID,
                    km.TenKM,
                    hd.ThoiGianVao,
                    hd.ThoiGianRa,
                    hd.TongTienHang,
                    hd.PhuThu,
                    hd.GiamGia,
                    hd.ThueVAT,
                    hd.TongThanhToan,
                    hd.TrangThai,
                    hd.GhiChu
                FROM HOADON hd
                JOIN BAN b ON hd.BanID = b.BanID
                LEFT JOIN NHANVIEN nv ON hd.NhanVienID = nv.NhanVienID
                LEFT JOIN KHUYENMAI km ON hd.KhuyenMaiID = km.KhuyenMaiID
                ORDER BY hd.ThoiGianVao DESC";
            return await session.Connect.QueryAsync<BillDATA>(query, transaction: session.Transaction);
        }
    }
}
