using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class Login
    {
        public void EnterCredentials(string userName, string password)
        {
            TestManager.ControlMap["Login.FieldUserName"].Type(userName);
            TestManager.ControlMap["Login.FieldPassword"].Type(password);
        }

        public void ClickLoginBtn()
        {
            TestManager.ControlMap["Login.LoginButton"].Click();
        }
    }
}
