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
    public partial class AddEmployee : System.Web.UI.UserControl,IWidget
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
            pnlSettings.Visible = true;
            //throw new NotImplementedException();
        }

        public new void Init(IWidgetHost host)
        {
            //throw new NotImplementedException();
        }

        public void ShowSettings()
        {
            pnlSettings.Visible = true;
            //throw new NotImplementedException();
        }

        protected void ButtonLogin_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Title = TextBoxTitle.Text;
            employee.FirstName = TextBoxFirstName.Text;
            employee.LastName = TextBoxLastName.Text;
            employee.Email = TextBoxEmail.Text;
            employee.Phone = TextBoxPhone.Text;
            employee.Designation = TextBoxDesignation.Text;
            var response = Employee.AddEmployee(employee);
            if (response != null)
                Response.Write("Employee Added Successfully");
            else
                Response.Write("Sorry ! Customer could not be added");
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