using System;
using System.Data;

namespace RestaurantShared.DTO
{
    public class NhanVienDATA
    {
        public NhanVienDATA()
        {
        }
        public NhanVienDATA(
            string maNV,
            string hoTen,
            DateTime ngaySinh,
            string gioiTinh,
            string soDienThoai,
            string diaChi,
            string vaiTro,
            string trangThai
            )
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
            MaNV = row["MaNV"] == DBNull.Value ? string.Empty : row["MaNV"].ToString()!;
            HoTen = row["HoTen"] == DBNull.Value ? "Chưa có tên" : row["HoTen"].ToString()!;
            NgaySinh = row["NgaySinh"] == DBNull.Value ? DateTime.MinValue : Convert.ToDateTime(row["NgaySinh"]);
            GioiTinh = row["GioiTinh"] == DBNull.Value ? "Chưa rõ" : row["GioiTinh"].ToString()!;
            SoDienThoai = row["SoDienThoai"] == DBNull.Value ? "Chưa có SDT" : row["SoDienThoai"].ToString()!;
            DiaChi = row["DiaChi"] == DBNull.Value ? "Chưa có địa chỉ" : row["DiaChi"].ToString()!;
            VaiTro = row["VaiTro"] == DBNull.Value ? string.Empty : row["VaiTro"].ToString()!;
            TrangThai = row["TrangThai"] == DBNull.Value ? string.Empty : row["TrangThai"].ToString()!;
        }

        public string MaNV { get; set; } = string.Empty;
        public string HoTen { get; set; } = string.Empty;
        public DateTime NgaySinh { get; set; } = DateTime.MinValue;
        public string GioiTinh { get; set; } = string.Empty;
        public string SoDienThoai { get; set; } = string.Empty;
        public string DiaChi { get; set; } = string.Empty;
        public string VaiTro { get; set; } = string.Empty;
        public string TrangThai { get; set; } = string.Empty;


    }
}