using System;

namespace WSCAutomation.Employees
{
	public sealed class Sales : Employee
	{
		public Sales()
		{
		}

		public void AddCustomer()
		{
		}

		public void EditCustomer()
		{
		}

		public int AddOrder(Orders.Order order)
		{
            var dbm = Database.DatabaseManager.Instance;

            return dbm.DBAddOrder(order);
		}

		public bool EditOrder(Orders.Order order)
		{
            var dbm = Database.DatabaseManager.Instance;

            return dbm.DBEditOrder(order);
		}

		public int AddPayment(Customers.Payment payment)
		{
            var dbm = Database.DatabaseManager.Instance;

            return dbm.DBAddPayment(payment);
		}

		public bool EditPayment(Customers.Payment payment)
		{
            var dbm = Database.DatabaseManager.Instance;

            return dbm.DBEditPayment(payment);
		}
	};
}