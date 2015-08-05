using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AuthenticationForm.Model;
using System.Net;

namespace AuthenticationForm
{
    public partial class Userspx : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write(Session["name"].ToString() + "<br/>");
            if (!IsPostBack)
                LoadGridData();
        }


        private void LoadGridData()
        {

            Employee employee = new Employee();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            string email = Session["email"].ToString();
            var response1 = client.DownloadString("http://localhost:53412/EmployeeService.svc/employeeEmail/" + email);
            employee = Serializer.Deserialize<Employee>(response1);
            EmployeeIdBox.Text = employee.Id.ToString();
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
            Response.Redirect("~/PasswordChange.aspx");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            Response.Cookies["UserName"].Expires = DateTime.Now.AddDays(-1);
            Response.Cookies["Password"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect("~/Account/Login.aspx");
        }

      
    }
}