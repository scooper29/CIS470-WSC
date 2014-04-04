using System;

namespace WSCAutomation.Inventory
{
    public class Inventory
    {
        public int inventoryID;
        public string itemName;
        public int quantity;

        public Inventory()
        {
        }

        // This is for searching by ID and will create an object from database returned results
        // Not sure of we need this...
        public Inventory(int inventoryIDIn)
        {
            inventoryID = inventoryIDIn;
            // TODO Call to database to determine matching ID, return results into local variables
            // itemName = return from database query
            // quantity = return from database query
        }

        // This constructor is for creating an object from database results when searched from itemName
        // Again, not sure we'll need this...
        public Inventory(string itemNameIn)
        {
            itemName = itemNameIn;
            // TODO Call to database to search inventory by Item Name
            // inventoryID = return from database query
            // quantity = return from database query
        }

        public Inventory(int inventoryIDIn, string itemNameIn, int quantityIn)
        {
            inventoryID = inventoryIDIn;
            itemName = itemNameIn;
            quantityIn = quantity;
        }
    }
}