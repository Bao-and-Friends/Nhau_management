using BCrypt.Net;
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

        public string Login(string username,string password)
        {
            string query = $"select MatKhau,MaNV from TAIKHOAN where TenDangNhap = @username";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new SqlParameter("@username", username));
            if(data.Rows.Count >0)
            {
                string HashPwd = data.Rows[0]["MatKhau"].ToString()!;
                bool isCorrect = BCrypt.Net.BCrypt.Verify(password,HashPwd);
                if(isCorrect)
                {
                    return data.Rows[0]["MaNV"].ToString()!;
                }

            }
            return "";
        }
        
    }
}
