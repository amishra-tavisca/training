using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Tavisca.BusinessLayer;

namespace Tavisca.EMS.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service2" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service2.svc or Service2.svc.cs at the Solution Explorer and start debugging.
    public class Service2 : IEmployeeService
    {
        public Employee Get(string employeeId)
        {
            var object1 = new Employee();
            var object2 = (EmployeeObjectAtBusinessLayer)RemarkFactory.Get(employeeId);
            object1.Id = object2.Id;
            object1.Title = object2.title;
            object1.FirstName = object2.firstName;
            object1.LastName = object2.lastName;
            object1.Email = object2.email;
            object1.Remarks.remark = object2.remark;
            return(object1);
        }

        public List<Employee> GetAll()
        {
            List<Employee> List1 = new List<Employee>();
            List<EmployeeObjectAtBusinessLayer> List2 = new List<EmployeeObjectAtBusinessLayer>();
            foreach (EmployeeObjectAtBusinessLayer object2 in List2)
            {
                var object1 = new Employee();
                object1.Id = object2.Id;
                object1.Title = object2.title;
                object1.FirstName = object2.firstName;
                object1.LastName = object2.lastName;
                object1.Email = object2.email;
                object1.Remarks.remark = object2.remark;

                List1.Add(object1);
            }
            return(List1);
        }
    }
}
