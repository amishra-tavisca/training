using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
     public class SEO
    {
        public void ClickSEOLink()
        {
            TestManager.ControlMap["SEO.LinkSEO"].Click();
        }
        public void EnterHeaderCode(string headerCode)
        {
            TestManager.ControlMap["SEO.FieldHeaderCode"].SendKeys(headerCode);
            
        }
        public void EnterFooterCode(string footerCode)
        {
            TestManager.ControlMap["SEO.FieldFooterCode"].SendKeys(footerCode);

        }
        public void ClickAddBtn()
        {
            TestManager.ControlMap["SEO.AddButton"].Click();

        }
        public void EnterNewDetails(string TagName, string TagDescription)
        {
            TestManager.ControlMap["SEO.FieldTagName"].Reset().Type(TagName);
            TestManager.ControlMap["SEO.FieldTagDescription"].Reset().SendKeys(TagDescription);
            SaveNewDetails();

        }
        public void SaveNewDetails()
        {
            TestManager.ControlMap["SEO.SaveButton"].Reset().Click();

        }
        public void SelectEditMetaTag(string buttonToSelect)
        {
           
           var listItems = TestManager.ControlMap["SEO.TitleITagName"].Reset().GetMatchingVisibleControls();
           var listEditButtons =  TestManager.ControlMap["SEO.SelectEditBtn"].Reset().GetMatchingVisibleControls();

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
