using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace WSCAutomation.Database
{
    using Inventory;

	partial class DatabaseManager
	{
        #region Inventory table column names
        const string INVENTORYORDER_TABLE = "Inventory Order";

        const string INVENTORYORDER_ID = "InventoryOrder_ID";
        const string INVENTORYORDER_QUANTITY = "InvOrder_Quantity";
        const string INVENTORYORDER_COMPLETED = "InvOrder_Completed";
        const string INVENTORYORDER_ORDERDATE = "InvOrder_OrderDate";
        const string INVENTORYORDER_ARRIVALDATE = "InvOrder_ArrivalDate";
        #endregion

        static SqlCeCommand BuildModificationQuery(SqlCeConnection connection, ModificationQueryType type,
            InventoryOrder invOrder)
        {
            var query = new ModificationQueryBuilder(connection, type, INVENTORYORDER_TABLE);

            query.AddParameter(INVENTORYORDER_ID, "invOrderId", invOrder.InventoryId);

            query.AddParameter(INVENTORYORDER_QUANTITY, "Quantity", invOrder.Quantity);
            query.AddParameter(INVENTORYORDER_COMPLETED, "Completed", invOrder.Completed);
            query.AddParameter(INVENTORYORDER_ORDERDATE, "OrderDate", invOrder.OrderDate);
            query.AddParameter(INVENTORYORDER_ARRIVALDATE, "ArrivalDate", invOrder.ArrivalDate);

            return query.ToDbCommand();
        }

        object PerformModificationQuery(ModificationQueryType type, InventoryOrder invOrder)
        {
            object result = null;

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                var command = BuildModificationQuery(connection, type, invOrder);

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
		public int DBAddInventory(InventoryOrder invOrder)
		{
            object Obj = PerformModificationQuery(ModificationQueryType.Insert, invOrder);

            if (Obj != null)
            {
                invOrder.InventoryId = Convert.ToInt32(Obj);

                return invOrder.InventoryId;
            }

            return -1;
		}

		public bool DBEditInventory(InventoryOrder invOrder)
		{
            var rowsAffected = (int)PerformModificationQuery(ModificationQueryType.Update, invOrder);

            return rowsAffected == 1;
		}

        public List<InventoryOrder> DBGetInventoryOrder(string invOrder_InventoryId, string invOrder_Quantity, string invOrder_Completed, string invOrder_OrderDate, string invOrder_ArrivalDate = "")
        {
            VerifySearchParameter(invOrder_InventoryId, "invOrder_InventoryId");
            VerifySearchParameter(invOrder_Quantity, "invOrder_Quantity");
            VerifySearchParameter(invOrder_Completed, "invOrder_Completed");
            VerifySearchParameter(invOrder_OrderDate, "invOrder_OrderDate");
            VerifySearchParameter(invOrder_ArrivalDate, "invOrder_ArrivalDate");

            var results = new List<InventoryOrder>();

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                // create a SELECT query builder for the Customertable
                var command = new SelectQueryBuilder(connection, CUSTOMER_TABLE);

                // Add inventoryOrderId parameter
                if (!SkipSearchParameter(invOrder_InventoryId))
                    command.AddParameter(INVENTORYORDER_ID, "invOrder_InventoryId", invOrder_InventoryId);

                // Add INVENTORY ORDER QUANTITY parameter
                if (!SkipSearchParameter(invOrder_Quantity))
                    command.AddParameter(INVENTORYORDER_QUANTITY, "invOrder_Quantity", invOrder_Quantity);

                // Add INVENTORY Order Cmplete parameter
                if (!SkipSearchParameter(invOrder_Completed))
                    command.AddParameter(INVENTORYORDER_COMPLETED, "invOrder_Completed", invOrder_Completed);

                // Add INVENTORY ORDER DATE parameter
                if (!SkipSearchParameter(invOrder_OrderDate))
                    command.AddParameter(INVENTORYORDER_ORDERDATE, "invOrder_OrderDate", invOrder_OrderDate);

                using (var reader = command.ToDbCommand().ExecuteReader())
                {
                    // each Read() fetches the next record that matches our SELECT query
                    // build our code object from each record and add it to the list of results
                    while (reader.Read())
                    {
                        InventoryOrder invOrder = new InventoryOrder();

                        invOrder.InventoryId = (int)reader[INVENTORYORDER_ID];
                        invOrder.Quantity = (int)reader[INVENTORYORDER_QUANTITY];
                        invOrder.Completed = (bool)reader[INVENTORYORDER_COMPLETED];
                        invOrder.OrderDate = (DateTime)reader[INVENTORYORDER_ORDERDATE];
                        invOrder.ArrivalDate = (DateTime)reader[INVENTORYORDER_ARRIVALDATE];

                        results.Add(invOrder);
                    }
                }
            }

            return results;

        }

		
	};
}