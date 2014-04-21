using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
    public partial class EnterEditCustomerForm : WSCAutomation.App.EnterEditRecordFormBase
    {
		Customers.Customer customerData;

        public EnterEditCustomerForm()
        {
            InitializeComponent();

			base.recordKindName = "Customer";
        }

		void DataBindToCustomerData()
		{
			SetRecordIdDataBinding(customerData);

			// TODO
		}

		public override void SetEnterEditData(object enterEditData)
		{
			if (customerData != null)
				throw new InvalidOperationException("data was previously set already");

			var customer = enterEditData as Customers.Customer;

			if (customer == null)
				throw new ArgumentNullException("enterEditData");

			customerData = customer;
			DataBindToCustomerData();
		}

		public override int GetRecordIdValue()
		{
			return customerData.Id;
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