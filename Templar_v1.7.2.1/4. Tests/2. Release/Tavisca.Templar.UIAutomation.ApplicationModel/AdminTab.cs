using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class AdminTab
    {
        public static void SelectAdminTabLink() 
        {
            TestManager.ControlMap["Admin.LinkAdminTab"].Click();
        }
    }
}
