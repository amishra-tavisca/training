using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Tavisca.Templar.UIAutomation.ScenarioObjects;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("SiteDetails")]
    public class SiteDetailsTest : ScenarioTestComponent
    {
        public SiteDetailsScenario SiteDetails { get; set; }
        public ThemesScenario Themes { get; set; }


        protected override void RunSmoke()
        {
            ExtractScenarioData();
            #region remove afterwards
            //Themes = ((CreateSiteDetails)Scenario).Themes;
            //var themeNames = new List<string>();
            //GlobalsTab.SelectGlobalsTabLink();//GlobalsTab is a static class, so we can call method of that using ClassName.MethoName();
            //ManageTheme.SelectGlobalThemeLink();//ManageTheme is a static class, so we can call method of that using ClassName.MethoName();
            //var addThemes = new AddNewGlobalThemeTest();
            //foreach (var themeName in Themes.ListThemes)
            //{
            //    var dateTimeStamp = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
            //    var timeStampedThemeName = themeName + dateTimeStamp;
            //    addThemes.GlobalTheme = new Globals { ThemeName = timeStampedThemeName, Description = themeName, FromThemeName = "Blank Theme" };
            //    addThemes.AddTheme();
            //    themeNames.Add(TestManager.TestData.Get<string>("CreatedThemeName"));
            //}
            //TestManager.TestData.Add("ListThemeNames", themeNames);
            
            #endregion

            SitesTab.SelectSitesTabLink();//SitesTab is a static class, so we can call method of that using ClassName.MethodName();

            var createNewSiteLink = new CreateNewSite();

            createNewSiteLink.SelectCreateNewSiteLink();

            var siteDetailsWdgt = new SiteDetails();

            var timeStamp=DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
            var siteName=SiteDetails.Name + timeStamp;
            TestManager.TestData.Add("CreatedSiteName", siteName);
            siteDetailsWdgt.EnterSiteDetails(siteName, SiteDetails.Url, SiteDetails.Description);

            siteDetailsWdgt.SelectCreateSiteCheckbox(SiteDetails.CreateSiteFromScratch);
            if (SiteDetails.CreateSiteFromScratch==true)
            {                
                    siteDetailsWdgt.SelectStatusDropDown(SiteDetails.Status);
                
            }
            else
            {
                var tmpName = TestManager.TestData.Get< string >("CreatedTemplateName");//Access template name .
                //siteDetailsWdgt.SelectTemplateDropDown(SiteDetails.Template);// Template name come from sheet.
                siteDetailsWdgt.SelectTemplateDropDown(tmpName);
                                
                siteDetailsWdgt.SelectCheckBoxIndividualPages(SiteDetails.SelectIndividualPages);          
            }            
        }

        protected virtual void ExtractScenarioData()
        {
            SiteDetails = ((TemplarDetails)Scenario).CreateSiteDetails.SiteDetails;
        }
    }
}
