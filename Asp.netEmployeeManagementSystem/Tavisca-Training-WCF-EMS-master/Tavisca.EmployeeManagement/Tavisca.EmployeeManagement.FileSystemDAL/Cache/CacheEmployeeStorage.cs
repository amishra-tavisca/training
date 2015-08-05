using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.Interface;
using Newtonsoft.Json;
using Tavisca.EmployeeManagement.ErrorSpace;

namespace Tavisca.EmployeeManagement.FileStorage
{
    public class CacheEmployeeStorage : IEmployeeStorage
    {
        public CacheEmployeeStorage(ICacheManager manager)
        {
            _innerStorage = new EmployeeStorage();
            _cacheManager = manager;
        }

        IEmployeeStorage _innerStorage;
        ICacheManager _cacheManager;

        readonly string KEYFORMAT = "emp.{0}";
        readonly string CACHEMANAGER = "employee";

        public Model.Employee Save(Model.Employee employee)
        {
            var result = _innerStorage.Save(employee);
            _cacheManager.Add(string.Format(KEYFORMAT, result.Id), result, CACHEMANAGER);
            return result;
        }

        public Model.Employee Get(string employeeId)
        {
            Model.Employee result;
            result = _cacheManager.Get(string.Format(KEYFORMAT, employeeId), CACHEMANAGER) as Model.Employee;
            if (result == null)
            {
                result = _innerStorage.Get(employeeId);
                _cacheManager.Add(string.Format(KEYFORMAT, employeeId), result, CACHEMANAGER);
            }
            return result;
        }

        public Model.Employee GetByEmail(string employeeEmail)
        {
            Model.Employee result;
            result = _innerStorage.GetByEmail(employeeEmail);    
            return result;
        }

        public void AddRemark(string employeeId, Tavisca.EmployeeManagement.Model.Remark remark)      //return
        {
            _innerStorage.AddRemark(employeeId,remark);
        
        }

        public String ChangePassword(string employeeEmail, string newPassword)
        {
            string result=_innerStorage.ChangePassword(employeeEmail,newPassword);
            return result;
        }


        public bool IsValid(string employeeEmail, string password)
        {
            bool result = _innerStorage.IsValid(employeeEmail,password);
            return result;
        } 

        public List<Model.Employee> GetAll()
        {
            return _innerStorage.GetAll();
        }
    }
}
