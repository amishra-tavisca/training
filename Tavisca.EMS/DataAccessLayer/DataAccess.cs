using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Tavisca.DataAccessLayer
{
    public static class DataAccessor
    {
        
        //Cheks whether an employee with given Id exists
        public static bool DoesIdExist(string Id)
        {
            Id = string.Concat(Id, ".txt");
            DirectoryInfo directory = new DirectoryInfo(@"D:\TrainingRepo\training\Tavisca.EMS\Employees");
            foreach (var file in directory.GetFiles())
            {
                if (file.Name == Id)
                {
                    return (true);
                }
            }
            return (false);
        }
            
        
        //Adds employee's information to a file in json string format
        public static void AddEmployee(string id, string newEntry)
        { 
            File.WriteAllText(@"D:\TrainingRepo\training\Tavisca.EMS\Employees\" + id + ".txt", newEntry);    
        }

        
        //Adds remark for an existing employee
        public static void AddRemark(string id, string remark)
        {
            File.WriteAllText(@"D:\TrainingRepo\training\Tavisca.EMS\Employees\" + id + ".txt", remark);
        }

        
        //Returns employee's information in json format
        public static string GetEmployee(string id)
        {
            return (File.ReadAllText(@"D:\TrainingRepo\training\Tavisca.EMS\Employees\" + id + ".txt"));
        }

       
        public static List<string> GetAll()
        {
            List<string> targets = new List<string>();
            DirectoryInfo di = new DirectoryInfo(@"D:\TrainingRepo\training\Tavisca.EMS\Employees");
            foreach (var file in di.GetFiles())
            {
                targets.Add((File.ReadAllText(@"D:\TrainingRepo\training\Tavisca.EMS\Employees\"+file.Name)));
            }
            return (targets);
        }
           

    }
    
}
