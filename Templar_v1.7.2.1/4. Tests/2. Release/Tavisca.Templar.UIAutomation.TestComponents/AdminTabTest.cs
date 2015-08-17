using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("AdminTab")]

    public class AdminTabTest : ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            AdminTab.SelectAdminTabLink();
        }
    }
}
