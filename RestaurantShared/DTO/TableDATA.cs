using System;
using System.Data;

namespace RestaurantShared.DTO
{
    public enum TableStatus
    {
        TRONG,
        CO_KHACH,
        DA_DAT,
        CHO_DON
    }
    public class TableDATA
    {
       

        public TableDATA()
        {
        }

        public TableDATA(string maBan, string tenBan, int sucChua, TableStatus trangThai)
        {
            MaBan = maBan;
            TenBan = tenBan;
            SucChua = sucChua;
            TrangThai = trangThai;
        }

        public TableDATA(DataRow row)
        {
            MaBan = row["MaBan"] == DBNull.Value ? string.Empty : row["MaBan"].ToString()!;
            TenBan = row["TenBan"] == DBNull.Value ? string.Empty : row["TenBan"].ToString()!;
            SucChua = row["SucChua"] == DBNull.Value ? 0 : Convert.ToInt32(row["SucChua"]);
            TrangThai = row["TrangThai"] == DBNull.Value ? TableStatus.TRONG : (TableStatus)Convert.ToInt32(row["TrangThai"]);
        }

        public string MaBan { get; set; } = string.Empty;
        public string TenBan { get; set; } = string.Empty;
        public int SucChua { get; set; } = 0;
        public TableStatus TrangThai { get; set; } = TableStatus.TRONG;
    }
}