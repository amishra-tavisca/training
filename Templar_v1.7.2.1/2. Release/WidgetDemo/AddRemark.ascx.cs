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
    public partial class AddRemark : System.Web.UI.UserControl,IWidget
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Response.Write(Session["name"].ToString() + "<br/>");
                Dictionary<string, string> dictionary = new Dictionary<string, string>();
                if (Page.IsPostBack == false)
                {

                    var employeeList = Employee.GetAllEmployee();
                    for (int i = 0; i < employeeList.Count(); i++)
                    {
                        Employee tempEmployee = employeeList.ElementAt(i);
                        dictionary.Add(tempEmployee.Id.ToString(), tempEmployee.Id.ToString() + " " + tempEmployee.FirstName.ToString().Trim() + " " + tempEmployee.LastName.ToString().Trim());
                    }
                    DropDownEmployee.DataTextField = "Value";
                    DropDownEmployee.DataValueField = "Key";
                    DropDownEmployee.DataSource = dictionary;
                    DropDownEmployee.DataBind();

                }
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

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            string selectedEmployee = DropDownEmployee.SelectedValue;
            Remark remark = new Remark();
            remark.Text = TextBoxRemark.Text;
            remark.CreateTimeStamp = DateTime.UtcNow;
            Remark.AddRemark(remark, selectedEmployee);
            Response.Write("Remark Added successfully !");
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