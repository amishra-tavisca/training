using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class PageNavigation
    {
        public static void NavigateToGlobalTheme()
        {
            if (TestManager.ControlMap["Globals.LinkAddNewTheme"].WaitForControlExist(3000, false) == false)
            {
                GlobalsTab.SelectGlobalsTabLink();//GlobalsTab is a static class, so we can call method of that using ClassName.MethodName();
                ManageTheme.SelectGlobalThemeLink();//ManageTheme is a static class, so we can call method of that using ClassName.MethodName();
            }

        }

        public static void NavigateToGlobalCulture() 
        {
            if (TestManager.ControlMap["Globals.LinkAddCulture"].WaitForControlExist(3000, false) == false) 
            {
                GlobalsTab.SelectGlobalsTabLink();//GlobalsTab is a static class, so we can call method of that using ClassName.MethodName();
                ManageCulture.SelectGlobalCulturesLink();
            
            }
        }

        public static void NavigateToTemplates() 
        {
            if (TestManager.ControlMap["Templates.LinkCreateTemplate"].WaitForControlExist(3000, false) == false) 
            {
                TemplatesTab.SelectTemplatesTabLink();
                ManageTemplates.SelectManageTemplatesLink();
            }

        }
        public static void NavigateToSiteDashBoard()
        {
            if (TestManager.ControlMap["CreateNewSite.LinkCreateNewSite"].WaitForControlExist(3000, false) == false)
            {
                SitesTab.SelectSitesTabLink();
            }

        }
        public static void NavigateToAddUser() 
        {
            if (TestManager.ControlMap["Admin.LinkAddUser"].WaitForControlExist(3000, false) == false) 
            {
                AdminTab.SelectAdminTabLink();
                ManageUser.SelectManageUserLink();

            }

        }

        public static void NavigateToWidget() 
        {
            if (TestManager.ControlMap["Admin.LinkAddNewWidget"].WaitForControlExist(5000, false) == false) 
            {
                AdminTab.SelectAdminTabLink();
                ManageWidget.SelectManagewidgetLink();
            }
        }
        public static void NavigateToUpdateWidget() 
        {
            if (TestManager.ControlMap["Admin.LinkUpdateWidget"].WaitForControlExist(3000, false) == false) 
            {
                AdminTab.SelectAdminTabLink();
                ManageWidget.SelectManagewidgetLink();
                UpdateWidgetLink.ClickUpdateWidgetLink();
 
            }

        }
    }
}
