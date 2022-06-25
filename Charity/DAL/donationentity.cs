using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Charity.Models;

namespace Charity.DAL
{
    public class donationentity
    {
        string ConnectionString = @"data source =DESKTOP-375UQVA;initial catalog=SadqaAndZakat;integrated security = True";
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public int Insert(donation d)
        {
            int effectedRows = 0;
            try
            {
                string a = "";
                int b = 0;
                sqlConnection = new SqlConnection(ConnectionString);
                string query = "SELECT Sum (Amount), Type FROM AdminDonation GROUP BY Type";
                sqlConnection.Open();
                cmd = new SqlCommand(query, sqlConnection);
                SqlDataReader s = cmd.ExecuteReader();
                while(s.Read())
                {
                    a = s[1].ToString();
                    b = int.Parse(s[0].ToString());
                }
                s.Close();
                sqlConnection.Close();
                SqlConnection sqlConnection1 = null;
                SqlCommand cmd1 = null;
                sqlConnection = new SqlConnection(ConnectionString);
                string query1 = "Insert into DonatedAmount('"+a+ "','" + b + "')";
                sqlConnection1.Open();
                cmd1 = new SqlCommand(query1, sqlConnection1);
                cmd.ExecuteNonQuery();
                sqlConnection1.Close();
                effectedRows = cmd.ExecuteNonQuery();
                return effectedRows;
            }
            catch (Exception exp)
            {
                return effectedRows;
            }

        }
    }
}