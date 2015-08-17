using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class AddNewPageLink
    {
        public void SelectAddNewPageLink() 
        {
            TestManager.ControlMap["PageDashBoard.LinkAddNewPage"].Reset().Click();
        }
    }
}
