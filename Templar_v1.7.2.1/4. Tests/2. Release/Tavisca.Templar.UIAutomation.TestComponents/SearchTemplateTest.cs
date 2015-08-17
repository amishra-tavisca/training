using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("SearchTemplate")]
    public class SearchTemplateTest : ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            var searchTemplate = new SearchTemplate();
            var deleteTemplate = new DeleteTemplate();

            var templateName = TestManager.TestData.Get<string>("CreatedTemplateName");
            var isFound = searchTemplate.SearchCreatedTemplate(templateName);
            if (isFound) Console.WriteLine("Template: " + templateName + " Searched successfully.");
            Assert.IsTrue(isFound, "Created Template:" + templateName + " not found. ");

            deleteTemplate.CheckDeleteTemplate(templateName);
            deleteTemplate.ClickDeleteButton();
            deleteTemplate.ClickDeleteOKButton();
            //deleteTemplate.CheckMsg();
           
            // There are two ways . either use msg comes on UI or Search again after deleting template.
            isFound = searchTemplate.SearchCreatedTemplate(templateName);
            if (isFound==false) Console.WriteLine("After deleting template:" + templateName + ", search again same template and now deleted Template is not found.");
            Assert.IsTrue(isFound == false, "After deleting Template: " + templateName + " template searched.It means template is not deleted yet.");

        }
    }
}
