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

		/// <summary>Turns fields on/off or in/visible depending on the EnterEditFormMode state</summary>
		protected virtual void ToggleFieldsForEnterEditFormMode()
		{
			switch (enterEditFormMode)
			{
				case EnterEditRecordFormMode.View:
					this.Text = GetTitleForViewMode();
					//btnSave.Visible = false;
					break;

				case EnterEditRecordFormMode.Edit:
					this.Text = GetTitleForViewMode();
					txtRecordId.ReadOnly = true;
					break;

				case EnterEditRecordFormMode.Create:
					this.Text = GetTitleForCreationMode();
					txtRecordId.Text = "N/A"; // Record doesn't have a ID yet
					break;
			}
		}

		/// <summary>The usage mode which the form is currently in</summary>
		[Browsable(false)]
		[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
		public EnterEditRecordFormMode EnterEditFormMode {
			get { return enterEditFormMode; }
			set {
				if (value == enterEditFormMode)
					return;

				enterEditFormMode = value;

				ToggleFieldsForEnterEditFormMode();
			}
		}

		/// <summary>Get the ID of the record (Employee, Order, etc) which this form is ultimately editing</summary>
		/// <returns></returns>
		protected virtual int GetRecordIdValue()
		{
			return -1;
		}
		/// <summary>Get the form title string for when a user is viewing or editing an existing record</summary>
		/// <returns></returns>
		protected virtual string GetTitleForViewMode()
		{
			return string.Format("{0}: ID {1}", recordKindName, GetRecordIdValue());
		}
		/// <summary>Get the form title string for when a user is creating a new record</summary>
		/// <returns></returns>
		protected virtual string GetTitleForCreationMode()
		{
			return string.Format("New {0}", recordKindName);
		}

		/// <summary>
		/// Formats a message that will be shown to the user via a MessageBox which only has an OK button
		/// </summary>
		/// <param name="format"></param>
		/// <param name="args"></param>
		protected void ShowValidationErrorMessage(string format, params object[] args)
		{
			string message = string.Format(format, args);

			MessageBox.Show(this, message, "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		/// <summary>Performs the validation required prior to trying to save a record</summary>
		/// <returns>True if all fields are valid, false if not</returns>
		protected virtual bool PreSaveValidation()
		{
			return true;
		}
		/// <summary>Invokes the business layer to save the underlying record data</summary>
		/// <returns>The record's ID, or -1 if saving failed</returns>
		protected virtual int SaveEnterEditData()
		{
			return -1;
		}
		private void OnSaveClick(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.Assert(enterEditFormMode != EnterEditRecordFormMode.View,
				"Save functionality shouldn't be usable in View modes");

			bool isValid = false;
			int saveDataId = -1;

			isValid = PreSaveValidation();
			if (isValid)
				saveDataId = SaveEnterEditData();

			// if validation or saving fails prevent the form from closing
			if (!isValid || saveDataId == -1)
				this.DialogResult = DialogResult.None;
		}

		private void OnCloseClick(object sender, EventArgs e)
		{
		}
	};
}