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
    [TestComponent("TemplateDetails")]
    public class TemplateDetailsTest : ScenarioTestComponent
    {
        public CreateTemplateDetails TemplateDetails { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();

            PageNavigation.NavigateToTemplates();
           
            var createNewTemplateLink = new CreateNewTemplate();
            createNewTemplateLink.SelectCreateNewTemplate();

            var templateDetailswdgt = new TemplateDetails();

            var dateTimeStamp = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
            var templateName = TemplateDetails.Name + dateTimeStamp;
            TestManager.TestData.Add("CreatedTemplateName", templateName);
            templateDetailswdgt.EnterTemplateDetails(templateName, TemplateDetails.Description);
            
            templateDetailswdgt.SelectUploadFileCheckbox(TemplateDetails.CreateTemplateFromFile);
            if (TemplateDetails.CreateTemplateFromFile== true)
            {
                templateDetailswdgt.EnterTemplatePath();
               
            }
            else 
            {
                templateDetailswdgt.SelectSiteDropDown(TemplateDetails.SiteName);
            }

            templateDetailswdgt.ClickCreateTemplateBtn();
            templateDetailswdgt.CheckMsg();
        }

        private void ExtractScenarioData()
        {
            TemplateDetails = ((TemplarDetails)Scenario).CreateTemplateDetails;
        }
    }
}
