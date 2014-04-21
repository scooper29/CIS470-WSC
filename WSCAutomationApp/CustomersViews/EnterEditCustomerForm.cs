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

			txtPhoneNumber.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);
			txtZipCode.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);

			// only sales can get/edit the payment details
			if (Program.CurrentUser.Authority != UserAuthorityType.Sales)
				btnEditPayment.Visible = false;
        }

		void DataBindToCustomerData()
		{
			SetRecordIdDataBinding(customerData);

			txtFirstName.DataBindings.Add("Text", customerData, "FirstName");
			txtLastName.DataBindings.Add("Text", customerData, "LastName");
			txtEmail.DataBindings.Add("Text", customerData, "Email");
			txtPhoneNumber.DataBindings.Add("Text", customerData, "Phone");

			txtAddress.DataBindings.Add("Text", customerData, "Address");
			txtCity.DataBindings.Add("Text", customerData, "City");
			txtZipCode.DataBindings.Add("Text", customerData, "ZipCode");
			
			cbxState.DataBindings.Add("Text", customerData, "State");
			cbxState.Items.AddRange(Program.ListOfStates);
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

			if (customerData.FirstName == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "First Name");
			}

			if (customerData.LastName == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Last Name");
			}

			if (customerData.Email == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Email");
			}
			// TODO: should add a regex check to validate a well formed email address

			if (customerData.Address == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Address");
			}

			if (customerData.City == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "City");
			}

			if (customerData.State == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please select a State");
			}

			if (customerData.ZipCode == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Zip Code");
			}

			if (customerData.Phone == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Phone Number");
			}

			return valid;
		}

		protected override int AddEnterEditData()
		{
			var salesAccess = Program.CurrentUser.AsSales;

			return salesAccess.AddCustomer(customerData);
		}
		protected override bool SaveEnterEditData()
		{
			var salesAccess = Program.CurrentUser.AsSales;

			return salesAccess.EditCustomer(customerData);
		}

		private void OnEditPayment(object sender, EventArgs e)
		{
			var salesAccess = Program.CurrentUser.AsSales;

			Customers.Payment paymentData;

			if (customerData.PaymentId == -1)
			{
				paymentData = new Customers.Payment();
			}
			else
			{
				var payments = salesAccess.GetPayments(customerData.PaymentId);
				System.Diagnostics.Debug.Assert(payments.Count == 1);

				paymentData = payments[0];
			}

			throw new NotImplementedException("TODO");
		}
    };
}