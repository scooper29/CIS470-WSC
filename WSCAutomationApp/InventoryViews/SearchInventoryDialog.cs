using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
    public partial class SearchInventoryDialog : WSCAutomation.App.SearchRecordsDialogBase
    {
        public SearchInventoryDialog()
        {
            InitializeComponent();

			// only the clerk can enter inv order request details
			if (Program.CurrentUser.Authority != UserAuthorityType.StockClerk)
				btnSubmitRequestDetails.Visible = false;
        }

		protected override bool CurrentUserCanEditRecords { get {
			return Program.CurrentUser.Authority == UserAuthorityType.StockClerk;
		} }

		protected override void CreateSearchResultsColumns()
		{
			base.CreateSearchResultsColumns();

			var dgcName = new DataGridViewTextBoxColumn();
			dgcName.DataPropertyName = "Name";
			dgcName.Name = "Name";
			dgvSearchResults.Columns.Add(dgcName);

			var dgcManufacturer = new DataGridViewTextBoxColumn();
			dgcManufacturer.DataPropertyName = "Manufacturer";
			dgcManufacturer.Name = "Manufacturer";
			dgvSearchResults.Columns.Add(dgcManufacturer);

			var dgcQuantity = new DataGridViewTextBoxColumn();
			dgcQuantity.DataPropertyName = "Quantity";
			dgcQuantity.Name = "Quantity";
			dgvSearchResults.Columns.Add(dgcQuantity);
		}

		protected override void PerformSearch(BindingSource searchResultsBindingSource)
		{
			var invId = ParameterId;
			var invName = txtInventoryName.Text;
			var invManufacturerName = txtManufacturerName.Text;

			var emp = Program.CurrentUser.EmployeeData;
			foreach (var e in emp.CheckInventory(invId, invManufacturerName, invName))
				searchResultsBindingSource.Add(e);
		}

		protected override void OnSearchResultsSelectionChanged(object sender, EventArgs e)
		{
			base.OnSearchResultsSelectionChanged(sender, e);

			btnSubmitRequestDetails.Enabled = SelectedRecord != null;
		}

		private void OnSubmitRequestDetails(object sender, EventArgs e)
		{
			var inv = SelectedRecord as Inventory.Inventory;
			var invOrder = new Inventory.InventoryOrder();
			invOrder.InventoryId = inv.Id;

			var recordForm = new PurchaseInventoryRequest();
			recordForm.EnterEditFormMode = EnterEditRecordFormMode.Create;

			recordForm.ShowDialog(this);
		}
    }
}
