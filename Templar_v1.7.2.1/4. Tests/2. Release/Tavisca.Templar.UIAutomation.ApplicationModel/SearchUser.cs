using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using System.Threading;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class SearchUser
    {
        public void EnterUserName(string UserName)
        {
            TestManager.ControlMap["Admin.FieldSearchUser"].WaitForControlExist(null);
            Thread.Sleep(300);
            TestManager.ControlMap["Admin.FieldSearchUser"].Type(UserName);
        }
        public void ClickSearchIcon()
        {
            TestManager.ControlMap["Admin.LinkUserSearch"].Click();
        }
        public bool SearchAddedUser(string UserToSearch)
        {
            if (GetAddedUserIndex(UserToSearch) > -1)
            {
                return true;
            }

            return false;
        }

        public int GetAddedUserIndex(string UserToSearch)
        {
            EnterUserName(UserToSearch);
            ClickSearchIcon();
            Thread.Sleep(300);
            TestManager.ControlMap["Admin.ListUserRole"].WaitForControlExist(3000,false);
            Thread.Sleep(300);
            var ListUserName = TestManager.ControlMap["Admin.ListUserRole"].GetMatchingVisibleControls();
            for (int i = 0; i < ListUserName.Count; i++)
            {
                var userNameOnUI = ListUserName[i].HtmlControl.GetParent().GetParent().GetChildren()[1].GetChildren()[0].Title;
                if (string.Equals(UserToSearch, userNameOnUI))
                {
                    return i;
                }
            }
            return -1;
        }
    }

}


