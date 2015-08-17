using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class UpdateWidgetLink
    {
        public static void ClickUpdateWidgetLink() 
        {
            TestManager.ControlMap["Admin.LinkUpdateWidget"].Click();
        }

      //  var ele= ControlMap["Admin.SelectFile"].HtmlControl.GetChildren()[0].Element;
//ele.SendKeys("D:\\TestDumyTemplate.zip");
    }
}
