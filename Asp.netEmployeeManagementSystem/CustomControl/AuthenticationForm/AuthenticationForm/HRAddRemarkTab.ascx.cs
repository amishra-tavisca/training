using AuthenticationForm.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationForm
{
    public partial class HRAddRemarkTab : System.Web.UI.UserControl
    {
        Dictionary<string, string> dictionary = new Dictionary<string, string>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
               
                var client = new WebClient();
                client.Headers.Add("Content-Type", "application/json");
                var response1 = client.DownloadString("http://localhost:53412/EmployeeService.svc/employee");
                var employeeList = Serializer.Deserialize<List<Employee>>(response1);
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
        protected void Button1_Click(object sender, EventArgs e)
        {


            string selectedEmployee = DropDownEmployee.SelectedValue;
            Remark remark = new Remark();
            remark.Text = TextBoxRemark.Text;
            remark.CreateTimeStamp = DateTime.UtcNow;
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Remark));
            ser.WriteObject(stream1, remark);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            // Console.Write("JSON form of Person object: ");
            string d = sr.ReadToEnd();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var response = client.UploadString("http://localhost:53412/EmployeeManagementService.svc/employee/"+selectedEmployee+"/remark", "POST", d);
            Response.Write("Remark Added successfully !");
        }

        protected void TextBoxEmployee_TextChanged(object sender, EventArgs e)
        {

        }



    }
}