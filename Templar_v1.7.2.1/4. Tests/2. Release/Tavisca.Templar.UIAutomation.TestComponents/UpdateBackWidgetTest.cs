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
    [TestComponent("UpdateAndBackWidget")]
    public class UpdateBackWidgetTest : ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            var updateBackWidget = new UpdateBackWidget();
            updateBackWidget.ClickBackLink();
            
        }
    }
}
