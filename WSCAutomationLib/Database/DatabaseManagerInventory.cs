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
        const string INVENTORY_TABLE = "Inventory";

        const string INVENTORY_ID = "InventoryID";
        const string INVENTORY_NAME = "Inv_Name";
        const string INVENTORY_MANUFACTURER = "Inv_Manufacturer";
        const string INVENTORY_QUANTITY = "Inv_Quantity";
        const string INVENTORY_QTYSOLD = "Inv_QtySold";
        #endregion

        static SqlCeCommand BuildModificationQuery(SqlCeConnection connection, ModificationQueryType type,
            Inventory inv)
        {
            var query = new ModificationQueryBuilder(connection, type, INVENTORY_TABLE);

            query.AddIdParameter(INVENTORY_ID, "invId", inv.InventoryID);

            query.AddParameter(INVENTORY_NAME, "invName", inv.Name);
            query.AddParameter(INVENTORY_MANUFACTURER, "manufacturerName", inv.Manufacturer);
            query.AddParameter(INVENTORY_QUANTITY, "quantity", inv.Quantity);
            query.AddParameter(INVENTORY_QTYSOLD, "qtySold", inv.QtySold);

            return query.ToDbCommand();
        }

        object PerformModificationQuery(ModificationQueryType type, Inventory inv)
        {
            object result = null;

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                var command = BuildModificationQuery(connection, type, inv);

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

        public int DBAddInventory(Inventory inv)
		{
            object Obj = PerformModificationQuery(ModificationQueryType.Insert, inv);

            if (Obj != null)
            {
                inv.InventoryID = Convert.ToInt32(Obj);

                return inv.InventoryID;
            }

            return -1;
		}

		public bool DBEditInventory(Inventory inv)
		{
            var rowsAffected = (int)PerformModificationQuery(ModificationQueryType.Update, inv);

            return rowsAffected == 1;
		}

		public List<Inventory> DBGetInventory(string inv_invname, string inv_manufacturer = "")
		{
            VerifySearchParameter(inv_invname, "inv_name");
            VerifySearchParameter(inv_manufacturer, "inv_manufacturer");

            var results = new List<Inventory>();

            // open a connection to the SQL DB
            using (var connection = OpenConnection())
            {
                // create a SELECT query builder for the Employee table
                var command = new SelectQueryBuilder(connection, CUSTOMER_TABLE);

                // Add employeeId parameter
                if (!SkipSearchParameter(inv_invname))
                    command.AddParameter(INVENTORY_NAME, "inv_name", inv_invname);

                // Add userId parameter
                if (!SkipSearchParameter(inv_manufacturer))
                    command.AddParameter(INVENTORY_MANUFACTURER, "inv_manufacturer", inv_manufacturer);

                using (var reader = command.ToDbCommand().ExecuteReader())
                {
                    // each Read() fetches the next record that matches our SELECT query
                    // build our code object from each record and add it to the list of results
                    while (reader.Read())
                    {
                        Inventory inv = new Inventory();

                        inv.InventoryID = (int)reader[INVENTORY_ID];
                        inv.Name = (string)reader[INVENTORY_NAME];
                        inv.Manufacturer = (string)reader[INVENTORY_MANUFACTURER];
                        inv.Quantity = (int)reader[INVENTORY_QUANTITY];
                        inv.QtySold = (int)reader[INVENTORY_QTYSOLD];

                        results.Add(inv);
                    }
                }
            }

            return results;
		}
	};
}