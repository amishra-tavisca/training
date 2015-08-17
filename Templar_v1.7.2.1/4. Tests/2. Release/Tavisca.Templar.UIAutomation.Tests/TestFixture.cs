using System.Runtime.CompilerServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.TravelNxt.UIAutomation.Tests;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Model;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using Tavisca.Templar.UIAutomation.DataBinders;

namespace Tavisca.TravelNxt.UIAutomation.BOXTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class TemplarTestFixture : BaseTestFixture
    {
        private ScenarioTestPipeline TestExecutionPipeline { get; set; }

        [TestInitialize]
        public new void TestInitialize()
        {
            base.TestInitialize();
            TestExecutionPipeline = new ScenarioTestPipeline();
        }
        [TestMethod]
        [TestCategory("Sanity"),TestCategory("Smoke")]
        [DataSource("SanityDataSource")]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void TemplarSanity()
        {
            TestExecutionPipeline.TestMode = TestMode.Smoke;
            var dataSource = (DataSourceAttribute)MethodBase.GetCurrentMethod().GetCustomAttributes(typeof(DataSourceAttribute), false)[0];
            var testData = GetTestData(dataSource);
            string scenarioType = TestContext.DataRow["Scenario_Scenario_1"].ToString().Split('|')[1];
            var binder = new TemplarBinder();
            Scenario scenario = binder.GetTemplarDetails(testData);           
            scenario.TestComponents = testData["Scenario_TestComponents_1"].Split('|').ToList();
            TestExecutionPipeline.Execute(scenario);
        }


        //[TestMethod]
        [TestCategory("CreateSite"), TestCategory("Smoke")]
        [DataSource("CreateSiteSmokeDataSource")]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void CreateSite()
        {
            TestExecutionPipeline.TestMode = TestMode.Smoke;
            var dataSource = (DataSourceAttribute)MethodBase.GetCurrentMethod().GetCustomAttributes(typeof(DataSourceAttribute), false)[0];
            var testData = GetTestData(dataSource);
            string scenarioType = TestContext.DataRow["Scenario_Scenario_1"].ToString().Split('|')[1];
            var binder = new TemplarBinder();
            Scenario scenario = binder.GetTemplarDetails(testData);
            scenario.TestComponents = testData["Scenario_TestComponents_1"].Split('|').ToList();
            TestExecutionPipeline.Execute(scenario);
        }

        //[TestMethod]
        [TestCategory("Templates"), TestCategory("Smoke")]
        [DataSource("TemplatesSmokeDataSource")]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Templates()
        {
            TestExecutionPipeline.TestMode = TestMode.Smoke;
            var dataSource = (DataSourceAttribute)MethodBase.GetCurrentMethod().GetCustomAttributes(typeof(DataSourceAttribute), false)[0];
            var testData = GetTestData(dataSource);
            string scenarioType = TestContext.DataRow["Scenario_Scenario_1"].ToString().Split('|')[1];
            var binder = new TemplarBinder();
            Scenario scenario = binder.GetTemplarDetails(testData);
            scenario.TestComponents = testData["Scenario_TestComponents_1"].Split('|').ToList();
            TestExecutionPipeline.Execute(scenario);
        }
        //[TestMethod]
        [TestCategory("SiteDashBoard"), TestCategory("Smoke")]
        [DataSource("SiteDashBoardDataSource")]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void SiteDashBoard()
        {
            TestExecutionPipeline.TestMode = TestMode.Smoke;
            var dataSource = (DataSourceAttribute)MethodBase.GetCurrentMethod().GetCustomAttributes(typeof(DataSourceAttribute), false)[0];
            var testData = GetTestData(dataSource);
            string scenarioType = TestContext.DataRow["Scenario_Scenario_1"].ToString().Split('|')[1];
            var binder = new TemplarBinder();
            Scenario scenario = binder.GetTemplarDetails(testData);
            scenario.TestComponents = testData["Scenario_TestComponents_1"].Split('|').ToList();
            TestExecutionPipeline.Execute(scenario);
        }
        //[TestMethod]
        [TestCategory("Globals"), TestCategory("Smoke")]
        [DataSource("GlobalsDataSource")]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Globals()
        {
            TestExecutionPipeline.TestMode = TestMode.Smoke;
            var dataSource = (DataSourceAttribute)MethodBase.GetCurrentMethod().GetCustomAttributes(typeof(DataSourceAttribute), false)[0];
            var testData = GetTestData(dataSource);
            string scenarioType = TestContext.DataRow["Scenario_Scenario_1"].ToString().Split('|')[1];
            var binder = new TemplarBinder();
            Scenario scenario = binder.GetTemplarDetails(testData);
            scenario.TestComponents = testData["Scenario_TestComponents_1"].Split('|').ToList();
            TestExecutionPipeline.Execute(scenario);

        }
        //[TestMethod]
        [TestCategory("Admin"), TestCategory("Smoke")]
        [DataSource("AdminDataSource")]
        [MethodImpl(MethodImplOptions.NoInlining)]
        public void Admin()
        {
            TestExecutionPipeline.TestMode = TestMode.Smoke;
            var dataSource = (DataSourceAttribute)MethodBase.GetCurrentMethod().GetCustomAttributes(typeof(DataSourceAttribute), false)[0];
            var testData = GetTestData(dataSource);
            string scenarioType = TestContext.DataRow["Scenario_Scenario_1"].ToString().Split('|')[1];
            var binder = new TemplarBinder();
            Scenario scenario = binder.GetTemplarDetails(testData);
            scenario.TestComponents = testData["Scenario_TestComponents_1"].Split('|').ToList();
            TestExecutionPipeline.Execute(scenario);

        }

        //[TestMethod]
        [TestCategory("EditSite"), TestCategory("Smoke")]
        [DataSource("EditSiteSmokeDataSource")]
        [MethodImpl(MethodImplOptions.NoInlining)]        
        public void EditSite()
        {
            TestExecutionPipeline.TestMode = TestMode.Smoke;
            var dataSource = (DataSourceAttribute)MethodBase.GetCurrentMethod().GetCustomAttributes(typeof(DataSourceAttribute), false)[0];
            var testData = GetTestData(dataSource);
            string scenarioType = TestContext.DataRow["Scenario_Scenario_1"].ToString().Split('|')[1];
            var binder = new TemplarBinder();
            Scenario scenario = binder.GetTemplarDetails(testData);
            scenario.TestComponents = testData["Scenario_TestComponents_1"].Split('|').ToList();
            TestExecutionPipeline.Execute(scenario);
        }

        public void Execute(Dictionary<string, string> testData)
        {
            var binder = new CreateSiteBinder();
            var scenario = binder.GetCreateSiteDetails(testData);
            scenario.TestComponents = testData["Scenario_TestComponents_1"].Split('|').ToList();
            TestExecutionPipeline.Execute(scenario);
        }

        [TestCleanup]
        public new void Cleanup()
        {
            base.Cleanup();
        }
    }
}
