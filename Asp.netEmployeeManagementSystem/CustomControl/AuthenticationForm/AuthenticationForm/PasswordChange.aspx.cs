using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationForm
{
    public partial class PasswordChange : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session["name"].ToString()+"<br/>");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string email=Convert.ToString(Session["email"]);
            string OriginalPassword = Convert.ToString(Session["password"]);
            string NewPassword = TextBoxNewPassword.Text;
            if (OriginalPassword == TextBoxOldPassword.Text)
            {
                MemoryStream stream1 = new MemoryStream();
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(string));
                ser.WriteObject(stream1, NewPassword);
                stream1.Position = 0;
                StreamReader sr = new StreamReader(stream1);
                // Console.Write("JSON form of Person object: ");
                string d = sr.ReadToEnd();

                var client = new WebClient();
                client.Headers.Add("Content-Type", "application/json");
                var response = client.UploadString("http://localhost:53412/EmployeeManagementService.svc/employee/" + email + "/changePassword", "POST", d);
                Response.Write("Password successfully Changed !");
                Session["password"] = NewPassword;
            }
            else
                Response.Write("Incorrect old password");                 

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies.Clear();
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/Account/Login.aspx");
            
        }
    }
}