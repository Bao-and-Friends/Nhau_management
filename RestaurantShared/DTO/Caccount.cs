using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantShared.DTO
{
    public class Caccount
    {
        private string maTaiKhoan;
        private string maNV;

        private string trangThai;

        private string NgayTao;

        public string MaTaiKhoan { get => maTaiKhoan; set => maTaiKhoan = value; }
        public string MaNV { get => maNV; set => maNV = value; }
        public string TrangThai { get => trangThai; set => trangThai = value; }
        public string NgayTao1 { get => NgayTao; set => NgayTao = value; }
    }
}
