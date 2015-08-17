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
    [TestComponent("PageDetails")]
    public class PageDetailsTest : ScenarioTestComponent
    {
        public SiteDashBoardDetails PageDetails { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();

            var addNewPageLink = new AddNewPageLink();

            addNewPageLink.SelectAddNewPageLink();

            var pageDetailsWdgt = new PageDetails();

            var dateTimestamp = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
            var pageName = PageDetails.PageName + dateTimestamp;
            var pageTitle = PageDetails.PageTitle + dateTimestamp;
            var pageUrl = PageDetails.PageUrl + dateTimestamp;
            TestManager.TestData.Add("CreatedPageName", pageName);
            TestManager.TestData.Add("CreatedPagetitle", pageTitle);
            TestManager.TestData.Add("CreatedPageUrl", pageUrl);

            pageDetailsWdgt.EnterpageDetails(pageName, pageTitle, pageUrl);

            pageDetailsWdgt.SelectOpenPageInDesignMode(PageDetails.OpenPageInDesignMode);
           
            pageDetailsWdgt.ClickAddPageBtn();
            pageDetailsWdgt.CheckMsg();
        }

        private void ExtractScenarioData()
        {
            PageDetails = ((TemplarDetails)Scenario).SiteDashBoardDetails;
        }
    }
}
