using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	public partial class SearchEmployeesDialog : WSCAutomation.App.SearchRecordsDialogBase
	{
		public SearchEmployeesDialog()
		{
			InitializeComponent();
		}

		protected override bool CurrentUserCanEditRecords { get {
			return Program.CurrentUser.Authority == UserAuthorityType.Admin;
		} }

		protected override void CreateSearchResultsColumns()
		{
			base.CreateSearchResultsColumns();

			var dgcUserName = new DataGridViewTextBoxColumn();
			dgcUserName.DataPropertyName = "UserName";
			dgcUserName.Name = "User Name";
			dgvSearchResults.Columns.Add(dgcUserName);
		}

		protected override void PerformSearch(BindingSource searchResultsBindingSource)
		{
			var empId = ParameterId;
			var userName = txtParameterUserName.Text;

			var emp = Program.CurrentUser.EmployeeData;
			foreach (var e in emp.GetEmployees(empId, userName))
				searchResultsBindingSource.Add(e);
		}

		protected override void OnEditClick(object sender, EventArgs e)
		{
			base.OnEditClick(sender, e);

			// validate we're not trying to edit the currently logged in user
			// if we are, prompt the user to be sure this is what they want to do
			// this should only really ever happen for admins...
			if (SearchDialogResult == SearchRecordsDialogResult.Edit && SelectedRecord != null)
			{
				var emp = SelectedRecord as Employees.Employee;

				string message = "You selected your employee record. Are you sure you want to edit it?";

				if (emp.UserName == Program.CurrentUser.EmployeeData.UserName)
				{
					if (MessageBox.Show(message, "Are you sure?", MessageBoxButtons.YesNo) != DialogResult.Yes)
						this.DialogResult = DialogResult.None; // stop the search dialog from closing
				}
			}
		}
	};
}