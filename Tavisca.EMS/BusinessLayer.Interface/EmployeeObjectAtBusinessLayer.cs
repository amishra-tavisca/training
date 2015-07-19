using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tavisca.BusinessLayer
{
         [Serializable]
        public class EmployeeObjectAtBusinessLayer
        {
            public string Id {get;set;}
            public string title{get;set;}
            public string firstName { get; set; }
            public string lastName { get; set; }
            public string email { get; set; }
            public string remark{get;set;}


            public EmployeeObjectAtBusinessLayer(string Title, string FirstName, string LastName, string Email)
            {
                this.Id = System.Guid.NewGuid().ToString();
                this.title = Title;
                this.firstName = FirstName;
                this.lastName = LastName;
                this.email = Email;
                this.remark ="     -> ("+DateTime.UtcNow+") :"+"WELCOME TO EMS ";
            }

            public EmployeeObjectAtBusinessLayer(EmployeeObjectAtBusinessLayer object1)
            {
                this.Id = object1.Id;
                this.title = object1.title;
                this.firstName = object1.firstName;
                this.lastName =object1 .lastName;
                this.email = object1.email;
                this.remark = object1.remark;
            }

        }


}
