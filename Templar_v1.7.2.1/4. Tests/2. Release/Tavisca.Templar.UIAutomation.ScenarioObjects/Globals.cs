using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Model;

namespace Tavisca.Templar.UIAutomation.ScenarioObjects
{
    public class Globals : Scenario
    {
        public string Language { get; set; }
        public string Country { get; set; }
        public string ThemeName { get; set; }
        public string Description { get; set; }
        public string FromThemeName { get; set; }
        
    }
}
