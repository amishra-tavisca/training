using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using System.Data;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;

namespace Tavisca.Templar.UIAutomation.DataBinders
{
    public class TemplatesBinder
    {
        public CreateTemplateDetails GetCreateTemplateDetails(Dictionary<string, string> dataRow) 
        {
            var createTemplate = new CreateTemplateDetails();
            var templarScenarioRef = dataRow["Scenario_Scenario_1"].Split('|')[2];
            var refID = dataRow["TemplarScenario_Templates_" + templarScenarioRef + "_1"];
            if (string.IsNullOrEmpty(refID)) return null;

            var templatesRef = refID.Split('|')[2];
            refID=dataRow["Templates_TemplateDetails_"+templatesRef+"_1"];
            if (string.IsNullOrEmpty(refID)) return null;
            var templateDetailsRef = refID.Split('|')[2];
            createTemplate.Name = dataRow["TemplateDetails_Name_" + templateDetailsRef + "_1"];
            createTemplate.Description = dataRow["TemplateDetails_Description_" + templateDetailsRef + "_1"];
            createTemplate.SiteName = dataRow["TemplateDetails_SiteName_" + templateDetailsRef + "_1"];
            createTemplate.CreateTemplateFromFile = dataRow["TemplateDetails_CreateTemplateFromFile_" + templateDetailsRef + "_1"].ToBool();
            return createTemplate;
        }
    }
}
