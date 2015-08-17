using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using OpenQA.Selenium;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("UpdateWidgetfromOtherServer")]
    public class UpdateWidgetFromOtherServerTest : ScenarioTestComponent
    {
        public AdminDetails UpdatewidgetFromServer { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();
            PageNavigation.NavigateToUpdateWidget();

            var updateWidgetFromDiffrentServer = new UpdateWidgetFromOtherServer();

            updateWidgetFromDiffrentServer.EnterDeploymentToUpdateFrom(UpdatewidgetFromServer.DeploymentAddress);
            updateWidgetFromDiffrentServer.ClickLocateServerBtn();
            updateWidgetFromDiffrentServer.EnterAuthenticationDetails(UpdatewidgetFromServer.UserName, UpdatewidgetFromServer.UserPassword);
            updateWidgetFromDiffrentServer.ClickAuthenticateUserBtn();
            
        }

        private void ExtractScenarioData()
        {
            UpdatewidgetFromServer = ((TemplarDetails)Scenario).AdminDetails;
        }
       
    }
}
