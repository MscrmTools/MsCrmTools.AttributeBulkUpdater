using Microsoft.Xrm.Sdk.Metadata;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MsCrmTools.AttributeBulkUpdater
{
    public class UpdateSettings
    {
        public bool UpdateIsSecured { get; internal set; }
        internal List<ListViewItem> Items { get; set; }
        internal AttributeRequiredLevel? RequirementLevelValue { get; set; }
        internal bool UpdateAuditIsEnabled { get; set; }
        internal bool UpdateRequirementLevel { get; set; }
        internal bool UpdateValidForAdvancedFind { get; set; }
    }
}