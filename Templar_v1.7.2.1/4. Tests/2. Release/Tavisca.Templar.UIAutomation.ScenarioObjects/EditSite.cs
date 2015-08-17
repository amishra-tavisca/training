using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Model;


namespace Tavisca.Templar.UIAutomation.ScenarioObjects
{
    
    public class EditSiteDetailsScenario
    {
        public string SiteNameToEdit { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public string MappedToDomain { get; set; }
        public string Status { get; set; }
                
    }
    public class EditThemeScenario 
    {
        public string ThemeName { get; set; }
        public string ThemeDescription { get; set; }
        public string FromSite { get; set; }
        public string FromTheme { get; set; }

        public List<string> ListGlobalThemes { get; set; }

    }

    public class EditSite : Scenario
    {
        public EditSite() 
        {
            EditSiteDetails = new EditSiteDetailsScenario();
            EditThemes = new EditThemeScenario();
        }

        public EditSiteDetailsScenario EditSiteDetails { get; set; }
        public EditThemeScenario EditThemes { get; set; }
    }
}
