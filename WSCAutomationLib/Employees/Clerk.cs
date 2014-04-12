using System;

namespace WSCAutomation.Employees
{
	public sealed class Clerk : Employee
	{
		public Clerk()
		{
		}

        public void AddInventory()
        {
            //recieve inventory parameters from UI
            try
            {
                // call DBGetInventory() to search for existing item
                // if (returned results == 0)
                //    call DBAddInventory(parameters here) to add inventory
                // if (returned results == item found)
                //    call DBUpdateInventory(parameters here) and add to quantity
                //    of existing table entry
            }
            catch (Exception ex)
            {
                // Display message box of error???
            }
        }
	};
}