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
    [TestComponent("SelectPagesToCreateSite")]
    public class SelectPagesToCreateSiteTest : ScenarioTestComponent
    {
        public PageNameScenario PageName { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();
            CreateSiteBtn.ClickCreateSiteBtn(); 
            var SelectPagesToCreateSiteWdgt = new SelectPagesToCreateSite();

            foreach (var pageName in PageName.ListPageName)
            {
                SelectPagesToCreateSiteWdgt.SelectPagesCbx(pageName);
            }

            SelectPagesToCreateSiteWdgt.ClickCreateBtn();

        }

        private void ExtractScenarioData()
        {
            PageName = ((TemplarDetails)Scenario).CreateSiteDetails.PageName;
        }
    }
}
