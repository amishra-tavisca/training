using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.Templar.UIAutomation.ScenarioObjects;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("DeleteTemplate")]
    class DeleteTemplateTest : ScenarioTestComponent
    {
        public CreateTemplateDetails TemplateDetails { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();
            PageNavigation.NavigateToTemplates();
            var deleteTemplate = new DeleteTemplate();
            var templateName = TestManager.TestData.Get<string>("CreatedTemplateName");
            deleteTemplate.CheckDeleteTemplate(templateName);
            deleteTemplate.ClickDeleteButton();
            deleteTemplate.ClickDeleteOKButton();

        }

        private void ExtractScenarioData()
        {
            TemplateDetails = ((TemplarDetails)Scenario).CreateTemplateDetails;
        }
        
    }
}
