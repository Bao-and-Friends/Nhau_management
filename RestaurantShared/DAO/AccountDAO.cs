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
            string query = "";
           DataTable data = DataProvider.Instance.ExecuteQuery(query);
            return data.Rows.Count > 0;

        }
    }
}
