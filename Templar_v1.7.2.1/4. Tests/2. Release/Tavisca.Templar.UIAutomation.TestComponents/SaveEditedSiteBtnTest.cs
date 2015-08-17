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
    [TestComponent("SaveSiteBtn")]
    public class SaveEditedSiteBtnTest : ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            var SaveSiteWdgt = new SaveEditedSiteBtn();
            SaveSiteWdgt.ClickSaveSiteBtn();
        }
    }
}
