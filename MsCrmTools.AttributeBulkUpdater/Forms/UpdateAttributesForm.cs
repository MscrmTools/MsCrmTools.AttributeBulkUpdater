using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Messages;
using Microsoft.Xrm.Sdk.Metadata;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using XrmToolBox;

namespace MsCrmTools.AttributeBulkUpdater.Forms
{
    /// <summary>
    /// Updates the changed attributes
    /// </summary>
    public partial class UpdateAttributesForm : Form
    {
        #region Variables

        /// <summary>
        /// Crm Organization service
        /// </summary>
        private readonly IOrganizationService innerService;

        /// <summary>
        /// Background worker for attributes update
        /// </summary>
        private BackgroundWorker bwUpdateAttributes;

        /// <summary>
        /// Item update result
        /// </summary>
        private enum Result
        {
            Success,
            Warning,
            Error
        }

        #endregion Variables

        #region Constructor

        /// <summary>
        /// Initializes a new instance of class UpdateAttributesForm
        /// </summary>
        /// <param name="service">Crm Organization service</param>
        /// <param name="us">Settings for update operation</param>
        public UpdateAttributesForm(IOrganizationService service, UpdateSettings us)
        {
            InitializeComponent();

            innerService = service;
            FillImagesInListView();

            UpdateAttributes(us);
        }

        #endregion Constructor

        #region Handlers

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bwUpdateAttributes_DoWork(object sender, DoWorkEventArgs e)
        {
            var bw = (BackgroundWorker)sender;
            var arg = (Tuple<List<ListViewItem>, UpdateSettings>)e.Argument;
            var itemsToManage = arg.Item1;
            var us = arg.Item2;
            int attributesProcessed = 0;

            // We process the items
            foreach (ListViewItem item in itemsToManage)
            {
                var amd = (AttributeMetadata)item.Tag;

                try
                {
                    attributesProcessed++;

                    if (amd.IsCustomizable.Value || amd.IsManaged.HasValue && amd.IsManaged.Value == false)
                    {
                        if (us.UpdateValidForAdvancedFind)
                        {
                            amd.IsValidForAdvancedFind.Value = item.Checked;
                        }

                        if (us.UpdateAuditIsEnabled)
                        {
                            amd.IsAuditEnabled.Value = item.Checked;
                        }

                        if (us.UpdateRequirementLevel && us.RequirementLevelValue.HasValue)
                        {
                            amd.RequiredLevel = new AttributeRequiredLevelManagedProperty(us.RequirementLevelValue.Value);
                        }

                        if (us.UpdateIsSecured)
                        {
                            amd.IsSecured = item.Checked;
                        }

                        innerService.Execute(new UpdateAttributeRequest
                        {
                            Attribute = amd,
                            EntityName = amd.EntityLogicalName
                        });

                        AddItemToInformationList(bw, Convert.ToInt32(attributesProcessed * 100 / itemsToManage.Count), amd.DisplayName.UserLocalizedLabel.Label, null, Result.Success);
                    }
                    else
                    {
                        AddItemToInformationList(bw, Convert.ToInt32(attributesProcessed * 100 / itemsToManage.Count), amd.DisplayName.UserLocalizedLabel.Label, "Column not customizable!",
                            Result.Warning);
                    }
                }
                catch (Exception error)
                {
                    string errorMessage = CrmExceptionHelper.GetErrorMessage(error, false);
                    AddItemToInformationList(bw, Convert.ToInt32(attributesProcessed * 100 / itemsToManage.Count), amd.DisplayName.UserLocalizedLabel.Label, errorMessage, Result.Error);
                }
            }
        }

        private void bwUpdateAttributes_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pbUpdate.Value = e.ProgressPercentage;
            lvInformation.Items.Add((ListViewItem)e.UserState);
        }

        private void bwUpdateAttributes_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnClose.Enabled = true;
        }

        #endregion Handlers

        #region Methods

        /// <summary>
        /// Launch process to update attributes
        /// </summary>
        /// <param name="us">Settings for update operation</param>
        public void UpdateAttributes(UpdateSettings us)
        {
            // We need to process only items that have their IsValidForAdvancedFind
            // property updated
            var itemsToManage = (from item in us.Items
                                 let amd = (AttributeMetadata)item.Tag
                                 where
                                     amd.IsValidForAdvancedFind.Value != item.Checked && us.UpdateValidForAdvancedFind ||
                                     amd.IsAuditEnabled.Value != item.Checked && us.UpdateAuditIsEnabled ||
                                     amd.IsSecured.HasValue && amd.IsSecured.Value != item.Checked && us.UpdateIsSecured ||
                                     (item.Checked && amd.RequiredLevel.Value != AttributeRequiredLevel.SystemRequired && amd.RequiredLevel.Value != us.RequirementLevelValue && us.UpdateRequirementLevel)
                                 select item).ToList();

            if (itemsToManage.Count == 0)
            {
                MessageBox.Show(this, "No column need to be updated!", "Information", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                Close();
                return;
            }

            bwUpdateAttributes = new BackgroundWorker();
            bwUpdateAttributes.RunWorkerCompleted += bwUpdateAttributes_RunWorkerCompleted;
            bwUpdateAttributes.ProgressChanged += bwUpdateAttributes_ProgressChanged;
            bwUpdateAttributes.DoWork += bwUpdateAttributes_DoWork;
            bwUpdateAttributes.WorkerReportsProgress = true;
            bwUpdateAttributes.WorkerSupportsCancellation = true;
            bwUpdateAttributes.RunWorkerAsync(new Tuple<List<ListViewItem>, UpdateSettings>(itemsToManage, us));
        }

        /// <summary>
        /// Adds an information in the listbox
        /// </summary>
        /// <param name="percentage"></param>
        /// <param name="attributeName">Attribute display name</param>
        /// <param name="message">Message to display</param>
        /// <param name="result">Result of the update for this attribute</param>
        /// <param name="worker"></param>
        private void AddItemToInformationList(BackgroundWorker worker, int percentage, string attributeName, string message, Result result)
        {
            ListViewItem item = new ListViewItem();
            item.Text = attributeName;
            item.SubItems.Add(message);

            switch (result)
            {
                case Result.Success:
                    {
                        item.ImageIndex = 0;
                    }
                    break;

                case Result.Warning:
                    {
                        item.ImageIndex = 1;
                    }
                    break;

                case Result.Error:
                    {
                        item.ImageIndex = 2;
                    }
                    break;
            }

            worker.ReportProgress(percentage, item);
        }

        /// <summary>
        /// Attaches result images to lisbox
        /// </summary>
        private void FillImagesInListView()
        {
            lvInformation.SmallImageList = new ImageList();
            System.Reflection.Assembly myAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            using (Stream myStream = myAssembly.GetManifestResourceStream("MsCrmTools.AttributeBulkUpdater.Images.solidgreentick.gif"))
            {
                if (myStream == null) return;
                var successImage = new Bitmap(myStream);
                lvInformation.SmallImageList.Images.Add(successImage);
            }

            using (Stream myStream = myAssembly.GetManifestResourceStream("MsCrmTools.AttributeBulkUpdater.Images.notif_icn_warn16.png"))
            {
                if (myStream == null) return;
                var warningImage = new Bitmap(myStream);
                lvInformation.SmallImageList.Images.Add(warningImage);
            }
            using (Stream myStream = myAssembly.GetManifestResourceStream("MsCrmTools.AttributeBulkUpdater.Images.notif_icn_crit16.png"))
            {
                if (myStream == null) return;
                var errorImage = new Bitmap(myStream);
                lvInformation.SmallImageList.Images.Add(errorImage);
            }
        }

        #endregion Methods
    }
}