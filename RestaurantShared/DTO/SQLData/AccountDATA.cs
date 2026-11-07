using System;
using System.Data;

namespace RestaurantShared.DTO.SQLData
{
    public class AccountDATA
    {
        public AccountDATA() { }


        public AccountDATA( string manv, string state, DateTime ngaytao,string email)
        {
            this.MaNV = manv;
            this.TrangThai = state;
            this.NgayTao = ngaytao;
            this.Email = email;
        }

        public AccountDATA(DataRow row)
        {
            this.MaNV = row["MaNV"] == DBNull.Value ? string.Empty : row["MaNV"].ToString()!;
            this.TrangThai = row["TrangThai"] == DBNull.Value ? string.Empty : row["TrangThai"].ToString()!;
            this.NgayTao = row["NgayTao"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgayTao"]);
            this.Email = row["Email"] == DBNull.Value ? string.Empty : row["Email"].ToString()!;
        }

        public string MaNV { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;
        public DateTime NgayTao { get; set; } = DateTime.Now;
        public string Email { get; set; } = string.Empty;
    }
}