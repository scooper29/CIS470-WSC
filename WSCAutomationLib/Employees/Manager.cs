using System;

namespace WSCAutomation.Employees
{
	public sealed class Manager : Employee
	{
		public Manager()
		{
		}

		public void ValidateOrder(int orderID, bool validated, int specialistId)
		{
            // creates instance of the DBManager
            var dbm = Database.DatabaseManager.Instance;

            // returns results from DBGetInventory
            var result = dbm.DBGetOrders(orderID: orderID);

            // this throws an excpetion if more or less that 1 result is returned
            // should never happen here
            if (result.Count != 1)
            {
                throw new InvalidOperationException("Unexpected order results");
            }

            // creates inv object from the returned list (only one)
            var ord = result[0];

            // assign values to corresponding attributes of the order object
            ord.Validated = validated;
            ord.SpecialistId = specialistId;

            // call make the change in the DB
            dbm.DBEditOrder(ord);
		}

		public void PerformQualityCheck()
		{
		}

        public void UpdateOrder()
        {
            //Bring up with group
        }
	};
}