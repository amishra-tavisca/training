using AuthenticationForm.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization.Json;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AuthenticationForm
{
    public partial class HRAddEmployeeTab : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        protected void ButtonEmpSubmit_Click(object sender, EventArgs e)
        {
            Employee employee = new Employee();
            employee.Title = TextBoxTitle.Text;
            employee.FirstName = TextBoxFirstName.Text;
            employee.LastName = TextBoxLastName.Text;
            employee.Email = TextBoxEmail.Text;
            employee.Phone = TextBoxPhone.Text;           
            employee.Designation=TextBoxDesignation.Text;
            MemoryStream stream1 = new MemoryStream();
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Employee));
            ser.WriteObject(stream1, employee);
            stream1.Position = 0;
            StreamReader sr = new StreamReader(stream1);
            // Console.Write("JSON form of Person object: ");
            string d = sr.ReadToEnd();
            var client = new WebClient();
            client.Headers.Add("Content-Type", "application/json");
            var response = client.UploadString("http://localhost:53412/EmployeeManagementService.svc/employee", "POST", d);
            

        }

    }
}