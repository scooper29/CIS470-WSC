using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
    public partial class PurchaseInventoryRequest : WSCAutomation.App.EnterEditRecordFormBase
    {
		Inventory.InventoryOrder invOrderData;

        public PurchaseInventoryRequest()
        {
            InitializeComponent();

			base.recordKindName = "Inventory Order";

			Program.Fix(upDownOrderQty);

			// the ID of the InvOrder isn't useful to the user, don't show it
			base.lblRecordId.Visible = false;
			base.txtRecordId.Visible = false;
        }

		void DataBindToInvOrderData()
		{
			SetRecordIdDataBinding(invOrderData);

			txtInventoryId.DataBindings.Add("Text", invOrderData, "InventoryId");
			upDownOrderQty.DataBindings.Add("Value", invOrderData, "Quantity");
			dateTimePickerOrderDate.DataBindings.Add("Value", invOrderData, "OrderDate");
			dateTimePickerDelieveryDate.DataBindings.Add("Value", invOrderData, "ArrivalDate");
		}

		public override void SetEnterEditData(object enterEditData)
		{
			if (invOrderData != null)
				throw new InvalidOperationException("data was previously set already");

			var invOrder = enterEditData as Inventory.InventoryOrder;

			if (invOrder == null)
				throw new ArgumentNullException("enterEditData");

			invOrderData = invOrder;
			DataBindToInvOrderData();
		}

		public override int GetRecordIdValue()
		{
			return invOrderData.Id;
		}

		protected override bool PreSaveValidation()
		{
			bool valid = true;

			if (invOrderData.ArrivalDate < invOrderData.OrderDate)
			{
				valid = false;
				ShowValidationErrorMessage("Arrival date can't come before the initial order!");
			}

			return valid;
		}

		protected override int AddEnterEditData()
		{
			var clerkAccess = Program.CurrentUser.AsStockClerk;

			return clerkAccess.OrderInventory(invOrderData);
			throw new NotImplementedException("TODO");
		}
		protected override bool SaveEnterEditData()
		{
			var clerkAccess = Program.CurrentUser.AsStockClerk;

			//return clerkAccess.EditInventoryOrder(invOrderData);
			throw new NotSupportedException("TODO");
		}

		protected override void OnSaveClick(object sender, EventArgs e)
		{
			base.OnSaveClick(sender, e);

			if (this.DialogResult == DialogResult.OK)
				this.Close();
		}
    };
}