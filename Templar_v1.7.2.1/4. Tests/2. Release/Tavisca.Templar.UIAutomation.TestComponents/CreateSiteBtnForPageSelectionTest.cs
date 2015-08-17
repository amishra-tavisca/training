using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("CreateSiteBtnForPageSelection")]
    public class CreateSiteBtnForPageSelectionTest :ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            var createSiteBtnForPageSelection = new CreateSiteBtnForPageSelection();
            createSiteBtnForPageSelection.ClickCreateSiteBtnBeforePageSelection();
        }
    }
}
