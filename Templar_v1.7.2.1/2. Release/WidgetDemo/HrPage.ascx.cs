using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace WidgetDemo
{
    public partial class HrPage : System.Web.UI.UserControl,IWidget
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
            //throw new NotImplementedException();
        }

        public new void Init(IWidgetHost host)
        {
            //throw new NotImplementedException();
        }

        public void ShowSettings()
        {
            //throw new NotImplementedException();
        }

        protected void ButtonAddRemark_Click(object sender, EventArgs e)
        {
            Response.Redirect("addremark");
        }

        protected void ButtonChangePassword_Click(object sender, EventArgs e)
        {
            Response.Redirect("changepassword");
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