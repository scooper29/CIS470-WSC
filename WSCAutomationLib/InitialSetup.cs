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
			var emp = new Employees.Employee();
			// the expected ID of the next employee we're adding. DB Identity starts at 1, so we do as well
			int empExpectedId = 1;

			emp.Access = Employees.AccessCode.Admin;
			emp.FirstName = "WSC";
			emp.LastName = "Admin";
			emp.Email = "wscadm60683@gmail.com";
			emp.UserName = "admin";
			emp.Password = "admin";
			AddAndVerifyNewEmployee(fakeAdmin, emp, empExpectedId++);

			emp = new Employees.Employee();
			emp.Access = Employees.AccessCode.Manager;
			emp.FirstName = "WSC";
			emp.LastName = "Manager";
			emp.Email = "wscman60683@gmail.com";
			emp.UserName = "manager";
			emp.Password = "manager";
			AddAndVerifyNewEmployee(fakeAdmin, emp, empExpectedId++);

			emp = new Employees.Employee();
			emp.Access = Employees.AccessCode.StockClerk;
			emp.FirstName = "WSC";
			emp.LastName = "Clerk";
			emp.Email = "wscclerk60683@gmail.com";
			emp.UserName = "clerk";
			emp.Password = "clerk";
			AddAndVerifyNewEmployee(fakeAdmin, emp, empExpectedId++);

			emp = new Employees.Employee();
			emp.Access = Employees.AccessCode.Specialist;
			emp.FirstName = "WSC";
			emp.LastName = "Specialist";
			emp.Email = "wscspec60683@gmail.com";
			emp.UserName = "specialist";
			emp.Password = "specialist";
			AddAndVerifyNewEmployee(fakeAdmin, emp, empExpectedId++);

			emp = new Employees.Employee();
			emp.Access = Employees.AccessCode.Sales;
			emp.FirstName = "WSC";
			emp.LastName = "Sales";
			emp.Email = "wscsales60683@gmail.com";
			emp.UserName = "sales";
			emp.Password = "sales";
			AddAndVerifyNewEmployee(fakeAdmin, emp, empExpectedId++);
		}

		void AddAndVerifyNewCustomer(Employees.Sales fakeSales,
			Customers.Customer cust, int expectedId)
		{
			// TODO: AddCustomer API needs to be implemented
			int custId = -1;//fakeSales.AddCustomer(emp);

			if (custId < 0)
				throw new InvalidOperationException("Failed to add customer: "+cust.Email);

			if (custId != expectedId)
				throw new InvalidOperationException("Unexpected employee ID when adding customer: "+cust.Email);
		}
		/// <summary>Setup the baseline Customer records and their associated Payments</summary>
		void SetupCustomers()
		{
			// create a fake Sales so we can both use and test its interface for adding customers
			var fakeSales = new Employees.Sales();
			// temporary customer object used to hold the data we'll be adding to the customers table
			var cust = new Customers.Customer();
			// the expected ID of the next customer we're adding. DB Identity starts at 1, so we do as well
			int custExpectedId = 1;

			cust.PaymentId = -1; // TODO: Customer constructor should initialize IDs to -1
			cust.FirstName = "WSC";
			cust.LastName = "Customer";
			cust.Email = "customer@wsc.com";
			cust.Address = "1234 DeVry Stinks Road";
			cust.City = "College";
			cust.State = "CT";
			cust.ZipCode = "06883";
			cust.Phone = "203-555-1234";
			// TODO: uncomment once the Sales API if ready to be tested/working
			//AddAndVerifyNewCustomer(fakeSales, cust, custExpectedId++);
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