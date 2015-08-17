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
    [TestComponent("LoadSite")]
    public class LoadSiteTest : ScenarioTestComponent
    {
        public SiteDashBoardDetails SiteDashBoardDetails { get; set; }

        protected override void RunSmoke()
        {
            //ExtractscenarioData();

            var loadsitelink = new LoadSite();
            var searchSite = new SearchSite();

            //searchSite.EnterSiteName(SiteDashBoardDetails.SiteName);
            //searchSite.ClickSearchIcon();

            var siteName = TestManager.TestData.Get<string>("CreatedSiteName");
            var isFound = searchSite.SearchCreatedSite(siteName);

            //if (isFound) Console.WriteLine("Site: " + siteName + " Searched successfully.");
            Assert.IsTrue(isFound, "Created site:" + siteName + " not found.");

            //loadsitelink.ClickLoadSiteLink(SiteDashBoardDetails.SiteName);
            loadsitelink.ClickLoadSiteLink(siteName);
            
        }

        private void ExtractscenarioData()
        {
            SiteDashBoardDetails = ((TemplarDetails)Scenario).SiteDashBoardDetails;
        }
    }
}
