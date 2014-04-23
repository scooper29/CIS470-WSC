using System;
using System.Net;
using System.Net.Mail;

namespace WSCAutomation.Employees
{
	public sealed class Clerk : Employee
	{
		public Clerk()
		{
		}

        public int AddInventory(Inventory.Inventory invIn)
        {
            // returns itemID from DBAddInventory after item added
            return Database.DatabaseManager.Instance.DBAddInventory(invIn);
        }

        public bool UpdateInventory(Inventory.Inventory inv)
        {
            // returns true of the edit is successful
            return Database.DatabaseManager.Instance.DBEditInventory(inv);
        }

        //called when the specialist requests an item that is NOT in stock
        public int OrderInventory(Inventory.InventoryOrder invOrder)
        {
            SendNotification("wscspec60683@gmail.com", this.Email, "Inventory Ordered", "Inventory #" + invOrder.InventoryId + " that you requested that was not in stock has been ordered. Delivery expected: " + invOrder.ArrivalDate.ToShortDateString());
            
            return Database.DatabaseManager.Instance.DBAddInventoryOrder(invOrder);
        }

        //called when the specialist requests and item that IS in stock
        public bool PullInventory(Inventory.Inventory invIn)
        {
            // Decreases quantity on hand and quantity sold after pulling order
            invIn.QtySold -= 1;
            invIn.Quantity -= 1;

            SendNotification("wscspec60683@gmail.com", this.Email, "Inventory Pulled", "Inventory #" + invIn.Id + " that you requested has been pulled.");

            return Database.DatabaseManager.Instance.DBEditInventory(invIn);
        }
    };
}