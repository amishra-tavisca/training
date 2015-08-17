using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using System.Threading;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class SearchSite
    {
        public void EnterSiteName(string siteName)
        {
            TestManager.ControlMap["SiteDashBoard.FieldSearchSite"].Type(siteName);            
        }

        public void ClickSearchIcon()
        {
            TestManager.ControlMap["SiteDashBoard.LinkSearch"].Click();
        }

        public bool SearchCreatedSite(string siteToSearch)
        {
            if (GetCreatedSiteIndex(siteToSearch) > -1)
            {
                return true;
            }

            return false;

        }
        public int GetCreatedSiteIndex(string siteToSearch)
        {
            EnterSiteName(siteToSearch);
            ClickSearchIcon();
            Thread.Sleep(1000);
            TestManager.ControlMap["SiteDashBoard.ListSearchSite"].WaitForControlExist(3000,false);
            var ListItems = TestManager.ControlMap["SiteDashBoard.ListSearchSite"].Reset().GetMatchingVisibleControls();
            for (int i = 0; i < ListItems.Count; i++)
            {
                var siteNameText = ListItems[i].HtmlControl.GetProperty("title").ToString().Split(new string[] { "Description" }, StringSplitOptions.None)[0];
                var searchSiteResult = siteNameText.Replace("Name:", "").Trim();
                if (searchSiteResult.Equals(siteToSearch))
                {
                    return i;
                }
            }
            return -1;
        }
       
    }

}
