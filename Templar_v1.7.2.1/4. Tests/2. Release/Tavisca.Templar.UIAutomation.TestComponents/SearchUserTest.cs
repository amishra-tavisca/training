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
    [TestComponent("SearchUser")]
    public class SearchUserTest : ScenarioTestComponent
    {
        //public AdminDetails UserName { get; set; }

        protected override void RunSmoke()
        {
            //ExtractScenarioData();
            var searchUser = new SearchUser();
            var deleteUser = new DeleteUser();

            var loginName = TestManager.TestData.Get<string>("CreatedLoginName");
            
            //bool isFound = searchUser.SearchAddedUser(UserName.LoginName);

            bool isFound = searchUser.SearchAddedUser(loginName);
            if (isFound) Console.WriteLine("User: " + loginName + " Searched successfully.");
            Assert.IsTrue(isFound, "Added User:" + loginName + "not found.");

            deleteUser.ClickDeleteUser(loginName);
            deleteUser.ClickDeleteOKButton();

            isFound = searchUser.SearchAddedUser(loginName);
            if (isFound == false) Console.WriteLine("After deleting User: " + loginName + ", search again same user and now deleted user is not found.");
            Assert.IsTrue(isFound == false, "After deleting User: " + loginName + " template searched.It means template is not deleted yet.");


        }

        /*private void ExtractScenarioData()
        {
            UserName = ((AdminDetails)Scenario);
        }*/
    }
}
