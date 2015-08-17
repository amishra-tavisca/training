using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using Tavisca.Templar.UIAutomation.ScenarioObjects;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using OpenQA.Selenium;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("UpdateWidgetFromBackUpFile")]
    public class UpdateWidgetFromBackUpFileTest :ScenarioTestComponent
    {
        protected override void RunSmoke()
        {
            PageNavigation.NavigateToUpdateWidget();

            var updateWidgetFromBackUpFile = new UpdateWidgetFromBackUpFile();

            updateWidgetFromBackUpFile.ClickUpdateFromBackUPFile();

            updateWidgetFromBackUpFile.ClickUploadBackUpFileBtn();

            updateWidgetFromBackUpFile.ClickShowdiffBtn();
        }    
        
    }
}
