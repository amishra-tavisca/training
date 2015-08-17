using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class SiteDetails
    {
        public void EnterSiteDetails(string siteName, string url, string description )
        {
            TestManager.ControlMap["SiteDetails.FieldSiteName"].Type(siteName);
            TestManager.ControlMap["SiteDetails.FieldSiteUrl"].Type(siteName.Replace(" ", ""));
            TestManager.ControlMap["SiteDetails.FieldDescription"].Reset().SendKeys(description);
        }

        public void SelectCreateSiteCheckbox(bool isCreateFromScratch)
        {            
                TestManager.ControlMap["SiteDetails.CheckBoxCreateSiteFromScratch"].SelectCheckBox(isCreateFromScratch);   
        }

        public void SelectStatusDropDown(string statusType)
        {
            TestManager.ControlMap["SiteDetails.StatusDropDown"].SelectComboBoxByText(statusType);
        }

        public void SelectTemplateDropDown(string templateName)
        {
            TestManager.ControlMap["SiteDetails.SelectTemplateDropDown"].SelectComboBoxByText(templateName);
        }

        public void SelectCheckBoxIndividualPages(bool isSelectIndividualPages)
        {
            TestManager.ControlMap["SiteDetails.CheckBoxIndividualPages"].SelectCheckBox(isSelectIndividualPages);
        }

    }

}
