﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	// NOTE: we don't currently track open records.
	// Meaning right now, a person could search for an employee, edit the
	// record and not close the edit form. Then search for the record again,
	// and open another edit form while the old edit form is still open.

	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		#region Log In process logic
		/// <summary>Show the login dialog and validate the provided user credentials</summary>
		/// <param name="loginDialog"></param>
		/// <param name="dialogResult"></param>
		/// <returns>true if a user successfully logs in with valid credentials</returns>
		bool AttemptLogIn(LogInDialog loginDialog, out DialogResult dialogResult)
		{
			dialogResult = loginDialog.ShowDialog(this);

			if (dialogResult == DialogResult.Cancel) // "Exit" button translates to Cancel
				return false;

			var emp = Employees.Employee.TryLogin(loginDialog.UserName, loginDialog.Password);
			if (emp == null && dialogResult == DialogResult.OK)
			{
				MessageBox.Show(this, "Unrecognized username or password",
					"Log In failure",
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}

			Program.CurrentUser = new UserInfo(emp);

			return true;
		}
		/// <summary>Enters the app into the Login-or-Exit prompt state</summary>
		/// <remarks>This should happen at first startup or after logging out</remarks>
		void EnterLogInPrompt()
		{
			var loginDialog = new LogInDialog();

			// Keep letting the user attempt to log in until they exit or successfully enter user credentials
			DialogResult dialogResult;
			while (!AttemptLogIn(loginDialog, out dialogResult) && dialogResult != DialogResult.Cancel)
				continue;

			switch (dialogResult)
			{
				case DialogResult.OK:
					HandleNewAuthority(Program.CurrentUser.Authority);
					break;

				case DialogResult.Cancel: // "Exit" button translates to Cancel
					OnFileExitClick(this, EventArgs.Empty);
					break;

				default:
					throw new InvalidOperationException(dialogResult.ToString());
			}
		}
		#endregion

		#region Menu logic for User Authority
		/// <summary>Resets a menu item and all of its child drop down items to a given visiblity state</summary>
		/// <param name="menu">Menu we're reseting the visiblity on</param>
		/// <param name="visible">Visibility state to use</param>
		void ResetMenuItemVisibility(ToolStripMenuItem menu, bool visible)
		{
			menu.Visible = visible;
			foreach (var submenu in menu.DropDownItems)
				ResetMenuItemVisibility((ToolStripMenuItem)submenu, visible);
		}
		/// <summary>Resets <see cref="mainMenu"/>'s items to all be invisible, except for <see cref="fileMenu"/></summary>
		void ResetMainMenuVisibility()
		{
			foreach (var menu in mainMenu.Items)
				ResetMenuItemVisibility((ToolStripMenuItem)menu, visible: false);

			// file menu will always be visible to any authority
			ResetMenuItemVisibility(fileMenu, visible: true);
		}
		
		void HandleNewAuthority(UserAuthorityType newAuthorityType)
		{
			switch (newAuthorityType)
			{
				case UserAuthorityType.None:
					break;

				case UserAuthorityType.Admin:
					ResetMenuItemVisibility(adminMenu, visible: true);
					break;

				case UserAuthorityType.Manager:
					customersMenu.Visible = true;
					customersSearchMenuItem.Visible = true;

					ordersMenu.Visible = true;
					ordersSearchMenuItem.Visible = true;
					break;

				case UserAuthorityType.Sales:
					ResetMenuItemVisibility(customersMenu, visible: true);
					ResetMenuItemVisibility(ordersMenu, visible: true);
					break;

				case UserAuthorityType.Specialist:
					inventoryMenu.Visible = true;
					inventorySearchMenuItem.Visible = true;

					ordersMenu.Visible = true;
					ordersSearchMenuItem.Visible = true;
					break;

				case UserAuthorityType.StockClerk:
					ResetMenuItemVisibility(inventoryMenu, visible: true);
					break;
			}
		}
		#endregion

		void HandleNewSearchDialog(SearchRecordsDialogBase searchDialog)
		{
			searchDialog.SearchDialogMode = SearchRecordsDialogMode.Query;
			if (searchDialog.ShowDialog(this) == DialogResult.OK)
			{
				if (searchDialog.SearchDialogMode == SearchRecordsDialogMode.Query)
					HandleQueriedRecord(searchDialog);
			}
		}

		void HandleNewChildForm(Form form)
		{
			form.MdiParent = this;
			form.Show();
			form.BringToFront();
		}
		void HandleNewCreateRecordForm(EnterEditRecordFormBase enterForm, object enterEditData)
		{
			enterForm.EnterEditFormMode = EnterEditRecordFormMode.Create;
			enterForm.SetEnterEditData(enterEditData);
			HandleNewChildForm(enterForm);
		}
		/// <summary>Presents a form for editing or viewing a record</summary>
		/// <param name="recordForm"></param>
		/// <param name="formMode"></param>
		/// <param name="enterEditData"></param>
		void HandleNewQueryRecordForm(EnterEditRecordFormBase recordForm, EnterEditRecordFormMode formMode,
			object enterEditData)
		{
			// TODO: if we track any open records, we should handle the logic for adding them to whatever tracker here

			recordForm.SetEnterEditData(enterEditData);
			recordForm.EnterEditFormMode = formMode;
			HandleNewChildForm(recordForm);
		}

		/// <summary>Handle the selected record that was queried in a search dialog</summary>
		/// <param name="searchDialog"></param>
		/// <remarks>Figures out how to present a record for editing or just viewing</remarks>
		void HandleQueriedRecord(SearchRecordsDialogBase searchDialog)
		{
			var enterEditData = searchDialog.SelectedRecord;
			var formMode = EnterEditRecordFormMode.None;
			EnterEditRecordFormBase recordForm = null;

			#region Determine formMode
			switch (searchDialog.SearchDialogResult)
			{
				case SearchRecordsDialogResult.Edit:
					formMode = EnterEditRecordFormMode.Edit;
					break;

				case SearchRecordsDialogResult.View:
					formMode = EnterEditRecordFormMode.View;
					break;

				default:
					throw new InvalidOperationException("Unexpected search dialog result: " +
						searchDialog.SearchDialogResult);
			}
			#endregion

			#region Determine enterEditData
			if (enterEditData is Employees.Employee)
				recordForm = new EnterEditEmployeeForm();
			else if (enterEditData is Customers.Customer)
				recordForm = new EnterEditCustomerForm();
			else if (enterEditData is Inventory.Inventory)
				recordForm = new EnterEditInventoryForm();
			else if (enterEditData is Orders.Order)
				recordForm = new EnterEditOrderForm();
			else
			{
				System.Diagnostics.Debug.Assert(enterEditData != null);

				throw new NotImplementedException("Didn't know how to handle record data of type: " + 
					enterEditData.GetType().Name);
			}
			#endregion

			HandleNewQueryRecordForm(recordForm, formMode, enterEditData);
		}

		#region fileMenu events
		private void OnFileLogOutClick(object sender, EventArgs e)
		{
			// TODO: dispose any existing state created by the previous login
			ResetMainMenuVisibility();

			EnterLogInPrompt();
		}

		private void OnFileExitClick(object sender, EventArgs e)
		{
			Application.Exit();
			Program.MainForm = null;
		}
		#endregion

		#region inventoryMenu events
		private void OnInventorySearchClick(object sender, EventArgs e)
		{
			var searchDialog = new SearchInventoryDialog();
			HandleNewSearchDialog(searchDialog);
		}

		private void OnInventoryAddClick(object sender, EventArgs e)
		{
			var enterForm = new EnterEditInventoryForm();
			HandleNewCreateRecordForm(enterForm,
				new Inventory.Inventory());
		}
		#endregion

		#region customersMenu events
		private void OnCustomersSearchClick(object sender, EventArgs e)
		{
			var searchDialog = new SearchCustomersDialog();
			HandleNewSearchDialog(searchDialog);
		}

		private void OnCustomersAddClick(object sender, EventArgs e)
		{
			var enterForm = new EnterEditCustomerForm();
			HandleNewCreateRecordForm(enterForm,
				new Customers.Customer());
		}
		#endregion

		#region ordersMenu events
		private void OnOrdersSearchClick(object sender, EventArgs e)
		{
			var searchDialog = new SearchOrdersDialog();
			HandleNewSearchDialog(searchDialog);
		}

		private void OnOrdersAddClick(object sender, EventArgs e)
		{
			var enterForm = new EnterEditOrderForm();
			HandleNewCreateRecordForm(enterForm,
				new Orders.Order());
		}
		#endregion

		#region adminMenu events
		private void OnAdminSearchUsersClick(object sender, EventArgs e)
		{
			var searchDialog = new SearchEmployeesDialog();
			HandleNewSearchDialog(searchDialog);
		}

		private void OnAdminAddUserClick(object sender, EventArgs e)
		{
			var enterForm = new EnterEditEmployeeForm();
			HandleNewCreateRecordForm(enterForm,
				new Employees.Employee());
		}
		#endregion

		private void OnFormShown(object sender, EventArgs e)
		{
			ResetMainMenuVisibility();

			EnterLogInPrompt();
		}
	};
}