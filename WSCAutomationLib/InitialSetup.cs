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

		void AddAndVerifyNewEmployee(Employees.Admin fakeAdmin,
			Employees.Employee emp, int expectedId)
		{
			int empId = fakeAdmin.AddEmployee(emp);

			if (empId < 0)
				throw new InvalidOperationException("Failed to add "+emp.Access+" employee");

			if (empId != expectedId)
				throw new InvalidOperationException("Unexpected employee ID when adding a "+emp.Access);
		}
		/// <summary>Setup the baseline Employees</summary>
		void SetupEmployees()
		{
			// create a fake admin so we can both use and test its interface for adding employees
			var fakeAdmin = new Employees.Admin();
			// temporary employee object used to hold the data we'll be adding to the employees table
			Employees.Employee emp;
			// the expected ID of the next employee we're adding. DB Identity starts at 1, so we do as well
			int empExpectedId = 1;

			emp = new Employees.Employee
			{
				Access = Employees.AccessCode.Admin,
				FirstName = "WSC",
				LastName = "Admin",
				Email = "wscadm60683@gmail.com",
				UserName = "admin",
				Password = "admin",
			};
			AddAndVerifyNewEmployee(fakeAdmin, emp, empExpectedId++);

			emp = new Employees.Employee
			{
				Access = Employees.AccessCode.Manager,
				FirstName = "WSC",
				LastName = "Manager",
				Email = "wscman60683@gmail.com",
				UserName = "manager",
				Password = "manager",
			};
			AddAndVerifyNewEmployee(fakeAdmin, emp, empExpectedId++);

			emp = new Employees.Employee
			{
				Access = Employees.AccessCode.StockClerk,
				FirstName = "WSC",
				LastName = "Clerk",
				Email = "wscclerk60683@gmail.com",
				UserName = "clerk",
				Password = "clerk",
			};
			AddAndVerifyNewEmployee(fakeAdmin, emp, empExpectedId++);

			emp = new Employees.Employee
			{
				Access = Employees.AccessCode.Specialist,
				FirstName = "WSC",
				LastName = "Specialist",
				Email = "wscspec60683@gmail.com",
				UserName = "specialist",
				Password = "specialist",
			};
			AddAndVerifyNewEmployee(fakeAdmin, emp, empExpectedId++);

			emp = new Employees.Employee
			{
				Access = Employees.AccessCode.Sales,
				FirstName = "WSC",
				LastName = "Sales",
				Email = "wscsales60683@gmail.com",
				UserName = "sales",
				Password = "sales",
			};
			AddAndVerifyNewEmployee(fakeAdmin, emp, empExpectedId++);
		}

		void AddAndVerifyNewCustomer(Employees.Sales fakeSales,
			Customers.Customer cust, int expectedId)
		{
			int custId = fakeSales.AddCustomer(cust);

			if (custId < 0)
				throw new InvalidOperationException("Failed to add customer: "+cust.Email);

			if (custId != expectedId)
				throw new InvalidOperationException("Unexpected customer ID when adding customer: "+cust.Email);
		}
		/// <summary>Setup the baseline Customer records and their associated Payments</summary>
		void SetupCustomers()
		{
			// create a fake Sales so we can both use and test its interface for adding customers
			var fakeSales = new Employees.Sales();
			// temporary customer object used to hold the data we'll be adding to the customers table
			Customers.Customer cust;
			// the expected ID of the next customer we're adding. DB Identity starts at 1, so we do as well
			int custExpectedId = 1;

			cust = new Customers.Customer
			{
				FirstName = "WSC",
				LastName = "Customer",
				Email = "customer@wsc.com",
				Address = "1234 DeVry Stinks Road",
				City = "College",
				State = "CT",
				ZipCode = "06883",
				Phone = "203-555-1234",
			};
			AddAndVerifyNewCustomer(fakeSales, cust, custExpectedId++);
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