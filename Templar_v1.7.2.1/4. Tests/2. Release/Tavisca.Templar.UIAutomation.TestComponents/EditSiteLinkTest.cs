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
    [TestComponent("EditSiteLink")]
    public class EditSiteLinkTest : ScenarioTestComponent
    {
        public EditSiteDetailsScenario EditSiteDetails { get; set; }


        protected override void RunSmoke()
        {
            ExtractscenarioData();

            var editSiteLink = new EditSiteLink();

            var searchSite = new SearchSite();

            searchSite.EnterSiteName(EditSiteDetails.SiteNameToEdit);
            searchSite.ClickSearchIcon();

            editSiteLink.ClickEditSiteLink(EditSiteDetails.SiteNameToEdit);

        }

        protected virtual void ExtractscenarioData()
        {
            EditSiteDetails = ((EditSite)Scenario).EditSiteDetails;
        }
                 

    }
}
