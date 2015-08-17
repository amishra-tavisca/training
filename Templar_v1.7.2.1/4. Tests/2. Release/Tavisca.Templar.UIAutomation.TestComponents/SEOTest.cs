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
    [TestComponent("SEO")]
    public class SEOTest : ScenarioTestComponent 
    {
        public SEOScenario SEO { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();

            var seoWdgt = new SEO();

            seoWdgt.ClickSEOLink();
            seoWdgt.EnterHeaderCode(SEO.HeaderCode);
            seoWdgt.EnterFooterCode(SEO.FooterCode);
            
            foreach (var kvp in SEO.ListMetaTagName)
            {
                seoWdgt.ClickAddBtn();
                seoWdgt.EnterNewDetails(kvp.Key, kvp.Value);
            }
            
            seoWdgt.SelectEditMetaTag(SEO.ListMetaTagName[0].Key);
            seoWdgt.EnterNewDetails("EditKey", "EditedValue");
            //seoWdgt.SaveNewDetails();

        }


        private void ExtractScenarioData()
        {
            SEO = ((TemplarDetails)Scenario).CreateSiteDetails.SEO;
        }
    }
}
