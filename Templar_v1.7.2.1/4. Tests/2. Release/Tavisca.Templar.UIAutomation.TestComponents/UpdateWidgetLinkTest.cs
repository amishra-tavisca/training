using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("UpdateWidgetLink")]
    public class UpdateWidgetLinkTest : ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            UpdateWidgetLink.ClickUpdateWidgetLink();
        }
    }
}
