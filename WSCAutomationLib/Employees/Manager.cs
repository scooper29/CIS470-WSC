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

		public bool ValidateOrder(Orders.Order ord)
		{
            // creates instance of the DBManager
            var dbm = Database.DatabaseManager.Instance;

            // call make the change in the DB
			bool success = dbm.DBEditOrder(ord);

			if (success)
				SendNotification("wscspec60683@gmail.com", this.Email,
					"Order has been assigned to you", "Order #" + ord.Id + " has been assigned to Specialist #" + ord.SpecialistId);

			return success;
		}

		public int PerformQualityCheck(int orderId, Orders.QualityCheckList check)
		{
            if (check.Pass)
            {
				SendNotification("showandy@gmail.com", this.Email, "Order Finished", "Your order #" + orderId + " is finished and is ready to be shipped or picked up.");
				SendNotification("wscsales60683@gmail.com", this.Email, "Close Order", "Please close Order #" + orderId);
            }
            else
            {
				SendNotification("wscspec60683@gmail.com", this.Email, "Order Failed Quality Check", "Order #" + orderId + " that you worked on did not pass the quality check.");
            }

            return Database.DatabaseManager.Instance.DBAddQualityCheckList(check);
		}

        public bool ReevaluateQualityCheck(int orderId, Orders.QualityCheckList check)
        {
            if (check.Pass)
            {
				SendNotification("showandy@gmail.com", this.Email, "Order Finished", "Your order " + orderId + " is finished and is ready to be shipped or picked up.");
				SendNotification("wscsales60683@gmail.com", this.Email, "Close Order", "Please close Order #" + orderId);
            }
            else
            {
				SendNotification("wscspec60683@gmail.com", this.Email, "Order Failed Quality Check", "Order #" + orderId + " that you worked on did not pass the quality check, again.");
            }

            return Database.DatabaseManager.Instance.DBEditQualityChecklist(check);
        }
	};
}