using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using System.Data;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;

namespace Tavisca.Templar.UIAutomation.DataBinders
{
    public class SiteDashBoardBinder
    {
        public SiteDashBoardDetails GetSiteDashBoardDetails(Dictionary<string, string> dataRow) 
        {
            var siteDashBoard = new SiteDashBoardDetails();
            var templarScenarioRef = dataRow["Scenario_Scenario_1"].Split('|')[2];
            var refID = dataRow["TemplarScenario_SiteDashBoard_" + templarScenarioRef + "_1"];
            if (string.IsNullOrEmpty(refID)) return null;

            var sideDashBoardRef = refID.Split('|')[2];
            siteDashBoard.SiteName = dataRow["SiteDashBoard_Name_" + sideDashBoardRef + "_1"];
            siteDashBoard.PageName = dataRow["SiteDashBoard_PageName_" + sideDashBoardRef + "_1"];
            siteDashBoard.PageTitle = dataRow["SiteDashBoard_PageTitle_" + sideDashBoardRef + "_1"];
            siteDashBoard.PageUrl = dataRow["SiteDashBoard_PageUrl_" + sideDashBoardRef + "_1"];
            siteDashBoard.OpenPageInDesignMode = dataRow["SiteDashBoard_OpenPageInDesignMode_" + sideDashBoardRef + "_1"].ToBool();
            siteDashBoard.ListItemToPublish = dataRow["SiteDashBoard_PublishSiteItems_" + sideDashBoardRef + "_1"].Split('|').ToList();
            return siteDashBoard;
        }
    }
}
