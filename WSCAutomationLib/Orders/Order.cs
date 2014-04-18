﻿using System;

namespace WSCAutomation.Orders
{
	public class Order
	{
		public int orderId { get; set; }

		public int SalesId { get; set; }
		public int SpecialistId { get; set; }
		public int CustomerId { get; set; }
		public int InventoryId { get; set; }
        public int EmployeeID { get; set; }

		public string Type { get; set; }
		public int CatalogNumber { get; set; }

		public string Message { get; set; }
		public string InvalidMemo { get; set; }

		public bool Paid { get; set; }
		public bool Validated { get; set; }
		public bool Complete { get; set; }
		public bool Closed { get; set; }

		public Order()
		{
		}
	};
}