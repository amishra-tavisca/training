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
    public class UpdateWidgetAction
    {
        public void SelectAllCheckBox() 
        {
            TestManager.ControlMap["Admin.CheckBoxSelectAllDiff"].WaitForControlExist(null);
            Thread.Sleep(1000);
            TestManager.ControlMap["Admin.CheckBoxSelectAllDiff"].SelectCheckBox(true);
        }        
        public void ClickUpdateBtn() 
        {
            TestManager.ControlMap["Admin.UpdateBtn"].Click();
        }
        public void ClickUpdateAndContinueBtn() 
        {
            TestManager.ControlMap["Admin.UpdateAndContinueBtn"].Click();
        }
    }
}
