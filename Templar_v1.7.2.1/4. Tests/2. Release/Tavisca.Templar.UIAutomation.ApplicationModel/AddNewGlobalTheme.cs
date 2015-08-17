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
    public class AddNewGlobalTheme
    {
        public void ClickOnAddNewTheme() 
        {
            TestManager.ControlMap["Globals.LinkAddNewTheme"].Click();

        }
        public void EnterThemeDetails(string themeName, string description) 
        {
            TestManager.ControlMap["Globals.FieldThemeName"].Type(themeName);
            TestManager.ControlMap["Globals.FieldThemeDescription"].SendKeys(description);
        }
        public void SelectThemeDropDown(string FromThemeName) 
        {
            TestManager.ControlMap["Globals.FromThemeDropDown"].SelectComboBoxByText(FromThemeName);
        }
        public void ClickAddThemeBtn() 
        {
            TestManager.ControlMap["Globals.AddThemeBtn"].Click();
            CheckMsg();
            TestManager.ControlMap["Globals.DivMsg"].WaitForControlExist(3000, false);
            TestManager.ControlMap["Globals.DivMsg"].WaitForControlNotExist(null);
            Thread.Sleep(500);
        }
        public void CheckMsg()
        {
            TestManager.ControlMap["Globals.DivMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["Globals.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("created successfully."), "Failed to add Global Theme.");
            Console.WriteLine(Msg);
        }
    }
}
