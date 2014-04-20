﻿using System;
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
        public virtual List<Inventory.Inventory> CheckInventory(int inventoryIDIn, string mfgNameIn, string itemNameIn)
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
        
        protected void SendNotification(string toAddress, string fromAddress, string subject, string bodyMessage)
        {
            MailAddress to = new MailAddress(toAddress);
            MailAddress from = new MailAddress(fromAddress);
            MailMessage message = new MailMessage(from, to);
            message.Subject = subject;
            message.SubjectEncoding = System.Text.Encoding.UTF8;
            message.Body = bodyMessage;
            message.BodyEncoding = System.Text.Encoding.UTF8;
            string server;
            int port;
            server = "stmp.gmail.com";
            port = 587;
            SmtpClient smtp = new SmtpClient(server, port);
            smtp.Credentials = new System.Net.NetworkCredential(fromAddress, "senprojCIS470");
            smtp.Send(message);
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

        public void UpdateOrder(int orderID, bool complete)
        {
            // creates instance of the DBManager
            var dbm = Database.DatabaseManager.Instance;

            // returns results from DBGetInventory
            var result = dbm.DBGetOrders(orderID: orderID);

            // this throws an excpetion if more or less that 1 result is returned
            // should never happen here
            if (result.Count != 1)
            {
                throw new InvalidOperationException("Unexpected order results");
            }

            // creates inv object from the returned list (only one)
            var ord = result[0];

            // assign values to corresponding attributes of the order object
            ord.Complete = complete;

            // call make the change in the DB
            dbm.DBEditOrder(ord);
        }
	};
}