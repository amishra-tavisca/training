﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using Tavisca.EmployeeManagement.DataContract;

namespace Tavisca.EmployeeManagement.ServiceContract
{
    [ServiceContract]
    public interface IEmployeeService
    {
        [WebGet(UriTemplate = "employee/{employeeId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Employee Get(string employeeId);

        [WebGet(UriTemplate = "employee", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        List<Employee> GetAll();

        [WebGet(UriTemplate = "employeeEmail/{employeeEmail}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        Employee GetByEmail(string employeeEmail);

        [WebGet(UriTemplate = "employee/{employeeEmail}/{password}/IsValid", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        bool IsValid(string employeeEmail, string password);
    }
}
