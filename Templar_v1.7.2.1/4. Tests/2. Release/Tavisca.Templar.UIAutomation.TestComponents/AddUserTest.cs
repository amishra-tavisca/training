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
    [TestComponent("AddUser")]
    public class AddUserTest : ScenarioTestComponent
    {
        public AdminDetails AdminDetail { get; set; }
        protected override void RunSmoke()
        {
            ExtractScenarioData();

            PageNavigation.NavigateToAddUser();

            var addUser = new AddUser();
            addUser.ClickAddUserLink();

            var dateTimeStamp = DateTime.Now.ToString().Replace("/", "").Replace(":", "").Replace(" ", "");
            var loginName = AdminDetail.LoginName + dateTimeStamp;
            TestManager.TestData.Add("CreatedLoginName", loginName);
            addUser.EnterUserDetails(loginName, AdminDetail.Password, AdminDetail.FirstName, AdminDetail.LastName);
            addUser.SelectUserTypeDropDown(AdminDetail.UserRole);
            addUser.SelectDisableUser(AdminDetail.DisableUser);
            addUser.ClickUpdateUserLink();

        }

        private void ExtractScenarioData()
        {
            AdminDetail = ((TemplarDetails)Scenario).AdminDetails;
        }

    }
}
