using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using System.Threading;


namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class SearchGlobalCulture
    {
        public void EnterGlobalCulture(string Culture)
        {
            TestManager.ControlMap["Globals.FieldSearchGLobalCulture"].Type(Culture);
        }
        public void ClickSearchIcon()
        {
            TestManager.ControlMap["Globals.LinkGlobalCultureSearch"].Click();
        }
        public bool SearchAddedGlobalculture(string CultureToSearch)
        {
            if (GetAddedGlobalcultureIndex(CultureToSearch) > -1)
            {
                return true;
            }
            return false;
        }


        public int GetAddedGlobalcultureIndex(string CultureToSearch)
        {
            var languageString = CultureToSearch.Split('-')[0].Trim();
            EnterGlobalCulture(languageString);
            ClickSearchIcon();
            Thread.Sleep(1000);
            TestManager.ControlMap["Globals.ListCultureStatus"].WaitForControlExist(3000,false);
            var ListCultureName = TestManager.ControlMap["Globals.ListCultureStatus"].GetMatchingVisibleControls();
            for (int i = 0; i < ListCultureName.Count; i++)
            {
                var cultureNameOnUI = ListCultureName[i].HtmlControl.GetParent().GetParent().GetChildren()[1].InnerText;
                if (string.Equals(CultureToSearch, cultureNameOnUI))
                {
                    return i;
                }

            }
            return -1;
        }

    }
}

