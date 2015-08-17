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
    public class UpdateWidgetFromOtherServer
    {
        public void EnterDeploymentToUpdateFrom(string deploymentAddress) 
        {
            TestManager.ControlMap["Admin.FieldDeploymentToUpdateFrom"].Type(deploymentAddress);
        }
        public void ClickLocateServerBtn() 
        {
            TestManager.ControlMap["Admin.LocateServerBtn"].Click();
        }
        
        public void EnterAuthenticationDetails(string userName, string password) 
        {
            TestManager.ControlMap["Admin.FieldUserName"].Type(userName);
            TestManager.ControlMap["Admin.FieldServerPassword"].Type(password);
        }
        public void ClickAuthenticateUserBtn() 
        {
            TestManager.ControlMap["Admin.AuthenticateUserBtn"].WaitForControlExist(null);            
            TestManager.ControlMap["Admin.AuthenticateUserBtn"].Click();
            if (TestManager.ControlMap["Admin.DivDiffModalPopUp"].WaitForControlExist(10000, false) == false)
            {
                 Assert.Fail("Show Diff PopUp Not Open");
            }
        }
    }
}
