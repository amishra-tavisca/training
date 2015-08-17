using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class CreateSiteLevelTheme
    {
        public void SelectCreateThemeLink() 
        {
            TestManager.ControlMap["SiteLevelTheme.LinkCreateNewTheme"].Click();
        }
        public void EnterSiteLevelThemeDetails(string themeName, string description) 
        {
            TestManager.ControlMap["SiteLevelTheme.FieldThemeName"].Type(themeName);
            TestManager.ControlMap["SiteLevelTheme.FieldThemeDescription"].SendKeys(description);
        }
        public void SelectFromSiteDropDown(string fromSite) 
        {
            TestManager.ControlMap["SiteLevelTheme.SelectFromSiteDropDown"].SelectComboBoxByText(fromSite);
        }
        public void SelectFromThemeDropDown(string fromTheme) 
        {
            TestManager.ControlMap["SiteLevelTheme.SelectFromThemeDropDown"].SelectComboBoxByText(fromTheme);
        }
        public void ClickCreateThemeBtn() 
        {
            TestManager.ControlMap["SiteLevelTheme.CreateThemeBtn"].Click();
        }
    }
}
