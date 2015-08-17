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
    public class PublishSite
    {
        public void ClickPublishSiteLink(string siteNameToSelect)
        {
            Thread.Sleep(500);
            TestManager.ControlMap["SiteDashBoard.LinkPublishSite"].WaitForControlExist(null);
            var ListItemsPublishLink = TestManager.ControlMap["SiteDashBoard.LinkPublishSite"].Reset().GetMatchingVisibleControls();

            var ListItemsSiteName = TestManager.ControlMap["SiteDashBoard.LblSiteName"].Reset().GetMatchingVisibleControls();

            for (int i = 0; i < ListItemsPublishLink.Count; i++)
            {
                if (ListItemsSiteName[i].HtmlControl.Title.Split(new string[] { "Description" }, StringSplitOptions.None)[0].Replace("Name:","").Trim().Equals(siteNameToSelect))
                {
                    ListItemsPublishLink[i].Click();

                    return;
                }
            }
            Assert.Fail(siteNameToSelect + "Not found in listing.");
        }

        public void ClickPublishOkButton()
        {
            TestManager.ControlMap["SiteDashBoard.PublishSiteBtn"].Click();
            
        }

        public void CheckMsg()
        {
            TestManager.ControlMap["SiteDashBoard.PublishSiteMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["SiteDashBoard.PublishSiteMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("published sucessfully."), "Failed to Publish Site.");
            Console.WriteLine(Msg);
        }
    }
}
