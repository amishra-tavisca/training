using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Model;

namespace Tavisca.Templar.UIAutomation.ScenarioObjects
{    
       
    public class CreateTemplateDetails : Scenario
    {
        public CreateTemplateDetails()
        {
            
            
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CreateTemplateFromFile { get; set; }
        public string SiteName { get; set; }       
    }
}
