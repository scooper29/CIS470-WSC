﻿using System;

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

		public virtual void CheckInventory()
		{
            // recieve inventory information from UI
            try
            {
                // if passed check value, search all and return all results
                // else call to DBCheckInventory(itemID, itemName, manufacturerName)
                // return list of objects to UI (Inventory is quantity - qtySold)
                // if nothing found, send check value to imply nothing found???
            }
            catch (Exception ex)
            {
                // do somthing here to alert user to error MessagoBox.Show()???
            }
		}

		public virtual void CheckOrder()
		{
		}

		protected void SendNotification()
		{
		}

		/// <summary>
		/// Do to the fact we don't use controllers for employee operations, but instead use
		/// child classes of Employee, our DBGetEmployees function needs a way to create
		/// the specific Employee subclass based on the AccessCodeID value in the Employee record
		/// </summary>
		/// <param name="access"></param>
		/// <returns>An instance of the Employee subclass associated with the given access</returns>
		internal static Employee Create(AccessCode access)
		{
			Employee emp;

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
			var dbm = new Database.DatabaseManager();

			// try and find the employee using the provided username
			var employees = dbm.DBGetEmployees(userId: userName);

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
	};
}