using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;

namespace WSCAutomation.Database
{
	// TODO: DatabaseManager methods relating to the Orders tables should go here

	partial class DatabaseManager
	{
		public int DBAddOrder(Orders.Order order)
		{
            //Replace with actual id to be returned
            //This is just a place holder to actually return a value for program to compile
            return -1;
		}

		public bool DBEditOrder(Orders.Order order)
		{
            //Need the code to actually edit the order object
            return false;
		}

        public List<Orders.Order> DBGetOrders(int orderID = -1, int customerId = -1, int empId = -1)
		{
            return null;
		}
	};
}