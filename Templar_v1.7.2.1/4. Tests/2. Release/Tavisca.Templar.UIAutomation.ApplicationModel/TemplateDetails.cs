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
    public class TemplateDetails
    {
        public void EnterTemplateDetails(string templateName, string description) 
        {
            TestManager.ControlMap["Templates.FieldTemplateName"].Type(templateName);
            TestManager.ControlMap["Templates.FieldTemplateDescription"].Reset().SendKeys(description);
        }

        public void SelectSiteDropDown(string SiteName)
        {
            TestManager.ControlMap["Templates.SelectSiteDropDown"].SelectComboBoxByText(SiteName);
        }

        public void SelectUploadFileCheckbox(bool isUplodFile) 
        {
            TestManager.ControlMap["Templates.CheckBoxUploadFile"].SelectCheckBox(isUplodFile);
        }

        public void EnterTemplatePath() 
        {
            var path = Environment.CurrentDirectory + "\\UploadTemplate.zip";
            TestManager.ControlMap["Templates.UploadButton"].SendKeys(path);
            Thread.Sleep(500);
            
        }

        public void ClickCreateTemplateBtn() 
        {
            TestManager.ControlMap["Templates.CreateTemplateBtn"].Click();            
        }
        public void CheckMsg()
        {
            TestManager.ControlMap["Templates.DivMsg"].WaitForControlExist(null);            
            var Msg = TestManager.ControlMap["Templates.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("created successfully"), "Failed to create Template.");
            Console.WriteLine(Msg);
            TestManager.ControlMap["Templates.DivMsg"].WaitForControlNotExist(null, false);
        }

    }
}
