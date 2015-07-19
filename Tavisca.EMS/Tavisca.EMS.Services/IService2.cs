using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace Tavisca.EMS.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService2" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeService
    {
        
        [OperationContract]
        Employee Get(string employeeId);

        [OperationContract]
        List<Employee> GetAll();
    }
}
