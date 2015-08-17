using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using OpenQA.Selenium;
using Tavisca.Templar.UIAutomation.DataBinders;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("UpdateWidgetAction")]
    public class UpdateWidgetActionTest : ScenarioTestComponent
    {
        public AdminDetails UpdateOrUpdateAndContinue { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();

            var updateWidgetAction = new UpdateWidgetAction();

            if (UpdateOrUpdateAndContinue.UpdateAndUpdateContinue == true)
            {
                updateWidgetAction.SelectAllCheckBox();
                updateWidgetAction.ClickUpdateBtn();
            }
            else 
            {
                updateWidgetAction.SelectAllCheckBox();
                updateWidgetAction.ClickUpdateAndContinueBtn();
            }
        }

        private void ExtractScenarioData()
        {
            UpdateOrUpdateAndContinue = ((TemplarDetails)Scenario).AdminDetails;
            
        }
    }
}
