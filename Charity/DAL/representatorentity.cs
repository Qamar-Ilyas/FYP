using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Charity.Models;

namespace Charity.DAL
{
    public class representatorentity
    {
        string ConnectionString = @"data source =DESKTOP-375UQVA;initial catalog=SadqaAndZakat;integrated security = True";
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public int Insert(int rid,representatordonee u)
        {
            int effectedRows = 0;
            try
            {
                sqlConnection = new SqlConnection(ConnectionString);
                string query = "insert into Representatoradddonee(RAdid,Name,Cnic,Address,Type,Rid) values('" + u.RAdid + "','" + u.Name + "','" + u.Cnic + "','" + u.Address + "','" + u.Type + "','" + rid + "' )";
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