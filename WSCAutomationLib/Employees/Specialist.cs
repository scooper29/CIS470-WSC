using System;

namespace WSCAutomation.Employees
{
	public sealed class Specialist : Employee
	{
		public Specialist()
		{
		}

		public bool UpdateInventory()
		{
            // not 100% sure of return type here

            // Recieve inventory parameter(s) from UI
            try
            {
                //update inventory to reflect qty "sold" by
                //call to DBEditInventory(itemID, qtySold)
                return true;
            }
            catch (Exception ex)
            {
                //display message box???
                return false;
            }
		}

		public void ReviewQualityCheck()
		{
		}
	};
}