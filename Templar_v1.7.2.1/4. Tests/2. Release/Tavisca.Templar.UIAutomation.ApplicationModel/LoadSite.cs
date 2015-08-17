using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using System.Threading;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class LoadSite
    {
        public void ClickLoadSiteLink(string siteNameToSelect) 
        {
            Thread.Sleep(500);
            TestManager.ControlMap["SiteDashBoard.LinkLoadSite"].WaitForControlExist(null);
            var ListItemsLoadLink = TestManager.ControlMap["SiteDashBoard.LinkLoadSite"].GetMatchingVisibleControls();

            var ListItemsSiteName = TestManager.ControlMap["SiteDashBoard.LblSiteName"].GetMatchingVisibleControls();

            for (int i = 0; i < ListItemsLoadLink.Count; i++)
            {
                if (ListItemsSiteName[i].HtmlControl .Title.Split(new string[] { "Description" }, StringSplitOptions.None)[0].Replace("Name:", "").Trim().Equals(siteNameToSelect)) 
                {
                    ListItemsLoadLink[i].Click();
                    return;
                }
            }

        }
    }
}
