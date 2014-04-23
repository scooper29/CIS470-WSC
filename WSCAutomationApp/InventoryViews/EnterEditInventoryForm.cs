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

			btnSubmitRequestDetails.Enabled = false;
        }

		private void EnterEditInventoryForm_Load(object sender, EventArgs e)
		{
			// only the clerk can enter inv order request details
			if (Program.CurrentUser.Authority != UserAuthorityType.StockClerk)
			{
				btnSubmitRequestDetails.Visible = false;
				btnMarkAsDelivered.Visible = false;
				numericUpDownQuantity.ReadOnly = true;
			}

			// only the specialist can request the inventory
			if (Program.CurrentUser.Authority != UserAuthorityType.Specialist)
				btnRequestInventory.Visible = false;
		}

		protected override void ToggleFieldsForEnterEditFormMode()
		{
			base.ToggleFieldsForEnterEditFormMode();

			switch (EnterEditFormMode)
			{
				case EnterEditRecordFormMode.Edit:
				case EnterEditRecordFormMode.View:
					if (Program.CurrentUser.Authority == UserAuthorityType.StockClerk)
						btnSubmitRequestDetails.Enabled = true;
					break;

				case EnterEditRecordFormMode.Create:
					btnSubmitRequestDetails.Enabled = false;
					btnMarkAsDelivered.Enabled = false;
					break;
			}
		}

		Binding numericUpDownQuantityBinding { get { return numericUpDownQuantity.DataBindings[0]; } }

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

		private void OnMarkAsSold(object sender, EventArgs e)
		{
			var specAccess = Program.CurrentUser.AsSpecialist;

			string message = "";

			if (inventoryData.Quantity == 0)
			{
				specAccess.RequestOutofstockInventory(inventoryData);

				message = "Inventory is out of stock, but a request to order more was sent to the Stock Clerk";
				btnRequestInventory.Enabled = false;
			}
			else
			{
				bool success = specAccess.RequestInstockInventory(inventoryData, specAccess.Id);

				if (success)
				{
					message = "Inventory was successfully marked 'sold'. A clerk will be notified shortly.";
					btnRequestInventory.Enabled = false;
				}
				else
					message = "Failed to mark the inventory as sold. Contact support.";
			}

			MessageBox.Show(this, message, "Info");
		}

		private void OnMarkAsDelivered(object sender, EventArgs e)
		{
			if (inventoryData.Quantity == 0)
			{
				MessageBox.Show(this,
					"You need to order more inventory before you can deliver it!",
					"Error");
			}

			var clerkAccess = Program.CurrentUser.AsStockClerk;

			bool success = clerkAccess.PullInventory(inventoryData);

			string message = "";
			if (success)
			{
				message = "Inventory was successfully delivered. The specialist will be notified shortly.";
				numericUpDownQuantityBinding.ReadValue();
			}
			else
				message = "Failed to mark the inventory as delivered. Contact support.";

			MessageBox.Show(this, message, "Info");
		}
    };
}