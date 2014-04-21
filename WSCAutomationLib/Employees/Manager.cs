using System;

namespace WSCAutomation.Employees
{
	public sealed class Manager : Employee
	{
		public Manager()
		{
		}

        public void ReviewPayment()
        {
            SendNotification("showandy@gmail.com", this.Email, "Payment Failed", "We were unable to complete your payment.  Please contact your sales representative to arrange a new payment.");
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

            SendNotification("wscspec60683@gmail.com", this.Email, "Order has been assigned to you", "Order " + ord.Id + " has been assigned to you");
		}

		public int PerformQualityCheck(Orders.QualityCheckList check)
		{
            if (check.Pass)
            {
                SendNotification("showandy@gmail.com", this.Email, "Order Finished", "Your order " + check.OrderId + " is finished and is ready to be shipped or picked up.");
                SendNotification("wscsales60683@gmail.com", this.Email, "Close Order", "Please close Order number " + check.OrderId);
            }
            else
            {
                SendNotification("wscspec60683@gmail.com", this.Email, "Order Failed Quality Check", "Order number " + check.OrderId + " that you worked on did not pass the quality check.");
            }

            return Database.DatabaseManager.Instance.DBAddQualityCheckList(check);
		}

        public bool ReevaluateQualityCheck(Orders.QualityCheckList check)
        {
            if (check.Pass)
            {
                SendNotification("showandy@gmail.com", this.Email, "Order Finished", "Your order " + check.OrderId + " is finished and is ready to be shipped or picked up.");
                SendNotification("wscsales60683@gmail.com", this.Email, "Close Order", "Please close Order number " + check.OrderId);
            }
            else
            {
                SendNotification("wscspec60683@gmail.com", this.Email, "Order Failed Quality Check", "Order number " + check.OrderId + " that you worked on did not pass the quality check, again.");
            }

            return Database.DatabaseManager.Instance.DBEditQualityChecklist(check);
        }
	};
}