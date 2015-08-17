using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Tavisca.Templar.UIAutomation.ScenarioObjects;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("ErrorHandling")]
    public class ErrorHandlingTest : ScenarioTestComponent
    {
        public ErrorHandlingScenario ErrorHandling { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();

            var errorHandlingWdgt = new ErrorHandling();
            errorHandlingWdgt.ClickErrorHandlingLink();


            foreach (var kvp in ErrorHandling.ListStatusCode)
            {
                errorHandlingWdgt.ClickAddBtn();
                errorHandlingWdgt.EnterNewDetails(kvp.Key, kvp.Value);
            }

            errorHandlingWdgt.SelectEditActions(ErrorHandling.ListStatusCode[0].Key);
            errorHandlingWdgt.EnterNewDetails("101", "EditedValue");
           
        }
        private void ExtractScenarioData()
        {
            ErrorHandling = ((TemplarDetails)Scenario).CreateSiteDetails.ErrorHandling;
        }
    }
}
