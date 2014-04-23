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
			txtSpecialistId.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnlyAndNegativeSign);
			txtCustomerId.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);
			txtInventoryId.KeyPress += new KeyPressEventHandler(Program.OnTextBoxKeyPressAllowNumbersOnly);

			cbxOrderPaidUpFront.Items.AddRange(Program.BooleanComboItems);
			cbxOrderPaid.Items.AddRange(Program.BooleanComboItems);
			cbxOrderValidated.Items.AddRange(Program.BooleanComboItems);
			cbxOrderComplete.Items.AddRange(Program.BooleanComboItems);
			cbxOrderClosed.Items.AddRange(Program.BooleanComboItems);
        }

		private void EnterEditOrderForm_Load(object sender, EventArgs e)
		{
			var authority = Program.CurrentUser.Authority;
			// only show the Edit/View quality button to managers and specialists
			btnEditQuality.Visible =
				authority == UserAuthorityType.Manager ||
				authority == UserAuthorityType.Specialist;

			// change the display name of the Edit button to View for specialists
			if (authority == UserAuthorityType.Specialist ||
				this.EnterEditFormMode == EnterEditRecordFormMode.View)
				btnEditQuality.Text = "View";

			// we currently shouldn't need to let users change the sales employee
			if (true)
			{
				btnSelectSalesEmployee.Visible = false;
				txtSalesId.ReadOnly = true;
			}

			#region Disable Manager-only fields
			if (authority != UserAuthorityType.Manager)
			{
				btnSelectSpecialistEmployee.Visible = false;
				txtSpecialistId.ReadOnly = true;
				btnValidateOrder.Visible = false;

				cbxOrderClosed.Enabled = false;
				txtOrderInvalidMemo.ReadOnly = true;
			}				
			#endregion

			#region Disable Sales-only fields
			if (authority != UserAuthorityType.Sales)
			{
				btnSelectCustomer.Visible = false;
				txtCustomerId.ReadOnly = true;

				btnSelectInventory.Visible = false;
				txtInventoryId.ReadOnly = true;

				txtOrderMessage.ReadOnly = true;

				cbxOrderPaidUpFront.Enabled = false;
				cbxOrderPaid.Enabled = false;
			}
			#endregion

			#region Disable Specialist-only fields
			if (authority != UserAuthorityType.Specialist)
			{
				btnMarkCompleted.Visible = false;
			}
			#endregion

			if (EnterEditFormMode == EnterEditRecordFormMode.Edit)
			{
				if (orderData.Validated)
				{
					btnValidateOrder.Enabled = false;
					txtSpecialistId.ReadOnly = true;
				}
				// Only the manager can reverse a completion
				if (orderData.Complete &&
					authority == UserAuthorityType.Specialist)
				{
					btnMarkCompleted.Enabled = false;
				}
				if (orderData.Complete &&
					authority == UserAuthorityType.Manager)
				{
					cbxOrderComplete.Enabled = true;
				}
			}

			if (orderData.QualityId == -1 &&
				(authority != UserAuthorityType.Manager ||
				 EnterEditFormMode == EnterEditRecordFormMode.View))
			{
				btnEditQuality.Visible = false;
			}
		}

		protected override void ToggleFieldsForEnterEditFormMode()
		{
			base.ToggleFieldsForEnterEditFormMode();

			switch (EnterEditFormMode)
			{
				case EnterEditRecordFormMode.View:
					btnSelectCustomer.Visible = false;
					btnSelectInventory.Visible = false;
					btnSelectSalesEmployee.Visible = false;
					btnSelectSpecialistEmployee.Visible = false;
					btnMarkCompleted.Visible = false;
					btnValidateOrder.Visible = false;
					break;

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
		Binding txtQualityIdBinding { get { return txtQualityId.DataBindings[0]; } }
		Binding cbxOrderValidatedBinding { get { return cbxOrderValidated.DataBindings[0]; } }
		Binding cbxOrderCompleteBinding { get { return cbxOrderComplete.DataBindings[0]; } }

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
			var emp = Program.CurrentUser.EmployeeData;

			#region Customer ID
			if (orderData.CustomerId == -1)
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Customer ID");
			}
			else if (!txtCustomerId.ReadOnly && 
				emp.GetCustomers(orderData.CustomerId).Count == 0)
			{
				valid = false;
				ShowValidationErrorMessage("No {0} exists by the given ID", "Customer");
			}
			#endregion

			#region Inventory ID
			if (orderData.InventoryId == -1)
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Inventory ID");
			}
			else if (!txtInventoryId.ReadOnly &&
				emp.CheckInventory(orderData.InventoryId).Count == 0)
			{
				valid = false;
				ShowValidationErrorMessage("No {0} exists by the given ID", "Inventory");
			}
			#endregion

			#region Sales ID
			if (orderData.SalesId != -1 && !txtSalesId.ReadOnly &&
				emp.GetEmployees(orderData.SalesId).Count == 0)
			{
				valid = false;
				ShowValidationErrorMessage("No {0} exists by the given ID", "Sales Employee");
			}
			#endregion

			#region Inventory ID
			if (orderData.SpecialistId != -1 && !txtSpecialistId.ReadOnly &&
				emp.GetEmployees(orderData.SpecialistId).Count == 0)
			{
				valid = false;
				ShowValidationErrorMessage("No {0} exists by the given ID", "Specialist");
			}
			#endregion

			#region Message
			if (orderData.Message == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Message");
			}
			#endregion

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

				if (!orderData.Validated)
					return managerAccess.ValidateOrder(orderData);
				else
					return managerAccess.UpdateOrder(orderData);
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
			var recordFormMode = EnterEditRecordFormMode.Create;

			Orders.QualityCheckList quality = null;
			if (orderData.QualityId == -1)
				quality = new Orders.QualityCheckList();
			else
			{
				var emp = Program.CurrentUser.EmployeeData;

				var lists = emp.GetQualityCheckLists(orderData.QualityId);
				if (lists.Count != 1)
					throw new InvalidOperationException("GetQualityCheckLists returned an unexpected number of lists");

				quality = lists[0];

				if (this.EnterEditFormMode == EnterEditRecordFormMode.View)
					recordFormMode = EnterEditRecordFormMode.View;
				else
				{
					switch (Program.CurrentUser.Authority)
					{
						case UserAuthorityType.Manager:
							recordFormMode = EnterEditRecordFormMode.Edit;
							break;

						case UserAuthorityType.Specialist:
							recordFormMode = EnterEditRecordFormMode.View;
							break;

						default:
							throw new InvalidOperationException();
					}
				}
			}

			var recordForm = new EnterEditOrderQualityDialog();
			recordForm.SetEnterEditData(quality, orderData);
			recordForm.EnterEditFormMode = recordFormMode;

			// if the quality data was saved and we were creating a new
			// quality checklist, force the quality ID UI to update with the new ID
			if (recordForm.ShowDialog(this) == DialogResult.OK &&
				recordFormMode == EnterEditRecordFormMode.Create)
			{
				var managerAccess = Program.CurrentUser.AsManager;
				managerAccess.UpdateOrder(orderData);

				txtQualityIdBinding.ReadValue();
			}
		}

		private void OnValidateOrder(object sender, EventArgs e)
		{
			var managerAccess = Program.CurrentUser.AsManager;

			orderData.Validated = true;
			if (managerAccess.ValidateOrder(orderData))
			{
				btnSelectSpecialistEmployee.Enabled = false;
				txtSpecialistId.ReadOnly = true;
				btnValidateOrder.Enabled = false;
				cbxOrderValidatedBinding.ReadValue();

				MessageBox.Show(this, "Order validated!", "Success");
			}
			else
			{
				orderData.Validated = false;

				MessageBox.Show(this, "Order failed to validate! Contact support", "Failure");
			}
		}

		private void OnMarkCompleted(object sender, EventArgs e)
		{
			var specAccess = Program.CurrentUser.AsSpecialist;

			bool success = specAccess.MarkOrderComplete(orderData, specAccess.Id);

			string message = "";
			if (success)
			{
				message = "Order marked as complete. A manager will be notified shortly.";

				btnMarkCompleted.Enabled = false;
				cbxOrderCompleteBinding.ReadValue();
			}
			else
				message = "Failed to mark as completed. Contact support";

			MessageBox.Show(this, message, "Success");
		}
    };
}