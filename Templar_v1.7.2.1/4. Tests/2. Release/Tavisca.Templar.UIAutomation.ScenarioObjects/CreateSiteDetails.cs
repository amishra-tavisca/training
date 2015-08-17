using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Model;

namespace Tavisca.Templar.UIAutomation.ScenarioObjects
{
    public class SiteDetailsScenario
    {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Description { get; set; }
        public bool CreateSiteFromScratch { get; set; }
        public string Status { get; set; }
        public string Template { get; set; }
        public bool SelectIndividualPages { get; set; }
        public string PageName { get; set; }
        

    }

    public class ThemesScenario
    {
        public List<string> ListThemes { get; set; }
    }

    public class ScriptScenario
    {
        public ScriptScenario()
        {
            ListScript = new List<KeyValuePair<string, string>>();
        }

        public List<KeyValuePair<string,string>> ListScript { get; set; }
    }

    public class SEOScenario
    {
        public SEOScenario()
        {
            ListMetaTagName = new List<KeyValuePair<string, string>>();
        }
        public string HeaderCode { get; set; }
        public string FooterCode { get; set; }
        public List<KeyValuePair<string, string>> ListMetaTagName { get; set; }

        public string headerCode { get; set; }
    }

    public class ErrorHandlingScenario 
    {
        public ErrorHandlingScenario()
        {
            ListStatusCode = new List<KeyValuePair<string, string>>(); 
        }
        public List<KeyValuePair<string, string>> ListStatusCode { get; set; }
    }

    public class GlobalizationScenario 
    {
        public List<string> ListCultures { get; set; }
    }

    public class PageNameScenario 
    {
        public List<string> ListPageName { get; set; }
    }

    public class CreateSiteDetails : Scenario
    {
        public CreateSiteDetails()
        {
            SiteDetails = new SiteDetailsScenario();
            Themes = new ThemesScenario();
            Script = new ScriptScenario();
            SEO = new SEOScenario();
            ErrorHandling = new ErrorHandlingScenario();
            Globalization = new GlobalizationScenario();
            PageName = new PageNameScenario();
        }

        public SiteDetailsScenario SiteDetails{ get; set; }
        public ThemesScenario Themes { get; set; }
        public ScriptScenario Script { get; set; }
        public SEOScenario SEO { get; set; }
        public ErrorHandlingScenario ErrorHandling { get; set; }
        public GlobalizationScenario Globalization { get; set; }
        public PageNameScenario PageName { get; set; }
    }
}
