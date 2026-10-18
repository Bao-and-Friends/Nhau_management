using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestaurantShared.DTO
{
    public class AccountDATA
    {
        public AccountDATA(string matk,string manv,string state,string ngaytao)
        {
            this.MaTaiKhoan = matk;
            this.MaNV = manv;
             this.TrangThai = state;
            this.NgayTao = ngaytao;
        }
        public AccountDATA(DataRow row)
        {
            this.MaTaiKhoan = row["MaTaiKhoan"].ToString();
            this.MaNV = row["MaNV"].ToString(); 
            this.TrangThai = row["TrangThai"].ToString(); 
            this.NgayTao = row["NgayTao"].ToString(); 
        }
        private string maTaiKhoan;
        private string maNV;

        private string trangThai;

        private string ngayTao;

        public string MaTaiKhoan { get => maTaiKhoan; set => maTaiKhoan = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string NgayTao { get => ngayTao; set => ngayTao = value; }
    }
}
