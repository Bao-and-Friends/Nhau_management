using System;
using System.Data;

namespace RestaurantShared.DTO
{
    public class AccountDATA
    {
        public AccountDATA() { }


        public AccountDATA(string matk, string manv, string state, DateTime ngaytao)
        {
            this.MaTaiKhoan = matk;
            this.MaNV = manv;
            this.TrangThai = state;
            this.NgayTao = ngaytao;
        }

        public AccountDATA(DataRow row)
        {
            this.MaTaiKhoan = row["MaTaiKhoan"] == DBNull.Value ? string.Empty : row["MaTaiKhoan"].ToString()!;
            this.MaNV = row["MaNV"] == DBNull.Value ? string.Empty : row["MaNV"].ToString()!;
            this.TrangThai = row["TrangThai"] == DBNull.Value ? string.Empty : row["TrangThai"].ToString()!;
            this.NgayTao = row["NgayTao"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayTao"]);
        }

        public string MaTaiKhoan { get; set; } = string.Empty;
        public string MaNV { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;
        public DateTime NgayTao { get; set; } = DateTime.Now;
    }
}