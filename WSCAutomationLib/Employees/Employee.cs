using System;

namespace WSCAutomation.Employees
{
	public abstract class Employee
	{
		public int Id { get; set; }
		public int Access { get; set; }

		public string FirstName { get; set; }
		public string LastName { get; set; }
		public string Email { get; set; }

		public string UserName { get; set; }
		public string Password { get; set; }

		protected Employee()
		{
		}

		public virtual void CheckInventory()
		{
		}

		public virtual void CheckOrder()
		{
		}

		protected void SendNotification()
		{
		}
	};
}