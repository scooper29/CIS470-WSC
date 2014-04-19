using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace WSCAutomation.App
{
	using Employees;

	public partial class EnterEditEmployeeForm : WSCAutomation.App.EnterEditRecordFormBase
	{
		#region AccessCode formatting and parsing logic
		static Dictionary<AccessCode, string> AccessCodeToDisplayName;

		static EnterEditEmployeeForm()
		{
			AccessCodeToDisplayName = new Dictionary<AccessCode, string>();

			AccessCodeToDisplayName.Add(AccessCode.None, "None");
			AccessCodeToDisplayName.Add(AccessCode.Admin, "Admin");
			AccessCodeToDisplayName.Add(AccessCode.Manager, "Manager");
			AccessCodeToDisplayName.Add(AccessCode.Sales, "Sales");
			AccessCodeToDisplayName.Add(AccessCode.Specialist, "Specialist");
			AccessCodeToDisplayName.Add(AccessCode.StockClerk, "Stock Clerk");
		}

		static void StringToAccessCode(object sender, ConvertEventArgs e)
		{
			if (e.DesiredType != typeof(AccessCode)) return;
			if (e.Value.GetType() != typeof(string)) return;

			string name = (string)e.Value;
			foreach (var kv in AccessCodeToDisplayName)
				if (name == kv.Value)
					e.Value = kv.Key;
		}
		static void AccessCodeToString(object sender, ConvertEventArgs e)
		{
			if (e.DesiredType != typeof(string)) return;
			if (e.Value.GetType() != typeof(AccessCode)) return;

			var ac = (AccessCode)e.Value;
			e.Value = AccessCodeToDisplayName[ac];
		}
		#endregion

		Employees.Employee employeeData;

		public EnterEditEmployeeForm()
		{
			InitializeComponent();

			base.recordKindName = "User";

			foreach (var name in AccessCodeToDisplayName.Values)
				cbxAccessCode.Items.Add(name);
		}

		void DataBindToEmployeeData()
		{
			SetRecordIdDataBinding(employeeData);

			var access_binding = new Binding("Text", employeeData, "Access");
			access_binding.Format += new ConvertEventHandler(AccessCodeToString);
			access_binding.Parse += new ConvertEventHandler(StringToAccessCode);
			cbxAccessCode.DataBindings.Add(access_binding);

			txtFirstName.DataBindings.Add("Text", employeeData, "FirstName");
			txtLastName.DataBindings.Add("Text", employeeData, "LastName");
			txtEmail.DataBindings.Add("Text", employeeData, "Email");

			txtUserName.DataBindings.Add("Text", employeeData, "UserName");
			txtPassword.DataBindings.Add("Text", employeeData, "Password");
		}

		public override void SetEnterEditData(object enterEditData)
		{
			// NOTE: if we allow the reseting of employeeData, we will need to clear the existing
			// data bindings from our controls
			if (employeeData != null)
				throw new InvalidOperationException("employeeData was previously set already");

			var emp = enterEditData as Employees.Employee;

			if (emp == null)
				throw new ArgumentNullException("enterEditData");

			employeeData = emp;
			DataBindToEmployeeData();
		}

		public override int GetRecordIdValue()
		{
			return employeeData.Id;
		}

		protected override bool PreSaveValidation()
		{
			bool valid = true;

			if (employeeData.Access == Employees.AccessCode.None)
			{
				valid = false;
				ShowValidationErrorMessage("Please set employee access to something other than None");
			}

			if (employeeData.FirstName == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "First Name");
			}

			if (employeeData.LastName == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Last Name");
			}

			if (employeeData.Email == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Email");
			}
			// TODO: should add a regex check to validate a well formed email address

			if (employeeData.UserName == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "User Name");
			}

			if (employeeData.Password == "")
			{
				valid = false;
				ShowValidationErrorMessage("Please provide a value for {0}", "Password");
			}

			return valid;
		}

		protected override int AddEnterEditData()
		{
			var adminAccess = Program.CurrentUser.AsAdmin;

			return adminAccess.AddEmployee(employeeData);
		}
		protected override bool SaveEnterEditData()
		{
			var adminAccess = Program.CurrentUser.AsAdmin;

			return adminAccess.EditEmployee(employeeData);
		}
	};
}