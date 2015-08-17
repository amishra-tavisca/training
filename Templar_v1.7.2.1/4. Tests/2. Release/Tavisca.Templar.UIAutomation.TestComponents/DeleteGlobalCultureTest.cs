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
    [TestComponent ("DeleteGlobalCulture")]
    public class DeleteGlobalCultureTest : ScenarioTestComponent 
    {
        public List<Globals> GlobalsCulture { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();
            
            PageNavigation.NavigateToGlobalCulture();

            var deleteGlobalCulture = new DeleteGlobalCulture();
            var searchGlobalCulture = new SearchGlobalCulture();
                        
            foreach (var culture in GlobalsCulture)
            {
                 

                if (string.IsNullOrEmpty(culture.Country) == false)
                {
                    deleteGlobalCulture.ClickDeleteGlobalCulture(culture.Language + " - " + culture.Country);
                    deleteGlobalCulture.ClickDeleteOKButton();
                    deleteGlobalCulture.ConfermDeleteOkButton();
                                                                               
                }

                else
                {
                    deleteGlobalCulture.ClickDeleteGlobalCulture(culture.Language);
                    deleteGlobalCulture.ClickDeleteOKButton();
                    deleteGlobalCulture.ConfermDeleteOkButton();
                }

                var  isFound = searchGlobalCulture.SearchAddedGlobalculture(culture.Language + " - " + culture.Country);
                if (isFound == false) Console.WriteLine("Global Culture:" + culture.Language + " - " + culture.Country + "deleted successfully.");
                Assert.IsTrue(isFound == false, "Global Culture:" + culture.Language + " - " + culture.Country + "is not deleted.");
            }


        }

        private void ExtractScenarioData()
        {
            GlobalsCulture = ((TemplarDetails)Scenario).Globals;
        }

              
    }
}
