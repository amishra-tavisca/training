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
    [TestComponent("Globalization")]
    public class GlobalizationTest : ScenarioTestComponent
    {
        public GlobalizationScenario Globalization { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();

            var globalizationWdgt = new Globalization();
            globalizationWdgt.ClickGlobalizationLink();
            globalizationWdgt.ClickAddGlobalCulturesLink();

            foreach (var cultureName in Globalization.ListCultures)
            {
                globalizationWdgt.SelectCultureChkbox(cultureName);
            }

            globalizationWdgt.ClickSaveBtn();
            globalizationWdgt.SelectDefaultCulture(Globalization.ListCultures[0]);


        }

        private void ExtractScenarioData()
        {
            Globalization = ((TemplarDetails)Scenario).CreateSiteDetails.Globalization;
        }
    }
}
