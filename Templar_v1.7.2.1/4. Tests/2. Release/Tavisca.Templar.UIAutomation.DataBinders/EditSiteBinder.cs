using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using System.Data;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;

namespace Tavisca.Templar.UIAutomation.DataBinders
{
    public class EditSiteBinder
    {
        public EditSite GetEditsite(Dictionary<string, string> dataRow) 
        {
            var editSite = new EditSite();
            var templarScenarioRef = dataRow["Scenario_Scenario_1"].Split('|')[2];

            var refID = dataRow["TemplarScenario_EditSites_" + templarScenarioRef + "_1"];
            if (string.IsNullOrEmpty(refID)) return null;

            var editSiteDetailRef = refID.Split('|')[2];

            editSite.EditSiteDetails.SiteNameToEdit = dataRow["EditSiteDetails_SiteNameToEdit_" + editSiteDetailRef + "_1"];
            editSite.EditSiteDetails.Name = dataRow["EditSiteDetails_Name_" + editSiteDetailRef + "_1"];
            editSite.EditSiteDetails.Url = dataRow["EditSiteDetails_Url_" + editSiteDetailRef + "_1"];
            editSite.EditSiteDetails.Description = dataRow["EditSiteDetails_Description_" + editSiteDetailRef + "_1"];
            editSite.EditSiteDetails.MappedToDomain = dataRow["EditSiteDetails_MappedToDomain_" + editSiteDetailRef + "_1"];
            editSite.EditSiteDetails.Status = dataRow["EditSiteDetails_Status_" + editSiteDetailRef + "_1"];

            editSite.EditThemes = GetEditThemeDetails(dataRow, editSiteDetailRef);
            return editSite;
        }

        private EditThemeScenario GetEditThemeDetails(Dictionary<string, string> dataRow, string editSiteDetailRef) 
        {
            var str = dataRow["EditSite_EditThemes_" + editSiteDetailRef + "_1"];
            if (string.IsNullOrEmpty(str)) return null;
            var editThemeRef = str.Split('|')[2];
            var editTheme = new EditThemeScenario();
            editTheme.ThemeName = dataRow["EditThemes_ThemeName_" + editThemeRef + "_1"];
            editTheme.ThemeDescription = dataRow["EditThemes_ThemeDescription_" + editThemeRef + "_1"];
            editTheme.FromSite = dataRow["EditThemes_FromSite_" + editThemeRef + "_1"];
            editTheme.FromTheme = dataRow["EditThemes_FromTheme_" + editThemeRef + "_1"];

            editTheme.ListGlobalThemes = dataRow["EditThemes_ListGlobalThemes_" + editThemeRef + "_1"].Split('|').ToList();

            return editTheme;
        }
        
    }
}
