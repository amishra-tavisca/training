using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using System.Threading;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class SearchWidget
    {
        public void EnterWidgetName(string WidgetName) 
        {
            TestManager.ControlMap["Admin.FieldSearchWidget"].WaitForControlExist(null);
            Thread.Sleep(300);
            TestManager.ControlMap["Admin.FieldSearchWidget"].Type(WidgetName);
        }
        public void ClickSearchIcon() 
        {
            TestManager.ControlMap["Admin.LinkSearchWidget"].Click();
        }
        public bool SearchAddedWidget(string WidgetToSearch) 
        {
            EnterWidgetName(WidgetToSearch);
            ClickSearchIcon();
            Thread.Sleep(300);
            TestManager.ControlMap["Admin.ListLastModified"].WaitForControlExist(3000, false);
            Thread.Sleep(300);
            var ListWidgetName = TestManager.ControlMap["Admin.ListLastModified"].GetMatchingVisibleControls();
            for (int i = 0; i < ListWidgetName.Count; i++)
            {
                var widgetNameOnUI = ListWidgetName[i].HtmlControl.GetParent().GetParent().GetChildren()[1].InnerText;
                if (string.Equals(WidgetToSearch, widgetNameOnUI))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
