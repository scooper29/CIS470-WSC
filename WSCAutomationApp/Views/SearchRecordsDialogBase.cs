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

		public SearchRecordsDialogBase()
		{
			InitializeComponent();

			SearchDialogMode = SearchRecordsDialogMode.Query;
		}

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
						btnEdit.Visible = true;
						break;

					case SearchRecordsDialogMode.Selection:
						btnSelect.Text = "Select";
						btnEdit.Visible = false;
						break;
				}

				searchDialogMode = value;
			}
		}

		private void OnSearchClick(object sender, EventArgs e)
		{
		}

		private void OnSelectClick(object sender, EventArgs e)
		{
		}

		private void OnEditClick(object sender, EventArgs e)
		{
		}
	};
}