using System;
using System.Collections.Generic;

namespace WSCAutomation.Employees
{
	public sealed class Admin : Employee
	{
		public Admin()
		{
		}

		public override List<Inventory.Inventory> CheckInventory(int inventoryIDIn, string mfgNameIn, string itemNameIn)
		{
			throw new InvalidOperationException(
				"Admins can't check inventory");
		}

		public override void CheckOrder()
		{
			throw new InvalidOperationException(
				"Admins can't check orders");
		}

		public bool UserNameAlreadyTaken(string userName)
		{
			var dbm = Database.DatabaseManager.Instance;

			var existingUser = dbm.DBGetEmployees(userId: userName);

			return existingUser.Count != 0;
		}

		public int AddEmployee(Employee emp)
		{
			var dbm = Database.DatabaseManager.Instance;

			// verify no other employees with the same user name exist
			if (UserNameAlreadyTaken(emp.UserName))
			{
				// we found an existing employee in the DB with a matching user name
				// set the employee ID to be 'invalid' and return it so callers of this
				// method know the add operation failed
				emp.Id = -1;
				return emp.Id;
			}

			// no other employee has the same user name, so go ahead and add the
			// employee to the DB and return its new, valid ID
			return dbm.DBAddEmployee(emp);
		}

		public bool EditEmployee(Employee emp)
		{
			var dbm = Database.DatabaseManager.Instance;

			// TODO: if we allow the user name to be changed in the UI, then we'll want
			// to verify here or there that no other user exists with the same user name

			// run the UPDATE operation and return whether it was successful or not
			return dbm.DBEditEmployee(emp);
		}


	};
}