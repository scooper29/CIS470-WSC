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
    };
}