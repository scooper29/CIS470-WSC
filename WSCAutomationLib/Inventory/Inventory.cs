using System;

namespace WSCAutomation.Inventory
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Manufacturer { get; set; }
        public int Quantity { get; set; }
        public int QtySold { get; set; }

        public Inventory()
        {
			Id = -1;

			Name = Manufacturer =
				"";
        }
    };
}