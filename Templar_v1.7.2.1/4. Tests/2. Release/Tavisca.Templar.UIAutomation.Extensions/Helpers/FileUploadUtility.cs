using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tavisca.TravelNxt.UIAutomation.Framework.Core;

namespace Tavisca.Templar.UIAutomation.Extensions.Helpers
{
    public class FileUploadUtility
    {       
        public static void SelectFileToUpload(string filepath)
        {
            //WinWindow ChooseFileDialog = new WinWindow();
            //ChooseFileDialog.SearchProperties.Add(WinWindow.PropertyNames.ControlType, "Window");
            //ChooseFileDialog.SearchProperties.Add(WinWindow.PropertyNames.ClassName, "#32770");
            //ChooseFileDialog.TechnologyName = "MSAA";
            //ChooseFileDialog.Find();

            ////var viewList = new WinList(ChooseFileDialog);

            ////viewList.SearchProperties[WinList.PropertyNames.Name] = "Items View";
            ////viewList.WindowTitles.Add("Choose File to Upload");
            ////var list = viewList.Items.ToList();
            ////Mouse.DoubleClick(list[6]);
            ////Playback.Wait(10000);
            //WinEdit fileName = new WinEdit(ChooseFileDialog);
            //fileName.SearchProperties.Add(WinEdit.PropertyNames.Name, "File name:");
            //fileName.TechnologyName = "MSAA";


            ////string nameStr = @"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg";


            //fileName.Text = filepath;

            //WinButton openbutton = new WinButton(ChooseFileDialog);
            //openbutton.SearchProperties.Add(WinButton.PropertyNames.Name, "Open");
            //Mouse.Click(openbutton);
            //Playback.Wait(4000);
            
        }
    }
}
