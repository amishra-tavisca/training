using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.DataAccessLayer;
using Tavisca.BusinessLayer;

namespace Tavisca.BusinessLayer
{
   
    public class RemarkFactory
    {
        
        /*public static void Main()
        {
            var ob1 = new EmployeeObjectAtBusinessLayer("Mr", "Abhishek", "Mishra", "abhi@gmail.com");
            var ob2 = new EmployeeObjectAtBusinessLayer("Mr", "Pankaj", "Ahhirao", "pankya@gmail.com");
            EmployeeFactory.CreateEmployee(ob1);
            EmployeeFactory.CreateEmployee(ob2);
            AddRemark(ob1.Id,"Get registered");
            Console.WriteLine("for 1 object");
            Console.WriteLine(Get(ob1.Id).Id);
            Console.WriteLine("for All objects");
            foreach (EmployeeObjectAtBusinessLayer t in GetAll())
            {
                Console.WriteLine(t.Id);
            }
        }*/

        public static string AddRemark(string Id, String Remark)
        {

            Remark = string.Concat("      -> (" + DateTime.UtcNow, ") : " + Remark);
            if (DataAccessor.DoesIdExist(Id))
            {
                EmployeeObjectAtBusinessLayer object1 = new EmployeeObjectAtBusinessLayer(Translator.ConvertJSonToObject<EmployeeObjectAtBusinessLayer>(DataAccessor.GetEmployee(Id)));
                object1.remark = string.Concat(object1.remark, "   " + Remark);
                EmployeeFactory.CreateEmployee(object1);
                return (object1.remark);
            }
            return (null);
        }

        public static EmployeeObjectAtBusinessLayer Get(string Id)
        {
            var ob = new EmployeeObjectAtBusinessLayer((EmployeeObjectAtBusinessLayer)Translator.ConvertJSonToObject<EmployeeObjectAtBusinessLayer>(DataAccessor.GetEmployee(Id)));
            return (ob);
        }

        public static List<EmployeeObjectAtBusinessLayer> GetAll()
        {
            List<EmployeeObjectAtBusinessLayer> EmployeeList = new List<EmployeeObjectAtBusinessLayer>();
            List<string> fileInJson = new List<string>();
            fileInJson = DataAccessor.GetAll();
            foreach (string string1 in fileInJson)
            {
                EmployeeList.Add(((EmployeeObjectAtBusinessLayer)Translator.ConvertJSonToObject<EmployeeObjectAtBusinessLayer>(string1)));
            }
            return (EmployeeList);

        }
        
        
       
    }
}
