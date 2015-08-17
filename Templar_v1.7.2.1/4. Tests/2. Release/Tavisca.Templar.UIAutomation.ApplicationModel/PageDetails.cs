using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class PageDetails
    {        
        public void EnterpageDetails(string pageName, string pageTitle, string pageUrl) 
        {
            TestManager.ControlMap["PageDetails.FieldPageName"].Type(pageName);
            TestManager.ControlMap["PageDetails.FieldPageTitle"].Type(pageTitle);
            TestManager.ControlMap["PageDetails.FieldPageURL"].Type(pageUrl);
        }
        public void SelectOpenPageInDesignMode(bool isOpenDesignMode) 
        {
            TestManager.ControlMap["PageDetails.CheckBoxOpenDesignMode"].SelectCheckBox(isOpenDesignMode);
        }
        public void ClickAddPageBtn() 
        {
            TestManager.ControlMap["PageDetails.AddButton"].Click();
           
        }
        public void CheckMsg()
        {
            TestManager.ControlMap["PageDetails.DivMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["PageDetails.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("Page has been created successfully."), "Failed to add page in site.");
            Console.WriteLine(Msg);
        }
    }
}
