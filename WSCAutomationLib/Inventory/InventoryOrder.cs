using System;
using System.Net;
using System.Net.Mail;

namespace WSCAutomation.Inventory
{
	public class InventoryOrder
	{
		public int Id { get; set; }

		public int InventoryId { get; set; }
		public int Quantity { get; set; }
		public bool Completed { get; set; }
		public DateTime OrderDate { get; set; }
		public DateTime ArrivalDate { get; set; }

		public InventoryOrder()
		{
			Id = InventoryId =
				-1;

			OrderDate = DateTime.Today;
			ArrivalDate = DateTime.Today.AddDays(1);
		}
	};
}