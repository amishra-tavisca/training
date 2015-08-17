using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public static class SitesTab
    {
        public static void SelectSitesTabLink() 
        {
            TestManager.ControlMap["SiteDetails.LinkSitesTab"].Click();
        } 
    }
}
