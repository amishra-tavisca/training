using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Model;

namespace Tavisca.Templar.UIAutomation.ScenarioObjects
{   

    public class SiteDashBoardDetails : Scenario 
    {
        public string SiteName { get; set; }
        public string PageName { get; set; }
        public string PageTitle { get; set; }
        public string PageUrl { get; set; }
        public bool OpenPageInDesignMode { get; set; }
        public List<string> ListItemToPublish { get; set; } 
    }
}
