//    Copyright(C) 2018  Christopher Ryan Mackay

//    This program is free software: you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation, either version 3 of the License, or
//    (at your option) any later version.

//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.See the
//    GNU General Public License for more details.

//    You should have received a copy of the GNU General Public License
//    along with this program.If not, see<https://www.gnu.org/licenses/>.

using System;
using System.Collections.Generic;
using System.Windows.Media.Imaging;
using Autodesk.Revit.UI;
using Autodesk.Revit.Attributes;

namespace CRMTools
{
    [TransactionAttribute(TransactionMode.Manual)]
    [RegenerationAttribute(RegenerationOption.Manual)]

    public class AddPanel : IExternalApplication
    {
        public Result OnStartup(UIControlledApplication application)
        {

            // Create a custom ribbon tab
            string tabName = "CRM Tools";
            application.CreateRibbonTab(tabName);

            string revitVersion = string.Empty;
            revitVersion = "v2017";

            string commandsPath = "";
            commandsPath = @"C:\Users\" + Environment.UserName + @"\Documents\CRMRevitTools\" + revitVersion + @"\Commands\";

            string iconsPath = "";
            iconsPath = @"C:\Users\" + Environment.UserName + @"\Documents\CRMRevitTools\" + revitVersion + @"\RevitIcons\";
            
            #region CreateRevitSheets

            // Create a push button
            PushButtonData btnCreateRevitSheets = new PushButtonData("cmdCreateRevitSheets", "Create \nRevit Sheets", commandsPath + "CreateRevitSheets.dll", "CreateRevitSheets.Class1");
            btnCreateRevitSheets.ToolTip = "Creates sheet views from a .csv file.";
            btnCreateRevitSheets.LongDescription = "Create large numbers of sheets with the same titleblock. Manually create sheets or load them from a .csv file." +
                                                   "CSV files can be created with Microsoft Excel. The Sheet Number must be in column A and the Sheet Name must be in Column B. Each sheet should have its own row. " +
                                                   "Sheet 1 in row 1, sheet 2 in row 2, etc.";

            // create bitmap image for button
            Uri uriLargeImage_CreateRevitSheets = new Uri(iconsPath + @"32x32\cmdRevitSheetsImage_32x32.bmp");
            BitmapImage largeImage_CreateRevitSheets = new BitmapImage(uriLargeImage_CreateRevitSheets);

            // create bitmap image for button
            Uri uriSmallImage_CreateRevitSheets = new Uri(iconsPath + @"16x16\cmdRevitSheetsImage_16x16.bmp");
            BitmapImage smallImage_CreateRevitSheets = new BitmapImage(uriSmallImage_CreateRevitSheets);

            btnCreateRevitSheets.LargeImage = largeImage_CreateRevitSheets;
            btnCreateRevitSheets.Image = smallImage_CreateRevitSheets;

            #endregion
            
            #region SharedParameterCreator

            // Create a push button
            PushButtonData btnSharedParameterCreator = new PushButtonData("cmdSharedParameterCreator", "Shared \nParameter Creator", commandsPath + "SharedParameterCreator.dll", "SharedParameterCreator.Class1");
            btnSharedParameterCreator.ToolTip = "Create a Shared Parameter file from a CSV (Comma delimited) (.csv) file list";
            btnSharedParameterCreator.LongDescription = "Create large numbers of Shared Parameters. To use this program, first a file with the .csv extension must be created, which can be stored anywhere. " +
                                                        "CSV files can be created with Microsoft Excel.\n\n" +
                                                        "Column A: Category (e.g. Mechanical Equipment)\n" +
                                                        "Column B: Shared Parameter Group (User Determined)\n" +
                                                        "Column C: Data Type (e.g. Number, Integer, Text, YesNo)\n" +
                                                        "Column D: Binding Type (e.g. Instance, Type)\n" +
                                                        "Column E: Parameter Name (User Determined)\n\n" +
                                                        "Parameters are grouped under Data in Properties";

            // create bitmap image for button
            Uri uriLargeImage_SharedParameterCreator = new Uri(iconsPath + @"32x32\cmdSharedParameterCreator_32x32.bmp");
            BitmapImage largeImage_SharedParameterCreator = new BitmapImage(uriLargeImage_SharedParameterCreator);

            // create bitmap image for button
            Uri uriSmallImage_SharedParameterCreator = new Uri(iconsPath + @"16x16\cmdSharedParameterCreator_16x16.bmp");
            BitmapImage smallImage_SharedParameterCreator = new BitmapImage(uriSmallImage_SharedParameterCreator);

            btnSharedParameterCreator.LargeImage = largeImage_SharedParameterCreator;
            btnSharedParameterCreator.Image = smallImage_SharedParameterCreator;

            #endregion

            #region SheetRenamer

            PushButtonData btnSheetRenamer = new PushButtonData("cmdSheetRenamer", "Sheet \nRenamer", commandsPath + "SheetRenamer.dll", "SheetRenamer.Class1");
            btnSheetRenamer.ToolTip = "Rename all sheets to DPS standard file naming convention.";
            btnSheetRenamer.LongDescription = "Create a sheet set within Revit and assign the sheets you want to print. Once the sheets are printed, browse to the directory where they are saved. " + 
                                              "Select the sheet set that you used to print and click OK.\n\n" + 
                                              "NOTE: Ensure that the Project Number is set within Project Information for proper file naming.";

            // create bitmap image for button
            Uri uriLargeImage_SheetRenamer = new Uri(iconsPath + @"32x32\cmdSheetRenamer_32x32.bmp");
            BitmapImage largeImage_SheetRenamer = new BitmapImage(uriLargeImage_SheetRenamer);

            // create bitmap image for button
            Uri uriSmallImage_SheetRenamer = new Uri(iconsPath + @"16x16\cmdSheetRenamer_16x16.bmp");
            BitmapImage smallImage_SheetRenamer = new BitmapImage(uriSmallImage_SheetRenamer);

            btnSheetRenamer.LargeImage = largeImage_SheetRenamer;
            btnSheetRenamer.Image = smallImage_SheetRenamer;

            #endregion
            
            #region ProductionPanelItems

            // Create a ribbon panel
            RibbonPanel pnlProductionPanel = application.CreateRibbonPanel(tabName, "Production");
            // Add the buttons to the panel
            List<RibbonItem> productionButtons = new List<RibbonItem>();
            // Add the buttons to the panel
            productionButtons.Add(pnlProductionPanel.AddItem(btnCreateRevitSheets));
            productionButtons.Add(pnlProductionPanel.AddItem(btnSharedParameterCreator));
            productionButtons.Add(pnlProductionPanel.AddItem(btnSheetRenamer));

            #endregion

            return Result.Succeeded;
        }

        public Result OnShutdown(UIControlledApplication application)
        {
            // nothing to clean up
            return Result.Succeeded;
        }
    }
}
