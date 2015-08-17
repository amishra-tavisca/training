using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Model;

namespace Tavisca.Templar.UIAutomation.ScenarioObjects
{
    public class TemplarDetails : Scenario
    {
        public AdminDetails AdminDetails { get; set; }
        public CreateSiteDetails CreateSiteDetails { get; set; }
        public EditSite EditSite { get; set; }
        public List<Globals> Globals { get; set; }
        public SiteDashBoardDetails SiteDashBoardDetails { get; set; }
        public CreateTemplateDetails CreateTemplateDetails { get; set; }
        
    }
}
