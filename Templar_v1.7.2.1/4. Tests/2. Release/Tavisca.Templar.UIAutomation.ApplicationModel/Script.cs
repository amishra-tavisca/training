using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;
using Tavisca.TravelNxt.UIAutomation.Framework.Controls;


namespace Tavisca.Templar.UIAutomation.ApplicationModel
{
    public class Script
    {
        public void SelectScriptLink()
        {
            TestManager.ControlMap["Script.LinkScript"].Click();
        }

        public void ClickInformationLink()
        {
            TestManager.ControlMap["Script.TitleInformation"].Click();
        }

        public void ClickIconClose()
        {
            TestManager.ControlMap["Script.IconClose"].Click();
        }

        public void ClickAddBtn()
        {
            TestManager.ControlMap["Script.AddButton"].Click();

        }

        public void EnterNewDetails(string key, string value)
        {
            var count = TestManager.ControlMap["Script.FieldKey"].Reset().GetVisibleMatchingControlsCount();
            TestManager.ControlMap["Script.FieldKey"].Reset().GetMatchingVisibleControls()[count - 1].Type(key);
            TestManager.ControlMap["Script.FieldValue"].Reset().GetMatchingVisibleControls()[count - 1].SendKeys(value);

        }

        public void SaveNewDetails()
        {
            TestManager.ControlMap["Script.SaveButton"].Click();

        }

        /*public void CancleNewDetails()
        {

            TestManager.ControlMap["Script.CancleButton"].Click();

        }*/

        public void SelectScript(string buttonToSelect)
        {
            var ButtonItems = TestManager.ControlMap["Script.SelectScriptBtn"].Reset().GetMatchingVisibleControls();
            
            for (int i = 2; i < ButtonItems.Count; i++)
            {
                var scriptButton = ButtonItems[i].HtmlControl.GetParent().GetParent();
                var dataValue = scriptButton.InnerText.Split(new string[]{"\r\n"},StringSplitOptions.RemoveEmptyEntries)[2];
                if (dataValue.Equals(buttonToSelect))
                {
                    ButtonItems[i].Click();
                    return;
                }
            }
        }

                            
        public void SaveDetails()
        {
            TestManager.ControlMap["Script.SaveButton"].Click();

        }

        /*public void CancleDetails()
        {

            TestManager.ControlMap["Script.CancleButton"].Click();

        }*/

        public void DeleteScript(string buttonToSelect)
        {
           
            var ButtonItems = TestManager.ControlMap["Script.DeleteScriptBtn"].Reset().GetMatchingVisibleControls();
           
            for (int i = 0; i < ButtonItems.Count; i++)
            {
                var scriptButton = ButtonItems[i].HtmlControl.GetParent().GetParent();
                var dataValue = scriptButton.InnerText.Split(new string[] { "\r\n" }, StringSplitOptions.RemoveEmptyEntries)[0];
                if (dataValue.Equals(buttonToSelect))
                {
                    ButtonItems[i].Click();
                    TestManager.ControlMap["Script.DeleteOkButton"].Click();
                    return;
                }
            }
        }

            public void ConfirmDeletion()
            {
                 
               TestManager.ControlMap["Script.DeleteOkButton"].Click();

               // TestManager.ControlMap["Script.DeleteCancleButton"].Click();

            }

        }

        
    }


