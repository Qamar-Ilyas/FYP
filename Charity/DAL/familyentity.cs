using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Charity.Models;

namespace Charity.DAL
{
    public class familyentity
    {
        string ConnectionString = @"data source =DESKTOP-375UQVA;initial catalog=SadqaAndZakat;integrated security = True";
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public int Insert(int did,int daid,familymodel m)
        {
            int effectedRows = 0;
            try
            {
                sqlConnection = new SqlConnection(ConnectionString);
                string query = "insert into Familydonate(Fid,Did,DAid,Date,Type,Amount) values('" + m.Fid + "','"+did+ "','" + daid + "','" + m.Date + "','" + m.Type + "','" + m.Amount + "' )";
                sqlConnection.Open();
                cmd = new SqlCommand(query, sqlConnection);
                effectedRows = cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return effectedRows;
            }
            catch (Exception exp)
            {
                return effectedRows;
            }
        }
    }
}