﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using Charity.Models;

namespace Charity.DAL
{
    public class OrganizatioEntity
    {
        string ConnectionString = @"data source =DESKTOP-375UQVA;initial catalog=SadqaAndZakat;integrated security = True";
        SqlConnection sqlConnection = null;
        SqlCommand cmd = null;
        public int Insert(organizatiomodel a)
        {
            int effectedRows = 0;
            try
            {
                sqlConnection = new SqlConnection(ConnectionString);
                string query = "insert into Organization(OrganizationName,ContactNo,Type,Address) values('" + a.OrganizationName + "','" + a.ContactNo + "','" + a.Type + "','" + a.Address + "' )";
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
