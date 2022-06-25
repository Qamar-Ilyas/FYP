using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Charity.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Charity.DAL;


namespace Charity.Controllers
{
    public class WelcomeController : Controller
    {
        string ConnectionString = @"data source =DESKTOP-375UQVA;initial catalog=SadqaAndZakat;integrated security = True";
        SqlConnection sqlConnection = null;
      
        // GET: Welcome
        public ActionResult Admin_Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Admin_Signup(signup sin,string Field)
        {
            AdminEntity autherentity = new AdminEntity();
            int effectedRows = autherentity.Insert(sin,Field);
            ViewBag.dboSucess = null;
            if (effectedRows > 0)
            {
                ViewBag.dboSucess = true;
            }
            else
            {
                ViewBag.dboSucess = false;
                ModelState.AddModelError("", "Email and Password is incorrect");
            }
            return RedirectToAction("Admin_Login", "Welcome");
            //return RedirectToAction("MyAnswers", "Auther");
            //return RedirectToAction("Admin_Login");
        }
        [HttpGet]
        public ActionResult Admin_Login()
        {
            return View();
            
        }
        [HttpPost]
        public ActionResult Admin_Login(login l,string Field)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query="select Aid,Name from Admin where Email='"+l.Email+"'and Password='"+l.Password+"'";
            SqlCommand scmd = new SqlCommand(query,sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            sdr.Read();
           
                if (sdr.HasRows)
            {
                sqlConnection.Close();
                return RedirectToAction("Admin_Dashboard", "Welcome");
            }
            else
            {
                sqlConnection.Close();
                return View();
            }
            //return View();
        }
        [HttpGet]
        public ActionResult Donor_Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Donor_Login(login l, string Field)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select Did,Name from Donor where Email='" + l.Email + "'and Password='" + l.Password + "'";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            sdr.Read();

            if (sdr.HasRows)
            {
                Session["Did"]=int.Parse(sdr["Did"].ToString());
                sqlConnection.Close();
                return RedirectToAction("Donor_Dashboard", "Welcome");
            }
            else
            {
                sqlConnection.Close();
                return View();
            }
            //return View();
        }
        [HttpGet]
        public ActionResult FieldWorker_Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult FieldWorker_Login(login l, string Field)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select Fid,Name from FieldWorker where Email='" + l.Email + "'and Password='" + l.Password + "'";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            sdr.Read();

            if (sdr.HasRows)
            {
                sqlConnection.Close();
                return RedirectToAction("FieldWorker_Dashboard", "Welcome");
            }
            else
            {
                sqlConnection.Close();
                return View();
            }
            //return View();
        }
        [HttpGet]
        public ActionResult Representator_Login()
        {
            return View();

        }
        [HttpPost]
        public ActionResult Representator_Login(login l, string Field)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select Rid,Name from Representator where Email='" + l.Email + "'and Password='" + l.Password + "'";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            sdr.Read();

            if (sdr.HasRows)
            {
                Session["Rid"] = int.Parse(sdr["Rid"].ToString());
                sqlConnection.Close();
                return RedirectToAction("Representator_Dashboard", "Welcome");
            }
            else
            {
                sqlConnection.Close();
                return View();
            }
            //return View();
        }

        public ActionResult Admin_Dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Manage_Donor()
        {
            return View();
        }

        [HttpGet]
        public ActionResult View_Donor()
        {

            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select  Did,Name,Email,Cnic,ContactNo,Status,Address,Password from Donor";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<donorsignup> alist = new List<donorsignup>();
            while (sdr.Read())
            {
                if (sdr["Status"].ToString() == "Approved")
                {
                    donorsignup a = new donorsignup();
                    a.Did = (sdr["Did"].ToString());
                    a.Name = (sdr["Name"].ToString());
                    a.Email = (sdr["Email"].ToString());
                    a.Cnic = sdr["Cnic"].ToString();
                    a.ContactNo = sdr["ContactNo"].ToString();
                    a.Status = (sdr["Status"].ToString());
                    a.Address = sdr["Address"].ToString();
                    a.Password = (sdr["Password"].ToString());
                    alist.Add(a);
                }
            }
            sqlConnection.Close();
            return View(alist);
        }
        [HttpGet]
        public ActionResult Pending_Donor()
        {

            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select  Did,Name,Email,Cnic,ContactNo,Status,Address,Password from Donor";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<donorsignup> alist = new List<donorsignup>();
            while (sdr.Read())
            {
                if (sdr["Status"].ToString() != "Approved")
                {
                    donorsignup a = new donorsignup();
                    a.Did = (sdr["Did"].ToString());
                    a.Name = (sdr["Name"].ToString());
                    a.Email = (sdr["Email"].ToString());
                    a.Cnic = sdr["Cnic"].ToString();
                    a.ContactNo = sdr["ContactNo"].ToString();
                    a.Status = (sdr["Status"].ToString());
                    a.Address = sdr["Address"].ToString();
                    a.Password = (sdr["Password"].ToString());
                    alist.Add(a);
                }
            }
            sqlConnection.Close();
            return View(alist);
        }

        [HttpGet]

        public ActionResult Approve(string id)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "Update Donor set Status='Approved' where Did='" + id + "'";
            SqlCommand scmd = new SqlCommand(query, sqlCon);
            scmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToAction("Pending_Donor");
        }

        [HttpGet]

        public ActionResult Dismiss(string id)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "Delete from Donor where Did='" + id + "'";
            SqlCommand scmd = new SqlCommand(query, sqlCon);
            scmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToAction("Pending_Donor");
        }
        [HttpGet]

        public ActionResult DeleteDonor(string id)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "Delete from Donor where Did='" + id + "'";
            SqlCommand scmd = new SqlCommand(query, sqlCon);
            scmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToAction("View_Donor");
        }
        private donorsignup donorDetail(string id)
        {

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "select Did,Name,Email,Cnic,ContactNo,Address,Status,Password from Donor where Did='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            SqlDataReader sdr = cmd.ExecuteReader();

            sdr.Read();

            donorsignup a = new donorsignup();
            a.Did = sdr["Did"].ToString();
            a.Name = sdr["Name"].ToString();
            a.Email = sdr["Email"].ToString();
            a.Cnic = sdr["Cnic"].ToString();
            a.ContactNo = sdr["ContactNo"].ToString();
            a.Status = sdr["Status"].ToString();
            a.Address = sdr["Address"].ToString();
            a.Password = sdr["Password"].ToString();


            sdr.Close();
            sqlCon.Close();

            return a;
        }

        [HttpGet]
        public ActionResult Edits(string id)
        {
            donorsignup a = new donorsignup();
            a = donorDetail(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult Edits(signup a)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "update Donor  set Name='" + a.Name + "', Email='" + a.Email + "',Cnic='" + a.Cnic + "',ContactNo='" + a.ContactNo + "',Address='" + a.Address + "',Status='" + a.Status + "',Password='" + a.Password + "' where Did= '" + a.Aid + "'";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToAction("View_Donor");

        }
        [HttpGet]
        public ActionResult Manage_Donee()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ViewDonor_Donee()
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select  DAid,Name,Cnic,Address,Need,Did from Donoradddonee";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<DonorAddDonee> alist = new List<DonorAddDonee>();
            while (sdr.Read())
            {

                DonorAddDonee a = new DonorAddDonee();
                a.DAid = (sdr["DAid"].ToString());
                a.Name = (sdr["Name"].ToString());
                a.Cnic = sdr["Cnic"].ToString();
              
                a.Address = sdr["Address"].ToString();
                a.Need = sdr["Need"].ToString();
                a.Did = (sdr["Did"].ToString());
                alist.Add(a);

            }
            sqlConnection.Close();
            return View(alist);
        }
        [HttpGet]
        public ActionResult ViewRepresentator_Donee()
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select  RAdid,Name,Cnic,Address,Type,Rid from Representatoradddonee";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<representatordonee> alist = new List<representatordonee>();
            while (sdr.Read())
            {
                
                    representatordonee a = new representatordonee();
                    a.RAdid = (sdr["RAdid"].ToString());
                    a.Name = (sdr["Name"].ToString());
                    a.Cnic = sdr["Cnic"].ToString();
                  
                    a.Address = sdr["Address"].ToString();
                    a.Type = sdr["Type"].ToString();
                    a.Rid = (sdr["Rid"].ToString());
                    alist.Add(a);
                
            }
            sqlConnection.Close();
            return View(alist);
        }


        [HttpGet]
        public ActionResult Manage_FieldWorker()
        {
            return View();
        }
       
        [HttpGet]
        public ActionResult Pending_FieldWorker()
        {

            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select  Fid,Name,Email,Cnic,ContactNo,Status,Address,Password from FieldWorker";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<signup> alist = new List<signup>();
            while (sdr.Read())
            {
                if (sdr["Status"].ToString() != "Approved")
                {
                    signup a = new signup();
                    a.Aid = (sdr["Fid"].ToString());
                    a.Name = (sdr["Name"].ToString());
                    a.Email = (sdr["Email"].ToString());
                    a.Cnic = sdr["Cnic"].ToString();
                    a.ContactNo = sdr["ContactNo"].ToString();
                    a.Status = (sdr["Status"].ToString());
                    a.Address = sdr["Address"].ToString();
                    a.Password = (sdr["Password"].ToString());
                    alist.Add(a);
                }
            }
            sqlConnection.Close();
            return View(alist);
        }
        [HttpGet]
        public ActionResult View_FieldWorker()
        {

            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select  Fid,Name,Email,Cnic,ContactNo,Status,Address,Password from FieldWorker";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<signup> alist = new List<signup>();
            while (sdr.Read())
            {
                if (sdr["Status"].ToString() == "Approved")
                {
                    signup a = new signup();
                    a.Aid = (sdr["Fid"].ToString());
                    a.Name = (sdr["Name"].ToString());
                    a.Email = (sdr["Email"].ToString());
                    a.Cnic = sdr["Cnic"].ToString();
                    a.ContactNo = sdr["ContactNo"].ToString();
                    a.Status = (sdr["Status"].ToString());
                    a.Address = sdr["Address"].ToString();
                    a.Password = (sdr["Password"].ToString());
                    alist.Add(a);
                }
            }
            sqlConnection.Close();
            return View(alist);
        }
        [HttpGet]

        public ActionResult Delete(string id)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "Delete from FieldWorker where Fid='" + id + "'";
            SqlCommand scmd = new SqlCommand(query, sqlCon);
            scmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToAction("View_FieldWorker");
        }
        private signup signupDetail(string id)
        {

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "select Fid,Name,Email,Cnic,ContactNo,Address,Status,Password from FieldWorker where Fid='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            SqlDataReader sdr = cmd.ExecuteReader();

            sdr.Read();

            signup a = new signup();
            a.Aid = sdr["Fid"].ToString();
            a.Name = sdr["Name"].ToString();
            a.Email = sdr["Email"].ToString();
            a.Cnic = sdr["Cnic"].ToString();
            a.ContactNo = sdr["ContactNo"].ToString();
            a.Status = sdr["Status"].ToString();
            a.Address = sdr["Address"].ToString();
            a.Password = sdr["Password"].ToString();


            sdr.Close();
            sqlCon.Close();

            return a;
        }

        [HttpGet]
        public ActionResult Edit(string id)
        {
            signup a = new signup();
            a = signupDetail(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult Edit(signup a)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "update FieldWorker  set Name='" + a.Name + "', Email='" + a.Email + "',Cnic='" + a.Cnic + "',ContactNo='" + a.ContactNo + "',Address='" + a.Address + "',Status='" + a.Status + "',Password='" + a.Password + "' where Fid= '" + a.Aid + "'";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToAction("View_FieldWorker");

        }
        [HttpGet]

        public ActionResult Approved(string id)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "Update FieldWorker set Status='Approved' where Fid='" + id + "'";
            SqlCommand scmd = new SqlCommand(query, sqlCon);
            scmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToAction("Pending_FieldWorker");
        }
        [HttpGet]

        public ActionResult Dismissed(string id)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "Delete from FieldWorker where Fid='" + id + "'";
            SqlCommand scmd = new SqlCommand(query, sqlCon);
            scmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToAction("Pending_FieldWorker");
        }

        [HttpGet]
        public ActionResult Manage_Representator()
        {
            return View();
        }
        [HttpGet]
        public ActionResult View_Representator()
        {

            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select  Rid,Name,Email,Cnic,ContactNo,Status,Address,Password from Representator";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<signup> alist = new List<signup>();
            while (sdr.Read())
            {
                if (sdr["Status"].ToString() == "Approved")
                {
                    signup a = new signup();
                    a.Aid = (sdr["Rid"].ToString());
                    a.Name = (sdr["Name"].ToString());
                    a.Email = (sdr["Email"].ToString());
                    a.Cnic = sdr["Cnic"].ToString();
                    a.ContactNo = sdr["ContactNo"].ToString();
                    a.Status = (sdr["Status"].ToString());
                    a.Address = sdr["Address"].ToString();
                    a.Password = (sdr["Password"].ToString());
                    alist.Add(a);
                }
            }
            sqlConnection.Close();
            return View(alist);
        }
        [HttpGet]
        public ActionResult Pending_Representator()
        {

            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select  Rid,Name,Email,Cnic,ContactNo,Status,Address,Password from Representator";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<signup> alist = new List<signup>();
            while (sdr.Read())
            {
                if (sdr["Status"].ToString() != "Approved")
                {
                    signup a = new signup();
                    a.Aid = (sdr["Rid"].ToString());
                    a.Name = (sdr["Name"].ToString());
                    a.Email = (sdr["Email"].ToString());
                    a.Cnic = sdr["Cnic"].ToString();
                    a.ContactNo = sdr["ContactNo"].ToString();
                    a.Status = (sdr["Status"].ToString());
                    a.Address = sdr["Address"].ToString();
                    a.Password = (sdr["Password"].ToString());
                    alist.Add(a);
                }
            }
            sqlConnection.Close();
            return View(alist);
        }
        [HttpGet]

        public ActionResult Approveds(string id)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "Update Representator set Status='Approved' where Rid='" + id + "'";
            SqlCommand scmd = new SqlCommand(query, sqlCon);
            scmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToAction("Pending_Representator");
        }
        [HttpGet]

        public ActionResult Dismisse(string id)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "Delete from Representator where Rid='" + id + "'";
            SqlCommand scmd = new SqlCommand(query, sqlCon);
            scmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToAction("Pending_Representator");
        }
        [HttpGet]

        public ActionResult Delete_Representator(string id)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "Delete from Representator where Rid='" + id + "'";
            SqlCommand scmd = new SqlCommand(query, sqlCon);
            scmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToAction("View_Representator");
        }
        private signup signupDetails(string id)
        {

            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "select Rid,Name,Email,Cnic,ContactNo,Address,Status,Password from Representator where Rid='" + id + "'";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            SqlDataReader sdr = cmd.ExecuteReader();

            sdr.Read();

            signup a = new signup();
            a.Aid = sdr["Rid"].ToString();
            a.Name = sdr["Name"].ToString();
            a.Email = sdr["Email"].ToString();
            a.Cnic = sdr["Cnic"].ToString();
            a.ContactNo = sdr["ContactNo"].ToString();
            a.Status = sdr["Status"].ToString();
            a.Address = sdr["Address"].ToString();
            a.Password = sdr["Password"].ToString();


            sdr.Close();
            sqlCon.Close();

            return a;
        }

        [HttpGet]
        public ActionResult Edit_Representator(string id)
        {
            signup a = new signup();
            a = signupDetail(id);
            return View(a);
        }

        [HttpPost]
        public ActionResult Edit_Representator(signup a)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "update Representator  set Name='" + a.Name + "', Email='" + a.Email + "',Cnic='" + a.Cnic + "',ContactNo='" + a.ContactNo + "',Address='" + a.Address + "',Status='" + a.Status + "',Password='" + a.Password + "' where Rid= '" + a.Aid + "'";
            SqlCommand cmd = new SqlCommand(query, sqlCon);
            cmd.ExecuteNonQuery();
            sqlCon.Close();
            return RedirectToAction("View_Representator");

        }
        [HttpGet]
        public ActionResult Manage_Organization()
        {
            return View();
        }
        
        [HttpGet]
        public ActionResult Assign_FieldWorker(signup s)
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select Did,Name,Email,Cnic,ContactNo,Address,Status,Password from Donor";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<donorsignup> alist = new List<donorsignup>();
            while (sdr.Read())
            {
                donorsignup a = new donorsignup();
                a.Did= (sdr["Did"].ToString());
                a.Name = (sdr["Name"].ToString());
                a.Email = sdr["Email"].ToString();
                a.Cnic = sdr["Cnic"].ToString();
                a.ContactNo = sdr["ContactNo"].ToString();
                a.Address = sdr["Address"].ToString();
                a.Status = sdr["Status"].ToString();
                a.Password = sdr["Password"].ToString();
                //a.Assign = sdr["Assign"].ToString();

                alist.Add(a);
            }
            sqlConnection.Close();
            return View(alist);

            

        }
        [HttpGet]
        public ActionResult Assign1(string Address,int Did,string Name)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "Update Donor set Assign='Assign' where Address='" + Address + "'";
            SqlCommand scmd = new SqlCommand(query, sqlCon);
            scmd.ExecuteNonQuery();
            sqlCon.Close();
            FieldWorkersid(Address,Did,Name);
            return RedirectToAction("Assign_FieldWorker");
        }
        public void FieldWorkersid(string Address, int Did, string Name)
        {
            SqlConnection sqlCon = new SqlConnection(ConnectionString);
            sqlCon.Open();
            string query = "Update FieldWorker set Did='"+Did+"' where Address='" + Address + "' and Name='"+Name+"'";
            SqlCommand scmd = new SqlCommand(query, sqlCon);
            scmd.ExecuteNonQuery();
            sqlCon.Close();
            
        }
        [HttpGet]
        public ActionResult FieldWorker_Dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Representator_Dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Representator_AddDonee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Representator_AddDonee(representatordonee uuu)
        {
            representatorentity autherentity = new representatorentity();
            int rid = (int)Session["Rid"];
            int effectedRows = autherentity.Insert(rid,uuu);
            ViewBag.dboSucess = null;
            if (effectedRows > 0)
            {
                ViewBag.dboSucess = true;
            }
            else
            {
                ViewBag.dboSucess = false;
                ModelState.AddModelError("", "Email and Password is incorrect");
            }
            //return RedirectToAction("Admin_Login", "Welcome");
            //return RedirectToAction("MyAnswers", "Auther");
            //return RedirectToAction("Admin_Login");
            return View();
        }
        
        [HttpGet]
        public ActionResult ViewDonee()
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select  RAdid,Name,Cnic,Address,Type,Rid from Representatoradddonee";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<representatordonee> alist = new List<representatordonee>();
            while (sdr.Read())
            {
                representatordonee a = new representatordonee();
                a.RAdid = (sdr["RAdid"].ToString());
                a.Name = (sdr["Name"].ToString());
                a.Cnic = sdr["Cnic"].ToString();
         
                a.Address = sdr["Address"].ToString();
                a.Type = sdr["Type"].ToString();
                a.Rid = (sdr["Rid"].ToString());
                alist.Add(a);
            }
            sqlConnection.Close();
            return View(alist);

        }
        
        //[HttpGet]
        //public ActionResult Organization()
        //{
        //    return View();
        //}
        //[HttpPost]
        //public ActionResult Organization(organizatiomodel ain)
        //{
        //    OrganizatioEntity autherentity = new OrganizatioEntity();
        //    int effectedRows = autherentity.Insert(ain);
        //    ViewBag.dboSucess = null;
        //    if (effectedRows > 0)
        //    {
        //        ViewBag.dboSucess = true;
        //    }
        //    else
        //    {
        //        ViewBag.dboSucess = false;
        //        //ModelState.AddModelError("", "Email and Password is incorrect");
        //    }
        //    //return RedirectToAction("Admin_Login", "Welcome");
        //    return View();
        //}
        [HttpGet]
        public ActionResult Donate()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ShowDonorDonee()
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select DAid,Name,Cnic from Donoradddonee";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<DonorAddDonee> alist = new List<DonorAddDonee>();
            while (sdr.Read())
            {
                DonorAddDonee a = new DonorAddDonee();
                a.DAid = (sdr["DAid"].ToString());
                a.Name = (sdr["Name"].ToString());
                a.Cnic = sdr["Cnic"].ToString();
              
                alist.Add(a);
            }
            sqlConnection.Close();
            return View(alist);

        }
        [HttpGet]
        public ActionResult family(int DAid)
        {
            Session["daid"] = DAid;
            return View();
        }
        [HttpPost]
        public ActionResult family(familymodel f)
        {

            familyentity autherentity = new familyentity();
            int did = (int)Session["Did"];
            int daid = (int)Session["DAid"];
            int effectedRows = autherentity.Insert(did,daid, f);
            ViewBag.dboSucess = null;
            if (effectedRows > 0)
            {
                ViewBag.dboSucess = true;
                
            }
            else
            {
                ViewBag.dboSucess = false;
                //ModelState.AddModelError("", "Email and Password is incorrect");
            }
            return View();
        }
       [HttpGet]
       public ActionResult Other()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Other(Amountdonation sss)
        {
            var userDt = DateTime.Now.ToString("MM/dd/yyyy hh:mm tt");
            var nwDt = DateTime.Now.ToShortDateString();
            ViewData["nowDt"] = nwDt;
            amountentity autherentity = new amountentity();
            int did = (int)Session["Did"];
            int effectedRows = autherentity.Insert(did,sss);
            ViewBag.dboSucess = null;
            if (effectedRows > 0)
            {
                ViewBag.dboSucess = true;
            }
            else
            {
                ViewBag.dboSucess = false;
                //ModelState.AddModelError("", "Email and Password is incorrect");
            }
            return View();
           
        }

        [HttpGet]
        public ActionResult ViewDonation()
        {
            
                return View();
        }
        [HttpGet]
        public ActionResult Familys()
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select Fid,Did,DAid,Date,Type,Amount from Familydonate";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<familymodel> alist = new List<familymodel>();
            while (sdr.Read())
            {
                familymodel a = new familymodel();
                a.Fid = (sdr["Fid"].ToString());
                a.Did = (sdr["Did"].ToString());
                a.DAid = (sdr["DAid"].ToString());
                a.Date = sdr["Date"].ToString();
                a.Type = sdr["Type"].ToString();
                a.Amount = sdr["Amount"].ToString();
                alist.Add(a);
            }
            sqlConnection.Close();
            return View(alist);

        }
        [HttpGet]
        
        public ActionResult others()
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select ADonation,Did,Date,Type,Amount from AdminDonation";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<Amountdonation> alist = new List<Amountdonation>();
            while (sdr.Read())
            {
                Amountdonation a = new Amountdonation();
                a.ADonation = int.Parse(sdr["ADonation"].ToString());
                a.Did = int.Parse(sdr["Did"].ToString());
                a.Date = sdr["Date"].ToString();
                a.Type = sdr["Type"].ToString();
                a.Amount = int.Parse(sdr["Amount"].ToString());
                alist.Add(a);
            }
            sqlConnection.Close();
            return View(alist);

        }

        [HttpGet]
        public ActionResult DonationAmount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DonationAmount(donation d)
        {
            donationentity autherentity = new donationentity();
            int effectedRows = autherentity.Insert(d);
            ViewBag.dboSucess = null;
            if (effectedRows > 0)
            {
                ViewBag.dboSucess = true;
            }
            else
            {
                ViewBag.dboSucess = false;
                //ModelState.AddModelError("", "Email and Password is incorrect");
            }
            return View();
        }


        //[HttpGet]
        //private List<Donationmodel> DonationRecords()
        //{
        //    List<Donationmodel> dlist = new List<Donationmodel>();
        //    sqlConnection.Open();
        //    string query = "select Name,Cnic,Type,Amount from Donation";
        //    SqlCommand cmd = new SqlCommand(query, sqlConnection);
        //    SqlDataReader sdr = cmd.ExecuteReader();
        //    while (sdr.Read())
        //    {
        //        Donationmodel d = new Donationmodel();
        //        d.Name = sdr["Name"].ToString();
        //        d.Cnic = sdr["Cnic"].ToString();
        //        d.Type = sdr["Type"].ToString();
        //        d.Amount = sdr["Amount"].ToString();
        //        dlist.Add(d);
        //    }
        //    sdr.Close();
        //    sqlConnection.close();

        //    return dlist;
        //}
        //public ActionResult ViewDonation()
        //{
        //    return View(Donation());
        //}
        //[HttpPost]
        //public ActionResult ViewDonation(Donationmodel donationmodel)
        //{
        //    return View("Donation");

        //}
        [HttpGet]
        public ActionResult Donor_Dashboard()
        {
            return View();
        }
        [HttpGet]
        public ActionResult AddDonee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDonee(DonorAddDonee aaa)
        {
            DonoradddoneeEntity autherentity = new DonoradddoneeEntity();
            int did = (int)Session["Did"];
            int effectedRows = autherentity.Insert(did,aaa);
            ViewBag.dboSucess = null;
            if (effectedRows > 0)
            {
                ViewBag.dboSucess = true;
            }
            else
            {
                ViewBag.dboSucess = false;
                //ModelState.AddModelError("", "Email and Password is incorrect");
            }
            return View();

        }
        [HttpGet]
        public ActionResult ViewDonorDonee()
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select  RAdid,Name,Cnic,Address,Rid from Representatoradddonee";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<representatordonee> alist = new List<representatordonee>();
            while (sdr.Read())
            {
                representatordonee a = new representatordonee();
                a.RAdid = (sdr["RAdid"].ToString());
                a.Name = (sdr["Name"].ToString());
                a.Cnic = sdr["Cnic"].ToString();
               
                a.Address = sdr["Address"].ToString();
                a.Rid = (sdr["Rid"].ToString());
                alist.Add(a);
            }
            sqlConnection.Close();
            return View(alist);



        }


        [HttpGet]
        public ActionResult MyDonation()
        {
            sqlConnection = new SqlConnection(ConnectionString);
            sqlConnection.Open();
            string query = "select Fid,Did,DAid,Date,Type,Amount from Familydonate";
            SqlCommand scmd = new SqlCommand(query, sqlConnection);
            SqlDataReader sdr = scmd.ExecuteReader();
            List<familymodel> alist = new List<familymodel>();
            while (sdr.Read())
            {
                familymodel a = new familymodel();
                a.Fid = (sdr["Fid"].ToString());
                a.Did = (sdr["Did"].ToString());
                a.DAid = (sdr["DAid"].ToString());
                a.Date = (sdr["Date"].ToString());
                a.Type = (sdr["Type"].ToString());
                a.Amount = (sdr["Amount"].ToString());
                alist.Add(a);
            }
            sqlConnection.Close();
            return View(alist);

        }
       
        [HttpGet]
        public ActionResult Calculate_Zakat()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Calculate_Zakat(calculatemodel p)
        {
            int gold = int.Parse(p.GoldValue.ToString());
            int silver = int.Parse(p.SilverValue.ToString());
            int cash = int.Parse(p.CashHand.ToString());
            int bussiness = int.Parse(p.BussinessAccounts.ToString());
            int others = int.Parse(p.Others.ToString());
            int zakat = int.Parse(p.YourZakat.ToString());
            double result=0;
            result = (gold + silver + cash + bussiness + others) * 0.025;
            double a = result;
            ViewBag.a = a;
            return View();
        }
     
      
       
           

    }
}

