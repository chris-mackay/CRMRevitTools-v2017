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

namespace CreateRevitSheets
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbTitleblocks = new System.Windows.Forms.ComboBox();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.lblSheetList = new System.Windows.Forms.Label();
            this.lblTitleblocks = new System.Windows.Forms.Label();
            this.btnLoad = new System.Windows.Forms.Button();
            this.lstAvailableViews = new System.Windows.Forms.ListBox();
            this.lstSheetsToCreate = new System.Windows.Forms.ListBox();
            this.lstViewsToAdd = new System.Windows.Forms.ListBox();
            this.lblViews = new System.Windows.Forms.Label();
            this.lblSheets = new System.Windows.Forms.Label();
            this.lblViewsToAdd = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.btnMoveViewUp = new System.Windows.Forms.Button();
            this.btnMoveViewDown = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnMoveSheetDown = new System.Windows.Forms.Button();
            this.btnMoveSheetUp = new System.Windows.Forms.Button();
            this.btnEditSheet = new System.Windows.Forms.Button();
            this.btnRemoveSheet = new System.Windows.Forms.Button();
            this.btnAddSheet = new System.Windows.Forms.Button();
            this.cbViewTypes = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbTitleblocks
            // 
            this.cbTitleblocks.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.cbTitleblocks.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTitleblocks.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbTitleblocks.FormattingEnabled = true;
            this.cbTitleblocks.Location = new System.Drawing.Point(9, 79);
            this.cbTitleblocks.Name = "cbTitleblocks";
            this.cbTitleblocks.Size = new System.Drawing.Size(558, 21);
            this.cbTitleblocks.TabIndex = 4;
            this.cbTitleblocks.SelectedIndexChanged += new System.EventHandler(this.cbTitleblocks_SelectedIndexChanged);
            // 
            // txtFilename
            // 
            this.txtFilename.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.txtFilename.Enabled = false;
            this.txtFilename.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txtFilename.Location = new System.Drawing.Point(9, 34);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.ReadOnly = true;
            this.txtFilename.Size = new System.Drawing.Size(558, 20);
            this.txtFilename.TabIndex = 1;
            // 
            // btnCreate
            // 
            this.btnCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCreate.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnCreate.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCreate.Location = new System.Drawing.Point(516, 502);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(75, 23);
            this.btnCreate.TabIndex = 1;
            this.btnCreate.Text = "Create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCancel.Location = new System.Drawing.Point(597, 502);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnBrowse.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnBrowse.Location = new System.Drawing.Point(573, 33);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBrowse.TabIndex = 2;
            this.btnBrowse.Text = "Browse...";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblSheetList
            // 
            this.lblSheetList.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSheetList.AutoSize = true;
            this.lblSheetList.BackColor = System.Drawing.Color.Transparent;
            this.lblSheetList.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSheetList.Location = new System.Drawing.Point(9, 16);
            this.lblSheetList.Name = "lblSheetList";
            this.lblSheetList.Size = new System.Drawing.Size(66, 13);
            this.lblSheetList.TabIndex = 0;
            this.lblSheetList.Text = "Sheet list file";
            // 
            // lblTitleblocks
            // 
            this.lblTitleblocks.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblTitleblocks.AutoSize = true;
            this.lblTitleblocks.BackColor = System.Drawing.Color.Transparent;
            this.lblTitleblocks.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblTitleblocks.Location = new System.Drawing.Point(9, 61);
            this.lblTitleblocks.Name = "lblTitleblocks";
            this.lblTitleblocks.Size = new System.Drawing.Size(91, 13);
            this.lblTitleblocks.TabIndex = 3;
            this.lblTitleblocks.Text = "Select a titleblock";
            // 
            // btnLoad
            // 
            this.btnLoad.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnLoad.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnLoad.Location = new System.Drawing.Point(573, 78);
            this.btnLoad.Name = "btnLoad";
            this.btnLoad.Size = new System.Drawing.Size(75, 23);
            this.btnLoad.TabIndex = 5;
            this.btnLoad.Text = "Load...";
            this.btnLoad.UseVisualStyleBackColor = true;
            this.btnLoad.Click += new System.EventHandler(this.btnLoad_Click);
            // 
            // lstAvailableViews
            // 
            this.lstAvailableViews.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lstAvailableViews.FormattingEnabled = true;
            this.lstAvailableViews.HorizontalScrollbar = true;
            this.lstAvailableViews.Location = new System.Drawing.Point(9, 144);
            this.lstAvailableViews.Name = "lstAvailableViews";
            this.lstAvailableViews.Size = new System.Drawing.Size(166, 277);
            this.lstAvailableViews.TabIndex = 7;
            // 
            // lstSheetsToCreate
            // 
            this.lstSheetsToCreate.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lstSheetsToCreate.FormattingEnabled = true;
            this.lstSheetsToCreate.HorizontalScrollbar = true;
            this.lstSheetsToCreate.Location = new System.Drawing.Point(310, 144);
            this.lstSheetsToCreate.Name = "lstSheetsToCreate";
            this.lstSheetsToCreate.Size = new System.Drawing.Size(166, 277);
            this.lstSheetsToCreate.TabIndex = 15;
            this.lstSheetsToCreate.SelectedIndexChanged += new System.EventHandler(this.lstSheetsToCreate_SelectedIndexChanged);
            // 
            // lstViewsToAdd
            // 
            this.lstViewsToAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lstViewsToAdd.FormattingEnabled = true;
            this.lstViewsToAdd.HorizontalScrollbar = true;
            this.lstViewsToAdd.Location = new System.Drawing.Point(482, 144);
            this.lstViewsToAdd.Name = "lstViewsToAdd";
            this.lstViewsToAdd.Size = new System.Drawing.Size(166, 277);
            this.lstViewsToAdd.TabIndex = 19;
            this.lstViewsToAdd.SelectedIndexChanged += new System.EventHandler(this.lstViewsToAdd_SelectedIndexChanged);
            // 
            // lblViews
            // 
            this.lblViews.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblViews.AutoSize = true;
            this.lblViews.BackColor = System.Drawing.Color.Transparent;
            this.lblViews.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblViews.Location = new System.Drawing.Point(9, 126);
            this.lblViews.Name = "lblViews";
            this.lblViews.Size = new System.Drawing.Size(81, 13);
            this.lblViews.TabIndex = 6;
            this.lblViews.Text = "Available Views";
            // 
            // lblSheets
            // 
            this.lblSheets.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblSheets.AutoSize = true;
            this.lblSheets.BackColor = System.Drawing.Color.Transparent;
            this.lblSheets.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblSheets.Location = new System.Drawing.Point(310, 126);
            this.lblSheets.Name = "lblSheets";
            this.lblSheets.Size = new System.Drawing.Size(80, 13);
            this.lblSheets.TabIndex = 14;
            this.lblSheets.Text = "Sheet to create";
            // 
            // lblViewsToAdd
            // 
            this.lblViewsToAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.lblViewsToAdd.AutoSize = true;
            this.lblViewsToAdd.BackColor = System.Drawing.Color.Transparent;
            this.lblViewsToAdd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblViewsToAdd.Location = new System.Drawing.Point(482, 126);
            this.lblViewsToAdd.Name = "lblViewsToAdd";
            this.lblViewsToAdd.Size = new System.Drawing.Size(74, 13);
            this.lblViewsToAdd.TabIndex = 18;
            this.lblViewsToAdd.Text = "View for sheet";
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAdd.Location = new System.Drawing.Point(181, 255);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(123, 23);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Add View -->";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemove.Location = new System.Drawing.Point(181, 284);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(123, 23);
            this.btnRemove.TabIndex = 13;
            this.btnRemove.Text = "<-- Remove View";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // btnMoveViewUp
            // 
            this.btnMoveViewUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMoveViewUp.Location = new System.Drawing.Point(487, 426);
            this.btnMoveViewUp.Name = "btnMoveViewUp";
            this.btnMoveViewUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveViewUp.TabIndex = 20;
            this.btnMoveViewUp.Text = "Move Up";
            this.btnMoveViewUp.UseVisualStyleBackColor = true;
            this.btnMoveViewUp.Click += new System.EventHandler(this.btnMoveViewUp_Click);
            // 
            // btnMoveViewDown
            // 
            this.btnMoveViewDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMoveViewDown.Location = new System.Drawing.Point(568, 426);
            this.btnMoveViewDown.Name = "btnMoveViewDown";
            this.btnMoveViewDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveViewDown.TabIndex = 21;
            this.btnMoveViewDown.Text = "Move Down";
            this.btnMoveViewDown.UseVisualStyleBackColor = true;
            this.btnMoveViewDown.Click += new System.EventHandler(this.btnMoveViewDown_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.btnMoveSheetDown);
            this.panel1.Controls.Add(this.btnMoveSheetUp);
            this.panel1.Controls.Add(this.btnEditSheet);
            this.panel1.Controls.Add(this.btnRemoveSheet);
            this.panel1.Controls.Add(this.btnAddSheet);
            this.panel1.Controls.Add(this.cbViewTypes);
            this.panel1.Controls.Add(this.btnMoveViewDown);
            this.panel1.Controls.Add(this.btnLoad);
            this.panel1.Controls.Add(this.btnRemove);
            this.panel1.Controls.Add(this.lblTitleblocks);
            this.panel1.Controls.Add(this.btnMoveViewUp);
            this.panel1.Controls.Add(this.lblSheetList);
            this.panel1.Controls.Add(this.btnAdd);
            this.panel1.Controls.Add(this.btnBrowse);
            this.panel1.Controls.Add(this.lstViewsToAdd);
            this.panel1.Controls.Add(this.lblViewsToAdd);
            this.panel1.Controls.Add(this.lstAvailableViews);
            this.panel1.Controls.Add(this.txtFilename);
            this.panel1.Controls.Add(this.cbTitleblocks);
            this.panel1.Controls.Add(this.lblSheets);
            this.panel1.Controls.Add(this.lstSheetsToCreate);
            this.panel1.Controls.Add(this.lblViews);
            this.panel1.Location = new System.Drawing.Point(13, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(659, 479);
            this.panel1.TabIndex = 0;
            // 
            // btnMoveSheetDown
            // 
            this.btnMoveSheetDown.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMoveSheetDown.Location = new System.Drawing.Point(396, 426);
            this.btnMoveSheetDown.Name = "btnMoveSheetDown";
            this.btnMoveSheetDown.Size = new System.Drawing.Size(75, 23);
            this.btnMoveSheetDown.TabIndex = 17;
            this.btnMoveSheetDown.Text = "Move Down";
            this.btnMoveSheetDown.UseVisualStyleBackColor = true;
            this.btnMoveSheetDown.Click += new System.EventHandler(this.btnMoveSheetDown_Click);
            // 
            // btnMoveSheetUp
            // 
            this.btnMoveSheetUp.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnMoveSheetUp.Location = new System.Drawing.Point(315, 426);
            this.btnMoveSheetUp.Name = "btnMoveSheetUp";
            this.btnMoveSheetUp.Size = new System.Drawing.Size(75, 23);
            this.btnMoveSheetUp.TabIndex = 16;
            this.btnMoveSheetUp.Text = "Move Up";
            this.btnMoveSheetUp.UseVisualStyleBackColor = true;
            this.btnMoveSheetUp.Click += new System.EventHandler(this.btnMoveSheetUp_Click);
            // 
            // btnEditSheet
            // 
            this.btnEditSheet.Location = new System.Drawing.Point(181, 173);
            this.btnEditSheet.Name = "btnEditSheet";
            this.btnEditSheet.Size = new System.Drawing.Size(123, 23);
            this.btnEditSheet.TabIndex = 10;
            this.btnEditSheet.Text = "Edit Sheet";
            this.btnEditSheet.UseVisualStyleBackColor = true;
            this.btnEditSheet.Click += new System.EventHandler(this.btnEditSheet_Click);
            // 
            // btnRemoveSheet
            // 
            this.btnRemoveSheet.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnRemoveSheet.Location = new System.Drawing.Point(181, 202);
            this.btnRemoveSheet.Name = "btnRemoveSheet";
            this.btnRemoveSheet.Size = new System.Drawing.Size(123, 23);
            this.btnRemoveSheet.TabIndex = 11;
            this.btnRemoveSheet.Text = "Remove Sheet";
            this.btnRemoveSheet.UseVisualStyleBackColor = true;
            this.btnRemoveSheet.Click += new System.EventHandler(this.btnRemoveSheet_Click);
            // 
            // btnAddSheet
            // 
            this.btnAddSheet.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnAddSheet.Location = new System.Drawing.Point(181, 144);
            this.btnAddSheet.Name = "btnAddSheet";
            this.btnAddSheet.Size = new System.Drawing.Size(123, 23);
            this.btnAddSheet.TabIndex = 9;
            this.btnAddSheet.Text = "Add Sheet";
            this.btnAddSheet.UseVisualStyleBackColor = true;
            this.btnAddSheet.Click += new System.EventHandler(this.btnAddSheet_Click);
            // 
            // cbViewTypes
            // 
            this.cbViewTypes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbViewTypes.FormattingEnabled = true;
            this.cbViewTypes.Items.AddRange(new object[] {
            "Floor Plans",
            "Ceiling Plans",
            "Drafting Views",
            "Legends",
            "Sections",
            "Elevations"});
            this.cbViewTypes.Location = new System.Drawing.Point(9, 427);
            this.cbViewTypes.Name = "cbViewTypes";
            this.cbViewTypes.Size = new System.Drawing.Size(166, 21);
            this.cbViewTypes.TabIndex = 8;
            this.cbViewTypes.SelectedIndexChanged += new System.EventHandler(this.cbViews_SelectedIndexChanged);
            // 
            // MainForm
            // 
            this.AcceptButton = this.btnCreate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(684, 537);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnCreate);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Create Revit Sheets";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.ComboBox cbTitleblocks;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnBrowse;
        public System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label lblSheetList;
        private System.Windows.Forms.Label lblTitleblocks;
        private System.Windows.Forms.Button btnLoad;
        private System.Windows.Forms.Label lblViews;
        private System.Windows.Forms.Label lblSheets;
        private System.Windows.Forms.Label lblViewsToAdd;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnRemove;
        public System.Windows.Forms.ListBox lstAvailableViews;
        public System.Windows.Forms.ListBox lstSheetsToCreate;
        public System.Windows.Forms.ListBox lstViewsToAdd;
        private System.Windows.Forms.Button btnMoveViewUp;
        private System.Windows.Forms.Button btnMoveViewDown;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbViewTypes;
        private System.Windows.Forms.Button btnRemoveSheet;
        private System.Windows.Forms.Button btnAddSheet;
        public System.Windows.Forms.Button btnEditSheet;
        private System.Windows.Forms.Button btnMoveSheetDown;
        private System.Windows.Forms.Button btnMoveSheetUp;
    }
}