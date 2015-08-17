using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("AddGlobalCulture")]
    public class AddGlobalCultureTest : ScenarioTestComponent
    {
        public List<Globals> GlobalsCulture { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();

            PageNavigation.NavigateToGlobalCulture();


            var AddGlobalCultureLink = new AddGlobalCulture();
            var searchGlobalCulture = new SearchGlobalCulture();


            var cultures = new List<Globals>();

            foreach (var culture in GlobalsCulture)
            {
                bool isFound;
                if (string.IsNullOrEmpty(culture.Country) == false)
                {
                    isFound = searchGlobalCulture.SearchAddedGlobalculture(culture.Language + " - " + culture.Country);
                }

                else
                {
                    isFound = searchGlobalCulture.SearchAddedGlobalculture(culture.Language);
                }
                if (isFound == false)
                {
                    AddGlobalCultureLink.SelectAddCultureLink();
                    AddGlobalCultureLink.SelectLanguageDropDown(culture.Language);
                    AddGlobalCultureLink.SelectCountryDropDown(culture.Country);
                    AddGlobalCultureLink.ClickAddCultureBtn();
                }
            }

        }

        private void ExtractScenarioData()
        {
            GlobalsCulture = ((TemplarDetails)Scenario).Globals;
        }
    }
}
