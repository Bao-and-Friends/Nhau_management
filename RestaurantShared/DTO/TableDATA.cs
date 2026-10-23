using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestaurantShared.DTO
{
    public class TableDATA
    {
        // Constructor
        public TableDATA(string maBan, string tenBan, int sucChua, string trangThai)
        {
            MaBan = maBan;
            TenBan = tenBan;
            SucChua = sucChua;
            TrangThai = trangThai;
        }
        public TableDATA(DataRow row)
        {
            MaBan = row["MaBan"].ToString()!;

            TenBan = row["TenBan"].ToString()!;

            SucChua = row["SucChua"] == DBNull.Value ? 0 : Convert.ToInt32(row["SucChua"]);

            TrangThai = row["TrangThai"].ToString()!;
        }
        // Fields
        private string maBan;
        private string tenBan;
        private int sucChua;
        private string trangThai;

        public static readonly int TableHeight = 200;
        public static readonly int TableWidth = 200;

        // Properties
        public string MaBan
        {
            get { return maBan; }
            set { maBan = value; }
        }

        public string TenBan
        {
            get { return tenBan; }
            set { tenBan = value; }
        }

        public int SucChua
        {
            get { return sucChua; }
            set { sucChua = value; }
        }

        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

      
    }
}
