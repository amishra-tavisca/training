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
    public class CreateSiteBtn
    {
     
        public static void ClickCreateSiteBtn()
        {
            TestManager.ControlMap["CreateSite.CreateSiteButton"].Click();           
        }
        public static void CheckMsg()
        {
            TestManager.ControlMap["CreateSite.DivMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["CreateSite.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("created"), "Failed to create site.");
            TestManager.ControlMap["CreateSite.DivMsg"].WaitForControlNotExist(null);
            Console.WriteLine(Msg);
        }
    }
}
