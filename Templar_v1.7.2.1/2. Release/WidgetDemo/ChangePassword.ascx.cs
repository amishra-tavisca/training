using EmsClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace WidgetDemo
{
    public partial class ChangePassword : System.Web.UI.UserControl,IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Write(Session["name"].ToString() + "<br/>");
            }
            catch (Exception exception)
            {
                Response.Redirect("home");
            }

        }

        public void HideSettings()
        {
            Panel1.Visible = false;
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
            string email = Convert.ToString(Session["email"]);
            string OriginalPassword = Convert.ToString(Session["password"]);
            string NewPassword = TextBoxNewPassword.Text;
            if (OriginalPassword == TextBoxOldPassword.Text)
            {
                Employee.ChangePassword(email, NewPassword);
                Response.Write("Password successfully Changed !");
                Session["password"] = NewPassword;
            }
            else
                Response.Write("Incorrect old password");      
        }

        protected void ButtonLogout_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("home");
        }
    }
}