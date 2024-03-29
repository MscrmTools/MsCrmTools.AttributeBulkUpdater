using Microsoft.Crm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using MsCrmTools.AttributeBulkUpdater.Forms;
using MsCrmTools.AttributeBulkUpdater.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using XrmToolBox.Extensibility;
using XrmToolBox.Extensibility.Interfaces;
using CrmExceptionHelper = XrmToolBox.CrmExceptionHelper;

namespace MsCrmTools.AttributeBulkUpdater
{
    public partial class AttributeBulkUpdater : PluginControlBase, IGitHubPlugin, IHelpPlugin
    {
        #region Variables

        /// <summary>
        /// Original value for searchable property
        /// </summary>
        private Dictionary<string, AttributeMetadata> attributesOriginalState;

        /// <summary>
        /// Current Attributes list order column index
        /// </summary>
        private int currentAttributesColumnOrder;

        private int currentEntitiesColumnOrder;

        private ToolTip tt;

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of class AttributeBulkUpdater
        /// </summary>
        public AttributeBulkUpdater()
        {
            InitializeComponent();

            tt = new ToolTip();
            tt.SetToolTip(label2, "List below controls what value to apply to selected property. Checked columns will receive \"True\" value. Unchecked columns will receive \"False\" value. For requirement level, checked columns will be updated with selected value.");
        }

        #endregion Constructor

        #region Properties

        public string HelpUrl
        { get { return "https://github.com/MscrmTools/MsCrmTools.AttributeBulkUpdater/wiki"; } }

        public string RepositoryName
        { get { return "MsCrmTools.AttributeBulkUpdater"; } }

        public string UserName
        { get { return "MscrmTools"; } }

        #endregion Properties

        #region Methods

        private void btnCheck_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvAttributes.Items)
            {
                item.Checked = ((Button)sender).Text == @"Check All";
            }

            ((Button)sender).Text = ((Button)sender).Text == @"Check All" ? "Clear All" : "Check All";
        }

        private void btnCheckAttrOnForms_Click(object sender, EventArgs e)
        {
            var forms = lvAttributes.Items.Cast<ListViewItem>().SelectMany(i => i.SubItems[4].Text.Split(',')).Select(i => i.Trim()).Distinct().Where(i => !string.IsNullOrEmpty(i)).ToList();

            var dialog = new FormSelectionForm(forms);
            if (dialog.ShowDialog(this) == DialogResult.OK)
            {
                forms = dialog.SelectedForms;

                foreach (ListViewItem item in lvAttributes.Items)
                {
                    var parts = item.SubItems[4].Text.Split(',').Select(i => i.Trim()).Where(i => !string.IsNullOrEmpty(i)).ToList();

                    item.Checked = forms.Any(f => parts.Contains(f));
                }
            }
        }

        private void btnResetAttributes_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvAttributes.Items)
            {
                AttributeMetadata amd = attributesOriginalState[item.SubItems[1].Text];

                if (chkValidForAdvancedFind.Checked && chkValidForAudit.Checked && chkIsSecured.Checked)
                {
                    item.Checked = amd.IsValidForAdvancedFind.Value && amd.IsAuditEnabled.Value && amd.IsSecured.HasValue && amd.IsSecured.Value;
                }
                else if (chkValidForAdvancedFind.Checked && chkValidForAudit.Checked)
                {
                    item.Checked = amd.IsValidForAdvancedFind.Value && amd.IsAuditEnabled.Value;
                }
                else if (chkValidForAdvancedFind.Checked && chkIsSecured.Checked)
                {
                    item.Checked = amd.IsValidForAdvancedFind.Value && amd.IsSecured.HasValue && amd.IsSecured.Value;
                }
                else if (chkIsSecured.Checked && chkValidForAudit.Checked)
                {
                    item.Checked = amd.IsSecured.HasValue && amd.IsSecured.Value && amd.IsAuditEnabled.Value;
                }
                else if (chkValidForAdvancedFind.Checked)
                {
                    item.Checked = amd.IsValidForAdvancedFind.Value;
                }
                else if (chkValidForAudit.Checked)
                {
                    item.Checked = amd.IsAuditEnabled.Value;
                }
                else if (chkIsSecured.Checked)
                {
                    item.Checked = amd.IsSecured.HasValue && amd.IsSecured.Value;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        private void TsbCloseThisTabClick(object sender, EventArgs e)
        {
            CloseTool();
        }

        #region Fill Entities

        private void LoadEntities()
        {
            lvEntities.Items.Clear();
            lvAttributes.Items.Clear();
            btnCheck.Enabled = false;
            btnCheckAttrOnForms.Enabled = false;
            btnInvertSelection.Enabled = false;
            btnResetAttributes.Enabled = false;
            gbEntities.Enabled = false;
            tsbPublishEntity.Enabled = false;
            tsbSaveAttributes.Enabled = false;

            WorkAsync(new WorkAsyncInfo
            {
                Message = "Loading tables...",
                Work = (bw, e) => { e.Result = MetadataHelper.RetrieveEntities(Service); },
                PostWorkCallBack = e =>
                {
                    if (e.Error != null)
                    {
                        string errorMessage = CrmExceptionHelper.GetErrorMessage(e.Error, true);
                        MessageBox.Show(ParentForm, errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        var items = new List<ListViewItem>();
                        foreach (EntityMetadata emd in (List<EntityMetadata>)e.Result)
                        {
                            var item = new ListViewItem { Text = emd.DisplayName.UserLocalizedLabel.Label, Tag = emd };
                            item.SubItems.Add(emd.LogicalName);
                            items.Add(item);
                        }
                        lvEntities.Items.AddRange(items.ToArray());

                        gbEntities.Enabled = true;
                    }
                }
            });
        }

        private void tsbLoadEntities_Click(object sender, EventArgs e)
        {
            ExecuteMethod(LoadEntities);
        }

        #endregion Fill Entities

        #region Fill Attributes

        private void lvEntities_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEntities.SelectedItems.Count > 0)
            {
                lvAttributes.Items.Clear();

                var emd = (EntityMetadata)lvEntities.SelectedItems[0].Tag;

                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Loading columns...",
                    AsyncArgument = emd.LogicalName,
                    Work = (bw, evt) =>
                    {
                        attributesOriginalState = new Dictionary<string, AttributeMetadata>();
                        EntityMetadata metadata = MetadataHelper.RetrieveEntity(evt.Argument.ToString(), Service);
                        XmlDocument allFormsDoc = MetadataHelper.RetrieveEntityForms(metadata.LogicalName, Service, ConnectionDetail);
                        var items = new List<ListViewItem>();

                        foreach (AttributeMetadata amd in metadata.Attributes)
                        {
                            if (amd.AttributeType.HasValue
                                && amd.AttributeType.Value != AttributeTypeCode.Virtual
                                && string.IsNullOrEmpty(amd.AttributeOf))
                            {
                                bool searchable = amd.IsValidForAdvancedFind.Value;
                                bool isAuditEnabled = amd.IsAuditEnabled.Value;
                                bool isSecured = amd.IsSecured.HasValue && amd.IsSecured.Value;

                                string label = amd.DisplayName.UserLocalizedLabel != null ? amd.DisplayName.UserLocalizedLabel.Label : "N/A";

                                var xDoc = XDocument.Parse(allFormsDoc.OuterXml);

                                IEnumerable<XElement> nodes =
                                (from el in xDoc.Root.Descendants("control")
                                 where (string)el.Attribute("datafieldname") == amd.LogicalName
                                 select el);

                                var forms = string.Join(", ", nodes.Select(n => n.Ancestors("form").First().Attribute("name").Value).OrderBy(f => f));

                                var item = new ListViewItem(label);
                                item.SubItems.Add(amd.LogicalName);
                                item.SubItems.Add(amd.IsValidForAdvancedFind.CanBeChanged.ToString());
                                item.SubItems.Add((amd.IsCustomizable.Value || amd.IsManaged.HasValue && amd.IsManaged.Value == false).ToString());
                                item.SubItems.Add(forms);
                                item.SubItems.Add(amd.RequiredLevel.Value.ToString());

                                item.Tag = amd;
                                item.Checked = searchable && chkValidForAdvancedFind.Checked || isAuditEnabled && chkValidForAudit.Checked || isSecured && chkIsSecured.Checked;

                                if (!amd.IsValidForAdvancedFind.CanBeChanged || (!amd.IsCustomizable.Value && amd.IsManaged.HasValue && amd.IsManaged.Value))
                                {
                                    item.ForeColor = Color.Gray;
                                }

                                attributesOriginalState.Add(amd.LogicalName, amd);

                                items.Add(item);
                            }
                        }

                        evt.Result = items;
                    },
                    PostWorkCallBack = evt =>
                    {
                        if (evt.Error != null)
                        {
                            MessageBox.Show(this, evt.Error.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            lvAttributes.Items.AddRange(((List<ListViewItem>)evt.Result).ToArray());

                            lvAttributes.Enabled = true;
                            tsbSaveAttributes.Enabled = true;
                            tsbPublishEntity.Enabled = true;
                            btnResetAttributes.Enabled = true;
                            btnInvertSelection.Enabled = true;
                            btnCheck.Enabled = true;
                            btnCheckAttrOnForms.Enabled = true;
                            gbAttributes.Enabled = true;
                            gbPropertySelection.Enabled = true;
                        }
                    }
                });
            }
        }

        #endregion Fill Attributes

        #region Save Attributes

        private void tsbSaveAttributes_Click(object sender, EventArgs e)
        {
            if (!chkValidForAdvancedFind.Checked && !chkValidForAudit.Checked && !chkRequirementLevel.Checked && !chkIsSecured.Checked)
            {
                MessageBox.Show(this, @"It is required to select at least one property to update:\r\n- Valid for advanced find\r\n- Is audit enabled\r\n - Requirement levelr\n - Is secured",
                    @"Warning",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            var us = new UpdateSettings
            {
                Items = lvAttributes.Items.Cast<ListViewItem>().Select(i => (ListViewItem)i.Clone()).ToList(),
                UpdateValidForAdvancedFind = chkValidForAdvancedFind.Checked,
                UpdateAuditIsEnabled = chkValidForAudit.Checked,
                UpdateRequirementLevel = chkRequirementLevel.Checked,
                RequirementLevelValue = chkRequirementLevel.Checked ? MapSdkValue(cboRequirementLevel.SelectedIndex) : null,
                UpdateIsSecured = chkIsSecured.Checked
            };

            var uaForm = new Forms.UpdateAttributesForm(Service, us);
            uaForm.ShowDialog();

            // reloads the attributes
            lvEntities_SelectedIndexChanged(null, null);
        }

        #endregion Save Attributes

        #region Publish Entity

        private void tsbPublishEntity_Click(object sender, EventArgs e)
        {
            if (lvEntities.SelectedItems.Count > 0)
            {
                tsbPublishEntity.Enabled = false;
                tsbSaveAttributes.Enabled = false;
                tsbLoadEntities.Enabled = false;

                WorkAsync(new WorkAsyncInfo
                {
                    Message = "Publishing table...",
                    AsyncArgument = lvEntities.SelectedItems[0].Tag,
                    Work = (bw, evt) =>
                    {
                        var currentEmd = (EntityMetadata)evt.Argument;

                        var pubRequest = new PublishXmlRequest();
                        pubRequest.ParameterXml = string.Format(@"<importexportxml>
                                                           <entities>
                                                              <entity>{0}</entity>
                                                           </entities>
                                                           <nodes/><securityroles/><settings/><workflows/>
                                                        </importexportxml>", currentEmd.LogicalName);

                        Service.Execute(pubRequest);
                    },
                    PostWorkCallBack = evt =>
                    {
                        if (evt.Error != null)
                        {
                            string errorMessage = CrmExceptionHelper.GetErrorMessage(evt.Error, false);
                            MessageBox.Show(ParentForm, errorMessage, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                        tsbPublishEntity.Enabled = true;
                        tsbSaveAttributes.Enabled = true;
                        tsbLoadEntities.Enabled = true;
                    }
                });
            }
        }

        #endregion Publish Entity

        #endregion Methods

        #region Column Sorting Handlers

        private void lvAttributes_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == currentAttributesColumnOrder)
            {
                lvAttributes.Sorting = lvAttributes.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                lvAttributes.ListViewItemSorter = new ListViewItemComparer(e.Column, lvAttributes.Sorting);
            }
            else
            {
                currentAttributesColumnOrder = e.Column;
                lvAttributes.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }
        }

        private void lvEntities_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lvEntities.SelectedItems.Clear();
            lvAttributes.Items.Clear();
            gbAttributes.Enabled = false;
            gbPropertySelection.Enabled = false;
            tsbSaveAttributes.Enabled = false;
            tsbPublishEntity.Enabled = false;
            btnResetAttributes.Enabled = false;
            btnCheck.Enabled = false;
            btnCheckAttrOnForms.Enabled = false;

            if (e.Column == currentEntitiesColumnOrder)
            {
                lvEntities.Sorting = lvEntities.Sorting == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
                lvEntities.ListViewItemSorter = new ListViewItemComparer(e.Column, lvEntities.Sorting);
            }
            else
            {
                currentEntitiesColumnOrder = e.Column;
                lvEntities.ListViewItemSorter = new ListViewItemComparer(e.Column, SortOrder.Ascending);
            }
        }

        #endregion Column Sorting Handlers

        private void btnInvertSelection_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem item in lvAttributes.Items)
            {
                item.Checked = !item.Checked;
            }
        }

        private void CheckItems()
        {
            foreach (ListViewItem item in lvAttributes.Items)
            {
                var amd = (AttributeMetadata)item.Tag;

                if (chkValidForAdvancedFind.Checked && chkValidForAudit.Checked && chkIsSecured.Checked)
                {
                    item.Checked = amd.IsValidForAdvancedFind.Value && amd.IsAuditEnabled.Value && amd.IsSecured.HasValue && amd.IsSecured.Value;
                }
                else if (chkValidForAdvancedFind.Checked && chkValidForAudit.Checked)
                {
                    item.Checked = amd.IsValidForAdvancedFind.Value && amd.IsAuditEnabled.Value;
                }
                else if (chkValidForAdvancedFind.Checked && chkIsSecured.Checked)
                {
                    item.Checked = amd.IsValidForAdvancedFind.Value && amd.IsSecured.HasValue && amd.IsSecured.Value;
                }
                else if (chkIsSecured.Checked && chkValidForAudit.Checked)
                {
                    item.Checked = amd.IsSecured.HasValue && amd.IsSecured.Value && amd.IsAuditEnabled.Value;
                }
                else if (chkValidForAdvancedFind.Checked)
                {
                    item.Checked = amd.IsValidForAdvancedFind.Value;
                }
                else if (chkValidForAudit.Checked)
                {
                    item.Checked = amd.IsAuditEnabled.Value;
                }
                else if (chkIsSecured.Checked)
                {
                    item.Checked = amd.IsSecured.HasValue && amd.IsSecured.Value;
                }
                else
                {
                    item.Checked = false;
                }
            }
        }

        private void chkIsSecured_CheckedChanged(object sender, EventArgs e)
        {
            CheckItems();
        }

        private void chkRequirementLevel_CheckedChanged(object sender, EventArgs e)
        {
            cboRequirementLevel.Enabled = chkRequirementLevel.Checked;
        }

        private void chkValidForAdvancedFind_CheckedChanged(object sender, EventArgs e)
        {
            CheckItems();
        }

        private void chkValidForAudit_CheckedChanged(object sender, EventArgs e)
        {
            CheckItems();
        }

        private AttributeRequiredLevel? MapSdkValue(int selectedValue)
        {
            switch (selectedValue)
            {
                case 0: return AttributeRequiredLevel.ApplicationRequired;
                case 1: return AttributeRequiredLevel.Recommended;
                case 2: return AttributeRequiredLevel.None;
                default: return null;
            }
        }
    }
}