using System;

namespace WSCAutomation.Inventory
{
    public class Inventory
    {
        public int InventoryID { get; set; }
        public string ItemName { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }

        public Inventory()
        {
        }

    }
}