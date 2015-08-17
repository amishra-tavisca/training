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
    [TestComponent("SiteLayout")]
    public class SiteLayoutTest : ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            var SiteLayoutWdgt = new SiteLayout();
            SiteLayoutWdgt.SelectSiteLayoutLink();
        }
    }
}
