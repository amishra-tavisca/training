using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;

namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class EditSiteDetails
    {
        public void AddMappedToDomain( string mappedToDomain)
        {
            
            TestManager.ControlMap["EditSiteDetails.FieldMappedToDomain"].Type(mappedToDomain);

        }
        public void ClickAddMappedToDomainLink() 
        {
            TestManager.ControlMap["EditSiteDetails.AddMappedToDomainBtn"].Click();
        }
    }
}
