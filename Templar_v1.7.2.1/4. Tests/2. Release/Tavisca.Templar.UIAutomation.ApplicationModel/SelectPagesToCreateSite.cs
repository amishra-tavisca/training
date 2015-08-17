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
    public class SelectPagesToCreateSite
    {

        public void SelectPagesCbx(string chkboxToSelect)
        {
            var ListItemsChkbx = TestManager.ControlMap["SelectPagesToCreate.ListPageCbx"].Reset().GetMatchingVisibleControls();

            var ListItemsPageName = TestManager.ControlMap["SelectPagesToCreate.ListPageName"].Reset().GetMatchingVisibleControls().Select(ctrl=>ctrl.GetInnerText()).ToList();


            for (int i = 0; i < ListItemsPageName.Count; i++)
			{
			 if (ListItemsPageName[i].Equals(chkboxToSelect))
                {
                    ListItemsChkbx[i-1].SelectCheckBox(true);
                    return;
                }
			}            
        }

        public void ClickCreateBtn()
        {
            TestManager.ControlMap["SelectPagesToCreate.CreateButton"].Click();            
        }
        public void CheckMsg()
        {
            TestManager.ControlMap["CreateSite.DivMsg"].WaitForControlExist(null);
            var Msg = TestManager.ControlMap["CreateSite.DivMsg"].GetInnerText();
            Assert.IsTrue(Msg.Contains("created"), "Failed to create site.");
            Console.WriteLine(Msg);
        }
    }
}
