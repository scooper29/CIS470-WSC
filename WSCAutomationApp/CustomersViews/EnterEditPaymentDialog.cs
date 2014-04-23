using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	public partial class EnterEditPaymentDialog : WSCAutomation.App.EnterEditRecordFormBase
	{
		Customers.Payment paymentData;

		public EnterEditPaymentDialog()
		{
			InitializeComponent();

			base.recordKindName = "Customer Payment";

			// the ID of the Quality log isn't useful to the user, don't show it
			base.lblRecordId.Visible = false;
			base.txtRecordId.Visible = false;

			txtCardNumber.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);

			cbxType.Items.Add("VISA");
			cbxType.Items.Add("MASTERCARD");
			cbxType.Items.Add("DISCOVER");
			cbxType.Items.Add("CHASE");
		}

		void DataBindToPaymentData()
		{
			SetRecordIdDataBinding(paymentData);

			txtCardNumber.DataBindings.Add("Text", paymentData, "CardNumber");
			cbxType.DataBindings.Add("Text", paymentData, "Type");
			dateTimePickerExpiration.DataBindings.Add("Value", paymentData, "ExpirationDate");
		}

		public override void SetEnterEditData(object enterEditData)
		{
			if (paymentData != null)
				throw new InvalidOperationException("data was previously set already");

			var payment = enterEditData as Customers.Payment;

			if (payment == null)
				throw new ArgumentNullException("enterEditData");

			paymentData = payment;
			DataBindToPaymentData();
		}

		public override int GetRecordIdValue()
		{
			return paymentData.Id;
		}

		protected override bool PreSaveValidation()
		{
			bool valid = true;

			if (paymentData.CardNumber == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Card Number");
			}

			return valid;
		}

		protected override int AddEnterEditData()
		{
			var salesAccess = Program.CurrentUser.AsSales;

			return salesAccess.AddPayment(paymentData);
		}
		protected override bool SaveEnterEditData()
		{
			var salesAccess = Program.CurrentUser.AsSales;

			return salesAccess.EditPayment(paymentData);
		}
	}
}