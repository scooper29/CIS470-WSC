using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace WSCAutomation.Database 
{
    using Orders;
	// TODO: DatabaseManager methods relating to the Orders tables should go here

	partial class DatabaseManager
	{
        #region Inventory table column names
        const string ORDER_TABLE = "Order";

        const string ORDER_ORDER_ID = "order_orderId";
	    //const string ORDER_SALES_ID = "order_SalesId";
	    const string ORDER_EMPLOYEE_ID = "order_EmpId"; 
        // const string ORDER_SPECLIST_ID = "order_SpeclistId";
        const string ORDER_CUST_ID = "order_CustId";
        const string ORDER_INVENTORY_ID = "order_InvId";
        const string ORDER_TYPE = "order_Type";
	    const string ORDER_CATALOG_NUM = "order_CatlogNum";
        const string ORDER_MESSAGE = "order_Message";
        const string ORDER_INVALID_MEMO = "order_InvalMemo";
        const string ORDER_PAID = "order_Paid";
        const string ORDER_VALIDATED = "order_Validated";
	    const string ORDER_COMPLETE = "0order_Complete";
        const string ORDER_CLOSED = "order_Closed";
        #endregion

        static SqlCeCommand BuildModificationQuery(SqlCeConnection connection, ModificationQueryType type, Order order)
        {
            var query = new ModificationQueryBuilder(connection, type, ORDER_TABLE);

            query.AddParameter(ORDER_ORDER_ID, "OrderId", order.Id);

			// TODO: get with Ryan and figure out the column names for the Order's sales and specialist IDs and update this code
	        //query.AddParameter(ORDER_SALES_ID, "SalesId", order.SalesId );
	        query.AddParameter(ORDER_EMPLOYEE_ID, "EmployeeId", order.SpecialistId);
            // query.AddParameter(ORDER_SPECLIST_ID, "SpecialistId", order.SpecialistId );
            query.AddParameter(ORDER_CUST_ID, "CustomerId", order.CustomerId );
            query.AddParameter(ORDER_INVENTORY_ID, "InventoryId", order.InventoryId );
            query.AddParameter(ORDER_TYPE, "Type", order.Type);
	        query.AddParameter(ORDER_CATALOG_NUM, "CatalogNumber", order.CatalogNumber);
            query.AddParameter(ORDER_MESSAGE, "Message", order.Message);
            query.AddParameter(ORDER_INVALID_MEMO, "InvalidMemo", order.InvalidMemo);
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
            //Replace with actual id to be returned
            //This is just a place holder to actually return a value for program to compile
            object Obj = PerformModificationQuery(ModificationQueryType.Insert, order);

            if (Obj != null)
            {
                order.Id = Convert.ToInt32(Obj);

                return order.Id;
            }
            return -1;
		}

		public bool DBEditOrder(Order order)
		{
            var rowsAffected = (int)PerformModificationQuery(ModificationQueryType.Update, order);

            return rowsAffected == 1;
		}

		public List<Order> DBGetOrders(int orderID = -1, int order_SalesId = -1, int order_EmpId = -1, int specialistId = -1, int customerId = -1, int order_InventoryId = -1,
            string order_Type = "", int order_CatalogNumber = -1, string order_Message = "", string order_InvalidMemo = "")
        {
			VerifySearchParameter(orderID, "orderID");
            //VerifySearchParameter(order_SalesId, "order_salesId");
            VerifySearchParameter(order_EmpId, "order_empId");
			//VerifySearchParameter(specialistId, "specialistId");
			VerifySearchParameter(customerId, "customerId");
            VerifySearchParameter(order_InventoryId, "order_inventoryId");
            VerifySearchParameter(order_Type, "order_type");
            VerifySearchParameter(order_CatalogNumber, "order_catalogNumber");
            VerifySearchParameter(order_Message, "order_message");
            VerifySearchParameter(order_InvalidMemo, "order_invalidMemo");

            var results = new List<Order>();

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                // create a SELECT query builder for the Customertable
                var command = new SelectQueryBuilder(connection, ORDER_TABLE);

                // Add OrderId parameter
				if (!SkipSearchParameter(orderID))
					command.AddParameter(ORDER_ORDER_ID, "orderID", orderID);

                // Add INVENTORY ORDER QUANTITY parameter
                if (!SkipSearchParameter(order_EmpId))
                    command.AddParameter(ORDER_EMPLOYEE_ID, "order_empId", order_EmpId);

                // Add INVENTORY Order Cmplete parameter
				if (!SkipSearchParameter(customerId))
					command.AddParameter(ORDER_CUST_ID, "customerId", customerId);

                // Add INVENTORY ORDER DATE parameter
                if (!SkipSearchParameter(order_InventoryId))
                    command.AddParameter(ORDER_INVENTORY_ID, "order_InventoryId", order_InventoryId);

                // Add OrderId parameter
                if (!SkipSearchParameter(order_Type))
                    command.AddParameter(ORDER_TYPE, "order_Type", order_Type);

                // Add INVENTORY ORDER QUANTITY parameter
                if (!SkipSearchParameter(order_CatalogNumber))
                    command.AddParameter(ORDER_CATALOG_NUM, "order_CatalogNumber", order_CatalogNumber);

                // Add INVENTORY Order Cmplete parameter
                if (!SkipSearchParameter(order_Message))
                    command.AddParameter(ORDER_MESSAGE, "order_Message", order_Message);

                // Add INVENTORY ORDER DATE parameter
                if (!SkipSearchParameter(order_InvalidMemo))
                    command.AddParameter(ORDER_INVALID_MEMO, "order_InvalidMemo", order_InvalidMemo);

                using (var reader = command.ToDbCommand().ExecuteReader())
                {
                    // each Read() fetches the next record that matches our SELECT query
                    // build our code object from each record and add it to the list of results
                    while (reader.Read())
                    {
                        Order order = new Order();

                        order.Id = (int)reader[ORDER_ORDER_ID];
						// TODO: get with Ryan and figure out the column names for the Order's sales and specialist IDs and update this code
                        order.SpecialistId = (int)reader[ORDER_EMPLOYEE_ID];
                        order.CustomerId = (int)reader[ORDER_CUST_ID];
                        order.InventoryId = (int)reader[ORDER_INVENTORY_ID];
                        order.Type = (string)reader[ORDER_TYPE];
                        order.CatalogNumber = (int)reader[ORDER_CATALOG_NUM];
                        order.Message = (string)reader[ORDER_MESSAGE];
                        order.CustomerId = (int)reader[ORDER_CUST_ID];
                        order.InvalidMemo = (string)reader[ORDER_INVALID_MEMO];


                        results.Add(order);
                    }
                }
            }

            return results;
        }
	};
}