using System;

namespace WSCAutomation
{
	/// <summary>
	/// Class for performing the initial setup of the DB so that it is usable
	/// </summary>
	public class InitialSetup
	{
		Database.DatabaseManager dbm;

		public InitialSetup()
		{
			dbm = new Database.DatabaseManager();
		}

		/// <summary>Setup the baseline Employees</summary>
		void SetupEmployees()
		{
			var emp = new Employees.Employee();

			emp.Access = Employees.AccessCode.Admin;
			emp.FirstName = "WSC";
			emp.LastName = "Admin";
			emp.Email = "admin@wsc.com";
			emp.UserName = "admin";
			emp.Password = "admin";
			dbm.DBAddEmployee(emp);
		}

		/// <summary>Setup the baseline Customer records and their associated Payments</summary>
		void SetupCustomers()
		{
		}

		/// <summary>Setup the baseline Inventory records</summary>
		void SetupInventory()
		{
		}

		/// <summary>Perform all the initial setup steps</summary>
		public void Perform()
		{
			if (dbm.InitializeAccessCodes())
				throw new Exception("Failed to initialize AccessCode table");

			SetupEmployees();
			SetupCustomers();
			SetupInventory();
		}
	};
}