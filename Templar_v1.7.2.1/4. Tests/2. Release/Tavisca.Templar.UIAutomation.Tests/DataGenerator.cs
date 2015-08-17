using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.TravelNxt.UIAutomation;
using Tavisca.TravelNxt.UIAutomation.Framework.Data;

namespace Tavisca.Templar.UIAutomation.Tests
{
    [TestClass]
    public class DataGeneratorTests
    {
        //[TestMethod]
        //[TestCategory("CreateSite")]
        public void CreateSiteTestsDataSource()
        {
            DataGenerator.GenerateDataSource("CreateSite", "Smoke");
        }
        
        //[TestMethod]
        //[TestCategory("Templates")]
        public void TempletsTestDataSource() 
        {
            DataGenerator.GenerateDataSource("Templates", "Smoke");
        }

        //[TestMethod]
        //[TestCategory("SiteDashBoard")]
        public void SiteDashBoardTestDataSource()
        {
            DataGenerator.GenerateDataSource("SiteDashBoard", "Smoke");
        }

        //[TestMethod]
        //[TestCategory("Globals")]
        public void GlobalsTestDataSource() 
        {
            DataGenerator.GenerateDataSource("Globals", "Smoke");
        }

        //[TestMethod]
        //[TestCategory("Admin")]
        public void AdminTestDataSource()
        {
            DataGenerator.GenerateDataSource("Admin", "Smoke");
        }

        //[TestMethod]
        //[TestCategory("EditSite")]
        public void EditSiteTestDataSource() 
        {
            DataGenerator.GenerateDataSource("EditSite", "Smoke");
        }

        [TestMethod]
        //[TestCategory("Smoke")]
        public void SanityTestDataSource() 
        {
            DataGenerator.GenerateDataSource("Sanity", "Smoke");
        }
    }
}
