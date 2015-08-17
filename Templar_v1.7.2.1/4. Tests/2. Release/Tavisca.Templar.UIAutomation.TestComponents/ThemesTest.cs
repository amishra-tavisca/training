using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Tavisca.Templar.UIAutomation.ScenarioObjects;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("Themes")]
    public class ThemesTest : ScenarioTestComponent
    {
        public ThemesScenario Themes { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();

            var themesWdgt = new Themes();

            var themeNames = TestManager.TestData.Get<List<string>>("ListThemeNames"); 


            themesWdgt.ClickThemesLink();
            themesWdgt.ClickAddGlobalThemesLink();

            foreach (var themeName in themeNames)
            {
                themesWdgt.SelectThemeChkbox(themeName);
            }

            //themesWdgt.SelectAllThemesCheckbox(Themes.SelectGlobalTheme);
            themesWdgt.ClickSaveBtn();
            themesWdgt.SelectDefaultTheme(themeNames[0]);
            //themesWdgt.ClickCancleBtn();
            themesWdgt.ClickAddSiteThemeLink();
            themesWdgt.ClickOkBtn();

        }

        private void ExtractScenarioData()
        {
            Themes = ((TemplarDetails)Scenario).CreateSiteDetails.Themes;
        }
    }
}
