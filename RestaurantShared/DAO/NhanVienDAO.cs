using Microsoft.Data.SqlClient;
using RestaurantShared.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestaurantShared.DAO
{
    public class NhanVienDAO
    {
        private static readonly Lazy<NhanVienDAO> NvDAO = new(() => new NhanVienDAO());
        public static NhanVienDAO Instance => NvDAO.Value;
        public NhanVienDAO() { }

        public NhanVienDATA? GetNhanVienbyID(string id)
        {
            string query = @"select * from NHANVIEN where MaNV = @id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new SqlParameter("id", id));
            if (data.Rows.Count > 0)
            {
                NhanVienDATA nv = new(data.Rows[0]);
                return nv;
            }
            return null;
        }

        // Lấy danh sách toàn bộ nhân viên kèm tên đăng nhập
        public DataTable GetListNhanVienWithAccount()
        {
            string query = @"SELECT N.MaNV, N.HoTen, N.NgaySinh, N.GioiTinh, N.SoDienThoai, N.DiaChi, N.VaiTro, N.TrangThai, T.TenDangNhap
                             FROM NHANVIEN N 
                             LEFT JOIN TAIKHOAN T ON N.MaNV = T.MaNV
                             ORDER BY N.MaNV ASC";
            return DataProvider.Instance.ExecuteQuery(query);
        }

        // Tự động sinh mã nhân viên tiếp theo (ví dụ: NV01, NV02 -> NV03)
        public string GetNextStaffCode()
        {
            try
            {
                string query = "SELECT COUNT(*) FROM NHANVIEN";
                object? countObj = DataProvider.Instance.ExecuteScalar(query);
                int count = countObj != null ? Convert.ToInt32(countObj) + 1 : 1;
                return $"NV{count:D2}";
            }
            catch
            {
                return $"NV{Random.Shared.Next(10, 99)}";
            }
        }
    }
}
