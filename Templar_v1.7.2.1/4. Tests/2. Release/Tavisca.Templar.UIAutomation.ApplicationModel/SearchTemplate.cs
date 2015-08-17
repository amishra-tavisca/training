using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using System.Threading;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class SearchTemplate
    {
        public void EnterTemplateName(string templateName) 
        {
            TestManager.ControlMap["Templates.FieldSearchTemplate"].Type(templateName);
        }
        public void ClickSearchIcon()
        {
            TestManager.ControlMap["Templates.LinkSearchTemplate"].Click();
        }

        public bool SearchCreatedTemplate(string templateToSearch) 
        {

            if (GetAddedTemplateIndex(templateToSearch)>-1) 
                {
                    return true;
                }
            
            return false;
        }

        public int GetAddedTemplateIndex(string templateToSearch)
        {
            EnterTemplateName(templateToSearch);
            ClickSearchIcon();
            Thread.Sleep(1000);
            TestManager.ControlMap["Templates.LblTemplateName"].WaitForControlExist(3000,false);
            var ListItems = TestManager.ControlMap["Templates.LblTemplateName"].GetMatchingVisibleControls();
            for (int i = 0; i < ListItems.Count; i++)
            {
                var templateNameText = ListItems[i].HtmlControl.GetProperty("title");
                if (templateNameText.Equals(templateToSearch))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
