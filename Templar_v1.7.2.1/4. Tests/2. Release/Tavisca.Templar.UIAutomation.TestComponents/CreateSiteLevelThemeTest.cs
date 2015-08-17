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
    [TestComponent("SiteLevelTheme")]
    public class CreateSiteLevelThemeTest : ScenarioTestComponent
    {
        public EditThemeScenario EditThemes { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();

            var themesWdgt = new Themes();
            themesWdgt.ClickThemesLink();
            themesWdgt.ClickAddSiteThemeLink();


            var createSiteLeveltheme = new CreateSiteLevelTheme();
                        
            createSiteLeveltheme.SelectCreateThemeLink();

            var dateTimeStamp = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
            var themeName = EditThemes.ThemeName+ dateTimeStamp;
            TestManager.TestData.Add("CreatedSiteLevelthemeName", themeName);
            createSiteLeveltheme.EnterSiteLevelThemeDetails(themeName, EditThemes.ThemeDescription);
            createSiteLeveltheme.SelectFromSiteDropDown(EditThemes.FromSite);
            createSiteLeveltheme.SelectFromThemeDropDown(EditThemes.FromTheme);
            createSiteLeveltheme.ClickCreateThemeBtn();
        }

        private void ExtractScenarioData()
        {
            EditThemes = ((EditSite)Scenario).EditThemes;
        }
    }
}
