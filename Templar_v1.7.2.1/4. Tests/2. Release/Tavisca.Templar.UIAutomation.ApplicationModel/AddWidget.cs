using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class AddWidget
    {
        public void SelectAddWidgetLink() 
        {
            TestManager.ControlMap["Admin.LinkAddNewWidget"].Click();
        }
        public void EnterWidgetDetails(string widgetName, string widgetUrl, string widgetDescription, string widgetIcon, string widgetState) 
        {
            TestManager.ControlMap["Admin.FieldWidgetName"].Type(widgetName);
            TestManager.ControlMap["Admin.FieldWidgetUrl"].Type(widgetUrl);
            TestManager.ControlMap["Admin.FieldWidgetDescription"].SendKeys(widgetDescription);
            TestManager.ControlMap["Admin.FieldWidgetIcon"].Type(widgetIcon);
            TestManager.ControlMap["Admin.FieldWidgetState"].SendKeys(widgetState);
        }
        public void ClickAddWidgetBtn() 
        {
            TestManager.ControlMap["Admin.AddWidgetBtn"].Click();
        }
       
    }
}
