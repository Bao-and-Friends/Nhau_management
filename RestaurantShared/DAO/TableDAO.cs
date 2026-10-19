using RestaurantShared.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestaurantShared.DAO
{
    public class TableDAO
    {
        private static readonly Lazy<TableDAO> tableDAO = new(() => new TableDAO());
        public static TableDAO Instance => tableDAO.Value;

        private TableDAO() { }

        public List<TableDATA> GetListTable()
        {
            List<TableDATA> listtable = new();
            string query = "select * from BAN";//bo sung query sau
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach(DataRow item in data.Rows)
            {
                listtable.Add(new TableDATA(item));
            }
            return listtable;

        }
    }
}
