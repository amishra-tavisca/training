using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using System.Threading;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class SearchPage
    {
        public void EnterPageName(string pageName) 
        {
            Thread.Sleep(500);
            TestManager.ControlMap["PageDashBoard.FieldSearchPage"].WaitForControlExist(null);
            Thread.Sleep(300);
            TestManager.ControlMap["PageDashBoard.FieldSearchPage"].Type(pageName);
        }

        public void ClickSearchIcon()
        {
            TestManager.ControlMap["PageDashBoard.LinkSearch"].Click();
        }

        public bool SearchCreatedPage(string pageToSearch) 
        {
            if (GetCreatedPageIndex(pageToSearch) > -1)
            {
                return true;
            }

            return false;
        }
        public int GetCreatedPageIndex(string pageToSearch)
        {
            EnterPageName(pageToSearch);
            ClickSearchIcon();
            Thread.Sleep(300);
            TestManager.ControlMap["PageDashBoard.ListSearchPage"].WaitForControlExist(3000,false);
            var ListItems = TestManager.ControlMap["PageDashBoard.ListSearchPage"].Reset().GetMatchingVisibleControls();
            for (int i = 0; i < ListItems.Count; i++)
            {
                var pageNameText = ListItems[i].HtmlControl.GetProperty("title").ToString();
                if (pageNameText.Equals(pageToSearch))
                {
                    return i;
                }
            }
            return -1;
        }

    }
}
