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
    public class DeleteUser
    {
        public void ClickDeleteUser(string UserToDelete) 
        {
            var searchUser = new SearchUser();
            var index = searchUser.GetAddedUserIndex(UserToDelete);
            var ListItemDeleteLink = TestManager.ControlMap["Admin.LinkDeleteUser"].GetMatchingVisibleControls();
            if (index > -1)
            {
                ListItemDeleteLink[index].Click();
                return;
            }
            Assert.Fail("Index not found");

        }
        public void ClickDeleteOKButton()
        {
            TestManager.ControlMap["Admin.DeleteOkButton"].Click();
            CheckMsg();
            TestManager.ControlMap["Admin.DivMsg"].WaitForControlExist(2000, false);
            TestManager.ControlMap["Admin.DivMsg"].WaitForControlNotExist(null);
            Thread.Sleep(500);

        }
        public void CheckMsg()
        {
            TestManager.ControlMap["Admin.DivMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["Admin.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("deleted successfully."), "Failed to delete User.");
            Console.WriteLine(Msg);
        }
    }
}
