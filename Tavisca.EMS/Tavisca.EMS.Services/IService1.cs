using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace Tavisca.EMS.Services
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
    [ServiceContract]
    public interface IEmployeeManagementService
    {

       /* [OperationContract]
        string GetData(int value);

        [OperationContract]
        Employee GetDataUsingDataContract(Employee composite);

        // TODO: Add your service operations here*/

        [OperationContract]
        Employee Create(Employee employee);

        [OperationContract]
        Remark AddRemark(string employeeId, Remark remark);



    }

    [DataContract]
    public class Remark
    {
        [DataMember]
        public string remark
        {
            get;
            set;
        }
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class Employee
    {
       /* bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }*/

        [DataMember]
        public string Id
        {
            get;
            set;
        }

        [DataMember]
        public string Title
        {
            get;
            set;
        }

        [DataMember]
        public string FirstName
        {
            get;
            set;
        }

        [DataMember]
        public string LastName
        {
            get;
            set;
        }

        [DataMember]
        public string Email
        {
            get;
            set;
        }

        [DataMember]
        public Remark Remarks
        {
            get;
            set;
        }

        


    }
}
