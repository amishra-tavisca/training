using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;


namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("AddGlobalTheme")]
    public class AddNewGlobalThemeTest : ScenarioTestComponent
    {
        public Globals GlobalTheme { get; set; }
        public ThemesScenario Themes { get; set; }

        
        protected override void RunSmoke()
        {
            ExtractScenarioData();

            PageNavigation.NavigateToGlobalTheme();

            
            var themeNames = new List<string>();
            
            foreach (var themeName in Themes.ListThemes)
            {
                var dateTimeStamp = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
                var timeStampedThemeName = themeName + dateTimeStamp;
                GlobalTheme = new Globals { ThemeName = timeStampedThemeName, Description = themeName, FromThemeName = "Blank Theme" };
                AddTheme();
                themeNames.Add(TestManager.TestData.Get<string>("CreatedThemeName"));
            }
            TestManager.TestData.Add("ListThemeNames", themeNames);

            //AddTheme();
        }

        public void AddTheme()
        {
            var AddNewGlobalThemeLink = new AddNewGlobalTheme();
            AddNewGlobalThemeLink.ClickOnAddNewTheme();

            
            var themeName = GlobalTheme.ThemeName;
            TestManager.TestData.Add("CreatedThemeName", themeName);
            AddNewGlobalThemeLink.EnterThemeDetails(themeName, GlobalTheme.Description);
            AddNewGlobalThemeLink.SelectThemeDropDown(GlobalTheme.FromThemeName);
            AddNewGlobalThemeLink.ClickAddThemeBtn();
        }

        private void ExtractScenarioData()
        {
            Themes = ((TemplarDetails)Scenario).CreateSiteDetails.Themes;
        }
    }
}
