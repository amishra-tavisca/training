using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("CancleSite")]
    public class CancleSiteTest : ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            var CancleSiteWdgt = new CancleSite();
            CancleSiteWdgt.ClickCancleSiteBtn();

        }
    }
}
