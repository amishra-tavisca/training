using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.Interface
{
    public interface IEmployeeStorage
    {
        Employee Save(Employee employee);

        Employee Get(string employeeId);

        Employee GetByEmail(string employeeEmail);            //remove

        void AddRemark(string employeeId, Remark remark);

        String ChangePassword(string employeeEmail, string newPassword);    //remove1

        bool IsValid(string employeeEmail, string password);

        List<Employee> GetAll();
    }
}
