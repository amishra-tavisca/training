using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Tavisca.EmployeeManagement.Model;

namespace Tavisca.EmployeeManagement.BusinessLogic
{
    public class EmployeeManager : IEmployeeManager
    {
        public EmployeeManager(IEmployeeStorage storage)
        {
            _storage = storage;
        }

        IEmployeeStorage _storage;

        public Employee Get(string employeeId)
        {
            return _storage.Get(employeeId);
        }

        public Employee GetByEmail(string employeeEmail)           //remove     
        {
            return _storage.GetByEmail(employeeEmail);
        }

        public bool IsValid(string employeeEmail, string password)               
        {
            return _storage.IsValid(employeeEmail,password);
        }

        public List<Employee> GetAll()
        {
            return _storage.GetAll();
        }
    }
}
