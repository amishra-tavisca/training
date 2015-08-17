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
    public class DeleteGlobalTheme
    {
        public void ClickDeleteGlobalThemeLink(string gThemeToDelete) 
        {
            Thread.Sleep(1000);
            var searchGlobalTheme = new SearchGlobalTheme();
            var index = searchGlobalTheme.GetAddedThemeIndex(gThemeToDelete);
            TestManager.ControlMap["Globals.LinkDeleteTheme"].WaitForControlExist(null);
            var ListItemDeleteLink = TestManager.ControlMap["Globals.LinkDeleteTheme"].GetMatchingVisibleControls();
            if (index > -1)
            {
                ListItemDeleteLink[index].Click();
                return;
            }
            Assert.Fail("Index not found"); 
        }
        public void ClickDeleteOKButton()
        {
            TestManager.ControlMap["Globals.DeleteOkButton"].Click();
            CheckMsg();
            TestManager.ControlMap["Globals.DivMsg"].WaitForControlExist(3000, false);
            TestManager.ControlMap["Globals.DivMsg"].WaitForControlNotExist(null);
            Thread.Sleep(500);

        }
        public void CheckMsg()
        {
            TestManager.ControlMap["Globals.DivMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["Globals.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("theme deleted successfully"), "Failed to delete Global Theme.");
            Console.WriteLine(Msg);
        }

    }
}
