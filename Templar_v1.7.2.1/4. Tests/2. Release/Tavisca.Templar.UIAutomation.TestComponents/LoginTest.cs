using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.Templar.UIAutomation.ApplicationModel;
using System.Configuration;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;

namespace Tavisca.Templar.UIAutomation.TestComponents
{
    [TestComponent("Login")]
    public class LoginTest:ScenarioTestComponent
    { 

        protected override void RunSmoke()
        {
            var loginWdgt = new Login();
            loginWdgt.EnterCredentials(ConfigHelper.UserName, ConfigHelper.Password);
            loginWdgt.ClickLoginBtn();
        }
    }
}
