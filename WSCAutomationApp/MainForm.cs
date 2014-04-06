using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	public partial class MainForm : Form
	{
		public MainForm()
		{
			InitializeComponent();
		}

		#region Log In process logic
		static UserAuthorityType UserAuthorityFromUserNameHack(string username)
		{
			username = username.ToLowerInvariant();

			switch (username)
			{
				case "admin":
					return UserAuthorityType.Admin;

				case "manager":
					return UserAuthorityType.Manager;

				case "sales":
					return UserAuthorityType.Sales;

				case "specialist":
					return UserAuthorityType.Specialist;

				case "clerk":
					return UserAuthorityType.StockClerk;

				default:
					return UserAuthorityType.None;
			}
		}
		
		/// <summary>Show the login dialog and validate the provided user credentials</summary>
		/// <param name="loginDialog"></param>
		/// <param name="dialogResult"></param>
		/// <returns>true if a user successfully logs in with valid credentials</returns>
		bool AttemptLogIn(LogInDialog loginDialog, out DialogResult dialogResult)
		{
			dialogResult = loginDialog.ShowDialog(this);

			// HACK: temporary setup, until there's an actual backend
			var userAuthorityType = UserAuthorityFromUserNameHack(loginDialog.UserName);
			if (userAuthorityType == UserAuthorityType.None && dialogResult == DialogResult.OK)
			{
				MessageBox.Show(this, "Unrecognized username or password",
					"Log In failure",
					MessageBoxButtons.OK, MessageBoxIcon.Error);

				return false;
			}

			Program.CurrentUser = new UserInfo(userAuthorityType);

			return true;
		}
		/// <summary>Enters the app into the Login-or-Exit prompt state</summary>
		/// <remarks>This should happen at first startup or after logging out</remarks>
		void EnterLogInPrompt()
		{
			var loginDialog = new LogInDialog();

			// Keep letting the user attempt to log in until they exit or successfully enter user credentials
			DialogResult dialogResult;
			while (!AttemptLogIn(loginDialog, out dialogResult))
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

		void HandleNewChildForm(Form form)
		{
			form.MdiParent = this;
			form.Show();
			form.BringToFront();
		}
		void HandleNewCreateRecordForm(EnterEditRecordFormBase enterForm)
		{
			enterForm.EnterEditFormMode = EnterEditRecordFormMode.Create;
			HandleNewChildForm(enterForm);
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
		}
		#endregion

		#region inventoryMenu events
		private void OnInventorySearchClick(object sender, EventArgs e)
		{
		}

		private void OnInventoryAddClick(object sender, EventArgs e)
		{
			var enterForm = new EnterEditInventoryForm();
			HandleNewCreateRecordForm(enterForm);
		}
		#endregion

		#region customersMenu events
		private void OnCustomersSearchClick(object sender, EventArgs e)
		{
		}

		private void OnCustomersAddClick(object sender, EventArgs e)
		{
			var enterForm = new EnterEditCustomerForm();
			HandleNewCreateRecordForm(enterForm);
		}
		#endregion

		#region ordersMenu events
		private void OnOrdersSearchClick(object sender, EventArgs e)
		{
			var searchDialog = new SearchOrdersDialog();
			searchDialog.ShowDialog(this);
		}

		private void OnOrdersAddClick(object sender, EventArgs e)
		{
			var enterForm = new EnterEditOrderForm();
			HandleNewCreateRecordForm(enterForm);
		}
		#endregion

		#region adminMenu events
		private void OnAdminSearchUsersClick(object sender, EventArgs e)
		{
			var searchDialog = new SearchEmployeesDialog();
			searchDialog.ShowDialog(this);
		}

		private void OnAdminAddUserClick(object sender, EventArgs e)
		{
			var enterForm = new EnterEditEmployeeForm();
			HandleNewCreateRecordForm(enterForm);
		}
		#endregion

		private void OnFormShown(object sender, EventArgs e)
		{
			ResetMainMenuVisibility();

			EnterLogInPrompt();
		}
	};
}