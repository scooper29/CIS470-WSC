using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	public partial class SearchOrdersDialog : WSCAutomation.App.SearchRecordsDialogBase
	{
		public SearchOrdersDialog()
		{
			InitializeComponent();

			txtParameterCustomerId.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);
			txtParameterSpecialistId.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);
		}

		protected override bool CurrentUserCanEditRecords { get {
			var authority = Program.CurrentUser.Authority;

			return authority == UserAuthorityType.Sales ||
				authority == UserAuthorityType.Manager ||
				authority == UserAuthorityType.Specialist;
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
			var orderId = ParameterId;
			var customerId = txtParameterCustomerId.Text != ""
				? Convert.ToInt32(txtParameterCustomerId.Text)
				: -1;
			var specialistId = txtParameterSpecialistId.Text != ""
				? Convert.ToInt32(txtParameterSpecialistId.Text)
				: -1;

			var emp = Program.CurrentUser.EmployeeData;
			throw new NotImplementedException("TODO");
//			foreach (var e in emp.GetOrders(orderId, customerId, specialistId))
//				searchResultsBindingSource.Add(e);
		}
	};
}