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
    [TestComponent("SearchWidget")]
    public class SearchWidgetTest : ScenarioTestComponent
    {
        //public AdminDetails WidgetName { get; set; }


        protected override void RunSmoke()
        {
            //ExtractScenarioData();
            var searchWidget = new SearchWidget();
            var widgetName = TestManager.TestData.Get<string>("AddedWidgetName");

            bool isFound = searchWidget.SearchAddedWidget(widgetName);
            if (isFound) Console.WriteLine("Widget added successfully.");
            Assert.IsTrue(isFound, "Added Widget:" + widgetName + "notFound.");
        }

        /*private void ExtractScenarioData()
        {
            WidgetName = ((AdminDetails)Scenario);
        }*/
    }
}
