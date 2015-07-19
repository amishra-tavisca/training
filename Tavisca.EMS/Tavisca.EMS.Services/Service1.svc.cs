using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using Tavisca.BusinessLayer;

namespace Tavisca.EMS.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IEmployeeManagementService
    {
       /* public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public Employee GetDataUsingDataContract(Employee composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        } */

        public Employee Create(Employee employee)
        {
            if (string.IsNullOrEmpty(employee.FirstName))
                throw new Exception("Atleast name is cumpulsory");
            var object1 = new EmployeeObjectAtBusinessLayer(employee.Title,employee.FirstName,employee.LastName,employee.Email);
            EmployeeFactory.CreateEmployee(object1);
            employee.Id = object1.Id;
            employee.Remarks.remark = object1.remark;
            return(employee);
        }


        public Remark AddRemark(string employeeId, Remark remark)
        {
            remark.remark=RemarkFactory.AddRemark(employeeId, remark.remark);
            return(remark);
        }
    }
}
