using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using System.Data;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;

namespace Tavisca.Templar.UIAutomation.DataBinders
{
    public class AdminBinder
    {
        
        public AdminDetails GetAdminDetails(Dictionary<string, string> dataRow) 
        {
            var admin = new AdminDetails();
            var templarScenarioRef = dataRow["Scenario_Scenario_1"].Split('|')[2];
            var refID = dataRow["TemplarScenario_Admin_" + templarScenarioRef + "_1"];
            if (string.IsNullOrEmpty(refID)) return null;

            var adminRef = refID.Split('|')[2];

            admin.LoginName = dataRow["Admin_LoginName_" + adminRef + "_1"];
            admin.Password = dataRow["Admin_Password_" + adminRef + "_1"];
            admin.FirstName = dataRow["Admin_FirstName_" + adminRef + "_1"];
            admin.LastName = dataRow["Admin_LastName_" + adminRef + "_1"];
            admin.UserRole = dataRow["Admin_UserRole_" + adminRef + "_1"];
            admin.DisableUser = dataRow["Admin_DisableUser_" + adminRef + "_1"].ToBool();
            admin.WidgetName = dataRow["Admin_WidgetName_" + adminRef + "_1"];
            admin.WidgetUrl = dataRow["Admin_WidgetUrl_" + adminRef + "_1"];
            admin.WidgetDescription = dataRow["Admin_WidgetDescription_" + adminRef + "_1"];
            admin.WidgetIcon = dataRow["Admin_WidgetIcon_" + adminRef + "_1"];
            admin.WidgetState = dataRow["Admin_WidgetState_" + adminRef + "_1"];
            admin.DeploymentAddress = dataRow["Admin_DeploymentAddress_" + adminRef + "_1"];
            admin.UserName = dataRow["Admin_UserName_" + adminRef + "_1"];
            admin.UserPassword = dataRow["Admin_UserPassword_" + adminRef + "_1"];
            admin.UpdateAndUpdateContinue = dataRow["Admin_UpdateAndUpdateContinue_" + adminRef + "_1"].ToBool();
            return admin;

        }
    }
}
