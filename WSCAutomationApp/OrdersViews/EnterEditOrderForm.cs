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

			txtCatalogNumber.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);

			//cbxOrderPaidUpFront.Items.AddRange(Program.BooleanComboItems);
			cbxOrderPaid.Items.AddRange(Program.BooleanComboItems);
			cbxOrderValidated.Items.AddRange(Program.BooleanComboItems);
			//cbxOrderComplete.Items.AddRange(Program.BooleanComboItems);
			cbxOrderClosed.Items.AddRange(Program.BooleanComboItems);
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

			txtCatalogNumber.DataBindings.Add("Text", orderData, "CatalogNumber");

			txtOrderMessage.DataBindings.Add("Text", orderData, "Message");
			txtOrderInvalidMemo.DataBindings.Add("Text", orderData, "InvalidMemo");

//			Program.SetBooleanComboBoxBinding(cbxOrderPaidUpFront,
//				orderData, "PaidUpFront");
			Program.SetBooleanComboBoxBinding(cbxOrderPaid,
				orderData, "Paid");
			Program.SetBooleanComboBoxBinding(cbxOrderValidated,
				orderData, "Validated");
//			Program.SetBooleanComboBoxBinding(cbxOrderComplete,
//				orderData, "Complete");
			Program.SetBooleanComboBoxBinding(cbxOrderClosed,
				orderData, "Closed");
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
			var salesAccess = Program.CurrentUser.AsSales;

			return salesAccess.AddOrder(orderData);
		}
		protected override bool SaveEnterEditData()
		{
			// TODO: need additional save conditions for different employees?

			var salesAccess = Program.CurrentUser.AsSales;

			return salesAccess.EditOrder(orderData);
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
    };
}