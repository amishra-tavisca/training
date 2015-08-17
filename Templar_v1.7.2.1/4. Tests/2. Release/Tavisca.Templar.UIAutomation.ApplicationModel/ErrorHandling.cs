using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class ErrorHandling
    {
        public void ClickErrorHandlingLink()
        {
            TestManager.ControlMap["ErrorHandling.LinkErrorHandling"].Click();

        }
        public void ClickAddBtn()
        {
            TestManager.ControlMap["ErrorHandling.AddButton"].Click();

        }

        public void EnterNewDetails(string StatusCode, string ErrorpageUrl)
        {           
            var count = TestManager.ControlMap["Script.FieldKey"].Reset().GetVisibleMatchingControlsCount();
            TestManager.ControlMap["Script.FieldKey"].Reset().GetMatchingVisibleControls()[count - 1].Type(StatusCode);
            TestManager.ControlMap["Script.FieldValue"].Reset().GetMatchingVisibleControls()[count - 1].SendKeys(ErrorpageUrl);
            SaveNewDetails();

        }
        public void SaveNewDetails()
        {
            TestManager.ControlMap["ErrorHandling.SaveButton"].Reset().Click();

        }
        public void SelectEditActions(string buttonToSelect)
        {

            var listItems = TestManager.ControlMap["ErrorHandling.TitleIStatusCode"].Reset().GetMatchingVisibleControls();
            var listEditButtons = TestManager.ControlMap["ErrorHandling.SelectEditBtn"].Reset().GetMatchingVisibleControls();

            for (int i = 0; i < listItems.Count; i++)
            {
                var dataValue = listItems[i].HtmlControl.InnerText;
                if (dataValue.Equals(buttonToSelect))
                {
                    listEditButtons[i].Click();
                    return;
                }
            }

            Assert.Fail("Edit button:" + buttonToSelect + " not found.");
        }
    }
}
