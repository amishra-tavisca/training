using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;
using EmsClasses;
namespace WidgetDemo
{
    public partial class Login : System.Web.UI.UserControl,IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.Cookies["UserName"] != null && Request.Cookies["Password"] != null)
                {
                    TextBoxUserID.Text = Request.Cookies["UserName"].Value;
                    TextBoxPassword.Attributes["value"] = Request.Cookies["Password"].Value;
                    //LoginButton_Click(null,null);
                }
            }
        }

        public void HideSettings()
        {
           // Panel1.Visible = false;
            //throw new NotImplementedException();
        }

        public new void Init(IWidgetHost host)
        {
            //throw new NotImplementedException();
        }

        public void ShowSettings()
        {
            Panel1.Visible = true;
            //throw new NotImplementedException();
        }
      
        protected void ButtonLogin_Click(object sender, EventArgs e)
        {

            if (CheckBoxRememberMe.Checked)
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(30);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(30);
            }
            else
            {
                Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
                Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);

            }
            Response.Cookies["UserName"].Value = TextBoxUserID.Text.Trim();
            Response.Cookies["Password"].Value = TextBoxPassword.Text.Trim();
            
            
            Employee employee = new Employee();

            string email = TextBoxUserID.Text;
            string password = TextBoxPassword.Text;
            var check = Employee.IsValidUser(email, password);

            if (check == true)
            {
                employee = Employee.GetEmployeeByEmail(email);
                Session["email"] = email;
                Session["password"] = password;
                string fullName = employee.FirstName + "  " + employee.LastName + "\r\n";
                Session["name"] = fullName;

                if (employee.Designation == "Hr")
                    Response.Redirect("hrpage");
                else
                    Response.Redirect("userpage");
            }
            else
                Response.Write("Wrong Id or Password");
        } 
    }
}