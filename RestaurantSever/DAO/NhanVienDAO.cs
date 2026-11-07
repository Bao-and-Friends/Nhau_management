using Microsoft.Data.SqlClient;
using System;
using System.Data;
using RestaurantShared;
using RestaurantShared.DTO.SQLData;

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
        // 1. Hàm tự động sinh MaNV tiếp theo (VD: đang có NV02 -> sinh ra NV03)
        public string GenerateNextMaNV()
        {
            // Sắp xếp theo độ dài trước rồi mới theo chữ cái để NV10 luôn lớn hơn NV09
            string query = "SELECT TOP 1 MaNV FROM NHANVIEN ORDER BY LEN(MaNV) DESC, MaNV DESC";
            object? result = DataProvider.Instance.ExecuteScalar(query);

            if (result != null && result != DBNull.Value)
            {
                string lastMaNV = result.ToString()!.Trim(); // VD: "NV02"
                if (lastMaNV.StartsWith("NV") && int.TryParse(lastMaNV.Substring(2), out int lastNum))
                {
                    // D2 giúp giữ tối thiểu 2 chữ số (03, 04... đến 10, 100 vẫn chạy tốt)
                    return $"NV{(lastNum + 1):D2}";
                }
            }
            return "NV01"; // Nếu bảng chưa có ai thì bắt đầu từ NV01
        }

        // 2. Hàm thêm Nhân Viên (Đã sửa tên cột thành MaVaiTro cho khớp với DB của bạn)
        public bool InsertNhanVien(
            string maNV,
            string hoTen,
            string gioiTinh,
            string VaiTro,
            DateTime? ngaySinh = null,
            string? soDienThoai = null,
            string? email = null,
            string? diaChi = null)
        {
            if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(hoTen) ||
                string.IsNullOrWhiteSpace(gioiTinh) || string.IsNullOrWhiteSpace(VaiTro))
            {
                return false;
            }

            string query = "INSERT INTO NHANVIEN(MaNV, HoTen, NgaySinh, GioiTinh, SoDienThoai, DiaChi, VaiTro, Email) " +
                           "VALUES(@manv, @hoten, @Dob, @sex, @sdt, @addr, @vt, @email)";

            object dbNgaySinh = ngaySinh.HasValue ? ngaySinh.Value : DBNull.Value;
            object dbSdt = string.IsNullOrWhiteSpace(soDienThoai) ? DBNull.Value : soDienThoai.Trim();
            object dbEmail = string.IsNullOrWhiteSpace(email) ? DBNull.Value : email.Trim();
            object dbDiaChi = string.IsNullOrWhiteSpace(diaChi) ? DBNull.Value : diaChi.Trim();

            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@manv", maNV.Trim()),
                new SqlParameter("@hoten", hoTen.Trim()),
                new SqlParameter("@Dob", dbNgaySinh),
                new SqlParameter("@sex", gioiTinh.Trim()),
                new SqlParameter("@sdt", dbSdt),
                new SqlParameter("@addr", dbDiaChi),
                new SqlParameter("@vt", VaiTro.Trim()),
                new SqlParameter("@email", dbEmail)
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);
            return result > 0;
        }
    }
}
