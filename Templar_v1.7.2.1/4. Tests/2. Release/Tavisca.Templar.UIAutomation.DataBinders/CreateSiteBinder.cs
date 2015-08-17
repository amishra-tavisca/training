using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using System.Data;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;

namespace Tavisca.Templar.UIAutomation.DataBinders
{
    public class CreateSiteBinder
    {
        public CreateSiteDetails GetCreateSiteDetails(Dictionary<string,string> dataRow)
        {
            
            var templarScenarioRef=dataRow["Scenario_Scenario_1"].Split('|')[2];
            var refID = dataRow["TemplarScenario_CreateSite_" + templarScenarioRef + "_1"];
            if (string.IsNullOrEmpty(refID)) return null;
            
            var createSite = new CreateSiteDetails();
            var createSiteRef = dataRow["TemplarScenario_CreateSite_" + templarScenarioRef + "_1"].Split('|')[2];


            var siteDetailsRef = dataRow["CreateSite_SiteDetails_" + createSiteRef + "_1"].Split('|')[2];
            createSite.SiteDetails.Name = dataRow["SiteDetails_Name_"+siteDetailsRef+"_1"];
            createSite.SiteDetails.Url = dataRow["SiteDetails_Url_"+siteDetailsRef+"_1"];
            createSite.SiteDetails.Description = dataRow["SiteDetails_Description_" + siteDetailsRef + "_1"];
            createSite.SiteDetails.CreateSiteFromScratch = dataRow["SiteDetails_CreateSiteFromScratch_"+siteDetailsRef+"_1"].ToBool();
            createSite.SiteDetails.Status = dataRow["SiteDetails_Status_" + siteDetailsRef + "_1"];
            createSite.SiteDetails.Template = dataRow["SiteDetails_Template_"+siteDetailsRef+"_1"];
            createSite.SiteDetails.SelectIndividualPages = dataRow["SiteDetails_SelectIndividualPages_"+siteDetailsRef+"_1"].ToBool();
                      
            createSite.Themes.ListThemes = dataRow["CreateSite_Themes_"+createSiteRef+"_1"].Split('|').ToList();
            
            var scriptsRef = dataRow["CreateSite_Script_"+createSiteRef+"_1"].Split('|');
           
            for (int i = 2; i < scriptsRef.Length; i++)
            {
                var key = dataRow["Script_Key_"+scriptsRef[i]+"_"+(i-1)];
                var value = dataRow["Script_Value_" + scriptsRef[i] + "_" + (i - 1)];
                var keyValuePair = new KeyValuePair<string,string> ( key, value );
                createSite.Script.ListScript.Add(keyValuePair);
            }

            createSite.SEO = GetSEODetails(dataRow, createSiteRef);
            createSite.ErrorHandling = GetErrorHandlingDetails(dataRow, createSiteRef);

            createSite.Globalization.ListCultures = dataRow["CreateSite_Globalization_" + createSiteRef + "_1"].Split('|').ToList();

            createSite.PageName.ListPageName = dataRow["CreateSite_PageName_" + createSiteRef + "_1"].Split('|').ToList();

            
            return createSite;
        }

        private SEOScenario GetSEODetails(Dictionary<string, string> dataRow, string createSiteRef)
        {
            var str=dataRow["CreateSite_SEO_" + createSiteRef + "_1"];
            if(string.IsNullOrEmpty(str)) return null;
            var seoRef = str.Split('|')[2];
            var seo = new SEOScenario();
            seo.HeaderCode = dataRow["SEO_HeaderCode_" + seoRef + "_1"];
            seo.FooterCode = dataRow["SEO_FooterCode_" + seoRef + "_1"];
            var metaDataString = dataRow["SEO_MetaData_" + seoRef + "_1"];
            var metaDataKeyValues = metaDataString.Split('|');
            foreach (var item in metaDataKeyValues)
            {
                var kvp = item.Split(':');
                seo.ListMetaTagName.Add(new KeyValuePair<string, string>(kvp[0], kvp[1]));
            }
            return seo;
        }

        private ErrorHandlingScenario GetErrorHandlingDetails(Dictionary<string, string> dataRow, string createSiteRef)
        {
            var str = dataRow["CreateSite_ErrorHandling_" + createSiteRef + "_1"];
            if (string.IsNullOrEmpty(str)) return null;
            var errorHandlingRef = str.Split('|')[2];
            var errorHandling = new ErrorHandlingScenario();
            var statusCodeString = dataRow["ErrorHandling_StatusCode_" + errorHandlingRef + "_1"];
            var statusCodeStringKeyValues = statusCodeString.Split('|');
            foreach (var item in statusCodeStringKeyValues)
            {
                var kvp = item.Split(':');
                errorHandling.ListStatusCode.Add(new KeyValuePair<string, string>(kvp[0], kvp[1]));
            }
            return errorHandling;
 
        }
    }
}
