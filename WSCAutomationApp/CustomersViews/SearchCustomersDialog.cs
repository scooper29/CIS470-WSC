using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
    public partial class SearchCustomersDialog : WSCAutomation.App.SearchRecordsDialogBase
    {
        public SearchCustomersDialog()
        {
            InitializeComponent();
        }

		protected override bool CurrentUserCanEditRecords { get {
			return Program.CurrentUser.Authority == UserAuthorityType.Sales;
		} }

		protected override void CreateSearchResultsColumns()
		{
			base.CreateSearchResultsColumns();

			var dgcEmail = new DataGridViewTextBoxColumn();
			dgcEmail.DataPropertyName = "Email";
			dgcEmail.Name = "Email";
			dgvSearchResults.Columns.Add(dgcEmail);

			var dgcLastName = new DataGridViewTextBoxColumn();
			dgcLastName.DataPropertyName = "LastName";
			dgcLastName.Name = "Last Name";
			dgvSearchResults.Columns.Add(dgcLastName);

			var dgcFirstName = new DataGridViewTextBoxColumn();
			dgcFirstName.DataPropertyName = "FirstName";
			dgcFirstName.Name = "First Name";
			dgvSearchResults.Columns.Add(dgcFirstName);
		}

		protected override void PerformSearch(BindingSource searchResultsBindingSource)
		{
			var customerId = ParameterId;
			var lastName = txtCustomerLastName.Text;

			var salesAccess = Program.CurrentUser.AsSales;
			// TODO: there's no GetCustomers currently...
			throw new NotImplementedException("TODO");
//			foreach (var e in salesAccess.GetCustomers(customerId, lastName))
//				searchResultsBindingSource.Add(e);
		}
    }
}
