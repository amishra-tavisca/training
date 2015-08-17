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
    public class DeleteGlobalCulture
    {
        public void ClickDeleteGlobalCulture(string CultureToDelete) 
        {
            Thread.Sleep(700);
            var searchCulture = new SearchGlobalCulture();
            var index = searchCulture.GetAddedGlobalcultureIndex(CultureToDelete);
            var ListItemDeleteLink = TestManager.ControlMap["Globals.LinkDeleteCulture"].GetMatchingVisibleControls();
            if (index>-1)
            {
                ListItemDeleteLink[index].Click();
                return;
            }
            Assert.Fail("Index not found");
            
        }
        public void ClickDeleteOKButton() 
        {
            TestManager.ControlMap["Globals.DeleteOkButton"].Click();
            /*CheckMsg();
            TestManager.ControlMap["Globals.DivMsg"].WaitForControlExist(2000, false);
            TestManager.ControlMap["Globals.DivMsg"].WaitForControlNotExist(null);
            Thread.Sleep(300);*/
            
        }
        public void ConfermDeleteOkButton() 
        {
            TestManager.ControlMap["Globals.DeleteOkButton"].Click();
        }

        /*public void CheckMsg()
        {
            TestManager.ControlMap["Globals.DivMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["Globals.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("deleted successfully."), "Failed to Delete Template.");
            Console.WriteLine(Msg);
        }*/
    }
}
