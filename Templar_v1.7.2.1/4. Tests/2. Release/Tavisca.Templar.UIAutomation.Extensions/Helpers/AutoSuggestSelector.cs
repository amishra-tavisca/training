using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Tavisca.Templar.UIAutomation.Constants;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using Tavisca.TravelNxt.UIAutomation.Framework.Model;

namespace Tavisca.Templar.UIAutomation.Extensions.Helpers
{
    public class AutoSuggestSelector
    {

        //public static void SelectLocationFromAutoSuggest(string location,Control txtFieldLocation)
        //{
        //    txtFieldLocation.Type(location);
        //   var suggestionList = TestManager.ControlMap[UILocatorConstants.Search.DivAutoSuggest].GetMatchingVisibleControls()[0].HtmlControl.GetChildren()[0];
            
        //    var listItems = suggestionList.GetChildren();
        //    for (int i = 0; i < listItems.Count; i++)
        //    {
        //        var text = ((HtmlControl)listItems[i]).InnerText;
        //        if (text.Contains(location,StringComparison.InvariantCultureIgnoreCase))
        //        {
        //            Mouse.Click(listItems[i]);
        //            return;
        //        }
        //    }
        //    Assert.Fail("Destination location:" + location + " not found in autosuggest list.");
        //}
    }
}
