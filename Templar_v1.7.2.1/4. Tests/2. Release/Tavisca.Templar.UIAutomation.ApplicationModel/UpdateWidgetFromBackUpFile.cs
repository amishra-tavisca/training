using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;
using OpenQA.Selenium;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class UpdateWidgetFromBackUpFile
    {
        public void ClickUpdateFromBackUPFile()
        {
            TestManager.ControlMap["Admin.UpdateFromBackupFileBtn"].Click();
        }
        public void ClickUploadBackUpFileBtn()
        {
            var ele = TestManager.ControlMap["Admin.SelectFileUplodBtn"].HtmlControl.GetChildren()[0].Element;
            var path = Environment.CurrentDirectory + "\\Widgets.zip";
            ele.SendKeys(path);
        }
        public void ClickShowdiffBtn() 
        {
            TestManager.ControlMap["Admin.ShowDiffBtn"].WaitForControlExist(null);
            Thread.Sleep(1000);
            TestManager.ControlMap["Admin.ShowDiffBtn"].Click();
            TestManager.ControlMap["Admin.LinkCancel"].WaitForControlNotExist(null);
            
            if (TestManager.ControlMap["Admin.DivDiffModalPopUp"].WaitForControlExist(10000, false)==false)
            {                
                Assert.Fail("Show Diff PopUp Not Open");
            }
        }
    }
}
