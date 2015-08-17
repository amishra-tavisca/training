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
    [TestComponent("Script")]
    public class ScriptTest : ScenarioTestComponent
    {
        public ScriptScenario Script { get; set; }

        protected override void RunSmoke()
        {
            ExtractScenarioData();

            var ScriptWdgt = new Script();

            ScriptWdgt.SelectScriptLink();
            ScriptWdgt.ClickInformationLink();
            ScriptWdgt.ClickIconClose();
            ScriptWdgt.ClickAddBtn();
            ScriptWdgt.EnterNewDetails(Script.ListScript[0].Key, Script.ListScript[0].Value);
            ScriptWdgt.SaveNewDetails();
            ScriptWdgt.SelectScript(Script.ListScript[0].Key);
            //ScriptWdgt.EnterNewDetails(Script.ListScript[1].Key, Script.ListScript[1].Value);
            ScriptWdgt.SaveDetails();
            //ScriptWdgt.DeleteScript("Newtestquery");
        }

        private void ExtractScenarioData()
        {
            Script = ((TemplarDetails)Scenario).CreateSiteDetails.Script;
        }
    }
}