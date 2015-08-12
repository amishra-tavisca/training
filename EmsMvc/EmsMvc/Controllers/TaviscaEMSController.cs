using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmsMvc.Models;
using System.Net;
using System.IO;
using System.Runtime.Serialization.Json;
using EmsClasses;
using PagedList;
using PagedList.Mvc;

namespace EmsMvc.Controllers
{
    public class TaviscaEMSController : Controller
    {
        
        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult GotoLogin()
        {
            ViewBag.Title = "Login Page";
            ViewData["message"] = TempData["message"];
            TempData["message"] = "";

            return View();
        }

       
        public ActionResult Authenticate(string UsernameTextbox, string PasswordTextbox)
        {
           
            Employee employee = new Employee();
            string email = UsernameTextbox;
            string password = PasswordTextbox;
            var check = Employee.IsValidUser(email, password);
            if (check == true)
            {
                employee = Employee.GetEmployeeByEmail(email);
                Session["email"] = email;
                Session["password"] = password;
                string fullName = employee.FirstName + "  " + employee.LastName + "\r\n";
                Session["name"] = fullName;
                if (employee.Designation == "Hr")
                    return View("HrPage");
                else
                    return RedirectToAction("GotoUserPage");
            }
            else
            TempData["message"] = "Oops ! wrong email or password. Re-enter again";
            return RedirectToAction("GotoLogin");
        }

      
        public ActionResult AddEmployee()
        {

            ViewData["message"] = TempData["message"];
            TempData["message"]="";
            return View();
        }

        
        public ActionResult SaveEmployee(Employee employee)
        {
            var response = Employee.AddEmployee(employee);
            if (response != null)          
                TempData["message"] = "Employee Added Successfully !";
            else
                TempData["message"] = "Sorry ! could't add employee";
            return RedirectToAction("AddEmployee");
        }

        
        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies.Clear();
            return RedirectToAction("GotoLogin");
        }

        
        public ActionResult AddRemark()
        {
            ViewData["message"] = TempData["message"];
            TempData["message"] = "";
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            var employeeList = Employee.GetAllEmployee();
            for (int i = 0; i < employeeList.Count(); i++)
            {
                Employee tempEmployee = employeeList.ElementAt(i);
                dictionary.Add(tempEmployee.Id.ToString(), tempEmployee.Id.ToString() + " " + tempEmployee.FirstName.ToString().Trim() + " " + tempEmployee.LastName.ToString().Trim());
            }
            ViewBag.dictionaryTest = dictionary;
            return View();
        }

        
        public ActionResult SaveRemark(string test, string RemarkTextbox)
        {
            Remark remark = new Remark();
            remark.Text = RemarkTextbox;
            remark.CreateTimeStamp = DateTime.UtcNow;
            Remark.AddRemark(remark, test);
            TempData["message"] = "Remark Added Successfully !";
            return RedirectToAction("AddRemark");
        }

    
        public ActionResult ChangePassword()
        {

            ViewData["message"] = TempData["message"];
            TempData["message"] = "";
            return View();
        }

        
        public ActionResult SaveChangedPassword(LocalPasswordModel password)
        {   
            string email = Convert.ToString(Session["email"]);
            string OriginalPassword = Convert.ToString(Session["password"]);
            string NewPassword =password.NewPassword;
            if(password.NewPassword!=password.ConfirmPassword)
                TempData["message"] = "Oops ! Confirm password did not matched New password. Re-enter all fields carefull";
            else if (OriginalPassword == password.OldPassword)
            {               
                Employee.ChangePassword(email, NewPassword);
                TempData["message"] = "Password Changed Successfully !";
                Session["password"] = NewPassword;
            }
            else
                TempData["message"] = " Oops ! You entered incorrect value for current password. Re-enter all fields carefull";
                return RedirectToAction("ChangePassword");
        }

       
        public ActionResult GotoUserPage(int? page)
        {  
            Employee employee = new Employee();
            employee = Employee.GetEmployeeByEmail(Session["email"].ToString());
            ViewData["message"] = TempData["message"];
            TempData["message"] = "";
            return View("UserPage", employee.Remarks.ToPagedList(page ?? 1, 2));
        }

    }
}
 