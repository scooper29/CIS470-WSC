using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	public partial class EnterEditRecordFormBase : Form
	{
		EnterEditRecordFormMode enterEditFormMode;
		/// <summary>What kind of record this enter/edit form is for</summary>
		protected string recordKindName = "UNKNOWN";

		public EnterEditRecordFormBase()
		{
			InitializeComponent();

			EnterEditFormMode = EnterEditRecordFormMode.View;
		}

		/// <summary>The usage mode which the form is currently in</summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public EnterEditRecordFormMode EnterEditFormMode {
			get { return enterEditFormMode; }
			set {
				if (value == enterEditFormMode)
					return;

				switch(value)
				{
					case EnterEditRecordFormMode.View:
						this.Text = GetTitleForViewMode();
						//btnSave.Visible = false;
						break;

					case EnterEditRecordFormMode.Edit:
						this.Text = GetTitleForViewMode();
						break;

					case EnterEditRecordFormMode.Create:
						this.Text = GetTitleForCreationMode();
						txtRecordId.Text = "N/A"; // Record doesn't have a ID yet
						break;
				}

				enterEditFormMode = value;
			}
		}

		protected virtual string GetTitleForViewMode()
		{
			return string.Format("{0}: ID {1}", recordKindName, -1);
		}
		protected virtual string GetTitleForCreationMode()
		{
			return string.Format("New {0}", recordKindName);
		}

		private void OnSaveClick(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.Assert(enterEditFormMode != EnterEditRecordFormMode.View,
				"Save functionality shouldn't be usable in View modes");
		}

		private void OnCloseClick(object sender, EventArgs e)
		{
		}
	};
}