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
            string query= @"select * from NHANVIEN where MaNV = @id";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new SqlParameter("id", id));
            if(data.Rows.Count >0)
            {
                NhanVienDATA nv = new(data.Rows[0]);
                return nv;
            }
            return null;
        }
    }
}
