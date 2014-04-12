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
			dbm = Database.DatabaseManager.Instance;
		}

		/// <summary>Setup the baseline Employees</summary>
		void SetupEmployees()
		{
			var emp = new Employees.Employee();

			emp.Access = Employees.AccessCode.Admin;
			emp.FirstName = "WSC";
			emp.LastName = "Admin";
			emp.Email = "wscadm60683@gmail.com";
			emp.UserName = "admin";
			emp.Password = "admin";
			dbm.DBAddEmployee(emp);

			emp = new Employees.Employee();
			emp.Access = Employees.AccessCode.Manager;
			emp.FirstName = "WSC";
			emp.LastName = "Manager";
			emp.Email = "wscman60683@gmail.com";
			emp.UserName = "manager";
			emp.Password = "manager";
			dbm.DBAddEmployee(emp);

			emp = new Employees.Employee();
			emp.Access = Employees.AccessCode.StockClerk;
			emp.FirstName = "WSC";
			emp.LastName = "Clerk";
			emp.Email = "wscclerk60683@gmail.com";
			emp.UserName = "clerk";
			emp.Password = "clerk";
			dbm.DBAddEmployee(emp);

			emp = new Employees.Employee();
			emp.Access = Employees.AccessCode.Specialist;
			emp.FirstName = "WSC";
			emp.LastName = "Specialist";
			emp.Email = "wscspec60683@gmail.com";
			emp.UserName = "specialist";
			emp.Password = "specialist";
			dbm.DBAddEmployee(emp);

			emp = new Employees.Employee();
			emp.Access = Employees.AccessCode.Sales;
			emp.FirstName = "WSC";
			emp.LastName = "Sales";
			emp.Email = "wscsales60683@gmail.com";
			emp.UserName = "sales";
			emp.Password = "sales";
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
			if (!dbm.InitializeAccessCodes())
				throw new Exception("Failed to initialize AccessCode table");

			SetupEmployees();
			SetupCustomers();
			SetupInventory();
		}
	};
}