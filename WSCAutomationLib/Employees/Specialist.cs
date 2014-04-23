using System;
using System.Collections.Generic;

namespace WSCAutomation.Employees
{
	public sealed class Specialist : Employee
	{
		public Specialist()
		{
		}

		public bool RequestInstockInventory(Inventory.Inventory inv, int specialistId)
        {
            // creates instance of the DBManager
            var dbm = Database.DatabaseManager.Instance;

            // increases the qty sold field
            inv.QtySold += 1;
            
            // returns true of the edit is successful
            bool success = dbm.DBEditInventory(inv);

			if (success)
			{
				string body = "Inventory item #" + inv.Id + " is in stock, please pull from shelf for Specialist #" + specialistId;
				SendNotification("wscclerk60683@gmail.com", this.Email, "In stock inventory requested", body);
			}

			return success;
        }

        public void RequestOutofstockInventory(Inventory.Inventory invIn)
        {
            string body = "Inventory item " + invIn.Id + " is out of stock, please order more.";
            SendNotification("wscclerk60683@gmail.com", this.Email, "Out of stock inventory needed", body);
        }

        public bool MarkOrderComplete(Orders.Order order, int specialistId)
        {
			order.Complete = true;

            bool success = UpdateOrder(order);

			if (success)
			{
				string body = string.Format("Specialist #{0} has marked Order #{1} as complete",
					specialistId, order.Id);
				SendNotification("wscman60683@gmail.com", this.Email, "Order Complete", body);
			}

			return success;
        }
	};
}