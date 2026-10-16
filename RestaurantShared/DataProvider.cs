using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection.Metadata;
using System.Text;
using System.Xml.XPath;

namespace RestaurantShared
{
    public class DataProvider
    {
        private string connectionStr = "Data Source=.;Initial Catalog=LTMCB;Integrated Security=True;Trust Server Certificate=True";
        private static readonly Lazy<DataProvider> DP = new (() => new DataProvider());

        public static DataProvider Instance => DP.Value;

        private DataProvider(){ }
        public DataTable ExecuteQuery(string query, object[] parameter = null)
        {
            DataTable data = new();

            using SqlConnection connection = new(connectionStr);

            connection.Open();

            SqlCommand cmd = new(query, connection);

            if(parameter != null)
            {
                string[] paraList = query.Split(' ');

                int i = 0;

                foreach(string item in paraList)
                {
                    if(item.Contains('@'))
                    {
                        cmd.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }

            SqlDataAdapter adapter = new(cmd);

            adapter.Fill(data);

            connection.Close();

            return data;
        }

        public int ExecuteNonQuery(string query,object[] parameter = null)
        {
            int data = 0;
            using SqlConnection connection = new(connectionStr);

            connection.Open();

            SqlCommand cmd = new(query, connection);

            if (parameter != null)
            {
                string[] paraList = query.Split(' ');

                int i = 0;

                foreach (string item in paraList)
                {
                    if (item.Contains('@'))
                    {
                        cmd.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }


            data = cmd.ExecuteNonQuery();
            connection.Close();

            return data;
        }

        public object ExecuteScalar(string query, object[] parameter = null)
        {
            object data = 0;
            using SqlConnection connection = new(connectionStr);

            connection.Open();

            SqlCommand cmd = new(query, connection);

            if (parameter != null)
            {
                string[] paraList = query.Split(' ');

                int i = 0;

                foreach (string item in paraList)
                {
                    if (item.Contains('@'))
                    {
                        cmd.Parameters.AddWithValue(item, parameter[i]);
                        i++;
                    }
                }
            }

            data = cmd.ExecuteScalar();

            connection.Close();

            return data;
        }

    }
}
