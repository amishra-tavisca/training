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
    [TestComponent("EditSiteDetails")]
    public class EditSiteDetailsTest : ScenarioTestComponent
    {
        public EditSiteDetailsScenario EditSiteDetails { get; set; }
        //public SiteDetailsScenario SiteDetails { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();

            var editSitedetailsWdgt = new EditSiteDetails();

            var siteDetailsWdgt = new SiteDetails();

            //var dateTimeStamp = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
            var siteName = EditSiteDetails.Name; //+ dateTimeStamp;
            TestManager.TestData.Add("CreatedSiteName", siteName);
            siteDetailsWdgt.EnterSiteDetails(siteName, EditSiteDetails.Url, EditSiteDetails.Description);

            editSitedetailsWdgt.AddMappedToDomain(EditSiteDetails.MappedToDomain);
            editSitedetailsWdgt.ClickAddMappedToDomainLink();
            siteDetailsWdgt.SelectStatusDropDown(EditSiteDetails.Status);

        }

        protected virtual void ExtractScenarioData()
        {
            EditSiteDetails = ((EditSite)Scenario).EditSiteDetails;
        }

       
    }
}
