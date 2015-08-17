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
    public class Themes
    {
        public void ClickThemesLink()
        {
            TestManager.ControlMap["Themes.LinkThemes"].Click();
        }

        public void ClickAddGlobalThemesLink()
        {
            TestManager.ControlMap["Themes.LinkAddGlobalTheme"].Click();
        }

        public void SelectAllThemesCheckbox(bool selectGlobalTheme)
        {
            TestManager.ControlMap["Themes.CheckBoxSelectAllGlobalThemes"].SelectCheckBox(selectGlobalTheme);
        }


        public void SelectThemeChkbox(string chkboxLabelToSelect)
        {
            var listItems = TestManager.ControlMap["Themes.ListSelectThemeCbx"].Reset().HtmlControl.GetChildren();
            foreach (var item in listItems)
            {
                var chkbox = new HtmlCheckBox((HtmlControl)item.GetChildren()[0]);
                var dataValue = chkbox.GetProperty("data-value");
                if (dataValue.Equals(chkboxLabelToSelect))
                {
                    chkbox.Checked = true;
                    return;
                }
            }
        }

        public void ClickSaveBtn()
        {
            TestManager.ControlMap["Themes.SaveButton"].Click();
        }

        public void SelectDefaultTheme(string radioToSelect)
        {
            var listItems = TestManager.ControlMap["Themes.RadioDefaultgTheme"].Reset().GetMatchingVisibleControls();
            foreach (var item in listItems)
            {
                var dataValue = item.HtmlControl.GetProperty("data-value");
                if (dataValue.Equals(radioToSelect))
                {
                    item.SelectRadioButton();
                    return;
                }
            }
            Assert.Fail("Radio button  for theme:" + radioToSelect + " not found.");
        }
        
        /*public void ClickCancleBtn()
        {
            TestManager.ControlMap["Themes.CancleButton"].Click();
        }*/

        public void ClickAddSiteThemeLink()
        {
            TestManager.ControlMap["Themes.LinkAddSiteTheme"].Click();
        }

        public void ClickOkBtn()
        {
            TestManager.ControlMap["Themes.OKButton"].Click();
        }

    }
}
