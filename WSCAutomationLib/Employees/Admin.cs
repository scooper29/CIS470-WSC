using System;

namespace WSCAutomation.Employees
{
	public sealed class Admin : Employee
	{
		public Admin()
		{
		}

		public override void CheckInventory()
		{
			throw new InvalidOperationException(
				"Admins can't check inventory");
		}

		public virtual void CheckOrder()
		{
			throw new InvalidOperationException(
				"Admins can't check orders");
		}

		public void AddEmployee(Employee employee)
		{
		}

		public void EditEmployee()
		{
		}
	};
}