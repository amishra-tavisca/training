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
    public class DeleteTemplate
    {
        public void CheckDeleteTemplate(string TemplateToDelete) 
        {
            Thread.Sleep(1000);
            var searchTemplate = new SearchTemplate();
            var index = searchTemplate.GetAddedTemplateIndex(TemplateToDelete);
            TestManager.ControlMap["Templates.CheckboxDeleteTmp"].WaitForControlExist(null);
            var ListItemDeleteCheckBox = TestManager.ControlMap["Templates.CheckboxDeleteTmp"].GetMatchingVisibleControls();
            if (index > -1) 
            {
                ListItemDeleteCheckBox[index].SelectCheckBox(true);
                return;
            }
            Assert.Fail("Index not found");
        }
        public void ClickDeleteButton() 
        {
            TestManager.ControlMap["Templates.DeleteBtn"].Click();
        }
        public void ClickDeleteOKButton()
        {
            TestManager.ControlMap["Templates.DeleteOkButton"].Click();
            CheckMsg();
            TestManager.ControlMap["Templates.DivMsg"].WaitForControlExist(2000, false);
            TestManager.ControlMap["Templates.DivMsg"].WaitForControlNotExist(null);
            Thread.Sleep(300);
        }
        public void CheckMsg()
        {
            TestManager.ControlMap["Templates.DivMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["Templates.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("deleted successfully."), "Failed to Delete Template.");
            Console.WriteLine(Msg);
        }
    }
}
