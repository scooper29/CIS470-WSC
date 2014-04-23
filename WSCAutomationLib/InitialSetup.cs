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

		Employees.Employee GetEmployee(string userName)
		{
			var dbm = Database.DatabaseManager.Instance;

			var employees = dbm.DBGetEmployees(userId: userName, asEmployeeObjectsOnly: false);

			if (employees.Count == 0)
				throw new ArgumentException("failed to find employee: " + userName);

			return employees[0];
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

		void AddAndVerifyNewOrder(Employees.Sales fakeSales,
			Orders.Order order, int expectedId)
		{
			int orderId = fakeSales.AddOrder(order);

			if (orderId < 0)
				throw new InvalidOperationException("Failed to add order");

			if (orderId != expectedId)
				throw new InvalidOperationException("Unexpected order ID when adding customer" );
		}
		void AddAndVerifyNewQualityCheckList(Employees.Manager fakeManager,
			Orders.Order order, Orders.QualityCheckList quality)
		{
			int qualityId = fakeManager.PerformQualityCheck(order.Id, quality);

			if (qualityId < 0)
				throw new InvalidOperationException("Failed to add quality checklist");

			order.QualityId = qualityId;

			bool success = fakeManager.UpdateOrder(order);

			if (!success)
				throw new InvalidOperationException("Failed to update order with new quality checklist");
		}
		void SetupOrders()
		{
			var fakeSales = (Employees.Sales)GetEmployee("chris");
			var fakeManager = (Employees.Manager)GetEmployee("jon");
			// temporary order object used to hold the data we'll be adding to the order table
			Orders.Order order;
			Orders.QualityCheckList quality;
			// the expected ID of the next order we're adding. DB Identity starts at 1, so we do as well
			int orderExpectedId = 1;

			const int SALES_ID = 7; // chris
			const int SPECIALIST_ID = 6; // sean
			const int CUSTOMER_ID = 2;
			const int INVENTORY_ID = 1;

			order = new Orders.Order
			{
				SalesId = SALES_ID,
				SpecialistId = SPECIALIST_ID,
				CustomerId = CUSTOMER_ID,
				InventoryId = INVENTORY_ID,

				Message = "#YOLO",

				PaidUpFront = true,
				Paid = true,
				Validated = true,
			};
			AddAndVerifyNewOrder(fakeSales, order, orderExpectedId++);

			quality = new Orders.QualityCheckList
			{
				Pass = false,
				Description = "You're fired.",
			};
			AddAndVerifyNewQualityCheckList(fakeManager, order, quality);
		}

		/// <summary>Perform all the initial setup steps</summary>
		public void Perform()
		{
#if false // Ryan already setup this data in the DB
			if (!dbm.InitializeAccessCodes())
				throw new Exception("Failed to initialize AccessCode table");

			SetupEmployees();
			SetupCustomers();
			SetupInventory();
#endif
			SetupOrders();
		}
	};
}