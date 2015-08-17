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
    [TestComponent("DeleteSite")]
    public class DeleteSiteTest : ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            PageNavigation.NavigateToSiteDashBoard();
            var searchSite = new SearchSite();
            var deleteSite = new DeleteSite();

            var siteName = TestManager.TestData.Get<string>("CreatedSiteName");
            var isFound = searchSite.SearchCreatedSite(siteName);

            Assert.IsTrue(isFound, "Created site:" + siteName + " not found.");

            deleteSite.ClickDeleteSite(siteName);
            deleteSite.ClickDeleteOKButton();

            isFound = searchSite.SearchCreatedSite(siteName);
            if (isFound == false) Console.WriteLine("After deleting site:" + siteName + ", search again same site and now deleted site is not found.");
            Assert.IsTrue(isFound == false, "After deleting Site: " + siteName + " site searched.It means site is not deleted yet.");


        }
    }
}
