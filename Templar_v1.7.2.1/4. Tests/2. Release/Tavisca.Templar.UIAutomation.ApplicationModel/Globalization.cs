using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.TravelNxt.UIAutomation.Framework.Model;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class Globalization
    {
        public void ClickGlobalizationLink()
        {
            TestManager.ControlMap["Globalization.LinkGlobalization"].Click();
        }

        public void ClickAddGlobalCulturesLink()
        {
            TestManager.ControlMap["Globalization.LinkAddGlobalCulture"].Click();
        }

        public void SelectAllCulturesChkbox(bool selectGlobalCultures) 
        {
            TestManager.ControlMap["Globalization.CheckBoxSelectAllGlobalCulture"].SelectCheckBox(selectGlobalCultures);
        }

        public void SelectCultureChkbox(string chkboxLableToSelect) 
        {
            var listItems = TestManager.ControlMap["Globalization.ListSelectCultureCbx"].Reset().HtmlControl.GetChildren();
            foreach (var item in listItems) 
            {
                var chkbox = (HtmlControl)item.GetChildren()[1];
                var dataValue = chkbox.InnerText.Trim();
                if (dataValue.Equals(chkboxLableToSelect)) 
                {
                    var checkbox = new HtmlCheckBox((HtmlControl)item.GetChildren()[0]);
                    checkbox.Checked = true;
                    return;
                }
            }

        }

        public void ClickSaveBtn() 
        {
            TestManager.ControlMap["Globalization.SaveButton"].Click();
        }

        public void SelectDefaultCulture(string radioToSelect)
        {
            var listItems = TestManager.ControlMap["Globalization.RadioDefaultGlobalCulture"].Reset().GetMatchingVisibleControls();
            foreach (var item in listItems)
            {                
                    item.SelectRadioButton();
                    return;               
            }
            Assert.Fail("Defult culture:" + radioToSelect + " not found.");
        }
    }
}
