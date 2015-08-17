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
    [TestComponent("DeletePage")]
    public class DeletePageTest : ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            var searchPage = new SearchPage();
            var deletePage = new DeletePage();

            var pageName = TestManager.TestData.Get<string>("CreatedPageName");
            deletePage.ClickDeletePageLink(pageName);
            deletePage.ClickDeleteOKButton();

            var isFound = searchPage.SearchCreatedPage(pageName);
            if (isFound == false) Console.WriteLine("After deleting Default Page: " + pageName + ", search again same Page and now deleted page is not found.");
            Assert.IsTrue(isFound == false, "After deleting Created page: " + pageName + " Page searched.It means Page is not deleted yet.");

        }
    }
}
