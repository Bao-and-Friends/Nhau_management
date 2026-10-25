using Microsoft.Data.SqlClient;
using System;
using System.Data;
using RestaurantShared;
using RestaurantShared.DTO;

namespace RestaurantSever.DAO
{
    public class NhanVienDAO
    {
        private static readonly Lazy<NhanVienDAO> NvDAO = new(() => new NhanVienDAO());
        public static NhanVienDAO Instance => NvDAO.Value;
        private NhanVienDAO() { }

        public NhanVienDATA? GetNhanVienbyID(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                return null;
            string query= @"select * from NHANVIEN where MaNV = @id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new SqlParameter("@id", id));
            if(data.Rows.Count >0)
            {
                NhanVienDATA nv = new(data.Rows[0]);
                return nv;
            }
            return null;
        }
    }
}
