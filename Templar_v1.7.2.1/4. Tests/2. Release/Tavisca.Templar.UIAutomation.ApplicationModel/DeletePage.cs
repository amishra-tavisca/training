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
    public class DeletePage
    {
        public void ClickDeletePageLink(string pageToDelete)
        {
            Thread.Sleep(1000);
            var searchPage = new SearchPage();
            var index = searchPage.GetCreatedPageIndex(pageToDelete);
            TestManager.ControlMap["PageDetails.LinkDeletePage"].WaitForControlExist(null);
            var ListItemDeleteLink = TestManager.ControlMap["PageDetails.LinkDeletePage"].GetMatchingVisibleControls();
            if (index > -1)
            {
                ListItemDeleteLink[index].Click();
                return;
            }
            Assert.Fail("Index not found");
        }
        public void ClickDeleteOKButton()
        {
            TestManager.ControlMap["PageDetails.DeleteOkButton"].Click();
            CheckMsg();
            TestManager.ControlMap["PageDetails.DivMsg"].WaitForControlExist(3000, false);
            TestManager.ControlMap["PageDetails.DivMsg"].WaitForControlNotExist(null);
            Thread.Sleep(500);

        }
        public void CheckMsg()
        {
            TestManager.ControlMap["PageDetails.DivMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["PageDetails.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("deleted successfully."), "Failed to delete page.");
            Console.WriteLine(Msg);
        }
        

    }
}
