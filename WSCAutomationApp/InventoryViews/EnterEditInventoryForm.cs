using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
    public partial class EnterEditInventoryForm : WSCAutomation.App.EnterEditRecordFormBase
    {
		Inventory.Inventory inventoryData;

        public EnterEditInventoryForm()
        {
            InitializeComponent();

			base.recordKindName = "Inventory";

			Program.Fix(numericUpDownQuantity);

			// only the clerk can enter inv order request details
			if (Program.CurrentUser.Authority != UserAuthorityType.StockClerk)
				btnSubmitRequestDetails.Visible = false;

			btnSubmitRequestDetails.Enabled = false;
        }

		protected override void ToggleFieldsForEnterEditFormMode()
		{
			base.ToggleFieldsForEnterEditFormMode();

			switch (EnterEditFormMode)
			{
				case EnterEditRecordFormMode.Edit:
					if(btnSubmitRequestDetails.Visible)
						btnSubmitRequestDetails.Enabled = true;
					break;

				case EnterEditRecordFormMode.Create:
					if (btnSubmitRequestDetails.Visible)
						btnSubmitRequestDetails.Enabled = false;
					break;
			}
		}

		void DataBindToInventoryData()
		{
			SetRecordIdDataBinding(inventoryData);

			txtInventoryName.DataBindings.Add("Text", inventoryData, "Name");
			txtManufacturerName.DataBindings.Add("Text", inventoryData, "Manufacturer");
			numericUpDownQuantity.DataBindings.Add("Value", inventoryData, "Quantity");
		}

		public override void SetEnterEditData(object enterEditData)
		{
			if (inventoryData != null)
				throw new InvalidOperationException("data was previously set already");

			var inv = enterEditData as Inventory.Inventory;

			if (inv == null)
				throw new ArgumentNullException("enterEditData");

			inventoryData = inv;
			DataBindToInventoryData();
		}

		public override int GetRecordIdValue()
		{
			return inventoryData.Id;
		}

		protected override bool PreSaveValidation()
		{
			bool valid = true;

			if (inventoryData.Name == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Name");
			}

			if (inventoryData.Manufacturer == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Manufacturer");
			}

			return valid;
		}

		protected override int AddEnterEditData()
		{
			var clerkAccess = Program.CurrentUser.AsStockClerk;

			return clerkAccess.AddInventory(inventoryData);
		}
		protected override bool SaveEnterEditData()
		{
			var clerkAccess = Program.CurrentUser.AsStockClerk;

			return clerkAccess.UpdateInventory(inventoryData);
		}

		private void OnSubmitRequestDetails(object sender, EventArgs e)
		{
			var invOrder = new Inventory.InventoryOrder();
			invOrder.InventoryId = inventoryData.Id;
			
			var recordForm = new PurchaseInventoryRequest();
			recordForm.EnterEditFormMode = EnterEditRecordFormMode.Create;
			recordForm.SetEnterEditData(invOrder);

			recordForm.ShowDialog(this);
		}
    };
}