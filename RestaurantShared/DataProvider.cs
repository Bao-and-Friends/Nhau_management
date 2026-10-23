using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Xml.XPath;

namespace RestaurantShared
{
    public class DataProvider
    {
        private string connectionStr = @"Data Source=.\SQLEXPRESS;Initial Catalog=QuanLyQuanNhau;Integrated Security=True;Trust Server Certificate=True";
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
            int data = 0;
            using SqlConnection connection = new(connectionStr);

            connection.Open();

            using SqlCommand cmd = new(query, connection);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }


            data = cmd.ExecuteNonQuery();
            connection.Close();

            return data;
        }

        public object ExecuteScalar(string query, params SqlParameter[] parameters)
        {
            object data = 0;
            using SqlConnection connection = new(connectionStr);

            connection.Open();

            using SqlCommand cmd = new(query, connection);

            if (parameters != null)
            {
                cmd.Parameters.AddRange(parameters);
            }
            data = cmd.ExecuteScalar();

            connection.Close();

            return data;
        }

    }
}
