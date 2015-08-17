using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using System.Threading;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class SearchGlobalTheme
    {
        public void EnterThemeName(string themeName) 
        {
            TestManager.ControlMap["Globals.FieldSearchTheme"].WaitForControlExist(null);
            Thread.Sleep(300);
            TestManager.ControlMap["Globals.FieldSearchTheme"].Type(themeName);
        }
        
        public void ClickSearchIcon()
        {
            TestManager.ControlMap["Globals.LinkSearchTheme"].Click();
        }

        public bool SearchAddedTheme(string themeToSearch)
        {
            if (GetAddedThemeIndex(themeToSearch) > -1)
            {
                return true;
            }

            return false;
        }
        public int GetAddedThemeIndex(string themeToSearch)
        {
            EnterThemeName(themeToSearch);
            ClickSearchIcon();
            Thread.Sleep(300);
            TestManager.ControlMap["Globals.ListThemes"].WaitForControlExist(3000,false);
            var ListItemThemes = TestManager.ControlMap["Globals.ListThemes"].GetMatchingVisibleControls();

            for (int i = 0; i < ListItemThemes.Count; i++)
            {
                var innerText = ListItemThemes[i].GetInnerText();
                var themeNameText = ListItemThemes[i].HtmlControl.GetProperty("title").ToString();

                if (innerText.Contains("..."))
                {
                    ListItemThemes[i].HtmlControl.GetProperty("title").ToString();
                }
                else
                {
                    ListItemThemes[i].GetInnerText();
                }
                return i;
            }
            return -1;
        }
    }
}
