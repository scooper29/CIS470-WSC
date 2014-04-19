using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	public partial class SearchRecordsDialogBase : Form
	{
		SearchRecordsDialogMode searchDialogMode;

		protected DataGridViewTextBoxColumn dgcRecordId;

		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SearchRecordsDialogResult SearchDialogResult { get; private set; }

		/// <summary>The selected row's backing business object (eg, Employee, Order, etc), or null if one isn't selected</summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public object SelectedRecord { get; private set; }

		public SearchRecordsDialogBase()
		{
			InitializeComponent();

			txtParameterId.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);

			SearchDialogMode = SearchRecordsDialogMode.Query;
			SearchDialogResult = SearchRecordsDialogResult.None;

			SelectedRecord = null;

			dgvSearchResults.AutoGenerateColumns = false;
			dgvSearchResults.AutoSize = false;
		}

		/// <summary>The record ID search parameter supplied by the user, or -1 if nothing was input</summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected int ParameterId { get {
			// txtParameterId is limited to numbers only, so we can safely call Convert.ToInt32
			var id = txtParameterId.Text != ""
				? Convert.ToInt32(txtParameterId.Text)
				: -1;

			return id;
		} }

		/// <summary>Can the current user select see "Edit" button?</summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		protected virtual bool CurrentUserCanEditRecords { get {
			return false;
		} }

		/// <summary>The usage mode which the dialog is currently in</summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public SearchRecordsDialogMode SearchDialogMode {
			get { return searchDialogMode; }
			set {
				if (value == searchDialogMode)
					return;

				switch(value)
				{
					case SearchRecordsDialogMode.Query:
						btnSelect.Text = "&View";
						btnEdit.Visible = CurrentUserCanEditRecords;
						break;

					case SearchRecordsDialogMode.Selection:
						btnSelect.Text = "Select";
						btnEdit.Visible = false;
						break;
				}

				searchDialogMode = value;
			}
		}

		/// <summary>
		/// Populates the dgvSearchResults's Columns with the fields we wish to present to the user
		/// </summary>
		protected virtual void CreateSearchResultsColumns()
		{
			// All record objects (Employee, Order, etc) should have their PK property named "Id"
			// else, this has to be manually changed in the child Search dialog
			dgcRecordId = new DataGridViewTextBoxColumn();
			dgcRecordId.DataPropertyName = "Id";
			dgcRecordId.Name = "ID";
			dgvSearchResults.Columns.Add(dgcRecordId);
		}

		/// <summary>Logic performed when the dialog needs search results from the business layer</summary>
		/// <param name="searchResultsBindingSource"></param>
		protected virtual void PerformSearch(BindingSource searchResultsBindingSource)
		{
			System.Diagnostics.Debug.WriteLine("{0} doesn't implement PerformSearch!",
				this.GetType().Name);
		}

		private void OnSearchClick(object sender, EventArgs e)
		{
			if (dgvSearchResults.DataSource == null)
			{
				dgvSearchResults.DataSource = new BindingSource();
				CreateSearchResultsColumns();
			}

			// clear any pre-existing search results
			var bindingSource = dgvSearchResults.DataSource as BindingSource;
			bindingSource.Clear();

			// The dialog is now in a valid state to receive search results
			// TODO: this should be ran on a separate thread, to not block the UI from refreshing while the search is done
			PerformSearch(bindingSource);
		}

		private void OnSearchResultsSelectionChanged(object sender, EventArgs e)
		{
			// SelectedRows isn't a list, can't query Count or index
			foreach (DataGridViewRow row in dgvSearchResults.SelectedRows)
			{
				SelectedRecord = row.DataBoundItem;

				// dgvSearchResults is setup to only allow one selection, the loop should only ever execute once...
				break;
			}

			// Enable or disable the view/select and edit buttons
			btnSelect.Enabled = btnEdit.Enabled =
				SelectedRecord != null;
		}

		private void OnSelectClick(object sender, EventArgs e)
		{
			switch (searchDialogMode)
			{
				case SearchRecordsDialogMode.Query:
					SearchDialogResult = SearchRecordsDialogResult.View;
					break;

				case SearchRecordsDialogMode.Selection:
					SearchDialogResult = SearchRecordsDialogResult.Select;
					break;
			}

			// will cause the dialog to close
			this.DialogResult = DialogResult.OK;
		}

		private void OnEditClick(object sender, EventArgs e)
		{
			SearchDialogResult = SearchRecordsDialogResult.Edit;

			// will cause the dialog to close
			this.DialogResult = DialogResult.OK;
		}
	};
}