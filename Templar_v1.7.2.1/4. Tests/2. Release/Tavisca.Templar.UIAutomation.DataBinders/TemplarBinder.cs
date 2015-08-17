using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using System.Data;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;

namespace Tavisca.Templar.UIAutomation.DataBinders
{
    public class TemplarBinder
    {
        public TemplarDetails GetTemplarDetails(Dictionary<string, string> dataRow)
        {
            var templarScenario = new TemplarDetails();
            var createSitebinder = new CreateSiteBinder();
            templarScenario.CreateSiteDetails = createSitebinder.GetCreateSiteDetails(dataRow);
            var templatebinder = new TemplatesBinder();
            templarScenario.CreateTemplateDetails = templatebinder.GetCreateTemplateDetails(dataRow);
            var siteDashBoardbinder = new SiteDashBoardBinder();
            templarScenario.SiteDashBoardDetails = siteDashBoardbinder.GetSiteDashBoardDetails(dataRow);
            var globalsbinder = new GlobalsBinder();
            templarScenario.Globals = globalsbinder.GetGlobals(dataRow);
            var adminbinder = new AdminBinder();
            templarScenario.AdminDetails = adminbinder.GetAdminDetails(dataRow);

            return templarScenario;

        }
    }
}
