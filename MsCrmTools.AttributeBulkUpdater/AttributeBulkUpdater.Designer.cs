namespace MsCrmTools.AttributeBulkUpdater
{
    partial class AttributeBulkUpdater
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AttributeBulkUpdater));
            this.gbPropertySelection = new System.Windows.Forms.GroupBox();
            this.cboRequirementLevel = new System.Windows.Forms.ComboBox();
            this.chkRequirementLevel = new System.Windows.Forms.CheckBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.chkValidForAudit = new System.Windows.Forms.CheckBox();
            this.chkValidForAdvancedFind = new System.Windows.Forms.CheckBox();
            this.tsMain = new System.Windows.Forms.ToolStrip();
            this.tsbCloseThisTab = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbLoadEntities = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSaveAttributes = new System.Windows.Forms.ToolStripButton();
            this.tsbPublishEntity = new System.Windows.Forms.ToolStripButton();
            this.gbEntities = new System.Windows.Forms.GroupBox();
            this.lvEntities = new System.Windows.Forms.ListView();
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.gbAttributes = new System.Windows.Forms.GroupBox();
            this.btnCheckAttrOnForms = new System.Windows.Forms.Button();
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnResetAttributes = new System.Windows.Forms.Button();
            this.lvAttributes = new System.Windows.Forms.ListView();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.chkIsSecured = new System.Windows.Forms.CheckBox();
            this.gbPropertySelection.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tsMain.SuspendLayout();
            this.gbEntities.SuspendLayout();
            this.gbAttributes.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbPropertySelection
            // 
            this.gbPropertySelection.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbPropertySelection.Controls.Add(this.chkIsSecured);
            this.gbPropertySelection.Controls.Add(this.cboRequirementLevel);
            this.gbPropertySelection.Controls.Add(this.chkRequirementLevel);
            this.gbPropertySelection.Controls.Add(this.panel2);
            this.gbPropertySelection.Controls.Add(this.chkValidForAudit);
            this.gbPropertySelection.Controls.Add(this.chkValidForAdvancedFind);
            this.gbPropertySelection.Enabled = false;
            this.gbPropertySelection.Location = new System.Drawing.Point(498, 43);
            this.gbPropertySelection.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbPropertySelection.Name = "gbPropertySelection";
            this.gbPropertySelection.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbPropertySelection.Size = new System.Drawing.Size(868, 108);
            this.gbPropertySelection.TabIndex = 90;
            this.gbPropertySelection.TabStop = false;
            this.gbPropertySelection.Text = "Attribute Property Selection";
            // 
            // cboRequirementLevel
            // 
            this.cboRequirementLevel.Enabled = false;
            this.cboRequirementLevel.FormattingEnabled = true;
            this.cboRequirementLevel.Items.AddRange(new object[] {
            "Business Required",
            "Business Recommended",
            "No Constraint"});
            this.cboRequirementLevel.Location = new System.Drawing.Point(671, 68);
            this.cboRequirementLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cboRequirementLevel.Name = "cboRequirementLevel";
            this.cboRequirementLevel.Size = new System.Drawing.Size(180, 28);
            this.cboRequirementLevel.TabIndex = 10;
            // 
            // chkRequirementLevel
            // 
            this.chkRequirementLevel.AutoSize = true;
            this.chkRequirementLevel.Location = new System.Drawing.Point(495, 72);
            this.chkRequirementLevel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkRequirementLevel.Name = "chkRequirementLevel";
            this.chkRequirementLevel.Size = new System.Drawing.Size(168, 24);
            this.chkRequirementLevel.TabIndex = 9;
            this.chkRequirementLevel.Text = "Requirement Level";
            this.chkRequirementLevel.UseVisualStyleBackColor = true;
            this.chkRequirementLevel.CheckedChanged += new System.EventHandler(this.chkRequirementLevel_CheckedChanged);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.LightYellow;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Location = new System.Drawing.Point(9, 29);
            this.panel2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(846, 33);
            this.panel2.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 5);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(372, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select which attribute properties should be updated";
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(4, 3);
            this.pictureBox2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 25);
            this.pictureBox2.TabIndex = 0;
            this.pictureBox2.TabStop = false;
            // 
            // chkValidForAudit
            // 
            this.chkValidForAudit.AutoSize = true;
            this.chkValidForAudit.Location = new System.Drawing.Point(186, 72);
            this.chkValidForAudit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkValidForAudit.Name = "chkValidForAudit";
            this.chkValidForAudit.Size = new System.Drawing.Size(134, 24);
            this.chkValidForAudit.TabIndex = 1;
            this.chkValidForAudit.Text = "Valid for Audit";
            this.chkValidForAudit.UseVisualStyleBackColor = true;
            this.chkValidForAudit.CheckedChanged += new System.EventHandler(this.chkValidForAudit_CheckedChanged);
            // 
            // chkValidForAdvancedFind
            // 
            this.chkValidForAdvancedFind.AutoSize = true;
            this.chkValidForAdvancedFind.Location = new System.Drawing.Point(15, 72);
            this.chkValidForAdvancedFind.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkValidForAdvancedFind.Name = "chkValidForAdvancedFind";
            this.chkValidForAdvancedFind.Size = new System.Drawing.Size(163, 24);
            this.chkValidForAdvancedFind.TabIndex = 0;
            this.chkValidForAdvancedFind.Text = "Valid for Adv. Find";
            this.chkValidForAdvancedFind.UseVisualStyleBackColor = true;
            this.chkValidForAdvancedFind.CheckedChanged += new System.EventHandler(this.chkValidForAdvancedFind_CheckedChanged);
            // 
            // tsMain
            // 
            this.tsMain.AutoSize = false;
            this.tsMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbCloseThisTab,
            this.toolStripSeparator3,
            this.tsbLoadEntities,
            this.toolStripSeparator1,
            this.tsbSaveAttributes,
            this.tsbPublishEntity});
            this.tsMain.Location = new System.Drawing.Point(0, 0);
            this.tsMain.Name = "tsMain";
            this.tsMain.Padding = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.tsMain.Size = new System.Drawing.Size(1366, 38);
            this.tsMain.TabIndex = 89;
            this.tsMain.Text = "toolStrip1";
            // 
            // tsbCloseThisTab
            // 
            this.tsbCloseThisTab.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCloseThisTab.Image = ((System.Drawing.Image)(resources.GetObject("tsbCloseThisTab.Image")));
            this.tsbCloseThisTab.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCloseThisTab.Name = "tsbCloseThisTab";
            this.tsbCloseThisTab.Size = new System.Drawing.Size(28, 35);
            this.tsbCloseThisTab.Text = "Close this tab";
            this.tsbCloseThisTab.Click += new System.EventHandler(this.TsbCloseThisTabClick);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 38);
            // 
            // tsbLoadEntities
            // 
            this.tsbLoadEntities.Image = ((System.Drawing.Image)(resources.GetObject("tsbLoadEntities.Image")));
            this.tsbLoadEntities.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbLoadEntities.Name = "tsbLoadEntities";
            this.tsbLoadEntities.Size = new System.Drawing.Size(140, 35);
            this.tsbLoadEntities.Text = "Load Entities";
            this.tsbLoadEntities.Click += new System.EventHandler(this.tsbLoadEntities_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 38);
            // 
            // tsbSaveAttributes
            // 
            this.tsbSaveAttributes.Enabled = false;
            this.tsbSaveAttributes.Image = ((System.Drawing.Image)(resources.GetObject("tsbSaveAttributes.Image")));
            this.tsbSaveAttributes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSaveAttributes.Name = "tsbSaveAttributes";
            this.tsbSaveAttributes.Size = new System.Drawing.Size(160, 35);
            this.tsbSaveAttributes.Text = "Save Attributes";
            this.tsbSaveAttributes.Click += new System.EventHandler(this.tsbSaveAttributes_Click);
            // 
            // tsbPublishEntity
            // 
            this.tsbPublishEntity.Enabled = false;
            this.tsbPublishEntity.Image = ((System.Drawing.Image)(resources.GetObject("tsbPublishEntity.Image")));
            this.tsbPublishEntity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbPublishEntity.Name = "tsbPublishEntity";
            this.tsbPublishEntity.Size = new System.Drawing.Size(146, 35);
            this.tsbPublishEntity.Text = "Publish entity";
            this.tsbPublishEntity.Click += new System.EventHandler(this.tsbPublishEntity_Click);
            // 
            // gbEntities
            // 
            this.gbEntities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbEntities.Controls.Add(this.lvEntities);
            this.gbEntities.Enabled = false;
            this.gbEntities.Location = new System.Drawing.Point(4, 43);
            this.gbEntities.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbEntities.Name = "gbEntities";
            this.gbEntities.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbEntities.Size = new System.Drawing.Size(489, 875);
            this.gbEntities.TabIndex = 88;
            this.gbEntities.TabStop = false;
            this.gbEntities.Text = "Entities";
            // 
            // lvEntities
            // 
            this.lvEntities.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lvEntities.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader4,
            this.columnHeader7});
            this.lvEntities.FullRowSelect = true;
            this.lvEntities.HideSelection = false;
            this.lvEntities.Location = new System.Drawing.Point(9, 31);
            this.lvEntities.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvEntities.Name = "lvEntities";
            this.lvEntities.Size = new System.Drawing.Size(469, 833);
            this.lvEntities.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvEntities.TabIndex = 79;
            this.lvEntities.UseCompatibleStateImageBehavior = false;
            this.lvEntities.View = System.Windows.Forms.View.Details;
            this.lvEntities.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvEntities_ColumnClick);
            this.lvEntities.SelectedIndexChanged += new System.EventHandler(this.lvEntities_SelectedIndexChanged);
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Display name";
            this.columnHeader4.Width = 156;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "Schema name";
            this.columnHeader7.Width = 130;
            // 
            // gbAttributes
            // 
            this.gbAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAttributes.Controls.Add(this.btnCheckAttrOnForms);
            this.gbAttributes.Controls.Add(this.btnCheck);
            this.gbAttributes.Controls.Add(this.btnResetAttributes);
            this.gbAttributes.Controls.Add(this.lvAttributes);
            this.gbAttributes.Enabled = false;
            this.gbAttributes.Location = new System.Drawing.Point(502, 160);
            this.gbAttributes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbAttributes.Name = "gbAttributes";
            this.gbAttributes.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gbAttributes.Size = new System.Drawing.Size(860, 758);
            this.gbAttributes.TabIndex = 87;
            this.gbAttributes.TabStop = false;
            this.gbAttributes.Text = "Attributes";
            // 
            // btnCheckAttrOnForms
            // 
            this.btnCheckAttrOnForms.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheckAttrOnForms.Enabled = false;
            this.btnCheckAttrOnForms.Location = new System.Drawing.Point(420, 20);
            this.btnCheckAttrOnForms.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheckAttrOnForms.Name = "btnCheckAttrOnForms";
            this.btnCheckAttrOnForms.Size = new System.Drawing.Size(188, 35);
            this.btnCheckAttrOnForms.TabIndex = 7;
            this.btnCheckAttrOnForms.Text = "Check Attr. on Forms";
            this.btnCheckAttrOnForms.UseVisualStyleBackColor = true;
            this.btnCheckAttrOnForms.Click += new System.EventHandler(this.btnCheckAttrOnForms_Click);
            // 
            // btnCheck
            // 
            this.btnCheck.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCheck.Enabled = false;
            this.btnCheck.Location = new System.Drawing.Point(614, 20);
            this.btnCheck.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(112, 35);
            this.btnCheck.TabIndex = 6;
            this.btnCheck.Text = "Check All";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnResetAttributes
            // 
            this.btnResetAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnResetAttributes.Enabled = false;
            this.btnResetAttributes.Location = new System.Drawing.Point(735, 20);
            this.btnResetAttributes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnResetAttributes.Name = "btnResetAttributes";
            this.btnResetAttributes.Size = new System.Drawing.Size(112, 35);
            this.btnResetAttributes.TabIndex = 5;
            this.btnResetAttributes.Text = "Reset";
            this.btnResetAttributes.UseVisualStyleBackColor = true;
            this.btnResetAttributes.Click += new System.EventHandler(this.btnResetAttributes_Click);
            // 
            // lvAttributes
            // 
            this.lvAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvAttributes.CheckBoxes = true;
            this.lvAttributes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader8});
            this.lvAttributes.Enabled = false;
            this.lvAttributes.FullRowSelect = true;
            this.lvAttributes.GridLines = true;
            this.lvAttributes.Location = new System.Drawing.Point(9, 65);
            this.lvAttributes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.lvAttributes.Name = "lvAttributes";
            this.lvAttributes.Size = new System.Drawing.Size(840, 682);
            this.lvAttributes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvAttributes.TabIndex = 2;
            this.lvAttributes.UseCompatibleStateImageBehavior = false;
            this.lvAttributes.View = System.Windows.Forms.View.Details;
            this.lvAttributes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAttributes_ColumnClick);
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Attribute Display Name";
            this.columnHeader2.Width = 160;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Attribute Logical Name";
            this.columnHeader1.Width = 150;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Can change";
            this.columnHeader3.Width = 75;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Is Customizable";
            this.columnHeader5.Width = 85;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "On Form";
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "RequirementLevel";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "Icon.png");
            // 
            // chkIsSecured
            // 
            this.chkIsSecured.AutoSize = true;
            this.chkIsSecured.Location = new System.Drawing.Point(328, 72);
            this.chkIsSecured.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkIsSecured.Name = "chkIsSecured";
            this.chkIsSecured.Size = new System.Drawing.Size(112, 24);
            this.chkIsSecured.TabIndex = 11;
            this.chkIsSecured.Text = "Is Secured";
            this.chkIsSecured.UseVisualStyleBackColor = true;
            this.chkIsSecured.CheckedChanged += new System.EventHandler(this.chkIsSecured_CheckedChanged);
            // 
            // AttributeBulkUpdater
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.gbPropertySelection);
            this.Controls.Add(this.tsMain);
            this.Controls.Add(this.gbEntities);
            this.Controls.Add(this.gbAttributes);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "AttributeBulkUpdater";
            this.Size = new System.Drawing.Size(1366, 923);
            this.gbPropertySelection.ResumeLayout(false);
            this.gbPropertySelection.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tsMain.ResumeLayout(false);
            this.tsMain.PerformLayout();
            this.gbEntities.ResumeLayout(false);
            this.gbAttributes.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbPropertySelection;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.CheckBox chkValidForAudit;
        private System.Windows.Forms.CheckBox chkValidForAdvancedFind;
        private System.Windows.Forms.ToolStrip tsMain;
        private System.Windows.Forms.ToolStripButton tsbLoadEntities;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbSaveAttributes;
        private System.Windows.Forms.ToolStripButton tsbPublishEntity;
        private System.Windows.Forms.GroupBox gbEntities;
        private System.Windows.Forms.ListView lvEntities;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.GroupBox gbAttributes;
        private System.Windows.Forms.Button btnCheckAttrOnForms;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnResetAttributes;
        private System.Windows.Forms.ListView lvAttributes;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ToolStripButton tsbCloseThisTab;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.CheckBox chkRequirementLevel;
        private System.Windows.Forms.ComboBox cboRequirementLevel;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.CheckBox chkIsSecured;
    }
}