using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.Templar.UIAutomation.ScenarioObjects;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("SearchGlobalCulture")]
    public class SearchGlobalCultureTest : ScenarioTestComponent
    {
        public List<Globals> GlobalsCulture { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();
            var searchGlobalCulture = new SearchGlobalCulture();
            
           
            bool isFound;
            if (string.IsNullOrEmpty(GlobalsCulture[0].Country) == false)
            {
                isFound = searchGlobalCulture.SearchAddedGlobalculture(GlobalsCulture[0].Language + " - " + GlobalsCulture[0].Country);
                if (isFound) Console.WriteLine("Global Culture:" + GlobalsCulture[0].Language + " - " + GlobalsCulture[0].Country + "added successfully.");
                Assert.IsTrue(isFound, "Added Global Culture:" + GlobalsCulture[0].Language + " - " + GlobalsCulture[0].Country + "is not found");
              
            }
            else
            {
                isFound = searchGlobalCulture.SearchAddedGlobalculture(GlobalsCulture[0].Language);
                if (isFound) Console.WriteLine("Neutral Global Culture:" + GlobalsCulture[0].Language + "added successfully.");
                Assert.IsTrue(isFound, "Added Neutral Global Culture:" + GlobalsCulture[0].Language + "is not found");
               
            }

            
        }

        protected virtual void ExtractScenarioData()
        {
            GlobalsCulture = ((TemplarDetails)Scenario).Globals;
        }
    }
}
