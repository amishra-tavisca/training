using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class AddUser
    {
        public void ClickAddUserLink() 
        {
            TestManager.ControlMap["Admin.LinkAddUser"].Click();
        }
        public void EnterUserDetails(string loginName, string password, string firstName, string lastName) 
        {
            TestManager.ControlMap["Admin.FieldLoginName"].Type(loginName);
            TestManager.ControlMap["Admin.FieldPassword"].Type(password);
            TestManager.ControlMap["Admin.FieldFirstName"].Type(firstName);
            TestManager.ControlMap["Admin.FieldLastName"].Type(lastName);
        }
        public void SelectUserTypeDropDown(string userType) 
        {
            TestManager.ControlMap["Admin.UserRoleDropDown"].SelectComboBoxByText(userType);
        }
        public void SelectDisableUser(bool isDisabled) 
        {
            TestManager.ControlMap["Admin.CheckBoxDisableUser"].SelectCheckBox(isDisabled);
        }
        public void ClickUpdateUserLink() 
        {
            TestManager.ControlMap["Admin.LinkUpdateUser"].Click();
            CheckMsg();
            TestManager.ControlMap["Admin.DivMsg"].WaitForControlExist(2000, false);
            TestManager.ControlMap["Admin.DivMsg"].WaitForControlNotExist(null);
            Thread.Sleep(500);
        }
        public void CheckMsg()
        {
            TestManager.ControlMap["Admin.DivMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["Admin.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("Created Successfully."), "Failed to add user.");
            Console.WriteLine(Msg);
        }
    }
}
