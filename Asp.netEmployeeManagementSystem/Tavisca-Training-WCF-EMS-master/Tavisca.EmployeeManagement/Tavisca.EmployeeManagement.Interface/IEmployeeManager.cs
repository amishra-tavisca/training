using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.Interface
{
    public interface IEmployeeManager
    {
        Employee Get(string employeeId);
        
        Employee GetByEmail(string employeeEmail);  //remove

        bool IsValid(string employeeEmail, string password);
        
        List<Employee> GetAll();
    }
}
