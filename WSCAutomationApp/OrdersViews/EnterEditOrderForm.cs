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

			txtSalesId.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);
			txtSpecialistId.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);
			txtCustomerId.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);
			txtInventoryId.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);

			cbxOrderPaidUpFront.Items.AddRange(Program.BooleanComboItems);
			cbxOrderPaid.Items.AddRange(Program.BooleanComboItems);
			cbxOrderValidated.Items.AddRange(Program.BooleanComboItems);
			cbxOrderComplete.Items.AddRange(Program.BooleanComboItems);
			cbxOrderClosed.Items.AddRange(Program.BooleanComboItems);

			var authority = Program.CurrentUser.Authority;
			// only show the Edit/View quality button to managers and specialists
			btnEditQuality.Visible = 
				authority == UserAuthorityType.Manager ||
				authority == UserAuthorityType.Specialist;

			// change the display name of the Edit button to View for specialists
			if (authority == UserAuthorityType.Specialist)
				btnEditQuality.Text = "View";

			// we currently shouldn't need to let users change the sales employee
			if (true)
			{
				btnSelectSalesEmployee.Visible = false;
				txtSalesId.ReadOnly = true;
			}

			// TODO: once we're out of testing, remove the explicit false
			// the manager is the only one who can change the assigned specialist
			if (false && authority != UserAuthorityType.Manager)
			{
				btnSelectSpecialistEmployee.Visible = false;
				txtSpecialistId.ReadOnly = true;
			}
			// the sales employee is the only one who can change the paid flags
			if (false && authority != UserAuthorityType.Sales)
			{
				txtCustomerId.ReadOnly = true;

				cbxOrderPaidUpFront.Enabled = false;
				cbxOrderPaid.Enabled = false;
			}
        }

		protected override void ToggleFieldsForEnterEditFormMode()
		{
			base.ToggleFieldsForEnterEditFormMode();

			switch (EnterEditFormMode)
			{
				case EnterEditRecordFormMode.Edit:
					if (btnEditQuality.Visible)
						btnEditQuality.Enabled = true;
					break;

				case EnterEditRecordFormMode.Create:
					if (btnEditQuality.Visible)
						btnEditQuality.Enabled = false;
					break;
			}
		}

		Binding txtSalesIdBinding { get { return txtSalesId.DataBindings[0]; } }
		Binding txtSpecialistIdBinding { get { return txtSpecialistId.DataBindings[0]; } }
		Binding txtCustomerIdBinding { get { return txtCustomerId.DataBindings[0]; } }
		Binding txtInventoryIdBinding { get { return txtInventoryId.DataBindings[0]; } }

		void DataBindToOrderData()
		{
			SetRecordIdDataBinding(orderData);

			txtSalesId.DataBindings.Add("Text", orderData, "SalesId");
			txtSpecialistId.DataBindings.Add("Text", orderData, "SpecialistId");
			txtCustomerId.DataBindings.Add("Text", orderData, "CustomerId");
			txtInventoryId.DataBindings.Add("Text", orderData, "InventoryId");
			txtQualityId.DataBindings.Add("Text", orderData, "QualityId");

			txtOrderMessage.DataBindings.Add("Text", orderData, "Message");
			txtOrderInvalidMemo.DataBindings.Add("Text", orderData, "InvalidMemo");

			Program.SetBooleanComboBoxBinding(cbxOrderPaidUpFront,
				orderData, "PaidUpFront");
			Program.SetBooleanComboBoxBinding(cbxOrderPaid,
				orderData, "Paid");
			Program.SetBooleanComboBoxBinding(cbxOrderValidated,
				orderData, "Validated");
			Program.SetBooleanComboBoxBinding(cbxOrderComplete,
				orderData, "Complete");
			Program.SetBooleanComboBoxBinding(cbxOrderClosed,
				orderData, "Closed");
		}

		public override void SetEnterEditData(object enterEditData)
		{
			if (orderData != null)
				throw new InvalidOperationException("data was previously set already");

			var order = enterEditData as Orders.Order;

			if (order == null)
				throw new ArgumentNullException("enterEditData");

			if (EnterEditFormMode == EnterEditRecordFormMode.Create)
				order.SalesId = Program.CurrentUser.EmployeeData.Id;

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

			if (orderData.CustomerId == -1)
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Customer ID");
			}

			if (orderData.InventoryId == -1)
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Inventory ID");
			}

			return valid;
		}

		protected override int AddEnterEditData()
		{
			var salesAccess = Program.CurrentUser.AsSales;

			return salesAccess.AddOrder(orderData);
		}
		protected override bool SaveEnterEditData()
		{
			var authority = Program.CurrentUser.Authority;
			if (authority == UserAuthorityType.Sales)
			{
				var salesAccess = Program.CurrentUser.AsSales;

				return salesAccess.EditOrder(orderData);
			}
			else if (authority == UserAuthorityType.Manager)
			{
				var managerAccess = Program.CurrentUser.AsManager;

				return managerAccess.ValidateOrder(orderData.Id, orderData.Validated, orderData.SpecialistId);
			}
			else
				throw new InvalidOperationException("This user doesn't have the authority to save changes to orders...");
		}

		private void OnSelectCustomer(object sender, EventArgs e)
		{
			var customer = Program.UserSearchForRecord
				<SearchCustomersDialog,Customers.Customer>(this);

			if (customer != null)
			{
				orderData.CustomerId = customer.Id;
				txtCustomerIdBinding.ReadValue();
			}
		}

		private void OnSelectInventory(object sender, EventArgs e)
		{
			var inv = Program.UserSearchForRecord
				<SearchInventoryDialog,Inventory.Inventory>(this);

			if (inv != null)
			{
				orderData.InventoryId = inv.Id;
				txtInventoryIdBinding.ReadValue();
			}
		}

		private void OnSelectSalesEmployee(object sender, EventArgs e)
		{
			var emp = Program.UserSearchForRecord
				<SearchEmployeesDialog,Employees.Employee>(this);

			if (emp != null)
			{
				orderData.SalesId = emp.Id;
				txtSalesIdBinding.ReadValue();
			}
		}

		private void OnSelectSpecialistEmployee(object sender, EventArgs e)
		{
			var emp = Program.UserSearchForRecord
				<SearchEmployeesDialog,Employees.Employee>(this);

			if (emp != null)
			{
				orderData.SpecialistId = emp.Id;
				txtSpecialistIdBinding.ReadValue();
			}
		}

		private void OnEditQualityLog(object sender, EventArgs e)
		{
			// TODO
		}
    };
}