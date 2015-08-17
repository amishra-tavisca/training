using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class SaveEditedSiteBtn
    {
        public void ClickSaveSiteBtn() 
        {
            TestManager.ControlMap["EditSite.SaveSiteButton"].Click();
        }
    }
}
