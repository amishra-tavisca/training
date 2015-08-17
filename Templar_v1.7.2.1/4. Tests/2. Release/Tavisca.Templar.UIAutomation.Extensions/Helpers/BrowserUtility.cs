using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Tavisca.Templar.UIAutomation.Constants;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;

namespace Tavisca.Templar.UIAutomation.Extensions.Helpers
{
    public static class BrowserUtility
    {
        public static void EndSessions()
        {
            try
            {
                var runingProcess = Process.GetProcesses();

                for (int i = 0; i < runingProcess.Length; i++)
                {
                    // compare equivalent process by their name
                    if (runingProcess[i].ProcessName == "iexplore" || runingProcess[i].ProcessName == "firefox")
                    {
                        // kill  running process
                        runingProcess[i].Kill();
                    }
                }
            }
            catch
            {
                //Suppress any exception here
            }
        }

        public static string GetBrowserWindowTitle()
        {
            //TestManager.ControlMap[UILocatorConstants.Login.BodyTag].IsExist();
            return TestManager.BrowserWindow.Title;
        }
    }
}
