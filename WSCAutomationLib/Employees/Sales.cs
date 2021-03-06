﻿using System;
using System.Collections.Generic;

namespace WSCAutomation.Employees
{
	public sealed class Sales : Employee
	{
		public Sales()
		{
		}

		public int AddCustomer(Customers.Customer custIn)
		{
            // returns customerID from DBAddCustomer after customer added
            return Database.DatabaseManager.Instance.DBAddCustomer(custIn);
		}

		public bool EditCustomer(Customers.Customer custIn)
		{
            // returns true of the edit is successful
            return Database.DatabaseManager.Instance.DBEditCustomer(custIn);
		}

		public int AddOrder(Orders.Order order)
		{
            var dbm = Database.DatabaseManager.Instance;

			dbm.DBAddOrder(order);

			if (order.Id != -1)
				SendNotification("wscman60683@gmail.com", this.Email, "New Order", "Order " + order.Id + " has been placed.");

			return order.Id;
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