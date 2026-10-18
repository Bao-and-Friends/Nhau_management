using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestaurantShared.DTO
{
    public class NhanVienDATA
    {
        public NhanVienDATA(
       string maNV,
       string hoTen,
       DateTime ngaySinh,
       string gioiTinh,
       string soDienThoai,
       string diaChi,
       string vaiTro,
       string trangThai)
        {
            MaNV = maNV;
            HoTen = hoTen;
            NgaySinh = ngaySinh;
            GioiTinh = gioiTinh;
            SoDienThoai = soDienThoai;
            DiaChi = diaChi;
            VaiTro = vaiTro;
            TrangThai = trangThai;
        }

        public NhanVienDATA(DataRow row)
        {
            MaNV =row["MaNV"].ToString();
            HoTen = row["HoTen"] == DBNull.Value ? "Chưa có tên" : row["HoTen"].ToString();
            NgaySinh = row["NgaySinh"] == DBNull.Value
                ? DateTime.MinValue
                : Convert.ToDateTime(row["NgaySinh"]);
            GioiTinh =row["GioiTinh"].ToString();
            SoDienThoai = row["SoDienThoai"] == DBNull.Value ? "Chưa có SDT" : row["SoDienThoai"].ToString();
            DiaChi = row["DiaChi"] == DBNull.Value ? "Chưa có địa chỉ" : row["DiaChi"].ToString();
            VaiTro =row["VaiTro"].ToString();
            TrangThai =row["TrangThai"].ToString();
        }
        private string maNV;
        private string hoTen;
        private DateTime ngaySinh;
        private string gioiTinh;
        private string soDienThoai;
        private string diaChi;
        private string vaiTro;
        private string trangThai;

        public string MaNV
        {
            get { return maNV; }
            set { maNV = value; }
        }

        public string HoTen
        {
            get { return hoTen; }
            set { hoTen = value; }
        }

        public DateTime NgaySinh
        {
            get { return ngaySinh; }
            set { ngaySinh = value; }
        }

        public string GioiTinh
        {
            get { return gioiTinh; }
            set { gioiTinh = value; }
        }

        public string SoDienThoai
        {
            get { return soDienThoai; }
            set { soDienThoai = value; }
        }

        public string DiaChi
        {
            get { return diaChi; }
            set { diaChi = value; }
        }

        public string VaiTro
        {
            get { return vaiTro; }
            set { vaiTro = value; }
        }

        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }
    }
}
