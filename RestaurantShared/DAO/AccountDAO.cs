using Microsoft.Data.SqlClient;
using RestaurantShared.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Runtime.Intrinsics.Arm;
using System.Text;

namespace RestaurantShared.DAO
{
    public class AccountDAO
    {
        private static readonly Lazy<AccountDAO> AcDAO = new(()=>new AccountDAO());
        public static AccountDAO Instance => AcDAO.Value;
        private AccountDAO() { }

        public bool Login(string username,string password)
        {
            string query = $"select MaTaiKhoan from TAIKHOAN where TenDangNhap = @username and MatKhau = @password";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new("@username", username),new("@password", password));
            return data.Rows.Count == 1;
        }
        
    }
}
