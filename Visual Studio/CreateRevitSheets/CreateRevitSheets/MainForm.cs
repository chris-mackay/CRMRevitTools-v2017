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
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using Autodesk.Revit.DB;
using Autodesk.Revit.UI;
using System.Text;

namespace CreateRevitSheets
{
    public partial class MainForm : System.Windows.Forms.Form
    {
        #region CLASS LEVEL VARIABLES

        //REVIT
        public UIApplication revitUIApp;
        public Document revitDoc;

        //TITLEBLOCKS
        public FilteredElementCollector titleblockCollector;

        //VIEWS
        public ElementCategoryFilter viewFilter;
        public FilteredElementCollector viewCollector;

        //VIEW SHEETS
        public FilteredElementCollector viewSheetCollector;

        //ILISTS
        public IList<Element> viewList;

        //ISETS
        public ISet<ElementId> usedViewIdsOnSheet;
        public ISet<ElementId> usedViewIdList;

        //LISTS
        public List<string> usedViewNames;
        public List<string> usedViewSheetNumbers;

        //VIEW DICTIONARY
        public Dictionary<string, ElementId> viewDictionary;

        //STRINGS
        public string titleBlockName;
        
        #endregion
       
        public MainForm()
        {
            InitializeComponent();          
        }

        public MainForm(UIApplication incomingUIApp)
        {
            InitializeComponent();
            revitUIApp = incomingUIApp;
            revitDoc = revitUIApp.ActiveUIDocument.Document;

            //TITLEBLOCKS
            titleblockCollector = new FilteredElementCollector(revitDoc);
            titleblockCollector.OfCategory(BuiltInCategory.OST_TitleBlocks);
            titleblockCollector.WhereElementIsElementType(); //CONTAINS ALL THE TITLEBLOCKS IN THE PROJECT

            //VIEWS
            viewCollector = new FilteredElementCollector(revitDoc);
            viewFilter = new ElementCategoryFilter(BuiltInCategory.OST_Views);
            viewList = viewCollector.WherePasses(viewFilter).ToElements(); //CONTAINS ALL THE VIEWS IN THE PROJECT
            
            //VIEW SHEETS
            viewSheetCollector = new FilteredElementCollector(revitDoc);
            viewSheetCollector.OfClass(typeof(Autodesk.Revit.DB.ViewSheet));

            //HASH SETS
            usedViewIdsOnSheet = new HashSet<ElementId>();
            usedViewIdList = new HashSet<ElementId>(); //CONTAINS ALL THE USED VIEW ID'S IN THE PROJECT. VIEWS THAT ARE ALREADY ON A SHEET

            //LISTS
            usedViewNames = new List<string>();
            usedViewSheetNumbers = new List<string>();

            //VIEW DICTIONARY
            viewDictionary = new Dictionary<string, ElementId>();
         
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            //ALLOW THE USER TO SELECT A SHEET LIST FILE.
            OpenFileDialog ofd = new OpenFileDialog();

            string libraryPath = string.Empty;
            libraryPath = "c:\\"; //DEFAULT PATH
            ofd.InitialDirectory = libraryPath;

            ofd.Filter = "CSV (Comma delimited) (.csv) Files (*.csv)|*.csv";

            if (ofd.ShowDialog() == DialogResult.OK)
            {
                string fileName = null;
                fileName = ofd.FileName;
                txtFilename.Text = fileName;

                TaskDialog tdConfirmSheetLoad = new TaskDialog("Load Sheets");
                tdConfirmSheetLoad.MainInstruction = "Are you sure you want to load sheets from " + fileName + "?";
                tdConfirmSheetLoad.MainContent = "If you have already created sheets using 'Add Sheet', these will be overwritten.";
                tdConfirmSheetLoad.CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No;

                if (tdConfirmSheetLoad.Show() == TaskDialogResult.Yes)
                {
                    this.GetAllSheetsToCreateFromCSV(fileName); //FILLS THE LISTBOX WITH THE SHEETS YOU WANT TO CREATE
                }
            }

        }

        private void cbTitleblocks_SelectedIndexChanged(object sender, EventArgs e)
        {

            titleBlockName = cbTitleblocks.SelectedItem.ToString();
            titleBlockName = titleBlockName.Substring(titleBlockName.IndexOf(":") + 1).Trim();

            if (cbTitleblocks.SelectedIndex != -1 && lstSheetsToCreate.Items.Count > 0) //CHECKS TO MAKE SURE A TITLEBLOCK IS SELECTED AND THERE IS AT LEAST 1 SHEET TO CREATE
            {
                btnCreate.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
            }

        }

        private void btnLoad_Click(object sender, EventArgs e)
        {

            try
            {
                LoadTitleblock();
            }
            catch (Exception ex)
            {

                TaskDialog.Show("Error", ex.Message + "\n\n" + ex.Source);
            }

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (this.lstAvailableViews.SelectedItems.Count > 0)
            {

                string selectedView = string.Empty;
                selectedView = lstAvailableViews.SelectedItem.ToString();

                //GET CURRENTLY SELECTED INDEX OF SELECTED SHEET
                int selectedSheetIndex = 0;
                selectedSheetIndex = lstSheetsToCreate.SelectedIndex;

                //CHECK IF A SHEET IS SELECTED
                if (selectedSheetIndex < 0)
                {
                    TaskDialog.Show("Add View", "Select a sheet that you want to add the view to");
                }
                else
                {
                    string viewToAdd = string.Empty;
                    viewToAdd = lstViewsToAdd.Items[selectedSheetIndex].ToString();

                    if (viewToAdd != "")
                    {
                        TaskDialog.Show("Add View", "The selected sheet already has a view assigned to it");
                    }
                    else
                    {
                        //INSERT VIEW AT CURRENTLY SELECTED SHEET
                        lstViewsToAdd.Items.RemoveAt(selectedSheetIndex);
                        lstViewsToAdd.Items.Insert(selectedSheetIndex, selectedView);
                        lstAvailableViews.Items.Remove(selectedView);
                    }
                }
            }
            else
            {
                return;
            }

        }

        private void btnRemove_Click(object sender, EventArgs e)
        {

            if (this.lstViewsToAdd.SelectedItems.Count > 0)
            {
                string selectedView = string.Empty;
                selectedView = lstViewsToAdd.SelectedItem.ToString();

                int selectedViewIndex = 0;
                selectedViewIndex = lstViewsToAdd.SelectedIndex;

                if (selectedView != "")
                {
                    lstViewsToAdd.Items.Remove(selectedView);
                    lstViewsToAdd.Items.Insert(selectedViewIndex, "");
                    lstAvailableViews.Items.Add(selectedView);
                }

            }
                
            else
            {
                return;
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.GetAllAvailableViewNamesAndIds();

            this.GetAllTitleblocks(titleblockCollector); //FILLS COMBOBOX WITH ALL THE TITLEBLOCKS IN THE DOCUMENT

            cbViewTypes.SelectedIndex = 0; //SELECT FLOOR PLANS BY DEFAULT
            btnCreate.Enabled = false;
        }

        private void btnMoveSheetUp_Click(object sender, EventArgs e)
        {
            MoveSheetUp(); //MOVES LISTBOX ITEM UP THE LIST
        }

        private void btnMoveSheetDown_Click(object sender, EventArgs e)
        {
            MoveSheetDown(); //MOVES LISTBOX ITEM DOWN THE LIST
        }

        private void btnMoveViewUp_Click(object sender, EventArgs e)
        {
            MoveViewUp(); //MOVES LISTBOX ITEM UP THE LIST
        }

        private void btnMoveViewDown_Click(object sender, EventArgs e)
        {
            MoveViewDown(); //MOVES LISTBOX ITEM DOWN THE LIST
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            CreateSheets(); //MAIN FUNCTION THAT CREATES SHEETS AND ASSIGNS VIEW TO SHEETS
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Result LoadTitleblock()
        {

            //GET THE REVIT LIBRARY PATH AS DEFINED VIA THE OPTIONS DIALOG - FILE LOCATIONS TAB - PLACES BUTTON
            string libraryPath = "";
            revitUIApp.Application.GetLibraryPaths().TryGetValue("Imperial Library", out libraryPath);

            if (string.IsNullOrEmpty(libraryPath))
            {
                libraryPath = "c:\\";   //DEFAULT PATH
            }

            //ALLOW THE USER TO SELECT A FAMILY FILE.
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = libraryPath;
            openFileDialog1.Filter = "Family Files (*.rfa)|*.rfa";

            //LOAD THE FAMILY FILE
            if (DialogResult.OK == openFileDialog1.ShowDialog())
            {

                //CREATE TRANSACTION
                Transaction trans = new Transaction(revitDoc, "Load Titleblock");
                trans.Start();

                Autodesk.Revit.DB.Family family = null;
                if (revitDoc.LoadFamily(openFileDialog1.FileName, out family))
                {
                    
                    //LOADS ALL TITLEBLOCKS
                    //CREATE A FILTER TO GET ALL THE TITLEBLOCK TYPES
                    FilteredElementCollector titleblockCollector = new FilteredElementCollector(revitDoc);
                    titleblockCollector.OfCategory(BuiltInCategory.OST_TitleBlocks);
                    titleblockCollector.WhereElementIsElementType();

                    this.cbTitleblocks.Items.Clear(); //CLEARS ALL TITLEBLOCKS IN THE LIST AND RELOADS ALL TO INCLUDE THE RECENTLY ADDED TITLEBLOCK

                    this.GetAllTitleblocks(titleblockCollector); //FILLS COMBOBOX WITH ALL THE TITLEBLOCKS IN THE DOCUMENT

                }
                else
                {
                    TaskDialog.Show("Revit", "Can't load the family file.");
                    return Result.Failed;
                }

                trans.Commit();

            }

            return Result.Succeeded;
        }              
       
        public void GetAllSheetsToCreateFromCSV(string _filename)
        {
            List<string> disregardedSheetsNumbersList = new List<string>();

            StringBuilder disregardedSheetNumbers = new StringBuilder();

            string csvLine = null;
            StreamReader reader = new StreamReader(_filename);

            lstSheetsToCreate.Items.Clear();

            while ((csvLine = reader.ReadLine()) != null)
            {
                char[] separator = new char[] { ',' };
                string[] values = csvLine.Split(separator, StringSplitOptions.None);

                //MAKE SURE BOTH VALUES ARE VALID
                if (values[0] != null && values[0].Length > 0 && values[1] != null && values[1].Length > 0)
                {   
                    string sheetNumber = null;
                    string sheetName = null;

                    sheetNumber = values[0];
                    sheetName = values[1];

                    string entry = string.Empty;

                    entry = sheetNumber + ":" + sheetName;

                    if (usedViewSheetNumbers.Contains(sheetNumber))
                    {
                        disregardedSheetsNumbersList.Add(sheetNumber);
                        disregardedSheetNumbers.Append(sheetNumber + "\n");
                    }
                    else
                    {
                        this.lstSheetsToCreate.Items.Add(entry); //ADDS THE NEW SHEET TO THE LIST
                        this.lstViewsToAdd.Items.Add(""); //CREATES A DEFAULT EMPTY SHEET BY ADDING A VIEW NAME OF ""
                    }
                    
                }
            }

            if (disregardedSheetsNumbersList.Count > 0)
            {   
                TaskDialog taskDialog = new TaskDialog("Create Revit Sheets");

                taskDialog.MainIcon = TaskDialogIcon.TaskDialogIconNone;
                taskDialog.MainInstruction = "The following sheets already exist in the project and will not be added to the list";
                taskDialog.MainContent = disregardedSheetNumbers.ToString();
                taskDialog.Show();
            }

            if (cbTitleblocks.SelectedIndex != -1 && lstSheetsToCreate.Items.Count > 0) //CHECKS TO MAKE SURE A TITLEBLOCK IS SELECTED AND THERE IS AT LEAST 1 SHEET TO CREATE
            {
                btnCreate.Enabled = true;
            }
            else
            {
                btnCreate.Enabled = false;
            }

        }

        public void GetAllAvailableViewNamesAndIds()
        {
            foreach (ViewSheet sheet in viewSheetCollector)
            {
                usedViewSheetNumbers.Add(sheet.SheetNumber);
                usedViewIdsOnSheet = sheet.GetAllPlacedViews();

                foreach (ElementId id in usedViewIdsOnSheet)
                {
                    usedViewIdList.Add(id);

                    Element elem = null;
                    elem = revitDoc.GetElement(id);
                    usedViewNames.Add(elem.Name);

                }
            }
            
            foreach (Autodesk.Revit.DB.View v in viewList)
            {
                if (!usedViewNames.Contains(v.ViewName))
                {
                    viewDictionary.Add(v.Name, v.Id);
                }
            }
        }

        public void GetAllTitleblocks(FilteredElementCollector _collector)
        {
            foreach (FamilySymbol f in _collector)
            {
                if (f.Name != null && f.Name != "Start Page")
                {
                    this.cbTitleblocks.Items.Add(f.Family.Name + " : " + f.Name); //FILLS COMBOBOX WITH ALL THE TITLEBLOCKS IN THE DOCUMENT
                }
            }
        }

        public void GetAllAvailableViewsAndFill_lstAvailableViews(IList<Element> _viewList, ViewType _viewType)
        {
            foreach (Autodesk.Revit.DB.View v in _viewList)
            {
                if (v.ViewType == _viewType)
                {
                    if (!lstAvailableViews.Items.Contains(v.ViewName.ToString()) && !lstViewsToAdd.Items.Contains(v.ViewName.ToString()) && !usedViewNames.Contains(v.ViewName.ToString()))
                    {                                               
                        this.lstAvailableViews.Items.Add(v.ViewName); //FILLS LISTBOX WITH ALL THE AVAILABLE VIEWS IN THE DOCUMENT BASED ON SELECTED VIEW TYPE
                    }
                }
            }
        }

        public void MoveSheetUp()
        {
            MoveItem(-1, lstSheetsToCreate);
        }

        public void MoveSheetDown()
        {
            MoveItem(1, lstSheetsToCreate);
        }

        public void MoveViewUp()
        {
            MoveItem(-1, lstViewsToAdd);
        }

        public void MoveViewDown()
        {
            MoveItem(1, lstViewsToAdd);
        }

        public void MoveItem(int direction, ListBox listBox)
        {
            //CHECK SELECTED ITEM
            if (listBox.SelectedItem == null || listBox.SelectedIndex < 0)
            {
                return; //NO ITEM SELECTED - DO NOTHING
            }

            //CALCULATE NEW INDEX USING MOVE DIRECTION
            int newIndex = listBox.SelectedIndex + direction;

            //CHECK BOUNDS OF THE RANGE
            if (newIndex < 0 || newIndex >= listBox.Items.Count)
            {
                return; //INDEX OUT OF RANGE - DO NOTHING
            }

            object selected = listBox.SelectedItem;

            //REMOVING REMOVABLE ELEMENT
            listBox.Items.Remove(selected);
            //INSERT IT IN NEW POSITION
            listBox.Items.Insert(newIndex, selected);
            //RESTORE SELECTION
            listBox.SetSelected(newIndex, true);

        }

        public void CreateSheets()
        {
            TaskDialog taskDialog = new TaskDialog("Create Revit Sheets");

            taskDialog.MainIcon = TaskDialogIcon.TaskDialogIconNone;
            taskDialog.MainInstruction = "Are you sure you want to create these sheets?";
            taskDialog.CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No;

            string EXviewId = string.Empty; //test
            string EXviewToAdd = string.Empty; //test

            if (this.cbTitleblocks.Items.Count == 0)
            {
                TaskDialog.Show("No Titleblocks Loaded", "Make sure you have a titleblock loaded and selected before continuing.");
            }
            else
            {
                if (taskDialog.Show() == TaskDialogResult.Yes)
                {
                    Transaction trans = new Transaction(revitDoc, "Create Revit Sheets");

                    try
                    {
                        
                        #region SELECTS SPECIFIC TITLEBLOCK AND VIEW FROM DOCUMENT

                        var query = from element in titleblockCollector where element.Name == this.titleBlockName select element;
                        List<Element> titleblockList = query.ToList();
                        ElementId titleBlockid = titleblockList[0].Id;
                        
                        #endregion

                        #region  READ FROM lstSheetsToCreate AND CREATE SHEETS

                        trans.Start(); //STARTS THE Create Revit Sheets TRANSACTION

                        int rowIndex = 0; //INTEGER TO INCREMENT TO GET THE NEXT FLOOR PLAN NAME FROM lstViewsToAdd

                        foreach (string sheet in lstSheetsToCreate.Items)
                        {
                            char[] separator = new char[] { ':' };
                            string[] values = sheet.Split(separator, StringSplitOptions.None);

                            string viewToAdd = string.Empty;
                            viewToAdd = this.lstViewsToAdd.Items[rowIndex].ToString(); //SELECT A SPECIFIC VIEW
                            EXviewToAdd = viewToAdd; //test    

                            if (viewToAdd != string.Empty) //IF THERE IS A VIEW ASSIGNED TO A SHEET THEN CREATE A VIEWPORT
                            {

                                ViewSheet vsSheet = ViewSheet.Create(revitDoc, titleBlockid); //CREATES A NEW SHEET

                                vsSheet.SheetNumber = values[0]; //SETS THE SHEET NUMBER
                                vsSheet.Name = values[1]; //SETS THE SHEET NAME

                                ElementId viewId = null;
                                viewId = viewDictionary[viewToAdd];
                                EXviewId = viewId.ToString(); //test

                                //GETS THE CENTER OF THE SCREEN TO ADD THE VIEW
                                UV location = new UV((vsSheet.Outline.Max.U - vsSheet.Outline.Min.U) / 2, (vsSheet.Outline.Max.V - vsSheet.Outline.Min.V) / 2);

                                Viewport.Create(revitDoc, vsSheet.Id, viewId, new XYZ(location.U, location.V, 0)); //PLACES THE VIEW ONTO THE SHEET

                            }
                            else //IF THERE IS NOT A VIEW ASSIGNED TO A SHEET THEN JUST CREATE AN EMPTY SHEET
                            {
                                ViewSheet vsSheet = ViewSheet.Create(revitDoc, titleBlockid); //CREATES A NEW SHEET

                                vsSheet.SheetNumber = values[0]; //SETS THE SHEET NUMBER
                                vsSheet.Name = values[1]; //SETS THE SHEET NAME

                            }

                            rowIndex += 1; //ADDS 1 TO ROWINDEX TO GET THE NEXT FLOOR PLAN NAME FROM lstViewsToAdd
                            
                        }

                        trans.Commit();
                        this.Close();
                        
                        #endregion
                    }
                    catch (Exception ex)
                    {
                        TaskDialog errorMessage = new TaskDialog("Create Sheet Error");
                        errorMessage.MainInstruction = "An error occurrued while creating sheets." + Environment.NewLine + "Please read the following error message below";
                        errorMessage.MainContent = ex.Message + Environment.NewLine + "viewId: " + EXviewId + Environment.NewLine + "View Name: " + EXviewToAdd;
                        errorMessage.Show();

                        trans.Dispose();
                    }
                }
            }
        }

        private void cbViews_SelectedIndexChanged(object sender, EventArgs e)
        {

            string viewTypeSelection = string.Empty;
            viewTypeSelection = cbViewTypes.SelectedItem.ToString();

            //GET ALL VIEW TYPES BASED ON USER SELECTION
            //FLOOR PLANS
            //CEILING PLANS
            //DRAFTING VIEWS
            //LEGENDS
            //SECTIONS
            //ELEVATIONS
            switch (viewTypeSelection)
            {
                case "Floor Plans":
                    lstAvailableViews.Items.Clear();
                    this.GetAllAvailableViewsAndFill_lstAvailableViews(viewList, ViewType.FloorPlan); //FILLS LISTBOX WITH ALL THE FLOOR PLANS IN THE DOCUMENT  

                    //REMOVES REVIT DEFAULT VIEWS THAT DON'T ACTUALLY EXIST IN THE PROJECT
                    this.lstAvailableViews.Items.Remove("Architectural Plan");
                    this.lstAvailableViews.Items.Remove("Electrical Plan");
                    this.lstAvailableViews.Items.Remove("Mechanical Plan");
                    this.lstAvailableViews.Items.Remove("Plumbing Plan");
                    break;
                case "Ceiling Plans":
                    lstAvailableViews.Items.Clear();
                    this.GetAllAvailableViewsAndFill_lstAvailableViews(viewList, ViewType.CeilingPlan); //FILLS LISTBOX WITH ALL THE LEGENDS IN THE DOCUMENT  

                    //REMOVES REVIT DEFAULT VIEWS THAT DON'T ACTUALLY EXIST IN THE PROJECT
                    this.lstAvailableViews.Items.Remove("Architectural Reflected Ceiling Plan");
                    this.lstAvailableViews.Items.Remove("Electrical Ceiling");
                    this.lstAvailableViews.Items.Remove("Mechanical Ceiling");
                    this.lstAvailableViews.Items.Remove("Plumbing Ceiling");
                    break;
                case "Drafting Views":
                    lstAvailableViews.Items.Clear();
                    this.GetAllAvailableViewsAndFill_lstAvailableViews(viewList, ViewType.DraftingView); //FILLS LISTBOX WITH ALL THE DRAFTING VIEWS IN THE DOCUMENT  
                    break;
                case "Legends":
                    lstAvailableViews.Items.Clear();
                    this.GetAllAvailableViewsAndFill_lstAvailableViews(viewList, ViewType.Legend); //FILLS LISTBOX WITH ALL THE LEGENDS IN THE DOCUMENT  
                    break;
                case "Sections":
                    lstAvailableViews.Items.Clear();
                    this.GetAllAvailableViewsAndFill_lstAvailableViews(viewList, ViewType.Section); //FILLS LISTBOX WITH ALL THE SECTIONS IN THE DOCUMENT  

                    //REMOVES REVIT DEFAULT VIEWS THAT DON'T ACTUALLY EXIST IN THE PROJECT
                    this.lstAvailableViews.Items.Remove("Architectural Section");
                    this.lstAvailableViews.Items.Remove("Electrical Section");
                    this.lstAvailableViews.Items.Remove("Mechanical Section");
                    this.lstAvailableViews.Items.Remove("Plumbing Section");
                    break;
                case "Elevations":
                    lstAvailableViews.Items.Clear();
                    this.GetAllAvailableViewsAndFill_lstAvailableViews(viewList, ViewType.Elevation); //FILLS LISTBOX WITH ALL THE ELEVATIONS IN THE DOCUMENT 
                    break;
                default:
                    break;
            }            
        }

        private void btnAddSheet_Click(object sender, EventArgs e)
        {
            frmAddSheet new_frmAddSheet = new frmAddSheet();

            if (new_frmAddSheet.ShowDialog() == DialogResult.OK)
            {
                List<string> usedAddSheetNumbers = new List<string>();

                string sheetNumber = string.Empty;
                string sheetName = string.Empty;

                sheetNumber = new_frmAddSheet.txtSheetNumber.Text;
                sheetName = new_frmAddSheet.txtSheetName.Text;

                string newEntry = string.Empty;

                newEntry = sheetNumber + ":" + sheetName;

                foreach (string sheet in lstSheetsToCreate.Items)
                {
                    char[] separator = new char[] { ':' };
                    string[] values = sheet.Split(separator, StringSplitOptions.None);
                    usedAddSheetNumbers.Add(values[0]);
                }

                if (usedViewSheetNumbers.Contains(sheetNumber))
                {
                    TaskDialog taskDialog = new TaskDialog("Create Revit Sheets");

                    taskDialog.MainIcon = TaskDialogIcon.TaskDialogIconNone;
                    taskDialog.MainInstruction = "The sheet number you are trying to create already exists in the project";
                    taskDialog.Show();
                }
                else if(usedAddSheetNumbers.Contains(sheetNumber))
                {
                    TaskDialog taskDialog = new TaskDialog("Create Revit Sheets");

                    taskDialog.MainIcon = TaskDialogIcon.TaskDialogIconNone;
                    taskDialog.MainInstruction = "The sheet number you are trying to create already exists in the list";
                    taskDialog.Show();
                }
                else
                {
                    this.lstSheetsToCreate.Items.Add(newEntry); //ADDS THE NEW SHEET TO THE LIST
                    usedAddSheetNumbers.Add(sheetNumber);
                    this.lstViewsToAdd.Items.Add(""); //CREATES A DEFAULT EMPTY SHEET BY ADDING A VIEW NAME OF ""
                }

                if (cbTitleblocks.SelectedIndex != -1 && lstSheetsToCreate.Items.Count > 0) //CHECKS TO MAKE SURE A TITLEBLOCK IS SELECTED AND THERE IS AT LEAST 1 SHEET TO CREATE
                {
                    btnCreate.Enabled = true;
                }
                else
                {
                    btnCreate.Enabled = false;
                }

            }

        }

        private void btnRemoveSheet_Click(object sender, EventArgs e)
        {
            if (this.lstSheetsToCreate.SelectedItems.Count > 0)
            {

                //GET CURRENTLY SELECTED INDEX OF SELECTED SHEET
                int selectedSheetIndex = 0;
                selectedSheetIndex = lstSheetsToCreate.SelectedIndex;

                string viewToRemove = string.Empty;
                viewToRemove = lstViewsToAdd.Items[selectedSheetIndex].ToString();

                string sheetToRemove = string.Empty;
                sheetToRemove = this.lstSheetsToCreate.SelectedItem.ToString();

                TaskDialog tdConfirmRemoveSheet = new TaskDialog("Remove Sheet");
                tdConfirmRemoveSheet.MainInstruction = "Are you sure you want to remove this sheet?";
                tdConfirmRemoveSheet.MainContent = sheetToRemove;
                tdConfirmRemoveSheet.CommonButtons = TaskDialogCommonButtons.Yes | TaskDialogCommonButtons.No;

                if (tdConfirmRemoveSheet.Show() == TaskDialogResult.Yes)
                {
                    if (viewToRemove != "")
                    {
                        //REMOVE THE ASSIGNED VIEW AND ADD IT BACK TO AVAILABLE VIEWS
                        lstAvailableViews.Items.Add(viewToRemove);
                        lstViewsToAdd.Items.Remove(viewToRemove);
                    }
                    else
                    {
                        //IF THE VIEW IS A DEFAULT EMPTY VIEW THEN JUST REMOVE IT
                        lstViewsToAdd.Items.Remove(viewToRemove);
                    }

                    //REMOVE THE SHEET
                    this.lstSheetsToCreate.Items.Remove(sheetToRemove);
                }

                if (cbTitleblocks.SelectedIndex != -1 && lstSheetsToCreate.Items.Count > 0) //CHECKS TO MAKE SURE A TITLEBLOCK IS SELECTED AND THERE IS AT LEAST 1 SHEET TO CREATE
                {
                    btnCreate.Enabled = true;
                }
                else
                {
                    btnCreate.Enabled = false;
                }

            }
        }

        private void btnEditSheet_Click(object sender, EventArgs e)
        {
            frmAddSheet new_frmAddSheet = new frmAddSheet();
            new_frmAddSheet.Text = "Edit Sheet";

            if (this.lstSheetsToCreate.SelectedItems.Count > 0)
            {   
                string sheetToEdit = string.Empty;
                int sheetIndex = 0;
                sheetToEdit = this.lstSheetsToCreate.SelectedItem.ToString();
                sheetIndex = this.lstSheetsToCreate.SelectedIndex;

                string oldSheetNumber = string.Empty;
                string oldSheetName = string.Empty;

                char[] separator = new char[] { ':' };
                string[] values = sheetToEdit.Split(separator, StringSplitOptions.None);

                oldSheetNumber = values[0];
                oldSheetName = values[1];

                new_frmAddSheet.txtSheetNumber.Text = oldSheetNumber;
                new_frmAddSheet.txtSheetName.Text = oldSheetName;

                if (new_frmAddSheet.ShowDialog() == DialogResult.OK)
                {
                    List<string> usedAddSheetNumbers = new List<string>();

                    string newSheetNumber = string.Empty;
                    string newSheetName = string.Empty;

                    newSheetNumber = new_frmAddSheet.txtSheetNumber.Text;
                    newSheetName = new_frmAddSheet.txtSheetName.Text;

                    string newEntry = string.Empty;

                    newEntry = newSheetNumber + ":" + newSheetName;

                    if (newSheetNumber != oldSheetNumber)
                    {
                        foreach (string sheet in lstSheetsToCreate.Items)
                        {
                            char[] checkSeparator = new char[] { ':' };
                            string[] checkValues = sheet.Split(checkSeparator, StringSplitOptions.None);
                            usedAddSheetNumbers.Add(checkValues[0]);
                        }

                        if (usedViewSheetNumbers.Contains(newSheetNumber))
                        {
                            TaskDialog taskDialog = new TaskDialog("Create Revit Sheets");

                            taskDialog.MainIcon = TaskDialogIcon.TaskDialogIconNone;
                            taskDialog.MainInstruction = "The sheet number you are trying to create already exists in the project";
                            taskDialog.Show();
                        }
                        else if (usedAddSheetNumbers.Contains(newSheetNumber))
                        {
                            TaskDialog taskDialog = new TaskDialog("Create Revit Sheets");

                            taskDialog.MainIcon = TaskDialogIcon.TaskDialogIconNone;
                            taskDialog.MainInstruction = "The sheet number you are trying to create already exists in the list";
                            taskDialog.Show();
                        }
                        else
                        {
                            this.lstSheetsToCreate.Items.RemoveAt(sheetIndex);
                            this.lstSheetsToCreate.Items.Insert(sheetIndex, newEntry);
                        }
                    }
                }
            }
        }

        private void lstSheetsToCreate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstViewsToAdd.Focused == false)
            {
                lstViewsToAdd.ClearSelected();
            }
        }

        private void lstViewsToAdd_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstSheetsToCreate.Focused == false)
            {
                lstSheetsToCreate.ClearSelected();
            }
        }
    }
}
