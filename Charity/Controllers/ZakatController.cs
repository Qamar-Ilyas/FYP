//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Charity.Models;
//using System.Data;
//using System.Data.SqlClient;


//namespace Charity.Controllers
//{
//    public class ZakatController : Controller
//    {
//        string connectionstring = @"Data Source=DESKTOP-375UQVA;Initial Catalog=SadqaAndZakat;Integrated Security=True";
//        [HttpGet]
//        public ActionResult Index()
//        {
//            DataTable dtblUsers = new DataTable();
//            using (SqlConnection sqlCon = new SqlConnection(connectionstring))
//            {
//                sqlCon.Open();
//                SqlDataAdapter sqlDa = new SqlDataAdapter("SELECT * FROM Users", sqlCon);
//                sqlDa.Fill(dtblUsers);
//            }
//            return View(dtblUsers);
//        }

//        [HttpGet]

//        public ActionResult Delete(string id)
//        {
//            SqlConnection sqlCon = new SqlConnection(connectionstring);
//            sqlCon.Open();
//            string query = "Delete from Users where Uid='" + id + "'";
//            SqlCommand scmd = new SqlCommand(query,sqlCon);
//            scmd.ExecuteNonQuery();
//            sqlCon.Close();
//            return RedirectToAction("Index");
//        }

//        private signup signupDetail(string id)
//        {

//            SqlConnection sqlCon = new SqlConnection(connectionstring);
//            sqlCon.Open();
//            string query = "select Uid,Name,Email,Cnic,ContactNo,Address,Password from Users where Uid='" + id + "'";
//            SqlCommand cmd = new SqlCommand(query, sqlCon);
//            SqlDataReader sdr = cmd.ExecuteReader();

//            sdr.Read();

//            signup a = new signup();
//            a.Aid = sdr["Uid"].ToString();
//            a.Name = sdr["Name"].ToString();
//            a.Email = sdr["Email"].ToString();
//            a.Cnic = sdr["Cnic"].ToString();
//            a.ContactNo = sdr["ContactNo"].ToString();
//            a.Address = sdr["Address"].ToString();
//            a.Password = sdr["Password"].ToString();


//            sdr.Close();
//            sqlCon.Close();

//            return a;
//        }

//        [HttpGet]
//        public ActionResult Edit(string id)
//        {
//            signup a = new signup();
//            a = signupDetail(id);
//            return View(a);
//        }

//        [HttpPost]
//        public ActionResult Edit(signup a)
//        {
//            SqlConnection sqlCon = new SqlConnection(connectionstring);
//            sqlCon.Open();
//            string query = "update Users  set Name='" + a.Name + "', Email='" + a.Email + "',Cnic='" + a.Cnic + "',ContactNo='" + a.ContactNo + "',Address='" + a.Address + "',Password='" + a.Password + "' where Uid= '" + a.Uid + "'";
//            SqlCommand cmd = new SqlCommand(query, sqlCon);
//            cmd.ExecuteNonQuery();
//            sqlCon.Close();
//            return RedirectToAction("Index");

//        }


//        [HttpGet]
//        public ActionResult Create()
//        {
//            return View("new CreateModel");
//        }

//        // POST: Zakat/Create
//        [HttpPost]
//        public ActionResult Create(CreateModel createModel)
//        {
//            using (SqlConnection sqlCon = new SqlConnection(connectionstring))
//            {
//                sqlCon.Open();
//                string query = "INSERT INTO USERS VALUES(@Name,@Email,@Cnic,@ContactNo,@Address,@Password)";
//                SqlCommand sqlCmd = new SqlCommand(query, sqlCon);
//                sqlCmd.Parameters.AddWithValue("@Name", createModel.Name);
//                sqlCmd.Parameters.AddWithValue("@Email", createModel.Email);
//                sqlCmd.Parameters.AddWithValue("@Cnic", createModel.Cnic);
//                sqlCmd.Parameters.AddWithValue("@ContactNo", createModel.ContactNo);
//                sqlCmd.Parameters.AddWithValue("@Address", createModel.Address);
//                sqlCmd.Parameters.AddWithValue("@Password", createModel.Paasword);
//                sqlCmd.ExecuteNonQuery();
//            }
//            return RedirectToAction("Index");
//        }
//    }
//}


