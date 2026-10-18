using System;
using System.Collections.Generic;
using System.Text;

namespace RestaurantShared.DAO
{
    public class NhanVienDAO
    {
        private static readonly Lazy<NhanVienDAO> NvDAO = new(() => new NhanVienDAO());
        public static NhanVienDAO Instance => NvDAO.Value;
        public NhanVienDAO() { }
    }
}
