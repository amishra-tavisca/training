using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Model;
using Tavisca.Templar.UIAutomation.Constants;
using System.Globalization;

namespace Tavisca.Templar.UIAutomation.Extensions
{
    public static class DatePircker
    {
        //public static void SelectDateFromCalendar(this Control controlToBeSet, string date)
        //{
        //    SelectDateFromCalendar(controlToBeSet, DateTime.Parse(date),false);
        //}

        //public static void SelectDateFromCalendar(this Control controlToBeSet, string date, bool selectProvidedDate)
        //{
        //    SelectDateFromCalendar(controlToBeSet, DateTime.Parse(date), selectProvidedDate);
        //}

        //public static void SelectDateFromCalendar(this Control controlToBeSet, DateTime date,bool selectProvidedDate)
        //{
        //    /* SPECIFICATION:
        //                * Click the control to show the calendar div
        //                * Get current month and year in calendar
        //                * Calculate the total number of months (month*year) displayed on the calender
        //                * Calculate the total number of months (month*year) we need to move to
        //                * Check if both values are equal or not
        //                    *  If the desired value is less than current
        //                            *  Move to previous month
        //                    *  If the desired value is greater than current
        //                            *  Move to next month
        //                * Repeat previous step till we reach desired value, i.e. current number of months = desired number of months
        //                * Select date cell
        //              */

        //    //Click control to show calendar

            
        //    if (selectProvidedDate==false)
        //    {
        //        int daysDiff = date.Day - DateTime.Now.Day;
        //        date = DateTime.Now;
        //        date = date.AddMonths(3);
        //        date = date.AddDays(daysDiff);
        //    }
            

        //    controlToBeSet.Reset().HtmlControl.SetFocus();
        //    controlToBeSet.Reset().Click();

        //    var currentMonth = DateParser.ParseLongMonthNameToMonthNumber(TestManager.ControlMap[UILocatorConstants.SearchHWidget.JDatePickerMonth].Reset().GetInnerText());
        //    var currentYear = Convert.ToInt32(TestManager.ControlMap[UILocatorConstants.SearchHWidget.JDatePickerYear].Reset().GetInnerText());

        //    var totalmonthsCurrent = currentMonth + currentYear * 12;
        //    var totalmonthsRequired = date.Month + date.Year * 12;
        //    var difference = Math.Abs(totalmonthsCurrent - totalmonthsRequired) / 2;

        //    for (var i = 0; i < difference; i++)
        //    {
        //        //Here we regenerate controls
        //        /*************** DO NOT CHANGE *******************/
        //        #region Regenerate Controls
        //        //TODO: Move this to control file
        //        var previousButtonControl = TestManager.ControlMap[UILocatorConstants.SearchHWidget.JDatePickerPrev];
        //        var nextButtonControl = TestManager.ControlMap[UILocatorConstants.SearchHWidget.JDatePickerNext];
        //        #endregion

        //        //If the month was in the past
        //        if (totalmonthsRequired < totalmonthsCurrent)
        //        {
        //            //Move backward
        //            previousButtonControl.Click();
        //            totalmonthsCurrent--;
        //        }
        //        //If the month is in the future
        //        else if (totalmonthsRequired > totalmonthsCurrent)
        //        {
        //            //Move forward
        //            nextButtonControl.Click();
        //            totalmonthsCurrent++;
        //        }
        //    }

        //    //TODO: Move this to control file?
        //    // Select the date

        //    if (currentMonth % 2 != 0)
        //    {
        //        if (totalmonthsRequired % 2 != 0)
        //            TestManager.ControlMap[UILocatorConstants.SearchHWidget.JDatePickerDateFirst].Reset().AddSearchData(date.Day.ToString()).Click();
        //        else
        //            TestManager.ControlMap[UILocatorConstants.SearchHWidget.JDatePickerDateLast].Reset().AddSearchData(date.Day.ToString()).Click();
        //    }
        //    else
        //    {
        //        if (totalmonthsRequired % 2 != 0)
        //            TestManager.ControlMap[UILocatorConstants.SearchHWidget.JDatePickerDateLast].Reset().AddSearchData(date.Day.ToString()).Click();
        //        else
        //            TestManager.ControlMap[UILocatorConstants.SearchHWidget.JDatePickerDateFirst].Reset().AddSearchData(date.Day.ToString()).Click();
        //    }
        //}

        //public static void SelectDateFromSmallCalendar(this Control controlToBeSet, string date)
        //{            
        //    SelectDateFromSmallCalendar(controlToBeSet, DateTime.Parse(date));
        //}

        //public static void SelectDateFromSmallCalendar(this Control controlToBeSet, string date, bool selectProvidedDate)
        //{            
        //    SelectDateFromSmallCalendar(controlToBeSet, DateTime.Parse(date), selectProvidedDate);
        //}

        //public static void SelectDateFromSmallCalendar(this Control controlToBeSet, DateTime date)
        //{
        //    SelectDateFromSmallCalendar(controlToBeSet, date, false);
        //}

        //public static void SelectDateFromSmallCalendar(this Control controlToBeSet, DateTime date,bool selectProvidedDate)
        //{
        //    /* SPECIFICATION:
        //                * Click the control to show the calendar div
        //                * Get current month and year in calendar
        //                * Calculate the total number of months (month*year) displayed on the calender
        //                * Calculate the total number of months (month*year) we need to move to
        //                * Check if both values are equal or not
        //                    *  If the desired value is less than current
        //                            *  Move to previous month
        //                    *  If the desired value is greater than current
        //                            *  Move to next month
        //                * Repeat previous step till we reach desired value, i.e. current number of months = desired number of months
        //                * Select date cell
        //              */

        //    //Click control to show calendar

            
        //    if (selectProvidedDate==false)
        //    {
        //        int daysDiff = date.Day - DateTime.Now.Day;
        //        date = DateTime.Now;
        //        date = date.AddMonths(3);
        //        date = date.AddDays(daysDiff);
        //    }            

        //    controlToBeSet.Reset().HtmlControl.SetFocus();
        //    controlToBeSet.Reset().Click();

        //    var currentMonth = DateParser.ParseShortMonthNameToMonthNumber(((HtmlComboBox)TestManager.ControlMap[UILocatorConstants.SmallCalendar.ComboBoxMonth].Reset().HtmlControl).SelectedItem);
        //    var currentYear = Convert.ToInt32(((HtmlComboBox)TestManager.ControlMap[UILocatorConstants.SmallCalendar.ComboBoxYear].Reset().HtmlControl).SelectedItem);

        //    var totalmonthsCurrent = currentMonth + currentYear * 12;
        //    var totalmonthsRequired = date.Month + date.Year * 12;
        //    var difference = Math.Abs(totalmonthsCurrent - totalmonthsRequired);

        //    for (var i = 0; i < difference; i++)
        //    {
        //        //Here we regenerate controls
        //        /*************** DO NOT CHANGE *******************/
        //        #region Regenerate Controls
        //        //TODO: Move this to control file
        //        var previousButtonControl = TestManager.ControlMap[UILocatorConstants.SearchHWidget.JDatePickerPrev];
        //        var nextButtonControl = TestManager.ControlMap[UILocatorConstants.SearchHWidget.JDatePickerNext];
        //        #endregion

        //        //If the month was in the past
        //        if (totalmonthsRequired < totalmonthsCurrent)
        //        {
        //            //Move backward
        //            previousButtonControl.Reset().Click();
        //            totalmonthsCurrent--;
        //        }
        //        //If the month is in the future
        //        else if (totalmonthsRequired > totalmonthsCurrent)
        //        {
        //            //Move forward
        //            nextButtonControl.Reset().Click();
        //            totalmonthsCurrent++;
        //        }
        //    }

        //    //TODO: Move this to control file?
        //    // Select the date

            
        //            TestManager.ControlMap[UILocatorConstants.SmallCalendar.JDatePickerDate].Reset().AddSearchData(date.Day.ToString()).Click();
            
        //}
    }
}
