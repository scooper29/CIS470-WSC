using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
    public partial class EnterEditOrderForm : WSCAutomation.App.EnterEditRecordFormBase
    {
		Orders.Order orderData;

        public EnterEditOrderForm()
        {
            InitializeComponent();

			base.recordKindName = "Order";
        }

		void DataBindToOrderData()
		{
			SetRecordIdDataBinding(orderData);

			// TODO
		}

		public override void SetEnterEditData(object enterEditData)
		{
			if (orderData != null)
				throw new InvalidOperationException("data was previously set already");

			var order = enterEditData as Orders.Order;

			if (order == null)
				throw new ArgumentNullException("enterEditData");

			orderData = order;
			DataBindToOrderData();
		}

		public override int GetRecordIdValue()
		{
			return orderData.Id;
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

		private void OnSelectCustomer(object sender, EventArgs e)
		{
		}

		private void OnSelectInventory(object sender, EventArgs e)
		{
		}

		private void OnSelectSalesEmployee(object sender, EventArgs e)
		{
		}

		private void OnSelectSpecialistEmployee(object sender, EventArgs e)
		{
		}
    };
}