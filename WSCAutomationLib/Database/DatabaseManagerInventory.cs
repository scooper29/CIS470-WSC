using System;

namespace WSCAutomation.Database
{
	// TODO: DatabaseManager methods relating to the Inventory tables should go here

	partial class DatabaseManager
	{
        public void DBAddInventory(string item, string manufacturer, int quantity)
		{
            string stringCommand = "INSERT INTO Inventory (In_Name,In_Manufacturer, In_Quantity) VALUES (\'" + item + "\',\'" + manufacturer + "\'," + quantity + ");";
            OleDBConnection conn = DBgetConnection();
            try
            {
                OleDbCommand command = new OleDbCommand(stringCommand, conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                conn.Open();
                adapter.InsertCommand = command;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to write data to the database.\n{0}", ex.Message);
                return;
            }
            finally
            {
                conn.Close();
            }
		}

		public void DBEditInventory()
		{
		}

		public void DBGetInventory()
		{
            string stringCommand = "SELECT * FROM Inventory";
            OleDBConnection conn = DBgetConnection();
            try
            {
                OleDbCommand command = new OleDbCommand(stringCommand, conn);
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                conn.Open();
                adapter.Fill(data, "Inventory");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: Failed to retrieve data to the database.\n{0}", ex.Message);
                return;
            }
            finally
            {
                conn.Close();
            }
		}

		public void DBAddInventoryOrder()
		{
		}

		public void DBEditInventoryOrder()
		{
		}

		public void DBGetInventoryOrders()
		{
		}
	};
}