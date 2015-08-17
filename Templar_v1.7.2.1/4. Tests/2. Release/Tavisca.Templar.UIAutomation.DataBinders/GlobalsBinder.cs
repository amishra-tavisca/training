using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using System.Data;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;

namespace Tavisca.Templar.UIAutomation.DataBinders
{
    public class GlobalsBinder
    {
        public List<Globals>GetGlobals(Dictionary<string, string> dataRow) 
        {
            List <Globals> listGlobals = new List<Globals>();
            var templarScenarioRef = dataRow["Scenario_Scenario_1"].Split('|')[2];

            var refID = dataRow["TemplarScenario_Globals_" + templarScenarioRef + "_1"];
            if (string.IsNullOrEmpty(refID)) return null;

            var globalsRef = refID.Split('|');
            for (int i = 2; i < globalsRef.Length; i++) 
            {
                var global = new Globals();

                global.Language = dataRow["Globals_Language_" + globalsRef[i] + "_" + (i-1)];
                global.Country = dataRow["Globals_Country_" + globalsRef[i] + "_" + (i - 1)];
                global.ThemeName = dataRow["Globals_ThemeName_" + globalsRef[i] + "_" + (i - 1)];
                global.Description = dataRow["Globals_Description_" + globalsRef[i] + "_" + (i - 1)];
                global.FromThemeName = dataRow["Globals_FromThemeName_" + globalsRef[i] + "_" + (i - 1)];

                listGlobals.Add(global);
                
            }

            return listGlobals;
            
        }
    }
}
