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
			var userId = txtParameterUserName.Text;

			var emp = Program.CurrentUser.EmployeeData;
			foreach (var e in emp.GetEmployees(empId, txtParameterUserName.Text))
				searchResultsBindingSource.Add(e);
		}
	};
}