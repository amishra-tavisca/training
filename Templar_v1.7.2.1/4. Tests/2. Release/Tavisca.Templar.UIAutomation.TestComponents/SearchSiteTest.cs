using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("SearchSite")]
    public class SearchSiteTest : ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            var searchSite = new SearchSite();
            
            var siteName = TestManager.TestData.Get<string>("CreatedSiteName");
            var isFound = searchSite.SearchCreatedSite(siteName);
            if (isFound) Console.WriteLine("Site: " + siteName + " Searched successfully.");
            Assert.IsTrue(isFound, "Created site:" + siteName + " not found.");

           
        }
    }
}
