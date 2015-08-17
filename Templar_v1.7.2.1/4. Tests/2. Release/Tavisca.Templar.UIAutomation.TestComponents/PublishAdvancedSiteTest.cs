using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("PublishAdvancedSite")]
    public class PublishAdvancedSiteTest : ScenarioTestComponent
    {
        public SiteDashBoardDetails SiteDashBoardDetails { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();

            PageNavigation.NavigateToSiteDashBoard();

            var publishAdvancedSiteLink = new PublishAdvancedSite();
            var searchSite = new SearchSite();

            //searchSite.EnterSiteName(SiteDashBoardDetails.SiteName); //Can use in regresstion
            //searchSite.ClickSearchIcon();

            var siteName = TestManager.TestData.Get<string>("CreatedSiteName");
            var isFound = searchSite.SearchCreatedSite(siteName);
            if (isFound) Console.WriteLine("Site: " + siteName + " Searched successfully.");
            Assert.IsTrue(isFound, "Created site:" + siteName + " not found.");

            //publishAdvancedSiteLink.ClickPublishAdvancedSiteLink(SiteDashBoardDetails.SiteName);
            publishAdvancedSiteLink.ClickPublishAdvancedSiteLink(siteName);

            foreach(var publishItem in SiteDashBoardDetails.ListItemToPublish)
            {
                publishAdvancedSiteLink.SelectPublishItem(publishItem);
            }
            publishAdvancedSiteLink.ClickPublishBtn();
            publishAdvancedSiteLink.CheckMsg();

        }

        private void ExtractScenarioData()
        {
            SiteDashBoardDetails = ((TemplarDetails)Scenario).SiteDashBoardDetails;
        }
    }
}
