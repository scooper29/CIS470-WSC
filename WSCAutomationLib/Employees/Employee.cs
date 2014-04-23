using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;

namespace WSCAutomation.Employees
{
	public class Employee
	{
		public int Id { get; set; }
		public AccessCode Access { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }

		public string UserName { get; set; }
		public string Password { get; set; }

		public Employee()
		{
			Id = -1;
			Access = AccessCode.None;

			FirstName = LastName = Email = UserName = Password =
				"";
		}

        // Returns a list of inventory objects of inventory items from DB
        public virtual List<Inventory.Inventory> CheckInventory(int inventoryIDIn = -1, string mfgNameIn = "", string itemNameIn = "")
        {
            return Database.DatabaseManager.Instance.DBGetInventory(itemNameIn, inventoryIDIn, mfgNameIn);
        }


		public virtual List<Orders.Order> CheckOrder(int orderId, int customerId, int specialistId)
		{
			return Database.DatabaseManager.Instance.DBGetOrders(orderID: orderId, customerId: customerId, specialistId: specialistId);
		}

		public List<Employee> GetEmployees(int employeeId = -1, string userName = "")
		{
			var dbm = Database.DatabaseManager.Instance;

			return dbm.DBGetEmployees(employeeId, userName);
		}

		public List<Customers.Customer> GetCustomers(int customerId = -1, string lastName = "")
		{
			var dbm = Database.DatabaseManager.Instance;

			return dbm.DBGetCustomers(customerId, lastName);
		}

		public List<Orders.QualityCheckList> GetQualityCheckLists(int qualityId = -1)
		{
			var dbm = Database.DatabaseManager.Instance;

			return dbm.DBGetQualityCheckList(qualityId);
		}

		public List<Customers.Payment> GetPayments(int paymentId = -1)
		{
			var dbm = Database.DatabaseManager.Instance;

			return dbm.DBGetPayments(paymentId);
		}
        
        protected void SendNotification(string toAddress, string fromAddress, string subject, string bodyMessage)
        {
			System.Diagnostics.Debug.WriteLine(
				"{0}\n" +
				"\tTo   {1}\n" +
				"\tFrom {2}\n" +
				"\t\t{3}\n\n",
				subject, toAddress, fromAddress, bodyMessage);

			// This is our constant password for our project
            const string emailPassword = "senprojCIS470";

            // This composes the email dependent on input
            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(fromAddress);
            mail.To.Add(toAddress);
            mail.Subject = subject;
            mail.Body = bodyMessage;

            // Configures server
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential(fromAddress, emailPassword);
            SmtpServer.EnableSsl = true;

            // Send the email
            SmtpServer.Send(mail);
        }
		/// <summary>
		/// Do to the fact we don't use controllers for employee operations, but instead use
		/// child classes of Employee, our DBGetEmployees function needs a way to create
		/// the specific Employee subclass based on the AccessCodeID value in the Employee record
		/// </summary>
		/// <param name="access"></param>
		/// <param name="asEmployeeObjectsOnly">
		/// If true, will create as instances of Employee only, not any of the subclasses. Required in order to bind Employee objects to a DataGrid</param>
		/// <returns>An instance of the Employee subclass associated with the given access</returns>
		internal static Employee Create(AccessCode access, bool asEmployeeObjectsOnly)
		{
			Employee emp = asEmployeeObjectsOnly
				? new Employee()
				: null;

			if (!asEmployeeObjectsOnly)
				switch (access)
				{
					case AccessCode.Admin:
						emp = new Admin();
						break;

					case AccessCode.Manager:
						emp = new Manager();
						break;

					case AccessCode.Sales:
						emp = new Sales();
						break;

					case AccessCode.Specialist:
						emp = new Specialist();
						break;

					case AccessCode.StockClerk:
						emp = new Clerk();
						break;

					default:
						throw new InvalidOperationException(access.ToString());
				}

			emp.Access = access;
			return emp;
		}

		/// <summary>Try to authenticate the user based on a name and password</summary>
		/// <param name="userName">Username the user provided</param>
		/// <param name="password">Password the user provided</param>
		/// <returns>A fully functioning Employee-based object if the username and password match the Employee record. Otherwise, null</returns>
		public static Employee TryLogin(string userName, string password)
		{
			var dbm = Database.DatabaseManager.Instance;

			// try and find the employee using the provided username
			// The employees need to instances of our Employee subclasses since that's where we put all of the business logic for them...
			var employees = dbm.DBGetEmployees(userId: userName, asEmployeeObjectsOnly: false);

			Employee validEmp = null;
			// There should only be one employee with the given username
			if (employees.Count == 1)
			{
				validEmp = employees[0];

				// if the passwords don't match, then set to null to signal failure
				// TODO: if we ever change the way passwords are stored (ie, not plain text), this code will need to be updated
				if (password != validEmp.Password)
					validEmp = null;
			}

			return validEmp;
		}

		public bool UpdateOrder(Orders.Order ord)
		{
			// creates instance of the DBManager
			var dbm = Database.DatabaseManager.Instance;

			// call make the change in the DB
			return dbm.DBEditOrder(ord);
		}
	};
}