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
    [TestComponent("AddWidget")]
    public class AddWidgetTest : ScenarioTestComponent
    {
        public AdminDetails WidgetDetail { get; set; }
        protected override void RunSmoke()
        {
            ExtractScenarioData();
            PageNavigation.NavigateToWidget();
            var addWidget = new AddWidget();
            addWidget.SelectAddWidgetLink();

            var dateTimestamp = DateTime.Now.ToString();
            var widgetName = WidgetDetail.WidgetName + dateTimestamp;
            TestManager.TestData.Add("AddedWidgetName", widgetName);
            
            addWidget.EnterWidgetDetails(widgetName, WidgetDetail.WidgetUrl, WidgetDetail.WidgetDescription, WidgetDetail.WidgetIcon, WidgetDetail.WidgetState);
            addWidget.ClickAddWidgetBtn();

        }

        private void ExtractScenarioData()
        {
            WidgetDetail = ((TemplarDetails)Scenario).AdminDetails;
        }
    }
}
