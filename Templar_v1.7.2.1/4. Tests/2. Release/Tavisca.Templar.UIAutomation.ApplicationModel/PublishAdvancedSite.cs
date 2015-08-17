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
    public class PublishAdvancedSite
    {
        public void ClickPublishAdvancedSiteLink(string siteNameToSelect) 
        {
            Thread.Sleep(500);
            TestManager.ControlMap["SiteDashBoard.LinkAdvancedPublish"].WaitForControlExist(null);
            var ListItemPublishAdvancedLink = TestManager.ControlMap["SiteDashBoard.LinkAdvancedPublish"].GetMatchingVisibleControls();

            var ListItemsSiteName = TestManager.ControlMap["SiteDashBoard.LblSiteName"].GetMatchingVisibleControls();

            for (int i = 0; i < ListItemPublishAdvancedLink.Count; i++)
            {
                if (ListItemsSiteName[i].HtmlControl.Title.Split(new string[] { "Description" }, StringSplitOptions.None)[0].Replace("Name:", "").Trim().Equals(siteNameToSelect))
                {
                    ListItemPublishAdvancedLink[i].Click();

                    return;
                }
            }
            Assert.Fail(siteNameToSelect + "Not found in listing.");

        }
        public void SelectPublishItem(string chkboxLabelToSelect) 
        {
            var ListItemToPublish = TestManager.ControlMap["SiteDashBoard.CheckBoxIndividualPublishItem"].Reset().GetMatchingVisibleControls();

            for (int i = 0; i < ListItemToPublish.Count; i++) 
            {
                var label = ListItemToPublish[i].HtmlControl.GetParent().GetChildren()[1].InnerText;

               if (label.Equals(chkboxLabelToSelect)) 
               {
                   ListItemToPublish[i].SelectCheckBox(true);
               }
            }
            

        }
        public void ClickPublishBtn() 
        {
            TestManager.ControlMap["SiteDashBoard.PublishAdvanceSiteBtn"].Click();
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
