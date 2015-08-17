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
    [TestComponent("CreateSite")]
    public class CreateSiteBtnTest : ScenarioTestComponent
    {

        protected override void RunSmoke()
        {
            CreateSiteBtn.ClickCreateSiteBtn();
            var siteDetails = ((TemplarDetails)Scenario).CreateSiteDetails.SiteDetails;
            if (siteDetails.SelectIndividualPages)
            {
                var selectPages = new SelectPagesToCreateSiteTest();
                selectPages.Execute(Scenario);
            }
            CreateSiteBtn.CheckMsg();
        }
    }
}
