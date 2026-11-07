using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace RestaurantShared
{
    public class DataProvider
    {
        private string connectionStr = "Data Source=.;Initial Catalog=QuanLyQuanNhau;Integrated Security=True;Trust Server Certificate=True";
        private static readonly Lazy<DataProvider> DP = new(() => new DataProvider());

        public static DataProvider Instance => DP.Value;

        private DataProvider() { }
        public DataTable ExecuteQuery(string query, params SqlParameter[] parameters)
        {
            DataTable data = new();

            using SqlConnection connection = new(connectionStr);


            using SqlCommand cmd = new(query, connection);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }

            using SqlDataAdapter adapter = new(cmd);

            adapter.Fill(data);


            return data;
        }

        public int ExecuteNonQuery(string query, params SqlParameter[] parameters)
        {
            using SqlConnection connection = new(connectionStr);

            connection.Open();

            using SqlCommand cmd = new(query, connection);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }


            int data = cmd.ExecuteNonQuery();
            return data;
        }

        public object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            using SqlConnection connection = new(connectionStr);

            connection.Open();

            using SqlCommand cmd = new(query, connection);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            object data = cmd.ExecuteScalar();
            return data;
        }

    }
}
