using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.Templar.UIAutomation.Extensions;
using Tavisca.Templar.UIAutomation.Extensions.Helpers;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using System.IO;
using Tavisca.Templar.UIAutomation.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using OpenQA.Selenium;

namespace Tavisca.TravelNxt.UIAutomation.Tests
{
    [TestClass]
    public class BaseTestFixture
    {
        public TestContext TestContext { get; set; }

        public string LaunchUrl { get; set; }

        protected static int TestNumber { get; set; }

        protected static string[] Lines { get; set; }

        protected static string[] TableHeaders { get; set; }

        protected static string FilePath { get; set; }

        protected static Stopwatch Timer {get; set;}     

        static BaseTestFixture()
        {
            FilePath = string.Empty;
            TestNumber = 1;
        }

        public BaseTestFixture()
        {
            //if (string.IsNullOrEmpty(ConfigHelper.Browser) == false)
            //BrowserWindow.CurrentBrowser = ConfigHelper.Browser;
        }

        [TestInitialize]
        public void TestInitialize()
        {
            //BrowserWindow.CurrentBrowser = ConfigHelper.Browser;
            //BrowserUtility.EndSessions();
            TestManager.ScreenCaptureImagesPath = TestContext.ResultsDirectory + "\\" + TestContext.TestName + "_ScenarioId " + TestContext.DataRow["Scenario_Id_1"].ToString();
            TestManager.Init(LaunchUrl);
            TestManager.Driver.Manage().Window.Maximize();
            Console.WriteLine("Purpose of Test: " + TestContext.DataRow["Scenario_AcceptanceCriteria_1"].ToString().Replace('|', ','));
           Console.WriteLine("ScenarioId: " + TestContext.DataRow["Scenario_Id_1"].ToString());
           Timer = new Stopwatch();
           Timer.Start();
        }

        protected virtual Dictionary<string, string> GetTestData(DataSourceAttribute dataSource)
        {
            InitializeDataSource(dataSource);
            string[] values = null;
            if (TestNumber < Lines.Length)
            {
                values = Lines[TestNumber].Split(',');
                TestNumber++;
            }

            var testData = new Dictionary<string, string>(TableHeaders.Length + 10);
            for (int index = 0; index < TableHeaders.Length; index++)
            {
                testData.Add(TableHeaders[index], values[index]);
            }
            return testData;
        }

        protected virtual void InitializeDataSource(DataSourceAttribute dataSource)
        {
            var filePath = ConfigHelper.GetDataSourceConnectionString(dataSource.DataSourceSettingName);
            if (string.Equals(FilePath, filePath) == false)
            {
                FilePath = filePath;
                TestNumber = 1;
                Lines = File.ReadAllLines(FilePath);
                TableHeaders = Lines[0].Split(',');
            }
            return;
        }

        [TestCleanup]
        public void Cleanup()
        {
            Timer.Stop();
            Console.WriteLine("Time taken by current scenario : {0} ", Timer.Elapsed); 
            if (TestContext.CurrentTestOutcome != UnitTestOutcome.Passed)
            {
                TestManager.CaptureScreenEntirePage("Failure_"+TestManager.TestNumber+".png");
            }
            TestManager.Dispose();
        }
    }
}
