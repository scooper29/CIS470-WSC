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

			return valid;
		}

		protected override int AddEnterEditData()
		{
			throw new NotImplementedException("TODO");
		}
		protected override bool SaveEnterEditData()
		{
			throw new NotImplementedException("TODO");
		}
    };
}