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
    [TestComponent("SearchPage")]
    public class SearchPageTest : ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            var searchPage = new SearchPage();

            var pageName = TestManager.TestData.Get<string>("CreatedPageName");

            var isFound = searchPage.SearchCreatedPage(pageName);
            if (isFound) Console.WriteLine("Default Page: " + pageName + " searched successfully.");
            Assert.IsTrue(isFound, "Created page:" + pageName + " not found. ");
        }
    }
}
