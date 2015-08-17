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
    public class DeleteSite
    {
        public void ClickDeleteSite(string SiteToDelete) 
        {
            Thread.Sleep(1000);
            var searchSite = new SearchSite();
            var index = searchSite.GetCreatedSiteIndex(SiteToDelete);
            TestManager.ControlMap["SiteDashBoard.LinkDeleteSite"].WaitForControlExist(null);
            var ListItemDeleteLink = TestManager.ControlMap["SiteDashBoard.LinkDeleteSite"].GetMatchingVisibleControls();
            if (index > -1)
            {
                ListItemDeleteLink[index].Click();
                return;
            }
            Assert.Fail("Index not found");
        }
        public void ClickDeleteOKButton()
        {
            TestManager.ControlMap["SiteDashBoard.DeleteOkButton"].Click();
            CheckMsg();
            TestManager.ControlMap["SiteDashBoard.DivMsg"].WaitForControlExist(2000, false);
            TestManager.ControlMap["SiteDashBoard.DivMsg"].WaitForControlNotExist(null);

        }
        public void CheckMsg()
        {
            TestManager.ControlMap["SiteDashBoard.DivMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["Templates.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("deleted successfully."), "Failed to Delete Site.");
            Console.WriteLine(Msg);
        }
    }
}
