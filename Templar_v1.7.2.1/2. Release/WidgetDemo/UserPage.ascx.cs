using EmsClasses;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tavisca.Templar.Contract;

namespace WidgetDemo
{
    public partial class UserPage : System.Web.UI.UserControl,IWidget
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

            if (!IsPostBack)
                LoadGridData();
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


        private void LoadGridData()
        {

            Employee employee = new Employee();
            employee = Employee.GetEmployeeByEmail(Session["email"].ToString());
            TextBoxEmployeeId.Text = employee.Id.ToString();
            DataTable dt = new DataTable();
            dt.Columns.Add("Timestamp");
            dt.Columns.Add("Text");
            foreach (Remark r in employee.Remarks)
            {
                DataRow dr = dt.NewRow();
                dr["Timestamp"] = r.CreateTimeStamp.ToString();
                dr["Text"] = r.Text;
                dt.Rows.Add(dr);
            }
            grdData.DataSource = dt;
            grdData.DataBind();
        }
        protected void grdData_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdData.PageIndex = e.NewPageIndex;
            LoadGridData();
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