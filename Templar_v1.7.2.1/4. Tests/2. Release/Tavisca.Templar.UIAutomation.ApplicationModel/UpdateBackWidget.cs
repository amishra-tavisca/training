using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class UpdateBackWidget
    {
        public void ClickBackLink()
        {
            TestManager.ControlMap["Admin.LinkBack"].WaitForControlExist(null);
            Thread.Sleep(1000);
            TestManager.ControlMap["Admin.LinkBack"].Click();            
        }
    }
}
