using System;

namespace WSCAutomation.Employees
{
	public sealed class Specialist : Employee
	{
		public Specialist()
		{
		}

        public bool RequestInventory(int invIDIn)
        {
            // creates instance of the DBManager
            var dbm = Database.DatabaseManager.Instance;

            // returns results from DBGetInventory
            var results = dbm.DBGetInventory(inventoryID: invIDIn);

            // this throws an excpetion if more or less that 1 result is returned
            // should never happen here
            if (results.Count != 1)
            {
                throw new InvalidOperationException("Unexpected inventory results");
            }

            // creates inv object from the returned list (only one)
            var inv = results[0];

            // increases the qty sold field
            inv.QtySold += 1;

            // returns true of the edit is successful
            return dbm.DBEditInventory(inv);
        }

        public void MarkOrderComplete(Orders.Order order, bool complete)
        {
            UpdateOrder(order.Id, true);
            
            SendNotification("wscman60683@gmail.com", this.Email, "Order Complete", "[THIS ORDER] has been completed.");
        }
        
        public void ReviewQualityCheck()
		{
		}
	};
}