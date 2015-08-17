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
    public class AddGlobalCulture
    {
        public void SelectAddCultureLink() 
        {
            Thread.Sleep(500);
            TestManager.ControlMap["Globals.LinkAddCulture"].Click();
        }

        public void SelectLanguageDropDown(string Language) 
        {
            TestManager.ControlMap["Globals.LanguageDropDown"].WaitForControlExist(null);
            
            TestManager.ControlMap["Globals.LanguageDropDown"].SelectComboBoxByText(Language);
        }
        public void SelectCountryDropDown(string CountryName) 
        {
            TestManager.ControlMap["Globals.CountryDropDown"].WaitForControlExist(null);
            TestManager.ControlMap["Globals.CountryDropDown"].SelectComboBoxByText(CountryName);
        }
        public void ClickAddCultureBtn() 
        {
            TestManager.ControlMap["Globals.AddCultureBtn"].Click();
            /*CheckMsg();
            TestManager.ControlMap["Globals.DivMsg"].WaitForControlExist(2000, false);
            TestManager.ControlMap["Globals.DivMsg"].WaitForControlNotExist(null);
            Thread.Sleep(500);*/
        }
        /*public void CheckMsg()
        {
            TestManager.ControlMap["Globals.DivMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["Globals.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("created successfully"), "Failed to create Template.");
            Console.WriteLine(Msg);
        }*/

    }
}
