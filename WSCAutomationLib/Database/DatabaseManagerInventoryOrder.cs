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
        const string INVENTORYORDER_TABLE = "InvOrder";

		const string INVENTORYORDER_ID = "InvOrderID";
		const string INVENTORYORDER_INV_ID = "InventoryID";
        const string INVENTORYORDER_QUANTITY = "InvOrdQty";
        const string INVENTORYORDER_COMPLETED = "InvOrd_Completed";
        const string INVENTORYORDER_ORDERDATE = "InvOrd_Date";
		const string INVENTORYORDER_ARRIVALDATE = "InvOrd_Delivery";
        #endregion

        static SqlCeCommand BuildModificationQuery(SqlCeConnection connection, ModificationQueryType type,
            InventoryOrder invOrder)
        {
            var query = new ModificationQueryBuilder(connection, type, INVENTORYORDER_TABLE);

            query.AddParameter(INVENTORYORDER_ID, "invOrderId", invOrder.InventoryId);

			query.AddParameter(INVENTORYORDER_INV_ID, "invId", invOrder.InventoryId);
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
		public int DBAddInventoryOrder(InventoryOrder invOrder)
		{
            object idObj = PerformModificationQuery(ModificationQueryType.Insert, invOrder);

			if (idObj != null)
            {
				invOrder.Id = Convert.ToInt32(idObj);

                return invOrder.Id;
            }

            return -1;
		}

		public bool DBEditInventoryOrder(InventoryOrder invOrder)
		{
            var rowsAffected = (int)PerformModificationQuery(ModificationQueryType.Update, invOrder);

            return rowsAffected == 1;
		}

        public List<InventoryOrder> DBGetInventoryOrder(int invOrderId = -1)
        {
			VerifySearchParameter(invOrderId, "invOrderId");

            var results = new List<InventoryOrder>();

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                // create a SELECT query builder for the Customertable
				var command = new SelectQueryBuilder(connection, INVENTORYORDER_TABLE);

				if (!SkipSearchParameter(invOrderId))
					command.AddParameter(INVENTORYORDER_ID, "invOrderId", invOrderId);

                using (var reader = command.ToDbCommand().ExecuteReader())
                {
                    // each Read() fetches the next record that matches our SELECT query
                    // build our code object from each record and add it to the list of results
                    while (reader.Read())
                    {
                        InventoryOrder invOrder = new InventoryOrder();

                        invOrder.Id = (int)reader[INVENTORYORDER_ID];
						invOrder.InventoryId = (int)reader[INVENTORYORDER_INV_ID];
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