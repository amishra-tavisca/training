using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.BusinessLayer;
using Tavisca.DataAccessLayer;
namespace Tavisca.BusinessLayer
{
      
    public class EmployeeFactory
    {
       
        public static void CreateEmployee( EmployeeObjectAtBusinessLayer object1)
        {

            DataAccessor.AddEmployee(object1.Id, Translator.ConvertObjectToJSon<EmployeeObjectAtBusinessLayer>(object1));
        }



    }
}
