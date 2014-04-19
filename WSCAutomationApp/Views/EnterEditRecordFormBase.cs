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

		Binding txtRecordIdBinding;

		public EnterEditRecordFormBase()
		{
			InitializeComponent();

			EnterEditFormMode = EnterEditRecordFormMode.None;
		}

		void SetAllEditableControlsToReadOnly()
		{
			foreach (Control control in base.Controls)
			{
				if (control is TextBox)
					(control as TextBox).ReadOnly = true;
				else if (control is NumericUpDown)
					(control as NumericUpDown).ReadOnly = true;
				else if (control is ComboBox)
					(control as ComboBox).Enabled = false; // ComboBox doesn't have a ReadOnly property
				else if (control is DateTimePicker)
					(control as DateTimePicker).Enabled = false; // DateTimePicker doesn't have a ReadOnly property
			}
		}

		/// <summary>Turns fields on/off or in/visible depending on the EnterEditFormMode state</summary>
		protected virtual void ToggleFieldsForEnterEditFormMode()
		{
			switch (enterEditFormMode)
			{
				case EnterEditRecordFormMode.None:
					throw new InvalidOperationException();

				case EnterEditRecordFormMode.View:
					this.Text = GetTitleForViewMode();
					SetAllEditableControlsToReadOnly();
					btnSave.Visible = false;
					break;

				case EnterEditRecordFormMode.Edit:
					this.Text = GetTitleForViewMode();
					break;

				case EnterEditRecordFormMode.Create:
					this.Text = GetTitleForCreationMode();
					txtRecordId.Text = "-1"; // Record doesn't have a ID yet
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

		protected void SetRecordIdDataBinding(object dataSource, string dataMember = "Id")
		{
			txtRecordIdBinding = txtRecordId.DataBindings.Add("Text", dataSource, dataMember);
		}

		public virtual void SetEnterEditData(object enterEditData)
		{
			throw new NotImplementedException("Child forms should implement this");
		}

		/// <summary>Get the ID of the record (Employee, Order, etc) which this form is ultimately editing</summary>
		/// <returns></returns>
		public virtual int GetRecordIdValue()
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
		/// <summary>Invokes the business layer to add the underlying record data to the DB</summary>
		/// <returns>The record's ID, or -1 if saving failed</returns>
		protected virtual int AddEnterEditData()
		{
			return -1;
		}
		/// <summary>Invokes the business layer to save the underlying record data to the DB</summary>
		/// <returns>True if saving succeeded, false if it failed</returns>
		protected virtual bool SaveEnterEditData()
		{
			return false;
		}
		private void OnSaveClick(object sender, EventArgs e)
		{
			System.Diagnostics.Debug.Assert(enterEditFormMode != EnterEditRecordFormMode.View,
				"Save functionality shouldn't be usable in View modes");

			bool isValid = false;

			isValid = PreSaveValidation();
			bool saveSucessful = false;
			if (isValid)
			{
				switch (EnterEditFormMode)
				{
					#region Save for 'Add New'
					case EnterEditRecordFormMode.Create:
						int saveDataId = AddEnterEditData();
						saveSucessful = saveDataId != -1;

						if (!saveSucessful)
						{
							MessageBox.Show(this,
								"TODO",
								"Failed to add a new " + recordKindName,
								MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						else
						{
							// cause the RecordId TextBox to refresh its binding to the business object's Id property
							txtRecordIdBinding.ReadValue();

							MessageBox.Show(this,
								string.Format("New {0} ID: {1}", recordKindName, saveDataId),
								"Add successful!",
								MessageBoxButtons.OK);

							// we're now editing an existing record
							EnterEditFormMode = EnterEditRecordFormMode.Edit;
						}
						break;
					#endregion

					#region Save existing record
					case EnterEditRecordFormMode.Edit:
						saveSucessful = SaveEnterEditData();

						if (!saveSucessful)
						{
							MessageBox.Show(this,
								"TODO",
								"Failed to save record",
								MessageBoxButtons.OK, MessageBoxIcon.Error);
						}
						else
						{
							MessageBox.Show(this,
								string.Format("Successfully saved {0} #{1}", recordKindName, GetRecordIdValue()),
								"Save successful!",
								MessageBoxButtons.OK);
						}
						break;
					#endregion

					default:
						throw new InvalidOperationException("No other form mode should try to save data...");
				}
			}

			// if validation or saving fails prevent the form from closing
			if (!isValid || !saveSucessful)
				this.DialogResult = DialogResult.None;
		}

		private void OnCloseClick(object sender, EventArgs e)
		{
			this.Close();
		}
	};
}