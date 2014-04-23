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
		Customers.Payment paymentData;

        public EnterEditCustomerForm()
        {
            InitializeComponent();

			base.recordKindName = "Customer";

			txtPhoneNumber.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);
			txtZipCode.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);
        }

		private void EnterEditCustomerForm_Load(object sender, EventArgs e)
		{
			var authority = Program.CurrentUser.Authority;

			// change the display name of the Edit button to View for specialists
			if (authority != UserAuthorityType.Sales ||
				this.EnterEditFormMode == EnterEditRecordFormMode.View)
				btnEditPayment.Text = "View";
			
			if (authority == UserAuthorityType.Specialist)
				btnEditPayment.Visible = false;
		}

		protected override void ToggleFieldsForEnterEditFormMode()
		{
			base.ToggleFieldsForEnterEditFormMode();

			switch (EnterEditFormMode)
			{
				case EnterEditRecordFormMode.View:
					if (btnEditPayment.Visible)
						btnEditPayment.Enabled = false;
					break;

				case EnterEditRecordFormMode.Edit:
					if (btnEditPayment.Visible)
						btnEditPayment.Enabled = true;
					break;

				case EnterEditRecordFormMode.Create:
//					if (btnEditPayment.Visible)
//						btnEditPayment.Enabled = false;
					break;
			}
		}

		Binding txtPaymentIdBinding { get { return txtPaymentId.DataBindings[0]; } }

		void DataBindToCustomerData()
		{
			SetRecordIdDataBinding(customerData);

			txtPaymentId.DataBindings.Add("Text", customerData, "PaymentId");

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

			if (customerData.PaymentId == -1)
			{
				valid = false;
				ShowValidationErrorMessage("Please add customer the payment details first");
			}

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

			customerData.PaymentId = salesAccess.AddPayment(paymentData);
			System.Diagnostics.Debug.Assert(customerData.PaymentId != -1);

			return salesAccess.AddCustomer(customerData);
		}
		protected override bool SaveEnterEditData()
		{
			var salesAccess = Program.CurrentUser.AsSales;

			return salesAccess.EditCustomer(customerData);
		}

		private void OnEditPayment(object sender, EventArgs e)
		{
			var recordFormMode = EnterEditRecordFormMode.Create;

			var salesAccess = Program.CurrentUser.AsSales;

			if (customerData.PaymentId == -1)
			{
				paymentData = new Customers.Payment();
			}
			else if(paymentData == null)
			{
				var payments = salesAccess.GetPayments(customerData.PaymentId);
				System.Diagnostics.Debug.Assert(payments.Count == 1);

				paymentData = payments[0];

				if (this.EnterEditFormMode == EnterEditRecordFormMode.View)
					recordFormMode = EnterEditRecordFormMode.View;
				else
				{
					switch (Program.CurrentUser.Authority)
					{
						case UserAuthorityType.Sales:
							recordFormMode = EnterEditRecordFormMode.Edit;
							break;

						default:
							recordFormMode = EnterEditRecordFormMode.View;
							break;
					}
				}
			}

			var recordForm = new EnterEditPaymentDialog();
			recordForm.SetEnterEditData(paymentData);
			recordForm.EnterEditFormMode = recordFormMode;

			if (recordForm.ShowDialog(this) == DialogResult.OK &&
				recordFormMode == EnterEditRecordFormMode.Create)
			{
				customerData.PaymentId = paymentData.Id;
				txtPaymentIdBinding.ReadValue();
			}
		}
    };
}