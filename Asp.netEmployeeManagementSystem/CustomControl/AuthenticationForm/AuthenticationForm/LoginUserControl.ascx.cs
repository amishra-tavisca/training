using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Net;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using AuthenticationForm.Model;
using System.Data.SqlClient;
using System.Data;
namespace AuthenticationForm
{
    public partial class LoginUserControl : System.Web.UI.UserControl
    {

       
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    UsernameTextbox.Text = Request.Cookies["UserName"].Value;
                    PasswordTextbox.Attributes["value"] = Request.Cookies["Password"].Value;
                    //LoginButton_Click(null,null);
                }
            }


        }
        protected void LoginButton_Click(object sender, EventArgs e)
        {

            if (CheckBoxRemember.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            }
            Response.Cookies["UserName"].Value = UsernameTextbox.Text.Trim();
            Response.Cookies["Password"].Value = PasswordTextbox.Text.Trim();
            

            Employee employee = new Employee();
           
            string email = UsernameTextbox.Text;
            string password = PasswordTextbox.Text;

            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var response = client.DownloadString("http://localhost:53412/EmployeeService.svc/employee/" + email + "/" + password + "/IsValid"); 
            var check= Serializer.Deserialize<bool>(response);
            
            if (check==true)
            {
               
                var response1 = client.DownloadString("http://localhost:53412/EmployeeService.svc/employeeEmail/" + email );
                employee = Serializer.Deserialize<Employee>(response1);
                Session["email"]=email;
                Session["password"] = password;
                string fullName = employee.FirstName +"  " +employee.LastName+"\r\n";
                Session["name"] = fullName;
               
                if (employee.Designation == "Hr")
                    Response.Redirect("~/HRPage.aspx");
                else
                    Response.Redirect("~/UsersPage.aspx");
            }
            else
               Response.Write("Wrong Id or Password");


           
            

        }
        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}