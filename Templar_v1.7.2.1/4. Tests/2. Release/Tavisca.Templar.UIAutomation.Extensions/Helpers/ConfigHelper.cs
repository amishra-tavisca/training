using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace Tavisca.Templar.UIAutomation.Extensions.Helpers
{
    public class ConfigHelper
    {
        public static string MessagesFilePath
        {
            get { return ConfigurationManager.AppSettings["MessagesPath"]; }
        }

        public static string Browser
        {
            get { return ConfigurationManager.AppSettings["Browser"]; }
        }
        public static string ApplicationUrl
        {
            get { return ConfigurationManager.AppSettings["ApplicationUrl"]; }
        }

        public static string UserName
        {
            get { return ConfigurationManager.AppSettings["UserName"]; }
        }
        public static string Password
        {
            get { return ConfigurationManager.AppSettings["PassWord"]; }
        }

        public static string GetDataSourceConnectionString(string dataSourceName)
        {
            var configSection = (Microsoft.VisualStudio.TestTools.UnitTesting.TestConfigurationSection) ConfigurationManager.GetSection("microsoft.visualstudio.qualitytools");
            var connectionStringName = configSection.DataSources[dataSourceName].ConnectionString;
            return ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString.Replace("|DataDirectory|\\\\", "").Replace("\\\\", "\\");
        }
    }
}
