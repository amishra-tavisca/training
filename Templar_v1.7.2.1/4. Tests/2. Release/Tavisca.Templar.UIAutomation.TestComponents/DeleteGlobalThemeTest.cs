using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.Templar.UIAutomation.ScenarioObjects;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent ("DeleteGlobalTheme")]
    public  class DeleteGlobalThemeTest : ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            PageNavigation.NavigateToGlobalTheme();

            var deleteGlobalTheme = new DeleteGlobalTheme();
            var searchGlobalTheme = new SearchGlobalTheme();

            var themeNames = TestManager.TestData.Get<List<string>>("ListThemeNames");

            foreach (var themeName in themeNames) 
            {
                deleteGlobalTheme.ClickDeleteGlobalThemeLink(themeName);
                deleteGlobalTheme.ClickDeleteOKButton();
                var isFound = searchGlobalTheme.SearchAddedTheme(themeName);
                if (isFound == false) Console.WriteLine("After deleting Global Theme: " + themeName + ", search again same Global Theme and now deleted Global Theme is not found.");
                Assert.IsTrue(isFound == false, "After deleting Global Theme: " + themeName + " Global Theme searched.It means Global Theme is not deleted yet.");
                                    
            }

        }

    }
}
