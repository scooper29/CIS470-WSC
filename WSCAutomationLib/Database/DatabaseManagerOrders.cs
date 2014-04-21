using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace WSCAutomation.Database 
{
    using Orders;

	partial class DatabaseManager
	{
        #region Inventory table column names
        const string ORDER_TABLE = "Order";

        const string ORDER_ORDER_ID = "OrderID";
	    const string ORDER_SALES_ID = "EmployeeID";
		const string ORDER_SPECIALIST_ID = "Order_AssignedEmpID";
        const string ORDER_CUST_ID = "CustomerID";
        const string ORDER_INVENTORY_ID = "InventoryID";
        //const string ORDER_QUALITY_ID = "order_QualId";
	    const string ORDER_CATALOG_NUM = "Order_CatologNum";
        const string ORDER_MESSAGE = "Order_Message";
        const string ORDER_INVALID_MEMO = "Order_InvalidMemo";
		const string ORDER_PAID_UP_FRONT = "Order_PaidUpFront";
        const string ORDER_PAID = "Order_Paid";
        const string ORDER_VALIDATED = "Order_Validated";
	    const string ORDER_COMPLETE = "Order_Complete";
        const string ORDER_CLOSED = "Order_Closed";
        #endregion

        static SqlCeCommand BuildModificationQuery(SqlCeConnection connection, ModificationQueryType type, Order order)
        {
            var query = new ModificationQueryBuilder(connection, type, ORDER_TABLE);

			object specialistId = DBNull.Value;
			if (order.SpecialistId != -1)
				specialistId = order.SpecialistId;

            query.AddParameter(ORDER_ORDER_ID, "OrderId", order.Id);

	        query.AddParameter(ORDER_SALES_ID, "SalesId", order.SalesId );
			query.AddParameter(ORDER_SPECIALIST_ID, "SpecialistId", specialistId);
            query.AddParameter(ORDER_CUST_ID, "CustomerId", order.CustomerId);
            query.AddParameter(ORDER_INVENTORY_ID, "InventoryId", order.InventoryId);
            //query.AddParameter(ORDER_QUALITY_ID, "QualityID", order.QualityID );
	        query.AddParameter(ORDER_CATALOG_NUM, "CatalogNumber", order.CatalogNumber);
            query.AddParameter(ORDER_MESSAGE, "Message", order.Message);
            query.AddParameter(ORDER_INVALID_MEMO, "InvalidMemo", order.InvalidMemo);
			query.AddParameter(ORDER_PAID_UP_FRONT, "PaidUpFront", order.PaidUpFront);
            query.AddParameter(ORDER_PAID, "Paid", order.Paid);
  	        query.AddParameter(ORDER_VALIDATED, "Validated", order.Validated);
            query.AddParameter(ORDER_COMPLETE, "Complete", order.Complete);
            query.AddParameter(ORDER_CLOSED, "Closed", order.Closed);

            return query.ToDbCommand();
        }

        object PerformModificationQuery(ModificationQueryType type, Order order)
        {
            object result = null;

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                var command = BuildModificationQuery(connection, type, order);

                // try to perform the modification, committing it if successful
                try
                {
                    result = ExecuteModification(command, type);

                    command.Transaction.Commit();
                }
                catch (Exception ex)
                {
                    // rollback the changes before we re-throw the exception
                    command.Transaction.Rollback();

                    throw ex;
                }
            }

            return result;
        }
		public int DBAddOrder(Order order)
		{
            object idObj = PerformModificationQuery(ModificationQueryType.Insert, order);

			if (idObj != null)
            {
				order.Id = Convert.ToInt32(idObj);

                return order.Id;
            }
            return -1;
		}

		public bool DBEditOrder(Order order)
		{
            var rowsAffected = (int)PerformModificationQuery(ModificationQueryType.Update, order);

            return rowsAffected == 1;
		}

		public List<Order> DBGetOrders(int orderID = -1, int customerId = -1, int specialistId = -1)
        {
			VerifySearchParameter(orderID, "orderID");
			VerifySearchParameter(specialistId, "specialistId");
			VerifySearchParameter(customerId, "customerId");

            var results = new List<Order>();

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                // create a SELECT query builder for the Customertable
                var command = new SelectQueryBuilder(connection, ORDER_TABLE);

                // Add OrderId parameter
				if (!SkipSearchParameter(orderID))
					command.AddParameter(ORDER_ORDER_ID, "orderID", orderID);

				if (!SkipSearchParameter(specialistId))
					command.AddParameter(ORDER_SPECIALIST_ID, "specialistId", specialistId);

				if (!SkipSearchParameter(customerId))
					command.AddParameter(ORDER_CUST_ID, "customerId", customerId);

                using (var reader = command.ToDbCommand().ExecuteReader())
                {
                    // each Read() fetches the next record that matches our SELECT query
                    // build our code object from each record and add it to the list of results
                    while (reader.Read())
                    {
                        Order order = new Order();

                        order.Id = (int)reader[ORDER_ORDER_ID];
						order.SalesId = (int)reader[ORDER_SALES_ID];
                        order.CustomerId = (int)reader[ORDER_CUST_ID];
                        order.InventoryId = (int)reader[ORDER_INVENTORY_ID];
                        order.CatalogNumber = (int)reader[ORDER_CATALOG_NUM];
                        order.Message = (string)reader[ORDER_MESSAGE];
                        order.PaidUpFront = (bool)reader[ORDER_PAID_UP_FRONT];
						order.Paid = (bool)reader[ORDER_PAID];
						order.Validated = (bool)reader[ORDER_VALIDATED];
                        order.InvalidMemo = (string)reader[ORDER_INVALID_MEMO];
						order.Complete = (bool)reader[ORDER_COMPLETE];
						order.Closed = (bool)reader[ORDER_CLOSED];

						var specialistIdObj = reader[ORDER_SPECIALIST_ID];
						if (specialistIdObj is DBNull)
							order.SpecialistId = -1;
						else
							order.SpecialistId = (int)specialistIdObj;


                        results.Add(order);
                    }
                }
            }

            return results;
        }
	};
}