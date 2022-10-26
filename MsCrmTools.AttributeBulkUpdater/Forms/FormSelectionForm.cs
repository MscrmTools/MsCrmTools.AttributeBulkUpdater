using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace MsCrmTools.AttributeBulkUpdater.Forms
{
    /// <summary>
    /// Updates the changed attributes
    /// </summary>
    public partial class FormSelectionForm : Form
    {
        /// <summary>
        /// Initializes a new instance of class FormSelectionForm
        /// </summary>
        public FormSelectionForm(List<string> forms)
        {
            InitializeComponent();

            lvForms.Items.AddRange(forms.Select(f => new ListViewItem(f)).ToArray());
        }

        public List<string> SelectedForms => chkAllForms.Checked ? lvForms.Items.Cast<ListViewItem>().Select(f => f.Text).ToList() : lvForms.CheckedItems.Cast<ListViewItem>().Select(f => f.Text).ToList();

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}