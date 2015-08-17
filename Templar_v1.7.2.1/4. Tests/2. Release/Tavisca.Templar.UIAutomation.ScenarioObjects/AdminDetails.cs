using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Model;

namespace Tavisca.Templar.UIAutomation.ScenarioObjects
{
    public class AdminDetails : Scenario
    {
        public string LoginName { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public bool DisableUser { get; set; }
        public string UserRole { get; set; }
        public string WidgetName { get; set; }
        public string WidgetUrl { get; set; }
        public string WidgetDescription { get; set; }
        public string WidgetIcon { get; set; }
        public string WidgetState { get; set; }
        public string DeploymentAddress { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public bool UpdateAndUpdateContinue { get; set; }                                         

    }
}
