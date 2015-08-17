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
    [TestComponent("SearchGlobalTheme")]
    public class SearchGlobalThemeTest : ScenarioTestComponent
    {
        //public Globals GlobalsThemes { get; set; }

        protected override void RunSmoke()
        {
            //ExtractScenarioData();

            var searchGlobalTheme = new SearchGlobalTheme();
            var deleteGlobalTheme = new DeleteGlobalTheme();

            var themeName = TestManager.TestData.Get<string>("CreatedThemeName");
            
            var isFound = searchGlobalTheme.SearchAddedTheme(themeName);
            if (isFound) Console.WriteLine("Global Theme: " + themeName + " searched successfully.");
            Assert.IsTrue(isFound, "Added Global Theme: " + themeName + "not found.");

            
        }

       /* protected virtual void ExtractScenarioData()
        {
            GlobalsThemes = ((Globals)Scenario);
        }*/
    }
}
